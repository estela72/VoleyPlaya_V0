#pragma checksum "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ManagerC\ConfigMenu.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0f3e7bf0770435c50c39dd6bfc58b40177fce3c7446fb1a2b6cb14314814c0f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerC_ConfigMenu), @"mvc.1.0.view", @"/Views/ManagerC/ConfigMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManagerC/ConfigMenu.cshtml", typeof(AspNetCore.Views_ManagerC_ConfigMenu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0f3e7bf0770435c50c39dd6bfc58b40177fce3c7446fb1a2b6cb14314814c0f1", @"/Views/ManagerC/ConfigMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"cc15118ad604b470ae866cea065e5e5dcaf3f56265436adea6abd4962110efbf", @"/Views/_ViewImports.cshtml")]
    public class Views_ManagerC_ConfigMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ManagerC\ConfigMenu.cshtml"
  
    ViewData["Title"] = "Index";
    var lista = menus.GetMenuMasterToConfig();
    lista = lista.OrderBy(m=>m.User_Roll).ThenBy(m => m.Parent_MenuID).ThenBy(m => m.Order).ToList();

#line default
#line hidden
            BeginContext(251, 502, true);
            WriteLiteral(@"<h2>Configuración del Menú de Opciones de Ligamanía</h2>
<div class=""card"">
    <div class=""card-body"">
        <h3>Orden=-1 indica que el menú está desactivado, y no se mostrará</h3>
        <h3>En orden se ponen los valores de 10 en 10 para que quede espacio para añadir posteriores entradas y no modificar el resto</h3>
        <button type=""button"" class='btn btn-primary btn-lg' data-toggle='modal' data-target='#addMenuModal'>Nueva entrada</button>
    </div>
    <div class=""card-body"">
");
            EndContext();
            BeginContext(817, 107, true);
            WriteLiteral("        <div id=\"grid-menu\" class=\"mvc-grid\" data-name=\"\" data-filter-mode=\"ExcelRow\" data-source-url=\"\">\r\n");
            EndContext();
            BeginContext(958, 2059, false);
#line 18 "D:\srcRepository\ProyectosEstela\Ligamania\LigamaniaCoreApp\Views\ManagerC\ConfigMenu.cshtml"
            Write(Html
                    .Grid(lista)
                    .Build(columns =>
                    {
                        columns.Add(model => model.MenuIdentity).Titled("Id");
                        columns.Add(model => model.MenuID).Titled("Menu");
                        columns.Add(model => model.MenuName).Titled("Nombre");
                        columns.Add(model => model.Parent_MenuID).Titled("ID Parent");
                        columns.Add(model => model.User_Roll).Titled("Rol");
                        columns.Add(model => model.MenuFileName).Titled("Menu File Name");
                        columns.Add(model => model.MenuURL).Titled("Url");
                        columns.Add(model => model.Order).Titled("Orden");
                        columns.Add(model => $"<button type='button' class='btn btn-primary' data-menuid=\"{model.MenuID}\" data-name=\"{model.MenuName}\" data-id=\"{model.MenuIdentity}\" data-parentid=\"{model.Parent_MenuID}\" " +
                            $"data-userrol=\"{model.User_Roll}\" data-filename=\"{model.MenuFileName}\" data-url=\"{model.MenuURL}\" data-orden=\"{model.Order}\" " +
                            $"data-toggle='modal' data-target='#editMenuModal'>Editar</button>").Encoded(false);
                        columns.Add(model => $"<button type='button' class='btn btn-secondary' id=\"{model.MenuIdentity}\" onClick=\"buttonBorrar(this.id)\">Borrar</button>").Encoded(false);
                    })
                    .Css("webgrid-noticiaAplicacion") // Overwrites all classes with the new ones
                    .Empty("No hay registros")
                    .Id("ajax-grid-menu")
                    .Pageable(pager =>
                    {
                        //pager.PageSizes = new Dictionary<Int32, String> { { 0, "All" }, { 5, "5" }, { 10, "10" } };
                        pager.ShowPageSizes = true;
                        pager.RowsPerPage = 5;
                    })
                    .Filterable()
                    .Sortable()
                );

#line default
#line hidden
            EndContext();
            BeginContext(3035, 638, true);
            WriteLiteral(@"        </div>
    </div>
</div>

<div class=""modal fade"" id=""addMenuModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addMenuModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addMenuModalLabel"">Nueva entrada del menú</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(3673, 1740, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3e7bf0770435c50c39dd6bfc58b40177fce3c7446fb1a2b6cb14314814c0f18873", async() => {
                BeginContext(3679, 1727, true);
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""menu-text"" class=""col-form-label"">Menu:</label>
                        <input type=""text"" class=""form-control"" id=""menu-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""nombre-text"" class=""col-form-label"">Nombre:</label>
                        <input type=""text"" class=""form-control"" id=""nombre-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""parent-text"" class=""col-form-label"">Parent:</label>
                        <input type=""text"" class=""form-control"" id=""parent-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""rol-text"" class=""col-form-label"">Rol:</label>
                        <input type=""text"" class=""form-control"" id=""rol-text"">
                    </div>
                    <div class=""form-group"">
       ");
                WriteLiteral(@"                 <label for=""fileName-text"" class=""col-form-label"">Menu File Name:</label>
                        <input type=""text"" class=""form-control"" id=""fileName-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""url-text"" class=""col-form-label"">Url:</label>
                        <input type=""text"" class=""form-control"" id=""url-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""orden-text"" class=""col-form-label"">Orden:</label>
                        <input type=""text"" class=""form-control"" id=""orden-text"">
                    </div>

                ");
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
            BeginContext(5413, 917, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" data-save=""modal-add"">Guardar</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""editMenuModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editMenuModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""editMenuModalLabel"">Editando... </h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(6330, 1892, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3e7bf0770435c50c39dd6bfc58b40177fce3c7446fb1a2b6cb14314814c0f113160", async() => {
                BeginContext(6336, 1879, true);
                WriteLiteral(@"
                    <input type=""hidden"" class=""form-control"" id=""edit-id-menu"">
                    <div class=""form-group"">
                        <label for=""edit-menu-text"" class=""col-form-label"">Menu:</label>
                        <input type=""text"" class=""form-control"" id=""edit-menu-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""edit-nombre-text"" class=""col-form-label"">Nombre:</label>
                        <input type=""text"" class=""form-control"" id=""edit-nombre-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""edit-parent-text"" class=""col-form-label"">Parent:</label>
                        <input type=""text"" class=""form-control"" id=""edit-parent-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""edit-rol-text"" class=""col-form-label"">Rol:</label>
                        <input type=""text"" c");
                WriteLiteral(@"lass=""form-control"" id=""edit-rol-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""edit-fileName-text"" class=""col-form-label"">Menu File Name:</label>
                        <input type=""text"" class=""form-control"" id=""edit-fileName-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""edit-url-text"" class=""col-form-label"">Url:</label>
                        <input type=""text"" class=""form-control"" id=""edit-url-text"">
                    </div>
                    <div class=""form-group"">
                        <label for=""edit-orden-text"" class=""col-form-label"">Orden:</label>
                        <input type=""text"" class=""form-control"" id=""edit-orden-text"">
                    </div>

                ");
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
            BeginContext(8222, 5117, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" data-save=""modal-edit"">Guardar</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    $('#editMenuModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var id = button.data('id') // Extract info from data-* attributes
        var menuId = button.data('menuid')
        var name = button.data('name')
        var parentid = button.data('parentid')
        var userrol = button.data('userrol')
        var filename = button.data('filename')
        var url = button.data('url')
        var orden = button.data('orden')

        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's c");
            WriteLiteral(@"ontent. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text('Edición de menú ' + id)
        modal.find('#edit-id-menu').val(id)
        modal.find('#edit-menu-text').val(menuId)
        modal.find('#edit-nombre-text').val(name)
        modal.find('#edit-parent-text').val(parentid)
        modal.find('#edit-rol-text').val(userrol)
        modal.find('#edit-fileName-text').val(filename)
        modal.find('#edit-url-text').val(url)
        modal.find('#edit-orden-text').val(orden)
    })

    $('#addMenuModal').on('click', '[data-save=""modal-add""]', function (event) {
        event.preventDefault();
        var menuId = $('#menu-text').val();
        var nombre = $('#nombre-text').val();
        var parent = $('#parent-text').val();
        var rol = $('#rol-text').val();
        var filename = $('#fileName-text').val();
        var url = $('#url-text').val();
        var orden = $('#o");
            WriteLiteral(@"rden-text').val();

        const menu = {
            MenuID: menuId,
            MenuName: nombre,
            Parent_MenuID: parent,
            User_Roll: rol,
            MenuFileName: filename,
            MenuURL: url,
            Order: orden
        };
        var urlToCall = '/MANAGERC/AgregarMenu';
        $.ajax({
            type: ""POST"",
            data: JSON.stringify(menu),
            url: urlToCall,
            contentType: ""application/json; charset=utf-8"",
            processData: true,
            cache: false,
            dataType: 'json',
            error: function (response) {
                alert(""Error al crear un nuevo menu"");
            }
        }).done(function (response) {
            alert(""Menú añadido"");
            $('#addMenuModal').modal('hide');
            location.reload();
        });
    })


    $('#editMenuModal').on('click', '[data-save=""modal-edit""]', function (event) {
        event.preventDefault();
        var id = $('#edit-");
            WriteLiteral(@"id-menu').val();
        var menuId = $('#edit-menu-text').val();
        var nombre = $('#edit-nombre-text').val();
        var parent = $('#edit-parent-text').val();
        var rol = $('#edit-rol-text').val();
        var filename = $('#edit-fileName-text').val();
        var url = $('#edit-url-text').val();
        var orden = $('#edit-orden-text').val();
        //alert(id); alert(menuId); alert(nombre); alert(parent + rol + filname + url + orden);
        const menu = {
            MenuIdentity: id,
            MenuID: menuId,
            MenuName: nombre,
            Parent_MenuID: parent,
            User_Roll: rol,
            MenuFileName: filename,
            MenuURL: url,
            Order: orden
        };
        var urlToCall = '/MANAGERC/EditarMenu';
        $.ajax({
            type: ""POST"",
            data: JSON.stringify(menu),
            url: urlToCall,
            contentType: ""application/json; charset=utf-8"",
            processData: true,
            cache:");
            WriteLiteral(@" false,
            dataType: 'json',
            error: function (response) {
                alert(""Error al modificar una entrada del menú"");
            }
        }).done(function (response) {
            alert(response.message);
            $('#editMenuModal').modal('hide');
            location.reload();
        });
    });

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


</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LigamaniaCoreApp.Services.MenuMasterService menus { get; private set; }
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
