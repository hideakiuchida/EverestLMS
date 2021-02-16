using EverestLMS.ViewModels.Examen;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IExamenService
    {
        public Task<string> GenerarExamenAsync(string idEscalador, int idEtapa, int idCurso);
        public Task<string> GenerarExamenAsync(string idEscalador, int idEtapa, int idCurso, int idLeccion);
        public Task<ExamenVM> GetExamenPorIdAsync(int id);
        public Task<PreguntaExamenVM> GetPreguntaDelExamenAsync(int idExamen, int numeroPregunta);
        public Task<bool> UpdateRespuestaAsync(int idExamen, int idRespuesta, RespuestaExamenToUpdateVM respuestaExamenToUpdateVM);
        public Task<bool> UpdateExamenAsync(int idExamen, ExamenToUpdateVM examenToUpdateVM);
    }
}
