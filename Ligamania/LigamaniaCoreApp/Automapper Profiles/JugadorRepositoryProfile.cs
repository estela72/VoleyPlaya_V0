using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.HerramientasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Automapper_Profiles
{
    public class JugadorRepositoryProfile : Profile
    {
        public JugadorRepositoryProfile()
        {
            CreateMap<TemporadaJugadorDTO, JugadorRepositoryViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Jugador.Id))
                    .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador.Nombre))
                    .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => !src.Jugador.Baja))

                    .ForMember(dest => dest.IdTemporada, opt=>opt.MapFrom(src=>src.Id))
                    .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada.Nombre))
                    .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club.Nombre))
                    .ForMember(dest => dest.Puesto, opt => opt.MapFrom(src => src.Puesto.Nombre))
                    .ForMember(dest => dest.ActivoTemporada, opt => opt.MapFrom(src => src.Activo));
        }
    }
}
