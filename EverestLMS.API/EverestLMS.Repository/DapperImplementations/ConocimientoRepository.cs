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
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("CreateConocimientoParticipante",
                new
                {
                    conocimientoParticipanteEntity.IdConocimiento,
                    conocimientoParticipanteEntity.IdParticipante
                },
                commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
        }

        public async Task<ConocimientoEntity> GetByIdAsync(int? id)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<ConocimientoEntity>("GetConocimientos", new { IdConocimiento = id },
                commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<ConocimientoEntity>> GetConocimientoByParticipanteIdAsync(string id)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<ConocimientoEntity>("GetConocimientosPorParticipante", new { IdParticipante = id },
                commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
        }
    }
}
