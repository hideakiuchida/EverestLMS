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
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("CreateRatingCurso", new { entity.Rating, entity.IdParticipante, entity.IdCurso },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<RatingCursoEntity>> GetAllAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "SELECT [IdRatingCurso],[Rating],[IdParticipante],[IdCurso] FROM [dbo].[RatingCurso]";
                var result = await conn.QueryAsync<RatingCursoEntity>(stringQuery);
                return result.ToList();
            }
        }

        public async Task<int> RemoveAllAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "DELETE FROM [dbo].[RatingCurso]";
                var result = await _dbConnection.QueryAsync<int>(stringQuery);
                return result.FirstOrDefault();
            }
        }
    }
}
