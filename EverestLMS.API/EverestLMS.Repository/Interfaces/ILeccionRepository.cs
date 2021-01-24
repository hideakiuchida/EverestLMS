using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ILeccionRepository
    {
        Task<IEnumerable<LeccionDetalleEntity>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search);
        Task<LeccionEntity> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion);
        Task<int> CreateLeccionAsync(LeccionEntity leccionEntity);
        Task<bool> UpdateLeccionAsync(LeccionEntity leccionEntity);
        Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion);
        Task<IEnumerable<PreguntaEntity>> GetPreguntasAsync(int idLeccion);
        Task<PreguntaEntity> GetSpecificPreguntaAsync(int idPregunta);
        Task<int> CreatePreguntaAsync(PreguntaEntity entity);
        Task<bool> DeletePreguntaAsync(int idPregunta);
        Task<IEnumerable<RespuestaEntity>> GetRespuestasAsync(int idPregunta);
        Task<RespuestaEntity> GetSpecificRespuestaAsync(int idRespuesta);
        Task<int> CreateRespuestaAsync(RespuestaEntity entity);
        Task<bool> DeleteRespuestaAsync(int idRespuesta);
        Task<bool> UpdatePreguntaAsync(PreguntaEntity entity);
        Task<bool> UpdateRespuestaAsync(RespuestaEntity entity);
    }
}
