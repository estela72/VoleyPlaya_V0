using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public interface ILigamaniaService
    {
        Task<IDictionary<string, string>> GetEstadoCompeticiones();
        Task<string> GetLastNew();
        Task<ICollection<JugadorEliminadoViewModel>> GetJugadoresEliminados();
        Task<ICollection<JugadorEliminadoViewModel>> GetJugadoresPreEliminados();
        Task<List<TemporadaJornadaJugadorViewModel>> GetJugadoresPorCategoria();

        //Task<ICollection<JugadorEliminadoViewModel>> GetJugadoresEliminadosJornada();
        Task<IQueryable<JugadorEliminadoViewModel>> GetJugadoresEliminadosQueryable();

        Task<ICollection<ClasificacionViewModel>> GetClasificaciones();
        Task<ICollection<ClasificacionViewModel>> GetClasificacionesTemporada(string nombreTemporada = "");
        Task<ICollection<ClasificacionViewModel>> GetClasificacionLigaParaCopa(string nombreTemporada = "");

        Task<ICollection<NoticiaViewModel>> GetAllNews();
        IQueryable<byte[]> GetImgClasificacionTemporada(string temporada);
        Task<SettingsViewModel> GetSettings();
        Task<Response> EstablecerConfiguracion(SettingsViewModel settings);
        Task<int> GetJornadaCarrusel();
        Task<int> GetJornadaActual();
        Task<int> GetJornadaCarrusel(string competicion);
        Task<int> GetJornadaActual(string competicion);

        Task<SelectList> GetAllCategorias(string competicion);
        Task<SelectList> GetAllTemporadas();
        Task<List<ReglamentoViewModel>> GetAllDocumentos();
        Task<SelectList>GetAllClubs(bool activo);
        Task<SelectList> GetAllClubs(bool activo, string selectedClub);
        Task<SelectList> GetAllPuestos();
        Task<SelectList> GetAllCompeticiones();
        Task<SelectList> GetCompeticionesActivas();
        Task<List<string>> GetCompeticionesActivasStr();
        Task<SelectList> GetEquiposTemporadaActual(string competicion);
        Task<SelectList> GetEquiposTemporadaActual(string competcion, string categoria);
        Task<SelectList> GetEquiposSinCategoria(string competicion);
        Task<SelectList> GetCalendarios();
        Task<SelectList> GetAllJornadasLiga();
        Task<SelectList> GetAllJornadasPasadas(string competicion);
        Task<SelectList> GetJugadoresPorPuestoTemporada(string puesto);
        Task<Tuple<string, string>> GetCompeticionLigaUsuario(string user);
        Task<ICollection<ClasificacionViewModel>> GetClasificacionesVuelta2();
        Task<TemporadaCompeticionDTO> GetCompeticionLigaActual();
        //Task<SelectList> GetAllPuestosPremios();
    }
}
