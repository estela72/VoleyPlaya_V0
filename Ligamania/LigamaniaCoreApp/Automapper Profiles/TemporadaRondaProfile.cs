using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class TemporadaRondaProfile : Profile
    {
        public TemporadaRondaProfile()
        {
            //Complex to Flattened
            CreateMap<TemporadaRondaDTO, TemporadaRondaViewModel>()
                .ForMember(dest => dest.Ronda, opt => opt.MapFrom(src => src.NumRonda))
                .ForMember(dest => dest.Final, opt => opt.MapFrom(src => src.RondaFinal))
                .ForMember(dest => dest.JornadaIda, opt => opt.MapFrom(src => src.JornadaIda.NumeroJornada))
                .ForMember(dest => dest.JornadaVuelta, opt => opt.MapFrom(src => src.JornadaVuelta.NumeroJornada));
        }
    }
}
