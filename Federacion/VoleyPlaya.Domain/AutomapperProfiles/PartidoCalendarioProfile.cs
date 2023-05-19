using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class PartidoCalendarioProfile : Profile
    {
        public PartidoCalendarioProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.TablaCalendario, VoleyPlaya.Domain.Models.PartidoCalendarioCircuito>()
                .ReverseMap();
        }
    }
}
