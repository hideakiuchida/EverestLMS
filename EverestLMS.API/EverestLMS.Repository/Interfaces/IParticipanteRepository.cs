using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IParticipanteRepository  
    {
        Task<IEnumerable<ParticipanteEntity>> GetAllAsync();
        Task<ParticipanteEntity> GetByIdAsync(int id);
        Task<IEnumerable<ParticipanteEntity>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, int? idSede, string search);
        Task<IEnumerable<ParticipanteEntity>> GetEscaladoresPorSherpaIdAsync(int id);
        Task<IEnumerable<ParticipanteEntity>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, int? idSede, string search);
        Task<bool> AsignarAsync(int idEscalador, int idSherpa);
        Task<bool> AsignarAutomaticamenteAsync(int idSherpa, int[] idsEscaladores);
        Task<bool> DesasignarAsync(int idEscalador);
        Task<bool> DesasignacionAutomatica();
        Task<IEnumerable<ParticipanteEntity>> GetParticipantesAsync(int? idLineaCarrera, int? idNivel);
        Task<int> CreateAsync(ParticipanteEntity participanteEntity);
    }
}
