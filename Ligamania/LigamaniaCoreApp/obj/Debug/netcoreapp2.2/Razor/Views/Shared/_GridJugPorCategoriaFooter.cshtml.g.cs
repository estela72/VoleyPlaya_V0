#pragma checksum "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8338143d3e495fbe86c13bdd44e0916950c6f95cae422eb9735584898548b92b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GridJugPorCategoriaFooter), @"mvc.1.0.view", @"/Views/Shared/_GridJugPorCategoriaFooter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_GridJugPorCategoriaFooter.cshtml", typeof(AspNetCore.Views_Shared__GridJugPorCategoriaFooter))]
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
#line 1 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
using LigamaniaCoreApp.Models.AdminViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"8338143d3e495fbe86c13bdd44e0916950c6f95cae422eb9735584898548b92b", @"/Views/Shared/_GridJugPorCategoriaFooter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cc15118ad604b470ae866cea065e5e5dcaf3f56265436adea6abd4962110efbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__GridJugPorCategoriaFooter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<TemporadaJornadaJugadorViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(166, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
  
    var competicionesActivas = await ligamaniaService.GetCompeticionesActivasStr();

#line default
#line hidden
            BeginContext(260, 44, true);
            WriteLiteral("<tr>\r\n    <td><b>Total</b></td>\r\n    <td><b>");
            EndContext();
            BeginContext(306, 39, false);
#line 10 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
       Write(Model.Rows.Sum(row => row.Model.Golden));

#line default
#line hidden
            EndContext();
            BeginContext(346, 22, true);
            WriteLiteral("</b></td>\r\n    <td><b>");
            EndContext();
            BeginContext(370, 40, false);
#line 11 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
       Write(Model.Rows.Sum(row => row.Model.SilverA));

#line default
#line hidden
            EndContext();
            BeginContext(411, 22, true);
            WriteLiteral("</b></td>\r\n    <td><b>");
            EndContext();
            BeginContext(435, 40, false);
#line 12 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
       Write(Model.Rows.Sum(row => row.Model.SilverB));

#line default
#line hidden
            EndContext();
            BeginContext(476, 11, true);
            WriteLiteral("</b></td>\r\n");
            EndContext();
#line 13 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
     if (competicionesActivas.Contains("Copa"))
    {

#line default
#line hidden
            BeginContext(543, 15, true);
            WriteLiteral("        <td><b>");
            EndContext();
            BeginContext(560, 37, false);
#line 15 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
           Write(Model.Rows.Sum(row => row.Model.Copa));

#line default
#line hidden
            EndContext();
            BeginContext(598, 11, true);
            WriteLiteral("</b></td>\r\n");
            EndContext();
#line 16 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
    }

#line default
#line hidden
#line 17 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
     if (competicionesActivas.Contains("Supercopa"))
    {

#line default
#line hidden
            BeginContext(677, 15, true);
            WriteLiteral("        <td><b>");
            EndContext();
            BeginContext(694, 42, false);
#line 19 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
           Write(Model.Rows.Sum(row => row.Model.Supercopa));

#line default
#line hidden
            EndContext();
            BeginContext(737, 11, true);
            WriteLiteral("</b></td>\r\n");
            EndContext();
#line 20 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
    }

#line default
#line hidden
#line 21 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
     if (competicionesActivas.Contains("Promocion"))
    {

#line default
#line hidden
            BeginContext(816, 15, true);
            WriteLiteral("        <td><b>");
            EndContext();
            BeginContext(833, 42, false);
#line 23 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
           Write(Model.Rows.Sum(row => row.Model.Promocion));

#line default
#line hidden
            EndContext();
            BeginContext(876, 11, true);
            WriteLiteral("</b></td>\r\n");
            EndContext();
#line 24 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\_GridJugPorCategoriaFooter.cshtml"
    }

#line default
#line hidden
            BeginContext(894, 7, true);
            WriteLiteral("\r\n</tr>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LigamaniaCoreApp.Services.ILigamaniaService ligamaniaService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGrid<TemporadaJornadaJugadorViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
