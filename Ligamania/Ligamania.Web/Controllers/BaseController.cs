using Ligamania.Web.Models;

using Microsoft.AspNetCore.Mvc;
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