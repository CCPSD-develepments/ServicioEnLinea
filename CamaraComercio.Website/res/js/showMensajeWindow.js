/// <reference path="jquery-1.4.1.min.js">
$(document).ready(function () {
    $('.fboxMensajes').fancybox(
                {
                    'centerOnScroll': true, 'titleShow': false,
                    'overlayShow': true, 'hideOnContentClick': false,
                    'hideOnOverlayClick': true, 'frameWidth': 750,
                    'frameHeight': 500, 'padding': 0
                }
            );

    $('.fboxMensajes').click(function () {
        $('.fboxMensajes #' + this.id).removeAttr("style");
    });

});