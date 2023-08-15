using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Repository.Models;

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
                .ForMember(dest => dest.TipoCalendario, opt => opt.MapFrom(src => src.TipoCalendario))
                .ForPath(dest => dest.FechasJornadas, opt => opt.MapFrom(src => src.Jornadas))
                .ForPath(dest => dest.Grupos, opt => opt.MapFrom(src => src.Grupos))
                ;

            CreateMap<VoleyPlaya.Domain.Models.Edicion, VoleyPlaya.Repository.Models.Edicion>()
                .ForPath(dest => dest.Temporada.Nombre, opt => opt.MapFrom(src => src.Temporada))
                .ForPath(dest => dest.Competicion.Nombre, opt => opt.MapFrom(src => src.Competicion))
                .ForPath(dest => dest.Categoria.Nombre, opt => opt.MapFrom(src => src.CategoriaStr))
                .ForPath(dest => dest.Jornadas, opt => opt.MapFrom(src => src.FechasJornadas))
                .ForPath(dest => dest.Grupos, opt => opt.MapFrom(src => src.Grupos))
                ;

        }
    }
}
