using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EverestLMS.Common.Settings;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.CloudinaryFile;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class CloudinaryFileService : ICloudinaryFileService
    {
        private readonly ICloudinaryFileRepository cloudinaryFileRepository;
        private readonly IMapper mapper;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private Cloudinary cloudinary;

        public CloudinaryFileService(ICloudinaryFileRepository cloudinaryFileRepository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.cloudinaryFileRepository = cloudinaryFileRepository;
            this.mapper = mapper;
            this.cloudinaryConfig = cloudinaryConfig;
            Account account = new Account(
               this.cloudinaryConfig.Value.CloudName,
               this.cloudinaryConfig.Value.ApiKey,
               this.cloudinaryConfig.Value.ApiSecret
           );

            this.cloudinary = new Cloudinary(account);
        }
        public async Task<int> CreateCloudinaryFileAsync(CloudinaryFileToCreateVM cloudinaryFileToCreate)
        {
            var cloudinaryFileEntity = UploadingToCloudinary(cloudinaryFileToCreate);
            var result = await cloudinaryFileRepository.CreateCloudinaryFileAsync(cloudinaryFileEntity);
            return result;
        }

        public async Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccionMaterial = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            var deletedOncloudinary = await DeleteFileInCloudinary(idCloudinaryFile, idCurso, idLeccionMaterial, idPregunta, idRespuesta, idUsuario);
            if (!deletedOncloudinary)
                return deletedOncloudinary;
            var deleted = await cloudinaryFileRepository.DeleteCloudinaryFileAsync(idCloudinaryFile, idCurso, idLeccionMaterial, idPregunta, idRespuesta, idUsuario);
            return deleted;
        }

        public async Task<bool> EditCloudinaryFileAsync(CloudinaryFileToUpdateVM cloudinaryFileToUpdateVM)
        {
            var deletedOncloudinary = await DeleteFileInCloudinary(cloudinaryFileToUpdateVM.Id, cloudinaryFileToUpdateVM.IdCurso, null, cloudinaryFileToUpdateVM.IdPregunta,
                cloudinaryFileToUpdateVM.IdRespuesta, cloudinaryFileToUpdateVM.IdUsuario);
            if (!deletedOncloudinary)
                return deletedOncloudinary;
            var cloudinaryFileEntity = UploadingToCloudinary(cloudinaryFileToUpdateVM);
            var result = await cloudinaryFileRepository.EditCloudinaryFileAsync(cloudinaryFileEntity);
            return result;
        }

        public async Task<IEnumerable<CloudinaryFileVM>> GetCloudinaryFilesAsync(int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            var entities = await cloudinaryFileRepository.GetCloudinaryFilesAsync(idCurso, idLeccion, idPregunta, idRespuesta, idUsuario);
            var result = mapper.Map<IEnumerable<CloudinaryFileVM>>(entities);
            return result;
        }

        public async Task<CloudinaryFileVM> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccionMaterial = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            var entity = await cloudinaryFileRepository.GetSpecificCloudinaryFilesAsync(idCloudinaryFile, idCurso, idLeccionMaterial, idPregunta, idRespuesta, idUsuario);
            var result = mapper.Map<CloudinaryFileVM>(entity);
            return result;
        }

        #region Private Methods
        private CloudinaryFileEntity UploadingToCloudinary(CloudinaryFileToCreateVM cloudinaryFileToCreate)
        {
            var file = cloudinaryFileToCreate.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = this.cloudinary.Upload(uploadParams);
                }
            }

            var cloudinaryFileEntity = mapper.Map<CloudinaryFileEntity>(cloudinaryFileToCreate);

            cloudinaryFileEntity.Url = uploadResult.Uri.ToString();
            cloudinaryFileEntity.IdPublico = uploadResult.PublicId;
            return cloudinaryFileEntity;
        }

        private async Task<bool> DeleteFileInCloudinary(int idCloudinaryFile, int? idCurso = null, int? idLeccionMaterial = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null)
        {
            var entity = await cloudinaryFileRepository.GetSpecificCloudinaryFilesAsync(idCloudinaryFile, idCurso, idLeccionMaterial, idPregunta, idRespuesta, idUsuario);
            if (entity?.IdPublico != null)
            {
                var deleteParams = new DeletionParams(entity.IdPublico);
                var result = this.cloudinary.Destroy(deleteParams);

                if (result.Result != "ok")
                    return default;
            }
            return true;
        }
        #endregion
    }
}
