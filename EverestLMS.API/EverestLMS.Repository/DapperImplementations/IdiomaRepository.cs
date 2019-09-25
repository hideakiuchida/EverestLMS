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
    public class IdiomaRepository : BaseConnection, IIdiomaRepository
    {
        private ILogger<IdiomaRepository> logger;
        public IdiomaRepository(IDbConnection dbConnection, ILogger<IdiomaRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<IdiomaEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdIdioma], [Descripcion] FROM [dbo].[Idioma]";
                var result = await _dbConnection.QueryAsync<IdiomaEntity>(stringQuery);
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
