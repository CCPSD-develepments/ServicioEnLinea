
function detectKindOfError() {

    var strReferrer = document.referrer.toLowerCase();

    if (location.href.indexOf("noreferrer=true") >= 0) strReferrer = "";

    if (strReferrer.length == 0) {

        $(document).ready(function () {
            $("#message").html("Disculpa la direccion que ha solicitado. No Existe.");
        });


    }

    var blnSearchReferral = false;

    var blnInsiteReferral = false;

    var strSite = "";

    if (strReferrer.length != 0)

    //we have been referred to this page some another web page ...
    {

        if (

		(strReferrer.indexOf(".looksmart.co") > 0) ||

		(strReferrer.indexOf(".ifind.freeserve") > 0) ||

		(strReferrer.indexOf(".ask.co") > 0) ||

		(strReferrer.indexOf("google.co") > 0) ||

		(strReferrer.indexOf("altavista.co") > 0) ||

		(strReferrer.indexOf("msn.co") > 0) ||

		(strReferrer.indexOf("yahoo.co") > 0) ||

		(strReferrer.indexOf("bing.co") > 0)

		) {

            //we have been referred to from a known search engine



            blnSearchReferral = true;

            var arrSite = strReferrer.split("/");

            var arrParams = strReferrer.split("?");

            var strSearchTerms = arrParams[1];

            arrParams = strSearchTerms.split("&");



            strSite = arrSite[2];

            var sQryStr = "";



            //define what search terms are in use

            var arrQueryStrings = new Array();

            arrQueryStrings[0] = "q="; //google, altavista, msn

            arrQueryStrings[1] = "p="; //yahoo

            arrQueryStrings[2] = "ask="; //ask jeeves

            arrQueryStrings[3] = "key="; //looksmart



            for (i = 0; i < arrParams.length; i++)

            //loop through all the parameters in the referring page's URL
            {

                for (q = 0; q < arrQueryStrings.length; q++) {

                    sQryStr = arrQueryStrings[q];

                    if (arrParams[i].indexOf(sQryStr) == 0) {//we've found a search term!

                        strSearchTerms = arrParams[i];

                        strSearchTerms = strSearchTerms.split(sQryStr);

                        strSearchTerms = strSearchTerms[1];

                        strSearchTerms = strSearchTerms.replace("+", " ");

                    }

                }

            }


            $(document).ready(function () {

                $("#message").html("La pagina solicitada ya no existe.");

                $("#listaOpciones li:last").append("<li><a id='backurl' href=" + strReferrer + "> Regresar a la pagina anterior.<\/a> <\/li>");
            });


        } //end of section dealing with referral from known search engine



        if (!blnSearchReferral) {

            // for referrals from other sites with broken links

            // ------------------------------------------------

            strSite = strReferrer;

            strSite = strSite.split("/");

            strSite = strSite[2];

            $(document).ready(function () {

                $("#message").html("La pagina solicitada ya no existe.");

                $("#listaOpciones li:last").append("<li><a id='backurl' href=" + strReferrer + "> Regresar a la pagina anterior.<\/a> <\/li>");
            });

        }

        if (!blnSearchReferral) {

            //blnInsiteReferral = ((strReferrer.indexOf("") >= 0))

        }

    }

}