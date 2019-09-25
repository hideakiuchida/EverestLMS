﻿using AutoMapper;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.Models;
using EverestLMS.ViewModels.Calendario;
using EverestLMS.ViewModels.Conocimiento;
using EverestLMS.ViewModels.Curso;
using EverestLMS.ViewModels.Etapa;
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
        }

        private void CreateMapParticipante()
        {
            CreateMap<ParticipanteToCreateVM, ParticipanteEntity>()
               .ForMember(dest => dest.Genero, opt => {
                   opt.MapFrom(d => d.Genero.ConvertGenderToString());
               })
               .ForMember(dest => dest.IdLineaCarrera, opt => {
                   opt.MapFrom(d => d.IdLineaCarrera.ValidateLineaCarrera());
               })
               .ForMember(dest => dest.IdNivel, opt => {
                   opt.MapFrom(d => d.IdNivel.ValidateNivel());
               });
            CreateMap<ParticipanteEntity, ParticipanteVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                })
                .ForMember(dest => dest.LineaCarrera, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt => {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                });
            CreateMap<ParticipanteEntity, SherpaLiteVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                });
            CreateMap<ParticipanteEntity, EscaladorLiteVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                })
                .ForMember(dest => dest.LineaCarrera, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt => {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Sede, opt => {
                    opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
                });

            CreateMap<ParticipanteEntity, EscaladorVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                })
                .ForMember(dest => dest.LineaCarrera, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt => {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Sede, opt => {
                    opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
                });
            CreateMap<ParticipanteEntity, SherpaVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                })
                .ForMember(dest => dest.LineaCarrera, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt => {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Sede, opt => {
                    opt.MapFrom(d => d.IdSede.ConvertSedeToString().SeparateTextByUpperCase());
                });
        }
        private void CreateMapLineaCarrera()
        {
            CreateMap<LineaCarreraEntity, LineaCarreraVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera);
                });
        }
        private void CreateMapNivel()
        {
            CreateMap<NivelEntity, NivelVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdNivel);
               });
        }
        private void CreateMapEtapa()
        {
            CreateMap<EtapaEntity, EtapaVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdEtapa);
               });
        }
        private void CreateMapSede()
        {
            CreateMap<SedeEntity, SedeVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdSede);
                });
        }
        private void CreateMapConocimiento()
        {
            CreateMap<ConocimientoEntity, ConocimientoVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdConocimiento);
                });
        }
        private void CreateMapCurso()
        {
            CreateMap<CursoPredictionEntity, CursoPredictionVM>()
                 .ForMember(dest => dest.Id, opt => {
                     opt.MapFrom(d => d.IdCurso);
                 }); ;
            CreateMap<CursoEntity, CursoVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdCurso);
               });
            CreateMap<CursoDetalleEntity, CursoDetalleVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdCurso);
               });
            CreateMap<CursoVM, CursoEntity>()
               .ForMember(dest => dest.IdCurso, opt => {
                   opt.MapFrom(d => d.Id);
               });

            CreateMap<DificultadEntity, DificultadVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdDificultad);
               });
            CreateMap<IdiomaEntity, IdiomaVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdIdioma);
               });
        }
        private void CreateMapCalendario()
        {
            CreateMap<CalendarioEntity, CalendarioVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdCalendario);
                }); 
            CreateMap<EventoEntity, EventoVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdEvento);
                }); 
            CreateMap<EventoVM, EventoEntity>()
                .ForMember(dest => dest.IdEvento, opt => {
                    opt.MapFrom(d => d.Id);
                });
            CreateMap<CriterioAceptacionEntity, CriterioAceptacionVM>()
               .ForMember(dest => dest.Id, opt => {
                   opt.MapFrom(d => d.IdCriterioAceptacion);
               });
            CreateMap<CriterioAceptacionVM, CriterioAceptacionEntity>()
                .ForMember(dest => dest.IdCriterioAceptacion, opt => {
                    opt.MapFrom(d => d.Id);
                });
        }
    }
}
