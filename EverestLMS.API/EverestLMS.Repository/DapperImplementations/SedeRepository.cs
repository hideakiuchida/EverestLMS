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
    public class SedeRepository : BaseConnection, ISedeRepository
    {
        private readonly ILogger<SedeRepository> logger;

        public SedeRepository(IDbConnection dbConnection, ILogger<SedeRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<SedeEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdSede],[Descripcion] FROM [dbo].[Sede]";
                var result = await _dbConnection.QueryAsync<SedeEntity>(stringQuery);
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
