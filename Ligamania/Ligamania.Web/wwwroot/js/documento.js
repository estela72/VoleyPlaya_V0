"use strict";
$(document).ready(function () {
    var table;

    $.getJSON('getListaDocumentos', function (documentos) {
        table = $('#tbDocumentos').DataTable({
            "data": documentos,
            "columns": [
                { "data": "documento" },
                { "data": "descripcion" }
                ,
                { "data": "tipo" },
                {
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "width": "15px",
                    "render": function (data, type, row) {
                        return createButton('file', row.id,'tag');
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
    
    //function createFileButton(rowID) {
    //    return '<button class="btn btn-secondary" id="btShowFile" data-id="' + rowID + '"><span class="bi bi-file-earmark-text-fill" aria-hidden="true" ></span>';
    //};

    //// code to read selected table row cell data (values).
    //$(document).on('click', '#btShowFile', function () {
    //    var id = $(this).data('id');
    //    window.open('ShowFile/'+id, "_blank");  
    //});
});
