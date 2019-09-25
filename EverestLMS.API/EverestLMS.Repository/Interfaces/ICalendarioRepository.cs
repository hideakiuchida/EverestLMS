using EverestLMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ICalendarioRepository
    {
        Task<IEnumerable<CalendarioEntity>> GetCalendariosAsync();
        Task<IEnumerable<EventoEntity>> GetEventosPorCalendarioAsync(int idCalendario);
        Task<int> CrearEventoAsync(EventoEntity evento);
        Task<bool> EliminarEventoAsync(int idCalendario, int idEvento);
        Task<IEnumerable<CriterioAceptacionEntity>> GetCriteriosAceptacionPorCalendarioAsync(int idCalendario);
        Task<int> CrearCriterioAceptacionAsync(CriterioAceptacionEntity criterioAceptacion);
        Task<bool> EliminarCriterioAceptacionAsync(int idCalendario, int idCriterioAceptacion);
    }
}
