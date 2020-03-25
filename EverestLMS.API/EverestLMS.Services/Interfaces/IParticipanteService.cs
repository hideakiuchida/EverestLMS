using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using System.Collections.Generic;
using System.Threading.Tasks;
using EverestLMS.ViewModels.Asignacion;

namespace EverestLMS.Services.Interfaces
{
    public interface IParticipanteService
    {
        Task<IEnumerable<ParticipanteVM>> GetAllAsync();
        Task<int> CreateAsync(ParticipanteToCreateVM participanteToCreate);
        Task<IEnumerable<SherpaLiteVM>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, int? idSede, string search);
        Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresPorSherpaIdAsync(int id);
        Task<EscaladorVM> GetEscaladorDetailAsync(int id);
        Task<SherpaVM> GetSherpaDetailAsync(int id);
        Task<IEnumerable<EscaladorLiteVM>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, int? idSede, string search);
        Task<string> AsignarAsync(AsignacionToCreateVM asignacionToCreateVM);
        Task<string> ProcesarAsignacionAutomatica();
        Task<string> ProcesarDesasignacionAutomatica(); 
        Task<string> DesasignarAsync(AsignacionToCreateVM asignacionToCreateVM);
        Task<bool> DeleteAsync(int id);
    }
}
