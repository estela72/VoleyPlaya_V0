using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaCompeticionJornadaProfile : Profile
    {
        public TemporadaCompeticionJornadaProfile()
        {
            CreateMap<TemporadaCompeticionJornadaDTO, TemporadaCompeticionJornadaViewModel>()
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada.Nombre))
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                ;
        }
    }
}
