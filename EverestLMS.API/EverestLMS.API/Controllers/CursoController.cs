using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService service;

        public CursoController(ICursoService service)
        {
            this.service = service;
        }
        /*[HttpGet]
        [Route("predicciones")]
        public async Task<IActionResult> GetAllCursosPredictionByParticipantAsync()
        {
            var result = await service.GetAllCursosPredictionByParticipantAsync();
            return Ok(result);
        }*/
        [HttpGet]
        [Route("predicciones")]
        public async Task<IActionResult> GetCursosPredictionByParticipantAsync(int idParticipante)
        {
            var result = await service.GetCursosPredictionByParticipantAsync(idParticipante);
            return Ok(result);
        }
    }
}