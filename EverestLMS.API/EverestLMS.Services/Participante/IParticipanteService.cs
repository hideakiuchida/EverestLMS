﻿using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using System.Collections.Generic;
using System.Threading.Tasks;
using EverestLMS.ViewModels.Asignacion;

namespace EverestLMS.Services.Participante
{
    public interface IParticipanteService
    {
        Task<IEnumerable<ParticipanteVM>> GetAllAsync();
        Task<ParticipanteVM> CreateAsync(ParticipanteToCreateVM participanteToCreate);
        Task<IEnumerable<SherpaLiteVM>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, string search);
        Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresPorSherpaIdAsync(int id);
        Task<EscaladorVM> GetEscaladorDetailAsync(int id);
        Task<SherpaVM> GetSherpaDetailAsync(int id);
        Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, string search);
        Task<string> AsignarAsync(AsignacionToCreateVM asignacionToCreateVM);
        Task<string> ProcesarAsignacionAutomatica();
        Task<string> DesasignarAsync(AsignacionToCreateVM asignacionToCreateVM);
    }
}
