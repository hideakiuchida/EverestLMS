using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EverestLMS.Entities.POCO;
using EverestLMS.Repository;
using EverestLMS.ViewModels.Nivel;

namespace EverestLMS.Services.NivelService
{
    public class NivelService : INivelService
    {
        private readonly IEverestRepository<Nivel> repository;
        private readonly IMapper mapper;

        public NivelService(IEverestRepository<Nivel> repository, IMapper mapper)
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
