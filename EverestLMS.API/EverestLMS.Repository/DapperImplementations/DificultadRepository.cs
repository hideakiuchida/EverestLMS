using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class DificultadRepository : BaseConnection, IDificultadRepository
    {
        public DificultadRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<DificultadEntity>> GetAllAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdDificultad], [Descripcion] FROM [dbo].[Dificultad]";
                var result = await conn.QueryAsync<DificultadEntity>(stringQuery);
                return result.ToList();
            }
        }
    }
}
