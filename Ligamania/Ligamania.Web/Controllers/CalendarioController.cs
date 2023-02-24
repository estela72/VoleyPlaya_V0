using AutoMapper;

using Ligamania.Web.Helpers;
using Ligamania.Web.Models;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CalendarioController : BaseController<CalendarioController>
    {
        private readonly IPreparacionService _preparacionService;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostingEnvironment;

        public CalendarioController(ILogger<CalendarioController> logger, IPreparacionService service, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(logger)
        {
            _preparacionService = service;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            CalendarioListVM model = new CalendarioListVM();
            return View(model);
        }
        public async Task<IActionResult> getListaCalendarios()
        {
            IEnumerable<CalendarioVM> calendarios = await _preparacionService.GetAllCalendarios();
            calendarios = calendarios.OrderBy(c => c.Calendario);
            foreach (var cal in calendarios) cal.Partidos.OrderBy(p => p.Jornada).ThenBy(p => p.Local);
            return Json(calendarios);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string nombre, int numEquipos)
        {
            CalendarioVM calendario = new CalendarioVM { Calendario = nombre, NumEquipos = numEquipos, Partidos=new List<CalendarioDetalleVM>() };
            try
            {
                if (ModelState.IsValid)
                {
                    IFormFile file = Request.Form.Files[0];
                    string folderName = "Upload";
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    CalendarParser.Parse(calendario, file, folderName, webRootPath);

                    var calendarioCreated = await _preparacionService.CreateCalendario(calendario);
                    if (!calendarioCreated.Error)
                    {
                        var model = new CalendarioListVM();
                        string msg = "Calendario creado correctamente.";
                        var calendarios = await _preparacionService.GetAllCalendarios();
                        model.calendarios = calendarios.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new CalendarioListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Index", model);
                    }
                }
                else
                {
                    var model = new CalendarioListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Index", model);
                }
            }
            catch (Exception x)
            {
                var model = new CalendarioListVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            CalendarioVM model = new CalendarioVM();
            try
            {
                var calendario = await _preparacionService.GetCalendarioById(id);
                model = _mapper.Map<CalendarioVM>(calendario);
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
        public async Task<IActionResult> Edit(int id, CalendarioVM updatedCalendario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var calendario = _mapper.Map<CalendarioVM>(updatedCalendario);
                    var calendarioUpdated = await _preparacionService.UpdateCalendario(id, calendario);
                    if (!calendarioUpdated.Error)
                    {
                        var model = new CalendarioListVM();
                        var calendarios = await _preparacionService.GetAllCalendarios();
                        model.calendarios = calendarios.ToList();
                        model.Set(false, "Calendario actualizado correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new CalendarioListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = new CalendarioListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = new CalendarioListVM();
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }
        // GET: Club/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            CalendarioVM model = new CalendarioVM();
            try
            {
                var calendario = await _preparacionService.GetCalendarioById(id);
                model = _mapper.Map<CalendarioVM>(calendario);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }
        // POST: Club/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _preparacionService.DeleteCalendarioById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                CalendarioVM model = new CalendarioVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePartidoCalendario(CalendarioDetalleVM calendarioDetalleVM)
        {
            try
            {
                var response = await _preparacionService.UpdatePartidoCalendario(calendarioDetalleVM.CalendarioId, calendarioDetalleVM.Id, calendarioDetalleVM.Jornada, calendarioDetalleVM.Local, calendarioDetalleVM.Visitante);
                var model = new CalendarioListVM(response.Message);
                model.Set(response.Error, response.Message);
                return View("Index", model);
            }
            catch(Exception x)
            {
                CalendarioVM model = new CalendarioVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeletePartidoCalendario(CalendarioDetalleVM calendarioDetalleVM)
        {
            try
            {
                var response = await _preparacionService.DeletePartidoCalendario(calendarioDetalleVM.CalendarioId, calendarioDetalleVM.Id);
                var model = new CalendarioListVM(response.Message);
                model.Set(response.Error, response.Message);
                return View("Index", model);
            }
            catch (Exception x)
            {
                CalendarioVM model = new CalendarioVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
    }
}
