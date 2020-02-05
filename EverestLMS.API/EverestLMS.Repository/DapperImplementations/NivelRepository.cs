using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace EverestLMS.Repository.DapperImplementations
{
    public class NivelRepository : BaseConnection, INivelRepository
    {
        private readonly ILogger<NivelRepository> logger;

        public NivelRepository(IDbConnection dbConnection, ILogger<NivelRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<NivelEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdNivel], [Descripcion] FROM [dbo].[Nivel]";
                var result = await _dbConnection.QueryAsync<NivelEntity>(stringQuery);
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
