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
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "SELECT [IdLineaCarrera],[Descripcion] FROM [dbo].[LineaCarrera]";
            var result = await _dbConnection.QueryAsync<LineaCarreraEntity>(stringQuery);
            return result.ToList();
        }
    }
}
