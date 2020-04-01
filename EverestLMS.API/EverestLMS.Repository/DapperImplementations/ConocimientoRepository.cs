using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class ConocimientoRepository : BaseConnection, IConocimientoRepository
    {
        public ConocimientoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<int> CreateConocimientoParticipanteAsync(ConocimientoParticipanteEntity conocimientoParticipanteEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateConocimientoParticipante",
            new
            {
                conocimientoParticipanteEntity.IdConocimiento,
                conocimientoParticipanteEntity.IdParticipante
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<ConocimientoEntity> GetByIdAsync(int? id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ConocimientoEntity>("GetConocimientos", new { IdConocimiento = id },
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ConocimientoEntity>> GetConocimientoByParticipanteIdAsync(string id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ConocimientoEntity>("GetConocimientosPorParticipante", new { IdParticipante = id },
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
