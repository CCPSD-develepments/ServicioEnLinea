<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="FormaEntrega.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Shared.FormaEntrega" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/res/js/ui.formaentrega.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="creacion">
                    <span class="right normal" style="visibility: hidden">Número de Solicitud <strong>
                        <asp:Label runat="server" ID="lblNoRecibo" Text="SIC-00982" ForeColor="SteelBlue" /></strong></span>
                    Transacciones de la Cámara</h1>
            </div>
            <div id="content_body">
                <div class="stepsTl" id="stepsTl">
                    <ul>
                        <li><a href="#" class="stepNobox">Solicitud</a></li>
                        <li><a href="#" class="stepNobox">Datos Generales</a></li>
                        <li><a href="#" class="stepNobox">Datos de la Empresa</a></li>
                        <li><a href="#" class="stepDone">Verificación</a></li>
                        <li><a href="#" class="stepLast">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <h2>
                Formas de Entrega de Documento
                    <%--Solicitud Procesada--%></h2>
                <asp:MultiView runat="server" ID="mv1" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vConfirmacion">
                        <asp:Panel runat="server" ID="pnlSolicitudInclusion" Visible="false">
                            <p>
                            <strong>Importante:</strong> Debe descargar la plantilla del <a href="/res/pdf/Poder Autorizacion Form.pdf"
                                target="_blank">poder de representación de la sociedad para el Registro Mercantil en Línea </a>
                                </p>
                        </asp:Panel>
                        <p>
                            Hemos recibido tu solicitud de servicio&nbsp; Para completarla debes de enviar los 
                            documentos requeridos a la Cámara de
                            <asp:Literal ID="ltrNombreCamara" runat="server"></asp:Literal>
                            (Envio en linea con firma digital) o depositar los documentos de forma física en 
                            la dirección indicada más abajo. Selecciona la alternativa que deseas utilizar:
                        </p>
                        <h3>
                            ¿Como Desea Entregar Los Documentos?</h3>
                        <div id="divFormasEntregaWrapper" style="text-align: center">
                            <div class="infoBox">
                                <div class="infoContent">
                                    <asp:HyperLink runat="server" ID="hlFisica" CssClass="btn" Text="Entrega Física de Documentos"
                                        Style="float: none;"></asp:HyperLink>
                                    <p>
                                        Debes de depositar 1 juego adicional de todos los documentos.<br />
                                        <asp:Literal ID="ltrDireccionCamara" runat="server"></asp:Literal>
                                    </p>
                                </div>
                            </div>
                            <div class="infoBox">
                                <div class="infoContent">
                                    <asp:HyperLink runat="server" ID="hlEnvioDatos" CssClass="btn" Style="float: none;"
                                        Text="Envío en Línea con Firma Digital" NavigateUrl="#" 
                                        ClientIDMode="Static" Enabled="True"></asp:HyperLink>
                                    <p>
                                        Para realizar tu transacción en línea, necesitas poseer una firma digital. Si deseas
                                        adquirir una, puedes visitar el portal de <a href="https://www.camarasantodomingo.do/apps/digifirma_solicitud_personal.php"
                                            title="DigiFirma">DigiFirma.</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="clear" />
                        <br />
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
