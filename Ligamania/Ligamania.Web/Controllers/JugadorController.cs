using AutoMapper;

using Ligamania.Web.Models.Jugador;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class JugadorController : BaseController<JugadorController>
    {
        private readonly IPreparacionService _preparacionService;
        private readonly IMapper _mapper;

        public JugadorController(ILogger<JugadorController> logger, IPreparacionService service, IMapper mapper) : base(logger)
        {
            _preparacionService = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            JugadorListVM model = new JugadorListVM();
            return View(model);
        }
        public async Task<IActionResult> getListaJugadores()
        {
            IEnumerable<JugadorVM> Jugadors = await _preparacionService.GetAllJugadores();
            Jugadors = Jugadors.OrderBy(c => c.Jugador);
            return Json(Jugadors);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string nombre,  string baja)
        {
            JugadorVM Jugador = new JugadorVM { Baja = baja, Jugador = nombre };
            try
            {
                if (ModelState.IsValid)
                {
                    var JugadorCreated = await _preparacionService.CreateJugador(Jugador);
                    if (!JugadorCreated.Error)
                    {
                        var model = new JugadorListVM();
                        string msg = "Jugador creado correctamente.";
                        var Jugadors = await _preparacionService.GetAllJugadores();
                        model.jugadores = Jugadors.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new JugadorListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Index", model);
                    }
                }
                else
                {
                    var model = new JugadorListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Index", model);
                }
            }
            catch (Exception x)
            {
                var model = new JugadorListVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            JugadorVM model = new JugadorVM();
            try
            {
                var Jugador = await _preparacionService.GetJugadorById(id);
                model = _mapper.Map<JugadorVM>(Jugador);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JugadorVM updatedJugador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Jugador = _mapper.Map<JugadorVM>(updatedJugador);
                    var JugadorUpdated = await _preparacionService.UpdateJugador(id, Jugador);
                    if (!JugadorUpdated.Error)
                    {
                        var model = new JugadorListVM();
                        var Jugadors = await _preparacionService.GetAllJugadores();
                        model.jugadores = Jugadors.ToList();
                        model.Set(false, "Jugador actualizado correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = updatedJugador;
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = updatedJugador;
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = new JugadorVM();
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }
        // GET: Jugador/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            JugadorVM model = new JugadorVM();
            try
            {
                var Jugador = await _preparacionService.GetJugadorById(id);
                model = _mapper.Map<JugadorVM>(Jugador);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }
        // POST: Jugador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _preparacionService.DeleteJugadorById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                JugadorVM model = new JugadorVM();
                model.Set(true, "- Borrado de jugador. Para poder borrar un jugador, éste no debe haber estado activo en ninguna temporada");
                return View(model);
            }
            catch (Exception x)
            {
                JugadorVM model = new JugadorVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
