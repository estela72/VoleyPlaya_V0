using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VoleyPlaya.Domain.Services;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using VoleyPlaya.GestionWeb.Pages;

namespace VoleyPlaya.Gestion.Web.Views.Edicion
{
    [AllowAnonymous]
    public class IndexModel : VPPageModel
    {
        public IndexModel(IEdicionService service) : base(service)
        {
        }
    }
}
