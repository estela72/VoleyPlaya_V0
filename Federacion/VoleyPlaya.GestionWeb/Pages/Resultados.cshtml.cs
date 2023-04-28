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
    [Authorize(Policy = "ResultadosOnly")]
    public class ResultadosModel : VPPageModel
    {
        IEdicionService _service;

        [BindProperty]
        public int EdicionSelected { get; set; }

        public SelectList Ediciones { get; set; } = default!;

        [BindProperty]
        public int GrupoSelected { get; set; }

        public SelectList Grupos { get; set; } = default!;

        [BindProperty]
        public List<Partido> Partidos { get; set; }        

        public ResultadosModel(IEdicionService service)
        {
            _service = service;
            Ediciones = new SelectList(new List<Edicion>(), "Id", "Item");
            Grupos = new SelectList(new List<EdicionGrupo>(), "Id", "Item");
        }
        public async Task OnGetAsync(int EdicionSelected, int GrupoSelected)
        {
            this.EdicionSelected = EdicionSelected;
            this.GrupoSelected = GrupoSelected;
            await GetLists();
            await GetPartidosAsync();
        }

        private async Task GetLists()
        {
            await GetListaEdiciones();
            await GetListaGrupos();
        }

        private async Task GetListaGrupos()
        {
            var grupos = await _service.GetListaGrupos(EdicionSelected);
            Grupos = new SelectList(grupos, "Id", "Item", GrupoSelected);
        }

        private async Task GetListaEdiciones()
        {
            var ediciones = await _service.GetListaEdiciones();
            Ediciones = new SelectList(ediciones, "Id", "Item", EdicionSelected);
        }

        public async Task GetPartidosAsync()
        {

            Partidos = await _service.GetPartidosFiltradosAsync(EdicionSelected, GrupoSelected);
        }
        public async Task<IActionResult> OnGetGruposAsync(int competicionId)
        {
            EdicionSelected = competicionId;
            await GetListaGrupos();
            return new JsonResult(Grupos);
        }
        public async Task<IActionResult> OnPostGuardarAsync()
        {
            //if (!ModelState.IsValid)
            //    return Page();

            await _service.UpdatePartidosClasificacionAsync(GrupoSelected, Partidos);
            await GetLists();
            return Page();
        }
    }
}
