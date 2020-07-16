using AutoMapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Curso;
using EverestLMS.ViewModels.Leccion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class CursoService : ICursoService
    {
        private readonly IParticipanteRepository participanteRepository;
        private readonly ICursoRepository repository;
        private readonly ILeccionRepository leccionRepository;
        private readonly IMapper mapper;

        public CursoService(ICursoRepository repository, IParticipanteRepository participanteRepository, ILeccionRepository leccionRepository, IMapper mapper)
        {
            this.participanteRepository = participanteRepository;
            this.leccionRepository = leccionRepository;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateCursoAsync(CursoToCreateVM cursoVM)
        {
            var cursoEntity = mapper.Map<CursoEntity>(cursoVM);
            var idCurso = await repository.CreateCursoAsync(cursoEntity);
            return idCurso;
        }

        public async Task<bool> DeleteCursoAsync(int idEtapa, int idCurso)
        {
            return await repository.DeleteCursoAsync(idEtapa, idCurso);
        }

        public async Task<bool> EditCursoASync(CursoToUpdateVM cursoVM)
        {
            var cursoEntity = mapper.Map<CursoEntity>(cursoVM);
            var updated = await repository.EditCursoASync(cursoEntity);
            return updated;
        }

        public async Task<IEnumerable<CursoPredictedByParticipantVM>> GetAllCursosPredictionByParticipantAsync()
        {
            var allItemsInteger = (int)decimal.Zero;
            var participantes = await participanteRepository.GetParticipantesAsync(allItemsInteger, allItemsInteger);
            List<CursoPredictedByParticipantVM> cursoPredictedByParticipantVMs = new List<CursoPredictedByParticipantVM>();
            foreach (var item in participantes)
            {
                var cursos = await GetCursosPredictionByParticipanteAsync(item.UsuarioKey);
                var cursoPredictedByParticipantVM = new CursoPredictedByParticipantVM();
                cursoPredictedByParticipantVM.Id = item.UsuarioKey;
                cursoPredictedByParticipantVM.Nombre = item.Nombre;
                cursoPredictedByParticipantVM.Apellido = item.Apellido;
                cursoPredictedByParticipantVM.Cursos = cursos?.ToList();
                cursoPredictedByParticipantVMs.Add(cursoPredictedByParticipantVM);
            }
            return cursoPredictedByParticipantVMs;
        }

        public async Task<CursoToUpdateVM> GetCursoAsync(int idEtapa, int idCurso)
        {
            var cursoEntity = await repository.GetCursoAsync(idEtapa, idCurso);
            var cursoVM = mapper.Map<CursoToUpdateVM>(cursoEntity);
            return cursoVM;
        }

        public async Task<CursoDetalleVM> GetCursoDetalleByParticipanteAsync(string idParticipante, int idEtapa, int idCurso)
        {
            var cursoEntity = await repository.GetCursoAsync(idEtapa, idCurso);
            var leccionesEntities = await leccionRepository.GetLeccionesDetalleAsync(default, default, idEtapa, idCurso, default);
            var cursoDetalleVM = mapper.Map<CursoDetalleVM>(cursoEntity as CursoEntity);
            var leccionesVM = mapper.Map<IEnumerable<LeccionDetalleVM>>(leccionesEntities);
            cursoDetalleVM.Lecciones = leccionesVM;
            return cursoDetalleVM;
        }

        public async Task<IEnumerable<CursoDetalleVM>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            var cursosEntities = await repository.GetCursosAsync(idEtapa, idLineaCarrera, idNivel, search);
            var cursosVM = mapper.Map<IEnumerable<CursoDetalleVM>>(cursosEntities);
            return cursosVM;
        }

        public async Task<IEnumerable<CursoVM>> GetCursosByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null)
        {
            var cursos = await repository.GetCursosByParticipanteAsync(idParticipante, idEtapa, idIdioma);
            var cursosVM = mapper.Map<IEnumerable<CursoVM>>(cursos);
            return cursosVM;
        }

        public async Task<IEnumerable<CursoPredictionVM>> GetCursosPredictionByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null)
        {
            var cursosPredicted = await repository.GetCursosPredictionByParticipanteAsync(idParticipante, idEtapa, idIdioma);
            var cursosPredictedVM = mapper.Map<IEnumerable<CursoPredictionVM>>(cursosPredicted);
            return cursosPredictedVM;
        }
    }
}
