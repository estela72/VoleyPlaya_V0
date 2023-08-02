using Ligamania.API.Lib.Services;
using Ligamania.Generic.Lib.Enums;
using Ligamania.Web.Models;
using Ligamania.Web.Models.Competicion;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

//using X.PagedList;

namespace Ligamania.Web.Controllers
{
    public class BaseController<T> : Controller
    {
        private readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            this._logger = logger;
        }
        protected void logInfo(string msg)
        {
            _logger.LogInformation(msg);
        }
        public async Task<IActionResult> GetCompeticiones()
        {
            var competiciones = EnumCompeticiones.Competiciones.Values;
            return Json(competiciones);
        }
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = EnumCategorias.Categorias.Values;
            return Json(categorias);
        }
        public async Task<IActionResult> GetPuestos()
        {
            var puestos = EnumPuestos.Puestos.Values;
            return Json(puestos);
        }
        public virtual async Task<IActionResult> GetEquipos()
        {
            var equipos = new Dictionary<int,string>().Values;
            return Json(equipos);
        }
        
        
        //protected IPagedList<T> GetPagedList(int? page, IEnumerable<T> listUnpaged, int? numRowsByPage)
        //{
        //    // return a 404 if user browses to before the first page
        //    if (page.HasValue && page < 1)
        //        return null;

        //    // page the list
        //    int pageSize = numRowsByPage ?? 15;
        //    var listPaged = listUnpaged.ToPagedList(page ?? 1, pageSize);

        //    // return a 404 if user browses to pages beyond last page. special case first page if no items exist
        //    if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
        //        return null;

        //    return listPaged;
        //}
    }
}