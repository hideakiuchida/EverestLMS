using EverestLMS.ViewModels.LineaCarrera;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ILineaCarreraService
    {
        Task<IEnumerable<LineaCarreraVM>> GetAllAsync();
    }
}
