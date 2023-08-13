#pragma checksum "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\INVITADOH\_historialTemporadaCategoriaPremios.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4e56c405c66bbf0026d9eab3d8306187c75c73a92139c58eaee8837bbdd7575f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_INVITADOH__historialTemporadaCategoriaPremios), @"mvc.1.0.view", @"/Views/INVITADOH/_historialTemporadaCategoriaPremios.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/INVITADOH/_historialTemporadaCategoriaPremios.cshtml", typeof(AspNetCore.Views_INVITADOH__historialTemporadaCategoriaPremios))]
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
#line 1 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp;

#line default
#line hidden
#line 4 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Models;

#line default
#line hidden
#line 5 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Models.AccountViewModels;

#line default
#line hidden
#line 6 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Models.ManageViewModels;

#line default
#line hidden
#line 7 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;

#line default
#line hidden
#line 8 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Services;

#line default
#line hidden
#line 9 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using LigamaniaCoreApp.Data;

#line default
#line hidden
#line 11 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#line 1 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\INVITADOH\_historialTemporadaCategoriaPremios.cshtml"
using LigamaniaCoreApp.Models.InvitadoViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4e56c405c66bbf0026d9eab3d8306187c75c73a92139c58eaee8837bbdd7575f", @"/Views/INVITADOH/_historialTemporadaCategoriaPremios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cc15118ad604b470ae866cea065e5e5dcaf3f56265436adea6abd4962110efbf", @"/Views/_ViewImports.cshtml")]
    public class Views_INVITADOH__historialTemporadaCategoriaPremios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PremioHistoricoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\INVITADOH\_historialTemporadaCategoriaPremios.cshtml"
  
    var premios = Model.OrderBy(p => p.Premio).ToList();

#line default
#line hidden
            BeginContext(162, 107, true);
            WriteLiteral("<div id=\"grid-premios\" class=\"mvc-grid\" data-name=\"\" data-filter-mode=\"FilterRow\" data-source-url=\"\">\r\n    ");
            EndContext();
            BeginContext(271, 430, false);
#line 7 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\INVITADOH\_historialTemporadaCategoriaPremios.cshtml"
Write(Html
        .Grid(premios)
        .Build(columns =>
        {
            columns.Add(model => !model.EsPichichi ? model.PremioTxt : "Pichichi").Titled("Premio").Css("grid-historial-row-premio");
            columns.Add(model => @Html.ActionLink(model.Equipo,"HistorialEquipo","InvitadoH", new { equipo=@model.Equipo })).Titled("Equipo").Css("grid-historial-row-equipo");
        })
        .Empty("No hay premios")
    );

#line default
#line hidden
            EndContext();
            BeginContext(702, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PremioHistoricoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
