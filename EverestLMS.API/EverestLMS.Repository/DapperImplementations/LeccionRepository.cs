using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class LeccionRepository : BaseConnection, ILeccionRepository
    {
        public LeccionRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<int> CreateLeccionAsync(LeccionEntity leccionEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateLeccion",
            new
            {
                leccionEntity.Nombre,
                leccionEntity.Descripcion,
                leccionEntity.Puntaje,
                leccionEntity.IdCurso
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> CreatePreguntaAsync(PreguntaEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreatePregunta",
            new
            {
                entity.Descripcion,
                entity.Imagen,
                entity.IdLeccion
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public async Task<bool> UpdatePreguntaAsync(PreguntaEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("UpdatePregunta",
            new
            {
                entity.IdPregunta,
                entity.Descripcion,
                entity.Imagen,
                entity.IdLeccion
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> CreateRespuestaAsync(RespuestaEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateRespuesta",
            new
            {
                entity.Descripcion,
                entity.EsCorrecto,
                entity.IdPregunta
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateRespuestaAsync(RespuestaEntity entity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("UpdateRespuesta",
            new
            {
                entity.IdRespuesta,
                entity.Descripcion,
                entity.EsCorrecto,
                entity.IdPregunta
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("DeleteLeccion",
            new
            {
                IdCurso = idCurso,
                IdLeccion = idLeccion
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
        }

        public async Task<bool> DeletePreguntaAsync(int idPregunta)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("DeletePregunta",
            new
            {
                IdPregunta = idPregunta
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
        }

        public async Task<bool> DeleteRespuestaAsync(int idRespuesta)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("DeleteRespuesta",
            new
            {
                IdRespuesta = idRespuesta
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
        }

        public async Task<bool> UpdateLeccionAsync(LeccionEntity leccionEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("UpdateLeccion",
            new
            {
                leccionEntity.IdLeccion,
                leccionEntity.Nombre,
                leccionEntity.Descripcion,
                leccionEntity.ContenidoHTML,
                leccionEntity.Puntaje,
                leccionEntity.NumeroOrden,
                leccionEntity.IdCurso
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
        }

        public async Task<IEnumerable<LeccionDetalleEntity>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<LeccionDetalleEntity>("GetLecciones",
            new
            {
                IdCurso = idCurso,
                IdEtapa = idEtapa,
                IdNivel = idNivel,
                IdLineaCarrera = idLineaCarrera,
                Search = search
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<PreguntaEntity>> GetPreguntasAsync(int idLeccion)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<PreguntaEntity>("GetPreguntas", new { IdLeccion = idLeccion }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<RespuestaEntity>> GetRespuestasAsync(int idPregunta)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<RespuestaEntity>("GetRespuestas", new { IdPregunta = idPregunta }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<LeccionEntity> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<LeccionEntity>("GetLeccion", new { IdLeccion = idLeccion, IdEtapa = idEtapa, IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
        }

        public async Task<PreguntaEntity> GetSpecificPreguntaAsync(int idPregunta)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<PreguntaEntity>("GetPregunta", new { IdPregunta = idPregunta }, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<RespuestaEntity> GetSpecificRespuestaAsync(int idRespuesta)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<RespuestaEntity>("GetRespuesta", new { IdRespuesta = idRespuesta }, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
