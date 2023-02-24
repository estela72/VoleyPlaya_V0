using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaEquipoProfile : Profile
    {
        public TemporadaEquipoProfile()
        {
            CreateMap<TemporadaEquipoDTO, TemporadaEquipoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                .ForMember(dest => dest.CompeticionId, opt => opt.MapFrom(src => src.Competicion.Id))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ForMember(dest => dest.Confirmada, opt => opt.MapFrom(src => src.ConfirmadaTemporada))
                .ForMember(dest => dest.Pagada, opt => opt.MapFrom(src => src.PagadaTemporada))
                .ForMember(dest => dest.Equipo, opt => opt.MapFrom(src => src.Equipo.Nombre))
                .ForMember(dest => dest.EquipoId, opt => opt.MapFrom(src => src.Equipo.Id))
                .ForMember(dest => dest.OrdenCompeticion, opt => opt.MapFrom(src => src.Competicion.Orden))
                .ForMember(dest => dest.OrdenCategoria, opt => opt.MapFrom(src => src.Categoria.Orden))
                ;
        }
    }
}
