using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EverestLMS.Entities.POCO;
using EverestLMS.Repository;
using EverestLMS.ViewModels.LineaCarrera;

namespace EverestLMS.Services.LineaCarreraService
{
    public class LineaCarreraService : ILineaCarreraService
    {
        private readonly IEverestRepository<LineaCarrera> repository;
        private readonly IMapper mapper;

        public LineaCarreraService(IEverestRepository<LineaCarrera> repository, IMapper mapper)
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
