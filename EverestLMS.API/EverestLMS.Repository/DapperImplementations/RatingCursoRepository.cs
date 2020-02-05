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
    public class RatingCursoRepository : BaseConnection, IRatingCursoRepository
    {
        private ILogger<RatingCursoRepository> logger;

        public RatingCursoRepository(IDbConnection dbConnection, ILogger<RatingCursoRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }
        public async Task<int> CreateAsync(RatingCursoEntity entity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateRatingCurso", new { entity.Rating, entity.IdParticipante, entity.IdCurso },
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

        public async Task<IEnumerable<RatingCursoEntity>> GetAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "SELECT [IdRatingCurso],[Rating],[IdParticipante],[IdCurso] FROM [dbo].[RatingCurso]";
                var result = await _dbConnection.QueryAsync<RatingCursoEntity>(stringQuery);
                _dbConnection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }        
        }

        public async Task<int> RemoveAllAsync()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                string stringQuery = "DELETE FROM [dbo].[RatingCurso]";
                var result = await _dbConnection.QueryAsync<int>(stringQuery);
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
