﻿using EverestLMS.ViewModels.Leccion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ILeccionService
    {
        Task<IEnumerable<LeccionDetalleVM>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search);
        Task<LeccionVM> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion);
        Task<int> CreateLeccionAsync(LeccionToCreateVM leccionVM);
        Task<bool> EditLeccionAsync(LeccionToUpdateVM leccionVM);
        Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion);
        Task<IEnumerable<LeccionMaterialVM>> GetLeccionMaterialesAsync(int idLeccion);
        Task<LeccionMaterialDetalleVM> GetSpecificLeccionMaterialAsync(int idLeccion, int idLeccionMaterial);
        Task<int> CreateLeccionMaterialAsync(LeccionMaterialToCreateVM leccionMaterialVM);
        Task<int> CreateLeccionVideoMaterialAsync(LeccionMaterialVideoToCreateVM leccionMaterialVM);
        Task<bool> DeleteLeccionMaterialAsync(int idLeccion, int idLeccionMaterial);
        Task<IEnumerable<PreguntaVM>> GetPreguntasAsync(int idLeccion);
        Task<PreguntaVM> GetSpecificPreguntaAsync(int idPregunta);
        Task<int> CreatePreguntaAsync(PreguntaToCreateVM preguntaToCreateVM);
        Task<bool> DeletePreguntaAsync(int idPregunta);
        Task<IEnumerable<RespuestaVM>> GetRespuestasAsync(int idPregunta);
        Task<RespuestaVM> GetSpecificRespuestaAsync(int idRespuesta);
        Task<int> CreateRespuestaAsync(RespuestaToCreateVM respuestaToCreateVM);
        Task<bool> DeleteRespuestaAsync(int idRespuesta);
        Task<bool> UpdatePreguntaAsync(PreguntaVM preguntaToUpdateVM);
        Task<bool> UpdateRespuestaAsync(RespuestaVM respuestaToUpdateVM);
    }
}
