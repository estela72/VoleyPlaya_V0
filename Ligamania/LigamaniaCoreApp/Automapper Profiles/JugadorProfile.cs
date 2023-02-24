using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class JugadorProfile : Profile
    {
        public JugadorProfile()
        {
            CreateMap<JugadorDTO, JugadorViewModel>()
               .ForMember(dest => dest.IdJugador, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => !src.Baja))
               ;
        }
    }
}
