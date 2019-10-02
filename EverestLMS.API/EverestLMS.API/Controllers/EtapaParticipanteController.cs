using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/participantes/{id}/etapas")]
    [ApiController]
    public class EtapaParticipanteController : ControllerBase
    {
        private readonly IEtapaService service;

        public EtapaParticipanteController(IEtapaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEtapasAsync(int id)
        {
            var result = await service.GetByParticipanteAsync(id);
            return Ok(result);
        }

    }
}