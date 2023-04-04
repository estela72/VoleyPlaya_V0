using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    public class CalendarioModel : PageModel
    {
        IEdicionService _service;
        [BindProperty]
        public Edicion Edicion { get; set; }


        public CalendarioModel(IEdicionService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Edicion = new();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Edicion = new Edicion();
                return Page();
            }

            var jsonEdicion = await _service.GetEdicionById(id.Value);
            Edicion = _service.FromJson(jsonEdicion);

            if (Edicion == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (Edicion != null)
            {
                await _service.UpdatePartidosAsync(Edicion);
            }
            return RedirectToPage("./Calendario");
        }
    }
}
