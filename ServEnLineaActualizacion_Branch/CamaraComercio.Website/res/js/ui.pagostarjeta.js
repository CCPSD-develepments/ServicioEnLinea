$(document).ready(function () {
    //Comentarios
    $('div.comments').hide();
    $('.commentCtrlHov').hover(
        function () { $("#" + this.id + "Comment").show(); },
        function () { $("#" + this.id + "Comment").hide(); }
    );

    //Muestro Div de direcciones en Caso que sea Física
    if ($("#hfFormaEntrega").val() == "F") {
        var divForma = $("#divFormaEntrega");
        if (divForma.lenght > 0)
            divForma.show();
    }
    else {
        var divForma = $("#divFormaEntrega");
        if (divForma.lenght > 0)
            divForma.hide();
    }

    //Mensajes informativos
    if ($("#hfHoraOficina").val() == 1)
        SetOutOfOfficeMessage();
    if ($("#hfServicio").val() == 1)
        SetConstitucionMessage();

    //Validacion de numeros en Textbox
    $("#txtCVV2").numeric();
    $("#txtRnc").numeric();

    //Muestra mensaje cuando se realiza solicitud fuera de horario laboral
    function SetOutOfOfficeMessage() {
        var mensaje = $("<div></div>");
        var msjDisplay = "Esta transacción se está realizando fuera del horario laboral de la cámara. Será registrada en el sistema a las 8:00 AM del próximo día laborable.";
        mensaje.text(msjDisplay).attr("id", "Mensaje");
        $("#login").after(mensaje);
    }

    //Muestra mensaje sobre copias a depositar para la constitucion/registro de nuevas empresas
    function SetConstitucionMessage() {
        $(".esConstitucion").removeClass("hiddenObj");
        $(".esConstitucion").show();
    }
});