"use strict";
$(document).ready(function () {
    var table;

    $.getJSON('getListaCalendarios', function (calendarios) {
        table = $('#tbCalendarios').DataTable({
            "data": calendarios,
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
                { "data": "calendario" },
                { "data": "numEquipos" }
                ,
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    //edit button creation
                    "render": function (data, type, row) {
                        return createButton('edit', row.id);
                    }
                }
                ,
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
            "order": [[2, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });
    // Add event listener for opening and closing details
    $('#tbCalendarios tbody').on('click', 'td.details-control', function () {
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
            getDetails(row.data(), function (details) {
                var tabla = getTabla(details);
                row.child(tabla).show();
                tr.addClass('shown');
                tr.find('.openclose').attr('data-icon', 'minus-circle');
            });
        }
    });    
});

/* Formatting function for row details - modify as you need */
function getDetails(calendario, callbackDetails) {
    getTablaDetalle(calendario, function (tabla) {
        callbackDetails(tabla);
    });
};
function getTablaDetalle(calendario, callbackPartidos) {
    callbackPartidos(calendario, calendario.partidos);
};
function callbackDetails(tabla) {
    return tabla;
};

function getTabla(calendario) {
    var infoEnt = '<div class="row">';
    infoEnt += '<div class="col-12 m-2">';
    infoEnt += '<div class="card">';
    infoEnt += '<div class="card-header m-2">';
    infoEnt += '<label class="label m-2">Enfrentamientos </label>';
    infoEnt += '</div>';// card-header
    infoEnt += '<div class="card-body">';
    infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;" id="tablePartidos">';
    sortJson(calendario.partidos, "jornada", "int", true);
    var partidos = calendario.partidos;
    //sortJson(partidos, "local", "string", true);
    partidos.forEach(function (partido, index) {
        infoEnt += '<tr>';
        infoEnt +=
            '<td>' + partido.jornada + '</td>' +
            '<td>' + partido.local + '</td>' +
            '<td>' + partido.visitante + '</td>';
        infoEnt += '<td><div class="btn-group" role="group" aria-label="Acciones sobre el partido">';
        infoEnt += '<button class="btn btn-outline-primary" id="btAccionPartido" data-accion="editar" data-calendarioId="' + calendario.id + '" data-partidoId="' + partido.id + '" data-jornadaId="'+partido.jornada+'" data-local="'+partido.local+'" data-visitante="'+partido.visitante+'"><span class="bi bi-pencil-square" aria-hidden="true" style="color:red"></span>';
        infoEnt += '<button class="btn btn-outline-primary" id="btAccionPartido" data-accion="borrar" data-calendarioId="' + calendario.id + '" data-partidoId="' + partido.id + '"><span class="bi bi-trash-fill" aria-hidden="true" ></span>';
        infoEnt += '</div></td>';
        infoEnt += '<td></td>';
        infoEnt += '</tr> ';
    });
    infoEnt += '</table>';
    infoEnt += '</div> ';// card-body
    infoEnt += '</div>';//card
    infoEnt += '</div> '; //col-5
    infoEnt += '</div > '; // row
    return infoEnt;
};

// code to read selected table row cell data (values).
$(document).on('click', '#btAccionPartido', function () {
    // get the current row
    var currentRow = $(this).closest("tr");

    var calendarioId = $(this).data('calendarioid');
    var id = $(this).data('partidoid');
    var accion = $(this).data('accion');

    if (accion === 'editar') {
        var jornada = $(this).data('jornadaid');
        var local = $(this).data('local');
        var visitante = $(this).data('visitante');

        var info = '<form class="row row-cols-lg-auto g-3 align-items-center">';
        info += '<div class="col-12"><label>Modificar datos del enfrentamiento:</label></div>';
        info += '<div class="col-12">';
        info += '<label>Jornada</label>';
        info += '<input id="jornada" name="jornada" type="number" class="form-control" value="' + jornada + '"/>';
        info += '</div>';

        info += '<div class="col-12">';
        info += '<label>Local</label>';
        info += '<input id="local" name="local" type="text" class="form-control" value="' + local + '"/>';
        info += '</div>';

        info += '<div class="col-12">';
        info += '<label>Visitante</label>';
        info += '<input id="visitante" name="visitante" type="text" class="form-control" value="' + visitante + '"/>';
        info += '</div>';

        info += '<div class="col-12">';
        info += '<button class="btn btn-primary p-3" id="btGuardarPartido" data-bs-toggle="tooltip" data-bs-placement="top" title="Guardar cambios" data-calendarioId="' + calendarioId + '" data-partidoId="' + id + '"><span class="bi bi-check-circle-fill" aria-hidden="true"></span></button>';
        info += '<button class="btn btn-secondary p-3 m-2" id="btCancelarPartido" data-bs-toggle="tooltip" data-bs-placement="top" title="Cancelar cambios" data-calendarioId="' + calendarioId + '" data-partidoId="' + id + '"><span class="bi bi-dash-circle-fill" aria-hidden="true"></span></button>';
        info += '</div>';

        info += '</form>';

        var col1 = currentRow.find("td:eq(4)").html(info); // get current row 1st table cell TD value
    } else if (accion === 'borrar') {
        var formData = new FormData();
        formData.append('calendarioId', calendarioId);
        formData.append('id', id);
        // llamar a la función del controller 
        var urlString = 'DeletePartidoCalendario';
        $.ajax({
            type: 'POST',
            url: urlString,
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                //alert("Calendario modificado");
            },
            failure: function (response) {
                alert("Se ha producido un error al borrar el partido del calendario");
            }
        }).done(function (response) {
            alert("Calendario modificado");
            location.reload();
        });

        var col1 = currentRow.find("td:eq(4)").html('');
    }
});

$(document).on('click', '#btGuardarPartido', function (event) {
    // get the current row
    var currentRow = $(this).closest("tr");

    var calendarioid = $(this).data('calendarioid');
    var id = $(this).data('partidoid');
    var jornada = $('#jornada').val();
    var local = $('#local').val();
    var visitante = $('#visitante').val();

    var formData = new FormData();
    formData.append('calendarioId', calendarioid);
    formData.append('id', id);
    formData.append('jornada', jornada);
    formData.append('local',local);
    formData.append('visitante', visitante);
    // llamar a la función del controller 
    var urlString = 'UpdatePartidoCalendario';
    $.ajax({
        type: 'POST',
        url: urlString,
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            //alert("Calendario modificado");
        },
        failure: function (response) {
            alert("Se ha producido un error al modificar el calendario");
        }
    }).done(function (response) {
        alert("Calendario modificado");
        location.reload();
    });

    var col1 = currentRow.find("td:eq(4)").html('');
});

$(document).on('click', '#btCancelarPartido', function (event) {
    // get the current row
    var currentRow = $(this).closest("tr");

    var id = $(this).data('partidoid');
    var jornada = $(this).data('jornadaid');
    var local = $(this).data('local');
    var visitante = $(this).data('visitante');

    var col1 = currentRow.find("td:eq(4)").html('');
});