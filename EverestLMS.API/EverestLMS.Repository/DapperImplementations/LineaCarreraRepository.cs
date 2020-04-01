using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class LineaCarreraRepository : BaseConnection, ILineaCarreraRepository
    {
        public LineaCarreraRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<LineaCarreraEntity>> GetAllAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdLineaCarrera],[Descripcion] FROM [dbo].[LineaCarrera]";
                var result = await conn.QueryAsync<LineaCarreraEntity>(stringQuery);
                return result.ToList();
            }
        }
    }
}
