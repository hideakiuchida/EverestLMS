using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Etapa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class EtapaService : IEtapaService
    {
        private readonly IEtapaRepository repository;
        private readonly IMapper mapper;
        public EtapaService(IEtapaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<EtapaVM>> GetAllAsync(int? idNivel, int? idLineaCarrera, string search)
        {
            var etapas = await repository.GetAllAsync(idNivel, idLineaCarrera, search);
            var etapasViewModel = mapper.Map<IEnumerable<EtapaVM>>(etapas);
            return etapasViewModel;
        }

        public async Task<IEnumerable<EtapaVM>> GetByParticipanteAsync(string idParticipante)
        {
            var etapas = await repository.GetByParticipanteAsync(idParticipante);
            var etapasViewModel = mapper.Map<IEnumerable<EtapaVM>>(etapas);
            return etapasViewModel;
        }
    }
}
