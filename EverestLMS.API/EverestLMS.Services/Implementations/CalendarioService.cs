using AutoMapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Calendario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class CalendarioService : ICalendarioService
    {
        private readonly ICalendarioRepository repository;
        private readonly IMapper mapper;
        public CalendarioService(ICalendarioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CrearCriterioAceptacionAsync(CriterioAceptacionVM criterioAceptacion)
        {
            var criterioAceptacionEntity = mapper.Map<CriterioAceptacionEntity>(criterioAceptacion);
            var id = await repository.CrearCriterioAceptacionAsync(criterioAceptacionEntity);
            return id;
        }

        public async Task<int> CrearEventoAsync(EventoVM evento)
        {
            var eventoToRepo = mapper.Map<EventoEntity>(evento);
            var idEvento = await repository.CrearEventoAsync(eventoToRepo);
            return idEvento;
        }

        public async Task<bool> EliminarCriterioAceptacionAsync(int idCalendario, int idCriterioAceptacion)
        {
            var deleted = await repository.EliminarCriterioAceptacionAsync(idCalendario, idCriterioAceptacion);
            return deleted;
        }

        public async Task<bool> EliminarEventoAsync(int idCalendario, int idEvento)
        {
            var deleted = await repository.EliminarEventoAsync(idCalendario, idEvento);
            return deleted;
        }

        public async Task<IEnumerable<CalendarioVM>> GetCalendariosAsync()
        {
            var calendarios = await repository.GetCalendariosAsync();
            var calendariosToReturn = mapper.Map<IEnumerable<CalendarioVM>>(calendarios);
            return calendariosToReturn;
        }

        public async Task<IEnumerable<CriterioAceptacionVM>> GetCriteriosAceptacionPorCalendarioAsync(int idCalendario)
        {
            var entities = await repository.GetCriteriosAceptacionPorCalendarioAsync(idCalendario);
            var entitiesViewModel = mapper.Map<IEnumerable<CriterioAceptacionVM>>(entities);
            return entitiesViewModel;
        }

        public async Task<IEnumerable<EventoVM>> GetEventosPorCalendarioAsync(int idCalendario)
        {
            var eventos = await repository.GetEventosPorCalendarioAsync(idCalendario);
            var eventosToReturn = mapper.Map<IEnumerable<EventoVM>>(eventos);
            return eventosToReturn;
        }
    }
}
