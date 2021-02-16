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
        private readonly ICursoRepository cursoRepository;
        private readonly IMapper mapper;
        private readonly Cloudinary cloudinary;

        public LeccionService(ILeccionRepository leccionRepository, ICursoRepository cursoRepository,
            IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.leccionRepository = leccionRepository;
            this.cursoRepository = cursoRepository;
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

        public async Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            return await leccionRepository.DeleteLeccionAsync(idEtapa, idCurso, idLeccion);
        }

        public async Task<bool> UpdateLeccionAsync(LeccionToUpdateVM leccionVM)
        {
            var leccionEntity = mapper.Map<LeccionEntity>(leccionVM);
            var result = await leccionRepository.UpdateLeccionAsync(leccionEntity);
            return result;
        }

        public async Task<IEnumerable<LeccionDetalleVM>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search)
        {
            var leccionesEntities = await leccionRepository.GetLeccionesDetalleAsync(idNivel, idLineaCarrera, idEtapa, idCurso, search);
            var leccionesVM = mapper.Map<IEnumerable<LeccionDetalleVM>>(leccionesEntities);
            return leccionesVM;
        }

        public async Task<LeccionVM> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion)
        {
            var entity = await leccionRepository.GetSpecificLeccionAsync(idEtapa, idCurso, idLeccion);
            var viewModel = mapper.Map<LeccionVM>(entity);
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

        public async Task<LeccionEscaladorVM> GetLeccionByParticipanteAsync(string id, int idEtapa, int idCurso, int idLeccion)
        {
            var curso = await cursoRepository.GetCursoAsync(idEtapa, idCurso);
            var leccion = await leccionRepository.GetSpecificLeccionAsync(idEtapa, idCurso, idLeccion);
            var leccionEscaladorVM = new LeccionEscaladorVM();
            leccionEscaladorVM.IdEtapa = idEtapa;
            leccionEscaladorVM.IdParticipante = id;
            leccionEscaladorVM.Id = leccion.IdLeccion;
            leccionEscaladorVM.IdCurso = curso.IdCurso;
            leccionEscaladorVM.Nombre = leccion.Nombre;
            leccionEscaladorVM.CursoNombre = curso.Nombre;
            leccionEscaladorVM.CursoImagenUrl = curso.Imagen;
            leccionEscaladorVM.ContenidoHTML = leccion.ContenidoHTML;
            return leccionEscaladorVM;
        }
    }
}
