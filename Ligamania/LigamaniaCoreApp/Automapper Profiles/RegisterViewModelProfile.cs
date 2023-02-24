using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Models.AccountViewModels;
using LigamaniaCoreApp.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class RegisterViewModelProfile : Profile
    {
        public RegisterViewModelProfile()
        {
            CreateMap<ApplicationUser, RegisterViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Conocimiento, opt => opt.MapFrom(src => src.Conocimiento))
                .ForMember(dest => dest.Whatsapp, opt => opt.MapFrom(src => src.Whatsap))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.EsBot, opt => opt.MapFrom(src => src.IsBot))
                .ForMember(dest => dest.CategoriaPreferida, opt => opt.MapFrom(src => src.CompartirGrupo))
                .ForMember(dest => dest.UserState, opt => opt.MapFrom(src => src.UserState))
                .ForMember(dest => dest.EsEntrenador, opt => opt.MapFrom(src => src.IsEntrenador));
        }
    }
}
