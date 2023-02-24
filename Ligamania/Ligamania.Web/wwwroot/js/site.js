// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//$(document).ready(function () {
//    $('#sidebarCollapse').on('click', function () {
//        $('#sidebar, #content').toggleClass('active');
//        $('.collapse.in').toggleClass('in');
//        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
//    });
//});

function createButton(buttonType, rowID, tag) {
    if (buttonType === "edit") {
        return '<a class="' + tag + '" href="Edit?id=' + rowID + '"><span class="bi bi-pencil-square" aria-hidden="true"></span></a>';
    }
    if (buttonType === "delete") {
        return '<a class="' + tag + '" href="Delete?id=' + rowID + '"><span class="bi bi-trash-fill" aria-hidden="true"></span></a>';
    }
    if (buttonType === "confirm") {
        return '<a class="' + tag + '" href="Confirm?id=' + rowID + '"><span class="bi bi-check-circle-fill" aria-hidden="true"></span></a>';
    }
    if (buttonType === "notConfirm") {
        return '<a class="' + tag + '" href="NotConfirm?id=' + rowID + '"><span class="bi bi-x-circle-fill" aria-hidden="true"></span></a>';
    }
    if (buttonType === "file") {
        return '<a class="' + tag + '" href="ShowFile?id=' + rowID + '" target="_blank"><span class="bi bi-file-earmark-text-fill" aria-hidden="true"></span></a>';
    }
    if (buttonType === "clasificacion") {
        return '<a class="' + tag + '" href="ShowClasificacion?id=' + rowID + '" target="_blank"><span class="bi bi-card-image" aria-hidden="true"></span></a>';
    }
};

function sortJson(element, prop, propType, asc) {
    switch (propType) {
        case "int":
            element = element.sort(function (a, b) {
                if (asc) {
                    return (parseInt(a[prop]) > parseInt(b[prop])) ? 1 : ((parseInt(a[prop]) < parseInt(b[prop])) ? -1 : 0);
                } else {
                    return (parseInt(b[prop]) > parseInt(a[prop])) ? 1 : ((parseInt(b[prop]) < parseInt(a[prop])) ? -1 : 0);
                }
            });
            break;
        default:
            element = element.sort(function (a, b) {
                if (asc) {
                    return (a[prop].toLowerCase() > b[prop].toLowerCase()) ? 1 : ((a[prop].toLowerCase() < b[prop].toLowerCase()) ? -1 : 0);
                } else {
                    return (b[prop].toLowerCase() > a[prop].toLowerCase()) ? 1 : ((b[prop].toLowerCase() < a[prop].toLowerCase()) ? -1 : 0);
                }
            });
    }
}