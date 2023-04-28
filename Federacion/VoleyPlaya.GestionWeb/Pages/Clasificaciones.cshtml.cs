using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Runtime.InteropServices;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "ResultadosOnly")]
    public class ClasificacionesModel : VPPageModel
    {
        [BindProperty]
        public string CompeticionSelected { get; set; }
        [BindProperty]
        public string CategoriaSelected { get; set; }
        [BindProperty]
        public string GeneroSelected { get; set; }
        [BindProperty]
        public string GrupoSelected { get; set; }

        public SelectList Competiciones { get; set; }
        public SelectList Categorias { get; set; }
        public SelectList Generos { get; set; }
        public SelectList Grupos { get; set; }

        public bool SelectCategorias { get; set; }
        public bool SelectGeneros { get; set; }
        public bool SelectGrupos { get; set; }

        public List<EdicionGrupo> Clasificaciones { get; set; }

        private readonly IEdicionService _service;
        private SelectList InitialSelectList;

        public ClasificacionesModel(IEdicionService service)
        {
            _service = service;
            SelectionItem item = new SelectionItem { Id = 0, Item = "Seleccionar..." };
            var lista = new List<SelectionItem>() { item };
            InitialSelectList = new SelectList(lista, "Id","Item","0");
        }

        public async Task OnGetAsync(int? competicion, int? categoria, string genero, int? grupo)
        {
            CompeticionSelected = competicion != null && competicion > 0 ? competicion.ToString():null;
            CategoriaSelected = categoria!=null && categoria>0? categoria!.ToString():null;
            GeneroSelected = genero;
            GrupoSelected = grupo!=null&&grupo>0 ? grupo.ToString():null;

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

        private async Task<SelectList> GetCompeticiones()
        {
            var competiciones = await _service.GetListaCompeticiones();
            if (CompeticionSelected==null) return new SelectList(competiciones, "Id", "Item");
            return new SelectList(competiciones, "Id", "Item", CompeticionSelected);
        }
        private async Task<SelectList> GetCategorias()
        {
            if (CompeticionSelected != null)
            {
                var categorias = await _service.GetListaCategorias(int.Parse(CompeticionSelected));
                SelectCategorias = true;
                return new SelectList(categorias, "Id", "Item", CategoriaSelected);
            }
            SelectCategorias = false;
            return InitialSelectList;
        }
        private async Task<SelectList> GetGeneros()
        {
            if (CompeticionSelected !=null && CategoriaSelected!=null)
            {
                var generos = await _service.GetListaGeneros(int.Parse(CompeticionSelected), int.Parse(CategoriaSelected));
                SelectGeneros = true;
                return new SelectList(generos, "Item", "Item", GeneroSelected);
            }
            SelectGeneros = false;
            return InitialSelectList;
        }

        private async Task<SelectList> GetGrupos()
        {
            if (CompeticionSelected != null && CategoriaSelected != null && GeneroSelected !=null && GeneroSelected!="0")
            {
                var grupos = await _service.GetListaGrupos(int.Parse(CompeticionSelected), int.Parse(CategoriaSelected), GeneroSelected);
                SelectGrupos = true;
                return new SelectList(grupos, "Id", "Item", GrupoSelected);
            }
            SelectGrupos = false;
            return InitialSelectList;
        }
    }
}
