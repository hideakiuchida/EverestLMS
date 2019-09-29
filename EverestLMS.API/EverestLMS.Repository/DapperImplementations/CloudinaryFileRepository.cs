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
    public class CloudinaryFileRepository : BaseConnection, ICloudinaryFileRepository
    {
        private readonly ILogger<CloudinaryFileRepository> logger;
        public CloudinaryFileRepository(IDbConnection dbConnection, ILogger<CloudinaryFileRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }

        public async Task<int> CreateCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("CreateCloudinaryFile",
                    new
                    {
                        cloudinaryFileEntity.Descripcion,
                        cloudinaryFileEntity.IdPublico,
                        cloudinaryFileEntity.Url,
                        cloudinaryFileEntity.IdReferencia
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

        public async Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idReferencia)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<int>("DeleteCloudinaryFile",
                    new
                    {
                        IdCloudinaryFile = idCloudinaryFile,
                        IdReferencia = idReferencia
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<bool> EditCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity)
        {
            try
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
                        cloudinaryFileEntity.IdReferencia
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<IEnumerable<CloudinaryFileEntity>> GetCloudinaryFilesAsync(int? idReferencia)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<CloudinaryFileEntity>("GetCloudinaryFiles",
                    new
                    {
                        IdReferencia = idReferencia
                    },
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<CloudinaryFileEntity> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idReferencia)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<CloudinaryFileEntity>("GetCloudinaryFile",
                    new
                    {
                        IdCloudinaryFile = idCloudinaryFile,
                        IdReferencia = idReferencia
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
    }
}
