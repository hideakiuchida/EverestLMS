using AutoMapper;
using EverestLMS.Common.Enums;
using EverestLMS.Common.Exceptions;
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
using System;
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

        public async Task<EscaladorVM> GetEscaladorDetailAsync(string id)
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

        public async Task<SherpaVM> GetSherpaDetailAsync(string id)
        {
            var sherpa = await repository.GetByIdAsync(id);
            if (sherpa is null)
                return default;
            var conocimientos = await conocimientoRepository.GetConocimientoByParticipanteIdAsync(id);
            var escaladores = await repository.GetEscaladoresPorSherpaIdAsync(sherpa.UsuarioKey);

            var escaladoresToReturn = mapper.Map<ICollection<EscaladorLiteVM>>(escaladores);
            var sherpaToReturn = mapper.Map<SherpaVM>(sherpa);
            var conocimientosToReturn = mapper.Map<ICollection<ConocimientoVM>>(conocimientos);

            sherpaToReturn.Conocimientos = conocimientosToReturn;
            sherpaToReturn.Escaladores = escaladoresToReturn;
            return sherpaToReturn;
        }

        public async Task<IEnumerable<SherpaLiteVM>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, int? idSede, string search)
        {
            var sherpas = await repository.GetSherpasAsync(idNivel, idLineaCarrera, idSede, search);
            var sherpasToReturn = mapper.Map<IEnumerable<SherpaLiteVM>>(sherpas);
            return sherpasToReturn;
        }

        public async Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresPorSherpaIdAsync(string id)
        {
            var escaladores = await repository.GetEscaladoresPorSherpaIdAsync(id);
            var escaladoresToReturn = mapper.Map<IEnumerable<EscaladorLiteVM>>(escaladores);
            return escaladoresToReturn;
        }

        public async Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, int? idSede, string search)
        {
            var escaladores = await repository.GetEscaladoresNoAsignadosAsync(idLineaCarrera, idSede, search);
            var escaladoresToReturn = mapper.Map<IEnumerable<EscaladorLiteVM>>(escaladores);
            return escaladoresToReturn;
        }

        public async Task<string> AsignarAsync(AsignacionToCreateVM asignacionToCreateVM)
        {
            var succeded = await repository.AsignarAsync(asignacionToCreateVM.IdEscalador, asignacionToCreateVM.IdSherpa);
            if (succeded)
                return $"Se asigno existosamente.";
            else
                return $"No se pudo asignar escalador.";
        }

        public async Task<string> ProcesarAsignacionAutomatica()
        {
            IEnumerable<int> lineaCarreras = new List<int>() { (int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.DevOpsEngineer,
                (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance, (int)LineaCarreraEnum.SoftwareEngineer};

            IEnumerable<int> sedes = new List<int>() { (int)SedeEnum.Cochabamba,(int) SedeEnum.Liberia, (int)SedeEnum.Lima,
                (int)SedeEnum.SanCarlos, (int)SedeEnum.SanJose };
            int countNoAsignados = default;
            int countAsignadosTotal = default;
            int maxQuantityEscaladores = Convert.ToInt32(config.GetSection("AppSettings:MaximunQuantityEscaladores").Value);
            foreach (var idLineaCarrera in lineaCarreras)
            {
                foreach (var idSede in sedes)
                {
                    var escaladoresNoAsignados = (await repository.GetEscaladoresNoAsignadosAsync(idLineaCarrera, idSede, default)).ToList();
                    if (escaladoresNoAsignados.Count == 0)
                        continue;

                    var dicSherpaCantidadNoAsignados = await GetSherpasNoAsignadosCompletamenteAsync(idLineaCarrera, idSede, maxQuantityEscaladores);
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
                                return $"Ocurrió un error en la asignación para el sherpa {idSherpa}.";
                        }
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
                return "No se pudo generar la des asignación.";
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await repository.DeleteAsync(id);
            return result;
        }

        public async Task<int> ActualizarPuntajeAsync(EscaladorPuntajeToUpdateVM requestUpdateVM)
        {
            var user = await repository.GetByIdAsync(requestUpdateVM.Id);
            var puntaje = user.Puntaje.Value + requestUpdateVM.Puntaje;
            var succeded = await repository.ActualizarPuntajeAsync(requestUpdateVM.Id, puntaje);
            if (!succeded) throw new LmsBaseException($"No se pudo actualizar el puntaje del escalador {requestUpdateVM.Id}");
            return puntaje;
        }

        #region Private
        private async Task<Dictionary<int, int>> GetSherpasNoAsignadosCompletamenteAsync(int idLineaCarrera, int idSede, int maxQuantityEscaladores)
        {
            Dictionary<int, int> dicSherpaCantidadNoAsignados = new Dictionary<int, int>();
            var sherpas = await repository.GetSherpasAsync(default, idLineaCarrera, idSede, default);
            foreach (var sherpa in sherpas)
            {
                var escaladoresPorSherpa = (await repository.GetEscaladoresPorSherpaIdAsync(sherpa.UsuarioKey)).ToList();
                if (escaladoresPorSherpa.Count >= maxQuantityEscaladores)
                    continue;
                var cantidadNoAsignados = maxQuantityEscaladores - escaladoresPorSherpa.Count;
                dicSherpaCantidadNoAsignados.Add(sherpa.IdParticipante, cantidadNoAsignados);
            }
            return dicSherpaCantidadNoAsignados;
        }
        #endregion
    }
}
