#pragma checksum "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "aaa150b9f450c40ed78e12c69dca4f116ded9eb314032aeee6e78f3f8ba2cca3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_MvcGrid__net3__Pager), @"mvc.1.0.view", @"/Views/Shared/MvcGrid .net3/_Pager.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/MvcGrid .net3/_Pager.cshtml", typeof(AspNetCore.Views_Shared_MvcGrid__net3__Pager))]
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
#line 1 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"aaa150b9f450c40ed78e12c69dca4f116ded9eb314032aeee6e78f3f8ba2cca3", @"/Views/Shared/MvcGrid .net3/_Pager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cc15118ad604b470ae866cea065e5e5dcaf3f56265436adea6abd4962110efbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_MvcGrid__net3__Pager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGridPager>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
  
    Int32 totalPages = Model.TotalPages;
    Int32 currentPage = Model.CurrentPage;
    Int32 firstDisplayPage = Model.FirstDisplayPage;

#line default
#line hidden
            BeginContext(197, 6, true);
            WriteLiteral("\r\n<div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 203, "\"", 243, 2);
            WriteAttributeValue("", 211, "mvc-grid-pager", 211, 14, true);
#line 10 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
WriteAttributeValue(" ", 225, Model.CssClasses, 226, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(244, 23, true);
            WriteLiteral(" data-show-page-sizes=\"");
            EndContext();
            BeginContext(268, 19, false);
#line 10 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                                               Write(Model.ShowPageSizes);

#line default
#line hidden
            EndContext();
            BeginContext(287, 4, true);
            WriteLiteral("\">\r\n");
            EndContext();
#line 11 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
     if (totalPages > 0)
    {
        if (currentPage > 1)
        {

#line default
#line hidden
            BeginContext(365, 111, true);
            WriteLiteral("            <button type=\"button\" data-page=\"1\">&laquo;</button>\r\n            <button type=\"button\" data-page=\"");
            EndContext();
            BeginContext(478, 15, false);
#line 16 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                         Write(currentPage - 1);

#line default
#line hidden
            EndContext();
            BeginContext(494, 21, true);
            WriteLiteral("\">&lsaquo;</button>\r\n");
            EndContext();
#line 17 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(551, 167, true);
            WriteLiteral("            <button type=\"button\" class=\"disabled\" tabindex=\"-1\">&laquo;</button>\r\n            <button type=\"button\" class=\"disabled\" tabindex=\"-1\">&lsaquo;</button>\r\n");
            EndContext();
#line 22 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
        }
        for (Int32 page = firstDisplayPage; page <= totalPages && page < firstDisplayPage + Model.PagesToDisplay; page++)
        {
            if (page == currentPage)
            {

#line default
#line hidden
            BeginContext(916, 64, true);
            WriteLiteral("                <button type=\"button\" class=\"active\" data-page=\"");
            EndContext();
            BeginContext(982, 4, false);
#line 27 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                                            Write(page);

#line default
#line hidden
            EndContext();
            BeginContext(987, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(991, 4, false);
#line 27 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                                                     Write(page);

#line default
#line hidden
            EndContext();
            BeginContext(996, 11, true);
            WriteLiteral("</button>\r\n");
            EndContext();
#line 28 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1055, 49, true);
            WriteLiteral("                <button type=\"button\" data-page=\"");
            EndContext();
            BeginContext(1106, 4, false);
#line 31 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                             Write(page);

#line default
#line hidden
            EndContext();
            BeginContext(1111, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(1115, 4, false);
#line 31 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                                      Write(page);

#line default
#line hidden
            EndContext();
            BeginContext(1120, 11, true);
            WriteLiteral("</button>\r\n");
            EndContext();
#line 32 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
            }
        }
        if (currentPage < totalPages)
        {

#line default
#line hidden
            BeginContext(1207, 45, true);
            WriteLiteral("            <button type=\"button\" data-page=\"");
            EndContext();
            BeginContext(1254, 15, false);
#line 36 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                         Write(currentPage + 1);

#line default
#line hidden
            EndContext();
            BeginContext(1270, 66, true);
            WriteLiteral("\">&rsaquo;</button>\r\n            <button type=\"button\" data-page=\"");
            EndContext();
            BeginContext(1337, 10, false);
#line 37 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                        Write(totalPages);

#line default
#line hidden
            EndContext();
            BeginContext(1347, 20, true);
            WriteLiteral("\">&raquo;</button>\r\n");
            EndContext();
#line 38 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1403, 167, true);
            WriteLiteral("            <button type=\"button\" class=\"disabled\" tabindex=\"-1\">&rsaquo;</button>\r\n            <button type=\"button\" class=\"disabled\" tabindex=\"-1\">&raquo;</button>\r\n");
            EndContext();
#line 43 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
        }
        if (Model.ShowPageSizes)
        {

#line default
#line hidden
            BeginContext(1626, 47, true);
            WriteLiteral("            <div class=\"mvc-grid-page-sizes\">\r\n");
            EndContext();
#line 47 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                 if (Model.PageSizes.Count > 0)
                {

#line default
#line hidden
            BeginContext(1741, 58, true);
            WriteLiteral("                    <select class=\"mvc-grid-pager-rows\">\r\n");
            EndContext();
#line 50 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                         foreach (KeyValuePair<Int32, String> size in Model.PageSizes)
                        {
                            if (Model.RowsPerPage == size.Key)
                            {

#line default
#line hidden
            BeginContext(2009, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(2041, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaa150b9f450c40ed78e12c69dca4f116ded9eb314032aeee6e78f3f8ba2cca312633", async() => {
                BeginContext(2077, 10, false);
#line 54 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                                              Write(size.Value);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 54 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                   WriteLiteral(size.Key);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2096, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 55 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(2194, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(2226, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaa150b9f450c40ed78e12c69dca4f116ded9eb314032aeee6e78f3f8ba2cca315350", async() => {
                BeginContext(2253, 10, false);
#line 58 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                                     Write(size.Value);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 58 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                                   WriteLiteral(size.Key);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2272, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 59 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                            }
                        }

#line default
#line hidden
            BeginContext(2332, 31, true);
            WriteLiteral("                    </select>\r\n");
            EndContext();
#line 62 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2423, 54, true);
            WriteLiteral("                    <input class=\"mvc-grid-pager-rows\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2477, "\"", 2503, 1);
#line 65 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
WriteAttributeValue("", 2485, Model.RowsPerPage, 2485, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2504, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 66 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
                }

#line default
#line hidden
            BeginContext(2528, 20, true);
            WriteLiteral("            </div>\r\n");
            EndContext();
#line 68 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2584, 60, true);
            WriteLiteral("            <input class=\"mvc-grid-pager-rows\" type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2644, "\"", 2670, 1);
#line 71 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
WriteAttributeValue("", 2652, Model.RowsPerPage, 2652, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2671, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 72 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
        }
    }
    else
    {

#line default
#line hidden
            BeginContext(2711, 56, true);
            WriteLiteral("        <input class=\"mvc-grid-pager-rows\" type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2767, "\"", 2793, 1);
#line 76 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
WriteAttributeValue("", 2775, Model.RowsPerPage, 2775, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2794, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 77 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\Shared\MvcGrid .net3\_Pager.cshtml"
    }

#line default
#line hidden
            BeginContext(2806, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGridPager> Html { get; private set; }
    }
}
#pragma warning restore 1591
