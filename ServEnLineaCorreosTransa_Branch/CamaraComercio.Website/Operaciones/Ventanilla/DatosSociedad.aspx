<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="DatosSociedad.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Ventanilla.DatosSociedad" %>

<%@ Register Src="~/UserControls/ManejoSocios.ascx" TagName="ManejoSocios" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls"
    TagPrefix="cc1" %>
<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- CSS -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/fbTextbox/TextboxList.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/fbTextbox/TextboxList.Autocomplete.css" rel="stylesheet" type="text/css" />
    <!-- Plugins -->
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/jquery.fieldtag.js" type="text/javascript"></script>
    <script src="/res/js/jquery.maskedinput.js" type="text/javascript"></script>
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/TextboxList.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/TextboxList.Autocomplete.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/GrowingInput.js" type="text/javascript"></script>
    <!-- Javascript de este formulario -->
    <script type="text/javascript" src="/res/js/ui.adecuacion.js"></script>
    <script type="text/javascript" src="/res/js/ui.datossociedad.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Telerik Mappings for AJAX -->
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lnkAddReferenciaBancaria">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridReferenciasBancarias" LoadingPanelID="pnlAjaxGridBancarias" />
                    <telerik:AjaxUpdatedControl ControlID="ddlReferenciasBancarias" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gridReferenciasBancarias">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlReferenciasBancarias" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HiddenField ID="hfNuevoRegistro" ClientIDMode="Static" Value="1" runat="server" />
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    Datos de la Sociedad/Empresa
                    <asp:Label runat="server" ID="lblTipoSociedadTitulo" />
                </h1>
            </div>
            <div id="content_body">
                <div class="stepsTl" id="stepsTl">
                    <ul>
                        <li>
                            <asp:HyperLink ID="hlinksolicitud" runat="server" NavigateUrl="#"
                                CssClass="stepNobox">Solicitud</asp:HyperLink></li>
                        <li><a href="#" class="stepLast">Datos Generales</a></li>
                        <li><a href="#" >Datos de la Empresa</a></li>
                        <li><a href="#">Confirmación</a></li>
                        <li><a href="#">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <fieldset class="form-fieldset">
                    <h2>Información de Socios/Accionistas/Propietarios</h2>
                    <uc1:ManejoSocios ID="ManejoSocios1" runat="server" TipoRelacion="A" NumeroSocios="2"
                        PropertyName="CantidadSocios" Enabled="True" />
                    <asp:Label CssClass="validator" runat="server" ID="lblSociosMensajes"></asp:Label>
                    <h3>Informaciones Financieras</h3>
                    <ul>
                        <li>
                            <asp:Label ID="lbltxtCapitalSocialActual" runat="server" AssociatedControlID="txtCapitalSocialActual"
                                Visible="False"> Capital Social Actual</asp:Label>
                            <telerik:RadNumericTextBox ID="txtCapitalSocialActual" runat="server" CssClass="tb shortInput"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" Visible="False">
                            </telerik:RadNumericTextBox>
                        </li>
                        <li id="liCapitalSocial">
                            <cc1:LabelOfv ID="lbltxtCapitalSocialNuevo" AssociatedControlID="txtCapitalSocialNuevo"
                                runat="server" PropertyName="CapitalSocial">Capital Social Autorizado</cc1:LabelOfv>
                            <cc1:NumericTextBoxOfv ID="txtCapitalSocialNuevo" runat="server" CssClass="tb shortInput"
                                MaxValue="999999999999.99" Culture="Spanish (Dominican Republic)" Type="Currency"
                                Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false"
                                PropertyName="CapitalSocial">
                            </cc1:NumericTextBoxOfv>
                            <asp:DropDownList runat="server" ID="ddlMonedaCapitalSocial" CssClass="shortdd" Enabled="False"
                                Visible="False" />
                            <cc1:RequiredValidatorOfv ID="txtCapitalSocialNuevoReq" runat="server" SetFocusOnError="true"
                                ErrorMessage="El capital social es requerido" ControlToValidate="txtCapitalSocialNuevo"
                                CssClass="validator" ValidationGroup="3" ClientIDMode="Static" PropertyName="CapitalSocial">El capital social es requerido</cc1:RequiredValidatorOfv>
                            <br />
                            <cc1:LabelOfv runat="server" ID="lblchkLlevaCapitalSocial" PropertyName="LibreCapitalSocial"
                                AssociatedControlID="chkLlevaCapitalSocial" />
                            <cc1:CheckBoxOfv runat="server" ID="chkLlevaCapitalSocial" PropertyName="LibreCapitalSocial"
                                Text="Empresa sin capital social" ClientIDMode="Static" Visible="false" />
                            <cc1:RangeValidatorOfv ID="rvCapitalSocialNuevo" runat="server" CssClass="validator"
                                ErrorMessage="Capital Autorizado especificado no es suficiente." Type="Currency"
                                MaximumValue="999999999999.99" MinimumValue="0.00" ValidationGroup="3" ControlToValidate="txtCapitalSocialNuevo"
                                PropertyName="CapitalSocial" Enabled="false"><br />El capital social minimo requerido para este tipo de sociedad/empresa es <%= FormatDecimalString(rvCapitalSocialNuevo.MinimumValue) %></cc1:RangeValidatorOfv>
                        </li>
                        <li>
                            <cc1:LabelOfv ID="lbltxtCapSuscrito" runat="server" AssociatedControlID="txtCapSuscrito"
                                PropertyName="CapitalSuscrito">Capital Suscrito y Pagado</cc1:LabelOfv>
                            <cc1:NumericTextBoxOfv ID="txtCapSuscrito" runat="server" CssClass="tb shortInput"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" PropertyName="CapitalSuscrito">
                            </cc1:NumericTextBoxOfv>
                            <asp:DropDownList runat="server" ID="ddlMonedaCapitalSuscrito" PropertyName="CapitalSuscrito"
                                CssClass="shortdd" Enabled="False" Visible="False" />
                            <cc1:RequiredValidatorOfv ID="txtCapSuscritoReq" runat="server" SetFocusOnError="true"
                                ErrorMessage="El capital suscrito es requerido" ControlToValidate="txtCapSuscrito"
                                CssClass="validator" ValidationGroup="3" ClientIDMode="Static" PropertyName="CapitalSuscrito">El capital suscrito es requerido</cc1:RequiredValidatorOfv>
                            <asp:Label runat="server" ID="lblErrorCapitalSuscrito" CssClass="validator" />
                        </li>
                        <li>
                            <asp:Label ID="lbltxtBienesRaices" runat="server" AssociatedControlID="txtBienesRaices"
                                Text="Bienes Raíces" />
                            <telerik:RadNumericTextBox ID="txtBienesRaices" runat="server" CssClass="tb shortInput"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false">
                            </telerik:RadNumericTextBox>
                            <asp:DropDownList runat="server" ID="ddlMonedaBienesRaices" CssClass="shortdd" Enabled="False"
                                Visible="False" />
                            <div class="comments" id="txtBienesRaicesComment">
                                Valor total en RD$ de inmuebles que la sociedad/empresa posee. Este valor puede
                                ser cero.
                            </div>
                        </li>
                        <li>
                            <cc1:LabelOfv ID="lbltxtActivos" runat="server" AssociatedControlID="txtActivos"
                                PropertyName="Activos">Activos </cc1:LabelOfv>
                            <cc1:NumericTextBoxOfv ID="txtActivos" runat="server" CssClass="tb shortInput" Culture="Spanish (Dominican Republic)"
                                Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false"
                                PropertyName="Activos" />
                            <asp:DropDownList runat="server" ID="ddlMonedaActivos" CssClass="shortdd" Enabled="False"
                                Visible="False" />
                            <div class="comments" id="txtActivosComment">
                                Valor total en RD$ de activos que la sociedad/empresa posee
                            </div>
                        </li>
                        <li>
                            <asp:Panel ID="pnlInformacionDGII" runat="server">
                                <ul>
                                    <li>
                                        <cc1:LabelOfv ID="lbltxtNoRecibo" runat="server" AssociatedControlID="txtNoRecibo"
                                            PropertyName="ReciboDGII">
                                No. Recibo DGII
                                        </cc1:LabelOfv>
                                        <cc1:TextBoxOfv ID="txtNoRecibo" runat="server" CssClass="tb shortInput" MaxLength="15"
                                            ClientID="Static" PropertyName="ReciboDGII" />
                                        <div class="comments" id="txtNoReciboComment">
                                            Número de recibo del pago por Impuesto de Constitución
                                        </div>
                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="txtNoReciboReq" runat="server"
                                            ErrorMessage="El número de recibo es requerido" ControlToValidate="txtNoRecibo"
                                            CssClass="validator" ValidationGroup="3" ClientIDMode="Static" PropertyName="ReciboDGII">
                                El número de recibo es requerido </cc1:RequiredValidatorOfv>
                                    </li>
                                    <li>
                                        <cc1:LabelOfv ID="lbltxtMontoDGII" runat="server" AssociatedControlID="txtMontoDGII"
                                            Text="Monto Pagado DGII" PropertyName="MontoReciboDGII" />
                                        <cc1:NumericTextBoxOfv ID="txtMontoDGII" runat="server" CssClass="tb shortInput"
                                            Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                            IncrementSettings-InterceptMouseWheel="false" PropertyName="MontoReciboDGII" />
                                        <asp:DropDownList runat="server" ID="ddlMonedaMontoDgii" PropertyName="MontoReciboDGII"
                                            CssClass="shortdd" Enabled="False" Visible="False" />
                                        <div class="comments" id="txtMontoDGIIComment">
                                            Monto pago en DGII por concepto de constitución
                                        </div>
                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="txtMontoDGIIReq" runat="server"
                                            ErrorMessage="El monto pagado en DGII es requerido" ControlToValidate="txtMontoDGII"
                                            CssClass="validator" ValidationGroup="3" ClientIDMode="Static" PropertyName="MontoReciboDGII">
                                El monto pagado en DGII es requerido </cc1:RequiredValidatorOfv>
                                    </li>
                                    <li>
                                        <cc1:LabelOfv ID="lblradFechaRecibo" runat="server" AssociatedControlID="radFechaRecibo"
                                            Text="Fecha Recibo" PropertyName="FechaReciboDGII" />
                                        <cc1:CalendarOfv ID="radFechaRecibo" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                            Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                            Nullable="True" PropertyName="FechaReciboDGII" CssClass="calendario">
                                            <TextBoxLabelStyle CssClass="tb shortInput" />
                                        </cc1:CalendarOfv>
                                        <div class="comments" id="radFechaReciboComment">
                                            Fecha en la que se realizó el pago del Impuesto de Constitución
                                        </div>
                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="radFechaReciboReq" runat="server"
                                            ErrorMessage="La fecha del recibo es requerida" ControlToValidate="radFechaRecibo"
                                            CssClass="validator" ValidationGroup="3" ClientIDMode="Static" PropertyName="FechaReciboDGII">La fecha del recibo es requerida </cc1:RequiredValidatorOfv>
                                    </li>
                                </ul>
                            </asp:Panel>
                        </li>
                        <li>
                            <asp:Label ID="lblcalInicioOperaciones" runat="server" AssociatedControlID="calInicioOperaciones"
                                Text="Fecha de Inicio Operaciones" />
                            <ew:CalendarPopup ID="calInicioOperaciones" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                CssClass="calendario" Nullable="True">
                                <TextBoxLabelStyle CssClass="tb shortInput" />
                            </ew:CalendarPopup>
                            <asp:RequiredFieldValidator runat="server" id="calInicioOperacionesReq" 
                                ControlToValidate="calInicioOperaciones" ValidationGroup="3"
                                ErrorMessage="La fecha de inicio de operaciones es requerida" CssClass="validator">
                                La fecha de inicio de operaciones es requerida
                            </asp:RequiredFieldValidator>
                        </li>
                        <li>
                            <cc1:LabelOfv runat="server" AssociatedControlID="calUltimaAsamblea" ID="lblcalUltimaAsamblea"
                                PropertyName="FechaUltAsamblea">
                    Fecha de última asamblea
                            </cc1:LabelOfv>
                            <cc1:CalendarOfv ID="calUltimaAsamblea" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                Nullable="True" VisibleDate="" CssClass="calendario" PropertyName="FechaUltAsamblea">
                                <TextBoxLabelStyle CssClass="tb shortInput" />
                            </cc1:CalendarOfv>
                            <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="calUltimaAsambleaReq" ErrorMessage="La fecha de la asamblea es requerida"
                                runat="server" ControlToValidate="calUltimaAsamblea" CssClass="validator" ValidationGroup="3"
                                ClientIDMode="Static" PropertyName="FechaUltAsamblea"> 
                    La fecha de su última asamblea es requerida 
                            </cc1:RequiredValidatorOfv>
                        </li>
                        
                        <li>
                            <asp:Label runat="server" AssociatedControlID="rblFechaCierreFiscal" 
                                ID="lblFechaCierreFiscal">Fecha de Cierre Fiscal</asp:Label>
                            <asp:RadioButtonList runat="server" ID="rblFechaCierreFiscal" 
                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Text="31 de Marzo"/>
                                <asp:ListItem Text="30 de Junio"/>
                                <asp:ListItem Text="30 de Septiembre"/>
                                <asp:ListItem Text="31 de Diciembre"/>
                            </asp:RadioButtonList>
                        </li>
                    </ul>
                    <h3>Informaciones Institucionales</h3>
                    <ul>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtDuracionSociedad" ID="lbltxtDuracionSociedad"> Duración de la Sociedad/Empresa</asp:Label>
                            <asp:DropDownList ID="ddlDuracionSociedad" runat="server" CssClass="sociedadIndefinidaDdl">
                                <asp:ListItem Text="Indefinida" Value="1" />
                                <asp:ListItem Text="A Tiempo Fijo" Value="2" />
                            </asp:DropDownList>
                            <asp:TextBox ID="txtDuracionSociedad" runat="server" CssClass="tb inputDuracionSociedad"
                                Width="80px"></asp:TextBox>
                            <div class="comments" id="txtDuracionSociedadComment">
                                Duración en años de la sociedad/empresa.
                            </div>
                        </li>
                        <li>
                            <cc1:LabelOfv runat="server" AssociatedControlID="txtDuracionOrganoAdmin" ID="lbltxtDuracionOrganoAdmin"
                                PropertyName="DuracionConsejo"> 
                    Duración del Órgano Adminsitrativo
                            </cc1:LabelOfv>
                            <cc1:NumericTextBoxOfv ID="txtDuracionOrganoAdmin" runat="server" CssClass="tb" Culture="Spanish (Dominican Republic)"
                                MaxValue="99" MinValue="1" Type="Number" Width="80px" Skin="" DataType="System.String"
                                IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false"
                                PropertyName="DuracionConsejo">
                                <NumberFormat DecimalDigits="0" />
                            </cc1:NumericTextBoxOfv>
                            <div class="comments" id="txtDuracionOrganoAdminComment">
                                Duración en años del órgano de administración.
                            </div>
                            <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="txtDuracionOrganoAdminReq" runat="server"
                                ErrorMessage="La duración del órgano administrador es requerida" ControlToValidate="txtDuracionOrganoAdmin"
                                CssClass="validator" ValidationGroup="3" ClientIDMode="Static" PropertyName="DuracionConsejo">
                    La duración del órgano adminsitrador es requerida 
                            </cc1:RequiredValidatorOfv>
                        </li>
                        <li>
                            <cc1:LabelOfv runat="server" AssociatedControlID="rblEsEnteRegulado" ID="lblrblEsEnteRegulado"
                                PropertyName="EnteRegulado"> 
                    Es Ente Regulado? 
                            </cc1:LabelOfv>
                            <cc1:RadioButtonListOfv ID="rblEsEnteRegulado" runat="server" RepeatLayout="Flow"
                                RepeatDirection="Horizontal" ClientIDMode="Static" CssClass="radio-empleados radio"
                                PropertyName="EnteRegulado">
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </cc1:RadioButtonListOfv>
                        </li>
                        <li>
                            <div id="pnlEmpresasReguladas" style="margin-left: 165px">
                                <ul>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="ddlTipoEnteRegulado" ID="lblddlTipoEnteRegulado"> Tipo de Ente</asp:Label>
                                        <asp:DropDownList ID="ddlTipoEnteRegulado" runat="server" CssClass="dd">
                                            <asp:ListItem>Por definir</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtNoResolucion" ID="lbltxtNoResolucion"> No. de Resolución</asp:Label>
                                        <asp:TextBox ID="txtNoResolucion" runat="server" CssClass="tb" Width="106px"></asp:TextBox>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <asp:Panel ID="pnlTipoDeAcciones" runat="server">
                                <ul>
                                    <li>
                                        <cc1:LabelOfv runat="server" AssociatedControlID="rblTipoAccionesExtranjeras" ID="lblrblTipoAccionesExtranjeras"
                                            Visible="False" PropertyName="AccionesNominales">
                                Tipo de Acciones</cc1:LabelOfv>
                                        <cc1:RadioButtonListOfv ID="rblTipoAccionesExtranjeras" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow" CssClass="radio" Visible="False" PropertyName="AccionesNominales">
                                            <asp:ListItem>con valor nominal</asp:ListItem>
                                            <asp:ListItem>sin valor nominal</asp:ListItem>
                                        </cc1:RadioButtonListOfv>
                                    </li>
                                </ul>
                            </asp:Panel>
                        </li>
                        <li id="liSucursales">
                            <label for="txtSucursales" id="lbltxtSucursales">
                                Sucursales</label>
                            <input type="text" id="txtSucursales" />
                            <div class="comments" id="txtSucursalesComment">
                                Ingrese todas sus sucursales. Separe cada una utilizando una coma.
                            </div>
                            <asp:HiddenField ID="hfTxtSucursales" ClientIDMode="Static" runat="server" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtEmpleadosM" ID="lbltxtEmpleadosM">
                    Empleados</asp:Label>
                            <asp:TextBox ID="txtEmpleadosM" runat="server" CssClass="tb inputEmpleados" Title="Masculinos"
                                autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                            &nbsp;
                            <asp:TextBox ID="txtEmpleadosF" runat="server" CssClass="tb inputEmpleados" Title="Femeninos"
                                autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                            <div class="comments" id="txtEmpleadosMComment">
                                Ingrese el número de empleados masculinos y femeninos.
                            </div>
                        </li>
                        <li>
                            <label>
                            </label>
                            <strong>Total: <span id="total-empleados"></span></strong>
                            </li>
                    </ul>
                    <h3>
                        Referencias y Registros</h3>
                    <ul>
                        <li id="liReferenciasComerciales">
                            <label for="txtReferenciasComerciales">
                                Referencias Comerciales
                            </label>
                            <input type="text" id="txtReferenciasComerciales" />
                            <div id="txtReferenciasComercialesComment" class="comments">
                                Ingrese todas las referencias comerciales que desee. Separe cada una utilizando
                                una coma.
                            </div>
                            <asp:HiddenField ID="hfReferenciasComerciales" ClientIDMode="Static" runat="server" />
                        </li>
                        <li id="liReferenciasBancarias">
                            <asp:Label runat="server" AssociatedControlID="txtReferenciasBancarias" ID="lbltxtReferenciasBancarias"> 
                    Referencias Bancarias
                            </asp:Label>
                            <asp:TextBox runat="server" ID="txtReferenciasBancarias" ClientIDMode="Static" />
                            <asp:HiddenField ID="hfReferenciasBancarias" ClientIDMode="Static" runat="server" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtNombreComercialNumero" ID="lbltxtNombreComercialNumero"> Registro de Nombre Comercial</asp:Label>
                            <telerik:RadTextBox ID="txtNombreComercialDesc" runat="server" EmptyMessage="Nombre Comercial"
                                Width="150px" CssClass="tb" Skin=""></telerik:RadTextBox>
                                <telerik:RadTextBox ID="txtNombreComercialDesc2" runat="server" EmptyMessage="Segunda Opción"
                                Width="150px" CssClass="tb" Skin=""></telerik:RadTextBox>
                                <telerik:RadTextBox ID="txtNombreComercialDesc3" runat="server" EmptyMessage="Tercera Opción"
                                Width="150px" CssClass="tb" Skin=""></telerik:RadTextBox>
                            <div class="comments" id="txtNombreComercialDescComment">
                                Especificar el Nombre Comercial que desea registrar en la Oficina Nacional de la 
                                Propiedad Industrial (ONAPI). Ingrese tres opciones a ser utilizadas en caso de que 
                                su nombre comercial no esté disponible.
                            </div>
                        </li>
                        <li>
                            <div class="footer_go"> 
                            <asp:Button ID="btnDatosFinancierosLlenos" runat="server" Text="Siguiente" OnClick="btnDatosFinancierosLlenos_Click"
                                ValidationGroup="3" CssClass="btn" />
                                </div>
                        </li>
                        <li>
                            <asp:ValidationSummary runat="server" ID="vsSummary" ValidationGroup="3" CssClass="validator" />
                        </li>
                        <li>
                            <asp:Label runat="server" ID="lblNoReciboDgiiExiste" Visible="false" CssClass="validator">
                    El número de recibo de DGII utilizado ya ha sido utilizado en una transacción previa. 
                            </asp:Label>
                        </li>
                    </ul>
                </fieldset>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
