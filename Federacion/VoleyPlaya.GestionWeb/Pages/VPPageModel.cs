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
        [ValidateNever] public string PruebaSelected { get; set; } = default!;
        [ValidateNever] public string CompeticionSelected { get; set; } = default!;
        [ValidateNever] public string CategoriaSelected { get; set; } = default!;
        [ValidateNever] public string GeneroSelected { get; set; } = default!;
        [ValidateNever] public string GrupoSelected { get; set; } = default!;


        [ValidateNever] public SelectList Pruebas { get; set; } = default!;
        [ValidateNever] public SelectList Competiciones { get; set; } = default!;
        [ValidateNever] public SelectList Categorias { get; set; } = default!;
        [ValidateNever] public SelectList Generos { get; set; } = default!;
        [ValidateNever] public SelectList Grupos { get; set; } = default!;

        [ValidateNever] public bool SelectCompeticiones { get; set; } = default!;
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

        protected async Task<SelectList> GetPruebas()
        {
            var pruebas = await _service.GetListaPruebas();
            return new SelectList(pruebas, "Item", "Item", PruebaSelected);
        }
        protected async Task<SelectList> GetCompeticiones()
        {
            if (PruebaSelected != null && PruebaSelected != "0")
            {
                var competiciones = await _service.GetListaCompeticiones(PruebaSelected);
                SelectCompeticiones = true;
                return new SelectList(competiciones, "Id", "Item", CompeticionSelected);
            }
            SelectCompeticiones = false;
            return InitialSelectList;
        }
        protected async Task<SelectList> GetCategorias()
        {
            if (CompeticionSelected != null && PruebaSelected!=null && PruebaSelected!="0")
            {
                var categorias = await _service.GetListaCategorias(PruebaSelected, int.Parse(CompeticionSelected));
                SelectCategorias = true;
                return new SelectList(categorias, "Id", "Item", CategoriaSelected);
            }
            SelectCategorias = false;
            return InitialSelectList;
        }
        protected async Task<SelectList> GetGeneros()
        {
            if (CompeticionSelected != null && CategoriaSelected != null && PruebaSelected != null && PruebaSelected != "0")
            {
                var generos = await _service.GetListaGeneros(PruebaSelected, int.Parse(CompeticionSelected), int.Parse(CategoriaSelected));
                SelectGeneros = true;
                return new SelectList(generos, "Item", "Item", GeneroSelected);
            }
            SelectGeneros = false;
            return InitialSelectList;
        }

        protected async Task<SelectList> GetGrupos()
        {
            if (CompeticionSelected != null && CategoriaSelected != null && GeneroSelected != null && GeneroSelected != "0" && PruebaSelected != null && PruebaSelected != "0")
            {
                var grupos = await _service.GetListaGrupos(PruebaSelected, int.Parse(CompeticionSelected), int.Parse(CategoriaSelected), GeneroSelected);
                SelectGrupos = true;
                return new SelectList(grupos, "Id", "Item", GrupoSelected);
            }
            SelectGrupos = false;
            return InitialSelectList;
        }
        protected async Task FilterSelection(string prueba, int? competicion, int? categoria, string genero, int? grupo)
        {
            PruebaSelected = prueba;
            CompeticionSelected = competicion is not null and > 0 ? competicion.ToString() : null;
            CategoriaSelected = categoria is not null and > 0 ? categoria.ToString() : null;
            GeneroSelected = genero;
            GrupoSelected = grupo is not null and > 0 ? grupo.ToString() : null;

            Pruebas = await GetPruebas();
            Competiciones = await GetCompeticiones();
            Categorias = await GetCategorias();
            Generos = await GetGeneros();
            Grupos = await GetGrupos();
        }
    }
}
