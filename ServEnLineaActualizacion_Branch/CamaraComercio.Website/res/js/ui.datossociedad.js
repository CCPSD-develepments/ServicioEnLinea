//Manejo de Fancybox
function pageLoad() {
    var fancyboxDivs = $(".fboxMensajes");
    $(fancyboxDivs).fancybox(
            {
                'centerOnScroll': true, 'titleShow': false,
                'overlayShow': true, 'hideOnContentClick': false,
                'hideOnOverlayClick': true, 'width': 650,
                'height': 800, 'padding': 0,
                'onClosed': loadRepresentantes
            });
}

//Carga de panel de representantes
function loadRepresentantes() {
    $(".panelSociosUpdate").get(0).control.ajaxRequest();
}

//Variables para Facebook Textbox
var t, t2, t3;

$(document).ready(function () {
    //Cal to action del panel de socios y botón adicional
    $("#divManejoSocios").hide();
    if ($("#hfSosciosVisible").val() == "0") {
        $("#cto_socios").hide();
        $("#divManejoSocios").show();
    }
    $("#cto_socios").click(function () {
        $("#cto_socios").hide();
        $("#divManejoSocios").fadeIn("slow");
        javascript: __doPostBack('ctl00$MainContent$ManejoSocios1$rgSocios$ctl00$ctl02$ctl00$InitInsertButton', '')
        $("#hfSosciosVisible").val("0");
    });
    $("#btnAddSocios").click(function () {
        $("#cto_socios").hide();
        $("#divManejoSocios").fadeIn("slow");
        javascript: __doPostBack('ctl00$MainContent$ManejoSocios1$rgSocios$ctl00$ctl02$ctl00$InitInsertButton', '')
        $("#hfSosciosVisible").val("0");
        return false;
    });

    // Duracion de sociedades indefinidas
    $('#ddlDuracionSociedad').change(function () {
        if ($(this).val() == "2") {
            $('#txtDuracionSociedad').show();
            disableAspNEtValidator("txtDuracionSociedadReq", true);
        } else {
            $('#txtDuracionSociedad').hide();
            disableAspNEtValidator("txtDuracionSociedadReq", false);
        }
    });
    $('#txtDuracionSociedad').hide(); //Se esconde durante el primer load de la página

    // Empresas reguladas
    $('.radio-empleados input').change(function () {
        if ($(this).val() == "Si") {
            $('#pnlEmpresasReguladas').show('fast');
        }
        else {
            $('#pnlEmpresasReguladas').hide('fast');
        }
    });
    $('#pnlEmpresasReguladas').hide();

    // Restringiendo campos a valor numerico
    $('.inputDuracionSociedad').numeric();
    var rnc = $('#txtRNC');
    if (rnc != undefined)
        rnc.numeric();
    $('#MainContent_txtNoRecibo').numeric();
    var noAcciones = $('.noAcciones');
    if (noAcciones.length > 0)
        $('.noAcciones').numeric();

    //Verificando empresas sin capital
    var chkLlevaCapital = $('#chkLlevaCapitalSocial');
    var txtCapSocial = $("#liCapitalSocial .tb");
    chkLlevaCapital.click(function () {
        if (chkLlevaCapital.is(':checked')) {
            txtCapSocial.attr("disabled", "disabled");
            $('#MainContent_txtCapitalSocialNuevo').val("0");
            $('#MainContent_txtCapitalSocialNuevo_Value').val("0");
            $('#MainContent_txtCapitalSocialNuevo_text').val("0");
            txtCapSocial.val("RD$0.00");
        }
        else {
            txtCapSocial.removeAttr("disabled");
            $('#MainContent_txtCapitalSocialNuevo').val("");
            $('#MainContent_txtCapitalSocialNuevo_Value').val("");
            $('#MainContent_txtCapitalSocialNuevo_text').val("");
            txtCapSocial.val("");
        }
    });

    //Texboxes para cantidad de empleados
    // Calculando valor del total de empleados
    $('.inputEmpleados').change(function () {
        CalcNumeroDeEmpleados();
    });
    $('.inputEmpleados').keyup(function () {
        CalcNumeroDeEmpleados();
    });
    // Restringiendo los campos a valor numerico
    $('.inputEmpleados').numeric();
    $('.inputEmpleados').fieldtag();
    //Forzando un select all para Internet Explorer 
    $('.inputEmpleados').click(function () {
        this.focus();
        this.select();
    });

    //Instanciando el control de Facebook Tags para las sucursales
    t = new $.TextboxList('#txtSucursales', { bitsOptions: { editable: { addKeys: [188, 9, 59]}} });
    t.addEvent('focus', function () { showdiv('#txtSucursalesComment'); });
    t.addEvent('bitBoxAdd', function (newEntry) {
        if (typeof newEntry != 'undefined') {
            if (newEntry.value[1] == "") {
                newEntry.remove();
                $('#txtEmpleadosM').focus();
            }
        }
    });
    t.addEvent('blur', function () {
        hidediv('#txtSucursalesComment');

        //Se verifica si hay objetos en edicion
        var controlEdicion = $('#liSucursales .textboxlist-bit-editable-input:last');
        var valorActual = controlEdicion.val();
        if (typeof valorActual != 'undefined' && valorActual.length > 0) {
            controlEdicion.val("");
            t.add(valorActual);
        }

        //Tab en blanco para salir del control
        var arr = t.getValues();
        var str = "";
        var cant = arr.length;

        //Asignacion de valores en el Hidden Field
        for (var i = 0; i < cant; i++) {
            str += arr[i][1];
            if (i != cant - 1) str += ",";
        }
        $('#hfTxtSucursales').val(str);
    });
    //Llenando el control con bits en caso de estar abriendo una modificacion/adecuacion
    var hfSucursales = $('#hfTxtSucursales');
    if (hfSucursales.val().length > 0) {
        var arrVals = hfSucursales.val().split(",");
        for (var i = 0; i < arrVals.length; i++) {
            var valor = arrVals[i].replace(";null", "").replace("null").replace(";", "");
            if (typeof (valor) != "undefined" && valor.length > 0 && valor != "undefined")
                t.add(valor);
        }
    }

    //Instanciando el control de Facebook Tags para las referencias comerciales
    t2 = new $.TextboxList('#txtReferenciasComerciales', { bitsOptions: { editable: { addKeys: [188, 9, 59]}} });
    t2.addEvent('focus', function () { showdiv('#txtReferenciasComercialesComment'); });
    t2.addEvent('bitBoxAdd', function (newEntry) {
        if (typeof newEntry != 'undefined') {
            if (newEntry.value[1] == "") {
                newEntry.remove();
                $('#txtReferenciasBancarias').focus();
            }
        }
    });
    t2.addEvent('blur', function () {
        hidediv('#txtReferenciasComercialesComment');

        //Se verifica si hay objetos en edicion
        var controlEdicion = $('#liReferenciasComerciales .textboxlist-bit-editable-input:last');
        var valorActual = controlEdicion.val();
        if (typeof valorActual != 'undefined' && valorActual.length > 0) {
            controlEdicion.val("");
            t2.add(valorActual);
        }

        //Tab en blanco para salir del control
        var arr = t2.getValues();
        var str = "";
        var cant = arr.length;

        //Asignacion de valores en el Hidden Field
        for (var i = 0; i < cant; i++) {
            str += arr[i][1];
            if (i != cant - 1) str += ",";
        }
        $('#hfReferenciasComerciales').val(str);
    });

    //Llenando el control con bits en caso de estar abriendo una modificacion/adecuacion
    var hfComerciales = $('#hfReferenciasComerciales');
    if (hfComerciales.val().length > 0) {
        var arrVals = hfComerciales.val().split(",");
        for (var i = 0; i < arrVals.length; i++) {
            var valor = arrVals[i].replace(";null", "").replace("null", "").replace(";", "");
            if (typeof (valor) != "undefined" && valor.length > 0 && valor != "undefined")
                t2.add(valor);
        }
    }

    //Instanciando el control de Facebook Tags para las sucursales
    t3 = crearControlRefBancarias();

    t3.addEvent('bitBoxAdd', function (newEntry) {
        if (typeof newEntry != 'undefined') {
            if (newEntry.value[1] == "") {
                newEntry.remove();
                $('#txtNombreComercialNumero').focus();
            }
        }

        //Tab en blanco para salir del control
        var arr = t3.getValues();
        var str = "";
        var cant = arr.length;

        //Asignacion de valores en el Hidden Field
        for (var i = 0; i < cant; i++) {
            var x = arr[i][0];
            var y = arr[i][1];

            if (x != undefined && typeof (x) != "undefined" && x != "undefined" &&
                y != undefined && typeof (y) != "undefined" && y != "undefined") {
                str += x + "," + y;
                if (i != cant - 1) str += ";";
            }
        }
        $('#hfReferenciasBancarias').val(str);
    });
    t3.addEvent('focus', function () { showdiv('#txtReferenciasBancariasComment'); });
    
    t3.addEvent('bitBoxRemove', function () {
        //Tab en blanco para salir del control
        var arr = t3.getValues();
        var str = "";
        var cant = arr.length;

        //Asignacion de valores en el Hidden Field
        for (var i = 0; i < cant; i++) {
            var x = arr[i][0];
            var y = arr[i][1];

            if (x != undefined && typeof (x) != "undefined" && x != "undefined" &&
                y != undefined && typeof (y) != "undefined" && y != "undefined") {
                str += x + "," + y;
                if (i != cant - 1) str += ";";
            }
        }
        $('#hfReferenciasBancarias').val(str);
    });

    t3.addEvent('blur', function () {
        //Caja de comentarios
        hidediv('#txtReferenciasBancariasComment');

        //Se verifica si hay objetos en edicion
        var controlEdicion = $('#liReferenciasBancarias .textboxlist-bit-editable-input:last');
        var valorActual = controlEdicion.val();
        if (typeof valorActual != 'undefined' && valorActual.length > 0) {
            controlEdicion.val("");
        }

        //Tab en blanco para salir del control
        var arr = t3.getValues();
        var str = "";
        var cant = arr.length;

        //Asignacion de valores en el Hidden Field
        for (var i = 0; i < cant; i++) {
            var x = arr[i][0];
            var y = arr[i][1];

            if (x != undefined && typeof (x) != "undefined" && x != "undefined" &&
                y != undefined && typeof (y) != "undefined" && y != "undefined") {
                str += x + "," + y;
                if (i != cant - 1) str += ";";
            }
        }
        $('#hfReferenciasBancarias').val(str);
    });

    //Llenando el control con bits en caso de estar abriendo una modificacion/adecuacion
    var hfBancarias = $('#hfReferenciasBancarias');
    if (hfBancarias.val().length > 0) {
        $("#txtReferenciasBancarias")[0].value = "";
        $("#liReferenciasBancarias .textboxlist").remove();
        t3 = crearControlRefBancarias();
        var valores = t3.getValues();

        var arrVals = hfBancarias.val().split(";");
        for (var i = 0; i < arrVals.length; i++) {
            var entrada = arrVals[i];
            var id = entrada.substring(0, entrada.indexOf(",")).replace(";null", "").replace("null", "").replace(";", "");
            var nombre = entrada.substring(entrada.indexOf(",") + 1).replace(";null", "").replace("null", "").replace(";", "");

            if (typeof (id) != "undefined" && id.length > 0 && id != "undefined"
                && id != "null" && id != undefined && typeof (nombre) != "undefined"
                && nombre.length > 0 && nombre != "undefined" && nombre != "null"
                && nombre != undefined) {
                t3.add(nombre, id, nombre);
            }
        }
    }
});

//Calculo del número de empleados para los formularios DatosSociedad.aspx
function CalcNumeroDeEmpleados() {
    var empleadosM = Number($('#txtEmpleadosM').val());
    var empleadosF = Number($('#txtEmpleadosF').val());

    var result = 0;

    if (!isNaN(empleadosM)) {
        result += empleadosM;
    }

    if (!isNaN(empleadosF)) {
        result += empleadosF;
    }

    $('#total-empleados').html(result);
}

function crearControlRefBancarias() {
    var t3 =new $.TextboxList('#txtReferenciasBancarias',
        { bitsOptions: { editable: { addKeys: [188, 9]} },
            plugins: { autocomplete: { minLength: 3, queryRemote: false} }
        });
    var autocomplete = t3.plugins['autocomplete'];
    $.ajax({
        type: 'GET',
        url: '/api.aspx',
        dataType: 'json',
        success: function (data) {
            var results = [];
            results.push("[");
            $.each(data, function (i, banco) {
                results.push("[" + banco.BancoId + ",\"" + banco.Text + "\",\"" + banco.Html + "\",\"" + banco.Comment + "\"]");
                if (i != data.length - 1)
                    results.push(", ");
            });
            results.push("]");
            autocomplete.setValues(eval(results.join("")));
        },
        error: function (err) {
            //TODO: Add Error Message
        },
        data: { op: "bancos" },
        async: false
    });

    return t3;
}