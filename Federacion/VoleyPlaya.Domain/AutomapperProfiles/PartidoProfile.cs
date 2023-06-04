using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class PartidoProfile : Profile
    {
        public PartidoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.Partido, VoleyPlaya.Domain.Models.Partido>()
                .ForMember(d => d.Local, o => o.MapFrom(ori => ori.Local.Nombre))
                .ForMember(d => d.Visitante, o => o.MapFrom(ori => ori.Visitante.Nombre))
                .ForMember(d => d.RetiradoLocal, o=>o.MapFrom(ori => ori.Local.Retirado))
                .ForMember(d => d.RetiradoVisitante, o => o.MapFrom(ori => ori.Visitante.Retirado))
                .ForPath(d => d.Resultado.Set1, o=>o.MapFrom(ori=>ori.Parciales.First()))
                .ForPath(d => d.Resultado.Set2, o => o.MapFrom(ori => ori.Parciales.Skip(1).First()))
                .ForPath(d => d.Resultado.Set3, o => o.MapFrom(ori => ori.Parciales.Last()))
                .ForMember(d => d.Competicion, o=>o.MapFrom(ori=>ori.Grupo.Edicion.Competicion.Nombre))
                .ForMember(d => d.Categoria, o => o.MapFrom(ori => ori.Grupo.Edicion.Categoria.Nombre))
                .ForMember(d => d.Genero, o => o.MapFrom(ori => ori.Grupo.Edicion.Genero))
                .ForMember(d => d.Grupo, o => o.MapFrom(ori => ori.Grupo.Nombre))
                .ForMember(d => d.Prueba, o => o.MapFrom(ori => ori.Grupo.Edicion.Prueba))
                .ForMember(d => d.NombreLocal, o=>o.MapFrom(ori => ori.NombreLocal))
                .ForMember(d => d.NombreVisitante, o => o.MapFrom(ori => ori.NombreVisitante))
                .ReverseMap();

            CreateMap<VoleyPlaya.Repository.Models.PartidoVis, VoleyPlaya.Domain.Models.Partido>()
                .ForMember(d => d.Local, o => o.MapFrom(ori => ori.Local))
                .ForMember(d => d.Visitante, o => o.MapFrom(ori => ori.Visitante))
                .ForMember(d => d.RetiradoLocal, o => o.MapFrom(ori => ori.RetiradoLocal))
                .ForMember(d => d.RetiradoVisitante, o => o.MapFrom(ori => ori.RetiradoVisitante))
                .ForMember(d => d.NombreLocal, o => o.MapFrom(ori => ori.NombreLocal))
                .ForMember(d => d.NombreVisitante, o => o.MapFrom(ori => ori.NombreVisitante))
                .ForPath(d => d.Resultado.Set1, o => o.MapFrom(ori => ori.Parciales.First()))
                .ForPath(d => d.Resultado.Set2, o => o.MapFrom(ori => ori.Parciales.Skip(1).First()))
                .ForPath(d => d.Resultado.Set3, o => o.MapFrom(ori => ori.Parciales.Last()))
                .ReverseMap();

        }
    }
}
