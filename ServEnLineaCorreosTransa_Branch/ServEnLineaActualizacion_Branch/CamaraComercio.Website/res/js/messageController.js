/// <reference path="jquery-1.4.1.min.js">
/// <reference path="jquery.bar.js">
function ShowMessage(message) {
    if (message != undefined)
        $().bar.showMessage(message);
    else if ($("#notice > span[id$=lblMessage]").text() != "") {
        message = $("#notice > span[id$=lblMessage]").text();
        $("#notice > span[id$=lblMessage]").text("");
        $().bar.showMessage(message);
    }

}

$(document).ready(function (event) {
    if ($("#notice > span[id$=lblMessage]").text() != "") {
        ShowMessage($("#notice > span[id$=lblMessage]").text());
        $("#notice > span[id$=lblMessage]").text("");
    }
});

function disableAspNEtValidator(valControlName, state) {
    var myVal = document.getElementById(valControlName);
    ValidatorEnable(myVal, state);
}

