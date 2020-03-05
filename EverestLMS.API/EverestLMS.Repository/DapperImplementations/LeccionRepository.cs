using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System;
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

        public async Task<int> CreateLeccionMaterialAsync(LeccionMaterialDetalleEntity leccionMaterialEntity)
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

        public async Task<bool> DeleteLeccionMaterialAsync(int idLeccion, int idLeccionMaterial)
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

        public async Task<bool> EditLeccionAsync(LeccionEntity leccionEntity)
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
            _dbConnection.Close();
            return result.ToList();
        }

        public async Task<IEnumerable<LeccionMaterialEntity>> GetLeccionMaterialesAsync(int idLeccion)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<LeccionMaterialEntity>("GetLeccionesMaterial", new { IdLeccion = idLeccion }, commandType: CommandType.StoredProcedure);
            _dbConnection.Close();
            return result.ToList();
        }

        public async Task<LeccionEntity> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<LeccionEntity>("GetLeccion", new { IdLeccion = idLeccion, IdEtapa = idEtapa, IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
            _dbConnection.Close();
            return result.FirstOrDefault();
        }

        public async Task<LeccionMaterialDetalleEntity> GetSpecificLeccionMaterialAsync(int idLeccion, int idLeccionMaterial)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<LeccionMaterialDetalleEntity>("GetLeccionMaterial", new { IdLeccionMaterial = idLeccionMaterial, IdLeccion = idLeccion }, commandType: CommandType.StoredProcedure);
            _dbConnection.Close();
            return result.FirstOrDefault();
        }
    }
}
