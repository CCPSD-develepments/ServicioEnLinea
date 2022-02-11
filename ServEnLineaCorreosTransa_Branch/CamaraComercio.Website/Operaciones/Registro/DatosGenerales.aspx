<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="DatosGenerales.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Registro.DatosGenerales"
    ClientIDMode="Static" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- CSS Styles -->
    <link href="/res/js/fbTextbox/TextboxList.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/fbTextbox/TextboxList.Autocomplete.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script type="text/javascript" src="/res/js/jquery.alphanumeric.js"></script>
    <script type="text/javascript" src="/res/js/jquery.fieldtag.js"></script>
    <script type="text/javascript" src="/res/js/jquery.maskedinput.js"></script>
    <script src="/res/js/fbTextbox/TextboxList.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/GrowingInput.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/TextboxList.Autocomplete.js" type="text/javascript"></script>
    <!-- Manejo del combo box multiple -->
    <script src="/res/js/fgMenu/fg.menu.js" type="text/javascript"></script>
    <link href="/res/js/fgMenu/fg.menu.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/fgMenu/theme/ui.all.css" rel="stylesheet" type="text/css" />
    <!-- User Scripts -->
    <script type="text/javascript" src="/res/js/ui.adecuacion.js"></script>
    <script type="text/javascript" src="/res/js/ui.datosgenerales.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //Objetos en el menu
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavCreacion').addClass("active");
            
            $("#txtActividadDescripcion").attr('maxlength', '250');
        });
    </script>
</asp:Content>

<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1 id="creacion">
                        <span class="right normal">
                            <asp:Label runat="server" ID="lblDenominacionSocialHeader" />,
                            <asp:Label runat="server" ID="lblTipoEmpresaHeader" />
                        </span>Creación de Empresa
                    </h1>
                </div>
                <div id="content_body">
                    <div class="stepsTl" id="stepsTl">
                        <ul>
                            <li><a href="#" class="stepDone">Solicitud</a></li>
                            <li><a href="#" class="stepLast">Datos Generales</a></li>
                            <li><a href="#">Datos de la Empresa</a></li>
                            <li><a href="#">Verificación</a></li>
                            <li><a href="#">Pago por Servicios</a></li>
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                    <fieldset class="form-fieldset">
                        <h2>
                            Datos Generales de la Empresa</h2>
                        <h5>
                            Estas a sólo minutos de completar la registración de tu empresa. Complete la información
                            de los datos generalos de la empresa y luego presiona el botón de "Siguiente". Si
                            tienes alguna duda con un término, visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/" target="_blank">
                                Glosario de Términos</a>. <strong>Los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                        <asp:Panel runat="server" ID="pnlNacionalidad" Visible="false">
                            <asp:Literal runat="server" ID="litTipoRegistroHeader" Text="<h3>Tipo de Registro</h3>" />
                            <ul>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="lblTipoEmpresaActual" ID="lblLblTipoEmpresaActual">
                                Tipo de Empresa (actual) 
                            </asp:Label>
                                    <asp:Label ID="lblTipoEmpresaActual" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="ddlPais" ID="lblddlPais">Nacionalidad</asp:Label>
                                    <asp:DropDownList ID="ddlPais" runat="server" CssClass="dd commentCtrl" ClientIDMode="Static">
                                    </asp:DropDownList>
                                    <div class="comments" id="ddlPaisComment">
                                        Nacionalidad de la Empresa
                                    </div>
                                    <asp:RegularExpressionValidator ID="ddlPaisReqex" runat="server" ControlToValidate="ddlPais"
                                        Display="None" ErrorMessage="Selecciona un país valido. Favor de insertarlo e intentarlo nuevamente."
                                        ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="2" 
                                        CssClass="validator summary">Selecciona un país valido. Favor de insertarlo e intentarlo nuevamente.</asp:RegularExpressionValidator>
                                    <asp:HiddenField runat="server" ID="hfEmpresasExtranjeras" />
                                    <asp:HiddenField runat="server" ID="hfPaisIdRepDominicana" />
                                </li>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="lblFechaEmision" ID="lbllblFechaEmision">Fecha de Emisión</asp:Label>
                                    <asp:Label ID="lblFechaEmision" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="lbllblFechaVencimiento" AssociatedControlID="lblFechaVencimiento">Fecha de Vencimiento</asp:Label>
                                    <asp:Label ID="lblFechaVencimiento" runat="server"></asp:Label>
                                    <asp:Panel ID="pnlRenovacionVencida" runat="server" CssClass="warnings" Visible="False">
                                        <span style="color: #FF0000">El registro mercantil actual de la empresa ha vencido.</span>
                                        Se incluirá el costo de renovaci&oacute;n junto con las modificaciones solicitadas.</asp:Panel>
                                </li>
                            </ul>
                        </asp:Panel>
                        <h3>
                            Dirección Comercial</h3>
                        <ul>
                            <li>
                                <asp:Label ID="lbltxtDireccionEmpCalle" runat="server" AssociatedControlID="txtDireccionEmpCalle">Calle / No. <span class="required">*</span>
</asp:Label>
                                <telerik:RadTextBox ID="txtDireccionEmpCalle" runat="server" CssClass="tb commentCtrl"
                                    EmptyMessage="Calle" Skin="" />
                                <telerik:RadTextBox ID="txtDireccionEmpNumero" runat="server" CssClass="tb commentCtrl"
                                    Width="60px" EmptyMessage="No." Skin="" />
                                <div class="comments" id="txtDireccionEmpCalle_textComment">
                                    Indica la calle o avenida donde ubicada la empresa.</div>
                                <div class="comments" id="txtDireccionEmpNumero_textComment">
                                    Indica el número del local donde ubica la empresa.
                                </div>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtDireccionEmpCalleReq" runat="server"
                                    Display="None" ClientIDMode="Static" ControlToValidate="txtDireccionEmpCalle"
                                    CssClass="validator summary" ValidationGroup="2" 
                                    ErrorMessage="El campo de la calle y el número del local de la empresa es obligatorio. ">El campo de la calle y el número del local de la empresa es obligatorio. 
                                </asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddlCiudad" ID="lblddlCiudad">Ciudad <span class="required">*</span>
</asp:Label>
                                <asp:DropDownList ID="ddlCiudad" runat="server" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged"
                                    CssClass="dd commentCtrl" AutoPostBack="True" ClientIDMode="Static">
                                </asp:DropDownList>
                                <div class="comments" id="ddlCiudadComment">
                                    Selecciona la ciudad donde ubicada la empresa.
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddlSector" ID="lblddlSector">Sector <span class="required">*</span>
</asp:Label>
                                <asp:DropDownList ID="ddlSector" runat="server" CssClass="dd commentCtrl" ClientIDMode="Static">
                                </asp:DropDownList>
                                <div class="comments" id="ddlSectorComment">
                                    Selecciona el sector donde ubicada la empresa.
                                </div>
                                <asp:Label ID="lblSectores" runat="server" Text="No Aplica" Visible="False"></asp:Label>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtApartadoPostal" ID="lbltxtApartadoPostal">Apartado Portal</asp:Label>
                                <asp:TextBox ID="txtApartadoPostal" runat="server" 
                                    CssClass="tb commentCtrl" ClientIdMode="Static" />
                                <div class="comments" id="txtApartadoPostalComment">
                                    Indica el apartado postal de la empresa. Este campo es opcional.</div>
                            </li>
                        </ul>
                        <h3>
                            Otras Informaciones</h3>
                        <ul>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtTelefonoPrimario" ID="lbltxtTelefonoPrimario">Teléfono Primario <span class="required">*</span>
</asp:Label>
                                <asp:TextBox ID="txtTelefonoPrimario" runat="server" CssClass="tb inputTelefonoPrimario commentCtrl"></asp:TextBox>
                                &nbsp;
                                <telerik:RadTextBox ID="txtTelefonoPrimarioExtension" runat="server" CssClass="tb"
                                    EmptyMessage="Ext." Skin="" Width="60px" MaxLength="4" />
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtTelefonoPrimarioReq" runat="server"
                                    Display="None" ClientIDMode="Static" ErrorMessage="El campo del teléfono primario de la empresa es obligatorio. "
                                    ControlToValidate="txtTelefonoPrimario" CssClass="validator summary" 
                                    ValidationGroup="2"></asp:RequiredFieldValidator>
                                <div class="comments" id="txtTelefonoPrimarioComment">
                                    Ingresa el teléfono primario de la empresa. Utiliza el teléfono más utilizado en la empresa y recuerda incluir el código de área de su teléfono. No utilices espacios ni guiónes. <strong>La extención es opcional.</strong>
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtTelefonoSecundario" ID="lbltxtTelefonoSecundario">Teléfono Secundario</asp:Label>
                                <asp:TextBox ID="txtTelefonoSecundario" runat="server" CssClass="tb inputTelefonoSecundario commentCtrl"></asp:TextBox>&nbsp;
                                <telerik:RadTextBox ID="txtTelefonoSecundarioExtension" runat="server" AutoPostBack="True"
                                    CssClass="tb" EmptyMessage="Ext." Skin="" Width="60px" MaxLength="4" />
                                <div class="comments" id="txtTelefonoSecundarioComment">
                                    Ingresa un teléfono alternativo ó secundario de la empresa. Este campo es opcional. <strong>La extención es opcional.</strong>
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtFax" ID="lbltxtFax">Fax</asp:Label>
                                <asp:TextBox ID="txtFax" runat="server" CssClass="tb inputFax commentCtrl"></asp:TextBox>
                                <div class="comments" id="txtFaxComment">
                                    Ingresa un número de fax de la empresa. Este campo es opcional.
                                </div>
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtEmail" ID="lbltxtEmail">Correo Electrónico <span class="required">*</span>
</asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="tb commentCtrl"></asp:TextBox>
                                <div class="comments" id="txtEmailComment">
                                    Ingresa el correo electrónico de la empresa. El correo puede ser distinto al correo
                                    del usuario y sugerimos que utilices el correo electrónico más utilizado de la empresa.
                                </div>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtEmailReq" runat="server"
                                    Display="None" ClientIDMode="Static" 
                                    ErrorMessage="El campo de direcci&oacute;n de correo electrónico es obligatoria."
                                    ControlToValidate="txtEmail" CssClass="validator summary" 
                                    ValidationGroup="2" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    CssClass="validator summary" ErrorMessage="La direcci&oacute;n de correo electrónico es inválida."
                                    ValidationGroup="2" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtWebsite" ID="lbltxtWebsite">Website</asp:Label>
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="tb commentCtrl" MaxLength="80"></asp:TextBox>
                                <div class="comments" id="txtWebsiteComment">
                                    Indica la dirección del sitio web de la empresa.
                                </div>
                            </li>
                        </ul>
                        <h3>
                            Actividades de la Empresa</h3>
                        <ul>
                            <li id="liActividades">
                                <label for="btnActividades">
                                    Actividades <span class="required">*</span>
                                </label>
                                <input type="text" id="txtActividades" />
                                <input type="button" id="btnActividades" value="+"/>
                                <asp:HiddenField runat="server" ID="hfActividades" ClientIDMode="Static" />
                                <asp:HiddenField runat="server" ID="hfActividadesCantidad" ClientIDMode="Static" />
                                <div class="comments" id="txtActividadesComment">
                                    Comienza a escribir y seleciona una de las opciones de la lista o selecciona una
                                    opción haciendo clic en "+". sobre el botón para seleccionar una actividad de la
                                    lista.
                                </div>
                                <asp:CustomValidator runat="server" ID="cvalActividades" Display="None"
                                ClientIDMode="Static" CssClass="validator summary" ValidationGroup="2"
                                ErrorMessage="Debe seleccionar por lo menos una actividad/industria" 
                                    ClientValidationFunction="ValidateActividades" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtActividadDescripcion" ID="lbltxtActividadDescripcion">
                     Objeto de la Empresa <span class="required">*</span>
</asp:Label>
                                <asp:TextBox ID="txtActividadDescripcion" runat="server" CssClass="tb wideInput commentCtrl"
                                    Rows="4" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                <div class="comments" id="txtActividadDescripcionComment">
                                    Escribe una descripción de la actividad a la que se dedica la empresa, usando el
                                    objeto que aparece en sus Estatutos o Acto Constituvo. Este campo permite un máximo
                                    de 250 caracteres.
                                </div>
                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtActividadDescripcionReq"
                                    Display="None" runat="server" ClientIDMode="Static" ErrorMessage="El campo de actividades de la empresa es obligatorio. "
                                    ControlToValidate="txtActividadDescripcion" CssClass="validator summary" 
                                    ValidationGroup="2">
                                El campo de actividades de la empresa es obligatorio. 
                            </asp:RequiredFieldValidator>
                            </li>
                            <li id="liProductos">
                                <label for="txtPrincipalesProductos" id="lbltxtPrincipalesProductos">
                                    Productos/Servicios <span class="required">*</span>
                                </label>
                                <input type="text" id="txtPrincipalesProductos" class="tb shortInput commentCtrl" />
                                <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfProductos" />
                                <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfCantidadProductos" />
                                <div class="comments" id="txtPrincipalesProductosComment">
                                    Escribe los productos y/o servicios que ofrece su empresa separados por coma. Ej:
                                    Servicios Legales, Ferretería, Carteras...
                                </div>
                                <asp:CustomValidator runat="server" ID="cvalProductos" ClientIDMode="Static"
                                Display="None" CssClass="validator summary" ValidationGroup="2"
                                ErrorMessage="Debe ingresar por lo menos un producto" 
                                    ClientValidationFunction="ValidateProductos" />
                            </li>
                            <li>
                                <div class="footer_go">
                                    <asp:Button ID="btnDatosGeneralesLlenos" runat="server" 
                                        Text="Siguiente" OnClick="btnDatosGeneralesLlenos_Click"
                                        ValidationGroup="2" CssClass="btn btnFormNext" ClientIDMode="Static" />
                                    <div style="clear: both;">
                                    </div>
                                </div>
                            </li>
                        </ul>
                        <asp:ValidationSummary runat="server" ID="errorbox" 
                        HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                            ValidationGroup="2" CssClass="summary" />
                    </fieldset>
                </div>
                <div class="clear" />
            </div>
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
