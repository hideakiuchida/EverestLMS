using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Examen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/examenes")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly IExamenService service;
        public ExamenController(IExamenService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("curso")]
        public async Task<IActionResult> GenerarExamenPorCursoAsync([FromBody] ExamenToGenarateVM examenToGenarateVM)
        {
            var result = await service.GenerarExamenAsync(examenToGenarateVM.UsuarioKey, examenToGenarateVM.IdCurso);
            return Ok(result);
        }

        [HttpPost]
        [Route("leccion")]
        public async Task<IActionResult> GenerarExamenPorLeccionAsync([FromBody] ExamenToGenerateForLessonVM examenToGenarateVM)
        {
            var result = await service.GenerarExamenAsync(examenToGenarateVM.UsuarioKey, 
                examenToGenarateVM.IdCurso, examenToGenarateVM.IdLeccion.Value);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}/escalador-respuestas/{idRespuestaEscalador}")]
        public async Task<IActionResult> UpdateRespuestaAsync(int id, int idRespuestaEscalador, [FromBody] RespuestaExamenToUpdateVM updateVM)
        {
            var result = await service.UpdateRespuestaAsync(id, idRespuestaEscalador, updateVM);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateExamenAsync(int id, [FromBody] ExamenToUpdateVM updateVM)
        {
            var result = await service.UpdateExamenAsync(id, updateVM);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetExamenPorIdAsync(int id)
        {
            var result = await service.GetExamenPorIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/pregunta")]
        public async Task<IActionResult> GetPreguntaDelExamenAsync(int id)
        {
            var result = await service.GetPreguntaDelExamenAsync(id);
            return Ok(result);
        }
    }
}
