using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EverestLMS.Services.NivelService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EverestLMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelController : ControllerBase
    {
        private readonly INivelService service;

        public NivelController(INivelService service)
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