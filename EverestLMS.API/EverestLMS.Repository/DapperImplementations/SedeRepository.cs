using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class SedeRepository : BaseConnection, ISedeRepository
    {
        public SedeRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<SedeEntity>> GetAllAsync()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "SELECT [IdSede],[Descripcion] FROM [dbo].[Sede]";
            var result = await _dbConnection.QueryAsync<SedeEntity>(stringQuery);
            return result.ToList();
        }
    }
}
