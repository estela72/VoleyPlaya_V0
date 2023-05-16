using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class EdicionGrupoProfile : Profile
    {
        public EdicionGrupoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.EdicionGrupo, VoleyPlaya.Domain.Models.EdicionGrupo>()
                .ReverseMap();
        }
    }
}
