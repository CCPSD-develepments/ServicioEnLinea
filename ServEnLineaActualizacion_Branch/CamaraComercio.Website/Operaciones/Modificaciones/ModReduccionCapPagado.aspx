﻿<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ModReduccionCapPagado.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.ModReduccionCapPagado" %>

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
                    </span>Modificación de Empresa</h1>
            </div>
            <div id="content_body">
                <h2>
                    Por Reduccion De Capital Suscrito Y Pagado</h2>
                <h5>
                    Introduce la información correspondiente en cada campo y haz click sobre "Someter".
                    Si tienes alguna duda con un término visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                        Glosario de Términos</a>. <strong>Todo los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                <br />
                <fieldset class="form-fieldset widderField">
                    <ul>
                        <li>
                            <label for="ltNombreSocial">
                                Denominación/Razón Social</label>
                            <asp:Label ID="ltNombreSocial" runat="server" ClientIDMode="Static" />
                        </li>
                        <li>
                            <label>
                                <asp:Label runat="server" Text="Capital Suscrito y Pagado " ID="lblCapitalSuscritoNombre" />
                                Actual
                            </label>
                            <asp:Label ID="ltCapitalPagado" runat="server" ClientIDMode="Static" />
                        </li>
                        <li>
                            <label for="txtCapPagado">
                                Nuevo
                                <asp:Label runat="server" Text="Capital Suscrito y Pagado" ID="lblCapitalSuscritoNuevoNombre" />
                            </label>
                            <telerik:RadNumericTextBox ID="txtCapPagado" runat="server" CssClass="tb commentCtrl"
                                Culture="Spanish (Dominican Republic)" ClientIDMode="Static" Type="Currency"
                                Width="200px" Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false"
                                TabIndex="1">
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqCapPagado" runat="server"
                                ControlToValidate="txtCapPagado" CssClass="validator summary" Display="None"
                                ErrorMessage="El campo de capital suscrito es requerido."></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvCapitalSocialNuevo" runat="server" CssClass="validator summary"
                                Display="None" Type="Currency" MaximumValue="9999999999.99" ControlToValidate="txtCapPagado" />
                            <asp:RangeValidator ID="rvCapitalSocialAnterior" runat="server" CssClass="validator summary"
                                Display="None" Type="Currency" ControlToValidate="txtCapPagado" MinimumValue="0.00" />
                            <asp:RangeValidator ID="rvCapitalSocialComp" runat="server" CssClass="validator summary"
                                Display="None" Type="Currency" ControlToValidate="txtCapPagado" MinimumValue="0.00" />
                            <div class="comments" id="txtCapPagado_textComment">
                                
                                Ingresa el capital suscrito de la empresa. 
                                <asp:Literal runat="server" ID="litCapPagadoComment" Text="
                                El capital suscrito mínimo es el 10% del capital social autorizado. 
                                " Visible="False"></asp:Literal>
                                Para más información visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                Glosario de Términos</a>.
                                
                            </div>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnEnviarModificacion" runat="server" Text="Someter" OnClick="btnEnviarModificacion_Click"
                                    CssClass="btn btnFormNext" TabIndex="2" />
                                <div class="clear" />
                            </div>
                        </li>
                    </ul>
                </fieldset>
                <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                    ClientIDMode="Static" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
