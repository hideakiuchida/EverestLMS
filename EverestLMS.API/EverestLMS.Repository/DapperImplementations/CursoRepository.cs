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

        public async Task<int> CreateCursoAsync(CursoEntity cursoEntity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateCurso",
                    new
                    {
                        cursoEntity.Nombre,
                        cursoEntity.Descripcion,
                        cursoEntity.IdDificultad,
                        cursoEntity.Idioma,
                        cursoEntity.Imagen,
                        cursoEntity.Puntaje,
                        cursoEntity.IdEtapa,
                        cursoEntity.Autor
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<bool> DeleteCursoAsync(int idEtapa, int idCurso)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("DeleteCurso",
                    new
                    {
                        IdEtapa = idEtapa,
                        IdCurso = idCurso
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<bool> EditCursoASync(CursoEntity cursoEntity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("EditCurso",
                    new
                    {
                        cursoEntity.IdCurso,
                        cursoEntity.Nombre,
                        cursoEntity.Descripcion,
                        cursoEntity.IdDificultad,
                        cursoEntity.Idioma,
                        cursoEntity.Imagen,
                        cursoEntity.Puntaje,
                        cursoEntity.IdEtapa,
                        cursoEntity.Autor
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<CursoToUpdateEntity> GetCursoAsync(int idEtapa, int idCurso)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<CursoToUpdateEntity>("GetCurso", new { IdEtapa = idEtapa, IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<IEnumerable<CursoDetalleEntity>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<CursoDetalleEntity>("GetCursos", new { IdEtapa = idEtapa, IdNivel = idNivel, IdLineaCarrera = idLineaCarrera, Search = search }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<IEnumerable<CursoPredictionEntity>> GetCursosPredictionByParticipantAsync(int? idLineaCarrera, int? idNivel)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<CursoPredictionEntity>("GetCursosPredictionByParticipant", new { IdNivel = idNivel, IdLineaCarrera = idLineaCarrera }, commandType: CommandType.StoredProcedure);
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
