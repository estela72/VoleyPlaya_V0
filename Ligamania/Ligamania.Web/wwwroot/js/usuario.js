"use strict";
$(document).ready(function () {
    var table;
    $.getJSON('getListaUsuarios', function (usuarios) {
        table = $('#tbUsuarios').DataTable({
            "data": usuarios,
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
                { "data": "userName" },
                { "data": "userState" },
                { "data": "email" },
                { "data": "roles" },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //edit button creation
                    "render": function (data, type, row) {
                        return createButton('edit', row.id, 'editdelete');
                    }
                },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //delete button creation
                    "render": function (data, type, row) {
                        return createButton('delete', row.id, 'editdelete');
                    }
                }
            ],
            "order": [[2, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });

    // Add event listener for opening and closing details
    $('#tbUsuarios tbody').on('click', 'td.details-control', function () {
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
            var tabla = getTabla(row.data());
            row.child(tabla).show();
            tr.addClass('shown');
            tr.find('.openclose').attr('data-icon', 'minus-circle');
        }
    });

    // Add event listener for opening and closing details
    $('#tbUsuariosPendientes tbody').on('click', 'td.details-control', function () {
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
            var tabla = getTabla(row.data());
            row.child(tabla).show();
            tr.addClass('shown');
            tr.find('.openclose').attr('data-icon', 'minus-circle');
        }
    });

    var tablePendientes;
    $.getJSON('getListaUsuariosPendientes', function (usuariosPendientes) {
        tablePendientes = $('#tbUsuariosPendientes').DataTable({
            "data": usuariosPendientes,
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
                { "data": "userName" },
                { "data": "userState" },
                { "data": "email" },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //confirm button creation
                    "render": function (data, type, row) {
                        return createButton('confirm', row.id, 'editdelete');
                    }
                },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //not confirm button creation
                    "render": function (data, type, row) {
                        return createButton('notConfirm', row.id, 'editdelete');
                    }
                }
            ],
            "order": [[1, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });
});

/* Formatting function for row details - modify as you need */
function getTabla(usuario) {
    var infoEnt = '';
    infoEnt = '<div class="row"><div class="card col-8 m-2"> <table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;background-color:yellow">' +
        '<tr>' +
        '<td>Teléfono</td>' +
        '<td style="font-weight:bold">' + usuario.phoneNumber + '</td>' +
        '<td>Población:</td>' +
        '<td style="font-weight:bold">' + usuario.city + '</td>' +
        '<td></td>' +
        '<td></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Como conocí Ligamania:</td>' +
        '<td style="font-weight:bold">' + usuario.conocimiento + '</td>' +
        '<td>Categoría preferida:</td>' +
        '<td style="font-weight:bold">' + usuario.compartirGrupo + '</td>' +
        '<td>Recibir whatsapps:</td>' +
        '<td style="font-weight:bold">' + usuario.whatsap + '</td>' +
        '</tr>' +
        '</table> </div>';
    return infoEnt;
};