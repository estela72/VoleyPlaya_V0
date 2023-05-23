using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class EdicionProfile : Profile
    {
        public EdicionProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.Edicion, VoleyPlaya.Domain.Models.Edicion>()
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada.Nombre))
                .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ForMember(dest => dest.CategoriaStr, opt => opt.MapFrom(src => src.Categoria.Nombre))
                //.ForMember(dest => dest.NumEquipos, opt => opt.MapFrom(src => src.Equipos.Count))
                //.ForMember(dest => dest.NumJornadas, opt => opt.MapFrom(src => src.Jornadas.Count))
                .ForMember(dest => dest.TipoCalendario, opt=>opt.MapFrom(src => src.TipoCalendario))
                .ForPath(dest => dest.FechasJornadas, opt=>opt.MapFrom(src => src.Jornadas))
                .ReverseMap();
        }
    }
}
