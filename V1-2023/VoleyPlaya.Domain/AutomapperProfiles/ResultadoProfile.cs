﻿using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.ParcialPartido, VoleyPlaya.Domain.Models.ResultadoParcial>()
                .ForMember(d=>d.Local, o => o.MapFrom(ori => ori.ResultadoLocal))
                .ForMember(d => d.Visitante, o => o.MapFrom(ori => ori.ResultadoVisitante))
                .ReverseMap();

            CreateMap<VoleyPlaya.Repository.Models.ParcialPartidoVis, VoleyPlaya.Domain.Models.ResultadoParcial>()
                .ForMember(d => d.Local, o => o.MapFrom(ori => ori.ResultadoLocal))
                .ForMember(d => d.Visitante, o => o.MapFrom(ori => ori.ResultadoVisitante))
                .ReverseMap();

        }
    }
}
