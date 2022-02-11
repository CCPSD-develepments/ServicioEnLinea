<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ModDomicilioProv.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.ModDomicilioProv" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
             <h1 id="empresa">  <span class="right normal">
                      <asp:Literal ID="ltNombreSocial" runat="server"></asp:Literal></span>
                    Modificación de Empresa</h1>
            </div>
            <div id="content_body">
            <h2>Modificación de Domicilio</h2>
                    <h5>Introduce la información correspondiente en cada campo y haz click sobre "Someter". Si tienes alguna duda con un término visita nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">Glosario de Términos</a>. <strong>Los campos marcados con asteriscos (*) son obligatorios.</strong></h5><br />
                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <label for="txtDireccionEmpCalle">
                                Calle / No.</label>
                            <telerik:RadTextBox ID="txtDireccionEmpCalle" runat="server" CssClass="tb" Width="200px"
                                EmptyMessage="" Skin="" TabIndex="1" />
                            <telerik:RadTextBox ID="txtDireccionEmpNumero" runat="server" CssClass="tb" Width="60px"
                                EmptyMessage="" Skin="" TabIndex="2" />
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtDireccionEmpCalle" CssClass="validator summary" ValidationGroup="3" Display="Static"
                                ErrorMessage="El campo de la calle y el número del local de la empresa es obligatorio.">
                            </asp:RequiredFieldValidator>
                            <div class="comments" id="txtDireccionEmpCalleComment">
                                <p>
                                    Indica la calle o avenida donde ubicada la empresa.</p>
                            </div>
                            <div class="comments" id="txtDireccionEmpNumeroComment">
                                <p>
                                    Número del Local</p>
                            </div>
                        </li>
                        <li>
                            <label for="ddlCiudad">
                                Ciudad</label>
                            <asp:DropDownList ID="ddlCiudad" runat="server" Width="200px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged" CssClass="dd" 
                                TabIndex="3">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlCiudad"
                                CssClass="validator summary" ValidationGroup="3" Display="Static"
                                ErrorMessage="El campo de ciudad de la empresa es obligatorio.">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ddlCiudad"
                                ErrorMessage=" Selecciona la ciudad donde ubicada la empresa." ValidationExpression="^[1-9]+[0-9]*$"
                                CssClass="validator summary" ValidationGroup="3" Display="Static"></asp:RegularExpressionValidator>
                            <div class="comments" id="ddlMunicipioComment">
                                <p>
                                    Selecciona la ciudad donde ubicada la empresa.</p>
                            </div>
                        </li>
                        <li>
                            <label for="ddlSector">
                                Sector</label>
                            <asp:DropDownList ID="ddlSector" runat="server" Width="200px" CssClass="dd" 
                                TabIndex="4">
                            </asp:DropDownList>
                            <asp:Label ID="lblSectores" runat="server"></asp:Label>
                            <div class="comments" id="ddCiudadComment0">
                                <p>
                                    Selecciona el sector donde ubicada la empresa.
                                </p>
                            </div>
                        </li>
                        <li>
                            <label for="txtApartadoPostal">
                                Apartado Postal</label>
                            <asp:TextBox ID="txtApartadoPostal" runat="server" CssClass="tb" Width="200px" 
                                TabIndex="5"></asp:TextBox>
                            <div class="comments" id="txtApartadoPostalComment">
                                <p>
                                    Indica el apartado postal de la empresa. Este campo es opcional.</p>
                            </div>
                        </li>
                        <li>
                            <div class="footer_go"> 
                            <asp:Button ID="btnEnviarModificacion" runat="server" Text="Someter" OnClick="btnEnviarModificacion_Click"
                                ValidationGroup="3" CssClass="btn" TabIndex="6" />
                                </div>
                        </li>
                    </ul>
                </fieldset>
                 <asp:ValidationSummary runat="server" ID="errorbox" 
                    HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;" 
                        ValidationGroup="3" ClientIDMode="Static" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
