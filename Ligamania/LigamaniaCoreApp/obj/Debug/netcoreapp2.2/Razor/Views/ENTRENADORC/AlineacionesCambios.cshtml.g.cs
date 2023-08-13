#pragma checksum "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ba1cda6f8c2f842cc8f86e06f27627b93ec53bf388c4f458259634c917d5341"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ENTRENADORC_AlineacionesCambios), @"mvc.1.0.view", @"/Views/ENTRENADORC/AlineacionesCambios.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ENTRENADORC/AlineacionesCambios.cshtml", typeof(AspNetCore.Views_ENTRENADORC_AlineacionesCambios))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4ba1cda6f8c2f842cc8f86e06f27627b93ec53bf388c4f458259634c917d5341", @"/Views/ENTRENADORC/AlineacionesCambios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cc15118ad604b470ae866cea065e5e5dcaf3f56265436adea6abd4962110efbf", @"/Views/_ViewImports.cshtml")]
    public class Views_ENTRENADORC_AlineacionesCambios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LigamaniaCoreApp.Models.EntrenadorViewModels.AlineacionesCambiosViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(83, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
  
    ViewData["Title"] = "Alineaciones y Cambios";

#line default
#line hidden
            BeginContext(143, 30, true);
            WriteLiteral("<h2>Alineaciones y Cambios de ");
            EndContext();
            BeginContext(174, 16, false);
#line 6 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
                         Write(Model.Entrenador);

#line default
#line hidden
            EndContext();
            BeginContext(190, 9, true);
            WriteLiteral("</h2>\r\n\r\n");
            EndContext();
#line 8 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
   
    if (Model.Equipos!=null && Model.Equipos.Count>0)
    {
        var equipos = Model.Equipos.OrderBy(e => e.OrdenCompeticion).ThenBy(e=>e.OrdenCategoria).ToList();
        

#line default
#line hidden
#line 12 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
         foreach (var equipo in equipos)
        {
            

#line default
#line hidden
            BeginContext(440, 57, false);
#line 14 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
       Write(await Html.PartialAsync("_AlineacionCambioEquipo",equipo));

#line default
#line hidden
            EndContext();
#line 14 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
                                                                      
        }

#line default
#line hidden
#line 15 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(534, 12, true);
            WriteLiteral("        <h2>");
            EndContext();
            BeginContext(547, 16, false);
#line 19 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
       Write(Model.Entrenador);

#line default
#line hidden
            EndContext();
            BeginContext(563, 162, true);
            WriteLiteral(" no tiene equipos activos en la temporada actual o bien aún no están abiertas las alineaciones. Si tienes dudas, consulta con el administrador de Ligamanía</h2>\r\n");
            EndContext();
#line 20 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ENTRENADORC\AlineacionesCambios.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LigamaniaCoreApp.Models.EntrenadorViewModels.AlineacionesCambiosViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
