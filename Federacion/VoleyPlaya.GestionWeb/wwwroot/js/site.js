// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function applyFilter() {
    var url = window.location.href.split('?')[0]; // obtener la URL base sin los parámetros de la consulta
    var prueba = $("#prueba-select").val();
    var competicion = $("#competicion-select").val();
    var categoria = $("#categoria-select").val();
    var genero = $("#genero-select").val();
    var grupo = $("#grupo-select").val();
    url += '?prueba='+prueba;
    url += '&competicion=' + competicion; // agregar el filtro de categoría a la URL
    url += '&categoria=' + categoria; // agregar el filtro de categoría a la URL
    url += '&genero=' + genero; // agregar el filtro de categoría a la URL
    url += '&grupo=' + grupo; // agregar el filtro de categoría a la URL
    window.location.href = url; // recargar la página con la URL actualizada
}
