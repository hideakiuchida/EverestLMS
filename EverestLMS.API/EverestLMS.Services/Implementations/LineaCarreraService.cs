using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.LineaCarrera;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class LineaCarreraService : ILineaCarreraService
    {
        private readonly IMapper mapper;
        private readonly ILineaCarreraRepository repository;

        public LineaCarreraService(ILineaCarreraRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<LineaCarreraVM>> GetAllAsync()
        {
            var lineaCarreras = await repository.GetAllAsync();
            var lineaCarrerasVM = mapper.Map<IEnumerable<LineaCarreraVM>>(lineaCarreras);
            return lineaCarrerasVM;
        }
    }
}
