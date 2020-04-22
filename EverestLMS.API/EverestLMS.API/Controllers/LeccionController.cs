using EverestLMS.Common.Enums;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Leccion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/etapas/{idEtapa}/cursos/{idCurso}/lecciones")]
    [ApiController]
    public class LeccionController : ControllerBase
    {
        private readonly ILeccionService leccionService;
        private readonly ICloudinaryFileService cloudinaryFileService;

        public LeccionController(ILeccionService leccionService, ICloudinaryFileService cloudinaryFileService)
        {
            this.leccionService = leccionService;
            this.cloudinaryFileService = cloudinaryFileService;
        }

        #region Leccion
        [HttpGet]
        public async Task<IActionResult> GetLeccionesDetalleAsync(int idEtapa, int idCurso, int? idLineaCarrera, int? idNivel, string search)
        {
            var result = await leccionService.GetLeccionesDetalleAsync(idNivel, idLineaCarrera, idEtapa, idCurso, search);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSpecificLeccionAsync(int idEtapa, int idCurso, int id)
        {
            var result = await leccionService.GetSpecificLeccionAsync(idEtapa, idCurso, id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeccionAsync(int idEtapa, int idCurso, [FromBody]LeccionToCreateVM leccionToCreateVM)
        {
            leccionToCreateVM.IdCurso = idCurso;
            var result = await leccionService.CreateLeccionAsync(leccionToCreateVM);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditLeccionAsync(int idEtapa, int idCurso, int id, [FromBody]LeccionToUpdateVM leccionToUpdateVM)
        {
            leccionToUpdateVM.IdCurso = idCurso;
            leccionToUpdateVM.Id = id;
            var result = await leccionService.EditLeccionAsync(leccionToUpdateVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLeccionAsync(int idEtapa, int idCurso, int id)
        {
            var result = await leccionService.DeleteLeccionAsync(idEtapa, idCurso, id);
            return Ok(result);
        }
        #endregion

        #region Leccion Material
        [HttpGet]
        [Route("{idLeccion}/lecciones-material")]
        public async Task<IActionResult> GetLeccionMaterialesAsync(int idEtapa, int idCurso, int idLeccion)
        {
            var result = await leccionService.GetLeccionMaterialesAsync(idLeccion);
            return Ok(result);
        }

        [HttpGet]
        [Route("{idLeccion}/lecciones-material/{idLeccionMaterial}")]
        public async Task<IActionResult> GetSpecificLeccionMaterialAsync(int idEtapa, int idCurso, int idLeccion, int idLeccionMaterial)
        {
            var result = await leccionService.GetSpecificLeccionMaterialAsync(idLeccion, idLeccionMaterial);
            return Ok(result);
        }

        [HttpPost]
        [Route("{idLeccion}/lecciones-material")]
        public async Task<IActionResult> CreateLeccionMaterialAsync(int idEtapa, int idCurso, int idLeccion, [FromBody]LeccionMaterialToCreateVM leccionMaterialToCreateVM)
        {
            leccionMaterialToCreateVM.IdLeccion = idLeccion;
            var result = await leccionService.CreateLeccionMaterialAsync(leccionMaterialToCreateVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{idLeccion}/lecciones-material/{idLeccionMaterial}")]
        public async Task<IActionResult> DeleteLeccionMaterialAsync(int idEtapa, int idCurso, int idLeccion, int idLeccionMaterial)
        {
            var result = await leccionService.DeleteLeccionMaterialAsync(idLeccion, idLeccionMaterial);
            return Ok(result);
        }
        #endregion

        #region Preguntas
        [HttpGet]
        [Route("{idLeccion}/preguntas")]
        public async Task<IActionResult> GetPreguntasAsync(int idLeccion)
        {
            var result = await leccionService.GetPreguntasAsync(idLeccion);
            return Ok(result);
        }

        [HttpGet]
        [Route("{idLeccion}/preguntas/{idPregunta}")]
        public async Task<IActionResult> GetSpecificPreguntaAsync(int idPregunta)
        {
            var result = await leccionService.GetSpecificPreguntaAsync(idPregunta);
            return Ok(result);
        }

        [HttpPost]
        [Route("{idLeccion}/preguntas")]
        public async Task<IActionResult> CreatePreguntaAsync(int idLeccion, [FromBody]PreguntaToCreateVM preguntaToCreateVM)
        {
            preguntaToCreateVM.IdLeccion = idLeccion;
            var result = await leccionService.CreatePreguntaAsync(preguntaToCreateVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{idLeccion}/preguntas/{idPregunta}")]
        public async Task<IActionResult> DeletePreguntaAsync(int idPregunta)
        {
            var result = await leccionService.DeletePreguntaAsync(idPregunta);
            return Ok(result);
        }
        #endregion

        #region Respuestas
        [HttpGet]
        [Route("{idLeccion}/preguntas/{idPregunta}/respuestas")]
        public async Task<IActionResult> GetRespuestasAsync(int idPregunta)
        {
            var result = await leccionService.GetRespuestasAsync(idPregunta);
            return Ok(result);
        }

        [HttpGet]
        [Route("{idLeccion}/preguntas/{idPregunta}/respuestas/{idRespuesta}")]
        public async Task<IActionResult> GetSpecificRespuestaAsync(int idRespuesta)
        {
            var result = await leccionService.GetSpecificRespuestaAsync(idRespuesta);
            return Ok(result);
        }

        [HttpPost]
        [Route("{idLeccion}/preguntas/{idPregunta}/respuestas")]
        public async Task<IActionResult> CreateRespuestaAsync(int idPregunta, [FromBody]RespuestaToCreateVM respuestaToCreateVM)
        {
            respuestaToCreateVM.IdPregunta = idPregunta;
            var result = await leccionService.CreateRespuestaAsync(respuestaToCreateVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{idLeccion}/preguntas/{idPregunta}/respuestas/{idRespuesta}")]
        public async Task<IActionResult> DeleteRespuestaAsync(int idRespuesta)
        {
            var result = await leccionService.DeleteRespuestaAsync(idRespuesta);
            return Ok(result);
        }
        #endregion

        #region Videos de Lecciones
        [HttpGet]
        [Route("{idLeccion}/lecciones-material/videos/{id}")]
        public async Task<IActionResult> GetSepecificCloudinaryFilesAsync(int idLeccion, int id)
        {
            var result = await leccionService.GetSpecificLeccionMaterialAsync(idLeccion, idLeccionMaterial: id);
            return Ok(result);
        }


#pragma warning disable S125 // Sections of code should not be commented out
        /*[HttpGet]
                [Route("{idLeccion}/lecciones-material/{idLeccionMaterial}/videos")]
                public async Task<IActionResult> GetCloudinaryFilesAsync(int idLeccionMaterial)
                {
                    var result = await cloudinaryFileService.GetCloudinaryFilesAsync(idLeccionMaterial: idLeccionMaterial);
                    return Ok(result);
                }*/

        [HttpPost]
#pragma warning restore S125 // Sections of code should not be commented out
        [Route("{idLeccion}/lecciones-material/videos")]
        public async Task<IActionResult> CreateCloudinaryFileAsync(int idLeccion, string titulo, [FromForm]LeccionMaterialVideoToCreateVM leccionMaterialVideoToCreateVM)
        {
            leccionMaterialVideoToCreateVM.IdLeccion = idLeccion;
            leccionMaterialVideoToCreateVM.Titulo = titulo;
            leccionMaterialVideoToCreateVM.IdTipoContenido = (int)TipoContenidoEnum.Video;
            var result = await leccionService.CreateLeccionVideoMaterialAsync(leccionMaterialVideoToCreateVM);
            return Ok(result);
        }


#pragma warning disable S125 // Sections of code should not be commented out
        /*[HttpPut]
                [Route("{idLeccion}/lecciones-material/{idLeccionMaterial}/videos/{id}")]
                public async Task<IActionResult> EditCloudinaryFileAsync(int idLeccionMaterial, int id, [FromForm]CloudinaryFileToUpdateVM cloudinaryFileToUpdateVM)
                {
                    cloudinaryFileToUpdateVM.IdLeccionMaterial = idLeccionMaterial;
                    cloudinaryFileToUpdateVM.Id = id;
                    var result = await cloudinaryFileService.EditCloudinaryFileAsync(cloudinaryFileToUpdateVM);
                    return Ok(result);
                }

                [HttpDelete]
                [Route("{idLeccion}/lecciones-material/{idLeccionMaterial}/videos/{id}")]
                public async Task<IActionResult> DeleteCloudinaryFileAsync(int idLeccionMaterial, int id)
                {
                    var result = await cloudinaryFileService.DeleteCloudinaryFileAsync(id, idLeccionMaterial: idLeccionMaterial);
                    return Ok(result);
                }*/
        #endregion
    }
#pragma warning restore S125 // Sections of code should not be commented out
}