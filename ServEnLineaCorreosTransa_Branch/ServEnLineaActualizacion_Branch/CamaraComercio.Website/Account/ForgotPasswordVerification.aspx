<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ForgotPasswordVerification.aspx.cs" Inherits="CamaraComercio.Website.Account.ForgotPasswordVerification" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var validateSession = false;
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    Verificación de cambio de contraseña</h1>
            </div>
            <div id="content_body">
                <asp:MultiView ID="multiView" runat="server" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vChangePassword">
                        <h1>
                            Ingrese su nueva contraseña</h1>
                        <fieldset class="form-fieldset">
                            <ul>
                                <li>
                                    <label for="lblUsuario">
                                        Usuario:</label>
                                    <asp:Label ID="lblUsuario" runat="server" ClientIDMode="Static" Text="N/A" CssClass="inputField"></asp:Label>
                                </li>
                                <li>
                                    <label for="txtPassword">
                                        Contraseña:</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputField" TextMode="Password"
                                        ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ControlToValidate="txtPassword"
                                        Text="*" ErrorMessage="El campo Contraseña debe tener un valor." ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="La contraseña debe tener al menos 8 caracteres,  una mayúscula una minúscula y un dígito."
                                        ControlToValidate="txtPassword" ForeColor="Red" Text="*" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" />
                                </li>
                                <li>
                                    <label for="txtPasswordConf">
                                        Confirmar contraseña:</label>
                                    <asp:TextBox ID="txtPasswordConf" runat="server" CssClass="inputField" TextMode="Password"
                                        ClientIDMode="Static" />
                                    <asp:RequiredFieldValidator ID="rfvPasswordConf" runat="server" ForeColor="Red" Display="Dynamic"
                                        ControlToValidate="txtPasswordConf" Text="*" ErrorMessage="El campo Confirmar Contraseña debe tener un valor." />
                                    <asp:CompareValidator ID="cvPasswordConf" runat="server" ErrorMessage="Las contraseñas no coinciden."
                                        ForeColor="Red" ControlToValidate="txtPasswordConf" Operator="Equal" Text="*"
                                        ControlToCompare="txtPassword" />
                                </li>
                                <li>
                                    <label>
                                    </label>
                                    <asp:Button ID="btnSave" runat="server" Text="Cambiar Contraseña" CssClass="inputButton btn"
                                        OnClick="btnSave_Click" ClientIDMode="Static" />
                                </li>
                            </ul>
                        </fieldset>
                        <asp:ValidationSummary ID="vSummary" runat="server" CssClass="validator" Display="Dynamic"/>
                    </asp:View>
                    <asp:View runat="server" ID="vPasswordChanged">
                        <p>
                            Su contraseña ha sido cambiada exitosamente. Haga click en el siguiente link para
                            ingresar al sistema. <a href="Login.aspx">Ingresar al sistema</a></p>
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
