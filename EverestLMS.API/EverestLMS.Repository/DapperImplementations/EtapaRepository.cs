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
    public class EtapaRepository : BaseConnection, IEtapaRepository
    {
        private readonly ILogger<EtapaRepository> logger;
        public EtapaRepository(IDbConnection dbConnection, ILogger<EtapaRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<EtapaEntity>> GetAllAsync(int? idNivel, int? idLineaCarrera, string search)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<EtapaEntity>("GetEtapas", new { IdNivel = idNivel, IdLineaCarrera = idLineaCarrera, Search = search },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }
    }
}
