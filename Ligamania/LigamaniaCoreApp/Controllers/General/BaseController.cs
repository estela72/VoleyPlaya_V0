using LigamaniaCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Controllers
{
    public class BaseController : Controller
    {
        //public ActionResult Constants()
        //{
        //    var constants = typeof(LigamaniaConst)
        //        .GetFields()
        //        .ToDictionary(x => x.Name, x => x.GetValue(null));
        //    var json = new JavaScriptSerializer().Serialize(constants);
        //    return JavaScript("var constants = " + json + ";");
        //}
    }
}
