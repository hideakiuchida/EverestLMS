using EverestLMS.ViewModels.Nivel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Services.NivelService
{
    public interface INivelService
    {
        Task<IEnumerable<NivelVM>> GetAllAsync();
    }
}
