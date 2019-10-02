using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/participantes/{id}/cursos")]
    [ApiController]
    public class CursoParticipanteController : ControllerBase
    {
        private readonly ICursoService service;

        public CursoParticipanteController(ICursoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCursosByParticipanteAsync(int id, int? idEtapa, int? idIdioma)
        {
            var result = await service.GetCursosByParticipanteAsync(id, idEtapa, idIdioma);
            return Ok(result);
        }

        [HttpGet]
        [Route("predicciones")]
        public async Task<IActionResult> GetCursosPredictionByParticipanteAsync(int id, int? idEtapa, int? idIdioma)
        {
            var result = await service.GetCursosPredictionByParticipanteAsync(id, idEtapa, idIdioma);
            return Ok(result);
        }

    
    }
}