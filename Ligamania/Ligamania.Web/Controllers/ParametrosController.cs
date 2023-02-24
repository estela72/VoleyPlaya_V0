using AutoMapper;

using Ligamania.Web.Models;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Mvc;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ParametrosController : BaseController<ParametrosController>
    {
        private readonly IPreparacionService _preparacionService;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostingEnvironment;

        public ParametrosController(ILogger<ParametrosController> logger, IPreparacionService service, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(logger)
        {
            _preparacionService = service;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index(ParametroVM model)
        {
            model = await _preparacionService.GetParametros();
            return View(model);
        }
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParametroVM updatedParametro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var parametro = _mapper.Map<ParametroVM>(updatedParametro);
                    var parametroUpdated = await _preparacionService.UpdateParametros(parametro);
                    if (parametroUpdated==null || !parametroUpdated.Error)
                    {
                        var model = new ParametroVM();
                        model = await _preparacionService.GetParametros();
                        model.Set(false, "Parámetros actualizados correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new ParametroVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Index", model);
                    }
                }
                else
                {
                    var model = new ParametroVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Index", model);
                }
            }
            catch (Exception x)
            {
                var model = new ParametroVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
    }
}
