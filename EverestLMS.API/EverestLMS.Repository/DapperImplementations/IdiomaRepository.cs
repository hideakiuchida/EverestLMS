using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class IdiomaRepository : BaseConnection, IIdiomaRepository
    {
        public IdiomaRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<IdiomaEntity>> GetAllAsync()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "SELECT [IdIdioma], [Descripcion] FROM [dbo].[Idioma]";
                var result = await _dbConnection.QueryAsync<IdiomaEntity>(stringQuery);
            return result.ToList();
        }
    }
}
