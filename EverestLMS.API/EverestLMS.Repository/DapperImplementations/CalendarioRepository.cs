using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class CalendarioRepository : BaseConnection, ICalendarioRepository
    {
        public CalendarioRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<int> CrearCriterioAceptacionAsync(CriterioAceptacionEntity criterioAceptacion)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("CreateCriterioAceptacion",
                    new
                    {
                        criterioAceptacion.Descripcion,
                        criterioAceptacion.Medida,
                        criterioAceptacion.Valor,
                        criterioAceptacion.IdCalendario
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
               
        }

        public async Task<int> CrearEventoAsync(EventoEntity evento)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("CreateEvento",
                new
                {
                    evento.Titulo,
                    evento.Descripcion,
                    evento.FechaInicio,
                    evento.FechaFinal,
                    evento.ColorPrimario,
                    evento.ColorSecundario,
                    evento.IdCalendario
                },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> EliminarCriterioAceptacionAsync(int idCalendario, int idCriterioAceptacion)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("DeleteCriterioAceptacion", new { IdCalendario = idCalendario, IdCriterioAceptacion = idCriterioAceptacion },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > 0;
            }
        }

        public async Task<bool> EliminarEventoAsync(int idCalendario, int idEvento)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("DeleteEvento", new { IdCalendario = idCalendario, IdEvento = idEvento }, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > 0;
            }
        }

        public async Task<IEnumerable<CalendarioEntity>> GetCalendariosAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdCalendario],[Descripcion],[FechaInicio],[FechaFinal],[Activo],[Temporada] FROM [dbo].[Calendario]";
                var result = await conn.QueryAsync<CalendarioEntity>(stringQuery);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<CriterioAceptacionEntity>> GetCriteriosAceptacionPorCalendarioAsync(int idCalendario)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdCriterioAceptacion],[Descripcion],[Medida],[Valor],[IdCalendario] FROM [dbo].[CriterioAceptacion] WHERE [IdCalendario] = @IdCalendario";
                var result = await conn.QueryAsync<CriterioAceptacionEntity>(stringQuery, new { IdCalendario = idCalendario });
                return result.ToList();
            }
        }

        public async Task<IEnumerable<EventoEntity>> GetEventosPorCalendarioAsync(int idCalendario)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var stringQuery = "SELECT [IdEvento],[Titulo],[Descripcion],[FechaInicio],[FechaFinal],[ColorPrimario],[ColorSecundario],[IdCalendario] FROM [dbo].[Evento] WHERE [IdCalendario] = @IdCalendario";
                var result = await conn.QueryAsync<EventoEntity>(stringQuery, new { IdCalendario = idCalendario });
                return result.ToList();
            }
        }
    }
}
