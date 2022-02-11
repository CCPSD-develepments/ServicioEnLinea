<%@ Page Title="" Language="C#" MasterPageFile="~/res/Consulta_header.Master" AutoEventWireup="true"
    CodeBehind="ConsultaCERT.aspx.cs" Inherits="CamaraComercio.Website.ConsultaCERT" %>
<%@ MasterType VirtualPath="~/res/Consulta_header.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Client Scripts -->    
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.numeric').numeric();
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1 id="creacion">
                        <div class="color">
                        Consulta Certificación de Registro Mercantil
                            </div>
                    </h1>
                </div>
                <div id="content_body">
                    <h4>
                        Ingresa los datos relacionados a la certificación registro mercantil a consultar
                    </h4>
                    <fieldset>
                        <ul>
                            <li>
                                <label for="ddlCamara">
                                    Cámara de Comercio
                                </label>
                                <asp:DropDownList runat="server" ID="ddlCamara" ClientIDMode="Static" 
                                    CssClass="dd commentCtrlHov" Enabled="false" />
                                <div class="comments" id="ddlCamaraComment">
                                    Seleccione la cámara de comercio a la que pertenece el certificado de registro mercantil
                                    que desea consultar.
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="ddlCamaraReq" ControlToValidate="ddlCamara"
                                    Display="None" ErrorMessage="Debe seleccionar una cámara de comercio" CssClass="validator summary" />
                            </li>
                            <br />
                            <li>
                                <label for="txtNumeroCertificacion">
                                    Número de certificación de registro mercantil
                                </label>
                                <asp:TextBox runat="server" ID="txtNumeroCertificacion" ClientIDMode="Static" CssClass="tb commentCtrl numeric" />
                                <div class="comments" id="txtNumeroCertificacionComment">
                                    Ingrese el número de la certificación de registro mercantil. Ignore las letras y guiones,
                                    solo digite los campos numéricos.
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="txtNumeroCertificacionReq" ControlToValidate="txtNumeroCertificacion"
                                    Display="None" ErrorMessage="Debe especificar el número de certificación de registro mercantil."
                                    CssClass="validator summary" />
                            </li>
                            <br />
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtNumeroValidacion" ID="txtNumeroValidacionLbl">
                                    Número de validación
                                </asp:Label>
                                <telerik:RadMaskedTextBox runat="server" ID="txtNumeroValidacion" 
                                    CssClass="commentCtrl maskedTb" Mask="aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa" 
                                    CausesValidation="True" EnableEmbeddedSkins="False" PromptChar="_" 
                                    SelectionOnFocus="CaretToBeginning" Width="300px" />
                                
                                <div class="comments" id="MainContent_txtNumeroValidacion_textComment">
                                    Inserte el número de validación de la certificación de registro mercantil. Este número se encuentra localizado
                                    en la parte inferior de la certificación. Consta de 5 segmentos alfanuméricos separados por un guíon
                                    (Ej: E3535116-3B3D-453A-B690-1B4B4D82151E)
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="txtNumeroValidacionReq" ControlToValidate="txtNumeroValidacion"
                                    Display="None" ErrorMessage="Debe especificar el número de validación del registro mercantil."
                                    CssClass="validator summary" />
                            </li>
                            <br />
                            <li>
                                <div class="footer_go">
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btnFormNext"
                                        ClientIDMode="Static" onclick="btnConsultar_Click" />
                                    <div class="clear" />
                                </div>
                            </li>
                        </ul>
                    </fieldset>
                    <asp:ValidationSummary runat="server" ID="errorbox" 
                        HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                        CssClass="summary errorbox" Display="static" />
                    
                    <br />
                    <asp:Panel runat="server" ID="pnlResultados" Visible="False">
                        <fieldset>
                            <ul>
                                <li>
                                    <label>Razón Social</label>
                                    <asp:Literal runat="server" ID="litRazonSocial" />
                                </li>
                                <li>
                                    <label>Fecha de Emisión</label>
                                    <asp:Literal runat="server" ID="litFechaEmision" />
                                </li>
                                <li>
                                    <label>Fecha de Vencimiento</label>
                                    <asp:Literal runat="server" ID="litFechaVencimiento" />
                                </li>
                                <li>
                                    <asp:Literal runat="server" ID="litEstadoRm" />
                                </li>
                            </ul>
                        </fieldset>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
