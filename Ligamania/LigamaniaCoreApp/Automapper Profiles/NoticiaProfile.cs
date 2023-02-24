using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.GlobalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class NoticiaProfile : Profile
    {
        public NoticiaProfile()
        {
            //Complex to Flattened
            CreateMap<NoticiaDTO, NoticiaViewModel>()
                .ForMember(dest => dest.Noticia, opt => opt.MapFrom(src => src.Texto))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha/*.ToLocalTime()*/));
        }
    }
}
