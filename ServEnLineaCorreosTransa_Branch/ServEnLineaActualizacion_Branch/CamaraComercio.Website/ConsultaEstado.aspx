<%@ Page Title="" Language="C#" MasterPageFile="~/res/Consulta_header.Master" AutoEventWireup="true"
    CodeBehind="ConsultaEstado.aspx.cs" Inherits="CamaraComercio.Website.ConsultaEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Consulta del estado de transacciones</title>
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.tb').numeric();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1 id="creacion">
                        <div class="color">
                        Consulta de Transacciones
                            </div>
                    </h1>
                </div>
                <div id="content_body">
                    <h4>
                        Ingresa los datos solicitados para consultar el estado actual de tu transacción.
                    </h4>
                    <ul>
                        <li>
                            <label for="txtTransaccionId">
                                Número de la transacción *
                            </label>
                            <asp:TextBox runat="server" ID="txtTransaccionId" CssClass="tb commentCtrl" ClientIDMode="Static" />
                            <div class="comments" id="txtTransaccionIdComment">
                                ID de la transacción que se desea consultar. Este número se encuentra definido en
                                el documento de solicitud que se entrega al momento de iniciar la transacción.
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="txtTransaccionIdReq" ClientIDMode="Static"
                                Display="None" ControlToValidate="txtTransaccionId" ErrorMessage="El número de la transaccion es requerido"
                                CssClass="validator summary" />
                        </li>
                        <br />
                        <li>
                            <label for="ddlCamara">
                                Cámara de Comercio
                            </label>
                            <asp:DropDownList runat="server" ID="ddlCamara" CssClass="dd commentCtrlHov" ClientIDMode="Static" Enabled="false" />
                            <div class="comments" id="ddlCamaraComment">
                                Cámara de comercio donde se inicio la transacción que desea consultar.
                            </div>
                        </li>
                        <br />
                        <li>
                            <label for="chkInternet">
                            </label>
                            <asp:CheckBox runat="server" ID="chkInternet" ClientIDMode="Static" Text="Inicié mi transacción por Internet"
                                CssClass="commentCtrl" />
                            <div class="comments" id="chkInternetComment">
                                Seleccione esta opción solo si inició su transacción desde el portal web.
                            </div>
                        </li>
                        <br />
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btnFormNext"
                                    ClientIDMode="Static" OnClick="btnConsultar_Click" />
                                <div style="clear: both;">
                                </div>
                            </div>
                        </li>
                    </ul>
                    <asp:MultiView runat="server" ID="mvConsulta">
                        <asp:View runat="server" ID="vResultados">
                            <ul>
                                <li>
                                    <label>
                                        Razon Social:</label>
                                    <asp:Literal runat="server" ID="litRazonSocial" />
                                </li>
                                <li>
                                    <label>
                                        Fecha de Recepción</label>
                                    <asp:Literal runat="server" ID="litFechaRecepcion" />
                                </li>
                                <li>
                                    <label>
                                        Estado actual</label>
                                    <span style="font-weight: bold; color: Maroon">
                                        <asp:Literal runat="server" ID="litEstadoActual" />
                                    </span></li>
                            </ul>
                            <telerik:RadGrid ID="rgSeguimiento" runat="server" AutoGenerateColumns="False" EnableEmbeddedSkins="False"
                                GridLines="None" Skin="NoboxGrid">
                                <MasterTableView>
                                    <NoRecordsTemplate>
                                        No existen movimientos registrados para esta transacción.
                                    </NoRecordsTemplate>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="FechaModificacion" HeaderText="Fecha" UniqueName="FechaModificacion" />
                                        <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado" />
                                        <telerik:GridBoundColumn DataField="Comentarios" HeaderText="Comentario" UniqueName="Comentario" />
                                    </Columns>
                                </MasterTableView>
                                <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                            </telerik:RadGrid>
                            <h5>
                                <asp:Literal runat="server" ID="litComentariosAdicionales" />
                            </h5>
                        </asp:View>
                        <asp:View runat="server" ID="vError">
                            <h4>
                                <asp:Literal runat="server" ID="litErrores" />
                            </h4>
                        </asp:View>
                    </asp:MultiView>
                    <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                        CssClass="summary errorbox" Display="static" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
