using AutoMapper;

using Ligamania.Web.Models.Competicion;
using Ligamania.Web.Services;

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
    public class CompeticionController : BaseController<CompeticionController>
    {
        private readonly IPreparacionService _preparacionService;
        private readonly IMapper _mapper;

        public CompeticionController(ILogger<CompeticionController> logger, IPreparacionService service, IMapper mapper) : base(logger)
        {
            _preparacionService = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            CompeticionListVM model = new CompeticionListVM();
            return View(model);
        }

        public async Task<IActionResult> getListaCompeticiones()
        {
            IEnumerable<CompeticionVM> competiciones = await _preparacionService.GetAllCompeticiones();
            competiciones = competiciones.OrderBy(c => c.Orden);
            return Json(competiciones);
        }
        public async Task<IActionResult> getListaCategorias(int idCompeticion)
        {
            IEnumerable<CategoriaVM> categorias = await _preparacionService.GetCategorias(idCompeticion);
            return Json(categorias);
        }

        // GET: UsersController/Create
        public IActionResult Create(CompeticionVM model)
        {
            if (model == null)
                model = new CompeticionVM();
            return View(model);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompeticion(CompeticionVM newCompeticion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var competicion = _mapper.Map<CompeticionVM>(newCompeticion);
                    var competicionCreated = await _preparacionService.CreateCompeticion(competicion);
                    if (!competicionCreated.Error)
                    {
                        var model = new CompeticionListVM();
                        string msg = "Competición creada correctamente.";
                        var competiciones = await _preparacionService.GetAllCompeticiones();
                        model.competiciones = competiciones.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new CompeticionVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Create", model);
                    }
                }
                else
                {
                    var model = new CompeticionVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Create", model);
                }
            }
            catch (Exception x)
            {
                var model = newCompeticion;
                model.Set(true, x.Message);
                return View("Create", model);
            }
        }

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            CompeticionVM model = new CompeticionVM();
            try
            {
                var competicion = await _preparacionService.GetCompeticionById(id);
                model = _mapper.Map<CompeticionVM>(competicion);
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
        public async Task<IActionResult> Edit(int id, CompeticionVM updatedCompeticion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var competicion = _mapper.Map<CompeticionVM>(updatedCompeticion);
                    var competicionUpdated = await _preparacionService.UpdateCompeticion(id, competicion);
                    if (!competicionUpdated.Error)
                    {
                        var model = new CompeticionListVM();
                        var competiciones = await _preparacionService.GetAllCompeticiones();
                        model.competiciones = competiciones.ToList();
                        model.Set(false, "Competición actualizada correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new CompeticionVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = new CompeticionVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = updatedCompeticion;
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }

        // GET: UsersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            CompeticionVM model = new CompeticionVM();
            try
            {
                var competicion = await _preparacionService.GetCompeticionById(id);
                model = _mapper.Map<CompeticionVM>(competicion);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _preparacionService.DeleteCompeticionById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                CompeticionVM model = new CompeticionVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategorias(int newCategoria, int competicionId)
        {
            var response = await _preparacionService.UpdateCategoriaToCompeticion(newCategoria, competicionId);
            var model = new CompeticionListVM(response.Message);
            model.Set(response.Error, response.Message);
            return View("Index", model);
        }

        public async Task<IActionResult> DeleteCategoriaFromCompeticion(int competicionId, int categoriaId)
        {
            var response = await _preparacionService.DeleteCategoriaFromCompeticion(competicionId, categoriaId);
            var model = new CompeticionListVM(response.Message);
            model.Set(response.Error, response.Message);
            return View("Index", model);
        }
    }
}
