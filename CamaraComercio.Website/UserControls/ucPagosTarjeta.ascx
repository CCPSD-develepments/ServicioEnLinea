<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPagosTarjeta.ascx.cs" Inherits="CamaraComercio.Website.UserControls.ucPagosTarjeta" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:HiddenField ID="hfHoraOficina" ClientIDMode="Static" Value="0" runat="server" />
<asp:HiddenField ID="hfFormaEntrega" runat="server" />
<asp:HiddenField ID="hfServicio" runat="server" ClientIDMode="Static" />
<script src="/res/js/ui.pagostarjeta.js" type="text/javascript"></script>
<script type="text/javascript">

    $(function () {
        $("#MainContent_btnContinuar").click(function (e) {
            if (!$("#chkCondicionBanco").attr('checked')) {
                alert("Debe aceptar la clausula de contrato con el banco para proceder con el pago con tarjeta de crédito y suministrar los datos del Solicitante.");
                $("#PanelCondicionPago").css("color", "red");
                e.preventDefault();
            }
        });
        $("#chkCondicionBanco").click(function () {
            $("#PanelCondicionPago").css("color", "black");
        });

        $('.btnRefresh').click(function () {
            var queryString = "<%= DefaultQueryString %>";
            window.location.href = `/TarjetaCredito/PagosTarjeta.aspx${queryString}`;
        });
    });

    function ErrorRNCInvalido() {
        alert("Introduzca un RNC Valido para realizar la busqueda.");
    }
</script>

<asp:MultiView ID="MvFacturaTrans" runat="server" ActiveViewIndex="0">
    <asp:View ID="vTransaccion" runat="server">
        <h2>Detalle de Transacción</h2>
        <h5>Estás a sólo minutos de completar la transacción. Verifica los detalles de la transacción
                            y haz click en "Seleccionar". <strong>Nota Importante: Una vez confirmados estos datos,
                                no podrán ser modificados. </strong>
        </h5>
        <div>
            <fieldset class="form-fieldset">
                <asp:Panel runat="server" ID="pnlNumeroRegistro">
                    <ul>
                        <li>
                            <label for="txtNoRegistro">
                                No. Registro</label>
                            <asp:Literal runat="server" ID="txtNoRegistro" ClientIDMode="Static" />
                        </li>
                    </ul>
                </asp:Panel>
                <ul>
                    <li>
                        <label for="txtDenominacion">
                            Denominación/Razón Social</label>
                        <asp:Literal runat="server" ID="txtDenominacion" ClientIDMode="Static" />
                    </li>
                    <li>
                        <label for="txtTipoSociedad">
                            Tipo de Empresa</label>
                        <asp:Literal runat="server" ID="txtTipoSociedad" ClientIDMode="Static" />
                    </li>
                    <li>
                        <asp:Label ID="lblFecha" runat="server" AssociatedControlID="txtFecha" Text="Fecha Solicitud" />
                        <asp:Label runat="server" ID="txtFecha"></asp:Label>
                    </li>
                    <li>
                        <label>Servicios Seleccionados</label>
                        <br />
                        <br />
                        <asp:Repeater runat="server" ID="rpServiciosSeleccionados">
                            <ItemTemplate>
                                <%# Eval("DescripcionWeb")%><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </li>
                </ul>
            </fieldset>
        </div>
        <asp:Panel ID="pnlDetalles" runat="server">
            <h2>Total a Pagar
            </h2>
            <h5>Verifica los detalles de la factura incluyendo el listado de servicios y sus costos.
            </h5>
            <asp:Repeater ID="rpDetalleServicio" runat="server">
                <HeaderTemplate>
                    <table class="hor-minimalist-b" style="margin-top: -15px">
                        <thead>
                            <tr>
                                <th>Detalle
                                </th>
                                <th>Cantidad
                                </th>
                                <th style="text-align: right">Costo
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblNombreServicio" runat="server" Text='<%#Eval("Descripcion") %>' />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCantidadCertificaciones" runat="server" Text='<%# Eval("Cantidad") %>'
                                ReadOnly="true" Width="60px"></asp:Label>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtCosto" runat="server" Text='<%# String.Format("{0:n}", Eval("Costo")) %>'
                                ReadOnly="true" Width="60px"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                    <tfoot>
                                        <tr style="display: none">
                                            <td style="text-align: right; font-weight: bold" colspan="2">
                                                <div class="subtotal" style="text-align: right">
                                                    <asp:Label ID="lblCostoTotal" runat="server" AssociatedControlID="txtCostoTotalTransaccion"
                                                        Text="Total Transacción:" />
                                                </div>
                                            </td>
                                            <td style="text-align: right; font-weight: bold">
                                                <asp:Label runat="server" ID="txtCostoTotalTransaccion" Text='<%# String.Format("{0:n}", Eval("CostoTotal")) %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </tfoot>
                    </table>
                                    <div class="esConstitucion hiddenObj">
                                        <p>
                                            <asp:Literal runat="server" ID="litCopiasExoneradas">
                                            Como está constituyendo una empresa la Cámara de Comercio exonera el primer original y copia de los documentos a registrar. En caso de no hacer el envió vía web deberá depositar un juego adicional de esos documentos en la Cámara correspondiente.
                                            </asp:Literal>
                                        </p>
                                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
        <asp:Panel ID="pnlDocumentos" runat="server" Visible="false">
            <h2>Documentos Seleccionados</h2>
            <asp:Repeater ID="rpDocumentos" runat="server">
                <HeaderTemplate>
                    <table class="hor-minimalist-b" style="margin-top: -15px">
                        <thead>
                            <tr>
                                <th>Documento
                                </th>
                                <th>Originales
                                </th>
                                <th>Copias
                                </th>
                                <th style="text-align: right">Costo Originales
                                </th>
                                <th style="text-align: right">Costo Copias
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblCosto" runat="server" AssociatedControlID="txtCosto" Text='<%#Eval("Nombre") %>' />
                        </td>
                        <td>
                            <%#Eval("CantidadOriginal") %>
                        </td>
                        <td>
                            <%#Eval("CantidadCopia") %>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtCosto" runat="server" Text='<%# String.Format("{0:n}", Eval("CostoOriginalFinal")) %>'
                                ReadOnly="true" Width="60px"></asp:Label>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtCostoCopia" runat="server" Text='<%# String.Format("{0:n}", Eval("CostoOriginalFinal")) %>'
                                ReadOnly="true" Width="60px"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="4" style="text-align: right">
                                                <div class="subtotal" style="text-align: right">
                                                    <asp:Label ID="lblCostoTransaccion" runat="server" AssociatedControlID="txtCostoTransaccion"
                                                        Text="Sub-Total Documentos" />
                                                </div>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label runat="server" ID="txtCostoTransaccion"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td colspan="4" style="text-align: right; font-weight: bold">
                                                <div class="subtotal" style="text-align: right">
                                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtCostoTransaccion" Text="Total Transacción:" />
                                                </div>
                                            </td>
                                            <td style="text-align: right; font-weight: bold">
                                                <asp:Label runat="server" ID="txtCostoTotalTransaccion"></asp:Label>
                                            </td>
                                        </tr>
                                    </tfoot>
                    </table>
                                    <div class="esConstitucion hiddenObj">
                                        <p>
                                            <asp:Literal runat="server" ID="litCopiasExoneradas">
                                            Como está constituyendo una empresa la Cámara de Comercio exonera el primer original y copia de los documentos a registrar. En caso de no hacer el envió vía web deberá depositar un juego adicional de esos documentos en la Cámara correspondiente.
                                            </asp:Literal>
                                        </p>
                                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
        <div>
            <table style="float: right; font-size: 14px" id="totalDetails" width="40%">
                <tbody>
                    <tr>
                        <td style="font-weight: bold">Cr&eacute;dito: </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCredito" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Total Transacci&oacute;n</td>
                        <td style="text-align: right">
                            <asp:Label ID="lblTotalTransaccion" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Total </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                    </tr>
                </tbody>

            </table>
        </div>
        <div class="clear">
        </div>
    </asp:View>
    <asp:View ID="vFactura" runat="server">
        <h2>Factura Complementaria</h2>
        <h3>Servicios Complementarios</h3>
        <asp:Repeater ID="rpServComplementarios" runat="server">
            <HeaderTemplate>
                <fieldset class="form-fieldset">
                    <table class="hor-minimalist-b" style="margin-top: -15px; margin-bottom: -15px">
                        <thead>
                            <tr>
                                <th>Cantidad
                                </th>
                                <th>Detalle
                                </th>
                                <th>Precio Unitario
                                </th>
                                <th>
                                Total</td>
                                                    <th>Descuento
                                                    </th>
                                <th>
                                Total Bruto</td>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Cantidad")%>
                    </td>
                    <td>
                        <%#Eval("Detalle") %>
                    </td>
                    <td style="text-align: right">
                        <%#String.Format("{0:N}", Eval("PrecioUnitario"))%>
                    </td>
                    <td style="text-align: right">
                        <%#String.Format("{0:N}", Eval("Total"))%>
                    </td>
                    <td style="text-align: right">
                        <%#String.Format("{0:N}", Eval("Descuento"))%>
                    </td>
                    <td style="text-align: right">
                        <%#String.Format("{0:N}", Eval("TotalBruto"))%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
                                <br />
                <p class="subtotal">
                    <asp:Label ID="lblCostoTransaccion" runat="server" AssociatedControlID="txtCostoTransaccion"
                        Text="Sub-Total Servicios Complementarios" />
                    <asp:Label runat="server" ID="txtCostoTransaccion"></asp:Label>
                </p>
                </fieldset>
            </FooterTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
    </asp:View>
</asp:MultiView>
<asp:MultiView runat="server" ID="mvFull" ActiveViewIndex="2">
    <asp:View runat="server" ID="vTransaccionSinCosto">
        <div class="footer_go">
            <asp:Button Text="Continuar" runat="server" CssClass="btn" ID="btnContinuarSinCosto"
                OnClick="btnContinuarSinCosto_Click" />
            <button type="button" class="btn btnRefresh">Volver atrás</button>
            <div class="clear" />
        </div>
    </asp:View>
    <asp:View runat="server" ID="vGeneracionTicket">
        <div>
            <h2>Detalles de Factura</h2>
            <fieldset class="form-fieldset">
                <asp:Panel runat="server" ID="pnlExpress" ClientIDMode="Static" Visible="False">
                    <h3>Transacción "Express"</h3>
                    <ul>
                        <li>
                            <asp:CheckBox runat="server" ID="chkExpress" ClientIDMode="Static" />
                            <label for="chkExpress" class="wideInput" style="width: 250px;">
                                Realizar transacción "express".</label>
                        </li>
                        <li>
                            <div class="sectDetail">
                                Las solicitudes normales tienen una duración de 5 dias. Las solicitudes de servicios
                                                "express" tienen una duración de sólo 24 horas laborables. <strong>Nota Importante:
                                                    si escoge esta opción la transacción tendría un costo de
                                                    <asp:Literal runat="server" ID="litCostoServicio" Text="" /></strong>
                            </div>
                        </li>
                    </ul>
                </asp:Panel>
            </fieldset>
            <div class="clear">
            </div>
            <h3>Tipos de Factura</h3>
            <fieldset id="informacionFactura" class="fieldFormulary">
                <ul>
                    <li>
                        <label for="ddlTipoComprobantes">
                            <asp:DropDownList ID="ddlTipoComprobantes" runat="server" ClientIDMode="Static" CssClass="commentCtrlHov"
                                Style="width: 280px" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoComprobantes_SelectedIndexChanged">
                            </asp:DropDownList>
                        </label>
                        <div class="comments" id="ddlTipoComprobantesComment">
                            Selecciona el tipo de factura. Nota <strong>Importante: Una vez emitida no podrá ser
                                                cambiada.</strong>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <ul>
                            <li>
                                <asp:Label ID="lblRnc" runat="server" AssociatedControlID="txtRnc" Width="135px">
                                    RNC o Cédula</asp:Label>
                                <asp:TextBox ID="txtRnc" runat="server" CssClass="tb" ClientIDMode="Static" MaxLength="11" ValidationGroup="Contribuyente" OnTextChanged="txtRnc_TextChanged" Width="175px" />
                                &nbsp;<asp:RequiredFieldValidator ClientIDMode="Static" ID="reqRnc" runat="server"
                                    ErrorMessage="*" CssClass="validator" ControlToValidate="txtRnc">
                                </asp:RequiredFieldValidator>
                                <asp:Button ID="btnBuscarRNC" runat="server" CssClass="btnSmall" Height="31px" OnClick="btnBuscarRNC_Click" Text="Validar" ValidationGroup="Contribuyente" Visible="False" Width="119px" />
                            </li>
                            <li>
                                <asp:Label ID="lblNombreEmpresa" runat="server" AssociatedControlID="txtNombre" Width="134px">
                                    Nombre Solicitante</asp:Label>
                                <asp:TextBox ID="txtNombre" runat="server" ClientIDMode="Static" CssClass="tb" Width="303px"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ClientIDMode="Static" ID="reqNombre" runat="server"
                                    ErrorMessage="*" CssClass="validator" ControlToValidate="txtNombre">
                                </asp:RequiredFieldValidator>
                            </li>
                            <li></li>
                        </ul>
                        <asp:Panel runat="server" ID="PanelCondicionPago" ClientIDMode="Static">
                            <input type="checkbox" id="chkCondicionBanco" />ACEPTO PAGAR ESTE MONTO SUJETO A LOS TERMINOS DEL CONTRATO CELEBRADO CON EL EMISOR DE LA TARJETA.
                        </asp:Panel>
                    </li>
                    <li>
                        <div class="footer_go">
                            <asp:Button ID="btnContinuar" runat="server" CssClass="btn" OnClick="btnContinuar_Click"
                                Text="Continuar" />
                            <button type="button" class="btn btnRefresh">Volver atrás</button>
                            <div class="clear" />
                        </div>
                    </li>
                </ul>
            </fieldset>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </asp:View>
    <asp:View runat="server" ID="vPagoFisico">
        <div id="divFormaEntrega">
            <h2>Realiza tu Pago</h2>
            <h5>Selecciona tu forma de pago. Si verificaste la información y confirmaste que es
                                correcta haz click en "Seleccionar". <strong>Nota Importante: Una vez confirmados estos
                                    datos, no podrán ser modificados. </strong>
            </h5>
            <fieldset class="fieldFormulary">
                <div>
                    <asp:RadioButtonList ID="rbFormaPago" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="Pagar con Tarjeta de Crédito." Value="1" Enabled="False" />
                    </asp:RadioButtonList>
                </div>
                <ul>
                    <li>
                        <div class="sectDetail" style="text-align: center">
                            <strong style="font-size: 15px;">Cámara de 
                                                    <asp:Literal ID="ltrNombreCamara" runat="server"></asp:Literal></strong>
                            <br />
                            <asp:Literal ID="ltrDireccionCamara" runat="server"></asp:Literal>
                        </div>
                    </li>
                    <li>
                        <div class="footer_go">
                            <asp:Button ID="btnFormaPago" runat="server" Text="Continuar" CssClass="btn" OnClick="btnFormaPago_Click" />
                            <asp:Button ID="Button1" runat="server" OnClick="btnBack_Click" Text="Volver atrás" CssClass="btn" />
                            <div class="clear" />
                        </div>
                    </li>
                </ul>
            </fieldset>
        </div>
    </asp:View>
</asp:MultiView>
