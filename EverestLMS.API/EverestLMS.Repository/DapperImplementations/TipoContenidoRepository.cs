using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class TipoContenidoRepository : BaseConnection, ITipoContenidoRepository
    {
        public TipoContenidoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<TipoContenidoEntity>> GetAllAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdTipoContenido], [Descripcion] FROM [dbo].[TipoContenido]";
                var result = await conn.QueryAsync<TipoContenidoEntity>(stringQuery);
                return result.ToList();
            }
        }
    }
}
