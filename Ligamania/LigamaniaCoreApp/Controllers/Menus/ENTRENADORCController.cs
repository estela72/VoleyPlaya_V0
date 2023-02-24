using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models.EntrenadorViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LigamaniaCoreApp.Controllers
{
    public class ENTRENADORCController : BaseController
    {
        private readonly IEntrenadorService _entrenadorService;
        private readonly ILigamaniaService _ligamaniaService;
        private readonly IManagerService _managerService;
        private readonly IControlUsuarioRepository _controlUsuarioRepository;
        private readonly ILogger<ENTRENADORCController> _logger;

        public ENTRENADORCController(
             IEntrenadorService entrenadorService
            ,ILigamaniaService ligamaniaService
            , IManagerService managerService
            , ILogger<ENTRENADORCController> logger
            , IControlUsuarioRepository controlUsuarioRepository
            )
        {
            _logger = logger;
            _entrenadorService = entrenadorService;
            _ligamaniaService = ligamaniaService;
            _managerService = managerService;
            _controlUsuarioRepository = controlUsuarioRepository;
        }
        [Authorize(Roles = "Admin,Manager,Entrenador")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Manager,Entrenador")]
        public async Task<IActionResult> AlineacionesCambios()
        {
            var user = User.Identity.Name;

            AlineacionesCambiosViewModel model = await _entrenadorService.GetAlineaciones(user).ConfigureAwait(false);
            // Registrar en base de datos que el usuario entró en sesión
            //await _controlUsuarioRepository.AddAccionUsuario(user, "Entrando en pantalla de alineaciones",model.Equipos.FirstOrDefault().Equipo);

            return View(model);
        }
        [Authorize(Roles = "Admin,Manager,Entrenador")]
        public async Task<IActionResult> CambioJugador([FromBody] InfoCambioJugador infoCambioJugador)
        {
            try
            {
                Response response = await _entrenadorService.CambioJugador(infoCambioJugador).ConfigureAwait(false);
                // Registrar en base de datos que el usuario entró en sesión
                var user = User.Identity.Name;
                await _controlUsuarioRepository.AddAccionUsuario(user, "Cambio de jugador "+infoCambioJugador.JugadorCambio + " x "+ infoCambioJugador.Jugador, infoCambioJugador.Equipo).ConfigureAwait(false);

                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CambioJugador] " + x);
                return Json("Error al CambioJugador");
            }
        }

        [Authorize(Roles = "Admin,Manager,Entrenador")]
        public async Task <IActionResult> CancelChange(string equipo, string competicion, string jugador, string jugadorCambio)
        {
            try
            {
                InfoCambioJugador infoCambio = new InfoCambioJugador
                {
                    Equipo = equipo,
                    Competicion = competicion,
                    Jugador = jugador,
                    JugadorCambio = jugadorCambio
                };
                if (jugadorCambio != LigamaniaConst.JugadorAlineacion)
                {
                    Response response = await _entrenadorService.CambioJugador(infoCambio).ConfigureAwait(false);
                }
                else
                {
                    Response response = await _entrenadorService.EliminaAlineacion(infoCambio).ConfigureAwait(false);
                }
                var user = User.Identity.Name;
                await _controlUsuarioRepository.AddAccionUsuario(user, "Cancela cambio de jugador " + jugador, infoCambio.Equipo).ConfigureAwait(false);
                return RedirectToAction("AlineacionesCambios");
            }
            catch (Exception x)
            {
                _logger.LogError("[CancelChange] " + x);
                return Json("Error al cancelar un cambio de jugador");
            }
        }

        public async Task<IActionResult> Carrusel(string competicion, string categoria, string jornada)
        {
            if (string.IsNullOrEmpty(competicion))
            {
                var user = User.Identity.Name;
                var tupla = await _ligamaniaService.GetCompeticionLigaUsuario(user).ConfigureAwait(false);
                competicion = tupla.Item1;
                categoria = tupla.Item2;
            }
            ViewBag.Competiciones = await _ligamaniaService.GetCompeticionesActivas().ConfigureAwait(false);
            //ViewBag.Categorias = await _ligamaniaService.GetAllCategorias(competicion);
            var listaCategorias = await _ligamaniaService.GetAllCategorias(competicion).ConfigureAwait(false);
            ViewBag.Categorias = listaCategorias;
            if (string.IsNullOrEmpty(categoria)||!listaCategorias.Any(x => x.Text == categoria))
            {
                if (listaCategorias.Any() && listaCategorias.Count() == 1)
                    categoria = listaCategorias.FirstOrDefault().Text;
            }
            ViewBag.Jornadas = await _ligamaniaService.GetAllJornadasPasadas(competicion).ConfigureAwait(false);
            int numJornada = -1;
            int.TryParse(jornada, out numJornada);
            if (numJornada == 0 && !string.IsNullOrEmpty(competicion))
            {
                numJornada = await _ligamaniaService.GetJornadaCarrusel(competicion).ConfigureAwait(false);
                if (numJornada == 0) numJornada = await _ligamaniaService.GetJornadaActual(competicion).ConfigureAwait(false);
            }
            CarruselViewModel carrusel = await _entrenadorService.GetCarrusel(competicion,categoria, numJornada).ConfigureAwait(false);
            return View(carrusel);
        }
    }
}