using AutoMapper;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.Models;
using EverestLMS.ViewModels.Authentication;
using EverestLMS.ViewModels.Calendario;
using EverestLMS.ViewModels.CloudinaryFile;
using EverestLMS.ViewModels.Conocimiento;
using EverestLMS.ViewModels.Curso;
using EverestLMS.ViewModels.Etapa;
using EverestLMS.ViewModels.Examen;
using EverestLMS.ViewModels.Leccion;
using EverestLMS.ViewModels.LineaCarrera;
using EverestLMS.ViewModels.Nivel;
using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using EverestLMS.ViewModels.Sede;

namespace EverestLMS.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMapParticipante();
            CreateMapLineaCarrera();
            CreateMapNivel();
            CreateMapConocimiento();
            CreateMapCurso();
            CreateMapSede();
            CreateMapCalendario();
            CreateMapEtapa();
            CreateMapCloudinaryFile();
            CreateMapLeccion();
            CreateMapAuthentication();
            CreateMapPregunta();
            CreateMapRespuesta();
            CreateMapExamen();
        }

        private void CreateMapExamen()
        {
            CreateMap<ExamenEntity, ExamenVM>();
            CreateMap<RespuestaEscaladorEntity, PreguntaExamenVM>()
                 .ForMember(dest => dest.IdRespuestaEscalador, opt =>
                 {
                     opt.MapFrom(d => d.Id);
                 });
            CreateMap<ExamenToUpdateVM, ExamenEntity>();
            CreateMap<RespuestaExamenToUpdateVM, RespuestaEscaladorEntity>();
        }
        private void CreateMapRespuesta()
        {
            CreateMap<RespuestaEntity, RespuestaVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdRespuesta);
                });
            CreateMap<RespuestaVM, RespuestaEntity>()
                .ForMember(dest => dest.IdRespuesta, opt =>
                {
                    opt.MapFrom(d => d.Id);
                });
            CreateMap<RespuestaToCreateVM, RespuestaEntity>();
        }

        private void CreateMapPregunta()
        {
            CreateMap<PreguntaEntity, PreguntaVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdPregunta);
                });
            CreateMap<PreguntaVM, PreguntaEntity>()
                .ForMember(dest => dest.IdPregunta, opt =>
                {
                    opt.MapFrom(d => d.Id);
                });
            CreateMap<PreguntaToCreateVM, PreguntaEntity>();
        }

        private void CreateMapParticipante()
        {
            CreateMap<ParticipanteToCreateVM, ParticipanteEntity>()
               .ForMember(dest => dest.Genero, opt =>
               {
                   opt.MapFrom(d => d.Genero.ConvertGenderToString());
               })
               .ForMember(dest => dest.IdLineaCarrera, opt =>
               {
                   opt.MapFrom(d => d.IdLineaCarrera.ValidateLineaCarrera());
               })
               .ForMember(dest => dest.IdNivel, opt =>
               {
                   opt.MapFrom(d => d.IdNivel.ValidateNivel());
               });
            CreateMap<ParticipanteEntity, ParticipanteVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.UsuarioKey);
                })
                .ForMember(dest => dest.LineaCarrera, opt =>
                {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt =>
                {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                });
            CreateMap<ParticipanteEntity, SherpaLiteVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.UsuarioKey);
                });
            CreateMap<ParticipanteEntity, EscaladorLiteVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.UsuarioKey);
                })
                .ForMember(dest => dest.LineaCarrera, opt =>
                {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt =>
                {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Sede, opt =>
                {
                    opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
                });

            CreateMap<ParticipanteEntity, EscaladorVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.UsuarioKey);
                })
                .ForMember(dest => dest.LineaCarrera, opt =>
                {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt =>
                {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Sede, opt =>
                {
                    opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
                });
            CreateMap<ParticipanteEntity, SherpaVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.UsuarioKey);
                })
                .ForMember(dest => dest.LineaCarrera, opt =>
                {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt =>
                {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Sede, opt =>
                {
                    opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
                });

            CreateMap<ParticipanteEntity, SherpaLiteVM>()
              .ForMember(dest => dest.Id, opt =>
              {
                  opt.MapFrom(d => d.UsuarioKey);
              });

            CreateMap<ParticipanteEntity, EscaladorLiteVM>()
              .ForMember(dest => dest.Id, opt =>
              {
                  opt.MapFrom(d => d.UsuarioKey);
              })
              .ForMember(dest => dest.LineaCarrera, opt =>
              {
                  opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
              })
              .ForMember(dest => dest.Nivel, opt =>
              {
                  opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
              })
              .ForMember(dest => dest.Sede, opt =>
              {
                  opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
              });
        }
        private void CreateMapLineaCarrera()
        {
            CreateMap<LineaCarreraEntity, LineaCarreraVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdLineaCarrera);
                });
        }
        private void CreateMapNivel()
        {
            CreateMap<NivelEntity, NivelVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdNivel);
               });
        }
        private void CreateMapEtapa()
        {
            CreateMap<EtapaEntity, EtapaVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdEtapa);
               });
        }
        private void CreateMapSede()
        {
            CreateMap<SedeEntity, SedeVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdSede);
                });
        }
        private void CreateMapConocimiento()
        {
            CreateMap<ConocimientoEntity, ConocimientoVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdConocimiento);
                });
        }
        private void CreateMapCurso()
        {
            CreateMap<CursoPredictionEntity, CursoPredictionVM>()
                 .ForMember(dest => dest.Id, opt =>
                 {
                     opt.MapFrom(d => d.IdCurso);
                 });
            CreateMap<CursoEntity, CursoVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdCurso);
               });
            CreateMap<CursoEntity, CursoDetalleVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdCurso);
               });
            CreateMap<CursoDetalleEntity, CursoDetalleVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdCurso);
               });
            CreateMap<CursoToUpdateVM, CursoEntity>()
               .ForMember(dest => dest.IdCurso, opt =>
               {
                   opt.MapFrom(d => d.Id);
               })
               .ForMember(dest => dest.Idioma, opt =>
               {
                   opt.MapFrom(d => d.IdIdioma);
               });
            CreateMap<CursoToUpdateEntity, CursoToUpdateVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdCurso);
               })
               .ForMember(dest => dest.IdIdioma, opt =>
               {
                   opt.MapFrom(d => d.Idioma);
               });
            CreateMap<CursoToCreateVM, CursoEntity>()
               .ForMember(dest => dest.Idioma, opt =>
               {
                   opt.MapFrom(d => d.IdIdioma);
               });

            CreateMap<DificultadEntity, DificultadVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdDificultad);
               });
            CreateMap<IdiomaEntity, IdiomaVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdIdioma);
               });
        }
        private void CreateMapCalendario()
        {
            CreateMap<CalendarioEntity, CalendarioVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdCalendario);
                });
            CreateMap<EventoEntity, EventoVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdEvento);
                });
            CreateMap<EventoVM, EventoEntity>()
                .ForMember(dest => dest.IdEvento, opt =>
                {
                    opt.MapFrom(d => d.Id);
                });
            CreateMap<CriterioAceptacionEntity, CriterioAceptacionVM>()
               .ForMember(dest => dest.Id, opt =>
               {
                   opt.MapFrom(d => d.IdCriterioAceptacion);
               });
            CreateMap<CriterioAceptacionVM, CriterioAceptacionEntity>()
                .ForMember(dest => dest.IdCriterioAceptacion, opt =>
                {
                    opt.MapFrom(d => d.Id);
                });
        }
        private void CreateMapCloudinaryFile()
        {
            CreateMap<CloudinaryFileEntity, CloudinaryFileVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdCloudinaryFile);
                });
            CreateMap<CloudinaryFileToCreateVM, CloudinaryFileEntity>();
            CreateMap<CloudinaryFileToUpdateVM, CloudinaryFileEntity>()
                .ForMember(dest => dest.IdCloudinaryFile, opt =>
                {
                    opt.MapFrom(d => d.Id);
                });
        }
        private void CreateMapLeccion()
        {
            CreateMap<LeccionEntity, LeccionVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdLeccion);
                });
            CreateMap<LeccionDetalleEntity, LeccionDetalleVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdLeccion);
                });
            CreateMap<LeccionToCreateVM, LeccionEntity>();
            CreateMap<LeccionToUpdateVM, LeccionEntity>()
                .ForMember(dest => dest.IdLeccion, opt =>
                {
                    opt.MapFrom(d => d.Id);
                });
            CreateMap<LeccionMaterialEntity, LeccionMaterialVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdLeccionMaterial);
                });
            CreateMap<LeccionMaterialDetalleEntity, LeccionMaterialDetalleVM>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(d => d.IdLeccionMaterial);
                });
            CreateMap<LeccionMaterialToCreateVM, LeccionMaterialDetalleEntity>();
            CreateMap<LeccionMaterialVideoToCreateVM, LeccionMaterialDetalleEntity>();

            CreateMap<LeccionMaterialToUpdateVM, LeccionMaterialDetalleEntity>()
                 .ForMember(dest => dest.IdLeccionMaterial, opt =>
                 {
                     opt.MapFrom(d => d.Id);
                 });
        }

        private void CreateMapAuthentication()
        {
            CreateMap<UsuarioEntity, UsuarioVM>();
            CreateMap<UsuarioToRegisterVM, UsuarioEntity>();
        }
    }
}
