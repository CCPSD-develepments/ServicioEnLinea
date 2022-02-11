<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="TransformacionTipo.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Transformaciones.TransformacionTipo" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/res/js/ui.adecuacion.js"></script>    
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            //Se esconde el panel de actualización de recibo de DGII
            $("#pnlInformacionDGII").hide();

            $(".nuevoCapital").change(function () {
                var nuevoCapital = parseFloat($(".nuevoCapital").val());
                var capital = parseFloat($("#ltCapAutorizado").text().replace(",", ""));

                if (nuevoCapital > capital) {
                    $("#pnlInformacionDGII").fadeIn();
                    disableAspNEtValidator("reqNumeroRecibo", true);
                    disableAspNEtValidator("reqMonto", true);
                    disableAspNEtValidator("reqFecha", true);
                }
                else {
                    $("#pnlInformacionDGII").fadeOut("fast");
                    disableAspNEtValidator("reqNumeroRecibo", false);
                    disableAspNEtValidator("reqMonto", false);
                    disableAspNEtValidator("reqFecha", false);
                }
            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="empresa">
                    <span class="right normal">
                        <asp:Literal ID="ltTipoSociedadTit" runat="server"></asp:Literal></span>
                    Tranformación de Registro</h1>
            </div>
            <div id="content_body">
             <h5>Introduce la información correspondiente en cada campo y haz click sobre "Someter". Si tienes alguna duda con un término visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">Glosario de Términos</a>. <strong>Los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                <fieldset class="form-fieldset">
                    <ul>
                        <li> <label>Denominación/Razón Social </label>
                            <asp:Literal ID="ltNombreSocial" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <label>Tipo de Sociedad</label>
                            <asp:Literal ID="ltTipoSociedad" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <label for="ddlTipoSociedadNueva">
                                Nuevo Tipo de Sociedad
                            </label>
                            <asp:DropDownList ID="ddlTipoSociedadNueva" ClientIDMode="Static" runat="server"
                                Width="350px" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoSociedadNueva_SelectedIndexChanged">
                            </asp:DropDownList>
                        </li>
                        <li>
                            <label>
                                Capital Social Autorizado</label>
                            <asp:Label ID="ltCapAutorizado" runat="server" ClientIDMode="Static"></asp:Label></li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtCapitalSocialNuevo" ID="lbltxtCapitalSocialNuevo">Nuevo Capital Social Autorizado</asp:Label>
                            <telerik:RadNumericTextBox ID="txtCapitalSocialNuevo" runat="server" CssClass="tb nuevoCapital"
                                Culture="Spanish (Dominican Republic)" EmptyMessage="Nuevo Capital" Type="Currency"
                                Width="200px" Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false">
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtCapitalSocialNuevo" CssClass="validator summary" ValidationGroup="3" Display="Static">El campo de capital social autorizado es requerido.</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvCapitalSocialNuevo" runat="server" CssClass="validator summary" ValidationGroup="3" Display="Static"
                                Type="Currency" MaximumValue="9999999999.99" ControlToValidate="txtCapitalSocialNuevo">
                            El capital social mínimo requerido para este tipo de sociedad es <%=String.Format("{0}", rvCapitalSocialNuevo.MinimumValue) %>
                            </asp:RangeValidator>
                        </li>
                        <li>
                            <asp:Panel ID="pnlInformacionDGII" runat="server" ClientIDMode="Static">
                                <ul>
                                    <li>
                                        <label for="txtNoRecibo">
                                            No. Recibo DGII</label>
                                        <telerik:RadTextBox ID="txtNoRecibo" runat="server" CssClass="tb" Width="100px" MaxLength="15"
                                            EmptyMessage="Número de Recibo" />
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqNumeroRecibo" runat="server"
                                            ControlToValidate="txtNoRecibo" CssClass="validator summary" ValidationGroup="3" Display="Static">El campo de número de recibo de DGII es requerido.</asp:RequiredFieldValidator>
                                    </li>
                                    <li>
                                        <label for="MainContent_radFechaRecibo">
                                            Fecha Recibo DGII</label>
                                        <telerik:RadDatePicker ID="radFechaRecibo" runat="server" Culture="Spanish (Dominican Republic)"
                                            EnableEmbeddedSkins="False" Skin="Ccpsd" EnableEmbeddedScripts="true" ShowPopupOnFocus="true">
                                            <DateInput ID="DateInput1" EnableEmbeddedSkins="False" runat="server" ShowButton="true"
                                                EmptyMessage="Fecha de Pago en DGII">
                                            </DateInput>
                                            <Calendar ID="Calendar1" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                ViewSelectorText="x" runat="server" EnableEmbeddedSkins="False" Skin="Ccpsd">
                                                <FastNavigationSettings CancelButtonCaption="Cancelar" DateIsOutOfRangeMessage="La fecha esta fuera del rango permitido."
                                                    TodayButtonCaption="Hoy" />
                                            </Calendar>
                                            <DatePopupButton ImageUrl="/res/img/calendar.png" HoverImageUrl="/res/img/calendar.png"
                                                runat="server" CssClass="noBorder" />
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqFecha" runat="server" ControlToValidate="radFechaRecibo"
                                            CssClass="validator summary" ValidationGroup="3" Display="Static">El campo de fecha de recibo deDGII es requerido.</asp:RequiredFieldValidator>
                                    </li>
                                    <li>
                                        <label for="txtMontoDGII">
                                            Monto Pagado DGII</label>
                                        <telerik:RadNumericTextBox ID="txtMontoDGII" runat="server" CssClass="tb" Culture="Spanish (Dominican Republic)"
                                            Type="Currency" Width="200px" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                            EmptyMessage="Monto Pagado en DGII" IncrementSettings-InterceptMouseWheel="false">
                                        </telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqMonto" runat="server" ControlToValidate="txtMontoDGII"
                                           CssClass="validator summary" ValidationGroup="3" Display="Static">El campo de monto pagado de DGII es requerido.</asp:RequiredFieldValidator>
                                    </li>
                                </ul>
                                <div class="clear" />
                            </asp:Panel>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnEnviarModificacion" runat="server" Text="Someter" OnClick="btnEnviarModificacion_Click"
                                    CssClass="btn" ValidationGroup="3" />
                                <div style="clear: both;">
                                </div>
                            </div>
                        </li>
                    </ul>
                </fieldset>
                <asp:ValidationSummary runat="server" ID="errorbox" 
                    HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;" ValidationGroup="3"/>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
