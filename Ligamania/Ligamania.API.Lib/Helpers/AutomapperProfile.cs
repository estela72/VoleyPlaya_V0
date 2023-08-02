using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository;
using Ligamania.Repository.Models;

using Microsoft.AspNetCore.Identity;

namespace Ligamania.API.Lib.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<EquipoDTO, Equipo>()
                .ForMember(e => e.EntrenadorId, opt => opt.MapFrom(src => src.ApplicationUser != null ? src.ApplicationUser.Id : string.Empty))
                .ForMember(e => e.Estado, opt => opt.MapFrom(src => src.Baja ? EstadoEquipo.Baja : EstadoEquipo.Activo))
                .ForMember(e => e.Tipo, opt => opt.MapFrom(src => src.EsBot ? TipoEquipo.Bot : src.Nombre.ToLower().Contains("filial") ? TipoEquipo.Filial : TipoEquipo.Regular))
                .ForMember(e => e.Escudo, opt => opt.MapFrom(src => src.EscudoImage))
                .ReverseMap()
                ;
            CreateMap<User, Entrenador>()
                .ForMember(e => e.Estado, opt => opt.MapFrom(src => 
                    (src.UserState == EstadoUsuario.Removed || src.UserState==EstadoUsuario.SinDefinir) ? EstadoEntrenador.Baja : 
                        (src.UserState == EstadoUsuario.Confirmed) ? EstadoEntrenador.Activo : EstadoEntrenador.Pendiente))
                .ForMember(e => e.Tipo, opt => opt.MapFrom(src => src.IsBot ? TipoEntrenador.Bot : src.UserName.ToLower().Contains("filial") ? TipoEntrenador.Invitado : TipoEntrenador.Regular))
                .ReverseMap()
                ;
            CreateMap<LigamaniaApplicationUser, User>()
                .ReverseMap()
                ;
            CreateMap<LigamaniaApplicationUser, Entrenador>()
                .ForMember(e => e.Nombre, opt => opt.MapFrom(src => src.UserName))
                .ForMember(e => e.Estado, opt => opt.MapFrom(src =>
                    (src.UserState == EstadoUsuario.Removed || src.UserState == EstadoUsuario.SinDefinir) ? EstadoEntrenador.Baja :
                        (src.UserState == EstadoUsuario.Confirmed) ? EstadoEntrenador.Activo : EstadoEntrenador.Pendiente))
                .ForMember(e => e.Tipo, opt => opt.MapFrom(src => src.IsBot ? TipoEntrenador.Bot : src.UserName.ToLower().Contains("filial") ? TipoEntrenador.Invitado : TipoEntrenador.Regular))
               .ReverseMap()
                ;
            CreateMap<IdentityRole, Role>()
                .ReverseMap()
                ;
            CreateMap<CompeticionDTO, Competicion>()
                .ReverseMap()
                ;
            CreateMap<TemporadaCompeticionDTO, Competicion>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.CompeticionId))
                .ForMember(c=>c.Nombre, opt=>opt.MapFrom(src=>src.Competicion.Nombre))
                .ReverseMap()
                ;

            CreateMap<CategoriaDTO, Categoria>()
                .ReverseMap()
                ;
            CreateMap<TemporadaCompeticionCategoriaDTO, Categoria>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.CategoriaId))
                .ForMember(c => c.Nombre, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ReverseMap()
                ;
            CreateMap<ClubDTO, Club>()
                .ReverseMap()
                ;
            CreateMap<JugadorDTO, Jugador>()
                .ReverseMap()
                ;
            CreateMap<TemporadaJugadorDTO, Jugador>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Jugador.Id))
                .ForMember(c => c.Nombre, opt => opt.MapFrom(src => src.Jugador.Nombre))
                .ForMember(c => c.Baja, opt => opt.MapFrom(src => src.Jugador.Baja))
                .ForMember(c => c.Club, opt => opt.MapFrom(src => src.Club.Nombre))
                .ForMember(c => c.AliasClub, opt => opt.MapFrom(src => src.Club.Alias))
                .ForMember(c => c.Puesto, opt => opt.MapFrom(src => src.Puesto.Nombre))
                .ForMember(c => c.OrdenPuesto, opt => opt.MapFrom(src => src.Puesto.Orden))
                .ReverseMap()
                ;

            CreateMap<CalendarioDTO, Calendario>()
                .ForMember(a => a.Partidos, map => map.MapFrom(src => src.CalendarioDetalle))
                .ReverseMap()
                ;
            CreateMap<CalendarioDetalleDTO, CalendarioDetalle>()
                .ReverseMap()
                ;
            CreateMap<DocumentsDTO, Documento>()
                 .ReverseMap()
                 ;
            CreateMap<SettingsDTO, Parametro>()
                .ForMember(a => a.VerCuadroCopa, map=>map.MapFrom(src => src.VerCuadroCopa))
                .ForMember(a => a.VerAvisoClasificaciones, map=>map.MapFrom(src=> true)) //map=>map.MapFrom(src => src.VerAvisoClasificaciones))
                .ForMember(a => a.VerEquiposPretemporadaPaginaPrincipal, map => map.MapFrom(src => false)) //map=>map.MapFrom(src => src.VerEquiposPretemporadaPaginaPrincipal))
                .ForMember(a => a.VerNoticiasPaginaPrincipal , map => map.MapFrom(src => true))
                .ForMember(a => a.VerRotuloCopa, map => map.MapFrom(src => true))
                .ForMember(a => a.AvisoClasificaciones, map => map.MapFrom(src => src.NotificacionClasificaciones))
                .ForMember(a => a.NumJorVueltaJugadorEliminado, map=>map.MapFrom(src => src.NumeroJornadasVolverEliminados))
                .ForMember(a => a.RotuloCopa, map => map.MapFrom(src => src.TemporadaPremios))
                .ReverseMap()
                ;

            CreateMap<TemporadaDTO, Temporada>()
                .ForMember(a => a.Clasificacion, map => map.MapFrom(src => src.Img_Clasificacion))
                .ReverseMap()
                ;
            CreateMap<TemporadaContabilidadDTO, ContabilidadDto>()
                .ForMember(a => a.PorEquipo, map => map.MapFrom(src => src.Equipo))
                .ForMember(a => a.Temporada, map => map.MapFrom(src => src.Temporada.Nombre))
                .ReverseMap()
                .ForMember(a => a.Equipo, map => map.MapFrom(src => src.PorEquipo))
                .ForMember(a => a.Gasto, map => map.MapFrom(src => src.Gasto))
                ;
            CreateMap<TemporadaPremiosPuestoDTO, PremioDto>()
                .ForMember(p => p.Categoria, map => map.MapFrom(src => src.PremioCategoria.Categoria.Categoria.Nombre))
                .ForMember(p => p.Competicion, map => map.MapFrom(src => src.PremioCategoria.Categoria.Competicion.Nombre))
                .ForMember(p => p.Porcentaje, map => map.MapFrom(src => src.Porcentaje))
                .ForMember(p => p.Puesto, map => map.MapFrom(src => src.Puesto))
                .ForMember(p => p.Premio, map => map.MapFrom(src => src.Importe))
                .ReverseMap()
                ;
        }
    }
}