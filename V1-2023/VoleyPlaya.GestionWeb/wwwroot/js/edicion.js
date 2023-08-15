"use strict";
$(function () {
    document.getElementById('listTipoGrupos').style.display = 'none';

    $("#Edicion_NumGrupos").on("change", function () {
        var num = $(this).val();
        var id = $("#EdicionId").val();
        $.ajax({
            type: "POST",
            url: "/Edicion/UpdateGrupos",
            data: { id: id, numGrupos: num },
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            }, success: function (response) {
                location.reload();
            },
            failure: function (response) {
                alert("Failure");
            },
            error: function (response) {
                alert("Error");
            }
        });
    });
});
$(function () {
    $('.numEquipos').each(function (index) {
        $(this).on('change', function () {
            // Lógica a ejecutar cuando cambia el valor del elemento de texto
            // Puedes usar el índice del elemento en el array con la variable "index"
            var num = $(this).val();
            var id = $("#EdicionId").val();
            var idx = index;
            $.ajax({
            type: "POST",
            url: "/Edicion/UpdateEquipos",
            data: {idEdicion:id, idxGrupo: idx, numEquipos: num },
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            }, success: function (response) {
                location.reload();
            },
            failure: function (response) {
                alert("Failure");
            },
            error: function (response) {
                alert("Error");
            }
        });
            console.log('Elemento de texto en el índice ' + index + ' cambió su valor: ' + $(this).val());
            // ...
        });
    });
});
    //$("#Edicion_NumEquipos").on("change", function () {
    //    var num = $(this).val();
    //    var id = $("#EdicionId").val();
    //    $.ajax({
    //        type: "POST",
    //        url: "/Edicion/UpdateGrupos",
    //        data: { id: id, numGrupos: num },
    //        dataType: "json",
    //        beforeSend: function (xhr) {
    //            xhr.setRequestHeader("XSRF-TOKEN",
    //                $('input:hidden[name="__RequestVerificationToken"]').val());
    //        }, success: function (response) {
    //            location.reload();
    //        },
    //        failure: function (response) {
    //            alert("Failure");
    //        },
    //        error: function (response) {
    //            alert("Error");
    //        }
    //    });
    //});
$(function () {
    $("#Edicion_NumJornadas").on("change", function () {
        var num = $(this).val();
        var id = $("#EdicionId").val();
        $.ajax({
            type: "POST",
            url: "/Edicion/UpdateJornadas",
            data: { id: id, numJornadas: num },
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            }, success: function (response) {
                FillTablaJornadas(response.jorActual, response.jorNuevo);
            },
            failure: function (response) {
                alert("Failure");
            },
            error: function (response) {
                alert("Error");
            }
        });
    });
});
function FillTablaGrupos(actual, nuevo) {
    // completar con tantos grupos como falten hasta llegar a nuevo
    // o eliminar filas
    var $t = $("#tableGrupos");
    var $body = $t.find("tbody");
    var $row = $t.find("tbody tr").last();
    const $select = document.getElementById('listTipoGrupos');
    const $options = Array.from($select.options);
    var fila = "<tr><td><input type='text' name='AddedGrupos[]' placeholder='Nombre del grupo'></td>";
    fila += "<td><select name='AddedTipoGrupo[]'>" + $select.innerHTML;
    fila += "</select></td>";
    fila += "<td><input type='number' name='AddedNumEquipos[]' placeholder='Nº de equipos'></td>"
    fila += "</tr>";

    var act = $('#tableGrupos>tbody>tr').length;
    var filas = nuevo - act;
    if (filas > 0) {
        // añadir
        for (var i = 0; i < filas; i++) {
            $body.append(fila);
        }
    }
    else {
        // borrar
        var count = act - nuevo;
        for (var i = 0; i < count; i++) {
            $row.remove();
            $row = $t.find("tableGrupos tbody tr").last();
        }
    }
};
function FillTablaJornadas(actual, nuevo) {
    // completar con tantas jornadas como falten hasta llegar a nuevo
    // o eliminar filas
    var $t = $("#tableJornadas");
    var $body = $t.find("tbody");
    var $row = $t.find("tbody tr").last();
    var fila = "<tr><td><input type='text' name='AddedJor[]' placeholder='Nº jornada'></td><td><input type='date' name='AddedFechas[]' placeholder='Fecha'></td></tr>";

    var act = $('#tableJornadas>tbody>tr').length;
    var filas = nuevo - act;
    if (filas > 0) {
        // añadir
        for (var i = 0; i < filas; i++) {
            $body.append(fila);
        }
    }
    else {
        // borrar
        var count = act - nuevo;
        for (var i = 0; i < count; i++) {
            $row.remove();
            $row = $t.find("tableJornadas tbody tr").last();
        }
    }
};