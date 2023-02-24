"use strict";
$(document).ready(function () {
    var table;

    $.getJSON('getListaJugadores', function (jugadores) {
        table = $('#tbJugadores').DataTable({
            "data": jugadores,
            "columns": [
                { "data": "jugador" },
                { "data": "baja" },
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
            "order": [[2, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        })
    });
});