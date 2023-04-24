#pragma checksum "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ADMINP\TemporadaActualJugadoresGrid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a03ad7773043b1cef360dd8e72643d96c0fc5eb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ADMINP_TemporadaActualJugadoresGrid), @"mvc.1.0.view", @"/Views/ADMINP/TemporadaActualJugadoresGrid.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ADMINP/TemporadaActualJugadoresGrid.cshtml", typeof(AspNetCore.Views_ADMINP_TemporadaActualJugadoresGrid))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp;

#line default
#line hidden
#line 4 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Models;

#line default
#line hidden
#line 5 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Models.AccountViewModels;

#line default
#line hidden
#line 6 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Models.ManageViewModels;

#line default
#line hidden
#line 7 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;

#line default
#line hidden
#line 8 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Services;

#line default
#line hidden
#line 9 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Data;

#line default
#line hidden
#line 11 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#line 4 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ADMINP\TemporadaActualJugadoresGrid.cshtml"
using LigamaniaCoreApp.Models.AdminViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a03ad7773043b1cef360dd8e72643d96c0fc5eb5", @"/Views/ADMINP/TemporadaActualJugadoresGrid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1653bea22581b35930f70d9de4acba1f76fe3e61", @"/Views/_ViewImports.cshtml")]
    public class Views_ADMINP_TemporadaActualJugadoresGrid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TemporadaJugadorViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(277, 806, false);
#line 9 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ADMINP\TemporadaActualJugadoresGrid.cshtml"
Write(Html
            .Grid(Model)
            .Build(columns =>
            {
                columns.Add(model => model.Jugador).Titled("Jugador");
                columns.Add(model => model.Activo ? "Activo" : "Inactivo").Titled("Activo/Inactivo");
                columns.Add(model => model.Club).Titled("Club");
                columns.Add(model => model.Puesto).Titled("Puesto");
            })
            .Css("webgrid-noticiaAplicacion") // Overwrites all classes with the new ones
            .WithFilterMode(GridFilterMode.FilterRow)
            .Empty("No hay jugadores")
            .Id("ajax-grid-temporadaactualjugadores")
            .Pageable(pager =>
            {
                pager.RowsPerPage = 10;
            })
            .Filterable()
            .Sortable()
    );

#line default
#line hidden
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TemporadaJugadorViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
