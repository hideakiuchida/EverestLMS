using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class EtapaRepository : BaseConnection, IEtapaRepository
    {
        public EtapaRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<EtapaEntity>> GetAllAsync(int? idNivel, int? idLineaCarrera, string search)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<EtapaEntity>("GetEtapas", new { IdNivel = idNivel, IdLineaCarrera = idLineaCarrera, Search = search },
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<EtapaEntity>> GetByParticipanteAsync(string idParticipante)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<EtapaEntity>("GetEtapasByParticipante", new { IdParticipante = idParticipante },
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
