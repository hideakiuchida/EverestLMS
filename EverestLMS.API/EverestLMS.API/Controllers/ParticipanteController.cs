using EverestLMS.Services.Participante;
using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteService service;

        public ParticipanteController(IParticipanteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("SherpasLite")]
        public async Task<IActionResult> GetSherpas(int? idNivel = null, int? idLineaCarrera = null, string search = null)
        {
            var result = await service.GetSherpasAsync(idNivel, idLineaCarrera, search);
            return Ok(result);
        }

        [HttpGet]
        [Route("Sherpa/{id}")]
        public async Task<IActionResult> GetSherpaDetail(int id)
        {
            var result = await service.GetSherpaDetailAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("Escalador/{id}")]
        public async Task<IActionResult> GetEscaladorDetail(int id)
        {
            var result = await service.GetEscaladorDetailAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("Sherpa/Escaladores/{id}")]
        public async Task<IActionResult> GetEscaladoresPorSherpaId(int id)
        {
            var result = await service.GetEscaladoresPorSherpaIdAsync(id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipanteToCreateVM participanteToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var participanteFromRepo = await this.service.CreateAsync(participanteToCreate);
            return Created("Get", participanteFromRepo);
            //return CreatedAtRoute("GetUser", new { Controller = "Users", id = createdUser.ID }, userToReturn);
        }
    }
}