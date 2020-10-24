using EverestLMS.ViewModels.Examen;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IExamenService
    {
        public Task<int> GenerarExamenAsync(string idEscalador, int idCurso);
        public Task<int> GenerarExamenAsync(string idEscalador, int idCurso, int idLeccion);
        public Task<ExamenVM> GetExamenPorIdAsync(int id);
        public Task<PreguntaExamenVM> GetPreguntaDelExamenAsync(int idExamen, int numeroPregunta);
        public Task<bool> UpdateRespuestaAsync(int idExamen, int idRespuesta, RespuestaExamenToUpdateVM respuestaExamenToUpdateVM);
        public Task<bool> UpdateExamenAsync(int idExamen, ExamenToUpdateVM examenToUpdateVM);
    }
}
