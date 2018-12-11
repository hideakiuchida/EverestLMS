using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EverestLMS.Common.Enums;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.POCO;
using EverestLMS.Repository.Participante;
using EverestLMS.ViewModels.Asignacion;
using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using System.Linq;
using EverestLMS.Repository.ConocimientoRepository;
using EverestLMS.ViewModels.Conocimiento;

namespace EverestLMS.Services.Participante
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository repository;
        private readonly IConocimientoRepository conocimientoRepository;
        private readonly IMapper mapper;

        public ParticipanteService(IParticipanteRepository repository, IConocimientoRepository conocimientoRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.conocimientoRepository = conocimientoRepository;
        }

        public async Task<ParticipanteVM> CreateAsync(ParticipanteToCreateVM participanteToCreate)
        {
            participanteToCreate.Nombre = participanteToCreate.Nombre.FirstCharToUpper();
            participanteToCreate.Apellido = participanteToCreate.Apellido.FirstCharToUpper();
            var participanteToRepo = mapper.Map<EverestLMS.Entities.POCO.Participante>(participanteToCreate);
            participanteToRepo.Activo = (int)EstadoEnum.Activo;
            List<ConocimientoParticipante> conocimientoParticipantes = new List<ConocimientoParticipante>();
            foreach (var id in participanteToCreate.ConocimientoIds)
            {
                conocimientoParticipantes.Add(new ConocimientoParticipante { IdConocimiento = id });
            }
            participanteToRepo.ConocimientoParticipantes = conocimientoParticipantes;

            var participanteFromRepo = await repository.CreateAsync(participanteToRepo);
            var participanteToReturn = mapper.Map<ParticipanteVM>(participanteFromRepo);
            return participanteToReturn;
        }

        public async Task<IEnumerable<ParticipanteVM>> GetAllAsync()
        {
            var participantes = await repository.GetAllAsync();
            var participantesToReturn = mapper.Map<IEnumerable<ParticipanteVM>>(participantes);
            return participantesToReturn;
        }

        public async Task<EscaladorVM> GetEscaladorDetailAsync(int id)
        {
            var escalador = await repository.GetByIdAsync(id);
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            if (escalador.ConocimientoParticipantes.Count > 0)
            {
                foreach (var item in escalador.ConocimientoParticipantes)
                {
                    var conocimiento = await conocimientoRepository.GetByIdAsync(item.IdConocimiento);
                    conocimientos.Add(conocimiento);
                }
            }
            var escaladorToReturn = mapper.Map<EscaladorVM>(escalador);
            var conocimientosToReturn = mapper.Map<ICollection<ConocimientoVM>>(conocimientos);
            escaladorToReturn.Conocimientos = conocimientosToReturn;
            return escaladorToReturn;
        }

        public async Task<SherpaVM> GetSherpaDetailAsync(int id)
        {
            var sherpa = await repository.GetByIdAsync(id);
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            if (sherpa.ConocimientoParticipantes.Count > 0)
            {         
                foreach (var item in sherpa.ConocimientoParticipantes)
                {
                    var conocimiento = await conocimientoRepository.GetByIdAsync(item.IdConocimiento);
                    conocimientos.Add(conocimiento);
                }
            }
            var escaladores = await repository.GetEscaladoresPorSherpaIdAsync(sherpa.IdParticipante);

            var escaladoresToReturn = mapper.Map<ICollection<EscaladorLiteVM>>(escaladores);
            var sherpaToReturn = mapper.Map<SherpaVM>(sherpa);
            var conocimientosToReturn = mapper.Map<ICollection<ConocimientoVM>>(conocimientos);

            sherpaToReturn.Conocimientos = conocimientosToReturn;
            sherpaToReturn.Escaladores = escaladoresToReturn;
            return sherpaToReturn;
        }

        public async Task<IEnumerable<SherpaLiteVM>> GetSherpasAsync(int? idNivel = null, int? idLineaCarrera = null, string search = null)
        {
            var sherpas = await repository.GetSherpasAsync(idNivel, idLineaCarrera, search);
            var sherpasToReturn = mapper.Map<IEnumerable<SherpaLiteVM>>(sherpas);
            return sherpasToReturn;
        }

        public async Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresPorSherpaIdAsync(int id)
        {
            var escaladores = await repository.GetEscaladoresPorSherpaIdAsync(id);
            var escaladoresToReturn = mapper.Map<IEnumerable<EscaladorLiteVM>>(escaladores);
            return escaladoresToReturn;
        }

        public async Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, string search = null)
        {
            var escaladores = await repository.GetEscaladoresNoAsignadosAsync(idLineaCarrera, search);
            var escaladoresToReturn = mapper.Map<IEnumerable<EscaladorLiteVM>>(escaladores);
            return escaladoresToReturn;
        }

        public async Task<string> AsignarAsync(AsignacionToCreateVM asignacionToCreateVM)
        {
            var succeded = await repository.AsignarAsync(asignacionToCreateVM.IdEscalador, asignacionToCreateVM.IdSherpa);
            if (succeded)
                return $"Se asigno existosamente escalador {asignacionToCreateVM.IdEscalador} al sherpa {asignacionToCreateVM.IdSherpa}";
            else
                return $"No se pudo asignar escalador {asignacionToCreateVM.IdEscalador} al sherpa {asignacionToCreateVM.IdSherpa}";
        }

        public async Task<string> ProcesarAsignacionAutomatica()
        {
            IEnumerable<LineaCarreraEnum> lineaCarreras = new List<LineaCarreraEnum>() { LineaCarreraEnum.BusinessAnalyst, LineaCarreraEnum.DevOpsEngineer,
                LineaCarreraEnum.MobileEngineer, LineaCarreraEnum.QualityAssurance, LineaCarreraEnum.SoftwareEngineer};
            int countNoAsignados = 0;
            int countAsignadosTotal = 0;
            foreach (var item in lineaCarreras)
            {
                Dictionary<int, int> dicSherpaCantidadNoAsignados = new Dictionary<int, int>();
                var idLineaCarrera = (int)item;
                var escaladoresNoAsignados = (await repository.GetEscaladoresNoAsignadosAsync(idLineaCarrera, null)).ToList();
                if (escaladoresNoAsignados.Count == 0)
                    continue;
                var sherpas = await GetSherpasAsync(null, idLineaCarrera);
                foreach (var sherpa in sherpas)
                {
                    var escaladoresPorSherpa = (await repository.GetEscaladoresPorSherpaIdAsync(sherpa.Id)).ToList();
                    if (escaladoresPorSherpa.Count >= 5)
                        continue;
                    var cantidadNoAsignados = 5 - escaladoresPorSherpa.Count;
                    dicSherpaCantidadNoAsignados.Add(sherpa.Id, cantidadNoAsignados);
                }

                int countAsignamiento = 0;
                foreach (var dicItem in dicSherpaCantidadNoAsignados)
                {
                    var idSherpa = dicItem.Key;
                    var cantidadNoAsignados = dicItem.Value;
                    var startIndex = countAsignamiento;
                    var length = countAsignamiento + cantidadNoAsignados;
                    for (int i = startIndex; i < length; i++)
                    {
                        if (escaladoresNoAsignados.Count > 0 && (escaladoresNoAsignados.Count - 1) < i)
                            break;
                        escaladoresNoAsignados[i].IdSherpa = idSherpa;
                        countAsignamiento++;
                    }
                }

                var saved = await repository.AsignarAutomaticamenteAsync(escaladoresNoAsignados);
                if (!saved)
                    return $"No se puedo grabar la asignación en la base de datos.";

                countNoAsignados += escaladoresNoAsignados.Count - countAsignamiento;
                countAsignadosTotal += countAsignamiento;

            }
            return $"Se asignaron {countAsignadosTotal} escaladores a sherpas y no se pudieron asignar {countNoAsignados} escaladores a sherpas.";
        }

        public async Task<string> DesasignarAsync(AsignacionToCreateVM asignacionToCreateVM)
        {
            var succeded = await repository.DesasignarAsync(asignacionToCreateVM.IdEscalador);
            if (succeded)
                return "Se eliminó la asignación existosamente.";
            else
                return "No se pudo eliminar la asignación.";
        }
    }
}
