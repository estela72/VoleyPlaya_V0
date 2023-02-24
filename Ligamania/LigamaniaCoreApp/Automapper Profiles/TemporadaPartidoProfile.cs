using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaPartidoProfile : Profile
    {
        public TemporadaPartidoProfile()
        {
            CreateMap<TemporadaPartidoDTO, TemporadaPartidoViewModel>()
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada.Nombre))
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ForMember(dest => dest.Jornada, opt => opt.MapFrom(src => src.Jornada.NumeroJornada))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Jornada.Fecha))
                .ForMember(dest => dest.EquipoA, opt => opt.MapFrom(src => src.EquipoA.Nombre))
                .ForMember(dest => dest.EquipoB, opt => opt.MapFrom(src => src.EquipoB.Nombre))
                .ForMember(dest => dest.ResultadoA, opt => opt.MapFrom(src => src.ResultadoA))
                .ForMember(dest => dest.ResultadoB, opt => opt.MapFrom(src => src.ResultadoB))
                .ForMember(dest => dest.EquipoGanador, opt => opt.MapFrom(src => src.EquipoGanador.Nombre))
                .ForMember(dest => dest.JornadaId, opt => opt.MapFrom(src => src.Jornada.Id))
                ;
        }
    }
}
