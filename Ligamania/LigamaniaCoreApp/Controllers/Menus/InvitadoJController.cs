using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LigamaniaCoreApp.Controllers.Menus
{
    //[Authorize(Roles = "Invitado")]
    public class InvitadoJController : BaseController
    {
        IInvitadoService _invitadoService;
        IManagerService _managerService;
        IAdministradorService _administradorService;
        IPanelControlService _panelControlService;
        ILigamaniaService _ligamaniaService;

        public InvitadoJController(
            IInvitadoService invitadoService
          , IManagerService managerService
          , IAdministradorService administradorService
            , IPanelControlService panelControlService
            , ILigamaniaService ligamaniaService
        )
        {
            _invitadoService = invitadoService;
            _managerService = managerService;
            _administradorService = administradorService;
            _panelControlService = panelControlService;
            _ligamaniaService = ligamaniaService;
        }

        public async Task<IActionResult> Jugadores()
        {
            TemporadaViewModel temporada = await _managerService.GetTemporadaViewModelActual().ConfigureAwait(false);
            if (temporada == null) temporada = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);

            ICollection<TemporadaJugadorViewModel> jugadores = new List<TemporadaJugadorViewModel>();
            if (temporada != null)
            {
                jugadores = await _administradorService.GetJugadoresViewModelFromTemporada(temporada.Id).ConfigureAwait(false);
                jugadores = jugadores.Where(j => j.Activo).OrderBy(j => j.Club).ThenBy(j => j.Jugador).ToList();
            }
            return View(jugadores);
        }

        public async Task<IActionResult> Calendario()
        {
            ICollection<CalendarioViewModel> calendarios = new List<CalendarioViewModel>();
            calendarios = await _invitadoService.GetCalendarios().ConfigureAwait(false);
            //TempData["Calendarios"] = calendarios;
            return View(calendarios);
        }
        public async Task<IActionResult> JornadaMenos(string competicion, string categoria, int jornada)
        {
            ICollection<CalendarioViewModel> calendarios = new List<CalendarioViewModel>();
            calendarios = await _invitadoService.GetCalendarios().ConfigureAwait(false);

            var cal = calendarios.FirstOrDefault(c => c.Competicion.Equals(competicion));
            var cat = cal.Categorias.FirstOrDefault(c => c.Categoria.Equals(categoria));
            cat.JornadaSelected = Math.Max(1, jornada - 1);

            ViewBag.Calendarios = calendarios;

            return View("Calendario", calendarios);

        }
        public async Task<IActionResult> JornadaMas(string competicion, string categoria, int jornada)
        {
            ICollection<CalendarioViewModel> calendarios = new List<CalendarioViewModel>();
            calendarios = await _invitadoService.GetCalendarios().ConfigureAwait(false);

            var cal = calendarios.FirstOrDefault(c => c.Competicion.Equals(competicion));
            var cat = cal.Categorias.FirstOrDefault(c => c.Categoria.Equals(categoria));
            var lastj = cat.LastJornada;//cat.Jornadas.Max(jj => jj.Jornada);
            cat.JornadaSelected = Math.Min(lastj,jornada + 1);

            ViewBag.Calendarios = calendarios;

            return View("Calendario", calendarios);
        }
        public async Task<IActionResult> Equipos()
        {
            return View();
        }
        public async Task<IActionResult> Clasificaciones()
        {
            return View();
        }
        public async Task<IActionResult> Clasificaciones2Vuelta()
        {
            ICollection<ClasificacionViewModel> clasificaciones = await _ligamaniaService.GetClasificacionesVuelta2().ConfigureAwait(false);
            return View(clasificaciones);
        }
        public async Task<IActionResult> CuadroCopaPrevia(string verPrevia=null)
        {
            List<TemporadaRondaPartidos> cuadroCopa = await _panelControlService.GetAllRondasConPartidos().ConfigureAwait(false);
            var rondaActiva = await _panelControlService.GetRondaActiva().ConfigureAwait(false);
            if (rondaActiva >= 3 && string.IsNullOrEmpty(verPrevia))
                return View("CuadroCopa", cuadroCopa);
            return View(cuadroCopa);
        }
        public async Task<IActionResult> CuadroCopa()
        {
            List<TemporadaRondaPartidos> cuadroCopa = await _panelControlService.GetAllRondasConPartidos().ConfigureAwait(false);
            return View(cuadroCopa);
        }
        public async Task<IActionResult> CriterioGanador(int idPartido)
        {
            TemporadaPartidoRondaViewModel partidoRonda = await _panelControlService.GetPartidoRonda(idPartido).ConfigureAwait(false);
            return View(partidoRonda);
        }
        public async Task<IActionResult> ClasificacionLigaCopa()
        {
            var clasi = await _ligamaniaService.GetClasificacionLigaParaCopa().ConfigureAwait(false);
            return View(clasi);
        }
    }
}