"use strict";

var listJugadores = $('.jug_dualListBox');
var listTemporadas = $('#temporadas');
var listClubs = $('#clubs');
var listPuestos = $('#puestos');
var jugBaja = $('.jug_dualListBox').val();
var selClub = "";
var selPuesto = "";

$(document).ready(function () {
    var selectedClub = $('#selClub').val();
    var selectedPuesto = $('#selPuesto').val();

    $.getJSON('getListaTemporadas', function (temporadas) {
        temporadas.forEach(function (temporada, index) {
            listTemporadas.append('<option value=' + temporada.temporada + '>' + temporada.temporada + '</option>');
        });
    });
    $.getJSON('getListaClubs', function (clubs) {
        listClubs.append('<option value="   "></option>');
        clubs.forEach(function (club, index) {
            if (club.alias === selectedClub) {
                listClubs.append('<option value=' + club.alias + ' selected>' + club.clubAlias + '</option>');
            }
            else {
                listClubs.append('<option value=' + club.alias + '>' + club.clubAlias + '</option>');
            }
        });
    });
    $.getJSON('getListaPuestos', function (puestos) {
        listPuestos.append('<option value="   "></option>');
        puestos.forEach(function (puesto, index) {
            if (puesto === selectedPuesto) {
                listPuestos.append('<option value=' + puesto + ' selected>' + puesto + '</option>');
            }
            else {
                listPuestos.append('<option value=' + puesto + '>' + puesto + '</option>');
            }
        });
    });
    listJugadores.bootstrapDualListbox({
        nonSelectedListLabel: 'Jugadores en la temporada actual',
        selectedListLabel: 'Jugadores de baja',
        preserveSelectionOnMove: 'moved',
        moveOnSelect: false,
        nonSelectedFilter: '',
        filterTextClear: 'Todos los jugadores',
        filterPlaceHolder: 'Filtrar',
        selectorMinimalHeight: 300,
        showFilterInputs: true,
        infoText: 'Mostrando {0} jugadores',
        infoTextEmpty: 'Lista vacía',
        infoTextFiltered: '<span class="label label-warning">Filtrados</span> {0} de {1}',
        // sets the button style class for all the buttons
        btnMoveText: '&gt;',
        btnRemoveText: '&lt;',
        btnMoveAllText: '&gt;&gt;',
        btnRemoveAllText: '&lt;&lt;',
        btnClass: 'btn-outline-secondary'
    });
    listJugadores.bootstrapDualListbox('eventRemoveOverride', true);
    listJugadores.bootstrapDualListbox('eventRemoveAllOverride', true);
    listJugadores.bootstrapDualListbox('eventMoveOverride', true);
    listJugadores.bootstrapDualListbox('eventMoveAllOverride', true);

    spinner.style.visibility = 'hidden'; //'visible'
});
function loadJugadores(club, puesto) {
    let spinner = document.getElementById("spinner");
    spinner.style.visibility = 'visible'; //'hidden'
    listJugadores.empty();
    const filtro = {
        "club": club,
        "puesto": puesto
    };
    $.getJSON('getListaJugadoresTemporada', filtro, function () {
    }).done(function (jugadores) {
        jugadores.forEach(function (jugador, index) {
            if (jugador.activo === "NO")
                addJugadorBaja(jugador.jugador, jugador.jugador);
            else
                addJugador(jugador.jugador, jugador.alias);
        });
    }).fail(function () {
        alert("error");
    }).always(function () {
        listJugadores.bootstrapDualListbox('eventRemoveOverride', true);
        listJugadores.bootstrapDualListbox('eventRemoveAllOverride', true);

        listJugadores.bootstrapDualListbox('refresh', true);
        jugBaja = $('.jug_dualListBox').val();
        spinner.style.visibility = 'hidden'; //'visible'
    });
};

function addJugador(jugador, alias) {
    listJugadores.append('<option value="' + jugador + '">' + alias + '</option>');
}
function addJugadorBaja(jugador, alias) {
    listJugadores.append('<option value="' + jugador + '" selected>' + alias + '</option>');
}

$(document).on("click", ".remove", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listJugadores.val();
    var diff = arr_diff(jugBaja, list);

    var club = $('#clubs').val();
    var puesto = $('#puestos').val();

    var texto = 'Pasar los jugadores ' + diff + ' al club ' + club + ' en el puesto ' + puesto;
    var alerta = $('#cambios');
    alerta.val(alerta.val() + "\n\r" + texto);
    $('#cambios').val(texto);

    alert(texto);
    spinner.style.visibility = 'hidden'; //'visible'

});
$(document).on("click", ".removeAll", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listJugadores.val();
    var diff = arr_diff(jugBaja, list);

    var club = $('#clubs').val();
    var puesto = $('#puestos').val();

    alert('Pasar TODOS los jugadores ' + diff + ' al club ' + club + ' en el puesto ' + puesto);
    spinner.style.visibility = 'hidden'; //'visible'

});

$(document).on("click", ".move", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    alert("Mover");
    spinner.style.visibility = 'hidden'; //'visible'

});
$(document).on("click", ".moveAll", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    alert('Mover TODOS');
    spinner.style.visibility = 'hidden'; //'visible'

});


$('#copiarJug').on('click', function () {
    alert('copiar jugadores');
});

$('#exportar').on('click', function () {
    alert('exportar');
});

$('#cargarExcel').on('click', function () {
    alert('cargar');
});

$("#selForm").on('click', function () {
    var club = $('#clubs').val();
    var puesto = $('#puestos').val();
    selClub = club;
    selPuesto = puesto;
    loadJugadores(club, puesto);
});
function arr_diff(a1, a2) {

    a1 = a1 || [];
    a2 = a2 || [];

    var a = [], diff = [];

    for (var i = 0; i < a1.length; i++) {
        a[a1[i]] = true;
    }

    for (var i = 0; i < a2.length; i++) {
        if (a[a2[i]]) {
            delete a[a2[i]];
        } else {
            a[a2[i]] = true;
        }
    }

    for (var k in a) {
        diff.push(k);
    }

    return diff;
};
$("#taJugForm").submit(function () {
    //var jugBaja = $('[name="jugadores[]"]').val();
    var jugAlta = $('[name="jugadores[]_helper1"]').val();
    var jugToBaja = $('[name="jugadores[]_helper2"]').val();
    var club = $('#clubs').val();
    var puesto = $('#puestos').val();
    selClub = club;
    selPuesto = puesto;

    var jugadores = new Array();
    jugAlta.forEach(function (jugador, index) {
        var item = {};
        item.Id = 0;
        item.Jugador = jugador;
        item.Alias = '';
        item.Activo = 'SI';
        item.Club = club;
        item.Puesto = puesto;
        jugadores.push(item);
    });
    jugToBaja.forEach(function (jugador, index) {
        var item = {};
        item.Id = 0;
        item.Jugador = jugador;
        item.Alias = '';
        item.Activo = 'NO';
        item.Club = club;
        item.Puesto = puesto;
        jugadores.push(item);
    });

    var urlString = 'UpdateJugadores';

    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(jugadores),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            alert(result);
            location.reload();
        },
        error:
            function (response) {
                alert("Error: " + response);
            }
    });
    return false;
});
