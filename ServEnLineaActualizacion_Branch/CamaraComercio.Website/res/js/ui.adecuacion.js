$(document).ready(function () {
    // Manejo de comentarios
    $('div.comments').hide();
    $('.commentCtrl').focus(function () {
        $("#" + this.id + "Comment").show();
    });
    $('.commentCtrl').blur(function () {
        $("#" + this.id + "Comment").hide();
    });
    $('.commentCtrlHov').hover(
        function () { $("#" + this.id + "Comment").show(); },
        function () { $("#" + this.id + "Comment").hide(); }
    );

    //Sumatoria de validaciones
    $(".btnFormNext").click(function () {
        if (typeof (Page_ClientValidate) == 'function') {
            Page_ClientValidate();
        }

        //Se limpian todos los errores
        var validadores = $(".validator.summary");
        for (var i = 0; i < validadores.length; i++){
            var valid = validadores.eq(i);
            valid.parent().removeClass("errorli");
        }

        //Se recorre la colección para verificar si existen errores y marcarlos
        if (Page_IsValid != undefined && !Page_IsValid) {
            for (var i = 0; i < validadores.length; i++) {
                var valid = validadores.eq(i);
                if (!valid[0].isvalid) {
                    valid.parent().addClass("errorli");
                    valid.html("");
                }
            }
            return false;
        }
    });

    // Checkbox del usuario administrador en el panel de socios
    $('.chkAdmin').change(function () {
        if ($(this).attr('checked')) {
            $('.cargoAdmDdl').show('fast');
        } else {
            $('.cargoAdmDdl').hide('fast');
        }
    });

    //Funcionalidad para Recibo DGII
    if ($("#hfNuevoRegistro").val() == 1) {
        $('#pnlInformacionDGII').show('fast');
    }
    else {
        $('#pnlInformacionDGII').hide('fast');
    }

    // Modificacion denominacion social
    $('.inputDenominacion').hide();

    $('#modificarDenomSocial').click(function () {
        $('.inputDenominacion').show();

        $('.inputDenominacion').val($('.denominacion span').text());

        $(this).hide();
        $('.denominacion span').hide();
    });


    //Empleados
    $('.radio-empleados input').click(function () {
        $(this).change();
    });

    $('.radio-nacionalidad input').click(function () {
        $(this).change();
    });

    $('.chkAdmin').click(function () {
        $(this).change();
    });
});

//Metodo para mostrar/esconder las ayudas del form
function showdiv(divName) {
    var reqName = divName.substr(0, divName.indexOf("Comment"));
    var reqField = $(reqName + "Req");
    if (reqField != undefined) {
        if (reqField.length == 0) {
            $(divName).show();
            return;
        }
        else {
            //Quiere decir que existe un validador. Se comprueba si no esta visible para mostrar el div de comentarios
            if (reqField.css('visibility') == 'hidden') 
            {
                $(divName).show();
                return;
            }
        }
    }
    else {
        $(divName).show();
        return;
    }
}

function hidediv(divName) {
    $(divName).hide();
}

function panelHide(validationControl, paneltohide) {
    alert($(validationControl).find("input[@checked]").val());
}

var toggleSwitch = 0;

function ToggleCargo() {

    if (toggleSwitch == 1) {
        hidediv('.trCargoDdl');
        $(".trCargoDdl").hide();
        toggleSwitch = 0;
        return false;
    }

    if (toggleSwitch == 0) {
        showdiv('.trCargoDdl');
        $(".trCargoDdl").show();
        toggleSwitch = 1;
        return false;
    }
}
function showCargo() {
    var isAdmin = $(".chkAdmin");
    if (isAdmin.length > 0)
        if (isAdmin.is(':checked'))
            showdiv('.trCargoDdl');
        else
            hidediv('.trCargoDdl');

}

