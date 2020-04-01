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
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "SELECT [IdNivel], [Descripcion] FROM [dbo].[Nivel]";
            var result = await _dbConnection.QueryAsync<NivelEntity>(stringQuery);
            return result.ToList();
        }
    }
}
