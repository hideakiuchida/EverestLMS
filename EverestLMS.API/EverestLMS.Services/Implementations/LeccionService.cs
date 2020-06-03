using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EverestLMS.Common.Settings;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Leccion;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class LeccionService : ILeccionService
    {
        private readonly ILeccionRepository leccionRepository;
        private readonly IMapper mapper;
        private readonly Cloudinary cloudinary;

        public LeccionService(ILeccionRepository leccionRepository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.leccionRepository = leccionRepository;
            this.mapper = mapper;
            var cloudinaryConfiguration = cloudinaryConfig;
            Account account = new Account(
               cloudinaryConfiguration.Value.CloudName,
               cloudinaryConfiguration.Value.ApiKey,
               cloudinaryConfiguration.Value.ApiSecret
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

        public async Task<IEnumerable<PreguntaVM>> GetPreguntasAsync(int idLeccion)
        {
            var preguntaEntities = await leccionRepository.GetPreguntasAsync(idLeccion);
            var preguntaVMs = mapper.Map<IEnumerable<PreguntaVM>>(preguntaEntities);
            return preguntaVMs;
        }

        public async Task<PreguntaVM> GetSpecificPreguntaAsync(int idPregunta)
        {
            var entity = await leccionRepository.GetSpecificPreguntaAsync(idPregunta);
            var viewModel = mapper.Map<PreguntaVM>(entity);
            return viewModel;
        }

        public async Task<int> CreatePreguntaAsync(PreguntaToCreateVM preguntaToCreateVM)
        {
            var entity = mapper.Map<PreguntaEntity>(preguntaToCreateVM);
            var id = await leccionRepository.CreatePreguntaAsync(entity);
            return id;
        }
        public async Task<bool> UpdatePreguntaAsync(PreguntaVM preguntaToUpdateVM)
        {
            var entity = mapper.Map<PreguntaEntity>(preguntaToUpdateVM);
            return await leccionRepository.UpdatePreguntaAsync(entity);
        }

        public async Task<bool> DeletePreguntaAsync(int idPregunta)
        {
            return await leccionRepository.DeletePreguntaAsync(idPregunta);
        }

        public async Task<IEnumerable<RespuestaVM>> GetRespuestasAsync(int idPregunta)
        {
            var entities = await leccionRepository.GetRespuestasAsync(idPregunta);
            var viewModels = mapper.Map<IEnumerable<RespuestaVM>>(entities);
            return viewModels;
        }

        public async Task<RespuestaVM> GetSpecificRespuestaAsync(int idRespuesta)
        {
            var entity = await leccionRepository.GetSpecificRespuestaAsync(idRespuesta);
            var viewModel = mapper.Map<RespuestaVM>(entity);
            return viewModel;
        }

        public async Task<int> CreateRespuestaAsync(RespuestaToCreateVM respuestaToCreateVM)
        {
            var entity = mapper.Map<RespuestaEntity>(respuestaToCreateVM);
            var id = await leccionRepository.CreateRespuestaAsync(entity);
            return id;
        }

        public async Task<bool> DeleteRespuestaAsync(int idRespuesta)
        {
            return await leccionRepository.DeleteRespuestaAsync(idRespuesta);
        }

        public async Task<bool> UpdateRespuestaAsync(RespuestaVM respuestaToUpdateVM)
        {
            var entity = mapper.Map<RespuestaEntity>(respuestaToUpdateVM);
            return await leccionRepository.UpdateRespuestaAsync(entity);
        }

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

        public async Task<bool> UpdateLeccionMaterialAsync(LeccionMaterialToUpdateVM leccionMaterialVM)
        {
            var leccionMaterialEntity = mapper.Map<LeccionMaterialDetalleEntity>(leccionMaterialVM);
            return await leccionRepository.UpdateLeccionMaterialAsync(leccionMaterialEntity);
        }
    }
}
