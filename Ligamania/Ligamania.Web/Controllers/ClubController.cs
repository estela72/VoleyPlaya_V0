using AutoMapper;

using Ligamania.Web.Models.Club;
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
    public class ClubController : BaseController<ClubController>
    {
        private readonly IPreparacionService _preparacionService;
        private readonly IMapper _mapper;

        public ClubController(ILogger<ClubController> logger, IPreparacionService service, IMapper mapper) : base(logger)
        {
            _preparacionService = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ClubListVM model = new ClubListVM();
            return View(model);
        }
        public async Task<IActionResult> getListaClubs()
        {
            IEnumerable<ClubVM> clubs = await _preparacionService.GetAllClubs();
            clubs = clubs.OrderBy(c => c.Club);
            return Json(clubs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string nombre, string alias, string baja)
        {
            ClubVM club = new ClubVM { Alias = alias, Baja = baja, Club = nombre };
            try
            {
                if (ModelState.IsValid)
                {
                    var clubCreated = await _preparacionService.CreateClub(club);
                    if (!clubCreated.Error)
                    {
                        var model = new ClubListVM();
                        string msg = "Club creado correctamente.";
                        var clubs = await _preparacionService.GetAllClubs();
                        model.clubs = clubs.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new ClubListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Index", model);
                    }
                }
                else
                {
                    var model = new ClubListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Index", model);
                }
            }
            catch (Exception x)
            {
                var model = new ClubListVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ClubVM model = new ClubVM();
            try
            {
                var club = await _preparacionService.GetClubById(id);
                model = _mapper.Map<ClubVM>(club);
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
        public async Task<IActionResult> Edit(int id, ClubVM updatedClub)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var club = _mapper.Map<ClubVM>(updatedClub);
                    var clubUpdated = await _preparacionService.UpdateClub(id, club);
                    if (!clubUpdated.Error)
                    {
                        var model = new ClubListVM();
                        var clubs = await _preparacionService.GetAllClubs();
                        model.clubs = clubs.ToList();
                        model.Set(false, "Club actualizado correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new ClubListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = new ClubListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = new ClubListVM();
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }
        // GET: Club/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ClubVM model = new ClubVM();
            try
            {
                var club = await _preparacionService.GetClubById(id);
                model = _mapper.Map<ClubVM>(club);
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
                    var result = await _preparacionService.DeleteClubById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                ClubVM model = new ClubVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
