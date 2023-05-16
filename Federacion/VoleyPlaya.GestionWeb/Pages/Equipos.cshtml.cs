using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Text.Json.Nodes;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "CompeticionesOnly")]
    public class EquiposModel : VPPageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public List<Equipo> Equipos { get; set; }
        [BindProperty]
        public int EdicionId { get; set; }

        [BindProperty]
        public string NuevoEquipo { get; set; }

        public string UrlEdicion { get; set; }
        
        public EquiposModel(IEdicionService service, IHttpContextAccessor httpContextAccessor):base(service)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                Equipos = new List<Equipo>();
                return Page();
            }

            if (!await GetEdicion(id.Value))
                return NotFound();

            UrlEdicion = _httpContextAccessor.HttpContext?.Request.Headers["Referer"].ToString();

            return Page();
        }
        private async Task<bool> GetEdicion(int id)
        {
            var edicion = await _service.GetEdicionById(id);
            if (edicion == null)
            {
                return false;
            }
            Equipos = edicion.Equipos;
            EdicionId = id;
            return true;
        }
        public async Task<IActionResult> OnPostDeleteEquipoAsync(int id)
        {
            if (id == 0)
            {
                Equipos = new List<Equipo>();
                return Page();
            }
            await _service.DeleteEquipoAsync(id);
            if (!await GetEdicion(EdicionId))
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostGuardarAsync()
        {
            await _service.UpdateEquiposEdicionAsync(EdicionId, Equipos);
            if (!await GetEdicion(EdicionId))
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostNuevoEquipoAsync()
        {
            if (string.IsNullOrEmpty(NuevoEquipo) || EdicionId == 0)
            {
                ErrorMessage = "Se necesita el nombre del equipo para poder crearlo";
            }
            await _service.AddEquipo(EdicionId, NuevoEquipo);
            if (!await GetEdicion(EdicionId))
                return NotFound();
            return Page();
        }
    }
}
