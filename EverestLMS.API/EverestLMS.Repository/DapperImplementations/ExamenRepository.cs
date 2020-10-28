using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class ExamenRepository : BaseConnection, IExamenRepository
    {
        public ExamenRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<int> CreateExamenAsync(ExamenEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateExamen",
                    new
                    {
                        entity.UsuarioKey,
                        entity.IdEtapa,
                        entity.IdCurso,
                        entity.IdLeccion,
                        entity.Nota,
                        entity.VidasRestante,
                        entity.NumeroPreguntaActual,
                        entity.TiempoRestante
                    },
                    commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> CreateQandAEscaladorAsync(int idExamen, RespuestaEscaladorEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateQandAEscalador",
                    new
                    {
                        entity.IdPregunta,
                        entity.DescripcionPregunta,
                        entity.IdRespuesta,
                        entity.DescripcionRespuesta,
                        entity.MarcoCorrecto,
                        IdExamen = idExamen,
                        entity.NumeroOrden
                    },
                    commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<ExamenEntity> GetExamenAsync(int id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ExamenEntity>("GetExamen", 
                new { Id = id },
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<RespuestaEscaladorEntity>> GetPreguntasDelExamenAsync(int id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<RespuestaEscaladorEntity>("GetPreguntasDelExamen", 
                new { IdExamen = id },
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<bool> UpdateExamenAsync(ExamenEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("UpdateExamen",
            new
            {
                IdExamen = entity.Id,
                entity.Nota,
                entity.VidasRestante,
                entity.TiempoRestante,
                entity.NumeroPreguntaActual,
                entity.FechaFinalizado
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateRespuestaDelExamenAsync(int idExamen, RespuestaEscaladorEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("UpdateRespuestaDelExamen",
            new
            {
                idExamen,
                entity.IdPregunta,
                entity.IdRespuesta,
                entity.DescripcionRespuesta,
                entity.MarcoCorrecto,
                entity.Id
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
