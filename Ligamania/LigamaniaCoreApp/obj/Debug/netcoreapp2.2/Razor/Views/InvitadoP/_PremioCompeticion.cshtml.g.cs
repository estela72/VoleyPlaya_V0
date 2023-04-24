#pragma checksum "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bf66a8dc1b348ccb4febd6171be5b0269388eea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InvitadoP__PremioCompeticion), @"mvc.1.0.view", @"/Views/InvitadoP/_PremioCompeticion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InvitadoP/_PremioCompeticion.cshtml", typeof(AspNetCore.Views_InvitadoP__PremioCompeticion))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bf66a8dc1b348ccb4febd6171be5b0269388eea", @"/Views/InvitadoP/_PremioCompeticion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1653bea22581b35930f70d9de4acba1f76fe3e61", @"/Views/_ViewImports.cshtml")]
    public class Views_InvitadoP__PremioCompeticion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LigamaniaCoreApp.Models.InvitadoViewModels.PremioCompeticionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(78, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
  
    ViewData["Title"] = "_PremioCompeticion";

#line default
#line hidden
            BeginContext(134, 27, true);
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    ");
            EndContext();
            BeginContext(162, 122, false);
#line 9 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
Write(Html.Display(Model.Competicion + "  (" + Model.Porcentaje.ToString("0") + "%)", new { @class = "tit-premio-competicion" }));

#line default
#line hidden
            EndContext();
            BeginContext(284, 69, true);
            WriteLiteral("\r\n</div>\r\n<div class=\"row\">\r\n    <table class=\"premio-competicion\">\r\n");
            EndContext();
#line 13 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
         foreach (var puesto in Model.Premios)
        {
            string puestoStr = puesto.Puesto.ToString();
            if (puestoStr.Equals("Primero"))
            {
                puestoStr = "Campeón";
            }
            if (Model.Competicion.Equals("Copa") && puestoStr.Equals("Segundo"))
            {
                puestoStr = "Subcampeón";
            }

#line default
#line hidden
            BeginContext(741, 101, true);
            WriteLiteral("            <tr class=\"fila-premio-competicion\">\r\n                <td class=\"col-premio-competicion\">");
            EndContext();
            BeginContext(843, 21, false);
#line 25 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
                                              Write(Html.Label(puestoStr));

#line default
#line hidden
            EndContext();
            BeginContext(864, 58, true);
            WriteLiteral("</td>\r\n                <td class=\"col-premio-competicion\">");
            EndContext();
            BeginContext(923, 25, false);
#line 26 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
                                              Write(Html.Label(puesto.Equipo));

#line default
#line hidden
            EndContext();
            BeginContext(948, 58, true);
            WriteLiteral("</td>\r\n                <td class=\"col-premio-competicion\">");
            EndContext();
            BeginContext(1007, 47, false);
#line 27 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
                                              Write(Html.Label(puesto.Importe.ToString("0") + " €"));

#line default
#line hidden
            EndContext();
            BeginContext(1054, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 29 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\InvitadoP\_PremioCompeticion.cshtml"
        }

#line default
#line hidden
            BeginContext(1091, 26, true);
            WriteLiteral("    </table>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LigamaniaCoreApp.Models.InvitadoViewModels.PremioCompeticionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
