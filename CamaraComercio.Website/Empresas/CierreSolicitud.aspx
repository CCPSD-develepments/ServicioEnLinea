<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="CierreSolicitud.aspx.cs" Inherits="CamaraComercio.Website.Empresas.CierreSolicitud" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ErrorAperturaCaso() {
            alert("Error aperturando caso en Sharebase.");
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            padding: 30px;
            border-bottom: 1px solid #e5e5e5;
            background-color: #f6f6f6;
            min-height: 75.4px;
            vertical-align: bottom;
            /*height: 83px;*/
        }
        .auto-style2 {
            padding: 30px;
            border-bottom: 1px solid #e5e5e5;
            background-color: #f6f6f6;
            min-height: 75.4px;
            vertical-align: bottom;
            height: 81px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <asp:Panel runat="server" ID="pnlCompletada" Visible="False">
                    <h1 id="transac">
                        <strong>
                            <asp:Label runat="server" ForeColor="SteelBlue" ID="lblNumSolicitud" /></strong>
                        <%--Transaccion Completada--%>Su transacción ha sido completada exitosamente.
                    </h1>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlNoCompletada" Visible="False">
                    <h1 id="H1">
                        <strong>
                            <asp:Label runat="server" ForeColor="SteelBlue" ID="Label1" /></strong>
                        <%--Transaccion Completada--%>Esta solicitud no ha sido completada.
                    </h1>
                </asp:Panel>

            </div>
            <div id="content_body">
                <div>
                    <h5>
                        <strong>
                            NOTA: En caso de haber seleccionado entrega física y posterior a recibir 
                            la notificación que su transacción fue completada, deberá presentarse a las 
                            instalaciones de la Cámara de Comercio y Producción de Santo Domingo ubicadas
                            en la Av. 27 de febrero esquina Tiradentes No. 228, Torre Friusa, Sector La Esperilla.
                        </strong>
                    </h5>
                    <br />
                    <p>
                        <strong>
                        Para imprimir la documentación correspondiente a esta transacción puede seleccionar
                        de las opciones listadas a continuación:
                        </strong>
                    </p>
                </div>
                <div id="wrapperContent" style="text-align: center">
<%--                    <div class="infoBox" id="divSolicitud">
                        <div class="infoContent">
                            <asp:HyperLink ID="hlVerSolicitud" runat="server" CssClass="btn" Text="Ver Solicitud"
                                Target="_blank" ClientIDMode="Static" Style="float: none;" /><br />
                            <!--<p>
                                Seleccione esta opcion si desea visualizar los datos de la solicitud, así como el
                                inventario de documentos.
                            </p>-->
                        </div>
                    </div>--%>
                    <asp:Panel runat="server" ID="panelFactura">
                        <div class="infoBox" id="divFactura">
                            <div class="auto-style1">
                                <asp:HyperLink runat="server" ID="hlVerFactura" Target="_blank" Text="Ver Factura"
                                    CssClass="btn" NavigateUrl="~/Empresas/ImprimirFactura.aspx" Style="float: none;" /><br />
                                <!-- <p>
                                Seleccione esta opción si desea visualizar su factura
                            </p>-->
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="panelConfirmacion" Visible="False">
                        <div class="infoBox" id="divEnvioDocs">
                            <div class="infoContent">
                                <asp:HyperLink runat="server" ID="hlEnvioDatos" Target="_blank" Text="Confirmación Digital"
                                    CssClass="btn" NavigateUrl="~/Empresas/ImprimirFactura.aspx" Style="float: none;" /><br />
                                <p>
                                    Debe enviar los documentos de esta transaccion para ser procesada en línea.
                                </p>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="panelDetalle">
                        <div class="infoBox" id="div1">
                            <div class="infoContent">
                                <asp:HyperLink runat="server" ID="hlDetalleTransaccion" Target="_blank" Text="Ver Detalle Transaccion"
                                    CssClass="btn" NavigateUrl="~/Empresas/VerDetalleTransaccion.aspx" Style="float: none;" /><br />
                                <%--<p>
                                   Puede enviar los documentos de esta transaccion para ser procesada en línea.
                                </p>--%>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="panelDescargaDocumentos">
                        <div class="infoBox" id="divDescargaDocumentos">
                            <div class="auto-style1">
                                <a id="btnDownloadFormularioSolicitud" runat="server" class="btn" style="float: none" onserverclick="btnDownloadFormularioSolicitud_Click">Descargar Formulario Solicitud</a>
                                <%--<p></p>--%>
                            </div>
                        </div>
                    </asp:Panel>
                    <p>
                    </p>
                    <div class="clear" />
                </div>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
