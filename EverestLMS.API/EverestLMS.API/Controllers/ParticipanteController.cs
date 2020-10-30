using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Asignacion;
using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Authorize]
    [Route("api/participantes")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteService service;
        private readonly IEtapaService etapaService;
        private readonly ICursoService cursoService;
        private readonly ILeccionService leccionService;

        public ParticipanteController(IParticipanteService service, IEtapaService etapaService, ICursoService cursoService, ILeccionService leccionService)
        {
            this.service = service;
            this.etapaService = etapaService;
            this.cursoService = cursoService;
            this.leccionService = leccionService;
        }

        [HttpGet]
        [Route("sherpas/{id}")]
        public async Task<IActionResult> GetSherpaDetailAsync(string id)
        {
            var result = await service.GetSherpaDetailAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("escaladores/{id}")]
        public async Task<IActionResult> GetEscaladorDetailAsync(string id)
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
        public async Task<IActionResult> GetEscaladoresPorSherpaIdAsync(string id)
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

        [HttpGet]
        [Route("{id}/etapas")]
        public async Task<IActionResult> GetEtapasAsync(string id)
        {
            var result = await etapaService.GetByParticipanteAsync(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("actualizar-puntaje")]
        public async Task<IActionResult> ActualizarPuntajeAsync([FromBody] EscaladorPuntajeToUpdateVM requestUpdateVM)
        {
            var result = await service.ActualizarPuntajeAsync(requestUpdateVM);
            return Ok(result);
        }

        #region Cursos
        [HttpGet]
        [Route("{id}/cursos")]
        public async Task<IActionResult> GetCursosByParticipanteAsync(string id, int? idEtapa, int? idIdioma)
        {
            var result = await cursoService.GetCursosByParticipanteAsync(id, idEtapa, idIdioma);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/cursos/predicciones")]
        public async Task<IActionResult> GetCursosPredictionByParticipanteAsync(string id, int? idEtapa, int? idIdioma)
        {
            var result = await cursoService.GetCursosPredictionByParticipanteAsync(id, idEtapa, idIdioma);
            return Ok(result);
        }
        #endregion

        #region Lecciones

        [HttpGet]
        [Route("{id}/etapas/{idEtapa}/cursos/{idCurso}/lecciones/{idLeccion}")]
        public async Task<IActionResult> GetLeccionByParticipanteAsync(string id, int idEtapa, int idCurso, int idLeccion)
        {
            var result = await leccionService.GetLeccionByParticipanteAsync(id, idEtapa, idCurso, idLeccion);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/etapas/{idEtapa}/cursos/{idCurso}/lecciones")]
        public async Task<IActionResult> GetLeccionesByParticipanteAsync(string id, int idEtapa, int idCurso)
        {
            var result = await cursoService.GetCursoDetalleByParticipanteAsync(id, idEtapa, idCurso);
            return Ok(result);
        }
        #endregion
    }
}