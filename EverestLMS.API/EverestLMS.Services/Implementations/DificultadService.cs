using AutoMapper;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class DificultadService : IDificultadService
    {
        private readonly IMapper mapper;
        private readonly IDificultadRepository repository;

        public DificultadService(IDificultadRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<IEnumerable<DificultadVM>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var viewModels = mapper.Map<IEnumerable<DificultadVM>>(entities);
            return viewModels;
        }
    }
}
