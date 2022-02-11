<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="NuevoRegistro.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Registro.NuevoRegistro"
    ClientIDMode="Static" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ManejoSocios.ascx" TagName="ManejoSocios" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc3" %>
<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Plugins -->
    <script type="text/javascript" language="javascript" src="/res/js/jquery.alphanumeric.js"></script>
    <script type="text/javascript" language="javascript" src="/res/js/jquery.fieldtag.js"></script>
    <script type="text/javascript" language="javascript" src="/res/js/jquery.maskedinput.js"></script>
    <!-- Referencia para el js que maneja el UX de este form -->
    <script type="text/javascript" language="javascript" src="/res/js/ui.adecuacion.js"></script>
    <!--Objetos en el menu-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavCreacion').addClass("active");

            $("#pSociedadComment").show();
            $("#pPersonaComment").hide();

            //Si se escoge persona fisica del Dropdown se cambia el label de la denominación social
            $('#ddAdecuacion').change(function () {
                var tipoEmpresa = $('#ddAdecuacion :selected').text();
                if (tipoEmpresa == "Personas Fisicas") {
                    $("#lbltxtNombreNuevaSociedad").text("Nombre");
                    $("#pSociedadComment").hide();
                    $("#pPersonaComment").show();
                }
                else {
                    $("#lbltxtNombreNuevaSociedad").text("Denominación/Razón Social");
                    $("#pSociedadComment").show();
                    $("#pPersonaComment").hide();
                }
            });
            

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
            <div id="content_header">
                <h1 id="creacion">
                    Creación de Empresas
                </h1>
            </div>
            <div id="content_body">
                <div class="stepsTl" id="stepsTl">
                    <ul>
                        <li><a href="#" class="stepLast">Solicitud</a></li>
                        <li><a href="#">Datos Generales</a></li>
                        <li><a href="#">Datos de la Empresa</a></li>
                        <li><a href="#">Verificación</a></li>
                        <li><a href="#">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <h5>
                    Introduce la información correspondiente en cada campo y haz click sobre "Siguiente".
                    Si tienes alguna duda con un término visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                Glosario de Términos</a>. <strong>Los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                        <br />
                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="ddlCamaras" ID="lblddlCamaras">
					Cámara
                            </asp:Label>
                            <asp:DropDownList ID="ddlCamaras" runat="server" Width="225px" CssClass="commentCtrl">
                            </asp:DropDownList>
                            <div class="comments" id="ddlCamarasComment">
                                <p>
                                    Selecciona la provincia donde esté domiciliada tu empresa. Esto va determinar en
                                    qué cámara de comercio se registrará su empresa.
                                </p>
                            </div>
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="ddAdecuacion" ID="lblddAdecuacion">TIipo Societario</asp:Label>
                            <asp:DropDownList ID="ddAdecuacion" runat="server" Width="225px" CssClass="commentCtrl"
                                ClientIDMode="Static" />
                            <div class="comments" id="ddAdecuacionComment">
                                Selecciona el tipo de societario de tu empresa. Para más información
                                visita la tabla de <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/modulos-societarios/" target="_blank">Tipos Societarios</a>.
                            </div>
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtNombreNuevaSociedad" ID="lbltxtNombreNuevaSociedad"
                                ClientIDMode="Static">
                                   Denominación/Razón Social <span class="required">*</span>
                                </asp:Label>
                            <telerik:RadTextBox ID="txtNombreNuevaSociedad" runat="server" Skin="" CssClass="tb widestInput commentCtrl"
                                EmptyMessage="Nombre de Empresa" ClientIDMode="Static">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtNombreNuevaSociedadReq"
                                runat="server" ControlToValidate="txtNombreNuevaSociedad" CssClass="validator summary"
                                ValidationGroup="1" Display="None" 
                                ErrorMessage="La denominación o razón social de la empresa es obligatorio."></asp:RequiredFieldValidator>
                            <div class="comments" id="txtNombreNuevaSociedad_textComment">
                                <p id="pSociedadComment">
                                    Indica el nombre de su empresa sin las siglas del tipo societario. Ej (1): Paraíso
                                    del Mar, Ej (2) <span style="text-decoration: line-through">Paraíso del Mar, S.A.</span>
                                </p>
                                <p id="pPersonaComment">
                                    Ingresa tu nombre completo.
                                </p>
                            </div>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnNuevoRegistroMercantil" runat="server" Text="Siguiente" OnClick="btnNuevoRegistroMercantil_Click"
                                    ValidationGroup="1" CssClass="btn btnFormNext" ClientIDMode="Static" /><div style="clear: both;">
                                    </div>
                            </div>
                        </li>
                    </ul>
                </fieldset>
                <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                        ValidationGroup="1" ClientIDMode="Static" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
