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
    public class LeccionRepository : BaseConnection, ILeccionRepository
    {
        private ILogger<LeccionRepository> logger;
        public LeccionRepository(IDbConnection dbConnection, ILogger<LeccionRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<int> CreateLeccionAsync(LeccionEntity leccionEntity)
        {
            try
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<int> CreateLeccionMaterialAsync(LeccionMaterialEntity leccionMaterialEntity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateLeccionMaterial",
                    new
                    {
                        leccionMaterialEntity.Titulo,
                        leccionMaterialEntity.ContenidoTexto,
                        leccionMaterialEntity.IdPublico,
                        leccionMaterialEntity.Url,
                        leccionMaterialEntity.IdTipoContenido,
                        leccionMaterialEntity.IdLeccion
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            try
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteLeccionMaterialAsync(int idLeccion, int idLeccionMaterial)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("DeleteLeccionMaterial",
                    new
                    {
                        IdLeccionMaterial = idLeccionMaterial,
                        IdLeccion = idLeccion
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<bool> EditLeccionAsync(LeccionEntity leccionEntity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("EditLeccion",
                    new
                    {
                        leccionEntity.IdLeccion,
                        leccionEntity.Nombre,
                        leccionEntity.Descripcion,
                        leccionEntity.Puntaje,
                        leccionEntity.NumeroOrden,
                        leccionEntity.IdCurso
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<LeccionDetalleEntity>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search)
        {
            try
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
                _dbConnection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<LeccionMaterialEntity>> GetLeccionMaterialesAsync(int idLeccion)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<LeccionMaterialEntity>("GetLeccionesMaterial", new { IdLeccion = idLeccion }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<LeccionEntity> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<LeccionEntity>("GetLeccion", new { IdLeccion = idLeccion, IdEtapa = idEtapa, IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                throw;
            }
        }

        public async Task<LeccionMaterialEntity> GetSpecificLeccionMaterialAsync(int idLeccion, int idLeccionMaterial)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<LeccionMaterialEntity>("GetLeccionMaterial", new { IdLeccionMaterial = idLeccionMaterial, IdLeccion = idLeccion }, commandType: CommandType.StoredProcedure);
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
