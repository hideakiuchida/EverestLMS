using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Sede;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class SedeService : ISedeService
    {
        private readonly IMapper mapper;
        private readonly ISedeRepository repository;

        public SedeService(ISedeRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<SedeVM>> GetAllAsync()
        {
            var sedes = await repository.GetAllAsync();
            var sedesVM = mapper.Map<IEnumerable<SedeVM>>(sedes);
            return sedesVM;
        }
    }
}
