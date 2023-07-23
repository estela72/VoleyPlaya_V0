using AutoMapper;

using Ligamania.Web.Models.Competicion;
using Ligamania.Web.Models.Temporada;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Mvc;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TemporadaController : BaseController<TemporadaController>
    {
        private readonly IGestionTemporadaService _temporadaService;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostingEnvironment;

        public TemporadaController(ILogger<TemporadaController> logger, IGestionTemporadaService service, IMapper mapper, IWebHostEnvironment hostingEnvironment) 
            : base(logger)
        {
            _temporadaService = service;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var model = new TemporadaListVM();
            return View(model);
        }
        public async Task<IActionResult> getListaTemporadas()
        {
            IEnumerable<TemporadaVM> temporadas = await _temporadaService.GetAllTemporadas();
            temporadas = temporadas.OrderByDescending(c => c.Actual).ThenByDescending(c=>c.Temporada);
            return Json(temporadas);
        }
        public async Task<IActionResult> ShowClasificacion(int id)
        {
            byte[] clasificacion = await _temporadaService.GetClasificacionById(id);

            if (clasificacion != null)
            {
                //instead of what augi wrote using the binarystreamresult this was the closest thing i found so i am assuming that this is what it evolved into 
                return new FileStreamResult(new System.IO.MemoryStream(clasificacion), "image/jpeg");
            }
            var model = new TemporadaListVM("No está disponible la clasificación");
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemporadaVM modelCreated)
        {
            TemporadaVM temporada = new TemporadaVM { Temporada=modelCreated.Temporada };
            try
            {
                if (ModelState.IsValid)
                {
                    var tempCreated = await _temporadaService.CreateTemporada(temporada);
                    if (!tempCreated.Error)
                    {
                        var model = new TemporadaListVM();
                        string msg = "Temporada creada correctamente.";
                        var temporadas = await _temporadaService.GetAllTemporadas();
                        model.temporadas = temporadas.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new TemporadaListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Index", model);
                    }
                }
                else
                {
                    var model = new TemporadaListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Index", model);
                }
            }
            catch (Exception x)
            {
                var model = new TemporadaListVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            TemporadaVM model = new TemporadaVM();
            try
            {
                var temp = await _temporadaService.GetTemporadaById(id);
                model = _mapper.Map<TemporadaVM>(temp);
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
        public async Task<IActionResult> Edit(int id, TemporadaVM updatedTemp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var temp = _mapper.Map<TemporadaVM>(updatedTemp);
                    var tempUpdated = await _temporadaService.UpdateTemporada(id, temp);
                    if (!tempUpdated.Error)
                    {
                        var model = new TemporadaListVM();
                        var temps = await _temporadaService.GetAllTemporadas();
                        model.temporadas = temps.ToList();
                        model.Set(false, "Temporada actualizada correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new TemporadaVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = new TemporadaVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = new TemporadaVM();
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }
        // GET: Jugador/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            TemporadaVM model = new TemporadaVM();
            try
            {
                var temp = await _temporadaService.GetTemporadaById(id);
                model = _mapper.Map<TemporadaVM>(temp);
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
                    var result = await _temporadaService.DeleteTemporadaById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                TemporadaVM model = new TemporadaVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> getListaCompeticiones(int idTemporada)
        {
            IEnumerable<CompeticionVM> competiciones = await _temporadaService.GetCompeticiones(idTemporada);
            foreach(var comp in competiciones)
            {
                var categorias = await getListaCategorias(idTemporada, comp.Id);
                comp.AddCategorias(categorias);
            }
            return Json(competiciones);
        }
        public async Task<IEnumerable<CategoriaVM>> getListaCategorias(int idTemporada, int idCompeticion)
        {
            IEnumerable<CategoriaVM> categorias = await _temporadaService.GetCategorias(idTemporada, idCompeticion);
            return categorias;
        }
        // GET: Temporada/Historificar/5
        [HttpGet]
        public async Task<IActionResult> Historificar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _temporadaService.HistorificarTemporadaById(id);
                   
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                TemporadaVM model = new TemporadaVM();
                model.Set(true, x.Message);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
