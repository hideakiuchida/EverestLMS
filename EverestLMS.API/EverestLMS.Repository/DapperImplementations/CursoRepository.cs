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
    public class CursoRepository : BaseConnection, ICursoRepository
    {
        private ILogger<CursoRepository> logger;

        public CursoRepository(IDbConnection dbConnection, ILogger<CursoRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<CursoPredictionEntity>> GetCursosAsync(int? idLineaCarrera, int? idNivel)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<CursoPredictionEntity>("GetCursos", new { IdNivel = idNivel, IdLineaCarrera = idLineaCarrera }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }   
        }
    }
}
