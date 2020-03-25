using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Calendario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/calendarios")]
    [ApiController]
    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioService service;
        public CalendarioController(ICalendarioService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("{id}/eventos")]
        public async Task<IActionResult> CrearEventoAsync(int id, [FromBody] EventoVM eventoVM)
        {
            eventoVM.IdCalendario = id;
            var result = await service.CrearEventoAsync(eventoVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}/eventos/{idEvento}")]
        public async Task<IActionResult> EliminarEventoAsync(int id, int idEvento)
        {
            var result = await service.EliminarEventoAsync(id, idEvento);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/eventos")]
        public async Task<IActionResult> GetEventosPorCalendarioAsync(int id)
        {
            var result = await service.GetEventosPorCalendarioAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("{id}/criterios-aceptacion")]
        public async Task<IActionResult> CrearCriterioAceptacionAsync(int id, [FromBody] CriterioAceptacionVM criterioAceptacionVM)
        {
            criterioAceptacionVM.IdCalendario = id;
            var result = await service.CrearCriterioAceptacionAsync(criterioAceptacionVM);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}/criterios-aceptacion/{idCriterioAceptacion}")]
        public async Task<IActionResult> EliminarCriterioAceptacionAsync(int id, int idCriterioAceptacion)
        {
            var result = await service.EliminarCriterioAceptacionAsync(id, idCriterioAceptacion);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/criterios-aceptacion")]
        public async Task<IActionResult> GetCriteriosAceptacionPorCalendarioAsync(int id)
        {
            var result = await service.GetCriteriosAceptacionPorCalendarioAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCalendariosAsync()
        {
            var result = await service.GetCalendariosAsync();
            return Ok(result);
        }
    }
}