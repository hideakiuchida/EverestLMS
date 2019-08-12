using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Curso;
using EverestLMS.ViewModels.Participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class CursoService : ICursoService
    {
        private readonly IPredictionTrainerRepository predictionTrainerRepository;
        private readonly IParticipanteRepository participanteRepository;
        private readonly IMapper mapper;
        public CursoService(IPredictionTrainerRepository predictionTrainerRepository, IParticipanteRepository participanteRepository, IMapper mapper)
        {
            this.predictionTrainerRepository = predictionTrainerRepository;
            this.participanteRepository = participanteRepository;
            this.mapper = mapper;
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

        public async Task<IEnumerable<CursoPredictionVM>> GetCursosPredictionByParticipantAsync(int id)
        {
            var cursosPredicted = await predictionTrainerRepository.GetCursosPredictionByParticipantAsync(id);
            var cursosPredictedVM = mapper.Map<IEnumerable<CursoPredictionVM>>(cursosPredicted);
            return cursosPredictedVM;
        }
    }
}
