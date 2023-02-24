"use strict";
$(document).ready(function () {
    var table;
    var roles;
    $.getJSON('getListaRoles', function (model) {
        roles = model;
        table = $('#tbRoles').DataTable({
            "data": model,
            "columns": [
                {
                    "className": 'details-control',
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "render": function () {
                        return '<i class="fas fa-plus-circle" aria-hidden="true"></i>';
                    },
                    "width": "15px"
                },
                //{ "data": "id" },
                { "data": "name" },
                { "data": "description" },
                { "data": "numberOfUsers" }
            ],
            "order": [[1, "asc"]],
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });
    });
    // Add event listener for opening and closing details
    $('#tbRoles tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);
        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
            tr.find('svg').attr('data-icon', 'plus-circle');
        }
        else {
            // Open this row
            getDetails(row.data(), function (details, rol) {
                var tabla = getTabla(details, roles, rol);
                row.child(tabla).show();
                tr.addClass('shown');
                tr.find('svg').attr('data-icon', 'minus-circle'); // FontAwesome 5
            });
        }
    });
});
$(document).on('click', '.check-user', function () {
    if (!$(this).prop("checked")) {
        $("#checkAll").prop("checked", false);
    }
});
$(document).on('click', '#checkAll', function () {
    $(".check-user").prop('checked', $(this).prop('checked'));
});
$(document).on('click', '#btNuevoRol', function () {
    var usuarios = [];
    // crear una lista con todos los usuarios seleccionados
    //Loop through all checked CheckBoxes in GridView.
    $("#tbUsuarios input[type=checkbox]:checked").each(function () {
        var row = $(this).closest("tr")[0];
        usuarios.push(row.cells[1].innerHTML);
    });
    var rolSelected = $("#newRol").val();

    // llamar a la función del controller que actualice el rol a los usuarios
    var urlString = 'UpdateRoles';
    $.ajax({
        type: 'POST',
        async: false,
        url: urlString,
        data: { newRol: rolSelected, usuarios: usuarios },
        dataType: 'json',
        success: function (response) {
            alert("Roles actualizados");
        },
        failure: function (response) {
            alert("Se ha producido un error al actualizar los roles");
        }
    }).done(function (response) {
    });
    location.reload();
});

/* Formatting function for row details - modify as you need */
function getDetails(rol, callbackDetails) {
    getTablaDetalle(rol, function (tabla) {
        callbackDetails(tabla, rol.name);
    });
};
function getTablaDetalle(rol, callbackUsuarios) {
    var urlString = 'getListaUsuariosByRol?name=' + rol.name;
    return $.ajax({
        type: 'GET',
        url: urlString,
        dataType: 'json',
        success: function (response) {
            callbackUsuarios(response.usuarios);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
};
function callbackDetails(tabla) {
    return tabla;
};
function getTabla(usuarios, roles, rol) {
    var infoEnt = '';
    infoEnt = '<div class="row">';
    infoEnt += '<div class="card col-6 m-2">';
    infoEnt += '<div class="card-header m-2">';
    infoEnt += '<input type="checkbox" class="checkAll" name="checkAll" id="checkAll"/><label class="label m-2">Seleccionar todo</label>';
    infoEnt += '<label class="label m-2">Nuevo rol: </label><select class="col-4" id="newRol"><option>Seleccionar un rol</option>';
    infoEnt += createSelect(roles, "newRol");
    infoEnt += '</select>';
    infoEnt += '<button class="btn-primary m-2" id="btNuevoRol">Cambiar rol</button>';
    infoEnt += '</div>';// card-header
    infoEnt += '<div class="card-body">';
    infoEnt += '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;" id="tbUsuarios">';
    usuarios.forEach(function (usuario, index) {
        infoEnt += '<tr>' +
            '<td><input type="checkbox" class="check-user" id="check-user" name="check-user"/></td>' +
            '<th>' + usuario.userName + '</th>' +
            '<th><a href="DeleteFromRole?userName=' + usuario.userName + '&rolName=' + rol + '"><span class="fas fa-trash-alt" aria-hidden="true"></span></a></th>' +
            '</tr>';
    });
    infoEnt += '</table>';
    infoEnt += '</div>';    //card-body
    infoEnt += '</div>';    //card
    infoEnt += '</div>';    //row
    return infoEnt;
};
function createSelect(options, listName) {
    var optionsText = '';
    $.each(options, function (index, item) {
        optionsText += '<option value=' + item.name + '>' + item.name + '</option>';
    });
    return optionsText;
}