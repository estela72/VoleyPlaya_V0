#pragma checksum "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66f02308a54065a4701b93383bac707dacc8f053"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ClasificacionesPartial), @"mvc.1.0.view", @"/Views/Shared/_ClasificacionesPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ClasificacionesPartial.cshtml", typeof(AspNetCore.Views_Shared__ClasificacionesPartial))]
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
#line 1 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
using LigamaniaCoreApp.Models.GlobalViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66f02308a54065a4701b93383bac707dacc8f053", @"/Views/Shared/_ClasificacionesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1653bea22581b35930f70d9de4acba1f76fe3e61", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ClasificacionesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClasificacionViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
     if (Model.Any())
    {

#line default
#line hidden
            BeginContext(127, 54, true);
            WriteLiteral("        <h2 class=\"text-center\">Clasificaciones</h2>\r\n");
            EndContext();
#line 7 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
    }

#line default
#line hidden
#line 9 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
     foreach (var categoria in Model)
    {

#line default
#line hidden
            BeginContext(236, 33, true);
            WriteLiteral("        <style type=\"text/css\">\r\n");
            EndContext();
#line 12 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
             foreach(var premio in categoria.Premios)
            {
                

#line default
#line hidden
            BeginContext(356, 87, false);
#line 14 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
           Write(string.Format(".premio-{0} {{ background-color:{1}; }}  ", premio.Id, premio.ColorName));

#line default
#line hidden
            EndContext();
#line 14 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
                                                                                                        
            }

#line default
#line hidden
            BeginContext(460, 60, true);
            WriteLiteral("        </style>\r\n        <h3><span style=\"color:darkkhaki\">");
            EndContext();
            BeginContext(521, 19, false);
#line 17 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
                                     Write(categoria.Categoria);

#line default
#line hidden
            EndContext();
            BeginContext(540, 14, true);
            WriteLiteral("</span></h3>\r\n");
            EndContext();
            BeginContext(563, 63, false);
#line 18 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
   Write(await Html.PartialAsync("_ClasificacionReferencias", categoria));

#line default
#line hidden
            EndContext();
            BeginContext(628, 16, true);
            WriteLiteral("        <hr />\r\n");
            EndContext();
            BeginContext(653, 61, false);
#line 20 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
   Write(await Html.PartialAsync("_ClasificacionCategoria", categoria));

#line default
#line hidden
            EndContext();
#line 20 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\Shared\_ClasificacionesPartial.cshtml"
                                                                      
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClasificacionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
