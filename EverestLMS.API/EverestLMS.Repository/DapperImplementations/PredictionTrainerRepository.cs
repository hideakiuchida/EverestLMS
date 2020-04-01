using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class PredictionTrainerRepository : BaseConnection, IPredictionTrainerRepository
    {
        public PredictionTrainerRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task ClearPredictionsAsync()
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                string stringQuery = "DELETE FROM [dbo].[PrediccionRatingCurso]";
                await conn.QueryAsync(stringQuery);
            }
        }

        public async Task<int> CreatePredictionCourseForParticipantAsync(RatingCursoEntity ratingCursoEntity)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("CreatePredictionCurso", new { ratingCursoEntity.Rating, ratingCursoEntity.IdParticipante, ratingCursoEntity.IdCurso },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
    }
}
