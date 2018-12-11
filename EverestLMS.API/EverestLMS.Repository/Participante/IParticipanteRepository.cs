using EverestLMS.ViewModels.Participante.Sherpa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Participante
{
    public interface IParticipanteRepository : IEverestRepository<Entities.POCO.Participante> 
    {
        Task<Entities.POCO.Participante> GetByIdAsync(int id);
        Task<IEnumerable<Entities.POCO.Participante>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, string search);
        Task<IEnumerable<Entities.POCO.Participante>> GetEscaladoresPorSherpaIdAsync(int id);
        Task<IEnumerable<Entities.POCO.Participante>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, string search);
        Task<bool> AsignarAsync(int idEscalador, int idSherpa);
        Task<bool> AsignarAutomaticamenteAsync(IEnumerable<Entities.POCO.Participante> escaladores);
        Task<bool> DesasignarAsync(int idEscalador);
    }
}
