using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IExamenRepository
    {
        public Task<int> CreateExamenAsync(ExamenEntity entity);
        public Task<int> CreateQandAEscaladorAsync(int idExamen, RespuestaEscaladorEntity entity);
        public Task<ExamenEntity> GetExamenAsync(int id);
        public Task<IEnumerable<RespuestaEscaladorEntity>> GetPreguntasDelExamenAsync(int id);
        public Task<bool> UpdateExamenAsync(ExamenEntity entity);
        public Task<bool> UpdateRespuestaDelExamenAsync(int idExamen, RespuestaEscaladorEntity entity);
    }
}
