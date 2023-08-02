"use strict";
$(document).ready(function () {
    var table;
    const columns = [
        { title: '' },
    ]
    $.getJSON('GetContabilidades', function (contabilidades) {
        table = $('#tbContabilidad').DataTable({
            "data": contabilidades,
            //createdRow: function (row) {
            //    $(row).find('td table')
            //        .DataTable({
            //            columns: columns,
            //            dom: 'tf'
            //        })
            //},
            "columns": [
                {
                    "className": 'details-control',
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "render": function () {
                        return '<i class="fas fa-plus-circle openclose" aria-hidden="true"></i>';
                    },
                    "width": "15px"
                },
                { "data": "temporada" },
                {
                    "data": null,
                    "render": function (row) {
                        $(row).DataTable({
                            columns: columns
                        })
                    }
                }
                { "data": "concepto" },
                { "data": "valor" },
                { "data": "gastoIngreso" },
                { "data": "porEquipo" },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //edit button creation
                    "render": function (data, type, row) {
                        return createButton('edit', row.id);
                    }
                },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //delete button creation
                    "render": function (data, type, row) {
                        return createButton('delete', row.id);
                    }
                }
            ],
            "order": [[1, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });
    // Add event listener for opening and closing details
    $('#tbContabilidad tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
            tr.find('.openclose').attr('data-icon', 'plus-circle');
        }
        else {
            // Open this row
            //getDetails(row.data(), function (details, contabilidad) {
            //    var tabla = getTabla(details, contabilidad);
                //row.child(tabla).show();
                tr.addClass('shown');
                tr.find('.openclose').attr('data-icon', 'minus-circle');
            //});
        }
    });
});

///* Formatting function for row details - modify as you need */
//function getDetails(contabilidad, callbackDetails) {
//    getTablaDetalle(contabilidad, function (tabla) {
//        callbackDetails(tabla, contabilidad.id);
//    });
//};
//function getTablaDetalle(contabilidad, callbackCategorias) {
//    var urlString = 'GetContabilidad?id=' + contabilidad.id;
//    return $.ajax({
//        type: 'GET',
//        url: urlString,
//        dataType: 'json',
//        success: function (premios) {
//            callbackPreios(premios);
//        },
//        failure: function (response) {
//            alert(response);
//        }
//    });
//};

//function callbackDetails(tabla) {
//    return tabla;
//};

//function getTabla(categorias, listcategorias, competicion) {
//    var infoEnt = '';
//    //infoEnt = '<div class="row">';
//    //infoEnt += '<div class="card col-6 m-2">';
//    //infoEnt += '<div class="card-header m-2">';
//    //infoEnt += '<label class="label m-2">Nueva categoría: </label>';
//    //infoEnt += '<select class="col-4" id="newCategoria"><option>Seleccionar una categoría</option>';
//    //infoEnt += createSelect(listcategorias, "newCategoria");
//    //infoEnt += '</select>';
//    //infoEnt += '<button class="btn-primary m-2" id="btNuevaCategoria">Añadir</button>';
//    //infoEnt += '<hidden id="idCompeticion" value="@competicion" style="display:none;">'+competicion+'</hidden>';
//    //infoEnt += '</div>';// card-header
//    //infoEnt += '<div class="card-body">';
//    //infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;" id="tbCategorias">';
//    //infoEnt += '<tr>';
//    //infoEnt += '<th>Categoría</th>';
//    //infoEnt += '<th>Activa</th>';
//    //infoEnt += '<th>Orden</th>';
//    //infoEnt += '</tr>';
//    //categorias.forEach(function (categoria, index) {
//    //    infoEnt += '<tr>' +
//    //        '<td>' + categoria.categoria + '</td>' +
//    //        '<td>' + categoria.activa + '</td>' +
//    //        '<td>' + categoria.orden + '</td>' +
//    //        '<th><a href="DeleteCategoriaFromCompeticion?competicionId=' + competicion + '&categoriaId=' + categoria.id + '"><span class="fas fa-trash-alt" aria-hidden="true"></span></a></th>' +
//    //        '</tr>';
//    //});
//    //infoEnt += '</table>';
//    //infoEnt += '</div>';    //card-body
//    //infoEnt += '</div>';    //card
//    //infoEnt += '</div>';    //row
//    return infoEnt;
//};
//function createSelect(options, listName) {
//    var optionsText = '';
//    $.each(options, function (index, item) {
//        optionsText += '<option value=' + item.id + '>' + item.categoria + '</option>';
//    });
//    return optionsText;
//}
//$(document).on('click', '#btNuevaCategoria', function () {
//    var categoriaSelected = $("#newCategoria").val();
//    var competicionId = $("#idCompeticion").text();

//    // llamar a la función del controller que actualice el rol a los usuarios
//    var urlString = 'UpdateCategorias';
//    $.ajax({
//        type: 'POST',
//        async: false,
//        url: urlString,
//        data: { newCategoria: categoriaSelected, competicionId: competicionId },
//        dataType: 'json',
//        success: function (response) {
//            alert("Categorías actualizadass");
//        },
//        failure: function (response) {
//            alert("Se ha producido un error al actualizar las categorías");
//        }
//    }).done(function (response) {
//        location.reload();
//    });
//});
