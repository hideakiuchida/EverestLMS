using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class NivelRepository : BaseConnection, INivelRepository
    {
        public NivelRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<NivelEntity>> GetAllAsync()
    {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdNivel], [Descripcion] FROM [dbo].[Nivel]";
                var result = await conn.QueryAsync<NivelEntity>(stringQuery);
                return result.ToList();
            }
        }
    }
}
