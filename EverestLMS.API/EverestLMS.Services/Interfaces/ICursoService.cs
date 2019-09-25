using EverestLMS.ViewModels.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoPredictionVM>> GetCursosPredictionByParticipantAsync(int id);
        Task<IEnumerable<CursoPredictedByParticipantVM>> GetAllCursosPredictionByParticipantAsync();
        Task<IEnumerable<CursoDetalleVM>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search);
        Task<int> CreateCursoAsync(CursoVM cursoVM);
        Task<bool> EditCursoASync(CursoVM cursoVM);
        Task<bool> DeleteCursoAsync(int idEtapa, int idCurso);
    }
}
