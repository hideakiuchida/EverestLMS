using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EverestLMS.Services.LineaCarreraService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EverestLMS.API.Controllers
{
    [Route("api/[controller]")]
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