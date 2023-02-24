using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaJugadorProfile : Profile
    {
        public TemporadaJugadorProfile()
        {
            CreateMap<TemporadaJugadorDTO, TemporadaJugadorViewModel>()
               .ForMember(dest => dest.IdTemporadaJugador, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.IdJugador, opt => opt.MapFrom(src => src.Jugador_ID))
               .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador.Nombre))
               .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club.Nombre))
               .ForMember(dest => dest.ClubActivo, opt => opt.MapFrom(src => !src.Club.Baja))
               .ForMember(dest => dest.Puesto, opt => opt.MapFrom(src => src.Puesto.Nombre))
               .ForMember(dest => dest.Temporada, opt=>opt.MapFrom(src => src.Temporada.Nombre))
               .ForMember(dest => dest.Baja, opt=>opt.MapFrom(src=>src.Jugador.Baja))
               .ForMember(dest => dest.OrdenPuesto, opt => opt.MapFrom(src => src.Puesto.Orden))
               ;
            CreateMap<TemporadaJugadorViewModel, JugadorActivoExcelDto>()
                .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador))
                //.ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club))
                .ForMember(dest => dest.Puesto, opt => opt.MapFrom(src => src.Puesto))
                //.ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada))
                //.ForMember(dest => dest.Baja, opt => opt.MapFrom(src => src.Baja ? "SI" : "NO"))
                //.ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo ? "SI" : "NO"))
                ;
            CreateMap<TemporadaJugadorViewModel, JugadorBajaExcelDto>()
                .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador))
                ;
        }
    }
}
