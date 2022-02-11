<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="DatosSociedad.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.DatosSociedad" %>

<%@ Register Src="~/UserControls/ManejoSocios.ascx" TagName="ManejoSocios" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="sm1" %>
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
    <script type="text/javascript">
        $(document).ready(function () {
            //Menu de navegación
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <sm1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Hidden Fields -->
    <asp:HiddenField ID="hfNuevoRegistro" ClientIDMode="Static" Value="1" runat="server" />
    <!-- Componentes de Ajax -->
    <telerik:RadAjaxManager runat="server" ID="radAjaxMgr">
    </telerik:RadAjaxManager>
    <!-- Main Container -->
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="empresa">
                    <span class="right normal">
                        <asp:Literal runat="server" ID="litNombreEmpresaTit" />
                    </span>Modificación de Registro
                </h1>
            </div>
            <div id="content_body">
                <fieldset class="form-fieldset">
                    <h2>
                        Datos de Socios/Accionistas/Propietarios</h2>
                    <h5>
                        Modifica los socios, propietarios y/o accionistas de la empresa y la información
                        financiera de la empresa, luego presiona el botón de "Siguiente". Si tienes alguna
                        duda con un término, visita nuestro <a target="_blank" href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                            Glosario de Términos</a>. <strong>Los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                    <h3>
                        Información de Propietarios/Socios/Accionistas</h3>
                    <!-- Manejo de Socios -->
                    <uc1:ManejoSocios ID="ManejoSocios1" runat="server" TipoRelacion="A" NumeroSocios="2"
                        EsModificacion="true" PropertyName="CantidadSocios" Enabled="True" />
                    <!-- End Manejo de Socios -->
                    <h5 class="sectDetail">
                        <asp:Literal runat="server" ID="litDescripcionSociedad" />
                    </h5>
                    <h3>
                        Información Financiera y Empresarial</h3>
                    <ul>
                        <li>
                            <label for="lblMontoCapitalSocial">
                                <cc1:LabelOfv ID="lblMontoCapitalSocialLbl" runat="server" PropertyName="CapitalSocial"
                                    Text="Capital Social" />
                            </label>
                            <asp:Literal runat="server" ID="lblMontoCapitalSocial" />
                        </li>
                        <li id="liCapitalSocial">
                            <asp:Panel runat="server" ID="pnlCapitalSuscrito">
                                <label for="lblMontoCapitalSuscrito">
                                    <cc1:LabelOfv ID="lblCapitalSuscrito" runat="server" PropertyName="CapitalSuscrito"
                                        Text="Capital Suscrito" />
                                </label>
                                <asp:Literal runat="server" ID="lblMontoCapitalSuscrito" />
                            </asp:Panel>
                        </li>
                        <li>
                            <label>
                                RNC</label>
                            <asp:TextBox runat="server" ID="txtRNC" ClientIDMode="Static" CssClass="tb" MaxLength="11" />
                            <asp:RequiredFieldValidator runat="server" ID="txtRNCReq" CssClass="validator summary"
                                ControlToValidate="txtRNC" ErrorMessage="El RNC Es necesario" ClientIDMode="Static"
                                Display="None" ValidationGroup="3" />
                            <asp:RegularExpressionValidator runat="server" ID="txtRNCRangeVal" CssClass="validator summary"
                                ControlToValidate="txtRNC" ErrorMessage="El RNC debe tener mínimo 9 caracteres"
                                ClientIDMode="Static" Display="Static" ValidationGroup="3" ValidationExpression="[0-9]{8,}$" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtDuracionSociedad" ID="lbltxtDuracionSociedad"> Duración de la Empresa</asp:Label>
                            <asp:DropDownList ID="ddlDuracionSociedad" runat="server" CssClass="sociedadIndefinidaDdl"
                                ClientIDMode="Static">
                                <asp:ListItem Text="Indefinida" Value="1" />
                                <asp:ListItem Text="A Tiempo Fijo" Value="2" />
                            </asp:DropDownList>
                            <asp:TextBox ID="txtDuracionSociedad" runat="server" CssClass="tb inputDuracionSociedad commentCtrl"
                                Width="80px" ClientIDMode="Static"></asp:TextBox>
                            <div class="comments" id="txtDuracionSociedadComment">
                                Selecciona si la duración de la empresa es a tiempo fijo o indefinida. En el caso
                                de que sea a tiempo fijo, especifique la duración en cantidad de años.
                            </div>
                        </li>
                        <li>
                            <label for="txtDuracionOrganoAdmin">
                                <cc1:LabelOfv runat="server" ID="lbltxtDuracionOrganoAdmin" PropertyName="DuracionConsejo">Duración del Órgano Administrativo </cc1:LabelOfv>
                                <cc1:SpanOfv runat="server" ID="spnDuracionOrganoAdmin" PropertyName="DuracionConsejo"
                                    CssClass="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:NumericTextBoxOfv ID="txtDuracionOrganoAdmin" runat="server" CssClass="tb commentCtrl"
                                Culture="Spanish (Dominican Republic)" MaxValue="99" MinValue="1" Type="Number"
                                Width="80px" Skin="" DataType="System.String" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" PropertyName="DuracionConsejo">
                                <NumberFormat DecimalDigits="0" />
                            </cc1:NumericTextBoxOfv>
                            &nbsp;<cc1:RequiredValidatorOfv runat="server" ID="txtDuracionOrganoAdminReq" CssClass="validator summary"
                                ControlToValidate="txtDuracionOrganoAdmin" PropertyName="DuracionConsejo" ErrorMessage="La duración del órgano de administración es requerida"
                                ClientIDMode="Static" Display="None" ValidationGroup="3" />
                            <cc1:RangeValidatorOfv ID="rvDuracionConsejo" runat="server" CssClass="validator summary"
                                Type="Integer" MaximumValue="6" MinimumValue="0" ValidationGroup="3" ControlToValidate="txtDuracionOrganoAdmin"
                                PropertyName="DuracionConsejo" Enabled="false" Display="None" ClientIDMode="Static"></cc1:RangeValidatorOfv>
                            <div class="comments" id="MainContent_txtDuracionOrganoAdmin_textComment">
                                Ingresa la
                                <cc1:LabelOfv runat="server" ID="lblDuracionOrganoComment" PropertyName="DuracionConsejo" />
                                en cantidad de años.
                                <cc1:LabelOfv runat="server" ID="lblDuracionOrganoAdminComment" PropertyName="DuracionConsejo" />.
                            </div>
                        </li>
                        <li>
                            <label for="rblEsEnteRegulado">
                                <cc1:LabelOfv runat="server" ID="lblrblEsEnteRegulado" PropertyName="EnteRegulado">Es Ente Regulado? </cc1:LabelOfv>
                                <cc1:SpanOfv runat="server" ID="spnRblEsEnteRegulado" PropertyName="EnteRegulado"
                                    class="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:RadioButtonListOfv ID="rblEsEnteRegulado" runat="server" RepeatLayout="Flow"
                                RepeatDirection="Horizontal" ClientIDMode="Static" CssClass="radio-empleados radio commentCtrlHov"
                                PropertyName="EnteRegulado">
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </cc1:RadioButtonListOfv>
                            &nbsp;<cc1:RequiredValidatorOfv PropertyName="EnteRegulado" runat="server" ID="rfvEsEnteRegulado"
                                ControlToValidate="rblEsEnteRegulado" ValidationGroup="3" CssClass="validator summary"
                                ErrorMessage="El campo de ente regulado de la empresa es requerido." Display="none" />
                            <div class="comments" id="rblEsEnteReguladoComment">
                                Especifica si la empresa es un ente regulado. Los entes regulados son las empresas
                                que se rigen por una ley especial o entidad reguladora. Ej: banca, telecomunicaciones,
                                etc. En el caso de que sea regulada por una ley especial, selecciona la zona y ingresa
                                el número de resolución. Para más información visita nuestro <a target="_blank" href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                    Glosario de Términos</a>.
                            </div>
                            <div class="clear">
                            </div>
                        </li>
                        <li>
                            <div id="pnlEmpresasReguladas" style="margin-left: 0px">
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
                                        <label for="rblTipoAccionesExtranjeras">
                                            <cc1:LabelOfv runat="server" ID="lblrblTipoAccionesExtranjeras" Visible="False" PropertyName="AccionesNominales">
                                            Tipo de Acciones  </cc1:LabelOfv>
                                        </label>
                                        <cc1:RadioButtonListOfv ID="rblTipoAccionesExtranjeras" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Table" CssClass="radio" Visible="False" PropertyName="AccionesNominales">
                                            <asp:ListItem>con valor nominal</asp:ListItem>
                                            <asp:ListItem>sin valor nominal</asp:ListItem>
                                        </cc1:RadioButtonListOfv>
                                        <cc1:RequiredValidatorOfv runat="server" ID="rfvTipoAccionesExtranjeras" ControlToValidate="rblTipoAccionesExtranjeras"
                                            PropertyName="AccionesNominales" ValidationGroup="3" CssClass="validator summary"
                                            ErrorMessage="El campo de tipo de acciones es requerido." Display="None" />
                                    </li>
                                </ul>
                            </asp:Panel>
                        </li>
                        <li id="liSucursales">
                            <label for="txtSucursales" id="lbltxtSucursales">
                                Sucursales</label>
                            <input type="text" id="txtSucursales" class="commentCtrl" />
                            <div class="comments" id="txtSucursalesComment">
                                Ingresa las sucursales que comprende su empresa separadas por coma. Ej: Sucursal
                                de Servicios, Sucursal Ejecutiva, etc. Este campo es opcional.</div>
                            <asp:HiddenField ID="hfTxtSucursales" ClientIDMode="Static" runat="server" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtEmpleadosM" ID="lbltxtEmpleadosM"> Empleados</asp:Label>
                            <asp:TextBox ID="txtEmpleadosM" runat="server" CssClass="tb inputEmpleados commentCtrl"
                                Title="Masculinos" autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                            &nbsp;
                            <asp:TextBox ID="txtEmpleadosF" runat="server" CssClass="tb inputEmpleados commentCtrl"
                                Title="Femeninos" autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                            <div class="comments" id="txtEmpleadosMComment">
                                Ingresa el número total de empleados de la empresa. Especifique aqúi la cantidad
                                de empleados masculinos. Este campo es opcional.
                            </div>
                            <div class="comments" id="txtEmpleadosFComment">
                                Ingresa el número total de empleados de la empresa. Especifique aqúi la cantidad
                                de empleados femeninos. Este campo es opcional.
                            </div>
                            <asp:RequiredFieldValidator ID="txtEmpleadosMReq" runat="server" ClientIDMode="Static"
                                ControlToValidate="txtEmpleadosM" CssClass="validator summary" Display="None"
                                ErrorMessage="El número de empleados masculinos es necesario" ValidationGroup="3" />
                            <asp:RequiredFieldValidator ID="txtEmpleadosFReq" runat="server" ClientIDMode="Static"
                                ControlToValidate="txtEmpleadosF" CssClass="validator summary" Display="None"
                                ErrorMessage="El número de empleados femeninos es necesario" ToolTip="3" />
                        </li>
                        <li>
                            <label>
                            </label>
                            <strong>Total: <span id="total-empleados"></span></strong></li>
                    </ul>
                    <h3>
                        Referencias y Registros</h3>
                    <ul>
                        <li id="liReferenciasComerciales">
                            <label for="txtReferenciasComerciales">
                                Referencias Comerciales
                            </label>
                            <input type="text" id="txtReferenciasComerciales" class="commentCtrl" />
                            <div id="txtReferenciasComercialesComment" class="comments">
                                Ingresa todas las referencias comerciales que desees, separando cada una utilizando
                                una coma .Ingresa las sucursales que comprende su empresa separadas por coma. Ej:
                                Sucursal de Servicios, Sucursal Ejecutiva, etc. Este campo es opcional.</div>
                            <asp:HiddenField ID="hfReferenciasComerciales" ClientIDMode="Static" runat="server" />
                        </li>
                        <li id="liReferenciasBancarias">
                            <asp:Label runat="server" AssociatedControlID="txtReferenciasBancarias" ID="lbltxtReferenciasBancarias"> Referencias Bancarias </asp:Label>
                            <asp:TextBox runat="server" ID="txtReferenciasBancarias" ClientIDMode="Static" class="commentCtrl" />
                            <asp:HiddenField ID="hfReferenciasBancarias" ClientIDMode="Static" runat="server" />
                            <div id="txtReferenciasBancariasComment" class="comments">
                                Ingresa las referencias bancarias de la empresas separadas por coma. Este campo
                                es opcional.</div>
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtNombreComercialNumero" ID="lbltxtNombreComercialNumero"> Registro de Nombre Comercial</asp:Label>
                            <telerik:RadTextBox ID="txtNombreComercialNumero" runat="server" EmptyMessage="No. registro"
                                Width="100px" CssClass="tb commentCtrl" Skin="">
                            </telerik:RadTextBox>
                            <cc1:ButtonOfv runat="server" id="btnValidarOnapi" ClientIDMode="Static" 
                                            CssClass="btnSmall" PropertyName="validacionOnapi" 
                                Text="Validar" onclick="btnValidarOnapi_Click" Visible="false"/>&nbsp;&nbsp;
                                <br />

                            <telerik:RadTextBox ID="txtNombreComercialDesc" runat="server" EmptyMessage="Nombre Comercial"
                                Width="195px" CssClass="tb commentCtrl" Skin="">
                            </telerik:RadTextBox>
                            <div class="comments" id="MainContent_txtNombreComercialNumero_textComment">
                                Ingresa el número del registro comercial aprobado por ONAPI. Para más información
                                visita la <a target="_blank" href="http://onapi.gob.do/">Oficina Nacional de la Propiedad
                                    Industrial (ONAPI)</a>. Este campo es opcional.</div>
                            <div class="comments" id="MainContent_txtNombreComercialDesc_textComment">
                                Ingresa el nombre del registro comercial aprobado por ONAPI. Para más información
                                visita la <a target="_blank" href="http://onapi.gob.do/">Oficina Nacional de la Propiedad
                                    Industrial (ONAPI)</a>. Este campo es opcional.</div>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnDatosFinancierosLlenos" runat="server" Text="Siguiente" OnClick="btnDatosFinancierosLlenos_Click"
                                    ValidationGroup="3" CssClass="btn btnFormNext" /><div style="clear: both;">
                                    </div>
                            </div>
                        </li>
                        <li></li>
                    </ul>
                </fieldset>
                <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                    ClientIDMode="Static" ValidationGroup="3" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
