using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EverestLMS.Common.Settings;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Leccion;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class LeccionService : ILeccionService
    {
        private readonly ILeccionRepository leccionRepository;
        private readonly IMapper mapper;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private Cloudinary cloudinary;

        public LeccionService(ILeccionRepository leccionRepository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.leccionRepository = leccionRepository;
            this.mapper = mapper;
            this.cloudinaryConfig = cloudinaryConfig;
            Account account = new Account(
               this.cloudinaryConfig.Value.CloudName,
               this.cloudinaryConfig.Value.ApiKey,
               this.cloudinaryConfig.Value.ApiSecret
           );

            this.cloudinary = new Cloudinary(account);
        }
        public async Task<int> CreateLeccionAsync(LeccionToCreateVM leccionVM)
        {
            var leccionEntity = mapper.Map<LeccionEntity>(leccionVM);
            var idLeccion = await leccionRepository.CreateLeccionAsync(leccionEntity);
            return idLeccion;
        }

        public async Task<int> CreateLeccionMaterialAsync(LeccionMaterialToCreateVM leccionMaterialVM)
        {
            var leccionMaterialEntity = mapper.Map<LeccionMaterialDetalleEntity>(leccionMaterialVM);
            var idLeccionMaterial = await leccionRepository.CreateLeccionMaterialAsync(leccionMaterialEntity);
            return idLeccionMaterial;
        }

        public async Task<int> CreateLeccionVideoMaterialAsync(LeccionMaterialVideoToCreateVM leccionMaterialVM)
        {
            var cloudinaryFileEntity = UploadingToCloudinary(leccionMaterialVM);
            var idLeccionMaterial = await leccionRepository.CreateLeccionMaterialAsync(cloudinaryFileEntity);
            return idLeccionMaterial;
        }

        public async Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            return await leccionRepository.DeleteLeccionAsync(idEtapa, idCurso, idLeccion);
        }

        public async Task<bool> DeleteLeccionMaterialAsync(int idLeccion, int idLeccionMaterial)
        {
            await DeleteFileInCloudinary(idLeccion, idLeccionMaterial);
            return await leccionRepository.DeleteLeccionMaterialAsync(idLeccion, idLeccionMaterial);
        }

        public async Task<bool> EditLeccionAsync(LeccionToUpdateVM leccionVM)
        {
            var leccionEntity = mapper.Map<LeccionEntity>(leccionVM);
            var result = await leccionRepository.EditLeccionAsync(leccionEntity);
            return result;
        }

        public async Task<IEnumerable<LeccionDetalleVM>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search)
        {
            var leccionesEntities = await leccionRepository.GetLeccionesDetalleAsync(idNivel, idLineaCarrera, idEtapa, idCurso, search);
            var leccionesVM = mapper.Map<IEnumerable<LeccionDetalleVM>>(leccionesEntities);
            return leccionesVM;
        }

        public async Task<IEnumerable<LeccionMaterialVM>> GetLeccionMaterialesAsync(int idLeccion)
        {
            var leccionesMaterialesEntities = await leccionRepository.GetLeccionMaterialesAsync(idLeccion);
            var leccionessMaterialesVM = mapper.Map<IEnumerable<LeccionMaterialVM>>(leccionesMaterialesEntities);
            return leccionessMaterialesVM;
        }

        public async Task<LeccionVM> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            var entity = await leccionRepository.GetSpecificLeccionAsync(idEtapa, idCurso, idLeccion);
            var viewModel = mapper.Map<LeccionVM>(entity);
            return viewModel;
        }

        public async Task<LeccionMaterialDetalleVM> GetSpecificLeccionMaterialAsync(int idLeccion, int idLeccionMaterial)
        {
            var entity = await leccionRepository.GetSpecificLeccionMaterialAsync(idLeccion, idLeccionMaterial);
            var viewModel = mapper.Map<LeccionMaterialDetalleVM>(entity);
            return viewModel;
        }

        #region Private Methods
        private LeccionMaterialDetalleEntity UploadingToCloudinary(LeccionMaterialVideoToCreateVM cloudinaryFileToCreate)
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

            var cloudinaryFileEntity = mapper.Map<LeccionMaterialDetalleEntity>(cloudinaryFileToCreate);

            cloudinaryFileEntity.Url = uploadResult.Uri.ToString();
            cloudinaryFileEntity.IdPublico = uploadResult.PublicId;
            return cloudinaryFileEntity;
        }

        private async Task<bool> DeleteFileInCloudinary(int idLeccion, int idLeccionMaterial)
        {
            var entity = await leccionRepository.GetSpecificLeccionMaterialAsync(idLeccion, idLeccionMaterial);
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
