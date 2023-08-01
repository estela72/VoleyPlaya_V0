$(document).ready(function () {
    "use strict";    // Return table with id generated from row's name field

    //var competiciones = null;
    //var categorias = null;
    //var puestos = null;
    //var equipos = null;
    var table;
    var nEditing = null;
    var addingRow = false;

    //$.getJSON('GetCompeticiones', function (lista) {
    //    competiciones = lista;
    //});
    //$.getJSON('GetCategorias', function (lista) {
    //    categorias = lista;
    //});
    //$.getJSON('GetPuestos', function (lista) {
    //    puestos = lista;
    //});
    //$.getJSON('GetEquipos', function (lista) {
    //    equipos = lista;
    //});

    function Dropdown(opciones, selected) {
        var html = '<select>';
        opciones.forEach(function (opcion, index) {
            if (opcion === selected)
                html += '<option value=' + opcion + ' selected>' + opcion + '</option>';
            else
                html += '<option value=' + opcion+'>' + opcion + '</option>';
        });
        html += '</select>';
        return html;
    }

    function format(tableId, tableId2) {
        var hijo = '<div class="panel panel-info m-3" sytle="border:1"><h4>Contabilidad</h4>';
        hijo += '<table id="' + tableId + '"class="display-table row-border compact stripe" cellpadding="3" cellspacing="0" border="0" style="padding-left:50px;">' +
            '</table>';
        hijo += '</div><div class="panel panel-info m-3" sytle="border:1"><h4>Premios</h4>';
        hijo += '<table id="' + tableId2 + '"class="display-table row-border compact stripe" cellpadding="3" cellspacing="0" border="0" style="padding-left:50px;">' +
            '</table></div>';
        hijo += '<table id="example" class="display-table" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
            '</table></div>';
        return hijo;
    }

    function editRow(oTable, nRow, data) {
        var aData = oTable.row(nRow).data();

        var jqTds = $('>td', nRow);
        jqTds[0].innerHTML = '<input type="text" value="' + aData.concepto + '">';
        jqTds[1].innerHTML = '<input type="text" value="' + aData.concGasto + '">';
        jqTds[2].innerHTML = '<input type="text" value="' + aData.concIngreso + '">';
        jqTds[3].innerHTML = '<select><option>SI</option><option>NO</option></select>';
        jqTds[4].innerHTML = '<button class="edit save" >[Save]</i>';
        jqTds[5].innerHTML = '<button class="edit cancel" >[Cancel]</i>';
    }
    function saveRow(oTable, nRow, temporada) {
        var jqInputs = $('input', nRow);
        var selects = $('select', nRow);
        var aData = oTable.row(nRow).data();

        const contabilidad = {
            "temporada": temporada,
            "concepto": jqInputs[0].value,
            "concGasto": jqInputs[1].value,
            "concIngreso": jqInputs[2].value,
            "porEquipo": selects[0].value,
            "id": aData.id
        };
        var urlString = '/Contabilidad/UpdateContabilidadTemporada';

        $.ajax({
            type: 'POST',
            url: urlString,
            dataType: 'json',
            data: JSON.stringify(contabilidad),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                alert(result);
                var jqTds = $('>td', nRow);
                jqTds[0].innerHTML = '<label>' + jqInputs[0].value + '</label>';
                jqTds[1].innerHTML = '<label>' + jqInputs[1].value + '</label>';
                jqTds[2].innerHTML = '<label>' + jqInputs[2].value + '</label>';
                jqTds[3].innerHTML = '<label>' + selects[0].value + '</label>';
                jqTds[4].innerHTML = '<button class="edit" >Editar</i>';
                jqTds[5].innerHTML = '<button class="delete" >Borrar</i>';
                oTable.row(nRow).data().concepto = jqInputs[0].value;
                oTable.row(nRow).data().concGasto = jqInputs[1].value;
                oTable.row(nRow).data().concIngreso = jqInputs[2].value;
                oTable.row(nRow).data().porEquipo = selects[0].value;
            },
            error:
                function (response) {
                    alert("Error: " + response);
                }
        });
    }
    function restoreRow(oTable, nRow) {
        var aData = oTable.row(nRow).data();
        var jqTds = $('>td', nRow);
        jqTds[0].innerHTML = '<label>' + aData.concepto + '</label>';
        jqTds[1].innerHTML = '<label>' + aData.concGasto + '</label>';
        jqTds[2].innerHTML = '<label>' + aData.concIngreso + '</label>';
        jqTds[3].innerHTML = '<label>' + aData.porEquipo + '</label>';
        jqTds[4].innerHTML = '<button class="edit" >Editar</i>';
        jqTds[5].innerHTML = '<button class="delete" >Borrar</i>';
    }
    function deleteRow(oTable, nRow) {
        var aData = oTable.row(nRow).data();
        var id = aData.id;

        var urlString = '/Contabilidad/RemoveContabilidadTemporada';

        $.ajax({
            type: 'POST',
            url: urlString,
            dataType: 'json',
            data: JSON.stringify(id),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                alert(result);
                oTable.row(nRow)
                    .remove()
                    .draw();
            },
            error:
                function (response) {
                    alert("Error: " + response);
                }
        });
    }
    function addRow(oTable) {
        var rowNode = oTable
            .row.add(
                {
                    "concepto": '',
                    "concGasto": 0,                    
                    "concIngreso": 0,
                    "porEquipo": 'NO',
                    "id": 0,
                }
            )
            .draw()
            .nodes()
            .to$();
        var jqTds = $('>td', rowNode);
        jqTds[0].innerHTML = '<input type="text" value="">';
        jqTds[1].innerHTML = '<input type="text" value="0">';
        jqTds[2].innerHTML = '<input type="text" value="0">';
        jqTds[3].innerHTML = '<select selected="1"><option>SI</option><option>NO</option></select>';
        jqTds[4].innerHTML = '<button class="edit save" >[Save]</i>';
        jqTds[5].innerHTML = '<button class="edit cancel" >[Cancel]</i>';

        $(rowNode)
            .css('color', 'red')
            .animate({ color: 'black' });

        //editRow(oTable, rowNode);
        nEditing = rowNode;
        addingRow = true;
    }

    function editRowPremio(oTable, nRow, data) {
        var aData = oTable.row(nRow).data();

        var jqTds = $('>td', nRow);
        //jqTds[0].innerHTML = Dropdown(competiciones, aData.competicion);// '<input type="text" value="' + aData.competicion + '">';
        //jqTds[1].innerHTML = Dropdown(categorias, aData.categoria); // '<input type="text" value="' + aData.categoria + '">';
        //jqTds[2].innerHTML = Dropdown(puestos, aData.puestoStr);// '<input type="text" value="' + aData.puesto + '">';
        //jqTds[3].innerHTML = '<input type="text" value="' + aData.equipo +'">';
        jqTds[4].innerHTML = '<input type="text" value="' + aData.premio + '">';
        jqTds[5].innerHTML = '<button class="edit save" >[Save]</i>';
        jqTds[6].innerHTML = '<button class="edit cancel" >[Cancel]</i>';
    }
    function saveRowPremio(oTable, nRow, temporada) {
        var jqInputs = $('input', nRow);
        var selects = $('select', nRow);
        var aData = oTable.row(nRow).data();

        const premio = {
            //"temporada": temporada,
            //"competicion": jqInputs[0].value,
            //"categoria": jqInputs[1].value,
            //"puesto": jqInputs[2].value,
            //"equipo": jqInputs[3].value,
            "premio": jqInputs[0].value,
            "id": aData.id
        };
        var urlString = '/Contabilidad/UpdatePremioTemporada';

        $.ajax({
            type: 'POST',
            url: urlString,
            dataType: 'json',
            data: JSON.stringify(premio),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                alert(result);
                var jqTds = $('>td', nRow);
                //jqTds[0].innerHTML = '<label>' + jqInputs[0].value + '</label>';
                //jqTds[1].innerHTML = '<label>' + jqInputs[1].value + '</label>';
                //jqTds[2].innerHTML = '<label>' + jqInputs[2].value + '</label>';
                //jqTds[3].innerHTML = '<label>' + jqInputs[3].value + '</label>';
                jqTds[4].innerHTML = '<label>' + jqInputs[0].value + '</label>';
                jqTds[5].innerHTML = '<button class="edit" >Editar</i>';
                jqTds[6].innerHTML = '<button class="delete" >Borrar</i>';
                //oTable.row(nRow).data().competicion = jqInputs[0].value;
                //oTable.row(nRow).data().categoria = jqInputs[1].value;
                //oTable.row(nRow).data().puesto = jqInputs[2].value;
                //oTable.row(nRow).data().equipo= jqInputs[3].value;
                oTable.row(nRow).data().premio = jqInputs[0].value;
            },
            error:
                function (response) {
                    alert("Error: " + response);
                }
        });
    }
    function restoreRowPremio(oTable, nRow) {
        var aData = oTable.row(nRow).data();
        var jqTds = $('>td', nRow);
        //jqTds[0].innerHTML = '<label>' + aData.competicion + '</label>';
        //jqTds[1].innerHTML = '<label>' + aData.categoria + '</label>';
        //jqTds[2].innerHTML = '<label>' + aData.puesto + '</label>';
        //jqTds[3].innerHTML = '<label>' + aData.equipo + '</label>';
        jqTds[4].innerHTML = '<label>' + aData.premio + '</label>';
        jqTds[5].innerHTML = '<button class="edit" >Editar</i>';
        jqTds[6].innerHTML = '<button class="delete" >Borrar</i>';
    }
    function deleteRowPremio(oTable, nRow) {
        var aData = oTable.row(nRow).data();
        var id = aData.id;

        var urlString = '/Contabilidad/RemovePremioTemporada';

        $.ajax({
            type: 'POST',
            url: urlString,
            dataType: 'json',
            data: JSON.stringify(id),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                alert(result);
                oTable.row(nRow)
                    .remove()
                    .draw();
            },
            error:
                function (response) {
                    alert("Error: " + response);
                }
        });
    }
    //function addRowPremio(oTable) {
    //    var rowNode = oTable
    //        .row.add(
    //            {
    //                "competicion": '',
    //                "categoria": '',
    //                "puesto": '',
    //                "equipo": '',
    //                "premio": 0,
    //                "id": 0,
    //            }
    //        )
    //        .draw()
    //        .nodes()
    //        .to$();
    //    var jqTds = $('>td', rowNode);
    //    jqTds[0].innerHTML = '<input type="text" value="">';
    //    jqTds[1].innerHTML = '<input type="text" value="">';
    //    jqTds[2].innerHTML = '<input type="text" value="">';
    //    jqTds[3].innerHTML = '<input type="text" value="">';
    //    jqTds[4].innerHTML = '<input type="text" value="0">';
    //    jqTds[5].innerHTML = '<button class="edit save" >[Save]</i>';
    //    jqTds[6].innerHTML = '<button class="edit cancel" >[Cancel]</i>';

    //    $(rowNode)
    //        .css('color', 'red')
    //        .animate({ color: 'black' });

    //    nEditing = rowNode;
    //    addingRow = true;
    //}

    // Main table
    $.getJSON('GetContabilidades', function (contabilidades) {
        table = $('#tbContabilidad').DataTable({
            //ajax: '/Contabilidad/GetContabilidades',
            stateSave: true,
            data: contabilidades,
            pageLength: 10,
            columnDefs: [
                {
                    targets: [0, 1,2,3,4],
                    className: 'dt-center'
                },
            ],
            columns: [
                {
                    className: 'details-control',
                    orderable: false,
                    data: null,
                    render: function () {
                        return '<i class="fas fa-plus-circle openclose" aria-hidden="true"></i>';
                    },
                },
                { data: "temporada" },
                { data: "equipos" },
                {
                    data: "gastos",
                    render: function (data, type) {
                        var number = DataTable.render
                            .number('.', ',', 2)
                            .display(data);
                        return number+' €';
                    }
                },
                {
                    data: "ingresos",
                    render: function (data, type) {
                        var number = DataTable.render
                            .number('.', ',', 2)
                            .display(data);
                        return number+' €';
                    }
                },
                {
                    data: "premios",
                    render: function (data, type) {
                        var number = DataTable.render
                            .number('.', ',', 2)
                            .display(data);
                        return number+' €';
                    }
                }
            ],
            order: [[1, 'asc']],
            //dom: 'Bfrtip',
        });
    });

    // Add event listener for opening and closing first level childdetails
    $('#tbContabilidad tbody').on('click', 'td.details-control', function () {

        var tr = $(this).closest('tr');
        var row = table.row(tr);
        var rowData = row.data();
        // Información de CONCEPTOS
        var id = rowData.temporada;
        var tableName = '#' + id;
        // Información de PREMIOS
        var id2 = rowData.temporada + "Premios";
        var tableNamePremios = '#' + id2;

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
            tr.find('.openclose').attr('data-icon', 'plus-circle');

            // Destroy the Child Datatable
            $(tableName).DataTable().destroy();
        }
        else {
            tr.addClass('shown');
            tr.find('.openclose').attr('data-icon', 'minus-circle');

            // generar la tabla de conceptos
            row.child(format(id,id2)).show();

            // Información de CONCEPTOS
            var childTable = $(tableName).DataTable({
                stateSave: true,
                order: [1, 'asc'],
                select: {
                    style: 'os',
                    selector: 'td:first-child'
                },
                columnDefs: [
                    {
                        targets: [1,2],
                        className: 'dt-body-right'
                    },
                    {
                        targets: 3,
                        className: 'dt-body-center'
                    },
                ],
                data: rowData.conceptos,
                columns: [
                    { data: "concepto", title: 'Concepto' },
                    {
                        data: "concGasto",
                        title: 'Gastos',
                        render: function (data, type) {
                            var number = DataTable.render
                                .number('.', ',', 2)
                                .display(data);
                            return number + ' €';
                        }
                    },
                    {
                        data: "concIngreso",
                        title: 'Ingresos',
                        render: function (data, type) {
                            var number = DataTable.render
                                .number('.', ',', 2)
                                .display(data);
                            return number + ' €';
                        }
                    },
                    {
                        data: "porEquipo",
                        title: 'Por equipo'
                    },
                    {
                        orderable: false,
                        data: null,
                        width: "15px",
                        render: function (data, type, row) {
                            return '<button class="edit" >Editar</i>';
                        }
                    },
                    {
                        orderable: false,
                        data: null,
                        width: "15px",
                        render: function (data, type, row) {
                            return '<button class="delete" >Borrar</i>';
                        }
                    },
                    {
                        data: "id",
                        visible: false
                    }
                ],
            });
            
            $(tableName + ' tbody').on('click', 'button.edit', function (e) {
                e.preventDefault();

                /* Get the row as a parent of the link that was clicked on */
                var nRow = $(this).parents('tr')[0];
                var data = childTable.row(nRow).data();

                if (nEditing !== null && $(this).hasClass("save") && addingRow) {
                    /* This row is being edited and should be saved */
                    saveRow(childTable, nEditing, id);
                    nEditing = null;
                    addingRow = false;
                }
                else if (nEditing !== null && nEditing != nRow) {
                    /* A different row is being edited - the edit should be cancelled and this row edited */
                    restoreRow(childTable, nEditing);
                    editRow(childTable, nRow);
                    nEditing = nRow;
                }
                else if (nEditing == nRow && $(this).hasClass("save") ) {
                    /* This row is being edited and should be saved */
                    saveRow(childTable, nEditing,id);
                    nEditing = null;
                }
                else if (nEditing == nRow && $(this).hasClass("cancel")) {
                    /* This row is being edited and should be saved */
                    restoreRow(childTable, nEditing);
                    nEditing = null;
                }
                else {
                    /* No row currently being edited */
                    editRow(childTable, nRow, data);
                    nEditing = nRow;
                }
            });
            $(tableName + ' tbody').on('click', 'button.delete', function (e) {
                e.preventDefault();

                /* Get the row as a parent of the link that was clicked on */
                var nRow = $(this).parents('tr')[0];
                deleteRow(childTable, nRow);

            });

            new $.fn.dataTable.Buttons(childTable, {
                buttons: [
                    {
                        text: 'Nuevo concepto',
                        action: function (e, dt, node, conf) {
                            addRow(dt);
                        }
                    }
                ]
            });

            childTable.buttons(0, null).container().prependTo(
                childTable.table().container()
            );

            // Información de PREMIOS
            var premiosTable = $(tableNamePremios).DataTable({
                stateSave: true,
                //order: [1, 'asc'], // no ponerlo. Afecta al rowSpan
                //select: {
                //    style: 'os',
                //    selector: 'td:first-child'
                //},
                //columnDefs: [
                //    {
                //        targets: 4,
                //        className: 'dt-body-right'
                //    }
                //],
                columns: [
                    { data: "competicion", title: 'Competición', name:'first'},
                    { data: "categoria", title: 'Categoría'},
                    { data: "puestoStr", title: 'Puesto' },
                    { data: "equipo", title: 'Equipo' },
                    {
                        data: "premio",
                        title: 'Premio',
                        render: function (data, type) {
                            var number = DataTable.render
                                .number('.', ',', 2)
                                .display(data);
                            return number + ' €';
                        }
                    },
                    {
                        orderable: false,
                        data: null,
                        width: "15px",
                        render: function (data, type, row) {
                            return '<button class="edit" >Editar</i>';
                        }
                    },
                    {
                        orderable: false,
                        data: null,
                        width: "15px",
                        render: function (data, type, row) {
                            return '<button class="delete" >Borrar</i>';
                        }
                    },
                    {
                        data: "id",
                        visible: false
                    }
                ],
                data: rowData.repartoPremios,
                rowsGroup:
                    [
                    // Always the array (!) of the column-selectors in specified order to which rows groupping is applied
                    // (column-selector could be any of specified in https://datatables.net/reference/type/column-selector)
                        'first:name',
                        //0,
                        1,
                ],
            });
            $(tableNamePremios + ' tbody').on('click', 'button.edit', function (e) {
                e.preventDefault();

                /* Get the row as a parent of the link that was clicked on */
                var nRow = $(this).parents('tr')[0];
                var data = premiosTable.row(nRow).data();

                if (nEditing !== null && $(this).hasClass("save") && addingRow) {
                    /* This row is being edited and should be saved */
                    saveRowPremio(premiosTable, nEditing, id);
                    nEditing = null;
                    addingRow = false;
                }
                else if (nEditing !== null && nEditing != nRow) {
                    /* A different row is being edited - the edit should be cancelled and this row edited */
                    restoreRowPremio(premiosTable, nEditing);
                    editRowPremio(premiosTable, nRow);
                    nEditing = nRow;
                }
                else if (nEditing == nRow && $(this).hasClass("save")) {
                    /* This row is being edited and should be saved */
                    saveRowPremio(premiosTable, nEditing, id);
                    nEditing = null;
                }
                else if (nEditing == nRow && $(this).hasClass("cancel")) {
                    /* This row is being edited and should be saved */
                    restoreRowPremio(premiosTable, nEditing);
                    nEditing = null;
                }
                else {
                    /* No row currently being edited */
                    editRowPremio(premiosTable, nRow, data);
                    nEditing = nRow;
                }
            });
            $(tableNamePremios + ' tbody').on('click', 'button.delete', function (e) {
                e.preventDefault();

                /* Get the row as a parent of the link that was clicked on */
                var nRow = $(this).parents('tr')[0];
                deleteRowPremio(premiosTable, nRow);

            });

            //new $.fn.dataTable.Buttons(premiosTable, {
            //    buttons: [
            //        {
            //            text: 'Nuevo premio',
            //            action: function (e, dt, node, conf) {
            //                addRowPremio(dt);
            //            }
            //        }
            //    ]
            //});

            //premiosTable.buttons(0, null).container().prependTo(
            //    premiosTable.table().container()
            //);

            //var datatest = [
            //    ['subgroupN', 'Group1', 'sub-subgroupN', 'ElementN', '2Element N'],
            //    ['subgroup1', 'Group2', 'sub-subgroup1', 'Element1', '2Element 1'],
            //    ['subgroup2', 'Group2', 'sub-subgroup1', 'Element1', '2Element 1'],
            //    ['subgroup2', 'Group2', 'sub-subgroup1', 'Element2', '2Element 2'],
            //    ['subgroup2', 'Group2', 'sub-subgroup2', 'Element3', '2Element 2'],
            //    ['subgroup2', 'Group2', 'sub-subgroup2', 'Element4', '2Element 4'],
            //    ['subgroup2', 'Group2', 'sub-subgroup2', 'Element2', '2Element 2'],
            //    ['subgroup3', 'Group1', 'sub-subgroup1', 'Element1', '2Element 1'],
            //    ['subgroup3', 'Group1', 'sub-subgroup1', 'Element1', '2Element 1'],
            //    ['subgroup2', 'Group2', 'sub-subgroup2', 'Element1', '2Element 1'],
            //    ['subgroup4', 'Group2', 'sub-subgroup2', 'Element1', '2Element 1'],
            //    ['subgroup4', 'Group2', 'sub-subgroup3', 'Element10', '2Element 17'],
            //    ['subgroup4', 'Group2', 'sub-subgroup3', 'Element231', '2Element 211'],

            //];
            //var tabletest = $('#example').DataTable({
            //    columns: [
            //        {
            //            title: 'First group',
            //            name:'second'
            //        },
            //        {
            //            //name: 'second',
            //            title: 'Second group [order first]',
            //        },
            //        {
            //            title: 'Third group',
            //        },
            //        {
            //            title: 'Forth ungrouped',
            //        },
            //        {
            //            title: 'Fifth ungrouped',
            //        },
            //    ],
            //    data: datatest,
            //    rowsGroup: [// Always the array (!) of the column-selectors in specified order to which rows groupping is applied
            //        // (column-selector could be any of specified in https://datatables.net/reference/type/column-selector)
            //        //'second:name',
            //        1,
            //        2
            //    ],
            //    pageLength: '20',
            //});
        }
    });
});