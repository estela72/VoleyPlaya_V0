using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class CompeticionCategoriaProfile : Profile
    {
        public CompeticionCategoriaProfile()
        {
            CreateMap<CompeticionCategoriaDTO, CompeticionCategoriaViewModel>()
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                .ForMember(dest => dest.IdCompeticion, opt => opt.MapFrom(src => src.Competicion_Id))
                .ForMember(dest => dest.OrdenCompeticion, opt => opt.MapFrom(src => src.Competicion.Orden))
                .ForMember(dest => dest.CompeticionCopiarAliIni, opt => opt.MapFrom(src => src.Competicion.CompeticionCopiarAliIni))
                .ForMember(dest => dest.CopiarAlineacionInicial, opt => opt.MapFrom(src => src.Competicion.CopiarAlineacionInicial))
                .ForMember(dest => dest.JornadaCuadro, opt => opt.MapFrom(src => src.Competicion.JornadaCuadro))
                .ForMember(dest => dest.RepetirClubAliIni, opt => opt.MapFrom(src => src.Competicion.RepetirClubAliIni))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Competicion.Tipo))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ForMember(dest => dest.IdCategoria, opt => opt.MapFrom(src => src.Categoria_Id))
                .ForMember(dest => dest.OrdenCategoria, opt => opt.MapFrom(src => src.Categoria.Orden));
        }
    }
}
