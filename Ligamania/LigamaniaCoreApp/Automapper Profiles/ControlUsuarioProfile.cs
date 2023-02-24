using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class ControlUsuarioProfile : Profile
    {
        public ControlUsuarioProfile()
        {
            CreateMap<ControlUsuarioDTO, AccionUsuarioViewModel>()
                //.ForMember(dest => dest.Fecha, opt => LigamaniaUtils.GetCurrentTime(opt.MapFrom(src => src.Fecha)))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.Equipo, opt => opt.MapFrom(src => src.Equipo))
                .ForMember(dest => dest.Entrenador, opt => opt.MapFrom(src => src.Usuario));
        }
    }
}
