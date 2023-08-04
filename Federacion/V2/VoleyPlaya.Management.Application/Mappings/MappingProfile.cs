using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Edicion, EdicionDto>();
            CreateMap<EdicionGrupo, EdicionGrupoDto>();
            CreateMap<Jornada, JornadaDto>();
            CreateMap<Parcial, ParcialDto>();
            CreateMap<Partido, PartidoDto>();
        }
    }
}
