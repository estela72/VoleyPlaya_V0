using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Text.RegularExpressions;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "ArbitrosOnly")]
    public class ResultadosModel : VPPageModel
    {

        [BindProperty]
        public List<Partido> Partidos { get; set; }

        public ResultadosModel(IEdicionService service) : base(service)
        {
            Grupos = new SelectList(new List<EdicionGrupo>(), "Id", "Item");
            Partidos = new List<Partido>();
        }
        public async Task OnGetAsync(string prueba, int? competicion, int? categoria, string genero, int? grupo)
        {
            await FilterSelection(prueba, competicion, categoria, genero, grupo);

            await GetPartidosAsync();
        }

        public async Task GetPartidosAsync()
        {
            if (PruebaSelected==null||PruebaSelected.Equals("0") || CompeticionSelected == null || CategoriaSelected == null || string.IsNullOrEmpty(GeneroSelected) || GeneroSelected.Equals("0") || GrupoSelected == null)
                return;
            var allPartidos = await _service.GetPartidosFiltradosAsync(PruebaSelected,int.Parse(CompeticionSelected), int.Parse(CategoriaSelected), GeneroSelected, int.Parse(GrupoSelected));
            Partidos = allPartidos.ToList();
        }
        //public async Task<IActionResult> OnPostGuardarAsync(string pruebaId, int? competicionId, int? categoriaId, string generoId, int? grupoId)
        //{
        //    try
        //    {
        //        await FilterSelection(pruebaId, competicionId, categoriaId, generoId, grupoId);
        //        await _service.UpdatePartidosClasificacionAsync(Partidos);
        //    }
        //    catch (Exception x)
        //    {
        //        ErrorMessage = "Se ha producido un error: " + x.Message;
        //    }
        //    await FilterSelection(pruebaId, competicionId, categoriaId, generoId, grupoId);
        //    await GetPartidosAsync();
        //    return Page();
        //}
        public async Task<IActionResult> OnPostAsync(int idPartido, bool activo, int set1L, int set1V, int set2L, int set2V, int set3L, int set3V)
        {
            try
            {
                var str = await _service.ConfirmarResultadoAsync(idPartido, activo, set1L, set1V, set2L, set2V, set3L, set3V);
                return new JsonResult(str);
            }
            catch (Exception x)
            {
                return new JsonResult("Error confirmando resultado: " + x.Message);
            }
        }
    }
}
