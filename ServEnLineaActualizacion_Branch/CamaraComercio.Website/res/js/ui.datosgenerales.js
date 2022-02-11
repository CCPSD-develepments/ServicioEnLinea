$(document).ready(function () {
    //Mostrando o escondiendo el div para nacionalidad en caso de empresas locales
    var ddAdecuacion = $('#ddAdecuacion');
    var ddNacionalidad = $('#divNacionalidad');

    //Primer Load
    if (!EmpresaExtranjeraSeleccionada(ddAdecuacion)) {
        $('#ddlCiudad').show();
        $('#ddlSector').show();
        $('#txtCiudad').hide();
        $('#lblSectores').hide();
        ddNacionalidad.hide();
    }

    // Masked inputs
    $('.inputTelefonoPrimario').mask('(999) 999-9999');
    $('.inputTelefonoSecundario').mask('(999) 999-9999');
    $('.inputFax').mask('(999) 999-9999');
    $('#txtApartadoPostal').numeric();

    //Funcion para cambio del dropdown de tipos de sociedades
    ddAdecuacion.change(function () {
        var x = 0;

        if (EmpresaExtranjeraSeleccionada(ddAdecuacion)) {
            ddNacionalidad.show();
        }
        else {
            var paisDefault = $('#hfPaisIdRepDominicana').val();
            ddNacionalidad.hide();
            $('#ddlPais').val(paisDefault);
        }
    });

    //Instanciando el control de Facebook Tags para las actividades
    t = new $.TextboxList('#txtPrincipalesProductos', { bitsOptions: { editable: { addKeys: [188, 9, 59]}} });
    t.addEvent('focus', function () { $('#txtPrincipalesProductosComment').show(); });
    t.addEvent('bitBoxAdd', function (newEntry) {
        if (typeof newEntry != 'undefined') {
            if (newEntry.value[1] == "" || newEntry.value[0] == "") {
                newEntry.remove();
                $('#btnDatosGeneralesLlenos').focus();
            }
        }
    });
    t.addEvent('bitRemove', function (removedEntry) {
        setHfValues(t, $('#hfProductos'), $('#hfCantidadProductos'));
    });
    t.addEvent('blur', function () {
        //Se esconde el div de comentarios
        $('#txtPrincipalesProductosComment').hide();

        //Se verifica si hay objetos en edicion
        var controlEdicion = $('.textboxlist-bit-editable-input:last');
        var valorActual = controlEdicion.val();
        if (typeof valorActual != 'undefined' && valorActual.length > 0) {
            controlEdicion.val("");
            t.add(valorActual);
        }

        setHfValues(t, $('#hfProductos'), $('#hfCantidadProductos'));
    });

    //Llenando el control con bits en caso de estar abriendo una modificacion/adecuacion
    var hfProductos = $('#hfProductos');
    if (hfProductos.val().length > 0) {
        var arrVals = hfProductos.val().split(",");
        var counter = 0;
        for (var i = 0; i < arrVals.length; i++) {
            var valor = arrVals[i];
            if (typeof (valor) != "undefined" && valor.length > 0) {

                valor = valor.replace(";null", "").replace("null", "").replace("undefined", "").replace(";", "");
                if (valor.length > 0) {
                    counter = counter + 1;
                    t.add(valor);
                }
            }
        }
        $('#hfCantidadProductos').val(counter);
    }

    //Actividades - Facebook Tags
    var t2 = new $.TextboxList('#txtActividades',
        { bitsOptions: { editable: { addKeys: [9]} },
            plugins: { autocomplete: { minLength: 3, queryRemote: false} }
        });
    var autocomplete = t2.plugins['autocomplete'];
    $.ajax({
        type: 'GET',
        url: '/api.aspx',
        dataType: 'json',
        success: function (data) {
            var results = [];
            results.push("[");
            $.each(data, function (i, activ) {
                results.push("[" + activ.id + ",\"" + activ.nombreCompleto + "\",\"" + activ.nombreCompleto + "\",\"" + "" + "\"]");
                if (i != data.length - 1)
                    results.push(", ");
            });
            results.push("]");
            autocomplete.setValues(eval(results.join("")));
        },
        error: function (err) {
            //TODO: Add Error Message
        },
        data: { op: "actividadesqry" },
        async: false
    });

    t2.addEvent('focus', function () { $('#txtActividadesComment').show(); });

    t2.addEvent('bitBoxAdd', function (newEntry) {
        if (typeof newEntry != 'undefined') {
            if (newEntry.value[0] == "" || newEntry.value[0] == null || newEntry.value[0] == "null") {
                newEntry.remove();
                $('#btnDatosGeneralesLlenos').focus();
            }
        }
    });

    t2.addEvent('bitRemove', function (removedEntry) {
        setHfValues(t2, $('#hfActividades'), $('#hfActividadesCantidad'));

    });
    t2.addEvent('blur', function () {
        //Se esconde el box con los comentarios
        $('#txtActividadesComment').hide();
        //Se verifica si hay objetos en edicion
        var controlEdicion = $('#liActividades .textboxlist-bit-editable-input');
        for (var i = 0; i < controlEdicion.length; i++) {
            var valorActual = controlEdicion.eq(i).val();
            if (typeof valorActual != 'undefined' && valorActual.length > 0) {
                controlEdicion.eq(i).val("");
            }
        }
        setHfValues(t2, $('#hfActividades'), $('#hfActividadesCantidad'));
    });

    //Llenando el control con bits en caso de estar abriendo una modificacion/adecuacion
    var hfActividades = $('#hfActividades');
    if (hfActividades.val().length > 0) {
        var arrVals = hfActividades.val().split(";");
        for (var i = 0; i < arrVals.length; i++) {
            var entrada = arrVals[i];
            var id = entrada.substring(0, entrada.indexOf(",")).replace(";null", "").replace("null", "").replace("undefined", "").replace(";", "");
            var nombre = entrada.substring(entrada.indexOf(",") + 1).replace(";null", "").replace("null", "").replace("undefined", "").replace(";", "");
            t2.add(nombre, id, '');
        }
    }

    //Actividades - Flyout Dropdown Menu
    $.ajax({ type: 'GET', url: '/api.aspx?op=actividadestree', dataType: 'json',
        async: false,
        success: function (data) {
            var ls = dibujarListado(data);

            $("#btnActividades").menu({
                content: ls,
                maxHeight: 180,
                flyOut: true,
                backLink: false
            });

            $("#btnActividades").click(function () {
                $(".nmMenuItem").unbind('click');
                $(".nmMenuItem").click(function () {
                    //Se agrega el item seleccionado
                    var nombre = this.attributes["rel"].value;
                    var id = this.id;
                    t2.add(nombre, id, '');
                    setHfValues(t2, $('#hfActividades'), $('#hfActividadesCantidad'));

                    //Se devuele falso para evitar llamar un link vacio en el browser
                    return false;
                });
            });
        }
    });

    //Boton btnDatosGeneralesLlenos. Validacion de texboxlists para que guarden correctamente en los HF
    $("#btnDatosGeneralesLlenos").click(function () {
        //Actividades
        var controlEdicion = $('#liActividades .textboxlist-bit-editable-input');
        for (var i = 0; i < controlEdicion.length; i++) {
            var valorActual = controlEdicion.eq(i).val();
            if (typeof valorActual != 'undefined' && valorActual.length > 0) {
                controlEdicion.eq(i).val("");
            }
        }
        
        setHfValues(t2, $('#hfActividades'), $('#hfActividadesCantidad'));

        //Productos
        var controlEdicionPr = $('.textboxlist-bit-editable-input:last');
        var valorActualPr = controlEdicionPr.val();
        if (typeof valorActualPr != 'undefined' && valorActualPr.length > 0) {
            controlEdicionPr.val("");
            t.add(valorActualPr);
        }
        setHfValues(t, $('#hfProductos'), $('#hfCantidadProductos'));
    });

});

//Indica si se ha seleccionado una empresa extranjera en el dropdown de tipos de sociedades
function EmpresaExtranjeraSeleccionada(ddAdecuacion) {
    var empresas = $('#hfEmpresasExtranjeras');
    if (typeof empresas != 'undefined' && empresas.val() != undefined) {
        var arrEmpresas = empresas.val().split(",");
        for (var j = 0; j < arrEmpresas.length; j++) {
            if (ddAdecuacion.val() == arrEmpresas[j]) {
                return true;
            }
        }
        return false;
    }
}

function dibujarListado(actividad) {
    if (typeof actividad != 'undefined' && actividad != undefined
                    && typeof actividad.ActividadesHijas != 'undefined' && actividad.ActividadesHijas.length > 0) {

        var count = actividad.ActividadesHijas.length;
        var listStr = "<ul>";

        for (var i = 0; i < count; i++) {
            listStr = listStr + "<li><a href='#' class='nmMenuItem' rel='" + actividad.ActividadesHijas[i].DescripcionLarga + "' id='" 
                        + actividad.ActividadesHijas[i].ID + "'>"
                        + actividad.ActividadesHijas[i].Descripcion + "</a>";
            listStr = listStr + dibujarListado(actividad.ActividadesHijas[i]);
            listStr = listStr + "</li>";
        }
        return listStr + "</ul>";
    }
    else {
        return "";
    }
}

//Valores de Hidden Fields
function setHfValues(tbox, valores, cantidades) {
    //Tab en blanco para salir del control
    var arr = tbox.getValues();
    var str = "";
    var cant = arr.length;
    //Asignacion de valores en el Hidden Field
    for (var i = 0; i < cant; i++) {
        str += arr[i][0] + "," + arr[i][1];
        if (i != cant - 1) str += ";";
    }
    valores.val(str);
    cantidades.val(cant);
}

//Validacion personalizada Client-Side 
function ValidateActividades(sender, args) {
    //Validacion para el control de .NET
    var v = $("#hfActividadesCantidad");
    args.IsValid = (v.val().length > 0);
}
//Validacion personalizada Client-Side 
function ValidateProductos(sender, args) {
    //Validacion para el control de .NET
    var v = $("#hfCantidadProductos");
    args.IsValid = (v.val().length > 0);
}