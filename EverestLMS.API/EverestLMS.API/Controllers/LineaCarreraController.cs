using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/linea-carreras")]
    [ApiController]
    public class LineaCarreraController : ControllerBase
    {
        private readonly ILineaCarreraService service;

        public LineaCarreraController(ILineaCarreraService service)
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