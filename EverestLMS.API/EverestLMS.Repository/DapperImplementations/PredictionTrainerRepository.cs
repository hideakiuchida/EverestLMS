using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class PredictionTrainerRepository : BaseConnection, IPredictionTrainerRepository
    {
        private readonly ILogger<PredictionTrainerRepository> logger;

        public PredictionTrainerRepository(IDbConnection dbConnection, ILogger<PredictionTrainerRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task ClearPredictionsAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "DELETE FROM [dbo].[PrediccionRatingCurso]";
                await _dbConnection.QueryAsync(stringQuery);
                _dbConnection.Close();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
            }  
        }

        public async Task<int> CreatePredictionCourseForParticipantAsync(RatingCursoEntity entity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreatePredictionCurso", new { entity.Rating, entity.IdParticipante, entity.IdCurso },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }    
        }
    }
}
