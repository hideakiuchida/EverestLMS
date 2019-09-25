using EverestLMS.ViewModels.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IIdiomaService
    {
        Task<IEnumerable<IdiomaVM>> GetAllAsync();
    }
}
