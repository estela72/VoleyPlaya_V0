using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class HistoricoProfile : Profile
    {
        public HistoricoProfile()
        {
            //Complex to Flattened
            CreateMap<HistoricoDTO, HistorialViewModel>()
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada.Nombre));
        }
    }
    public class TemporadaCompeticionCategoriaHistoricaProfile : Profile
    {
        public TemporadaCompeticionCategoriaHistoricaProfile()
        {
            CreateMap<TemporadaCompeticionCategoriaDTO, CategoriaHistoricaViewModel>()
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre));
        }
    }
}
