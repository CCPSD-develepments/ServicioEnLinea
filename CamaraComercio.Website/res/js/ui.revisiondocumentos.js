$(document).ready(function () {
    var docsAdicionales = $("#hfDocsAdicionales").val();

    //Se esconden los objetos del UI correspondientes
    $(".calValidator").hide();
    if (docsAdicionales == "false") {
        $("#divAgregarDocs").hide();
        docsAdicionales = false;

        $("#divAgregarDocsLink a").click(function () {
            $("#divAgregarDocsLink").hide();
            $("#divAgregarDocs").show("normal");
            $("#hfDocsAdicionales").val("true");

            //Retorna falso para no hacer click en el hyperlink
            return false;
        });
    }
    else {
        $("#divAgregarDocsLink").hide();
    }

    //Tambien se calculan los rows individuales. Para Originales y copias
    var gratisCopia = $("#hfCantExCopia").val();
    var gratisOriginal = $("#hfCantExOriginal").val();
    var rCopias = $(".inputNumerico.copia");
    var rOriginales = $(".inputNumerico.original");

    for (var i = 0; i < rCopias.length; i++) {
        calculateRow(rCopias[i], ".hfCostoCopiaRow", ".lblCostoCopia", gratisCopia);
    }
    for (var j = 0; j < rOriginales.length; j++) {
        calculateRow(rOriginales[j], ".hfCostoOriginalRow", ".lblCostoOriginal", gratisOriginal);
    }

    //Se activa la validacion para textboxes numericos
    $(".inputNumerico").numeric();
    $(".original.main").spinner({ min: 1, max: 1, increment: 1 });
    $(".original.grupo").spinner({ min: 0, max: 1, increment: 1 });
    $(".original.agregados").spinner({ min: 0, max: 1, increment: 1 });
    $(".copia").spinner({ min: 0, max: 100, increment: 1 });

    //Calculo por row de los docs seleccionados
    $(".inputNumerico.original").live("change keyup", function () {
        var gratisOriginal = $("#hfCantExOriginal").val();
        calculateRow(this, ".hfCostoOriginalRow", ".lblCostoOriginal", gratisOriginal);
    });
    $(".inputNumerico.copia").live("change keyup", function () {
        var gratisCopia = $("#hfCantExCopia").val();
        calculateRow(this, ".hfCostoCopiaRow", ".lblCostoCopia", gratisCopia);
    });

    $(".original").live("blur", function () {
        if ($(this).val() == '')
            $(this).val("0");

        if (Number($(this).val()) < 0)
            $(this).val("0");
        else
            if (Number($(this).val()) > 1)
                $(this).val("1");

        calculateTotal();
    });

    //Se calcula el costo al momento de cargar la pantalla
    calculateTotal();

    //Se muestran los mensajes de ayuda para los documentos que tienen descripcion
    var rowsNombreDoc = $(".NombreDocumento");
    for (var i = 0; i < rowsNombreDoc.length; i++) {
        var hf = rowsNombreDoc.eq(i).find("input").val();
        if (hf.length > 0) {
            rowsNombreDoc.eq(i).find("span").append("&nbsp;<img src='/res/img/icons/help.png' title='" + hf + "'/> ");
        }
    }
    $(".NombreDocumento img[title]").tooltip();

    function calculateTotal() {
        var gratisOriginal = $("#hfCantExOriginal").val();
        var gratisCopia = $("#hfCantExCopia").val();
        var total = 0;

        $(".inputNumerico").each(function () {
            var result = $(this).parent("td").find("[id*=hfCosto]").val();
            var cantidad = Number($(this).val()) > 0 ? Number($(this).val()) - gratisOriginal : 0;

            result = result * cantidad;
            total += result;
        });
        var txtCosto = $('#txtCosto');
        txtCosto.val(total);
        txtCosto.formatCurrency({ symbol: "RD$" });
    }

    $.urlParam = function (name) {
        var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (!results) { return 0; }
        return results[1] || 0;
    }

    function calculateRow(thisObj, rowSelector, labelSelector, cantExentas) {
        //Row Actual y costo por original
        var tdObj = thisObj.parentNode.parentNode;
        var indx = tdObj.rowIndex;
        var hfCosto = $(tdObj).find(rowSelector + " input")

        //Cantidad de documentos seleccionados
        if ($(thisObj).val() == '')
            $(thisObj).val("0");
        var cantOriginal = $(thisObj).val();

        //Calculo del monto y despliegue en labels
        var cantFinal = (cantOriginal - cantExentas > -1) ? cantOriginal - cantExentas : 0;
        var costoFinal = cantFinal * hfCosto.val();
        var costoLabel = $(tdObj).find(labelSelector);
        costoLabel.text(costoFinal);
        costoLabel.formatCurrency({ symbol: "" });

        //Validacion de calendarios para grupos
        var calTextbox = $(tdObj).find(".riTextBox:eq(0)");
        var objCal = $(tdObj).find(".calValidator");
        if (cantOriginal > 0) {
            if (calTextbox.val() == "") {
                objCal.show();
            }
            else {
                objCal.hide();
            }
        }
        else {
            objCal.hide();
        }

        calculateTotal();
    }
});