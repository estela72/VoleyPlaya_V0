using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Runtime.InteropServices;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    [AllowAnonymous]
    public class ClasificacionesModel : VPPageModel
    {
        public List<EdicionGrupo> Clasificaciones { get; set; }

        public ClasificacionesModel(IEdicionService service) : base(service)
        {
        }

        public async Task OnGetAsync(string prueba, int? competicion, int? categoria, string genero, int? grupo)
        {
            await FilterSelection(prueba, competicion, categoria, genero, grupo);
            await LoadClasificacionAsync();
        }

        private async Task LoadClasificacionAsync()
        {
            if (PruebaSelected==null||PruebaSelected.Equals("0") || CompeticionSelected == null || CategoriaSelected == null || string.IsNullOrEmpty(GeneroSelected) || GeneroSelected.Equals("0"))
                return;

            Clasificaciones = await _service.GetClasificacionEquiposAsync(PruebaSelected, int.Parse(CompeticionSelected), int.Parse(CategoriaSelected), GeneroSelected, GrupoSelected);
            Clasificaciones = Clasificaciones.Where(g => g.TipoGrupo.Equals(EnumTipoGrupo.Liga)).ToList();
        }
    }
}
