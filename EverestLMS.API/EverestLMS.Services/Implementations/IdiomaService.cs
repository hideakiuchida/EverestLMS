using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class IdiomaService : IIdiomaService
    {
        private readonly IMapper mapper;
        private readonly IIdiomaRepository repository;

        public IdiomaService(IIdiomaRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<IEnumerable<IdiomaVM>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var viewModels = mapper.Map<IEnumerable<IdiomaVM>>(entities);
            return viewModels;
        }
    }
}
