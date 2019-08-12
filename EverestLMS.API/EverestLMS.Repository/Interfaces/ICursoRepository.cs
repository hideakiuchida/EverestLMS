using EverestLMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoPredictionEntity>> GetCursosAsync(int? idLineaCarrera, int? idNivel);
    }
}
