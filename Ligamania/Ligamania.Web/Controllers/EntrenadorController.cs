using Ligamania.Web.Models;
using Ligamania.Web.Models.Equipo;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class EntrenadorController : BaseController<EntrenadorController>
    {
        private readonly IGestionService _entrenadorService;
        public EntrenadorController(ILogger<EntrenadorController> logger
            , IGestionService entrenadorService)
            :base(logger)
        {
            _entrenadorService = entrenadorService;
        }

        public IActionResult Index()
        {
            EntrenadorListVM model = new EntrenadorListVM();
            return View(model);
        }
        public async Task<IActionResult> getListaEntrenadores()
        {
            IEnumerable<EntrenadorVM> entrenadores = await _entrenadorService.GetAllEntrenadores();
            entrenadores = entrenadores.OrderBy(c => c.Nombre);
            return Json(entrenadores);
        }
        [HttpPost]
        public async Task<IActionResult> AddEquipo(NewEquipoVM data)         
        {
            byte[] imagen = null;
            if (data.escudo != null)
            {
                imagen = GetByteArrayFromImage(data.escudo);
            }
            var response = await _entrenadorService.AddEquipo(imagen, data.nombre, data.esBot, data.entrenadorId);
            var model = new EntrenadorVM(response.Message);
            model.Set(response.Error, response.Message);
            return View("Index", model);
        }
        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AccionEquipo(int equipoId, string accion)
        {
            var response = await _entrenadorService.AccionEquipo(equipoId, accion);
            var model = new EntrenadorVM(response.Message);
            model.Set(response.Error, response.Message);
            return View("Index", model);
        }
    }
}
