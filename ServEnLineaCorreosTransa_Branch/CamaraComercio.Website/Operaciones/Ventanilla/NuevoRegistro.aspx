<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="NuevoRegistro.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Ventanilla.NuevoRegistro"
    ClientIDMode="Static" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ManejoSocios.ascx" TagName="ManejoSocios" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ReCaptchaHelper.ascx" TagName="ReCaptchaHelper"
    TagPrefix="uc2" %>

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
            $('#liNuevoRegistro').addClass("active");
        });
    </script>
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
                        <li><a href="#">Datos de la Sociedad/Empresa</a></li>
                        <li><a href="#">Confirmación</a></li>
                        <li><a href="#">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>

                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="ddlCamaras" ID="lblddlCamaras">
					Provincia:
                            </asp:Label>
                            <asp:DropDownList ID="ddlCamaras" runat="server" Width="225px">
                            </asp:DropDownList>
                            <div class="comments" id="ddlCamarasComment">
                                <p>
                                    Camara donde se creará la empresa.
                                </p>
                            </div>
                        </li>
                        <li>
                            <asp:Label Text="Nombre o Razón Social" runat="server" AssociatedControlID="txtNombreNuevaSociedad"
                                ID="lbltxtNombreNuevaSociedad" />
                            <telerik:RadTextBox ID="txtNombreNuevaSociedad" runat="server" Skin="" CssClass="tb widestInput"
                                EmptyMessage="Nombre Compañía">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="txtNombreNuevaSociedadReq"
                                runat="server" ControlToValidate="txtNombreNuevaSociedad" CssClass="validator"
                                ValidationGroup="1">El nombre o razón social de la empresa es obligatorio</asp:RequiredFieldValidator>
                            <div class="comments" id="txtNombreNuevaSociedadComment">
                                <p>
                                    Nombre o Razón Social de la empresa.
                                </p>
                            </div>
                        </li>
                        <li>
                          <div class="footer_go">
                            <asp:Button ID="btnNuevoRegistroMercantil" runat="server" Text="Siguiente Paso" OnClick="btnNuevoRegistroMercantil_Click"
                                ValidationGroup="1" CssClass="btn" />
                                </div>
                        </li>
                    </ul>
                </fieldset>
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
