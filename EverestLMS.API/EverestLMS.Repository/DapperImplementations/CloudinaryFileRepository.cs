using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class CloudinaryFileRepository : BaseConnection, ICloudinaryFileRepository
    {
        public CloudinaryFileRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<int> CreateCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateCloudinaryFile",
                new
                {
                    cloudinaryFileEntity.Descripcion,
                    cloudinaryFileEntity.IdPublico,
                    cloudinaryFileEntity.Url,
                    cloudinaryFileEntity.IdCurso,
                    cloudinaryFileEntity.IdPregunta,
                    cloudinaryFileEntity.IdRespuesta,
                    cloudinaryFileEntity.IdUsuario,
                    cloudinaryFileEntity.IdLeccion
                },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
        }

        public async Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("DeleteCloudinaryFile",
                new
                {
                    IdCloudinaryFile = idCloudinaryFile,
                    IdCurso = idCurso,
                    IdPregunta = idPregunta,
                    IdRespuesta = idRespuesta,
                    IdUsuario = idUsuario,
                    IdLeccion = idLeccion
                },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
        }

        public async Task<bool> EditCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("EditCloudinaryFile",
                new
                {
                    cloudinaryFileEntity.IdCloudinaryFile,
                    cloudinaryFileEntity.Descripcion,
                    cloudinaryFileEntity.IdPublico,
                    cloudinaryFileEntity.Url,
                    cloudinaryFileEntity.IdCurso,
                    cloudinaryFileEntity.IdPregunta,
                    cloudinaryFileEntity.IdRespuesta,
                    cloudinaryFileEntity.IdUsuario,
                    cloudinaryFileEntity.IdLeccion
                },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
        }

        public async Task<IEnumerable<CloudinaryFileEntity>> GetCloudinaryFilesAsync(int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<CloudinaryFileEntity>("GetCloudinaryFiles",
                new
                {
                    IdCurso = idCurso,
                    IdPregunta = idPregunta,
                    IdRespuesta = idRespuesta,
                    IdUsuario = idUsuario,
                    IdLeccion = idLeccion
                },
                commandType: CommandType.StoredProcedure);
                return result.ToList();
        }

        public async Task<CloudinaryFileEntity> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<CloudinaryFileEntity>("GetCloudinaryFile",
                new
                {
                    IdCloudinaryFile = idCloudinaryFile,
                    IdCurso = idCurso,
                    IdPregunta = idPregunta,
                    IdRespuesta = idRespuesta,
                    IdUsuario = idUsuario,
                    IdLeccion = idLeccion
                },
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
