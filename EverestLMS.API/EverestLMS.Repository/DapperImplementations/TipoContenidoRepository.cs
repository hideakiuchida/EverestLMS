using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class TipoContenidoRepository : BaseConnection, ITipoContenidoRepository
    {
        private readonly ILogger<TipoContenidoRepository> logger;

        public TipoContenidoRepository(IDbConnection dbConnection, ILogger<TipoContenidoRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<TipoContenidoEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdTipoContenido], [Descripcion] FROM [dbo].[TipoContenido]";
                var result = await _dbConnection.QueryAsync<TipoContenidoEntity>(stringQuery);
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
