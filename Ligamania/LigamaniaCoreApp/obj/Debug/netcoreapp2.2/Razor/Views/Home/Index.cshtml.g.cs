#pragma checksum "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "346dceae5194bd8c0118d75278c00632ea624fe786b73bd8ede79e55e1ebabe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"346dceae5194bd8c0118d75278c00632ea624fe786b73bd8ede79e55e1ebabe4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cc15118ad604b470ae866cea065e5e5dcaf3f56265436adea6abd4962110efbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Ligamanía";
    var settings = await ligamaniaService.GetSettings();

#line default
#line hidden
#line 6 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{
    if (settings.VerNoticias)
    {
        //Ver noticias

#line default
#line hidden
            BeginContext(275, 262, true);
            WriteLiteral(@"        <div class=""flex-container"">
            <h2 class=""text-center"">Para que estés informado...</h2>
            <div id=""grid-noticias"" class=""mvc-grid flex-item-bold-center"" data-name="""" data-filter-mode=""FilterRow"" data-source-url="""">
                ");
            EndContext();
            BeginContext(538, 84, false);
#line 14 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
           Write(Html.AjaxGrid(Url.Action("NoticiasGrid", "Home"), new { id = "ajax-grid-noticias" }));

#line default
#line hidden
            EndContext();
            BeginContext(622, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 17 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
    }
    else if (settings.VerEquiposPretemporada)
    {
        //Ver equipos en pretemporada

#line default
#line hidden
            BeginContext(760, 286, true);
            WriteLiteral(@"        <div class=""flex-container"">
            <h2 class=""text-center"">Información de los equipos para la próxima temporada</h2>
            <div id=""grid-equipos"" class=""mvc-grid flex-item-bold-center"" data-name="""" data-filter-mode=""FilterRow"" data-source-url="""">
                ");
            EndContext();
            BeginContext(1047, 95, false);
#line 24 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
           Write(Html.AjaxGrid(Url.Action("VistaEquiposPretemporada", "Home"), new { id = "ajax-grid-equipos" }));

#line default
#line hidden
            EndContext();
            BeginContext(1142, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 27 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
    }
}
else
{
    //ver pagina para entrar en sesion
    

#line default
#line hidden
#line 32 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
     using (Html.BeginForm("Login", "Account", FormMethod.Get))
    {

#line default
#line hidden
            BeginContext(1311, 121, true);
            WriteLiteral("        <hr />\r\n        <button class=\"btn btn-primary btn-lg\" name=\"btnEntrar\" type=\"submit\">Entrar en sesión</button>\r\n");
            EndContext();
#line 36 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#line 37 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
     using (Html.BeginForm("Register", "Account", FormMethod.Get))
    {

#line default
#line hidden
            BeginContext(1514, 210, true);
            WriteLiteral("        <hr />\r\n        <h3 style=\"color:red\">¿Aún no estás registrado en el mejor juego online de Fútbol?</h3>\r\n        <button class=\"btn btn-success btn-lg\" name=\"btnEntrar\" type=\"submit\">Registro</button>\r\n");
            EndContext();
#line 42 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#line 42 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Home\Index.cshtml"
     
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
