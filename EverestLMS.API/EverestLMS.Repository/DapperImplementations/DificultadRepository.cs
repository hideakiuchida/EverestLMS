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
    public class DificultadRepository : BaseConnection, IDificultadRepository
    {
        private ILogger<DificultadRepository> logger;
        public DificultadRepository(IDbConnection dbConnection, ILogger<DificultadRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<DificultadEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdDificultad], [Descripcion] FROM [dbo].[Dificultad]";
                var result = await _dbConnection.QueryAsync<DificultadEntity>(stringQuery);
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
