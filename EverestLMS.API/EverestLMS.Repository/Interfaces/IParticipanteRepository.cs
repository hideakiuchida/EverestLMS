using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IParticipanteRepository  
    {
        Task<IEnumerable<ParticipanteEntity>> GetAllAsync();
        Task<ParticipanteEntity> GetByIdAsync(string id);
        Task<IEnumerable<ParticipanteEntity>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, int? idSede, string search);
        Task<IEnumerable<ParticipanteEntity>> GetEscaladoresPorSherpaIdAsync(string id);
        Task<IEnumerable<ParticipanteEntity>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, int? idSede, string search);
        Task<bool> AsignarAsync(string idEscalador, string idSherpa);
        Task<bool> AsignarAutomaticamenteAsync(int idSherpa, int[] idsEscaladores);
        Task<bool> DesasignarAsync(string idEscalador);
        Task<bool> DesasignacionAutomatica();
        Task<IEnumerable<ParticipanteEntity>> GetParticipantesAsync(int? idLineaCarrera, int? idNivel);
        Task<int> CreateAsync(ParticipanteEntity participanteEntity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ActualizarPuntajeAsync(string id, int puntaje);
    }
}
