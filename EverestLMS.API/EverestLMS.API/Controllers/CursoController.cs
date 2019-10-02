using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.CloudinaryFile;
using EverestLMS.ViewModels.Curso;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/etapas/{idEtapa}/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService service;
        private readonly ICloudinaryFileService cloudinaryFileService;

        public CursoController(ICursoService service, ICloudinaryFileService cloudinaryFileService)
        {
            this.service = service;
            this.cloudinaryFileService = cloudinaryFileService;
        }

        #region Cursos
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCursosAsync(int idEtapa, int id)
        {
            var result = await service.GetCursoAsync(idEtapa, id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCursosAsync(int idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            var result = await service.GetCursosAsync(idEtapa, idLineaCarrera, idNivel, search);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCursoAsync(int idEtapa, CursoToCreateVM cursoVM)
        {
            cursoVM.IdEtapa = idEtapa;
            var result = await service.CreateCursoAsync(cursoVM);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditCursoAsync(int idEtapa, int id, CursoToUpdateVM cursoVM)
        {
            cursoVM.IdEtapa = idEtapa;
            cursoVM.Id = id;
            var result = await service.EditCursoASync(cursoVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCursoAsync(int idEtapa, int id)
        {
            var result = await service.DeleteCursoAsync(idEtapa, id);
            return Ok(result);
        }
        #endregion

        #region Imagenes de Cursos
        [HttpGet]
        [Route("{id}/imagenes/{idImagen}")]
        public async Task<IActionResult> GetSepecificCloudinaryFilesAsync(int id, int idImagen)
        {
            var result = await cloudinaryFileService.GetSpecificCloudinaryFilesAsync(idImagen, id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/imagenes")]
        public async Task<IActionResult> GetCloudinaryFilesAsync(int id)
        {
            var result = await cloudinaryFileService.GetCloudinaryFilesAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("{id}/imagenes")]
        public async Task<IActionResult> CreateCloudinaryFileAsync(int id, [FromForm]CloudinaryFileToCreateVM cloudinaryFileToCreateVM)
        {
            cloudinaryFileToCreateVM.IdCurso = id;
            var result = await cloudinaryFileService.CreateCloudinaryFileAsync(cloudinaryFileToCreateVM);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}/imagenes/{idImagen}")]
        public async Task<IActionResult> EditCloudinaryFileAsync(int id, int idImagen, [FromForm]CloudinaryFileToUpdateVM cloudinaryFileToUpdateVM)
        {
            cloudinaryFileToUpdateVM.IdCurso = id;
            cloudinaryFileToUpdateVM.Id = idImagen;
            var result = await cloudinaryFileService.EditCloudinaryFileAsync(cloudinaryFileToUpdateVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}/imagenes/{idImagen}")]
        public async Task<IActionResult> DeleteCloudinaryFileAsync(int id, int idImagen)
        {
            var result = await cloudinaryFileService.DeleteCloudinaryFileAsync(idImagen, id);
            return Ok(result);
        }
        #endregion
    }
}