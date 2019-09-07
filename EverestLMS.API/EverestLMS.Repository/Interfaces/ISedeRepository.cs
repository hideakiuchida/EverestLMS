using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ISedeRepository
    {
        Task<IEnumerable<SedeEntity>> GetAllAsync();
    }
}
