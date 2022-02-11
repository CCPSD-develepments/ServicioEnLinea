<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ModReducionCapital.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.ModReducionCapital" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                    </span>Modificación de Empresa
                </h1>
            </div>
            <div id="content_body">
                <h2>
                    Por Reduccion De Capital Autorizado / Capital Social
                </h2>
                <h5>
                    Introduce la información correspondiente en cada campo y haz click sobre "Someter".
                    Si tienes alguna duda con un término visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                        Glosario de Términos</a>. <strong>Todo los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                <br />
                <fieldset class="form-fieldset widderField">
                    <ul>
                        <li>
                            <label>
                                Denominación/Razón Social</label>
                            <asp:Literal ID="ltNombreSociedad" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <label>
                                <asp:Label runat="server" ID="lblNombreCapitalSocial" Text="Capital Social Autorizado " />
                                Actual
                            </label>
                            <asp:Literal ID="ltCapAutorizado" runat="server"></asp:Literal>
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
                                CssClass="validator summary" ValidationGroup="3" Display="None" ClientIDMode="Static"
                                ControlToValidate="txtCapitalSocialNuevo" ErrorMessage="El campo de capital social autorizado es requerido." />
                            <asp:RangeValidator ID="rvCapitalSocialNuevo" runat="server" Type="Currency" MaximumValue="999999999.99"
                                CssClass="validator summary" ValidationGroup="3" Display="None" ClientIDMode="Static"
                                ControlToValidate="txtCapitalSocialNuevo" />
                            <asp:RangeValidator ID="rvCapitalSocialAnterior" runat="server" CssClass="validator summary"
                                Display="None" Type="Currency" ValidationGroup="3" ControlToValidate="txtCapitalSocialNuevo"
                                ClientIDMode="Static" ErrorMessage="El capital social debe ser menor al actual." />
                        </li>
                        <li></li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnEnviarModificacion" runat="server" Text="Someter" OnClick="btnEnviarModificacion_Click"
                                    ValidationGroup="3" CssClass="btn btnFormNext" TabIndex="2" /><div style="clear: both;">
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
