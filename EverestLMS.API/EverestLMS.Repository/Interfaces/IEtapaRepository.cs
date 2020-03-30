using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IEtapaRepository
    {
        Task<IEnumerable<EtapaEntity>> GetAllAsync(int? idNivel, int? idLineaCarrera, string search);
        Task<IEnumerable<EtapaEntity>> GetByParticipanteAsync(string idParticipante);
    }
}
