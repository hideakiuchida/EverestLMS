using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/etapas")]
    [ApiController]
    public class EtapaController : ControllerBase
    {
        private readonly IEtapaService service;

        public EtapaController(IEtapaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEtapasAsync(int? idLineaCarrera, int? idNivel, string search)
        {
            var result = await service.GetAllAsync(idNivel, idLineaCarrera, search);
            return Ok(result);
        }

    }
}