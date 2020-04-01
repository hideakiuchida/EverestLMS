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
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            string stringQuery = "DELETE FROM [dbo].[PrediccionRatingCurso]";
            await _dbConnection.QueryAsync(stringQuery);
        }

        public async Task<int> CreatePredictionCourseForParticipantAsync(RatingCursoEntity ratingCursoEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreatePredictionCurso", new { ratingCursoEntity.Rating, ratingCursoEntity.IdParticipante, ratingCursoEntity.IdCurso },
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();  
        }
    }
}
