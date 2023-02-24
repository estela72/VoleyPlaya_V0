using AutoMapper;

using General.CrossCutting.Lib.Enums;

using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Models.Requests;
using Ligamania.Generic.Lib.Enums;
using Ligamania.Web.Models;
using Ligamania.Web.Models.Club;
using Ligamania.Web.Models.Competicion;
using Ligamania.Web.Models.Jugador;
using Ligamania.Web.Models.Temporada;

namespace Ligamania.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            
            CreateMap<Equipo, EquipoVM>()
                .ReverseMap()
                ;
            CreateMap<Entrenador, EntrenadorVM>()
                .ForMember(e=>e.Equipos, opt=>opt.MapFrom(src => src.Equipos))
                .ReverseMap()
                ;
            CreateMap<User, UserVM>()
                .ForMember(e => e.Estado, opt => opt.MapFrom(src => src.UserState))
                .ForMember(e => e.UserState, opt => opt.MapFrom((src, dest) =>
                {
                    switch (src.UserState)
                    {
                        case EstadoUsuario.Confirmed: return "Confirmado";
                        case EstadoUsuario.Registered: return "Registrado";
                        case EstadoUsuario.Removed: return "Baja";
                    }
                    return "Sin establecer";
                }))
                .ForMember(e => e.IsBot, opt => opt.MapFrom(src => src.IsBot ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.IsEntrenador, opt => opt.MapFrom(src => src.IsEntrenador ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.Whatsap, opt => opt.MapFrom(src => src.Whatsap ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ReverseMap()
                .ForMember(e => e.UserState, opt => opt.MapFrom((src, dest) =>
                {
                    switch (src.UserState)
                    {
                        case "Confirmado": return EstadoUsuario.Confirmed;
                        case "Registrado": return EstadoUsuario.Registered;
                        case "Baja": return EstadoUsuario.Removed;
                    }
                    return EstadoUsuario.SinDefinir;
                }))
                .ForMember(e => e.IsBot, opt => opt.MapFrom(src => src.IsBot.Equals(SiNo.SI.ToString()) ? true : false))
                .ForMember(e => e.IsEntrenador, opt => opt.MapFrom(src => src.IsEntrenador.Equals(SiNo.SI.ToString()) ? true : false))
                .ForMember(e => e.Whatsap, opt => opt.MapFrom(src => src.Whatsap.Equals(SiNo.SI.ToString()) ? true : false))
                ;

            CreateMap<UserVM, EditUserVM>()
                .ReverseMap()
                ;
            CreateMap<RegisterVM, RegisterRequest>()
                .ReverseMap()
                ;
            CreateMap<RoleVM, Role>()
                .ReverseMap()
                ;
            CreateMap<Competicion, CompeticionVM>()
                .ForMember(e => e.Competicion, opt=>opt.MapFrom(src => src.Nombre))
                .ForMember(e => e.AliInicial, opt => opt.MapFrom(src => src.CompeticionCopiarAliIni))
                .ForMember(e => e.CopiarAliIni, opt => opt.MapFrom(src => src.CopiarAlineacionInicial? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.RepetirClub, opt => opt.MapFrom(src => src.RepetirClubAliIni? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ForMember(e => e.Activa, opt => opt.MapFrom(src => src.Activa?SiNo.SI.ToString():SiNo.NO.ToString()))
                .ReverseMap()
                .ForMember(e => e.CopiarAlineacionInicial, opt => opt.MapFrom(src => src.CopiarAliIni.Equals(SiNo.SI.ToString())))
                .ForMember(e => e.RepetirClubAliIni, opt => opt.MapFrom(src => src.RepetirClub.Equals(SiNo.SI.ToString())))
                .ForMember(e => e.Activa, opt => opt.MapFrom(src => src.Activa.Equals(SiNo.SI.ToString())))
                ;

            CreateMap<Categoria, CategoriaVM>()
                .ForMember(c => c.Categoria, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(c => c.Activa, opt => opt.MapFrom(src => src.Activa ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(c => c.MarcarPichichi, opt => opt.MapFrom(src => src.MarcarPichichi ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ReverseMap()
                .ForMember(e => e.Activa, opt => opt.MapFrom(src => src.Activa.Equals(SiNo.SI.ToString())))
                .ForMember(e => e.MarcarPichichi, opt => opt.MapFrom(src => src.MarcarPichichi.Equals(SiNo.SI.ToString())))
                ;
            CreateMap<Club, ClubVM>()
                .ForMember(c => c.Club, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(c => c.Baja, opt => opt.MapFrom(src => src.Baja ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ReverseMap()
                .ForMember(c => c.Baja, opt => opt.MapFrom(src => src.Baja.Equals(SiNo.SI.ToString())))
                ;
            CreateMap<Jugador, JugadorVM>()
                .ForMember(c => c.Jugador, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(c => c.Baja, opt => opt.MapFrom(src => src.Baja ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(c => c.Activo, opt => opt.MapFrom(src => src.Activo ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(c => c.AliasClub, opt => opt.MapFrom(src => src.AliasClub))
                .ReverseMap()
                .ForMember(c => c.Baja, opt => opt.MapFrom(src => src.Baja.Equals(SiNo.SI.ToString())))
                .ForMember(c => c.Activo, opt => opt.MapFrom(src => src.Activo.Equals(SiNo.SI.ToString())))
                ;
            CreateMap<Calendario, CalendarioVM>()
                .ForMember(c => c.Calendario, opt =>opt.MapFrom(src => src.Nombre))
                .ForMember(a => a.Partidos, map => map.MapFrom(src => src.Partidos))
                .ReverseMap()
                ;
            CreateMap<CalendarioDetalle, CalendarioDetalleVM>()
                .ReverseMap()
                ;
            CreateMap<Documento, DocumentoVM>()
                .ForMember(c => c.Documento, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(c => c.Descripcion, opt => opt.MapFrom(src => src.Description))
                .ForMember(c => c.Contenido, opt => opt.MapFrom(src => src.Content))
                .ForMember(c => c.Tipo, opt => opt.MapFrom(src => src.ContentType))
                .ReverseMap()
                ;
            CreateMap<Parametro, ParametroVM>()
                .ForMember(e => e.VerEquiposPretemporadaPaginaPrincipal, opt => opt.MapFrom(src => src.VerEquiposPretemporadaPaginaPrincipal ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.VerAvisoClasificaciones, opt => opt.MapFrom(src => src.VerAvisoClasificaciones ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.VerCuadroCopa, opt => opt.MapFrom(src => src.VerCuadroCopa ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.VerNoticiasPaginaPrincipal, opt => opt.MapFrom(src => src.VerNoticiasPaginaPrincipal ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ForMember(e => e.VerRotuloCopa, opt => opt.MapFrom(src => src.VerRotuloCopa ? SiNo.SI.ToString() : SiNo.NO.ToString()))
                .ReverseMap()
                .ForMember(e => e.VerEquiposPretemporadaPaginaPrincipal, opt => opt.MapFrom(src => src.VerEquiposPretemporadaPaginaPrincipal.Equals(SiNo.SI.ToString())))
                .ForMember(e => e.VerAvisoClasificaciones, opt => opt.MapFrom(src => src.VerAvisoClasificaciones.Equals(SiNo.SI.ToString())))
                .ForMember(e => e.VerCuadroCopa, opt => opt.MapFrom(src => src.VerCuadroCopa.Equals(SiNo.SI.ToString())))
                .ForMember(e => e.VerNoticiasPaginaPrincipal, opt => opt.MapFrom(src => src.VerNoticiasPaginaPrincipal.Equals(SiNo.SI.ToString())))
                .ForMember(c => c.VerRotuloCopa, opt => opt.MapFrom(src => src.VerRotuloCopa.Equals(SiNo.SI.ToString())))
                ;
            CreateMap<Temporada, TemporadaVM>()
                .ForMember(e => e.Temporada, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(e => e.Actual, opt => opt.MapFrom(src => src.Actual ? SiNo.SI.ToString():SiNo.NO.ToString()))
                .ReverseMap()
                .ForMember(e => e.Actual, opt => opt.MapFrom(src => src.Actual.Equals(SiNo.SI.ToString())))
                ;
        }
    }
}