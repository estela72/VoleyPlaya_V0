using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Models;

namespace VoleyPlaya.Domain.AutomapperProfiles
{
    public class PartidoProfile : Profile
    {
        public PartidoProfile()
        {
            CreateMap<VoleyPlaya.Repository.Models.Partido, VoleyPlaya.Domain.Models.Partido>()
                .ForMember(d => d.Local, o => o.MapFrom(ori => ori.Local==null?"":ori.Local.Nombre ))
                .ForMember(d => d.Visitante, o => o.MapFrom(ori => ori.Visitante==null?"":ori.Visitante.Nombre))
                .ForMember(d => d.RetiradoLocal, o=>o.MapFrom(ori => ori.Local==null?false:ori.Local.Retirado))
                .ForMember(d => d.RetiradoVisitante, o => o.MapFrom(ori => ori.Visitante == null ? false : ori.Visitante.Retirado))
                .ForPath(d => d.Resultado.Set1, o=>o.MapFrom(ori=>ori.Parciales==null ? null:ori.Parciales.FirstOrDefault()))
                .ForPath(d => d.Resultado.Set2, o => o.MapFrom(ori => ori.Parciales==null?null:ori.Parciales.Skip(1).First()))
                .ForPath(d => d.Resultado.Set3, o => o.MapFrom(ori => ori.Parciales==null?null:ori.Parciales.Last()))
                .ForMember(d => d.Competicion, o=>o.MapFrom(ori=>ori.Grupo==null?null:ori.Grupo.Edicion.Competicion.Nombre))
                .ForMember(d => d.Categoria, o => o.MapFrom(ori => ori.Grupo==null?null:ori.Grupo.Edicion.Categoria.Nombre))
                .ForMember(d => d.Genero, o => o.MapFrom(ori => ori.Grupo==null?"":ori.Grupo.Edicion.Genero))
                .ForMember(d => d.Grupo, o => o.MapFrom(ori => ori.Grupo==null?"":ori.Grupo.Nombre))
                .ForMember(d => d.Prueba, o => o.MapFrom(ori => ori.Grupo==null?"" : ori.Grupo.Edicion.Prueba))
                .ForMember(d => d.NombreLocal, o=>o.MapFrom(ori => ori.NombreLocal))
                .ForMember(d => d.NombreVisitante, o => o.MapFrom(ori => ori.NombreVisitante))
                .ForMember(d => d.EquipoLocalId, o => o.MapFrom(ori => ori.Local.Id))
                .ForMember(d => d.EquipoVisitanteId, o => o.MapFrom(ori => ori.Visitante.Id))
                //.ForPath(d=>d.Grupo, o=>o.MapFrom(ori=>ori.Grupo))
                .ReverseMap()
                ;

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

            //CreateMap<VoleyPlaya.Domain.Models.Partido, VoleyPlaya.Repository.Models.Partido>()
            //    .ForPath(d => d.Grupo?.Nombre, s => s.MapFrom(s => s.Grupo))
            //    .ForPath(d => d.Parciales, s => s.MapFrom(s => s.Resultado.Sets))
            //    .ForMember(d => d.RetiradoLocal, s => s.MapFrom(s => s.RetiradoLocal))
            //    .ForMember(d => d.RetiradoVisitante, s => s.MapFrom(s => s.RetiradoVisitante))
            //    .ForPath(d => d.Local?.Id, s => s.MapFrom(s => s.EquipoLocalId))
            //    .ForPath(d => d.Local?.Nombre, s => s.MapFrom(s => s.Local))
            //    .ForPath(d => d.Visitante?.Id, s => s.MapFrom(s => s.EquipoVisitanteId))
            //    .ForPath(d => d.Visitante?.Nombre, s => s.MapFrom(s => s.Visitante))
            //    .ForMember(d=>d.NombreLocal, s=>s.MapFrom(s=>s.NombreLocal))
            //    .ForMember(d=>d.NombreVisitante, s=>s.MapFrom(s=>s.NombreVisitante))
            //    ;
            CreateMap<VoleyPlaya.Domain.Models.Partido, VoleyPlaya.Repository.Models.Partido>()
             .ForMember(d => d.Parciales, s => s.MapFrom(s => s.Resultado.Sets))
             .ForMember(d => d.RetiradoLocal, s => s.MapFrom(s => s.RetiradoLocal))
             .ForMember(d => d.RetiradoVisitante, s => s.MapFrom(s => s.RetiradoVisitante))
             .ForMember(d => d.NombreLocal, s => s.MapFrom(s => s.NombreLocal))
             .ForMember(d => d.NombreVisitante, s => s.MapFrom(s => s.NombreVisitante))
             .ForPath(d => d.Grupo.Nombre, s => s.MapFrom(s => s.Grupo))
             .ForPath(d => d.Local.Nombre, s => s.MapFrom(s => s.Local))
             .ForPath(d => d.Visitante.Nombre, s => s.MapFrom(s => s.Visitante))
             .ForPath(d => d.Local.Id, s => s.MapFrom(s => s.EquipoLocalId))
             .ForPath(d => d.Visitante.Id, s => s.MapFrom(s => s.EquipoVisitanteId))

             ;

            //CreateMap<VoleyPlaya.Domain.Models.Partido, VoleyPlaya.Repository.Models.Equipo>()
            //    .ConvertUsing((s, d, c) =>
            //    {
            //        var equipoId = c.Mapper.Map<int?>(s.EquipoLocalId);
            //        var equipoNombre = c.Mapper.Map<string>(s.Local);
            //        if (equipoId != null && equipoNombre != null)
            //        {
            //            return new Equipo { Id = equipoId, Nombre = equipoNombre };
            //        }
            //        return null;
            //    });

            //CreateMap<VoleyPlaya.Domain.Models.Partido, VoleyPlaya.Repository.Models.Equipo>()
            //    .ConvertUsing((s, d, c) =>
            //    {
            //        var equipoId = c.Mapper.Map<int?>(s.EquipoVisitanteId);
            //        var equipoNombre = c.Mapper.Map<string>(s.Visitante);
            //        if (equipoId != null && equipoNombre != null)
            //        {
            //            return new Equipo { Id = equipoId, Nombre = equipoNombre };
            //        }
            //        return null;
            //    });

        }
    }
}
