using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VoleyPlaya.Domain.Services;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;

namespace VoleyPlaya.Gestion.Web.Views.Edicion
{
    public class EdicionesModel : PageModel
    {
        IEdicionService _service;
        [BindProperty]
        public IList<VoleyPlaya.Domain.Models.Edicion> Ediciones { get; set; } = default!;
        public EdicionesModel(IEdicionService service) 
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {
            var jsonEdiciones = await _service.GetAllAsync();
            var ediciones = _service.EdicionesFromJson(jsonEdiciones);
            Ediciones = new ObservableCollection<VoleyPlaya.Domain.Models.Edicion>(ediciones.ToList());
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id==null)
                return Page();

            await _service.DeleteEdicion(id.Value);
            return RedirectToPage("Ediciones");
        }
    }
}
