"use strict";
$(document).ready(function () {
    var table;
    $.getJSON('getListaEntrenadores', function (entrenadores) {
        table = $('#tbEntrenadores').DataTable({
            "data": entrenadores,
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
                { "data": "nombre" },
                { "data": "estadoEntrenador" },
                { "data": "tipoEntrenador" },
                { "data": "numEquipos" },
            ],
            "order": [[2, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });
    // Add event listener for opening and closing details
    $('#tbEntrenadores tbody').on('click', 'td.details-control', function () {
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
function getDetails(entrenador, callbackDetails) {
    getTablaDetalle(entrenador, function (tabla) {
        callbackDetails(tabla);
    });
};
function getTablaDetalle(entrenador, callbackEquipos) {
    callbackEquipos(entrenador, entrenador.equipos);
};
function callbackDetails(tabla) {
    return tabla;
};

/*
  <div class="collapse" id="collapseExample">
*/
function getTabla(entrenador) {
    var infoEnt = '<div class="row">';
    infoEnt += '<div class="col-5 m-2">';
    infoEnt += '<div class="card">';
    infoEnt += '<div class="card-header m-2">';
    infoEnt += '<label class="label m-2">Equipos </label>';
    infoEnt += '</div>';// card-header
    infoEnt += '<div class="card-body">';
    infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';
    entrenador.equipos.forEach(function (equipo, index) {
        infoEnt += '<tr>';
        if (equipo.escudo !== '') {
            infoEnt += '<td><img src=' + equipo.escudoToShow + ' class="rounded-circle" height="40" width="40" asp-append-version="true"/></td>';
        }
        else {
            infoEnt +='<td>-</td>';
        }
        infoEnt +=  '<th>' + equipo.nombre + '</th>' +
                    '<td>' + equipo.tipoEquipo + '</td>' +
                    '<td>' + equipo.estadoEquipo + '</td>';
        infoEnt += '<th><div class="btn-group" role="group" aria-label="Acciones sobre el equipo">';
        if (equipo.tipoEquipo === 'Regular') {
            infoEnt += '<button class="btn btn-outline-primary" id="btAccionEquipo" data-accion="bot" data-equipoId="' + equipo.id + '"><span class="bi bi-robot" aria-hidden="true" style="color:red"></span>';
        }
        else {
            infoEnt += '<button class="btn btn-outline-primary" id="btAccionEquipo" data-accion="regular" data-equipoId="' + equipo.id + '"><span class="bi bi-emoji-smile" aria-hidden="true" style="color:blue"></span>';
        }
        if (equipo.estadoEquipo === 'Baja') {
            infoEnt += '<button class="btn btn-outline-primary" id="btAccionEquipo" data-accion="alta" data-equipoId="' + equipo.id + '"><span class="bi bi-arrow-up-square-fill" aria-hidden="true" style="color:green"></span>';
        }
        else {
            infoEnt += '<button class="btn btn-outline-primary" id="btAccionEquipo" data-accion="baja" data-equipoId="' + equipo.id + '"><span class="bi bi-arrow-down-square-fill" aria-hidden="true" style="color:red"></span>';
        }
        infoEnt += '<button class="btn btn-outline-primary" id="btAccionEquipo" data-accion="borrar" data-equipoId="' + equipo.id + '"><span class="bi bi-trash-fill" aria-hidden="true" ></span>';
        infoEnt += '</div></th></tr>';
    });
    infoEnt += '</table>';
    infoEnt += '</div > ';// card-body
    infoEnt += '</div>';//card
    infoEnt += '</div > '; //col-5
    infoEnt += '<div class="col-6 m-2">'
    infoEnt += '<p><button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapseNuevoEquipo" aria-expanded="false" aria-controls="collapseNuevoEquipo">Nuevo Equipo';
    infoEnt += '</button></p>';
    infoEnt += '<div class="collapse" id="collapseNuevoEquipo">';
    infoEnt += '<div class="card">';
    infoEnt += '<div class="card-body">';
    infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';
    infoEnt += '<tr><td><label class="control-label m-2">Escudo (solo formato JPG): </label>';
    infoEnt += '<input id="escudoFile" type="file" /></td></tr>';
    infoEnt += '<tr><td><label class="control-label m-2">Nombre: </label>';
    infoEnt += '<input id="nombreEquipo" type="input" /></td></tr>';
    infoEnt += '<tr><td><label class="control-label m-2">¿Es BOT o FILIAL?: </label>';
    infoEnt += '<input id="esBot" type="checkbox" /></td></tr>';
    infoEnt += '</table>';
    infoEnt += '</div > '; //card-body
    infoEnt += '<div class="card-footer m-2">';
    infoEnt += '<hidden id="entrenadorId" style="display:none;">' + entrenador.id + '</hidden>';
    infoEnt += '<button class="btn-primary m-2" id="btNuevoEquipo">Añadir</button>';
    infoEnt += '</div>'; // card-footer
    infoEnt += '</div>'; //card
    infoEnt += '</div>';    // collapse
    infoEnt += '</div>'; // col-6
    infoEnt += '</div > '; // row
    return infoEnt;
};
$(document).on('click', '#btNuevoEquipo', function () {
    var nombre = $("#nombreEquipo").val();
    var esBot = $("#esBot").is(":checked"); 
    var entrenadorId = $("#entrenadorId").text();

    var input = document.getElementById("escudoFile");
    var files = input.files;
    var file = files[0];
    var formData = new FormData();
    formData.append('escudo', file);
    formData.append('nombre', nombre);
    formData.append('esBot', esBot);
    formData.append('entrenadorId', entrenadorId);
    // llamar a la función del controller 
    var urlString = 'AddEquipo';
    $.ajax({
        type: 'POST',
        url: urlString,
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            //alert("Equipo añadido");
        },
        failure: function (response) {
            alert("Se ha producido un error al añadir el equipo");
        }
    }).done(function (response) {
        alert("Equipo creado");
        location.reload();
    });
});
$(document).on('click', '#btAccionEquipo', function (event) {
    var equipoId = $(this).data('equipoid');
    var accion = $(this).data('accion');

    var msg = "¿Estás seguro de querer ";
    if (accion === 'borrar') {
        msg += "borrar el equipo?";
    } else if (accion === 'bot') {
        msg += "convertir el equipo a BOT?";
    } else if (accion === 'regular') {
        msg += "convertir el equipo en NORMAL?";
    } else if (accion === 'baja') {
        msg += "dar de baja el equipo?";
    } else if (accion === 'alta') {
        msg += "dar de alta el equipo?";
    }
    var resp = confirm(msg);
    if (resp) {
        var urlString = 'AccionEquipo';
        $.ajax({
            type: 'POST',
            async: false,
            url: urlString,
            data: { equipoId: equipoId, accion: accion},
            dataType: 'json',
            success: function (response) {
                //alert("Categorías actualizadass");
            },
            failure: function (response) {
                alert("Se ha producido un error al actualizar las categorías: "+response.message);
            }
        }).done(function (response) {
            alert("Equipo actualizado correctamente");
            location.reload();
        });
    }
});