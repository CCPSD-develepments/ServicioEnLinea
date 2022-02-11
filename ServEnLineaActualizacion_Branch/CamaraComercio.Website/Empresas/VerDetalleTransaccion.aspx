<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="VerDetalleTransaccion.aspx.cs" Inherits="CamaraComercio.Website.Empresas.VerDetalleTransaccion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Fancybox -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <!-- Inline user script -->
    <script type="text/javascript">
        $(document).ready(function () {

            //Navegación
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");

            $('#subnavigation li').removeClass("active");
            $('#liOficina').addClass("active");

            //Fancybox
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


            $("#lnkFacturaPendiente").click(function (e) {

                if ($("#hfDocumentosRequeridosSeleccionados").val() == "1") {
                    e.preventDefault();
                    showDialog();
                }

            });

            function showDialog() {

                $("#dialog:ui-dialog").dialog("destroy");
                $("#dialog-confirm").attr("title", "Selección Documentos Requeridos");
                var texto = "Actualmente no ha seleccionado todos los documentos requeridos de esta transacción, antes de proceder debe seleccionar documentos. ";
                $("#dialog-content").text(texto);
                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: 350,
                    width: 460,
                    modal: true,
                    buttons: {
                        "Agregar Documentos": function () {
                            $(this).dialog("close");
                            top.window.location.href = $('#lnkRevisionDocumentos').get(0).href;
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }

                    }
                });

            }

        });

    </script>
    </asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <asp:ObjectDataSource ID="odsHistoricosTransacciones" runat="server" SelectMethod="GetTransaccionHistoria"
        TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionesController"
        EnablePaging="true" SelectCountMethod="GetCountTransaccionesHistoria">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="nSolicitud" Name="transaccionId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="TransaccionesDocumentosId" Type="Int32" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="FechaEnvio" Type="DateTime" />
            <asp:Parameter Name="nombre" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="odDocuentosEnviados" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="DocumentosEnviados" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionDocumentosController"
        UpdateMethod="UpdateDocumentosEnviados" DeleteMethod="DeleteDocumentosEnviados">
        <DeleteParameters>
            <asp:Parameter Name="TransaccionesDocumentosId" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="_transaccionID" QueryStringField="nSolicitud" Type="Int32" />
            <asp:Parameter Name="pagInicio" Type="Int32" />
            <asp:Parameter Name="pagTamano" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="TransaccionesDocumentosId" Type="Int32" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="FechaEnvio" Type="DateTime" />
            <asp:Parameter Name="nombre" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMsg" runat="server" SelectMethod="FetchByTransaccion"
        TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.MensajesController" SelectCountMethod="CountByTransaccion"
        EnablePaging="True">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="nSolicitud" Name="transaccion" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DataSourceHistoricoTrans" runat="server" SelectMethod="HistoricoLlenado"
        TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionesController" SelectCountMethod="countHistoricoLLenado"
        EnablePaging="True">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="nSolicitud" Name="transaccion" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="transac">
                    <span class="right normal">
                        <span class="right normal">Número de Solicitud
                        <strong>
                            <asp:Label runat="server" ID="litNumSolicitud" ForeColor="SteelBlue"> </asp:Label>
                        </strong></span>
                        <!--<asp:Label runat="server" ID="lblTitRazonSocial" />
                        /
                        <asp:Label runat="server" ID="lblTitTipoEmpresa" />-->
                    </span>Estado de Solicitud</h1>
            </div>
            <div id="content_body">
                <div id="acciones" class="submenu floatRight">
                    <fieldset class="form-fieldset" style="margin-right: 40px">
                        <ul style="float: right; padding-right: 30px;">
                            <%--<li>
                                <asp:HyperLink ID="hlVerSolicitud" runat="server" CssClass="btn" Text="Ver Solicitud"
                                    Target="_blank" ClientIDMode="Static" Width="236px" />
                            </li>--%>
                            <li>
                                <asp:HyperLink runat="server" ID="hlVerFactura" Target="_blank" Text="Ver Factura"
                                    CssClass="btn" NavigateUrl="~/Empresas/ImprimirFactura.aspx" Width="198px" />
                            </li>
                            <li style="display: none;">
                                <asp:HyperLink runat="server" ID="hlEnvioDatos" Target="_blank" Text="Confirmación Digital"
                                    CssClass="btn" NavigateUrl="~/Empresas/ImprimirFactura.aspx" Width="198px" Visible="False" />
                            </li>
                            <li>
                                <a id="btnDownloadFormularioSolicitud" runat="server" class="btn" onserverclick="btnDownloadFormularioSolicitud_Click">Descargar Formulario Solicitud</a>
                            </li>
                        </ul>
                    </fieldset>
                </div>
                <div id="infoEmpresa">
                    <span class="validator">
                        <asp:HyperLink ID="lnkRevisionDocumentos" runat="server" Text="Revisión Documentos"
                            NavigateUrl="#" ClientIDMode="Static" Target="_blank" Style="color: Red; display: none; visibility: hidden;" />
                    </span>
                    <asp:HiddenField ID="hfDocumentosRequeridosSeleccionados" runat="server" Value="0"
                        ClientIDMode="Static" />
                    
                    <asp:Panel runat="server" ID="pnlEnvioDocs" Visible="false" CssClass="sectDetailBlue">
                        <h1 style="margin-right: 140px;">Esta solicitud no ha sido completada.</h1>
                        <p style="margin-right: 140px;">
                            La solicitud puede ser completada accesando a este link: 
                            <strong>
                                <asp:HyperLink runat="server" Text="Completar" ID="hlEnvioDocumentosTit" Font-Size="Small" Visible="true">
                                   
                              </asp:HyperLink>

                                <%-- <asp:HyperLink runat="server" Text="Completar Transaccion" ID="HyperLink1" Font-Size="Small" Visible="true">
                                     </asp:HyperLink>--%>

                                 <asp:Button runat="server" Text="Completar Transacción" ID="btnCompletarTransaccion"
                                    CssClass="botoncilloBD right" OnClick="btnCompletarTransaccion_Click" Visible="true">

                                </asp:Button>

                            </strong>

                            




                        </p>
                    </asp:Panel>


                    <asp:Panel runat="server" ID="pnlBhdEmpresa" Visible="false" CssClass="sectDetailBlue">
                        <h1 style="margin-right: 140px;">El pago esta pendiente de aprobacion.</h1>
                        <p style="margin-right: 140px;">
                           El pago esta pendiente de aprobacion por del Banco                                                     

                                 <asp:Button runat="server" Text="Comprobar Pago" ID="btnComprobarPagoBanco"
                                    CssClass="botoncilloBD right" OnClick="btnComprobarPagoBanco_Click" Visible="False">

                                </asp:Button>

                                                  

                        </p>
                    </asp:Panel>


                    <asp:Panel runat="server" ID="pnlEnProblema" Visible="false"  CssClass="sectDetail" HorizontalAlign="Center">
                        <center>
                            <div style="width:100%">
                                <h1 style="text-align:none;" align="right">Solicitud en revisión por problemas.</h1>
                            </div>
                            <div>
                                <asp:Panel runat="server" ID="pnlNotaProblema" Visible="false"  CssClass="sectDetail" HorizontalAlign="Center">
                                    <center>
                                        <strong style="font-size: 15px;">
                                            <asp:Label ID="lblMensajeNota" runat="server" style="color:#bb2a05" Visible="False" CssClass="sectDetail" BorderStyle="None"></asp:Label>
                                        </strong>
                                    </center>
                                </asp:Panel>
                            <p style="color:black">
                                Esta solicitud fue devuelta por problema. Si quiere solucionarlos presione
                                <strong>
                                    <asp:HyperLink runat="server" Text="Continuar" ID="hlEnProblemaContinuar" Font-Size="Small"></asp:HyperLink>
                                </strong>
                            </p>
                            </div>
                        </center>
                    </asp:Panel>
                    <h2>Datos Generales</h2>
                    <fieldset class="form-fieldset" style="width:60%;">
                        <ul>
                            <li>
                                <label>
                                    Cámara</label>
                                <asp:Label ID="lblCamara" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <label for="lblEmpresa">
                                    Denominación/Razón Social</label>
                                <asp:Label ID="lblEmpresa" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="lblTipoEmpresa" ID="titlelblTipoEmpresa"
                                    Visible="False">Tipo Societario</asp:Label>
                                <asp:Label ID="lblTipoEmpresa" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="lblNoRegistro" ID="titlelblNoRegistro"
                                    Visible="False">No. Registro</asp:Label>
                                <asp:Label ID="lblNoRegistro" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <label for="lblFechaRecepcion">
                                    Fecha de Solicitud</label>
                                <asp:Label ID="lblFechaRecepcion" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <label for="lblTransaccion">
                                    No. Transacción</label>
                                <asp:Label ID="lblTransaccion" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <label for="lblEstado">
                                    Status</label>
                                <asp:Label ID="lblEstado" runat="server" ClientIDMode="Static"></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblFacturaPagada" runat="server" ClientIDMode="Static"
                                    CssClass="validator" Visible="False"> (la factura aún no ha sido pagada) </asp:Label>
                            </li>
                        </ul>
                    </fieldset>
                    <div class="fieldsetContainer">
                        <asp:Panel ID="pnlDocumetosEnviados" runat="server">
                            <h3>
                                <%--<asp:HyperLink runat="server" Text="Envio Documentos" ID="hlEnvioDocumentos" CssClass="botoncillo right">
                                </asp:HyperLink>--%>
                                <asp:Button runat="server" Text="Procesar Transaccion" ID="btnEnvioDocumentos"
                                    CssClass="botoncillo right" OnClick="btnEnvioDocumentos_Click" Visible="false">

                                </asp:Button>
                                Documentos Enviados
                            </h3>
                            <telerik:RadGrid ID="rgridDocumentosEnviados" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" DataSourceID="odDocuentosEnviados" GridLines="None">
                                <MasterTableView DataSourceID="odDocuentosEnviados" NoDetailRecordsText="" NoMasterRecordsText="No se ha enviado ningún documento para esta transacción">
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="TipoDocumento.Nombre" HeaderText="Tipo de Documento"
                                            UniqueName="TipoDocumento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Nombre" HeaderText="Descripción" UniqueName="Descripcion">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                            <div style="text-align: right; margin-top: 4px">
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlDocumentoDescargar" runat="server" Visible="false">
                            <h3>Certificación</h3>
                            <div style="text-align: right; margin-top: 4px">
                                <asp:HyperLink runat="server" Text="Descarga Documento" ID="hlDescargaDocumentos"></asp:HyperLink>
                            </div>
                        </asp:Panel>
                    </div>
                    <br />
                    <div ID="seccionProblema" class="fieldsetContainer sectDetail" runat="server">
                        <h3>Detalle de transacción devuelta por problema</h3>
                        <telerik:RadGrid ID="rgridMensajes" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataSourceID="odsMsg" GridLines="None" BackColor="#FFFFCC">
                            <MasterTableView DataSourceID="odsMsg" NoMasterRecordsText="No se han generado mensajes para esta transacción">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ComentariosProblema" HeaderText="Comentarios" UniqueName="Titulo">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                    <div class="fieldsetCotainer">
                        <h3>Ficha
                            Histórica de Actividades</h3>
                        <telerik:RadGrid ID="rgridHistorico" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowPaging="True" AllowSorting="True" DataSourceID="" OnItemDataBound="rgridHistorico_ItemDataBound" OnNeedDataSource="rgridHistorico_NeedDataSource">
                            <MasterTableView DataSourceID="" NoMasterRecordsText="No se ha generado ninguna operación para esta transacción">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Fecha" UniqueName="FechaSolicitud" DataField="Fecha"
                                        DataFormatString="{0:dd/MM/yyyy h:mm:ss tt}">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn HeaderText="Sociedad" UniqueName="Sociedad" DataField="NombreSocialPersona">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridTemplateColumn HeaderText="Solicitud" UniqueName="Solicitud" DataField="ServicioId">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="ServicioGrid" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Estado" UniqueName="Estado" DataField="estado">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEstadoGrid" Text=""></asp:Label>

                                            <%--<asp:Image ID="EstadoImg" runat="server" ImageUrl='<%# Eval("EstatusTransId") != null ? new StatusIconHelper().GetStatusIcon(Convert.ToInt32(Eval("EstatusTransId"))) : "/res/img/icons/bullet_white.png" %>'
                                    ToolTip='<%# Eval("EstatusTransacciones.EstatusTransDescripcion") %>' />
                                            <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("EstatusTransacciones.EstatusTransDescripcion") %>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                        </telerik:RadGrid>
                    </div>
                </div>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
