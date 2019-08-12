using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Nivel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class NivelService : INivelService
    {
        private readonly IMapper mapper;
        private readonly INivelRepository repository;

        public NivelService(INivelRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<NivelVM>> GetAllAsync()
        {
            var niveles = await repository.GetAllAsync();
            var nivelesVM = mapper.Map<IEnumerable<NivelVM>>(niveles);
            return nivelesVM;
        }
    }
}
