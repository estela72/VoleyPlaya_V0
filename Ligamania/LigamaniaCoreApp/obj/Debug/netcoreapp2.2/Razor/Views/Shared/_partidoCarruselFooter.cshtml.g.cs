#pragma checksum "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62a2bd638aa7a94d638c6a11fb8e2012fbedaf05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__partidoCarruselFooter), @"mvc.1.0.view", @"/Views/Shared/_partidoCarruselFooter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_partidoCarruselFooter.cshtml", typeof(AspNetCore.Views_Shared__partidoCarruselFooter))]
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
#line 1 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
using LigamaniaCoreApp.Models.ManagerViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62a2bd638aa7a94d638c6a11fb8e2012fbedaf05", @"/Views/Shared/_partidoCarruselFooter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1653bea22581b35930f70d9de4acba1f76fe3e61", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__partidoCarruselFooter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<AlineacionViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
  
    var verCriterioParam = "false";
    if (ViewData["verCriterio"] != null) { verCriterioParam = ViewData["verCriterio"].ToString(); }
    var verCriterio = (verCriterioParam == "true") ? true : false;
    if (verCriterio)
    {

#line default
#line hidden
            BeginContext(325, 82, true);
            WriteLiteral("        <tr>\r\n            <td colspan=\"3\"><b>Totales</b></td>\r\n            <td><b>");
            EndContext();
            BeginContext(409, 35, false);
#line 11 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
               Write(Model.Rows.Sum(row => row.Model.GF));

#line default
#line hidden
            EndContext();
            BeginContext(445, 30, true);
            WriteLiteral("</b></td>\r\n            <td><b>");
            EndContext();
            BeginContext(477, 35, false);
#line 12 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
               Write(Model.Rows.Sum(row => row.Model.GC));

#line default
#line hidden
            EndContext();
            BeginContext(513, 30, true);
            WriteLiteral("</b></td>\r\n            <td><b>");
            EndContext();
            BeginContext(545, 47, false);
#line 13 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
               Write(Model.Rows.Sum(row => row.Model.MinutosJugados));

#line default
#line hidden
            EndContext();
            BeginContext(593, 30, true);
            WriteLiteral("</b></td>\r\n            <td><b>");
            EndContext();
            BeginContext(625, 46, false);
#line 14 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
               Write(Model.Rows.Sum(row => row.Model.TarjetasRojas));

#line default
#line hidden
            EndContext();
            BeginContext(672, 30, true);
            WriteLiteral("</b></td>\r\n            <td><b>");
            EndContext();
            BeginContext(704, 50, false);
#line 15 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
               Write(Model.Rows.Sum(row => row.Model.TarjetasAmarillas));

#line default
#line hidden
            EndContext();
            BeginContext(755, 26, true);
            WriteLiteral("</b></td>\r\n        </tr>\r\n");
            EndContext();
#line 17 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_partidoCarruselFooter.cshtml"
        }
    

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGrid<AlineacionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
