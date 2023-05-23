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

            await GetPartidosAsync();
        }

        public async Task GetPartidosAsync()
        {
            if (CompeticionSelected == null || CategoriaSelected == null || string.IsNullOrEmpty(GeneroSelected) || GeneroSelected.Equals("0") || GrupoSelected == null)
                return;
            var allPartidos = await _service.GetPartidosFiltradosAsync(int.Parse(CompeticionSelected), int.Parse(CategoriaSelected), GeneroSelected, int.Parse(GrupoSelected));
            if (allPartidos.Count > 0 && CompeticionSelected == "3")
                Partidos = allPartidos;
            else
                Partidos = allPartidos.Where(p => p.FechaHora.Date == DateTime.Today).ToList();
        }
        public async Task<IActionResult> OnPostGuardarAsync(int? competicionId, int? categoriaId, string generoId, int? grupoId)
        {
            try
            {
                CompeticionSelected = competicionId is not null and > 0 ? competicionId.ToString() : null;
                CategoriaSelected = categoriaId is not null and > 0 ? categoriaId.ToString() : null;
                GeneroSelected = generoId;
                GrupoSelected = grupoId is not null and > 0 ? grupoId.ToString() : null;

                await _service.UpdatePartidosClasificacionAsync(Partidos);
            }
            catch (Exception x)
            {
                ErrorMessage = "Se ha producido un error: " + x.Message;
            }
            Competiciones = await GetCompeticiones();
            Categorias = await GetCategorias();
            Generos = await GetGeneros();
            Grupos = await GetGrupos();
            await GetPartidosAsync();
            return Page();
        }
    }
}
