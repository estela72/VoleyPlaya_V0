using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Categoria, CategoriaDto>();
        CreateMap<Competicion, CompeticionDto>();
        CreateMap<Equipo, EquipoDto>();
        CreateMap<Tabla, TablaDto>();
        CreateMap<Temporada, TemporadaDto>();
    }
}
