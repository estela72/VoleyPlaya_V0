using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaProfile : Profile
    {
        public TemporadaProfile()
        {
            //Complex to Flattened
            CreateMap<TemporadaDTO, TemporadaViewModel>()
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.EstadoTemporada, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Competiciones, opt => opt.MapFrom(src => src.TemporadaCompeticion));
        }
    }
}
