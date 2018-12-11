using EverestLMS.ViewModels.LineaCarrera;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Services.LineaCarreraService
{
    public interface ILineaCarreraService
    {
        Task<IEnumerable<LineaCarreraVM>> GetAllAsync();
    }
}
