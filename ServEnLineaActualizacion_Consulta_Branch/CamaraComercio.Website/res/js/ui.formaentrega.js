$(document).ready(function () {
      $('#navigation li').removeClass("active");
      $('#subnavigation li').removeClass("active");
      $('#liNavRM').addClass("active");
});

function showDialog() {

    $("#dialog:ui-dialog").dialog("destroy");
    $("#dialog-confirm").attr("title", "Confirmación de Firma Digital");
    var texto = "Solo podra enviar documentos si posee una firma digital. si usted no tiene una firma digital, puede visitar el portal de DigiFirma y adquirir una.";
    $("#dialog-content").text(texto);
    $("#dialog-confirm").dialog({
        resizable: false,
        height: 350,
        width: 460,
        modal: true,
        buttons: {
            "Poseo Firma Digital": function () {
                $(this).dialog("close");
                top.window.location.href = $('#hlEnvioDatos').get(0).href;
            },
            Cancel: function () {
                $(this).dialog("close");
            },
            "Adquirir Firma Digital": function () {
                $(this).dialog("close");
                window.open("http://201.229.155.124/pki/pub", "DigiFirma");
            }
        }
    });
}

function validateFirmaDigital(e) {
    var url = "/Services/EnvioDatos.asmx/GetUsuarioFirmaDigital";
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data) {
            var result = $(data).text();
            if (result == "false") {
                showDialog();
            }
            else {
                top.window.location.href = url;
            }
        },
        error: function (data) { }

    });
}