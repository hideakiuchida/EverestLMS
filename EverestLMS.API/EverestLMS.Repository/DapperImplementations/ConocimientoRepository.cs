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
    public class ConocimientoRepository : BaseConnection, IConocimientoRepository
    {
        private readonly ILogger<ConocimientoRepository> logger;

        public ConocimientoRepository(IDbConnection dbConnection, ILogger<ConocimientoRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<int> CreateConocimientoParticipanteAsync(ConocimientoParticipanteEntity conocimientoParticipanteEntity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateConocimientoParticipante",
                    new
                    {
                        conocimientoParticipanteEntity.IdConocimiento,
                        conocimientoParticipanteEntity.IdParticipante
                    },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
            
        }

        public async Task<ConocimientoEntity> GetByIdAsync(int? id)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<ConocimientoEntity>("GetConocimientos", new { IdConocimiento = id },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            } 
        }

        public async Task<IEnumerable<ConocimientoEntity>> GetConocimientoByParticipanteIdAsync(int id)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<ConocimientoEntity>("GetConocimientosPorParticipante", new { IdParticipante = id },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
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
