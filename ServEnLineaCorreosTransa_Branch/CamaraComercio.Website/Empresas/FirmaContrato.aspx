<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="FirmaContrato.aspx.cs" Inherits="CamaraComercio.Website.Empresas.Firma_Contrato" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/res/css/buttons.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #divTextoContrato
        {
            font-family: Tahoma !important;
            font-size: small !important;
            color: #888888 !important;
        }
        #divTextoContrato .header
        {
            font-weight: bold !important;
        }
        #divContrato div
        {
            margin-left: 15px !important;
            margin-bottom: 5px !important;
        }
        #divTextoContrato ul
        {
            list-style: none !important;
            margin-left: 0 !important;
            padding-left: 1em !important;
            text-indent: -1em !important;
            margin-left: 15px !important;
        }
        #divTextoContrato li
        {
            margin-bottom: 5px !important;
            color: #888888 !important;
        }
    </style>
    <script type="text/javascript">
        //Variables
        var contratoLeido = false;

        $(document).ready(function () {
            var divContrato = $("#divTextoContrato");
            var divBotones = $(".buttons");
            var chkAceptacion = $("#chkAceptacion");

            //revision de usuario padre o hijo para carga del contrato
            if ($("#hfUsuarioHijo").val() == "1")
                divContrato.load("/TerminosUso.xml?ver=2");
            else
                divContrato.load("/ContratoOfv.xml?ver=2");	
				
			var iPadDevice = navigator.userAgent.match(/iPad/i) != null;
			if (!iPadDevice)
			{
				//Deshabilitando botón de aceptar
				divBotones.hide();

				$(divContrato).scroll(function () {
					var currentPos = divContrato.scrollTop();
					var offset = divContrato[0].offsetHeight;
					var scrollHeight = divContrato[0].scrollHeight;

					if (currentPos + offset >= scrollHeight)
						contratoLeido = true;

					checkContratoFirmado();
				});

				$(chkAceptacion).click(checkContratoFirmado);
			}
			else
			{
				$("#divTextoContrato").css('height', '2000px')
			}
        });

        function checkContratoFirmado() {
            if (contratoLeido &&  $("#chkAceptacion").attr("checked"))
                $(".buttons").fadeIn();
            else
                $(".buttons").fadeOut();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="FirmaContrato">
                    <asp:Literal runat="server" ID="litTituloContrato" />
                </h1>
            </div>
            <div id="content_body">
                <asp:HiddenField runat="server" ID="hfUsuarioHijo" ClientIDMode="Static"/>
                <p>
                    Para poder hacer uso del sistema de registro mercantil en línea debe estar de acuerdo
                    con las siguientes condiciones:
                </p>
                
                <div id="divTextoContrato" style="margin-top:20px; margin-bottom:20px; 
                    overflow:auto; width:100%; height:400px; border:1px solid #999999">
                </div>

                <div id="footer_go">
                    <p>
                    <asp:CheckBox runat="server" id="chkAceptacion" ClientIDMode="Static" 
                        Text="Acepto las condiciones establecidas. "/>
                    </p>
                    <br />
                    
                    <div class="buttons">
                    <asp:HyperLink runat="server" ClientIDMode="Static" ID="lnkImpresion" target="_blank">
                        <img src="/res/img/icons/printer.png" alt="Impresión (opcional)" />
                        <span id="uploadText">Imprimir</span>
                    </asp:HyperLink>
                    <asp:LinkButton runat="server" ID="btnAceptarContrato" ClientIDMode="Static" 
                            Text="Aceptar" Height="16px" onclick="btnAceptarContrato_Click"></asp:LinkButton>

                    <div class="clear" />
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
