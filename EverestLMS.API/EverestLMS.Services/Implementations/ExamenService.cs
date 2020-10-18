using AutoMapper;
using EverestLMS.Common.Enums.ErrorManagement;
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

        public async Task<int> GenerarExamenAsync(string idEscalador, int idCurso)
        {
            var examen = new ExamenEntity(default)
            {
                UsuarioKey = idEscalador,
                IdCurso = idCurso
            };
            var idExamen = await this.repository.CreateExamenAsync(examen);

            if(idExamen == default)
                return (int)ExamenErrorEnum.ERROR_CREAR_EXAMEN;
            // return $"No se creó el examen del curso {idCurso}";

            var leccionesPorCurso = await this.leccionRepository.GetLeccionesDetalleAsync(default, default, default, idCurso, default);
            List<PreguntaEntity> preguntas = new List<PreguntaEntity>();
            foreach (var leccion in leccionesPorCurso)
            {
                var preguntasPorLeccion = await this.leccionRepository.GetPreguntasAsync(leccion.IdLeccion);
                preguntas.AddRange(preguntasPorLeccion);
            }

            if (!preguntas.Any())
                return (int)ExamenErrorEnum.ERROR_NO_ENCUENTRA_PREGUNTAS;

            preguntas.Shuffle();
            var genaracionPreguntasExitoso = examen.GenerarDiversidadPreguntasExamenPorCurso(preguntas);
            if (!genaracionPreguntasExitoso)
                return (int)ExamenErrorEnum.ERROR_GENERACION_PREGUNTAS;
            // return $"No se generó correctamente las preguntas del examen del curso {idCurso}";

            var registroPreguntasExitoso = await CrearPreguntasParaExamenAsync(idExamen, examen.EscaladorRespuestas);
            if (!registroPreguntasExitoso)
                return (int)ExamenErrorEnum.ERROR_REGISTRO_PREGUNTAS;
            //  return $"No se registró correctamente las preguntas del examen {idExamen}";

            return idExamen;
        }

        public async Task<int> GenerarExamenAsync(string idEscalador, int idCurso, int idLeccion)
        {
            var examen = new ExamenEntity(idLeccion)
            {
                UsuarioKey = idEscalador,
                IdCurso = idCurso
            };
            var idExamen = await this.repository.CreateExamenAsync(examen);

            if (idExamen == default)
                return (int)ExamenErrorEnum.ERROR_CREAR_EXAMEN;
               // return $"No se creó el examen de la lección {idLeccion}";

            var preguntasPorLeccion = await this.leccionRepository.GetPreguntasAsync(idLeccion);

            var genaracionPreguntasExitoso = examen.GenerarPreguntasExamenPorLeccion(preguntasPorLeccion as IList<PreguntaEntity>);
            if (!genaracionPreguntasExitoso)
                return (int)ExamenErrorEnum.ERROR_GENERACION_PREGUNTAS;
            //return $"No se generó correctamente las preguntas del examen del curso {idCurso}";

            var registroPreguntasExitoso = await CrearPreguntasParaExamenAsync(idExamen, examen.EscaladorRespuestas);
            if (!registroPreguntasExitoso)
                return (int)ExamenErrorEnum.ERROR_REGISTRO_PREGUNTAS;
            //  return $"No se registró correctamente las preguntas del examen {idExamen}";

            return idExamen;
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

        public async Task<PreguntaExamenVM> GetPreguntaDelExamenAsync(int idExamen)
        {
            var examenPreguntas = await this.repository.GetPreguntasDelExamenAsync(idExamen);
            var examenPreguntaNoResuelta = examenPreguntas
                                           .OrderBy(x => x.NumeroOrden)
                                           .FirstOrDefault(x => !x.MarcoCorrecto.HasValue);
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
