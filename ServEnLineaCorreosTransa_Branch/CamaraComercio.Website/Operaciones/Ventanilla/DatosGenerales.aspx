<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="DatosGenerales.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Ventanilla.DatosGenerales"
    ClientIDMode="Static" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- CSS Styles -->
    <link href="/res/js/fbTextbox/TextboxList.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script type="text/javascript" src="/res/js/jquery.alphanumeric.js"></script>
    <script type="text/javascript" src="/res/js/jquery.fieldtag.js"></script>
    <script type="text/javascript" src="/res/js/jquery.maskedinput.js"></script>
    <script src="/res/js/fbTextbox/TextboxList.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/GrowingInput.js" type="text/javascript"></script>
    <!-- User Scripts -->
    <script type="text/javascript" src="/res/js/ui.adecuacion.js"></script>
    <script type="text/javascript" src="/res/js/ui.datosgenerales.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Telerik Mappings for AJAX -->
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCiudad" EventName="OnSelectedIndexChanged">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlSector" />
                    <telerik:AjaxUpdatedControl ControlID="lblSectores" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1 id="creacion">
                        Creación de Empresas</h1>
                </div>
                <div id="content_body">
                    <div class="stepsTl" id="stepsTl">
                    <ul>
                        <li><a href="#" class="stepDone">Solicitud</a></li>
                        <li><a href="#" class="stepLast">Datos Generales</a></li>
                        <li><a href="#">Datos de la Empresa</a></li>
                        <li><a href="#">Confirmación</a></li>
                        <li><a href="#">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                    <fieldset class="form-fieldset">
                        <h2>
                            Datos Generales</h2>
                        <ul>
                            <li>
                                <label>
                                </label>
                                <asp:Label runat="server" ID="lblDenominacionSocial" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="lblTipoEmpresaActual" ID="lblLblTipoEmpresaActual">Tipo de Sociedad/Empresa (actual) </asp:Label>
                                <asp:Label ID="lblTipoEmpresaActual" runat="server"></asp:Label>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddAdecuacion" ID="lblddAdecuacion">Registro de</asp:Label>
                                <asp:DropDownList ID="ddAdecuacion" runat="server" Width="250px" CssClass="dd ddTipoSociedad"
                                    ClientIDMode="Static" />
                            </li>
                            <div id="divNacionalidad">
                                <ul>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="ddlPais" ID="lblddlPais">Nacionalidad</asp:Label>
                                        <asp:DropDownList ID="ddlPais" runat="server" CssClass="dd" ClientIDMode="Static">
                                        </asp:DropDownList>
                                        <div class="comments" id="Div1">
                                            Nacionalidad de origen de la Empresa
                                        </div>
                                        <asp:RegularExpressionValidator ID="ddlPaisReqex" runat="server" ControlToValidate="ddlPais"
                                            ErrorMessage="Debe escoger un País válido" ValidationExpression="^[1-9]+[0-9]*$"
                                            ValidationGroup="2" CssClass="validator">Debe escoger un País válido</asp:RegularExpressionValidator>
                                    </li>
                                </ul>
                            </div>
                            <asp:HiddenField runat="server" ID="hfEmpresasExtranjeras" />
                            <asp:HiddenField runat="server" ID="hfPaisIdRepDominicana" />
                            <li>
                                <asp:Label runat="server" AssociatedControlID="lblFechaEmision" ID="lbllblFechaEmision">Fecha de Emisión</asp:Label>
                                <asp:Label ID="lblFechaEmision" runat="server"></asp:Label>
                            </li>
                            <li>
                                <asp:Label runat="server" ID="lbllblFechaVencimiento" AssociatedControlID="lblFechaVencimiento">Fecha de Vencimiento</asp:Label>
                                <asp:Label ID="lblFechaVencimiento" runat="server"></asp:Label>
                                <asp:Panel ID="pnlRenovacionVencida" runat="server" CssClass="warnings" Visible="False">
                                    <span style="color: #FF0000">El registro actual ha vencido.</span> Se incluirá el
                                    costo de renovaci&oacute;n junto con las adecuaciones solicitadas.</asp:Panel>
                            </li>
                        </ul>
                        <h3>
                            Dirección de la Sociedad/Empresa</h3>
                        <ul>
                            <li>
                                <asp:Label ID="lbltxtDireccionEmpCalle" runat="server" AssociatedControlID="txtDireccionEmpCalle">Calle / No.</asp:Label>
                                <telerik:RadTextBox ID="txtDireccionEmpCalle" runat="server" CssClass="tb" EmptyMessage="Calle"
                                    Skin="" />
                                <telerik:RadTextBox ID="txtDireccionEmpNumero" runat="server" CssClass="tb" Width="60px"
                                    EmptyMessage="No." Skin="" />
                                <div class="comments" id="txtDireccionEmpCalleComment">
                                    Calle o Avenida en la que esta ubicada la empresa.
                                </div>
                                <div class="comments" id="txtDireccionEmpNumeroComment">
                                    Número del local
                                </div>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtDireccionEmpCalleReq" runat="server"
                                    ClientIDMode="Static" ControlToValidate="txtDireccionEmpCalle" CssClass="validator"
                                    ValidationGroup="2" ErrorMessage="La direcci&oacute;n es un dato obligatorio"><br /><label></label>La dirección es un dato obligatorio</asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddlCiudad" ID="lblddlCiudad">Ciudad</asp:Label>
                                <asp:DropDownList ID="ddlCiudad" runat="server" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged"
                                    CssClass="dd" AutoPostBack="True" ClientIDMode="Static">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" ID="txtCiudad" CssClass="tb" ClientIDMode="Static" />
                                <div class="comments" id="ddlMunicipioComment">
                                    Ciudad en la que está ubicada la empresa
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ddlCiudad"
                                    ErrorMessage="Debe escoger una ciudad válida" ValidationExpression="^[1-9]+[0-9]*$"
                                    ValidationGroup="2" Display="Dynamic" CssClass="validator">Debe escoger una ciudad válida</asp:RegularExpressionValidator>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddlSector" ID="lblddlSector">Sector</asp:Label>
                                <asp:DropDownList ID="ddlSector" runat="server" CssClass="dd" ClientIDMode="Static">
                                </asp:DropDownList>
                                <asp:Label ID="lblSectores" runat="server" ClientIDMode="Static">No Aplica</asp:Label>
                                <div class="comments" id="ddCiudadComment0">
                                    Sector en el que esta registrada la empresa
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtApartadoPostal" ID="lbltxtApartadoPostal">Apartado Portal</asp:Label>
                                <asp:TextBox ID="txtApartadoPostal" runat="server" CssClass="tb"></asp:TextBox>
                                <div class="comments" id="txtApartadoPostalComment">
                                    Apartado postal de su empresa.
                                </div>
                            </li>
                        </ul>
                        <h3>
                            Informaciones de Contacto de la Sociedad/Empresa</h3>
                        <ul>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtTelefonoPrimario" ID="lbltxtTelefonoPrimario">Teléfono Primario</asp:Label>
                                <asp:TextBox ID="txtTelefonoPrimario" runat="server" CssClass="tb inputTelefonoPrimario"></asp:TextBox>
                                &nbsp;
                                <telerik:RadTextBox ID="txtTelefonoPrimarioExtension" runat="server" CssClass="tb"
                                    EmptyMessage="Ext." Skin="" Width="60px" MaxLength="4" />
                                <div class="comments" id="txtTelefonoPrimarioComment">
                                    Teléfono Principal de su empresa. Sin espacios ni guíones.
                                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtTelefonoPrimarioReq" runat="server"
                                        ClientIDMode="Static" ErrorMessage="Debe proveer por lo menos su teléfono primario"
                                        ControlToValidate="txtTelefonoPrimario" CssClass="validator" ValidationGroup="2">
                    Debe proveer por lo menos su teléfono primario
                                </asp:RequiredFieldValidator>
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtTelefonoSecundario" ID="lbltxtTelefonoSecundario">Teléfono Secundario</asp:Label>
                                <asp:TextBox ID="txtTelefonoSecundario" runat="server" CssClass="tb inputTelefonoSecundario"></asp:TextBox>&nbsp;
                                <telerik:RadTextBox ID="txtTelefonoSecundarioExtension" runat="server" AutoPostBack="True"
                                    CssClass="tb" EmptyMessage="Ext." Skin="" Width="60px" MaxLength="4" />
                                <div class="comments" id="txtTelefonoSecundarioComment">
                                    El teléfono Secundario es opcional
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtFax" ID="lbltxtFax">Fax</asp:Label>
                                <asp:TextBox ID="txtFax" runat="server" CssClass="tb inputFax"></asp:TextBox>
                                <div class="comments" id="txtFaxComment">
                                    El número de fax es opcional
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtEmail" ID="lbltxtEmail">Correo Electrónico</asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="tb"></asp:TextBox>
                                <div class="comments" id="txtEmailComment">
                                    Dirección de correo electrónico del contacto principal de la empresa. Puede ser
                                    distinto al correo del usuario que realiza la solicitud.
                                </div>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtEmailReq" runat="server"
                                    ClientIDMode="Static" ErrorMessage="La direcci&oacute;n de correo es obligatoria"
                                    ControlToValidate="txtEmail" CssClass="validator" ValidationGroup="2">La direcci&oacute;n de correo es obligatoria</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validator"
                                    ErrorMessage="Direcci&oacute;n de correo inválida" ValidationGroup="2">Direcci&oacute;n de correo inválida</asp:RegularExpressionValidator>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtWebsite" ID="lbltxtWebsite">Website</asp:Label>
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="tb" MaxLength="80"></asp:TextBox>
                                <div class="comments" id="txtWebsiteComment">
                                    Dirección del portal web de su empresa (URL).
                                </div>
                            </li>
                        </ul>
                        <h3>
                            Actividades de la Sociedad/Empresa</h3>
                        <ul>
                            <li>
                                <asp:CheckBoxList ID="cblActividades" runat="server" RepeatColumns="2" ClientIDMode="Static">
                                </asp:CheckBoxList>
                                <asp:Label ID="lblErrorActividades" runat="server" CssClass="validator" /><br />
                                <div class="comments" id="cblActividadesComment">
                                    Seleccione el tipo de actividad que mas se adecúa a la de la empresa. Puede seleccionar
                                    varias.
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtActividadDescripcion" ID="lbltxtActividadDescripcion">
                     Descripción del Negocio</asp:Label>
                                <asp:TextBox ID="txtActividadDescripcion" runat="server" CssClass="tb wideInput"
                                    Rows="4" TextMode="MultiLine"></asp:TextBox>
                                <div class="comments" id="txtActividadDescripcionComment">
                                    Descripción de la actividad a la que se dedica la sociedad/empresa.
                                </div>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtActividadDescripcionReq"
                                    runat="server" ClientIDMode="Static" ErrorMessage="Por favor proveer la actividad principal de su negocio"
                                    ControlToValidate="txtActividadDescripcion" CssClass="validator" ValidationGroup="2">Por favor proveer la actividad principal de su negocio</asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <label for="txtPrincipalesProductos" id="lbltxtPrincipalesProductos">
                                    Productos / Servicios</label>
                                <input type="text" id="txtPrincipalesProductos" class="tb shortInput" />
                                <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfProductos" />
                                <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfCantidadProductos" />
                                <div class="comments" id="txtPrincipalesProductosComment">
                                    Liste los principales productos o servicios que oferta la sociedad/empresa. Separe
                                    cada una utilizando una coma.
                                </div>
                                <asp:Label runat="server" ID="txtPrincipalesProductosReq" CssClass="validator">
                            </asp:Label>
                            </li>
                            <li>
                                <div class="footer_go">
                                    <asp:Button ID="btnDatosGeneralesLlenos" runat="server" Text="Siguiente Paso" OnClick="btnDatosGeneralesLlenos_Click"
                                        ValidationGroup="2" CssClass="btn" ClientIDMode="Static" />
                                </div>
                            </li>
                            <li>
                                <asp:ValidationSummary runat="server" ID="vsSummary" ValidationGroup="2" CssClass="validator" />
                            </li>
                        </ul>
                    </fieldset>
                </div>
                <div class="clear" />
            </div>
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
