using EverestLMS.ViewModels.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoPredictionVM>> GetCursosPredictionByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null);
        Task<IEnumerable<CursoVM>> GetCursosByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null);
        Task<IEnumerable<CursoPredictedByParticipantVM>> GetAllCursosPredictionByParticipantAsync();
        Task<IEnumerable<CursoDetalleVM>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search);
        Task<int> CreateCursoAsync(CursoToCreateVM cursoVM);
        Task<bool> EditCursoASync(CursoToUpdateVM cursoVM);
        Task<bool> DeleteCursoAsync(int idEtapa, int idCurso);
        Task<CursoToUpdateVM> GetCursoAsync(int idEtapa, int idCurso);
        Task<CursoDetalleVM> GetCursoDetalleByParticipanteAsync(string idParticipante, int idEtapa, int idCurso);
    }

}
