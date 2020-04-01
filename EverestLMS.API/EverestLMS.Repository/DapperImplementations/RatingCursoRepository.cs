using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class RatingCursoRepository : BaseConnection, IRatingCursoRepository
    {
        public RatingCursoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public async Task<int> CreateAsync(RatingCursoEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateRatingCurso", new { entity.Rating, entity.IdParticipante, entity.IdCurso },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<RatingCursoEntity>> GetAllAsync()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "SELECT [IdRatingCurso],[Rating],[IdParticipante],[IdCurso] FROM [dbo].[RatingCurso]";
            var result = await _dbConnection.QueryAsync<RatingCursoEntity>(stringQuery);
            return result.ToList();
        }

        public async Task<int> RemoveAllAsync()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "DELETE FROM [dbo].[RatingCurso]";
            var result = await _dbConnection.QueryAsync<int>(stringQuery);
            return result.FirstOrDefault();
        }
    }
}
