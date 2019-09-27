﻿using AutoMapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Curso;
using EverestLMS.ViewModels.Participante;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class CursoService : ICursoService
    {
        private readonly IPredictionTrainerRepository predictionTrainerRepository;
        private readonly IParticipanteRepository participanteRepository;
        private readonly ICursoRepository repository;
        private readonly IMapper mapper;
        public CursoService(ICursoRepository repository, IPredictionTrainerRepository predictionTrainerRepository, IParticipanteRepository participanteRepository, IMapper mapper)
        {
            this.predictionTrainerRepository = predictionTrainerRepository;
            this.participanteRepository = participanteRepository;
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
            var participantesVM = mapper.Map<IEnumerable<ParticipanteVM>>(participantes);
            List<CursoPredictedByParticipantVM> cursoPredictedByParticipantVMs = new List<CursoPredictedByParticipantVM>();
            foreach (var item in participantesVM)
            {
                var cursos = await GetCursosPredictionByParticipantAsync(item.Id);
                var cursoPredictedByParticipantVM = new CursoPredictedByParticipantVM();
                cursoPredictedByParticipantVM.Id = item.Id;
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

        public async Task<IEnumerable<CursoDetalleVM>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            var cursosEntities = await repository.GetCursosAsync(idEtapa, idLineaCarrera, idNivel, search);
            var cursosVM = mapper.Map<IEnumerable<CursoDetalleVM>>(cursosEntities);
            return cursosVM;
        }

        public async Task<IEnumerable<CursoPredictionVM>> GetCursosPredictionByParticipantAsync(int id)
        {
            var cursosPredicted = await predictionTrainerRepository.GetCursosPredictionByParticipantAsync(id);
            var cursosPredictedVM = mapper.Map<IEnumerable<CursoPredictionVM>>(cursosPredicted);
            return cursosPredictedVM;
        }
    }
}
