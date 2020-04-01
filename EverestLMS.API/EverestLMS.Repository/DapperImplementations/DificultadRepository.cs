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
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "SELECT [IdDificultad], [Descripcion] FROM [dbo].[Dificultad]";
                var result = await _dbConnection.QueryAsync<DificultadEntity>(stringQuery);
            return result.ToList();
        }
    }
}
