using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoPredictionEntity>> GetCursosPredictionByParticipanteAsync(int idParticipante, int? idEtapa = null, int? idIdioma = null);
        Task<IEnumerable<CursoEntity>> GetCursosByParticipanteAsync(int idParticipante, int? idEtapa = null, int? idIdioma = null);
        Task<IEnumerable<CursoDetalleEntity>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search);
        Task<int> CreateCursoAsync(CursoEntity cursoEntity);
        Task<bool> EditCursoASync(CursoEntity cursoEntity);
        Task<bool> DeleteCursoAsync(int idEtapa, int idCurso);
        Task<CursoToUpdateEntity> GetCursoAsync(int idEtapa, int idCurso);
    }
}
