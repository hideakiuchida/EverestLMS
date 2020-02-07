using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System;
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
            _dbConnection.Close();
        }

        public async Task<int> CreatePredictionCourseForParticipantAsync(RatingCursoEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreatePredictionCurso", new { entity.Rating, entity.IdParticipante, entity.IdCurso },
                commandType: CommandType.StoredProcedure);
            _dbConnection.Close();
            return result.FirstOrDefault();  
        }
    }
}
