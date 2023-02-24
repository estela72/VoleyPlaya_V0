using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.GlobalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            //Complex to Flattened
            CreateMap<SettingsDTO, SettingsViewModel>()
                .ForMember(dest => dest.VerCuadroCopa, opt => opt.MapFrom(src => src.VerCuadroCopa))
                .ForMember(dest => dest.VerEquiposPretemporada, opt => opt.MapFrom(src => src.VerEquiposPretemporada))
                .ForMember(dest => dest.VerNoticias, opt => opt.MapFrom(src => src.VerNoticias))
                .ForMember(dest => dest.VerRotuloCopa, opt => opt.MapFrom(src => src.VerCuadroCopa))
                .ForMember(dest => dest.NotificacionClasificaciones, opt => opt.MapFrom(src => src.NotificacionClasificaciones));

        }
    }
}
