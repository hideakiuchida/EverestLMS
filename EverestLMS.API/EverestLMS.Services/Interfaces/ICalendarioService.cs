using EverestLMS.ViewModels.Calendario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ICalendarioService
    {
        Task<IEnumerable<CalendarioVM>> GetCalendariosAsync();
        Task<IEnumerable<EventoVM>> GetEventosPorCalendarioAsync(int idCalendario);
        Task<int> CrearEventoAsync(EventoVM evento);
        Task<bool> EliminarEventoAsync(int idCalendario, int idEvento);
        Task<IEnumerable<CriterioAceptacionVM>> GetCriteriosAceptacionPorCalendarioAsync(int idCalendario);
        Task<int> CrearCriterioAceptacionAsync(CriterioAceptacionVM criterioAceptacion);
        Task<bool> EliminarCriterioAceptacionAsync(int idCalendario, int idCriterioAceptacion);
    }
}
