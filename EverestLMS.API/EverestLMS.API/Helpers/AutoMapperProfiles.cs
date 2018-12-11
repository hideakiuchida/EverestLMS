using AutoMapper;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.POCO;
using EverestLMS.ViewModels.Conocimiento;
using EverestLMS.ViewModels.LineaCarrera;
using EverestLMS.ViewModels.Nivel;
using EverestLMS.ViewModels.Participante;
using EverestLMS.ViewModels.Participante.Escalador;
using EverestLMS.ViewModels.Participante.Sherpa;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            /*CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });*/

            CreateMap<ParticipanteToCreateVM, Participante>()
                .ForMember(dest => dest.Genero, opt => {
                    opt.MapFrom(d => d.Genero.ConvertGenderToString());
                })
                .ForMember(dest => dest.Sede, opt => {
                    opt.MapFrom(d => d.Sede.ConvertSedeToString());
                })
                .ForMember(dest => dest.IdLineaCarrera, opt => {
                     opt.MapFrom(d => d.IdLineaCarrera.ValidateLineaCarrera());
                 })
                .ForMember(dest => dest.IdNivel, opt => {
                     opt.MapFrom(d => d.IdNivel.ValidateNivel());
                 });
            CreateMap<Participante, ParticipanteVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                })
                .ForMember(dest => dest.LineaCarrera, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera.ConvertLineaCarreraToString().SeparateTextByUpperCase());
                })
                .ForMember(dest => dest.Nivel, opt => {
                    opt.MapFrom(d => d.IdNivel.ConvertNivelToString().SeparateTextByUpperCase());
                }); 
            CreateMap<Participante, SherpaLiteVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdParticipante);
                });
            CreateMap<Participante, EscaladorLiteVM>()
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
                    opt.MapFrom(d => d.Sede.SeparateTextByUpperCase());
                });

            CreateMap<Participante, EscaladorVM>()
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
                    opt.MapFrom(d => d.Sede.SeparateTextByUpperCase());
                });
            CreateMap<Participante, SherpaVM>()
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
                    opt.MapFrom(d => d.Sede.SeparateTextByUpperCase());
                });

            CreateMap<LineaCarrera, LineaCarreraVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdLineaCarrera);
                });
            CreateMap<Nivel, NivelVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdNivel);
                });
            CreateMap<Conocimiento, ConocimientoVM>()
                .ForMember(dest => dest.Id, opt => {
                    opt.MapFrom(d => d.IdConocimiento);
                });
        }
    }
}
