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
    public class LineaCarreraRepository : BaseConnection, ILineaCarreraRepository
    {
        private readonly ILogger<LineaCarreraRepository> logger;

        public LineaCarreraRepository(IDbConnection dbConnection, ILogger<LineaCarreraRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<LineaCarreraEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdLineaCarrera],[Descripcion] FROM [dbo].[LineaCarrera]";
                var result = await _dbConnection.QueryAsync<LineaCarreraEntity>(stringQuery);
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
