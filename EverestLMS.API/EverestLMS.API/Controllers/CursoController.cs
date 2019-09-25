using EverestLMS.Services.Interfaces;
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

        public CursoController(ICursoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCursosAsync(int idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            var result = await service.GetCursosAsync(idEtapa, idLineaCarrera, idNivel, search);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCursoAsync(int idEtapa, CursoVM cursoVM)
        {
            cursoVM.IdEtapa = idEtapa;
            var result = await service.CreateCursoAsync(cursoVM);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditCursoAsync(int idEtapa, int id, CursoVM cursoVM)
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

    }
}