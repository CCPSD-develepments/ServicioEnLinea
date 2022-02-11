$(document).ready(function() {

    // Se esconden todos los DIVs de comentarios al cargar el form por primera vez
    $('div.comments').hide();

});

function showdiv(divName) {
    $(divName).show();
}

function hidediv(divName) {
    $(divName).hide();
}

