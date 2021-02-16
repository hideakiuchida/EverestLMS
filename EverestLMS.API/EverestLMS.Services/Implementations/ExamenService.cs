using AutoMapper;
using EverestLMS.Common.Exceptions;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Examen;
using EverestLMS.ViewModels.Leccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class ExamenService : IExamenService
    {
        private readonly IExamenRepository repository;
        private readonly ILeccionRepository leccionRepository;
        private readonly IMapper mapper;
        public ExamenService(IExamenRepository repository, ILeccionRepository leccionRepository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.leccionRepository = leccionRepository;
        }

        public async Task<string> GenerarExamenAsync(string idEscalador, int idEtapa, int idCurso)
        {
            var leccionesPorCurso = await this.leccionRepository.GetLeccionesDetalleAsync(default, default, idEtapa, idCurso, default);
            List<PreguntaEntity> preguntas = new List<PreguntaEntity>();
            foreach (var leccion in leccionesPorCurso)
            {
                var preguntasPorLeccion = await this.leccionRepository.GetPreguntasAsync(leccion.IdLeccion);
                preguntas.AddRange(preguntasPorLeccion);
            }

            if (!preguntas.Any())
                return "No se puedo obtener las preguntas para crear el examen.";

            var examen = new ExamenEntity(default)
            {
                UsuarioKey = idEscalador,
                IdEtapa = idEtapa,
                IdCurso = idCurso,
                NumeroPreguntaActual = 1
            };

            preguntas.Shuffle();
            var genaracionPreguntasExitoso = examen.GenerarDiversidadPreguntasExamenPorCurso(preguntas);
            if (!genaracionPreguntasExitoso)
                return "No se pudo generar preguntas para el examen.";

            return await CrearExamenPreguntas(examen);
        }

        public async Task<string> GenerarExamenAsync(string idEscalador, int idEtapa, int idCurso, int idLeccion)
        {
            var preguntasPorLeccion = await this.leccionRepository.GetPreguntasAsync(idLeccion);

            if (!preguntasPorLeccion.Any())
                return "No se puedo obtener las preguntas para crear el examen.";

            var examen = new ExamenEntity(idLeccion)
            {
                UsuarioKey = idEscalador,
                IdEtapa = idEtapa,
                IdCurso = idCurso,
                NumeroPreguntaActual = 1
            };

            var genaracionPreguntasExitoso = examen.GenerarPreguntasExamenPorLeccion(preguntasPorLeccion as IList<PreguntaEntity>);
            if (!genaracionPreguntasExitoso)
                return "No se pudo generar preguntas para el examen.";

            return await CrearExamenPreguntas(examen);
        }

        private async Task<string> CrearExamenPreguntas(ExamenEntity examen)
        {
            var idExamen = await this.repository.CreateExamenAsync(examen);

            if (idExamen == default)
                return "No se puedo crear el examen.";

            var registroPreguntasExitoso = await CrearPreguntasParaExamenAsync(idExamen, examen.EscaladorRespuestas);
            if (!registroPreguntasExitoso)
                return "No se puedo registrar las preguntas para el examen.";

            return idExamen.ToString();
        }

        private async Task<bool> CrearPreguntasParaExamenAsync(int idExamen, IList<RespuestaEscaladorEntity> respuestasEscalador)
        {
            int numeroOrden = default;
            foreach (var pregunta in respuestasEscalador)
            {
                pregunta.NumeroOrden = ++numeroOrden;
                var idQandAEscalador = await this.repository.CreateQandAEscaladorAsync(idExamen, pregunta);
                if (idQandAEscalador == default)
                    return false;
            }
            return true;
        }

        public async Task<ExamenVM> GetExamenPorIdAsync(int id)
        {
            var examen = await this.repository.GetExamenAsync(id);
            var examenVM = this.mapper.Map<ExamenVM>(examen);
            return examenVM;
        }

        public async Task<PreguntaExamenVM> GetPreguntaDelExamenAsync(int idExamen, int numeroPregunta)
        {
            var examenPreguntas = await this.repository.GetPreguntasDelExamenAsync(idExamen);
            var examenPreguntaNoResuelta = examenPreguntas.FirstOrDefault(x => x.NumeroOrden == numeroPregunta);
            if (examenPreguntaNoResuelta == null)
                return default;
            var respuestasDePregunta = await leccionRepository.GetRespuestasAsync(examenPreguntaNoResuelta.IdPregunta);
            var examenPreguntaVM = this.mapper.Map<PreguntaExamenVM>(examenPreguntaNoResuelta);
            examenPreguntaVM.Respuestas = this.mapper.Map<IEnumerable<RespuestaVM>>(respuestasDePregunta);
            return examenPreguntaVM;
        }

        public async Task<bool> UpdateExamenAsync(int idExamen, ExamenToUpdateVM examenToUpdateVM)
        {
            var examen = this.mapper.Map<ExamenEntity>(examenToUpdateVM);
            examen.Id = idExamen;
            if (examenToUpdateVM.Finalizado)
            {
                examen.EscaladorRespuestas = await repository.GetPreguntasDelExamenAsync(idExamen) as IList<RespuestaEscaladorEntity>;
                examen.CalcularNota();
                examen.FechaFinalizado = DateTime.UtcNow;
            }    
            return await this.repository.UpdateExamenAsync(examen);
        }

        public async Task<bool> UpdateRespuestaAsync(int idExamen, int idRespuesta, RespuestaExamenToUpdateVM respuestaExamenToUpdateVM)
        {
            var respuestaToUpdate = this.mapper.Map<RespuestaEscaladorEntity>(respuestaExamenToUpdateVM);
            respuestaToUpdate.Id = idRespuesta;
            var respuesta = await leccionRepository.GetSpecificRespuestaAsync(respuestaToUpdate.IdRespuesta);
            respuestaToUpdate.MarcoCorrecto = respuesta.EsCorrecto;
            return await this.repository.UpdateRespuestaDelExamenAsync(idExamen, respuestaToUpdate);
        }
    }
}
