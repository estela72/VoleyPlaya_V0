﻿using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class AlineacionProfile : Profile
    {
        public AlineacionProfile()
        {
            CreateMap<AlineacionDTO, AlineacionViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Jugador.Id))
                .ForMember(dest => dest.Jugador, opt => opt.MapFrom(src => src.Jugador.Nombre))
                .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club.Nombre))
                .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Club.Alias))
                .ForMember(dest => dest.Puesto, opt => opt.MapFrom(src => src.Puesto.Nombre))
                .ForMember(dest => dest.OrdenPuesto, opt => opt.MapFrom(src => src.Puesto.Orden))
                .ForMember(dest => dest.PendienteBaja, opt => opt.MapFrom(src => src.Jugador.PendienteBaja))
                ;
        }
    }
}
