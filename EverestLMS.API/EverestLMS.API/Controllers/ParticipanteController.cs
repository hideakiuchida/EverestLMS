﻿using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Asignacion;
using EverestLMS.ViewModels.Participante;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/participantes")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteService service;

        public ParticipanteController(IParticipanteService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("sherpas/{id}")]
        public async Task<IActionResult> GetSherpaDetailAsync(int id)
        {
            var result = await service.GetSherpaDetailAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("escaladores/{id}")]
        public async Task<IActionResult> GetEscaladorDetailAsync(int id)
        {
            var result = await service.GetEscaladorDetailAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("sherpas")]
        public async Task<IActionResult> GetSherpasAsync(int? idNivel, int? idLineaCarrera, int? idSede, string search)
        {
            var result = await service.GetSherpasAsync(idNivel, idLineaCarrera, idSede, search);
            return Ok(result);
        }

        [HttpGet]
        [Route("sherpas/{id}/escaladores")]
        public async Task<IActionResult> GetEscaladoresPorSherpaIdAsync(int id)
        {
            var result = await service.GetEscaladoresPorSherpaIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipanteToCreateVM participanteToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var participanteFromRepo = await service.CreateAsync(participanteToCreate);
            return Created("GetEscaladorDetailAsync", participanteFromRepo);
        }

        [HttpGet]
        [Route("escaladores-no-asignados")]
        public async Task<IActionResult> GetEscaladoresNoAsignados(int idLineaCarrera, string search = null)
        {
            var result = await service.GetEscaladoresNoAsignadosAsync(idLineaCarrera, default(int?), search);
            return Ok(result);
        }

        [HttpPatch]
        [Route("asignacion-manual")]
        public async Task<IActionResult> Asignar([FromBody] AsignacionToCreateVM asignacionToCreateVM)
        {
            var result = await service.AsignarAsync(asignacionToCreateVM);
            var message = new { message = result };
            return Ok(message);
        }

        [HttpPatch]
        [Route("desasignacion-manual")]
        public async Task<IActionResult> Desasignar([FromBody] AsignacionToCreateVM asignacionToCreateVM)
        {
            var result = await service.DesasignarAsync(asignacionToCreateVM);
            var message = new { message = result };
            return Ok(message);
        }

        [HttpPost]
        [Route("asignacion-automatica")]
        public async Task<IActionResult> AsignacionAutomatica()
        {
            var result = await service.ProcesarAsignacionAutomatica();
            var message = new { message = result };
            return Ok(message);
        }

        [HttpPost]
        [Route("desasignacion-automatica")]
        public async Task<IActionResult> DesasignacionAutomatica()
        {
            var result = await service.ProcesarDesasignacionAutomatica();
            var message = new { message = result };
            return Ok(message);
        }
    }
}