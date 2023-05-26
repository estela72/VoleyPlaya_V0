using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.GestionWeb.Infrastructure;

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
            if (allPartidos.Count > 0 && CompeticionSelected == "3")
                Partidos = allPartidos;
            else
                Partidos = allPartidos.Where(p => p.FechaHora.Date == DateTime.Today && !p.Validado).ToList();
        }
        public async Task<IActionResult> OnPostGuardarAsync(string pruebaId, int? competicionId, int? categoriaId, string generoId, int? grupoId)
        {
            try
            {
                await FilterSelection(pruebaId, competicionId, categoriaId, generoId, grupoId);
                await _service.UpdatePartidosClasificacionAsync(Partidos);
            }
            catch (Exception x)
            {
                ErrorMessage = "Se ha producido un error: " + x.Message;
            }
            await FilterSelection(pruebaId, competicionId, categoriaId, generoId, grupoId);
            await GetPartidosAsync();
            return Page();
        }
    }
}
