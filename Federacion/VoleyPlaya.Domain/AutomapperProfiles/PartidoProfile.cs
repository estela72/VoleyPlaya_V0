using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class PartidoProfile : Profile
    {
        public PartidoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.Partido, VoleyPlaya.Domain.Models.Partido>()
                .ForMember(d => d.Local, o => o.MapFrom(ori => ori.Local.Nombre))
                .ForMember(d => d.Visitante, o => o.MapFrom(ori => ori.Visitante.Nombre))
                .ForMember(d => d.RetiradoLocal, o=>o.MapFrom(ori => ori.Local.Retirado))
                .ForMember(d => d.RetiradoVisitante, o => o.MapFrom(ori => ori.Visitante.Retirado))
                .ReverseMap();
        }
    }
}
