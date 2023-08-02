using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Competicion, CompeticionDto>();
            //    .ForMember(c => c.Name, map => map.MapFrom(cat => cat.Nombre))
            //    .ReverseMap();
            //CreateMap<Equipo, EquipoDto>()
            //    .ForMember(c => c.Name, map => map.MapFrom(cat => cat.Nombre))
            //    .ReverseMap();
            //CreateMap<Tabla, TablaDto>()
            //    .ForMember(c => c.Name, map => map.MapFrom(cat => cat.Nombre))
            //    .ReverseMap();
            //CreateMap<Temporada, TemporadaDto>()
            //    .ForMember(c => c.Name, map => map.MapFrom(cat => cat.Nombre))
            //    .ReverseMap();
        }
    }
}
