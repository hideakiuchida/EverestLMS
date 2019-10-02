using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.TipoContenido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class TipoContenidoService : ITipoContenidoService
    {
        private readonly IMapper mapper;
        private readonly ITipoContenidoRepository repository;

        public TipoContenidoService(ITipoContenidoRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<IEnumerable<TipoContenidoVM>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var viewModels = mapper.Map<IEnumerable<TipoContenidoVM>>(entities);
            return viewModels;
        }
    }
}
