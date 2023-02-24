"use strict";

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

$(document).ready(function () {
    var table;

    $.getJSON('getListaClubsTemporada', function (clubs) {
        clubs.forEach(function (club, index) {
            if (club.baja === "SI")
                addClubBaja(club.clubAlias);
            else
                addClub(club.clubAlias);
        });
        listClubs.bootstrapDualListbox('refresh', true);
    });
});

function addClub(club){
    listClubs.append('<option value=' + club + '>' + club + '</option>');
}
function addClubBaja(club) {
    listClubs.append('<option value=' + club + ' selected>' + club + '</option>');
}

$("#taClubsForm").submit(function () {
    var clubsBaja = $('[name="clubs[]"]').val();
    var clubs = new Array();
    clubsBaja.forEach(function (club, index) {
        var item = {};
        item.Id = 0;
        item.Club = '';
        item.Alias = club;
        item.Baja = 'SI';
        clubs.push(item);
    });
    var urlString = 'UpdateClubs';

    $.ajax({
        type: 'POST',
        url: urlString,
        dataType: 'json',
        data: JSON.stringify(clubs),
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
