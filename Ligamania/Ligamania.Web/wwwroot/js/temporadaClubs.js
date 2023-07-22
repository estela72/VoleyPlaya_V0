"use strict";

var listClubs = $('.clubs_dualListBox');
var clubsBaja = $('.clubs_dualListBox').val();
var spinner = document.getElementById("spinner");

$(document).ready(function () {
    spinner.style.visibility = 'visible'; //'visible'
    var listClubs = $('.clubs_dualListBox').bootstrapDualListbox({
        nonSelectedListLabel: 'Clubs en la temporada actual',
        selectedListLabel: 'Clubs de baja',
        preserveSelectionOnMove: 'moved',
        moveOnSelect: false,
        nonSelectedFilter: '',
        filterTextClear: 'Todos los clubs',
        filterPlaceHolder: 'Filtrar',
        selectorMinimalHeight: 300,
        showFilterInputs: true,
        infoText: 'Mostrando {0} clubs',
        infoTextEmpty: 'Lista vacía',
        // sets the button style class for all the buttons
        btnMoveText: '&gt;',
        btnRemoveText: '&lt;',
        btnMoveAllText: '&gt;&gt;',
        btnRemoveAllText: '&lt;&lt;',
        btnClass: 'btn-outline-secondary'
    });
    listClubs.bootstrapDualListbox('eventRemoveOverride', true);
    listClubs.bootstrapDualListbox('eventRemoveAllOverride', true);
    listClubs.bootstrapDualListbox('eventMoveOverride', true);
    listClubs.bootstrapDualListbox('eventMoveAllOverride', true);

    loadClubs();
    spinner.style.visibility = 'hidden'; //'visible'

});

function loadClubs() {
    listClubs.empty();

    $.getJSON('getListaClubsTemporada', function (clubs) {
    }).done(function (clubs) {
        clubs.forEach(function (club, index) {
            if (club.baja === "SI")
                addClubBaja(club.clubAlias);
            else
                addClub(club.clubAlias);
        });
    }).fail(function () {
        alert("error");
    }).always(function () {
        listClubs.bootstrapDualListbox('eventRemoveOverride', true);
        listClubs.bootstrapDualListbox('eventRemoveAllOverride', true);
        listClubs.bootstrapDualListbox('refresh', true);
        clubsBaja = $('.clubs_dualListBox').val();
    });
};

function addClub(club){
    listClubs.append('<option value=' + club + '>' + club + '</option>');
}
function addClubBaja(club) {
    listClubs.append('<option value=' + club + ' selected>' + club + '</option>');
}

// mueve de la lista derecha a la lista izquierda
$(document).on("click", ".remove", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listClubs.val();
    var diff = arr_diff(clubsBaja, list);

    var clubs = new Array();
    if (diff && diff.length > 0) {
        diff.forEach(function (club) {
            var item = {};
            item.Id = 0;
            item.Club = '';
            item.Alias = club;
            item.Baja = 'NO';
            clubs.push(item);
        });
    }
    var urlString = 'UpdateClubs';
    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(clubs),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            loadClubs();
            clubsBaja = $('.clubs_dualListBox').val();
            listClubs.bootstrapDualListbox('refresh', true);
            alert(result);
            spinner.style.visibility = 'hidden'; //'visible'
        },
        error:
            function (response) {
                alert("Error: " + response);
                spinner.style.visibility = 'hidden'; //'visible'
            }
    });
});

// mueve elementos de la lista izquierda a la derecha (baja de clubs)
$(document).on("click", ".move", function () {
    spinner.style.visibility = 'visible'; //'hidden'

    var list = listClubs.val();
    var diff = arr_diff(clubsBaja, list);

    var clubs = new Array();
    if (diff && diff.length > 0) {
        diff.forEach(function (club) {
            var item = {};
            item.Id = 0;
            item.Club = '';
            item.Alias = club;
            item.Baja = 'SI';
            clubs.push(item);
        });
    }
    var urlString = 'UpdateClubs';
    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(clubs),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            loadClubs();
            clubsBaja = $('.clubs_dualListBox').val();
            listClubs.bootstrapDualListbox('refresh', true);
            alert(result);
            spinner.style.visibility = 'hidden'; //'visible'
        },
        error:
            function (response) {
                alert("Error: " + response);
                spinner.style.visibility = 'hidden'; //'visible'
            }
    });
});
// mueve todos los elementos de la lista izquierda a la derecha (baja de todos los jugadores)
$(document).on("click", ".moveAll", function () {
    spinner.style.visibility = 'visible'; //'hidden'
    spinner.style.visibility = 'hidden'; //'visible'
});
/* pasa todos los elementos de la lista derecha a la izquierda*/
$(document).on("click", ".removeAll", function () {
    spinner.style.visibility = 'visible'; //'hidden'
    spinner.style.visibility = 'hidden'; //'visible'
});

//$("#taClubsForm").submit(function () {
//    var clubsBaja = $('[name="clubs[]"]').val();
//    var clubs = new Array();
//    clubsBaja.forEach(function (club, index) {
//        var item = {};
//        item.Id = 0;
//        item.Club = '';
//        item.Alias = club;
//        item.Baja = 'SI';
//        clubs.push(item);
//    });
//    var urlString = 'UpdateClubs';

//    $.ajax({
//        type: 'POST',
//        url: urlString,
//        dataType: 'json',
//        data: JSON.stringify(clubs),
//        contentType: "application/json; charset=utf-8",
//        success: function (result) {
//            alert(result);
//            location.reload();
//        },
//        error:
//            function (response) {
//                alert("Error: " + response);
//            }
//    });
//    return false;
//});
