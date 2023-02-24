using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaCompeticionProfile : Profile
    {
        public TemporadaCompeticionProfile()
        {
            CreateMap<TemporadaCompeticionDTO, TemporadaCompeticionViewModel>()
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                .ForMember(dest => dest.IdCompeticion, opt => opt.MapFrom(src => src.Competicion.Id))
                .ForMember(dest => dest.OrdenCompeticion, opt => opt.MapFrom(src => src.Competicion.Orden))
                .ForMember(dest => dest.CambiosFijos, opt => opt.MapFrom(src => src.CambiosFijos))
                .ForMember(dest => dest.EstadoCompeticion, opt => opt.MapFrom(src => src.GetEstadoOperacion()))
                .ForMember(dest => dest.TipoCompeticion,
                    opt => opt.MapFrom(src => 
                        src.Competicion.Tipo == 0 ? eTipoCompeticion.Liga : 
                        src.Competicion.Tipo == 1 ? eTipoCompeticion.Copa : 
                                                    eTipoCompeticion.Supercopa));
        }
    }
}
