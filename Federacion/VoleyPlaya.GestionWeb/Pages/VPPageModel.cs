using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository.Repositories;

namespace VoleyPlaya.GestionWeb.Pages
{

    public class VPPageModel : PageModel
    {
        [ValidateNever] public string CompeticionSelected { get; set; } = default!;
        [ValidateNever] public string CategoriaSelected { get; set; } = default!;
        [ValidateNever] public string GeneroSelected { get; set; } = default!;
        [ValidateNever] public string GrupoSelected { get; set; } = default!;

        [ValidateNever]
        public SelectList Competiciones { get; set; } = default!;
        [ValidateNever] public SelectList Categorias { get; set; } = default!;
        [ValidateNever] public SelectList Generos { get; set; } = default!;
        [ValidateNever] public SelectList Grupos { get; set; } = default!;

        [ValidateNever] public bool SelectCategorias { get; set; } = default!;
        [ValidateNever] public bool SelectGeneros { get; set; } = default!;
        [ValidateNever] public bool SelectGrupos { get; set; } = default!;

        [ValidateNever] public string ErrorMessage { get; set; } = default!;

        protected SelectList InitialSelectList = default;
        protected readonly IEdicionService _service;

        public VPPageModel() { }
        public VPPageModel(IEdicionService service)
        {
            this._service = service;
            SelectionItem item = new SelectionItem { Id = 0, Item = "Seleccionar..." };
            var lista = new List<SelectionItem>() { item };
            InitialSelectList = new SelectList(lista, "Id", "Item", "0");
        }

        protected async Task<SelectList> GetCompeticiones()
        {
            var competiciones = await _service.GetListaCompeticiones();
            if (CompeticionSelected == null) return new SelectList(competiciones, "Id", "Item");
            return new SelectList(competiciones, "Id", "Item", CompeticionSelected);
        }
        protected async Task<SelectList> GetCategorias()
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
        protected async Task<SelectList> GetGeneros()
        {
            if (CompeticionSelected != null && CategoriaSelected != null)
            {
                var generos = await _service.GetListaGeneros(int.Parse(CompeticionSelected), int.Parse(CategoriaSelected));
                SelectGeneros = true;
                return new SelectList(generos, "Item", "Item", GeneroSelected);
            }
            SelectGeneros = false;
            return InitialSelectList;
        }

        protected async Task<SelectList> GetGrupos()
        {
            if (CompeticionSelected != null && CategoriaSelected != null && GeneroSelected != null && GeneroSelected != "0")
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
