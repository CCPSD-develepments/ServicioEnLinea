/// <reference path="jquery-1.4.1-vsdoc.js" />

//Bindeo del Grid
function rebindGrid() {
    if ($(".gridEnviados").length > 0) {
        $(".gridEnviados")[0].control.get_masterTableView().rebind();
    }
}

//Click forzado del botón de subir documentos
function triggerFileUpload() {
    document.getElementById("uploadDocumento").click();
}

//Seleccion de un archivo en el file upload
function uploadChangeEvent(titulo) {
    var txt = $("#uploadText");
    var btn = $("#btnUploadDocumento");
    var ddl = $("#ddlTipoDocumento");
    
    if (titulo.length > 0) {
        btn.fadeIn();
        ddl.fadeIn();
        txt.html(titulo);
    }
    else {
        btn.hide();
        ddl.hide();
        txt.html("Seleccionar Documento");
    }
}


$(document).ready(function () {
    //Variables
    var dataBeforeChange;

    //Deshabilitando botones
    if ($.browser.msie) {
        $("#divUpload").hide();
        $("#divUploadIE").css("visibility", "visible");
        $("#divUploadIE").css("display", "table");
    }
    else {
        $("#divUploadIE").css("visibility", "hidden").hide();
        $("#btnUploadDocumento").hide();
        $("#ddlTipoDocumento").hide();
    }

    //Manejo de eventos del footer
    //$('#FooterDiv').hide();
    $('#FooterButton').hide();
    $('#FooterDiv').fadeIn();
    $('#FooterButton').click(function () {
        $('#FooterButton').hide();
        $('#FooterDiv').fadeIn();
        return false;
    });

    //Updates del grid de descripcion de documentos / tipo de doc
    $(".onFlyUpdate").live('blur', function () {
        var element = $(this);
        var parentElement = element.parent("td").parent("tr");


        $('#loading').ajaxStart(function () {
            $(this).show().insertAfter(element);
            $(this).css("padding-left", "8px");
        });
        $('#loading').ajaxStop(function () {
            $(this).hide();
        });

        var Descripcion = parentElement.find("td > [id$=DescripcionLabel]").val();
        var TipoDocumentoId = parentElement.find("td > [id$=ddlTiposDocumentos]").val();
        var TransaccionesDocumentosId = parentElement.find("td > [id$=hfTransaccionDocumentoId]").val();
        var FirmaDigital = parentElement.find("td span > [id$=chkFirmasDigital]")[0].checked;

        // Comentado porque no se detecta el valor anterior si lo que cambia es FirmaDigital.
        //if (element.val() != dataBeforeChange)
        {

            $.ajax({
                type: 'POST',
                url: '/Services/EnvioDatos.asmx/UpdateDocumentosInfo',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify({ transaccionesDocumentosId: TransaccionesDocumentosId, descripcion: Descripcion, tipoDocumentoId: TipoDocumentoId, firmaDigital: FirmaDigital }),
                success: function (data) {
                    if (Number(data.d) == 1) {

                        $("#imgSucceed").show().insertAfter(element);
                        $("#imgSucceed").css("padding-left", "8px");
                        setTimeout(function () { $("#imgSucceed").fadeOut("slow") }, 5000);

                        $("input[type=checkbox][id$=chkEnviados]").attr("checked", false);

                        $("[id*=hfTipoDocumento]").each(function () {

                            if (Number($(this).val()) == TipoDocumentoId) {
                                $(this).parent("td").find("input[type=checkbox]").attr("checked", "true");
                            }
                        });
                    }
                    else {
                        $([id$ = lblMessage]).text("Ya has cargado este tipo de documento, selecciona uno diferente.");
                        parentElement.find("td > [id$=ddlTiposDocumentos]").val("-1");
                        ShowMessage();
                    }
                }
            });
        }

    });

    $(".firmaDigital").live('change', function () {
        var element = $(this);
        var parentElement = element.parent("td").parent("tr");


        $('#loading').ajaxStart(function () {
            $(this).show().insertAfter(element);
            $(this).css("padding-left", "8px");
        });
        $('#loading').ajaxStop(function () {
            $(this).hide();
        });

        var Descripcion = parentElement.find("td > [id$=DescripcionLabel]").val();
        var TipoDocumentoId = parentElement.find("td > [id$=ddlTiposDocumentos]").val();
        var TransaccionesDocumentosId = parentElement.find("td > [id$=hfTransaccionDocumentoId]").val();
        var FirmaDigital = parentElement.find("td span > [id$=chkFirmasDigital]")[0].checked;

        if (element.val() != dataBeforeChange) {

            $.ajax({
                type: 'POST',
                url: '/Services/EnvioDatos.asmx/UpdateDocumentosInfo',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify({ transaccionesDocumentosId: TransaccionesDocumentosId, descripcion: Descripcion, tipoDocumentoId: TipoDocumentoId, firmaDigital: FirmaDigital }),
                success: function (data) {
                    if (Number(data.d) == 1) {

                        $("#imgSucceed").show().insertAfter(element);
                        $("#imgSucceed").css("padding-left", "8px");
                        setTimeout(function () { $("#imgSucceed").fadeOut("slow") }, 5000);

                        $("input[type=checkbox][id$=chkEnviados]").attr("checked", false);

                        $("[id*=hfTipoDocumento]").each(function () {

                            if (Number($(this).val()) == TipoDocumentoId) {
                                $(this).parent("td").find("input[type=checkbox]").attr("checked", "true");
                            }
                        });
                    }
                    else {
                        $([id$ = lblMessage]).text("En este momento no podemos procesar tu solicitud. Intente nuevamente más tarde2.");
                        ShowMessage();
                    }
                }
            });
        }

    });

    $(".onFlyUpdate").live('focus', function () {
        dataBeforeChange = $(this).val();
    });

    //Envio de la transaccion y mensaje de advertencia
    $("#btnEnviarTransaccion").click(function (e) {

        e.preventDefault();

        $("#dialog:ui-dialog").dialog("destroy");
        $("#dialog-confirm").attr("title", "Confirmación de Envio de Transacción");
        $("#dialog-content").html("<p>La transacción sólo debe ser enviada cuando se han subido todos los documentos requeridos y "
                                  + "desee que un analista procese su solicitud. </p> "
                                  + "<p> Recuerde que los documentos enviados deben poseer una firma digital válida para "
                                  + "poder ser aceptados por la Cámara. </p>"
                                  + "<p><span>¿Está seguro que desea enviar la transacción?</span></p>");

        $("#dialog-confirm").dialog({
            resizable: false,
            height: 350,
            width: 460,
            modal: true,
            buttons: {
                "Enviar Transacción": function () {
                    $(this).dialog("close");

                    __doPostBack('ctl00$MainContent$btnEnviarTransaccion', '');
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });
    });


    var idusuario = $('input[id$=hfusuarioID]').val();
    var idsolicitud = $('input[id$=hfsolicitudID]').val();
    var idSession = $('input[id$=hfSessionID]').val();

});