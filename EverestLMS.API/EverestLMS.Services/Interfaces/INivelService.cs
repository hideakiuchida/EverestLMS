using EverestLMS.ViewModels.Nivel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface INivelService
    {
        Task<IEnumerable<NivelVM>> GetAllAsync();
    }
}
