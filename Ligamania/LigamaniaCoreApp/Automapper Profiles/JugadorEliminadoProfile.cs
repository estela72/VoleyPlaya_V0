using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.GlobalViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class JugadorEliminadoProfile : Profile
    {
        public JugadorEliminadoProfile()
        {
            //Complex to Flattened
            CreateMap<TemporadaJugadorDTO, JugadorEliminadoViewModel>()
                .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador.Nombre))
                .ForMember(dest => dest.JornadaEliminado, opt => opt.MapFrom(src => src.LastJornadaEliminacion.NumeroJornada));

            CreateMap<TemporadaJugadorDTO, JugadorBajaViewModel>()
                .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador.Nombre))
                .ForMember(dest => dest.PendienteBaja, opt => opt.MapFrom(src => src.Jugador.PendienteBaja));

        }
    }
}
