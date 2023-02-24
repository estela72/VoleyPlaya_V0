using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class AlineacionHistoricoProfile : Profile
    {
        public AlineacionHistoricoProfile()
        {
            CreateMap<AlineacionDTO, AlineacionHistoricoDTO>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club))
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion))
                .ForMember(dest => dest.Equipo, opt => opt.MapFrom(src => src.Equipo));
        }
    }
}
