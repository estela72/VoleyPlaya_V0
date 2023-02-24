﻿using AutoMapper;

using General.CrossCutting.Lib.Enums;

using Ligamania.Generic.Lib.Enums;
using Ligamania.Web.Models.Club;
using Ligamania.Web.Models.Jugador;
using Ligamania.Web.Models.Temporada;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TemporadaActualController : BaseController<TemporadaActualController>
    {
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly IGestionTemporadaService _temporadaService;
        private readonly IPreparacionService _preparacionService;

        public TemporadaActualController(ILogger<TemporadaActualController> logger,IMapper mapper, IWebHostEnvironment hostingEnvironment,
            IGestionTemporadaService temporadaService, IPreparacionService preparacionService) : base(logger)
        {
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _temporadaService = temporadaService;
            _preparacionService = preparacionService;
        }
        public IActionResult Clubs()
        {
            ClubListVM model = new ClubListVM();
            return View(model);
        }
        public async Task<IActionResult> Jugadores()
        {
            JugadorListVM model = new JugadorListVM();
            //asignar un club y puesto por defecto
            var clubs = await _temporadaService.GetAllClubs();
            
            ViewBag.Club = clubs.FirstOrDefault().Club;
            ViewBag.Puesto = Enum.GetNames<PuestoJugador>().FirstOrDefault();
            return View(model);
        }
        public async Task<IActionResult> getListaClubsTemporada()
        {
            IEnumerable<ClubVM> clubs = await _temporadaService.GetAllClubs();
            clubs = clubs.OrderBy(c => c.ClubAlias);
            return Json(clubs);
        }
        public async Task<IActionResult> getListaJugadoresTemporada(FiltroJugador filtro)
        {
            IEnumerable<JugadorVM> jugadores = await _temporadaService.GetAllJugadores();
            if (filtro != null)
            {
                ViewBag.Club = string.IsNullOrEmpty(filtro.club) ? "": filtro.club;
                ViewBag.Puesto = string.IsNullOrEmpty(filtro.puesto) ? "": filtro.puesto;
            }
            if (filtro != null)
            { 
                jugadores = string.IsNullOrEmpty(filtro.club) ? jugadores : jugadores.Where(j => j.Activo.Equals(SiNo.NO.ToString()) || (j.Activo.Equals(SiNo.SI.ToString()) && j.AliasClub.Equals(filtro.club)));
                jugadores = string.IsNullOrEmpty(filtro.puesto) ? jugadores : jugadores.Where(j => j.Activo.Equals(SiNo.NO.ToString()) || (j.Activo.Equals(SiNo.SI.ToString()) && j.Puesto.Equals(filtro.puesto)));
            }
            jugadores = jugadores.OrderBy(c => c.AliasClub).ThenBy(c=>c.OrdenPuesto).ThenBy(c=>c.Jugador);
            return Json(jugadores);
        }
        public async Task<IActionResult> getListaTemporadas()
        {
            IEnumerable<TemporadaVM> temporadas = await _temporadaService.GetAllTemporadas();
            temporadas = temporadas.OrderByDescending(t => t.Temporada);
            return Json(temporadas);
        }
        public async Task<IActionResult> getListaClubs()
        {
            IEnumerable<ClubVM> clubs = await _temporadaService.GetAllClubs();
            clubs = clubs.OrderBy(t => t.Alias);
            return Json(clubs);
        }
        public async Task<IActionResult> getListaPuestos()
        {
            IEnumerable<string> puestos = Enum.GetNames<PuestoJugador>() ;
            //puestos = puestos.OrderBy(t => t.Orden);
            return Json(puestos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClub(string club, string alias)
        {
            ClubVM clubEnt = new ClubVM { Alias = alias, Baja = SiNo.NO.ToString(), Club = club };
            try
            {
                if (ModelState.IsValid)
                {
                    var clubCreated = await _preparacionService.CreateClub(clubEnt);
                    if (!clubCreated.Error)
                    {
                        var model = new ClubListVM();
                        string msg = "Club creado correctamente.";
                        var clubs = await _preparacionService.GetAllClubs();
                        model.clubs = clubs.ToList();
                        model.Set(false, msg);
                        return View("Clubs", model);
                    }
                    else
                    {
                        var model = new ClubListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Clubs", model);
                    }
                }
                else
                {
                    var model = new ClubListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Clubs", model);
                }
            }
            catch (Exception x)
            {
                var model = new ClubListVM();
                model.Set(true, x.Message);
                return View("Clubs", model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> UpdateClubs([FromBody] List<ClubVM> clubs)
        {
            var messageResult = string.Empty;
            try
            {
                var res = await _temporadaService.UpdateClubsTemporada(clubs);
                messageResult = "Clubs actualizados en la temporada actual";
            }
            catch(Exception x)
            {
                messageResult = "Error al actualizar los clubs en la temporada actual: " + x.Message;
            }
            var result = new JsonResult(messageResult);
            // Return info.  
            return result;
        }
        [HttpPost]
        public async Task<JsonResult> UpdateJugadores([FromBody] List<JugadorVM> jugadores)
        {
            var messageResult = string.Empty;
            if (jugadores.Count>0)
            {
                ViewBag.Club = jugadores.First().Club;
                ViewBag.Puesto = jugadores.First().Puesto;
            }
            try
            {
                var res = await _temporadaService.UpdateJugadoresTemporada(jugadores);
                messageResult = "Jugadores actualizados en la temporada actual";
            }
            catch (Exception x)
            {
                messageResult = "Error al actualizar los jugadores en la temporada actual: " + x.Message;
            }
            var result = new JsonResult(messageResult);
            // Return info.  
            return result;
        }
    }
}
