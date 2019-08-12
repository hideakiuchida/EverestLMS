using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IRatingCursoRepository
    {
        Task<int> CreateAsync(RatingCursoEntity entity);

        Task<IEnumerable<RatingCursoEntity>> GetAllAsync();

        Task<int> RemoveAllAsync();
    }
}
