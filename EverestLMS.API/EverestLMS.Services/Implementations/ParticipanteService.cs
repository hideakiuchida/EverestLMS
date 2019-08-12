using AutoMapper;
using EverestLMS.Common.Enums;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Asignacion;
using EverestLMS.ViewModels.Conocimiento;
using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository repository;
        private readonly IConocimientoRepository conocimientoRepository;
        private readonly IConfiguration config;
        private readonly IMapper mapper;


        public ParticipanteService(IParticipanteRepository repository, IConocimientoRepository conocimientoRepository, IMapper mapper, IConfiguration config)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.conocimientoRepository = conocimientoRepository;
            this.config = config;
        }

        public async Task<int> CreateAsync(ParticipanteToCreateVM participanteToCreate)
        {
            participanteToCreate.Nombre = participanteToCreate.Nombre.FirstCharToUpper();
            participanteToCreate.Apellido = participanteToCreate.Apellido.FirstCharToUpper();
            var participanteToRepo = mapper.Map<ParticipanteEntity>(participanteToCreate);

            var idParticipante = await repository.CreateAsync(participanteToRepo);
            foreach (var id in participanteToCreate.ConocimientoIds)
            {
                var conocimientoParticipanteEntity = new ConocimientoParticipanteEntity { IdConocimiento = id, IdParticipante = idParticipante };
                await conocimientoRepository.CreateConocimientoParticipanteAsync(conocimientoParticipanteEntity);
            }
            return idParticipante;
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
            if (escalador is null)
                return default;
            var conocimientos = await conocimientoRepository.GetConocimientoByParticipanteIdAsync(id);
            var escaladorToReturn = mapper.Map<EscaladorVM>(escalador);
            var conocimientosToReturn = mapper.Map<ICollection<ConocimientoVM>>(conocimientos);
            escaladorToReturn.Conocimientos = conocimientosToReturn;
            return escaladorToReturn;
        }

        public async Task<SherpaVM> GetSherpaDetailAsync(int id)
        {
            var sherpa = await repository.GetByIdAsync(id);
            if (sherpa is null)
                return default;
            var conocimientos = await conocimientoRepository.GetConocimientoByParticipanteIdAsync(id);
            var escaladores = await repository.GetEscaladoresPorSherpaIdAsync(sherpa.IdParticipante);

            var escaladoresToReturn = mapper.Map<ICollection<EscaladorLiteVM>>(escaladores);
            var sherpaToReturn = mapper.Map<SherpaVM>(sherpa);;
            var conocimientosToReturn = mapper.Map<ICollection<ConocimientoVM>>(conocimientos);

            sherpaToReturn.Conocimientos = conocimientosToReturn;
            sherpaToReturn.Escaladores = escaladoresToReturn;
            return sherpaToReturn;
        }

        public async Task<IEnumerable<SherpaLiteVM>> GetSherpasAsync(int? idNivel = null, int? idLineaCarrera = null, string sede = null, string search = null)
        {
            var sherpas = await repository.GetSherpasAsync(idNivel, idLineaCarrera, sede, search);
            var sherpasToReturn = mapper.Map<IEnumerable<SherpaLiteVM>>(sherpas);
            return sherpasToReturn;
        }

        public async Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresPorSherpaIdAsync(int id)
        {
            var escaladores = await repository.GetEscaladoresPorSherpaIdAsync(id);
            var escaladoresToReturn = mapper.Map<IEnumerable<EscaladorLiteVM>>(escaladores);
            return escaladoresToReturn;
        }

        public async Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, string sede = null, string search = null)
        {
            var escaladores = await repository.GetEscaladoresNoAsignadosAsync(idLineaCarrera, sede, search);
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
            IEnumerable<int> lineaCarreras = new List<int>() { (int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.DevOpsEngineer,
                (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance, (int)LineaCarreraEnum.SoftwareEngineer};

            IEnumerable<string> sedes = new List<string>() { SedeEnum.Cochabamba.ToString(), SedeEnum.Liberia.ToString(), SedeEnum.Lima.ToString(),
                SedeEnum.SanCarlos.ToString(), SedeEnum.SanJose.ToString() };
            int countNoAsignados = default;
            int countAsignadosTotal = default;
            int maxQuantityEscaladores = config.GetValue<int>("AppSettings:MaximunQuantityEscaladores");
            foreach (var idLineaCarrera in lineaCarreras)
            {
                foreach (var sede in sedes)
                {
                    var escaladoresNoAsignados = (await repository.GetEscaladoresNoAsignadosAsync(idLineaCarrera, sede, default)).ToList();
                    if (escaladoresNoAsignados.Count == 0)
                        continue;

                    var dicSherpaCantidadNoAsignados = await GetSherpasNoAsignadosCompletamenteAsync(idLineaCarrera, sede, maxQuantityEscaladores);
                    int countAsignamiento = 0;
                    foreach (var dicItem in dicSherpaCantidadNoAsignados)
                    {
                        var idSherpa = dicItem.Key;
                        var cantidadParaAsignar = dicItem.Value;
                        var startIndex = countAsignamiento;
                        var length = countAsignamiento + cantidadParaAsignar;
                        for (int i = startIndex; i < length; i++)
                        {
                            if (escaladoresNoAsignados.Count > default(int) && (escaladoresNoAsignados.Count - 1) < i)
                                break;
                            escaladoresNoAsignados[i].IdSherpa = idSherpa;
                            countAsignamiento++;
                        }
                        var idEscaladores = escaladoresNoAsignados.Where(x => x.IdSherpa == idSherpa).Select(x => x.IdParticipante).ToArray();
                        if (idEscaladores.Length > default(int))
                        {
                            var saved = await repository.AsignarAutomaticamenteAsync(idSherpa, idEscaladores);
                            if (!saved)
                                return $"Ocurrió un error en asignación para el sherpa {idSherpa}.";
                        }
                        else
                            continue;
                    }
                    countNoAsignados += escaladoresNoAsignados.Count - countAsignamiento;
                    countAsignadosTotal += countAsignamiento;
                }  
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

        public async Task<string> ProcesarDesasignacionAutomatica()
        {
            var succeded = await repository.DesasignacionAutomatica();
            if (succeded)
                return "Se generó la deasignación existosamente.";
            else
                return "No se pudo generar la desasignación.";
        }

        #region Private
        private async Task<Dictionary<int, int>> GetSherpasNoAsignadosCompletamenteAsync(int idLineaCarrera, string sede, int maxQuantityEscaladores)
        {
            Dictionary<int, int> dicSherpaCantidadNoAsignados = new Dictionary<int, int>();
            var sherpas = await GetSherpasAsync(default, idLineaCarrera, sede);
            foreach (var sherpa in sherpas)
            {
                var escaladoresPorSherpa = (await repository.GetEscaladoresPorSherpaIdAsync(sherpa.Id)).ToList();
                if (escaladoresPorSherpa.Count >= maxQuantityEscaladores)
                    continue;
                var cantidadNoAsignados = maxQuantityEscaladores - escaladoresPorSherpa.Count;
                dicSherpaCantidadNoAsignados.Add(sherpa.Id, cantidadNoAsignados);
            }
            return dicSherpaCantidadNoAsignados;
        }
        #endregion
    }
}
