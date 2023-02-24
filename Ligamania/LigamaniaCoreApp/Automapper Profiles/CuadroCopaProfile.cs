using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class CuadroCopaProfile : Profile
    {
        public CuadroCopaProfile()
        {
            CreateMap<CuadroCopaDTO, CuadroViewModel>()
                .ForMember(dest => dest.CategoriaEquipoA, opt => opt.MapFrom(src => src.CompeticionCategoriaEquipoA.Categoria.Nombre))
                .ForMember(dest => dest.CompeticionEquipoA, opt => opt.MapFrom(src => src.CompeticionCategoriaEquipoA.Competicion.Nombre))
                .ForMember(dest => dest.EquipoAPuesto, opt => opt.MapFrom(src => src.PuestoPartidoEquipoA))
                .ForMember(dest => dest.CategoriaEquipoB, opt => opt.MapFrom(src => src.CompeticionCategoriaEquipoB.Categoria.Nombre))
                .ForMember(dest => dest.CompeticionEquipoB, opt => opt.MapFrom(src => src.CompeticionCategoriaEquipoB.Competicion.Nombre))
                .ForMember(dest => dest.EquipoBPuesto, opt => opt.MapFrom(src => src.PuestoPartidoEquipoB));
        }
        
    }
    public class TemporadaCuadroCopaProfile:Profile
    {
        public TemporadaCuadroCopaProfile()
        {
            CreateMap<TemporadaCuadroDTO, TemporadaCuadroViewModel>()
                .ForMember(dest => dest.CategoriaEquipoA, opt => opt.MapFrom(src => src.EquipoACategoria.Categoria.Nombre))
                .ForMember(dest => dest.CompeticionEquipoA, opt => opt.MapFrom(src => src.EquipoACompeticion.Competicion.Nombre))
                .ForMember(dest => dest.NombreEquipoA, opt => opt.MapFrom(src => src.NombreEquipoA))
                .ForMember(dest => dest.EquipoAPuesto, opt => opt.MapFrom(src => src.EquipoAPuesto))
                .ForMember(dest => dest.CategoriaEquipoB, opt => opt.MapFrom(src => src.EquipoBCategoria.Categoria.Nombre))
                .ForMember(dest => dest.CompeticionEquipoB, opt => opt.MapFrom(src => src.EquipoBCompeticion.Competicion.Nombre))
                .ForMember(dest => dest.EquipoBPuesto, opt => opt.MapFrom(src => src.EquipoBPuesto))
                .ForMember(dest => dest.NombreEquipoB, opt => opt.MapFrom(src => src.NombreEquipoB))
                .ForMember(dest => dest.NumPartido, opt => opt.MapFrom(src => src.NumeroPartido));
        }
    }
}
