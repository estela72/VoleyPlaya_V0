#pragma checksum "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db984c9116536e512a3d74e3af35c3b35ba9b099"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerC__NestedReferenciasGrid), @"mvc.1.0.view", @"/Views/ManagerC/_NestedReferenciasGrid.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManagerC/_NestedReferenciasGrid.cshtml", typeof(AspNetCore.Views_ManagerC__NestedReferenciasGrid))]
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
#line 11 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\_ViewImports.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#line 1 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
using LigamaniaCoreApp.Models.ManagerViewModels;

#line default
#line hidden
#line 2 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
using LigamaniaCoreApp.Data;

#line default
#line hidden
#line 4 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
using System.Drawing;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db984c9116536e512a3d74e3af35c3b35ba9b099", @"/Views/ManagerC/_NestedReferenciasGrid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1653bea22581b35930f70d9de4acba1f76fe3e61", @"/Views/_ViewImports.cshtml")]
    public class Views_ManagerC__NestedReferenciasGrid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IGrid<CompeticionCategoriaViewModel>>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(148, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
  
    var listaSiNo = new SelectList(new List<string> { LigamaniaEnum.eSINO.SI.ToString(), LigamaniaEnum.eSINO.NO.ToString() });

#line default
#line hidden
            BeginContext(285, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(453, 74, true);
            WriteLiteral("\r\n<div class=\"mvc-grid\">\r\n    <table>\r\n        <thead>\r\n            <tr>\r\n");
            EndContext();
#line 18 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                 foreach (IGridColumn column in Model.Columns)
                {

#line default
#line hidden
            BeginContext(610, 79, true);
            WriteLiteral("                    <th>\r\n                        <span class=\"mvc-grid-title\">");
            EndContext();
            BeginContext(690, 12, false);
#line 21 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                                                Write(column.Title);

#line default
#line hidden
            EndContext();
            BeginContext(702, 36, true);
            WriteLiteral("</span>\r\n                    </th>\r\n");
            EndContext();
#line 23 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                }

#line default
#line hidden
            BeginContext(757, 54, true);
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 27 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
             if (Model.Rows.Any())
            {
                foreach (IGridRow<CompeticionCategoriaViewModel> row in Model.Rows)
                {

#line default
#line hidden
            BeginContext(966, 23, true);
            WriteLiteral("                    <tr");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 989, "\"", 1012, 1);
#line 31 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
WriteAttributeValue("", 997, row.CssClasses, 997, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1013, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 32 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                         foreach (IGridColumn column in Model.Columns)
                        {

#line default
#line hidden
            BeginContext(1115, 31, true);
            WriteLiteral("                            <td");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1146, "\"", 1172, 1);
#line 34 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
WriteAttributeValue("", 1154, column.CssClasses, 1154, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1173, 31, true);
            WriteLiteral(" style=\"background-color:grey\">");
            EndContext();
            BeginContext(1205, 20, false);
#line 34 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                                                                                    Write(column.ValueFor(row));

#line default
#line hidden
            EndContext();
            BeginContext(1225, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 35 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                        }

#line default
#line hidden
            BeginContext(1259, 50, true);
            WriteLiteral("                    </tr>\r\n                    <tr");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1309, "\"", 1332, 1);
#line 37 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
WriteAttributeValue("", 1317, row.CssClasses, 1317, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1333, 150, true);
            WriteLiteral(">\r\n                        <td> <button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#addReferenciaModal\" data-competicion=\"");
            EndContext();
            BeginContext(1484, 21, false);
#line 38 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                                                                                                                                              Write(row.Model.Competicion);

#line default
#line hidden
            EndContext();
            BeginContext(1505, 18, true);
            WriteLiteral("\" data-categoria=\"");
            EndContext();
            BeginContext(1524, 19, false);
#line 38 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                                                                                                                                                                                      Write(row.Model.Categoria);

#line default
#line hidden
            EndContext();
            BeginContext(1543, 53, true);
            WriteLiteral("\">Agregar</button> </td>\r\n                    </tr>\r\n");
            EndContext();
#line 40 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                    if (row.Model.Referencias.Any())
                    {

#line default
#line hidden
            BeginContext(1673, 61, true);
            WriteLiteral("                        <tr>\r\n                            <td");
            EndContext();
            BeginWriteAttribute("colspan", " colspan=\"", 1734, "\"", 1766, 1);
#line 43 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
WriteAttributeValue("", 1744, Model.Columns.Count(), 1744, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1767, 35, true);
            WriteLiteral(">\r\n                                ");
            EndContext();
            BeginContext(1804, 2374, false);
#line 44 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                            Write(Html
                                    .Grid(row.Model.Referencias)
                                    .Build(columns =>
                                    {
                                        columns.Add(model => model.Descripcion).Titled("Descripcion");
                                        columns.Add(model => model.EsPremio ? LigamaniaEnum.eSINO.SI.ToString() : LigamaniaEnum.eSINO.NO.ToString()).Titled("Premio");
                                        columns.Add(model => model.PosicionInicial).Titled("Desde el puesto");
                                        columns.Add(model => model.PosicionFinal).Titled("Hasta el puesto");
                                        columns.Add(model => model.UsarMarca ? LigamaniaEnum.eSINO.SI.ToString() : LigamaniaEnum.eSINO.NO.ToString()).Titled("Usar icono");
                                        columns.Add().Encoded(false).Titled("Icono").RenderedAs(model => "<i class='"+model.Marca+"'></i>");
                                        columns.Add(model => model.UsarColor ? LigamaniaEnum.eSINO.SI.ToString() : LigamaniaEnum.eSINO.NO.ToString()).Titled("Usar color");
                                        columns.Add(model => $"<button type='button' class='btn btn-primary' " +
                                            $"data-id=\"{model.Id}\" data-desc=\"{model.Descripcion}\" data-premio=\"{model.EsPremio}\" " +
                                            $"data-posini=\"{model.PosicionInicial}\" " +
                                            $"data-posfin=\"{model.PosicionFinal}\" data-usarmarca=\"{model.UsarMarca}\" data-marca=\"{model.Marca}\" data-usarcolor=\"{model.UsarColor}\" " +
                                            $"data-html=\"{model.HtmlColor}\" data-argb=\"{model.Argb}\" " +
                                            $"data-toggle='modal' data-target='#editReferenciaModal'>Editar</button>").Encoded(false);
                                        columns.Add(model => $"<button type='button' class='btn btn-secondary' id=\"{model.Id}\" onClick=\"buttonBorrar(this.id)\">Borrar</button>").Encoded(false);
                                    })
                                    .RowAttributed(model => new { style= model.UsarColor == true ? "background-color:"+model.HtmlColor : "background-color:transparent" })
                                );

#line default
#line hidden
            EndContext();
            BeginContext(4179, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 67 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                    }
                }
            }
            else
            {

#line default
#line hidden
            BeginContext(4337, 72, true);
            WriteLiteral("                <tr class=\"mvc-grid-empty-row\">\r\n                    <td");
            EndContext();
            BeginWriteAttribute("colspan", " colspan=\"", 4409, "\"", 4441, 1);
#line 73 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
WriteAttributeValue("", 4419, Model.Columns.Count(), 4419, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4442, 27, true);
            WriteLiteral(">\r\n                        ");
            EndContext();
            BeginContext(4470, 15, false);
#line 74 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
                   Write(Model.EmptyText);

#line default
#line hidden
            EndContext();
            BeginContext(4485, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 77 "D:\srcRepository\Proyectos Estela\Ligamania\LigamaniaCoreApp\Views\ManagerC\_NestedReferenciasGrid.cshtml"
            }

#line default
#line hidden
            BeginContext(4552, 655, true);
            WriteLiteral(@"        </tbody>
    </table>

</div>

<div class=""modal fade"" id=""editReferenciaModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editReferenciaModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""editReferenciaModalLabel"">Editando... </h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(5207, 2574, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db984c9116536e512a3d74e3af35c3b35ba9b09917026", async() => {
                BeginContext(5213, 1590, true);
                WriteLiteral(@"
                    <input type=""hidden"" class=""form-control"" id=""edit-id"">
                    <input type=""hidden"" class=""form-control"" id=""edit-marca"">
                    <input type=""hidden"" class=""form-control"" id=""edit-color"">
                    <div class=""input-group mb-2"">
                        <div class=""input-group-prepend w-50"">
                            <span class=""input-group-text"" id=""basic-addon1"">Descripción:</span>
                        </div>
                        <input type=""text"" class=""form-control w-50"" id=""edit-desc-text"">
                    </div>
                    <div class=""input-group  mb-4"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""basic-addon1"">Desde el puesto:</span>
                        </div>
                        <input type=""number"" class=""form-control"" id=""edit-posini-text"">
                        <div class=""input-group-prepend"">
                         ");
                WriteLiteral(@"   <span class=""input-group-text"" id=""basic-addon1"">Hasta el puesto:</span>
                        </div>
                        <input type=""number"" class=""form-control"" id=""edit-posfin-text"">
                    </div>
                    <div class=""input-group mb-2"">
                        <div class=""input-group-prepend w-50"">
                            <span class=""input-group-text"" id=""basic-addon1"">Es Premio?:</span>
                        </div>
                        <input type=""checkbox"" class=""form-control w-50"" id=""edit-premio-text""");
                EndContext();
                BeginWriteAttribute("checked", " checked=\"", 6803, "\"", 6813, 0);
                EndWriteAttribute();
                BeginContext(6814, 364, true);
                WriteLiteral(@">
                    </div>
                    <div class=""input-group  mb-3"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""basic-addon1"">Usar icono:</span>
                        </div>
                        <input type=""checkbox"" class=""form-control"" id=""edit-usarmarca-text""");
                EndContext();
                BeginWriteAttribute("checked", " checked=\"", 7178, "\"", 7188, 0);
                EndWriteAttribute();
                BeginContext(7189, 440, true);
                WriteLiteral(@">
                        <i id=""edit-marca-icon"" class=""form-control ""></i>
                    </div>
                    <div class=""input-group  mb-3"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""basic-addon1"">Usar color:</span>
                        </div>
                        <input type=""checkbox"" class=""form-control"" id=""edit-usarcolor-text""");
                EndContext();
                BeginWriteAttribute("checked", " checked=\"", 7629, "\"", 7639, 0);
                EndWriteAttribute();
                BeginContext(7640, 134, true);
                WriteLiteral(">\r\n                        <input type=\"color\" class=\"form-control\" id=\"edit-html-text\">\r\n                    </div>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7781, 934, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" data-save=""modal-edit"">Guardar</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""addReferenciaModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addReferenciaModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addReferenciaModalLabel"">Añadiendo... </h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(8715, 2750, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db984c9116536e512a3d74e3af35c3b35ba9b09922853", async() => {
                BeginContext(8721, 1764, true);
                WriteLiteral(@"
                    <input type=""hidden"" class=""form-control"" id=""add-id"">
                    <input type=""hidden"" class=""form-control"" id=""add-marca"">
                    <input type=""hidden"" class=""form-control"" id=""add-color"">
                    <input type=""hidden"" class=""form-control"" id=""add-competicion"">
                    <input type=""hidden"" class=""form-control"" id=""add-categoria"">
                    <div class=""input-group mb-2"">
                        <div class=""input-group-prepend w-50"">
                            <span class=""input-group-text"" id=""addbasic-addon1"">Descripción:</span>
                        </div>
                        <input type=""text"" class=""form-control w-150"" id=""add-desc-text"">
                    </div>
                    <div class=""input-group  mb-4"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""addbasic-addon1"">Desde el puesto:</span>
                        </div>
   ");
                WriteLiteral(@"                     <input type=""number"" class=""form-control"" id=""add-posini-text"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""addbasic-addon1"">Hasta el puesto:</span>
                        </div>
                        <input type=""number"" class=""form-control"" id=""add-posfin-text"">
                    </div>
                    <div class=""input-group mb-2"">
                        <div class=""input-group-prepend w-50"">
                            <span class=""input-group-text"" id=""addbasic-addon1"">Es Premio?:</span>
                        </div>
                        <input type=""checkbox"" class=""form-control w-50"" id=""add-premio-text""");
                EndContext();
                BeginWriteAttribute("checked", " checked=\"", 10485, "\"", 10495, 0);
                EndWriteAttribute();
                BeginContext(10496, 366, true);
                WriteLiteral(@">
                    </div>
                    <div class=""input-group  mb-3"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""addbasic-addon1"">Usar icono:</span>
                        </div>
                        <input type=""checkbox"" class=""form-control"" id=""add-usarmarca-text""");
                EndContext();
                BeginWriteAttribute("checked", " checked=\"", 10862, "\"", 10872, 0);
                EndWriteAttribute();
                BeginContext(10873, 441, true);
                WriteLiteral(@">
                        <i id=""add-marca-icon"" class=""form-control ""></i>
                    </div>
                    <div class=""input-group  mb-3"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text"" id=""addbasic-addon1"">Usar color:</span>
                        </div>
                        <input type=""checkbox"" class=""form-control"" id=""add-usarcolor-text""");
                EndContext();
                BeginWriteAttribute("checked", " checked=\"", 11314, "\"", 11324, 0);
                EndWriteAttribute();
                BeginContext(11325, 133, true);
                WriteLiteral(">\r\n                        <input type=\"color\" class=\"form-control\" id=\"add-html-text\">\r\n                    </div>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(11465, 10827, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" data-save=""modal-add"">Guardar</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
            </div>
        </div>
    </div>
</div>


<script type=""text/javascript"">
    var muestrario;
    var muestrarioAdd;
    var colorPredeterminado = ""#0000ff"";
    var colorSeleccionado = colorPredeterminado;
    var colorSeleccionadoAdd = colorPredeterminado;

    window.addEventListener(""load"", startup, false);
    function startup() {
        muestrario = document.querySelector(""#edit-html-text"");
        muestrario.addEventListener(""input"", actualizarPrimero, false);
        muestrario.addEventListener(""change"", actualizarTodo, false);
        muestrario.select();

        muestrarioAdd = document.querySelector(""#add-html-text"");
        muestrarioAdd.addEventListener(""input"", actualizarPrimeroAdd, false);
      ");
            WriteLiteral(@"  muestrarioAdd.addEventListener(""change"", actualizarTodoAdd, false);
        muestrarioAdd.select();
    }
    function actualizarPrimero(event) {
        var p = document.querySelector(""p"");
        colorSeleccionado = event.target.value;
        if (p) {
            p.style.color = event.target.value;
        }
    }
    function actualizarTodo(event) {
        colorSeleccionado = event.target.value;
        document.querySelectorAll(""p"").forEach(function (p) {
            p.style.color = event.target.value;
        });
    }
    function actualizarPrimeroAdd(event) {
        var p = document.querySelector(""p"");
        colorSeleccionadoAdd = event.target.value;
        if (p) {
            p.style.color = event.target.value;
        }
    }
    function actualizarTodoAdd(event) {
        colorSeleccionadoAdd = event.target.value;
        document.querySelectorAll(""p"").forEach(function (p) {
            p.style.color = event.target.value;
        });
    }

    $('#editReferen");
            WriteLiteral(@"ciaModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var id = button.data('id') // Extract info from data-* attributes
        var color = button.data('argb')
        var desc = button.data('desc')
        var premio = button.data('premio')
        var posini = button.data('posini')
        var posfin = button.data('posfin')
        var usarmarca = button.data('usarmarca')
        var marca = button.data('marca')
        var usarcolor = button.data('usarcolor')
        var html = button.data('html')
        //alert(premio + """" + usarmarca + """" + usarcolor);
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text('Edición')
        modal.find('#edit-id').val(id)
    ");
            WriteLiteral(@"    modal.find('#edit-marca').val(marca)
        modal.find('#edit-color').val(color)
        modal.find('#edit-desc-text').val(desc)
        modal.find('#edit-posini-text').val(posini)
        modal.find('#edit-posfin-text').val(posfin)

        modal.find('#edit-premio-text').prop(""checked"", false);
        if (premio === ""True"") {
            modal.find('#edit-premio-text').prop(""checked"", true);
        }
        modal.find('#edit-usarmarca-text').prop('checked', false);
        if (usarmarca === ""True"") {
            modal.find('#edit-usarmarca-text').prop('checked', true);
        }
        modal.find('#edit-usarcolor-text').prop('checked', false);
        if (usarcolor === ""True"") {
            modal.find('#edit-usarcolor-text').prop('checked', true);
        }

        modal.find('#edit-marca-text').val(marca)
        var newClass = ""form-control "" + marca;
        modal.find('#edit-marca-icon').removeClass('form-control').addClass(newClass);
        modal.find('#edit-html-text')");
            WriteLiteral(@".val(html)
    })
    $('#editReferenciaModal').on('click', '[data-save=""modal-edit""]', function (event) {
        event.preventDefault();
        var id = $('#edit-id').val();
        var desc = $('#edit-desc-text').val();
        //var premio = $('#edit-premio-text').val();
        var premio = $('#edit-premio-text').is("":checked"");
        var posini = $('#edit-posini-text').val();
        var posfin = $('#edit-posfin-text').val();
        var usarmarca = $('#edit-usarmarca-text').is("":checked"");
        var marca = $('#edit-marca').val();
        var usarcolor = $('#edit-usarcolor-text').is("":checked"");
        //var argb = $('#edit-argb-text').val();
        //var color = $('#edit-color-text').val();
        var html = $('#edit-html-text').val();
        var color = $('#edit-color').val();

        var color = colorSeleccionado;

        //alert(desc + "" "" + premio + "" "" + posini + "" "" + posfin + "" "" + usarmarca + "" "" + marca + "" "" + usarcolor + "" "" + html);

        const referenci");
            WriteLiteral(@"a = {
            Id: id,
            Descripcion: desc,
            EsPremio: premio,
            PosicionInicial: posini,
            PosicionFinal: posfin,
            UsarMarca: usarmarca,
            Marca: marca,
            UsarColor: usarcolor,
            HexColor: color,
            Color: color
        };
        var urlToCall = '/MANAGERC/EditarReferenciaCompeticion';
        $.ajax({
            type: ""POST"",
            data: JSON.stringify(referencia),
            url: urlToCall,
            contentType: ""application/json; charset=utf-8"",
            processData: true,
            cache: false,
            dataType: 'json',
            error: function (response) {
                alert(""Error al modificar una referencia"");
            }
        }).done(function (response) {
            alert(response.message);
            if (response.result) {
                $('#editReferenciaModal').modal('hide');
                location.reload();
            }
        });
   ");
            WriteLiteral(@" });

    function buttonBorrar(elementid) {
        const menu = {
            MenuIdentity: elementid,
        };
        var urlToCall = '/MANAGERC/BorrarMenu';
        $.ajax({
            type: ""POST"",
            data: JSON.stringify(menu),
            url: urlToCall,
            contentType: ""application/json; charset=utf-8"",
            processData: true,
            cache: false,
            dataType: 'json',
            error: function (response) {
                alert(""Error al borrar menú"");
            }
        }).done(function (response) {
            alert(response.message);
            location.reload();
        });
    }
    $('#addReferenciaModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var id = 0 // Extract info from data-* attributes
        var competicion = button.data('competicion');
        var categoria = button.data('categoria');
        var color = ""#ffffff""
        ");
            WriteLiteral(@"var desc = """"
        var premio = ""False""
        var posini = 0
        var posfin = 0
        var usarmarca = ""False""
        var marca = ""fas fa-euro-sign""
        var usarcolor = ""False""
        var html = ""#ffffff""
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text('Añadiendo...')
        modal.find('#add-id').val(id)
        modal.find('#add-marca').val(marca)
        modal.find('#add-color').val(color)
        modal.find('#add-competicion').val(competicion)
        modal.find('#add-categoria').val(categoria)
        modal.find('#add-desc-text').val(desc)
        modal.find('#add-posini-text').val(posini)
        modal.find('#add-posfin-text').val(posfin)

        modal.find('#add-premio-text').prop(""checked"", false);
        if (pr");
            WriteLiteral(@"emio === ""True"") {
            modal.find('#add-premio-text').prop(""checked"", true);
        }
        modal.find('#add-usarmarca-text').prop('checked', false);
        if (usarmarca === ""True"") {
            modal.find('#add-usarmarca-text').prop('checked', true);
        }
        modal.find('#add-usarcolor-text').prop('checked', false);
        if (usarcolor === ""True"") {
            modal.find('#add-usarcolor-text').prop('checked', true);
        }

        modal.find('#add-marca-text').val(marca)
        var newClass = ""form-control "" + marca;
        modal.find('#add-marca-icon').removeClass('form-control').addClass(newClass);
        modal.find('#add-html-text').val(html)
    });
    $('#addReferenciaModal').on('click', '[data-save=""modal-add""]', function (event) {
        event.preventDefault();
        var id = $('#add-id').val();
        var desc = $('#add-desc-text').val();
        var competicion = $('#add-competicion').val();
        var categoria = $('#add-categoria').val()");
            WriteLiteral(@";
        var premio = $('#add-premio-text').is("":checked"");
        var posini = $('#add-posini-text').val();
        var posfin = $('#add-posfin-text').val();
        var usarmarca = $('#add-usarmarca-text').is("":checked"");
        var marca = $('#add-marca').val();
        var usarcolor = $('#add-usarcolor-text').is("":checked"");
        var html = $('#add-html-text').val();
        var color = $('#add-color').val();
        var color = colorSeleccionado;

        const referencia = {
            Id: id,
            Competicion: competicion,
            Categoria: categoria,
            Descripcion: desc,
            EsPremio: premio,
            PosicionInicial: posini,
            PosicionFinal: posfin,
            UsarMarca: usarmarca,
            Marca: marca,
            UsarColor: usarcolor,
            HexColor: color,
            Color: color
        };
        var urlToCall = '/MANAGERC/AgregarReferenciaCompeticion';
        $.ajax({
            type: ""POST"",
           ");
            WriteLiteral(@" data: JSON.stringify(referencia),
            url: urlToCall,
            contentType: ""application/json; charset=utf-8"",
            processData: true,
            cache: false,
            dataType: 'json',
            error: function (response) {
                alert(""Error al modificar una referencia"");
            }
        }).done(function (response) {
            alert(response.message);
            if (response.result) {
                $('#editReferenciaModal').modal('hide');
                location.reload();
            }
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IGrid<CompeticionCategoriaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
