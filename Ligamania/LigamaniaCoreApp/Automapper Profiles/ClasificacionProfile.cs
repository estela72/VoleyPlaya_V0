using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.GlobalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class EquipoClasificacionProfile : Profile
    {
        public EquipoClasificacionProfile()
        {
            //Complex to Flattened
            CreateMap<TemporadaClasificacionDTO, EquipoClasificacionViewModel>()
                .ForMember(dest => dest.Equipo, opt => opt.MapFrom(src => src.Equipo.Nombre));
        }
    }
    public class ReferenciaPremioProfile : Profile
    {
        public ReferenciaPremioProfile()
        {
            CreateMap<TemporadaCompeticionCategoriaReferenciaDTO, ReferenciaPremioViewModel>()
                //.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                //.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Simbolo, opt => opt.MapFrom(src => src.Marca));
        }
    }
}
