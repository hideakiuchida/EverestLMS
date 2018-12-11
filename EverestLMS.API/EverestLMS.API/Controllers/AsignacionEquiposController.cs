using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EverestLMS.ViewModels.Participante.Sherpa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EverestLMS.Services.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Asignacion;
using EverestLMS.ViewModels.Participante;

namespace EverestLMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionEquiposController : ControllerBase
    {
        private readonly IParticipanteService service;

        public AsignacionEquiposController(IParticipanteService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Lista de escaldores no asignados de la misma carrera del sherpa y menor nivel del sherpa y creterio de busqueda.
        /// </summary>
        /// <param name="idLineaCarrera">The identifier.</param>
        /// <param name="search">if set to <c>true</c> [reset by email].</param>
        /// <returns></returns>
        [HttpGet]
        [Route("EscaladoresNoAsignados")]
        public async Task<IActionResult> GetEscaladoresNoAsignados(int idLineaCarrera, string search = null)
        {
            var result = await service.GetEscaladoresNoAsignadosAsync(idLineaCarrera, search);
            return Ok(result);
        }

        /// <summary>
        /// Asignacion del escalador al sherpa.
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("AsignacionManual")]
        public async Task<IActionResult> Asignar([FromBody] AsignacionToCreateVM asignacionToCreateVM)
        {
            var result = await service.AsignarAsync(asignacionToCreateVM);
            var message = new { message = result };
            return Ok(message);
        }

        [HttpPatch]
        [Route("DesasignacionManual")]
        public async Task<IActionResult> Desasignar([FromBody] AsignacionToCreateVM asignacionToCreateVM)
        {
            var result = await service.DesasignarAsync(asignacionToCreateVM);
            var message = new { message = result };
            return Ok(message);
        }

        /// <summary>
        /// Generar automaticamente las asignaciones.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AsignacionAutomatica")]
        public async Task<IActionResult> ProcesarAsignacionAutomatica()
        {
            var result = await service.ProcesarAsignacionAutomatica();
            var message = new { message = result };
            return Ok(message);
        }

        /// <summary>
        /// Obtener reporte automaticamente las asignaciones.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Reporte")]
        public async Task<string> ObtenerReporteAsignaciones()
        {
            return "Not implemented yet";
        }

    }
}