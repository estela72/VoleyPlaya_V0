#pragma checksum "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Herramientas\CambiosEquipo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a60fc09cae52cbb76f464f829e2454d24bc4476"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Herramientas_CambiosEquipo), @"mvc.1.0.view", @"/Views/Herramientas/CambiosEquipo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Herramientas/CambiosEquipo.cshtml", typeof(AspNetCore.Views_Herramientas_CambiosEquipo))]
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
#line 1 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Herramientas\CambiosEquipo.cshtml"
using LigamaniaCoreApp.Models.HerramientasViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a60fc09cae52cbb76f464f829e2454d24bc4476", @"/Views/Herramientas/CambiosEquipo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1653bea22581b35930f70d9de4acba1f76fe3e61", @"/Views/_ViewImports.cshtml")]
    public class Views_Herramientas_CambiosEquipo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<CambioEquipoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(98, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Herramientas\CambiosEquipo.cshtml"
  
    ViewData["Title"] = "Cambios de equipos";

#line default
#line hidden
            BeginContext(154, 34, true);
            WriteLiteral("<div class=\"flex-container\">\r\n    ");
            EndContext();
            BeginContext(190, 447, false);
#line 8 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Herramientas\CambiosEquipo.cshtml"
Write(Html.Grid(Model)
        .Build(columns =>
        {
            columns.Add(model => model.Temporada).Titled("Temporada");
            columns.Add(model => model.EquipoOriginal).Titled("Equipo");
            columns.Add(model => model.CambioPor).Titled("Cambio por");
        })
        .Css("webgrid-cambios") // Overwrites all classes with the new ones
        .Empty("No hay cambios de equipos")
        .Id("ajax-grid-cambios")
    );

#line default
#line hidden
            EndContext();
            BeginContext(638, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<CambioEquipoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
