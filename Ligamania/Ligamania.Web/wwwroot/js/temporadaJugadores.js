"use strict";

var listJugadores = $('.jug_dualListBox');
var listTemporadas = $('#temporadas');
var listClubs = $('#clubs');
var listPuestos = $('#puestos');
var listClubsNuevo = $('#clubsNuevo');
var listPuestosNuevo = $('#puestosNuevo');
var jugBaja = $('.jug_dualListBox').val();
var spinner = document.getElementById("spinner");
var selClub = "";
var selPuesto = "";
var altaJugadores = [];
var bajaJugadores = [];

$(document).ready(function () {
    var selectedClub = $('#selClub').val();
    var selectedPuesto = $('#selPuesto').val();

    spinner.style.visibility = 'visible'; //'visible'

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
                listClubsNuevo.append('<option value=' + club.alias + ' selected>' + club.clubAlias + '</option>');
            }
            else {
                listClubs.append('<option value=' + club.alias + '>' + club.clubAlias + '</option>');
                listClubsNuevo.append('<option value=' + club.alias + '>' + club.clubAlias + '</option>');
            }
        });
    });
    $.getJSON('getListaPuestos', function (puestos) {
        listPuestos.append('<option value="   "></option>');
        puestos.forEach(function (puesto, index) {
            if (puesto === selectedPuesto) {
                listPuestos.append('<option value=' + puesto + ' selected>' + puesto + '</option>');
                listPuestosNuevo.append('<option value=' + puesto + ' selected>' + puesto + '</option>');
            }
            else {
                listPuestos.append('<option value=' + puesto + '>' + puesto + '</option>');
                listPuestosNuevo.append('<option value=' + puesto + ' selected>' + puesto + '</option>');
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
        showClear: false,
        showFilterInputs: true,
        sortByInputOrder: true,
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
        $('#clubs').val(club);
        $('#puestos').val(puesto);
        listJugadores.bootstrapDualListbox('refresh', true);
        jugBaja = $('.jug_dualListBox').val();
    });
};

function addJugador(jugador, alias) {
    listJugadores.append('<option value="' + jugador + '">' + alias + '</option>');
}
function addJugadorBaja(jugador, alias) {
    listJugadores.append('<option value="' + jugador + '" selected>' + alias + '</option>');
}

function updateCambios() {
    var texto = "Altas: ";
    altaJugadores.forEach(function (item) {
        texto += item + "; ";
    });
    texto += '\n\r';
    texto += "Bajas: ";
    bajaJugadores.forEach(function (item) {
        texto += item + "; ";
    });
    texto += '\n\r';
    var formattedItems = '<span class="label label-info">' + texto + '</span> ';
    // Actualiza el contenido del contenedor con los elementos formateados
    $('#selectedItemsContainer').html(formattedItems);

};

// mueve de la lista derecha a la lista izquierda
$(document).on("click", ".remove", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listJugadores.val();
    var diff = arr_diff(jugBaja, list);

    var club = $('#clubs').val();
    var puesto = $('#puestos').val();

    if (club === "" || puesto === "") {
        alert("Se debe especificar club y puesto para mover un jugador a la temporada actual");
        return;
    }

    var jugadores = new Array();
    if (diff && diff.length > 0) {
        diff.forEach(function (item) {
            var jugador = club + ' - ' + puesto + ' - ' + item;

            var jug = {};
            jug.Id = 0;
            jug.Jugador = item;
            jug.Alias = '';
            jug.Activo = 'SI';
            jug.Club = club;
            jug.Puesto = puesto;
            jugadores.push(jug);

            altaJugadores.push(jugador);
        });
    }
    var urlString = 'UpdateJugadores';
    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(jugadores),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            loadJugadores(club, puesto);
            jugBaja = $('.jug_dualListBox').val();
            listJugadores.bootstrapDualListbox('refresh', true);
            alert(result);
        },
        error:
            function (response) {
                alert("Error: " + response);
            }
    });
    spinner.style.visibility = 'hidden'; //'visible'
});

// mueve elementos de la lista izquierda a la derecha (baja de jugadores)
$(document).on("click", ".move", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listJugadores.val();
    var diff = arr_diff(jugBaja, list);

    var club = $('#clubs').val();
    var puesto = $('#puestos').val();

    var jugadores = new Array();
    if (diff && diff.length > 0) {
        diff.forEach(function (item) {
            var jugador = item;

            var jug = {};
            jug.Id = 0;
            jug.Jugador = jugador;
            jug.Alias = '';
            jug.Activo = 'NO';
            jug.Club = '';
            jug.Puesto = '';
            jugadores.push(jug);

            bajaJugadores.push(jugador);
        });
    }
    var urlString = 'UpdateJugadores';
    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(jugadores),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            loadJugadores(club, puesto);
            jugBaja = $('.jug_dualListBox').val();
            listJugadores.bootstrapDualListbox('refresh', true);
            alert(result);
        },
        error:
            function (response) {
                alert("Error: " + response);
            }
    });
    spinner.style.visibility = 'hidden'; //'visible'
});
// mueve todos los elementos de la lista izquierda a la derecha (baja de todos los jugadores)
$(document).on("click", ".moveAll", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    alert('Mover TODOS');
    spinner.style.visibility = 'hidden'; //'visible'

});
/* pasa todos los elementos de la lista derecha a la izquierda*/
$(document).on("click", ".removeAll", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listJugadores.val();
    var diff = arr_diff(jugBaja, list);

    var club = $('#clubs').val();
    var puesto = $('#puestos').val();

    alert('Pasar TODOS los jugadores ' + diff + ' al club ' + club + ' en el puesto ' + puesto);
    spinner.style.visibility = 'hidden'; //'visible'

});


$('#copiarJug').on('click', function () {
    //alert('copiar jugadores sin implementar');
    var temporada = $('#temporadas').val();
    var urlString = 'CopiarJugadoresTemporada';

    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(temporada),
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

$('#exportar').on('click', function () {
    alert('exportar sin implementar');
});

$('#cargarExcel').on('click', function () {
    alert('cargar sin implementar');
});

$('#crearJug').on('click', function () {
    //alert('crear jugador sin implementar');
    var jugador = $('#nuevoJugador').val();
    var puesto = $('#puestosNuevo').val();
    var club = $('#clubsNuevo').val();
    const item = {
        "club": club,
        "puesto": puesto,
        "jugador": jugador
    };
    var urlString = 'NuevoJugadorTemporada';

    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(item),
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

$("#selForm").on('click', function () {
    spinner.style.visibility = 'visible'; //'hidden'
    var club = $('#clubs').val();
    var puesto = $('#puestos').val();
    selClub = club;
    selPuesto = puesto;
    loadJugadores(club, puesto);
    spinner.style.visibility = 'hidden'; //'visible'
});
