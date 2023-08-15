using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Services;
using Microsoft.Extensions.Logging;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace LigamaniaCoreApp.Controllers
{
    public class HomeController : BaseController
    {
        private const string Message = "Entrando en Ligamania:(";
        private readonly ILigamaniaService _ligamaniaService;
        private readonly IManagerService _managerService;
        private readonly ILogger _logger;

        public HomeController(
              ILigamaniaService ligamaniaService
            , IManagerService managerService
            , ILogger<HomeController> logger
            )
        {
            _ligamaniaService = ligamaniaService;
            _managerService = managerService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation(Message);
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<PartialViewResult> JugadoresBajaGrid()
        {
            var jugadores = await _ligamaniaService.GetJugadoresBaja().ConfigureAwait(false);
            return PartialView("_JugadoresBajaPartial", jugadores);
        }
        [HttpGet]
        public async Task<PartialViewResult> JugadoresEliminadosGrid()
        {
            var jugadores = await _ligamaniaService.GetJugadoresEliminados().ConfigureAwait(false);
            return PartialView("_JugadoresEliminadosPartial", jugadores);
        }
        [HttpGet]
        public async Task<PartialViewResult> JugadoresPreEliminadosGrid()
        {
            var jugadores = await _ligamaniaService.GetJugadoresPreEliminados().ConfigureAwait(false);
            return PartialView("_JugadoresPreEliminadosPartial", jugadores);
        }

        [HttpGet]
        public async Task<PartialViewResult> JugadoresPorCategoriaGrid()
        {
            var jugadores = await _ligamaniaService.GetJugadoresPorCategoria().ConfigureAwait(false);
            return PartialView("_JugadoresPorCategoriaPartial", jugadores);
        }
        

        [HttpGet]
        public async Task<PartialViewResult> ClasificacionesGrid()
        {
            ICollection<ClasificacionViewModel> clasificaciones = await _ligamaniaService.GetClasificaciones().ConfigureAwait(false);
            return PartialView("_ClasificacionesPartial", clasificaciones);
        }
        [HttpGet]
        public async Task<PartialViewResult> NoticiasGrid()
        {
            var noticias = await _ligamaniaService.GetAllNews().ConfigureAwait(false);
            return PartialView("_NoticiasPartial", noticias);
        }
        
        [HttpGet]
        public async Task<PartialViewResult> VistaEquiposPretemporada()
        {
            ICollection<Models.ManagerViewModels.TemporadaEquipoViewModel> equipos = await _managerService.GetEquiposViewModelPretemporada().ConfigureAwait(false);
            equipos = equipos.Where(e => !e.Baja).ToList();
            return PartialView("_VistaEquiposPretemporadaPartial", equipos);
        }
    }
}
