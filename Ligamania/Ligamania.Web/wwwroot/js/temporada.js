"use strict";
$(document).ready(function () {
    var table;
    
    $.getJSON('getListaTemporadas', function (temporadas) {
        table = $('#tbTemporadas').DataTable({
            "data": temporadas,
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
                },                { "orderable": "true", "data": "temporada" },
                { "orderable": "true", "data": "estado" },
                { "orderable": "true", "data": "actual" },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    "render": function (data, type, row) {
                        return createButton('clasificacion', row.id, 'tag');
                    }
                },
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
            "order": [[1, "desc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });
    // Add event listener for opening and closing details
    $('#tbTemporadas tbody').on('click', 'td.details-control', function () {
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
            getDetails(row.data(), function (details, temporada) {
                var tabla = getTabla(details, temporada);
                row.child(tabla).show();
                tr.addClass('shown');
                tr.find('.openclose').attr('data-icon', 'minus-circle');
            });
        }
    });
});
/* Formatting function for row details - modify as you need */
function getDetails(temporada, callbackDetails) {
    getTablaDetalle(temporada, function (tabla) {
        callbackDetails(tabla, temporada.id);
    });
};
function getTablaDetalle(temporada, callbackCompeticiones) {
    var urlString = 'getListaCompeticiones?idTemporada=' + temporada.id;
    return $.ajax({
        type: 'GET',
        url: urlString,
        dataType: 'json',
        success: function (competiciones) {
            callbackCompeticiones(competiciones);
        },
        failure: function (response) {
            alert(response);
        }
    });
};
function callbackDetails(tabla) {
    return tabla;
};
function getTabla(competiciones, temporada) {
    var infoEnt = '';
    infoEnt = '<div class="row">';
    infoEnt += printCardCompeticiones(infoEnt, competiciones, temporada);
    infoEnt += printCardJugadores(temporada);
    infoEnt += '</div>';    //row
    return infoEnt;
};

function printCardCompeticiones(infoEnt, competiciones, temporada) {
    infoEnt += '<div class="card col-6 m-2">';
    infoEnt += '<div class="card-header m-2">';
    infoEnt += '<div class="title">Competiciones</div>'
    infoEnt += '</div>';// card-header
    infoEnt += '<div class="card-body">';
    infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;" id="tbCompeticiones">';
    infoEnt += '<tr class="filaCompeticion">';
    infoEnt += '<th>Competición</th>';
    infoEnt += '<th>Activa</th>';
    infoEnt += '<th>Nº cambios fijos</th>';
    infoEnt += '</tr>';
    competiciones.forEach(function (competicion, index) {
        infoEnt += '<tr>' +
            '<td>' + competicion.competicion + '</td>' +
            '<td>' + competicion.activa + '</td>' +
            '<td>' + competicion.descripcionEstado + '</td>' +
            '</tr>' +
            '<tr><th></th><th>Categoría</th><th>Nº max para eliminar</th><th>Marcar Pichichi</th><th></th><th></th></tr>';
        competicion.categorias.forEach(function (categoria, index) {
            infoEnt +=
                '<tr>' +
                '<td></td>' +
                '<td>' + categoria.categoria + '</td>' +
                '<td>' + categoria.numeroMaximoJugadorEliminar + '</td>' +
                '<td>' + categoria.marcarPichichi + '</td>' +
                '<th><a href="Partidos?temporadaId=' + temporada + '&competicionId=' + competicion.id + '&categoriaId=' + categoria.id + '"><span class="bi bi-bricks" aria-hidden="true"></span></a> Partidos</th>' +
            '<th><a href="Clasificacion?temporadaId=' + temporada + '&competicionId=' + competicion.id + '&categoriaId=' + categoria.id + '"><span class="bi bi-sort-numeric-down" aria-hidden="true"></span></a> Clasificación</th>' +

                '</tr>';
        });
    });
    infoEnt += '</table>';
    infoEnt += '</div>';    //card-body
    infoEnt += '</div>';    //card
    return infoEnt;
};
function printCardJugadores(temporada) {
    var infoEnt = '<div class="card col-5 m-2">';
    infoEnt += '<div class="card-header m-2">';
    infoEnt += '<div class="title">Jugadores</div>'
    infoEnt += '</div>';// card-header
    infoEnt += '<div class="card-body">';
    infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;" id="tbJugadores">';
    infoEnt += '<tr class="filaCompeticion">';
    infoEnt += '<th>Jugador</th>';
    infoEnt += '<th>Club</th>';
    infoEnt += '</tr>';
    //jugadores.forEach(function (jugador, index) {
    //    infoEnt += '<tr>' +
    //        '<td>' + competicion.competicion + '</td>' +
    //        '<td>' + competicion.activa + '</td>' +
    //        '<td>' + competicion.descripcionEstado + '</td>' +
    //        '</tr>' +
    //});
    infoEnt += '</table>';
    infoEnt += '</div>';    //card-body
    infoEnt += '</div>';    //card
    return infoEnt;
};