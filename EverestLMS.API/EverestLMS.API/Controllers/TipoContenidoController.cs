using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/tipos-contenido")]
    [ApiController]
    public class TipoContenidoController : ControllerBase
    {
        private readonly ITipoContenidoService service;

        public TipoContenidoController(ITipoContenidoService service)
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