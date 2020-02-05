using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class CalendarioRepository : BaseConnection, ICalendarioRepository
    {
        private readonly ILogger<CalendarioRepository> logger;

        public CalendarioRepository(IDbConnection dbConnection, ILogger<CalendarioRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<int> CrearCriterioAceptacionAsync(CriterioAceptacionEntity criterioAceptacion)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateCriterioAceptacion",
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<int> CrearEventoAsync(EventoEntity evento)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateEvento",
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<bool> EliminarCriterioAceptacionAsync(int idCalendario, int idCriterioAceptacion)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("DeleteCriterioAceptacion", new { IdCalendario = idCalendario, IdCriterioAceptacion = idCriterioAceptacion }, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<bool> EliminarEventoAsync(int idCalendario, int idEvento)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("DeleteEvento", new { IdCalendario = idCalendario, IdEvento = idEvento}, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<CalendarioEntity>> GetCalendariosAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdCalendario],[Descripcion],[FechaInicio],[FechaFinal],[Activo],[Temporada] FROM [dbo].[Calendario]";
                var result = await _dbConnection.QueryAsync<CalendarioEntity>(stringQuery);
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<CriterioAceptacionEntity>> GetCriteriosAceptacionPorCalendarioAsync(int idCalendario)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdCriterioAceptacion],[Descripcion],[Medida],[Valor],[IdCalendario] FROM [dbo].[CriterioAceptacion] WHERE [IdCalendario] = @IdCalendario";
                var result = await _dbConnection.QueryAsync<CriterioAceptacionEntity>(stringQuery, new { IdCalendario = idCalendario });
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<EventoEntity>> GetEventosPorCalendarioAsync(int idCalendario)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdEvento],[Titulo],[Descripcion],[FechaInicio],[FechaFinal],[ColorPrimario],[ColorSecundario],[IdCalendario] FROM [dbo].[Evento] WHERE [IdCalendario] = @IdCalendario";
                var result = await _dbConnection.QueryAsync<EventoEntity>(stringQuery, new { IdCalendario = idCalendario});
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }
    }
}
