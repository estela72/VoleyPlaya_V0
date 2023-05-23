using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Models;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class EdicionGrupoProfile : Profile
    {
        public EdicionGrupoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.EdicionGrupo, VoleyPlaya.Domain.Models.EdicionGrupo>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Nombre))
                .ForMember(d => d.TipoGrupo, opt => opt.MapFrom(s => s.Tipo))
                .ReverseMap();
        }
    }
}
