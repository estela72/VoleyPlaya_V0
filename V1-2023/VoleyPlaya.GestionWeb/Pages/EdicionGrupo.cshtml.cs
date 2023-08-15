using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VoleyPlaya.Domain.Services;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using VoleyPlaya.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using VoleyPlaya.GestionWeb.Pages;

namespace VoleyPlaya.Gestion.Web.Views.Edicion
{
    [Authorize(Policy = "CompeticionesOnly")]
    public class EdicionGrupoModel : VPPageModel
    {
        [BindProperty]
        public EdicionGrupo Grupo { get; set; } = default!;
        public EdicionGrupoModel(IEdicionService service):base(service)
        {
        }
        public async Task OnGetAsync(int? id)
        {
            Grupo = await _service.GetGrupoAsync(id.Value);
            Grupo.UpdateEquipos(Grupo.NumEquipos);
        }
        // Generar partidos
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Grupo != null)
            {
                await _service.UpdateGrupoAsync(Grupo);
            }
            Grupo = await _service.GetGrupoAsync(Grupo.Id);
            Grupo.UpdateEquipos(Grupo.NumEquipos);
            return Page();
        }
        public async Task<IActionResult> OnPostPartidosAsync()
        {
            for (int i = 0; i < Grupo.Partidos.Count; i++)
            {
                ModelState.Remove("Grupo.Partidos[" + i.ToString() + "].Local");
                ModelState.Remove("Grupo.Partidos[" + i.ToString() + "].Visitante");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Grupo != null && Grupo.Partidos != null && Grupo.Partidos.Count > 0)
            {
                await _service.UpdateClasificacion(Grupo);
                await _service.UpdatePartidosAsync(Grupo);
            }
            Grupo = await _service.GetGrupoAsync(Grupo!.Id);
            return Page();
        }
        public async Task<IActionResult> OnGetDeletePartido(int partidoId, int groupId)
        {
            await _service.DeletePartidoAsync(partidoId);
            Grupo = await _service.GetGrupoAsync(groupId);

            if (Grupo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
