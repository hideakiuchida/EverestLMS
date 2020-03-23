using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService service;
        public AuthController(IAuthenticationService service)
        {
            this.service = service;
        }

        /*[HttpGet]
        [Route("{id}/eventos")]
        public async Task<IActionResult> GetEventosPorCalendarioAsync(int id)
        {
            var result = await service.GetEventosPorCalendarioAsync(id);
            return Ok(result);
        }*/

    }
}