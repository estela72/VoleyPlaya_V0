using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class EquipoProfile:Profile
    {
        public EquipoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.Equipo, VoleyPlaya.Domain.Models.Equipo>()
                .ForMember(d => d.Posicion, o => o.MapFrom(ori => ori.OrdenCalendario))
                .ReverseMap();
        }
    }
}
