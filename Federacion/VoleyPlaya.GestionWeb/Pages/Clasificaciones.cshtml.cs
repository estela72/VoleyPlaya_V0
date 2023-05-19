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

        public async Task OnGetAsync(int? competicion, int? categoria, string genero, int? grupo)
        {
            CompeticionSelected = competicion is not null and > 0 ? competicion.ToString() : null;
            CategoriaSelected = categoria is not null and > 0 ? categoria.ToString() : null;
            GeneroSelected = genero;
            GrupoSelected = grupo is not null and > 0 ? grupo.ToString() : null;

            Competiciones = await GetCompeticiones();
            Categorias = await GetCategorias();
            Generos = await GetGeneros();
            Grupos = await GetGrupos();

            await LoadClasificacionAsync();
        }

        private async Task LoadClasificacionAsync()
        {
            if (CompeticionSelected == null || CategoriaSelected == null || string.IsNullOrEmpty(GeneroSelected) || GeneroSelected.Equals("0"))
                return;

            Clasificaciones = await _service.GetClasificacionEquiposAsync(int.Parse(CompeticionSelected), int.Parse(CategoriaSelected), GeneroSelected, GrupoSelected);
        }
    }
}
