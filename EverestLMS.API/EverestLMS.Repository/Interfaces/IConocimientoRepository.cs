using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IConocimientoRepository
    {
        Task<ConocimientoEntity> GetByIdAsync(int? id);
        Task<IEnumerable<ConocimientoEntity>> GetConocimientoByParticipanteIdAsync(string id);
        Task<int> CreateConocimientoParticipanteAsync(ConocimientoParticipanteEntity conocimientoParticipanteEntity);
    }
}
