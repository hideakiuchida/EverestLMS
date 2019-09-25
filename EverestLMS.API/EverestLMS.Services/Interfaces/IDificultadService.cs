using EverestLMS.ViewModels.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IDificultadService
    {
        Task<IEnumerable<DificultadVM>> GetAllAsync();
    }
}
