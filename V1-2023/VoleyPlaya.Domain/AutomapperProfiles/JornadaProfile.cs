using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class JornadaProfile : Profile
    {
        public JornadaProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.Jornada, VoleyPlaya.Domain.Models.FechaJornada>()
                .ForMember(dest => dest.Jornada, opt => opt.MapFrom(src => src.Numero))
                .ReverseMap();
        }
    }
}
