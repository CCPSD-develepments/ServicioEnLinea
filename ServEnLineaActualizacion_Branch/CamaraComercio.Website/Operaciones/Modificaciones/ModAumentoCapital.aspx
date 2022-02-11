<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ModAumentoCapital.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.ModAumentoCapital" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- CSS -->
    <link href="/res/css/Calendar.Ccpsd.css" rel="stylesheet" type="text/css" />
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="empresa">
                    <span class="right normal">
                        <asp:Literal ID="ltNombreSocialTitulo" runat="server"></asp:Literal>,
                        <asp:Literal ID="ltTipoSociedadTitulo" runat="server" />
                    </span>Modificación de Empresa</h1>
            </div>
            <div id="content_body">
                <h2>
                    Por Aumento Capital Autorizado / Capital Social</h2>
                <h5>
                    Introduce la información correspondiente en cada campo y haz click sobre "Someter".
                    Si tienes alguna duda con un término visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                        Glosario de Términos</a>. <strong>Todo los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                <br />
                <fieldset class="form-fieldset widderField">
                    <ul>
                        <li>
                            <label>
                                Denominación/Razón Social
                            </label>
                            <asp:Literal ID="ltNombreSocial" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <label>
                                <asp:Label runat="server" ID="lblNombreCapitalSocial" Text="Capital Social Autorizado " />
                                Actual</label><asp:Literal ID="ltCapAutorizado" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <label>
                                Nuevo <asp:Label runat="server" ID="lbltxtCapitalSocialNuevo">Capital Social Autorizado</asp:Label>
                            </label>
                            <telerik:RadNumericTextBox ID="txtCapitalSocialNuevo" runat="server" CssClass="tb commentCtrl"
                                Culture="Spanish (Dominican Republic)" EmptyMessage="" Type="Currency" Width="200px"
                                Skin="" IncrementSettings-InterceptArrowKeys="false" 
                                IncrementSettings-InterceptMouseWheel="false" TabIndex="1">
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtCapitalSocialNuevo" CssClass="validator summary" ValidationGroup="3"
                                Display="Static">El campo de capital social autorizado es requerido.</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvCapitalSocialNuevo" runat="server" CssClass="validator summary"
                                ValidationGroup="3" Display="Static" Type="Currency" MaximumValue="9999999999.99"
                                ControlToValidate="txtCapitalSocialNuevo">
                            El capital social mínimo requerido para este tipo de sociedad es <%=String.Format("{0}", rvCapitalSocialNuevo.MinimumValue) %>
                            </asp:RangeValidator>
                            <asp:RangeValidator ID="rvCapitalSocialAnterior" runat="server" CssClass="validator summary"
                                ValidationGroup="3" Display="Static" Type="Currency" MaximumValue="9999999999.99"
                                ControlToValidate="txtCapitalSocialNuevo">
                            El nuevo capital social autorizado debe ser mayor que el actual.
                            </asp:RangeValidator>
                            <div class="comments" id="MainContent_txtCapitalSocialNuevo_textComment">
                                Ingresa el nuevo capital para la sociedad/empresa. Este monto debe ser mayor al 
                                valor actual.
                            </div>
                        </li>
                        <li>
                            <asp:Panel ID="pnlInformacionDGII" runat="server">
                                <ul>
                                    <li>
                                        <cc1:LabelOfv runat="server" id="txtNoReciboLbl" AssociatedControlID="txtNoRecibo" PropertyName="ReciboDGII">
                                            No. Recibo DGII</cc1:LabelOfv>
                                        <cc1:TextBoxOfv ID="txtNoRecibo" runat="server" CssClass="tb commentCtrl" 
                                            MaxLength="15" TabIndex="2" PropertyName="ReciboDGII"/>
                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="reqNumeroRecibo" runat="server"
                                            ControlToValidate="txtNoRecibo" CssClass="validator summary" ValidationGroup="3"
                                            Display="None" ErrorMessage="El campo de número de recibo de DGII es requerido." 
                                            PropertyName="ReciboDGII"/>
                                        <div class="comments" id="MainContent_txtNoReciboComment">
                                            Ingresa el número de recibo del pago por impuesto de aumento de capital. Para 
                                            más información visita la <a href="https://www.dgii.gov.do/Paginas/Index.aspx">Dirección General de
                                                Impuestos (DGII)</a>.
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </li>
                                    <li>
                                        <cc1:LabelOfv runat="server" id="txtFechaReciboLbl" 
                                            AssociatedControlID="radFechaRecibo" PropertyName="FechaReciboDGII" 
                                            Text ="Fecha. Recibo DGII"/>
                                        <cc1:CalendarOfvRad  ID="radFechaRecibo" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                            Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha."
                                            Nullable="True" CssClass="calendario" TabIndex="3" PropertyName="FechaReciboDGII">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput CssClass="commentCtrl" TabIndex="3" />
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="3" />
                                        </cc1:CalendarOfvRad>

                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="reqFecha" runat="server" ControlToValidate="radFechaRecibo"
                                            CssClass="validator summary" ValidationGroup="3" Display="Static" PropertyName="FechaReciboDGII"
                                            ErrorMessage="El campo de fecha de recibo de DGII es requerido." />
                                            
                                        <div class="comments" id="MainContent_radFechaRecibo_dateInput_textComment">
                                            Oprime el botón del calendario y selecciona la fecha en la que se realizó el 
                                            pago del impuesto. Para más información visita la <a href="https://www.dgii.gov.do/Paginas/Index.aspx">
                                                Dirección General de Impuestos (DGII)</a>.
                                        </div>
                                    </li>
                                    <li> 
                                        <cc1:LabelOfv runat="server" id="txtMontoDGIILbl" 
                                            AssociatedControlID="txtMontoDGII" PropertyName="MontoReciboDGII" 
                                            Text ="Monto Pagado DGII" />
                                        <cc1:NumericTextBoxOfv ID="txtMontoDGII" runat="server" 
                                            CssClass="tb commentCtrl" Culture="Spanish (Dominican Republic)"
                                            Type="Currency" Width="200px" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                            EmptyMessage="" IncrementSettings-InterceptMouseWheel="false" TabIndex="4"
                                            PropertyName="MontoReciboDGII">
                                        </cc1:NumericTextBoxOfv>
                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="reqMonto" runat="server" ControlToValidate="txtMontoDGII" PropertyName="MontoReciboDGII"
                                            CssClass="validator summary" ValidationGroup="3" Display="Static" ErrorMessage="El campo de monto pagado de DGII es requerido." />
                                        <div class="comments" id="MainContent_txtMontoDGII_textComment">
                                            Ingresa el monto pago. Para más información visita la <a href="https://www.dgii.gov.do/Paginas/Index.aspx">Dirección General de Impuestos
                                                (DGII)</a>.</div>
                                        <div class="clear">
                                        </div>
                                    </li>
                                </ul>
                                <div class="clear" />
                            </asp:Panel>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnEnviarModificacion" runat="server" Text="Someter" OnClick="btnEnviarModificacion_Click"
                                    CssClass="btn btnFormNext" ValidationGroup="3" TabIndex="5" />
                                <div style="clear: both;">
                                </div>
                            </div>
                        </li>
                    </ul>
                </fieldset>
                <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                    ValidationGroup="3" ClientIDMode="Static" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
