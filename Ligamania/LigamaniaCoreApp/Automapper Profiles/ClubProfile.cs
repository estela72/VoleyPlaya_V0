using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<ClubDTO, ClubViewModel>()
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => !src.Baja))
                .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Alias))
                .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<ClubViewModel, ClubExcelDto>()
                .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club))
                ;
        }
    }
}
