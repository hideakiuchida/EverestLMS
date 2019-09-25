using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/dificultades")]
    [ApiController]
    public class DificultadController : ControllerBase
    {
        private readonly IDificultadService service;

        public DificultadController(IDificultadService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }
    }
}