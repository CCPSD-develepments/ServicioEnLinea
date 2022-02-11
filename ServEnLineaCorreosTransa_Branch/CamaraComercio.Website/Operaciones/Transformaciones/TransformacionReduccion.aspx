<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="TransformacionReduccion.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Transformaciones.TransformacionReduccion" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                                AutoPostBack="true" OnSelectedIndexChanged="ddlTipoSociedadNueva_SelectedIndexChanged">
                            </asp:DropDownList>
                        </li>
                        <li>
                            <label>
                                Capital Social Autorizado</label>
                            <asp:Literal ID="ltCapAutorizado" runat="server"></asp:Literal></li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtCapitalSocialNuevo" ID="lbltxtCapitalSocialNuevo">Nuevo Capital Social Autorizado</asp:Label>
                            <telerik:RadNumericTextBox ID="txtCapitalSocialNuevo" runat="server" CssClass="tb"
                                Culture="Spanish (Dominican Republic)" EmptyMessage="Nuevo Capital" Type="Currency"
                                Width="200px" Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false">
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtCapitalSocialNuevo" CssClass="validator summary" ValidationGroup="3" Display="Static">El campo de capital social autorizado es requerido.</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvCapitalSocialNuevo" runat="server" Type="Currency" MaximumValue="9999999999.99" CssClass="validator summary" ValidationGroup="3" Display="Static" ControlToValidate="txtCapitalSocialNuevo">
                            El capital social minimo requerido para este tipo de sociedad es <%=String.Format("{0}", rvCapitalSocialNuevo.MinimumValue) %>
                            </asp:RangeValidator>
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
