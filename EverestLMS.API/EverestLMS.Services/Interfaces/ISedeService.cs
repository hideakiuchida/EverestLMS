using EverestLMS.ViewModels.Sede;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ISedeService
    {
        Task<IEnumerable<SedeVM>> GetAllAsync();
    }
}
