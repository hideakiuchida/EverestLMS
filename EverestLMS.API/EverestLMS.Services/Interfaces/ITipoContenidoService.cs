using EverestLMS.ViewModels.TipoContenido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ITipoContenidoService
    {
        Task<IEnumerable<TipoContenidoVM>> GetAllAsync();
    }
}
