using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Services;
using Ligamania.Web.Models.Contabilidad;
using Ligamania.Web.Models.Jugador;
using Ligamania.Web.Models.Temporada;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ligamania.Web.Controllers
{
    public class ContabilidadController : BaseController<ContabilidadController>
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IPreparacionService _preparacionService;

        public ContabilidadController(ILogger<ContabilidadController> logger, IMapper mapper, IWebHostEnvironment hostingEnvironment,
            IPreparacionService preparacionService) : base(logger)
        {
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _preparacionService = preparacionService;
        }
        // GET: ContabilidadController
        public async Task<ActionResult> IndexAsync()
        {
            ContabilidadListVM model = new();
            model.Contabilidad = (List<ContabilidadVM>)await _preparacionService.GetContabilidades();
            return View(model);
        }
        public async Task<IActionResult> GetContabilidades()
        {
            IEnumerable<ContabilidadVM> contabilidades = await _preparacionService.GetContabilidades();
            contabilidades = contabilidades.OrderByDescending(c => c.Temporada);
            return Json(contabilidades);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateContabilidadTemporadaAsync([FromBody] ConceptoContabilidad contabilidad)
        {
            string messageResult;
            if (contabilidad == null)
                messageResult = "No se completaron los datos correctamente";
            else
            {
                try
                {
                    var res = await _preparacionService.UpdateContabilidadTemporadaAsync(contabilidad);
                    messageResult = res;
                }
                catch (Exception x)
                {
                    messageResult = "Error al actualizar la contabilidad: " + x.Message;
                }
            }
            var result = new JsonResult(messageResult);
            return result;
        }
        [HttpPost]
        public async Task<JsonResult> RemoveContabilidadTemporada([FromBody] int id)
        {
            string messageResult;
            if (id == 0)
                messageResult = "No se completaron los datos correctamente";
            else
            {
                try
                {
                    var res = await _preparacionService.RemoveContabilidadTemporada(id);
                    messageResult = res;
                }
                catch (Exception x)
                {
                    messageResult = "Error al borrar la contabilidad: " + x.Message;
                }
            }
            var result = new JsonResult(messageResult);
            return result;
        }
        [HttpPost]
        public async Task<JsonResult> UpdatePremioTemporadaAsync([FromBody] PremioContabilidadVM premio)
        {
            string messageResult;
            if (premio == null)
                messageResult = "No se completaron los datos correctamente";
            else
            {
                try
                {
                    var res = await _preparacionService.UpdatePremioTemporadaAsync(premio);
                    messageResult = res;
                }
                catch (Exception x)
                {
                    messageResult = "Error al actualizar el premio: " + x.Message;
                }
            }
            var result = new JsonResult(messageResult);
            return result;
        }
        [HttpPost]
        public async Task<JsonResult> RemovePremioTemporada([FromBody] int id)
        {
            string messageResult;
            if (id == 0)
                messageResult = "No se completaron los datos correctamente";
            else
            {
                try
                {
                    var res = await _preparacionService.RemovePremioTemporada(id);
                    messageResult = res;
                }
                catch (Exception x)
                {
                    messageResult = "Error al borrar el premio: " + x.Message;
                }
            }
            var result = new JsonResult(messageResult);
            return result;
        }
    }
}
