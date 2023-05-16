using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VoleyPlaya.Domain.Services;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using VoleyPlaya.GestionWeb.Pages;

namespace VoleyPlaya.Gestion.Web.Views.Edicion
{
    [Authorize(Policy = "CompeticionesOnly")]
    public class EdicionesModel : VPPageModel
    {
        [BindProperty]
        public IList<VoleyPlaya.Domain.Models.Edicion> Ediciones { get; set; } = default!;

        public EdicionesModel(IEdicionService service) :base(service)
        {
        }
        public async Task OnGetAsync()
        {
            try
            {
                var ediciones = await _service.GetAllAsync();
                Ediciones = new ObservableCollection<VoleyPlaya.Domain.Models.Edicion>(ediciones.ToList());
            }
            catch(Exception ex)
            {
                ErrorMessage = "Error cargando las competiciones.";
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id==null)
                return Page();
            try
            {
                await _service.DeleteEdicion(id.Value);
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error borrando la competición.";
            }

            return RedirectToPage("Ediciones");
        }
    }
}
