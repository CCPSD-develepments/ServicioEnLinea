<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ValidateUser.aspx.cs" Inherits="CamaraComercio.Website.Account.ValidateUser" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
            </div>
            <div id="content_body">
                <asp:MultiView ID="multiView" runat="server" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vChangePassword">
                        <asp:ValidationSummary ID="vSummary" runat="server" />
                        <br />
                        <fieldset>
                            <br />
                            <p>
                                Ingrese la contraseña deseada para activar su nuevo usuario.
                            </p>
                            <br />
                            <label for="lblUsuario">
                                Usuario:</label>
                            <asp:Label ID="lblUsuario" runat="server" Text="N/A" CssClass="inputField"></asp:Label>
                            <br />
                            <label for="txtPassword">
                                Contraseña:</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="inputField" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ControlToValidate="txtPassword"
                                Text="*" ErrorMessage="El campo Contraseña debe tener un valor."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Contraseña debe tener mínimo 6 caracteres."
                                ControlToValidate="txtPassword" ValidationExpression="^.{6,128}$">*</asp:RegularExpressionValidator>
                            <br />
                            <label for="txtPasswordConf">
                                Confirmar contraseña:</label>
                            <asp:TextBox ID="txtPasswordConf" runat="server" CssClass="inputField" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPasswordConf" runat="server" Display="Dynamic"
                                ControlToValidate="txtPasswordConf" Text="*" ErrorMessage="El campo Confirmar Contraseña debe tener un valor."></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPasswordConf" runat="server" ErrorMessage="Las contraseñas no coinciden."
                                ControlToValidate="txtPasswordConf" Operator="Equal" Text="*" ControlToCompare="txtPassword"></asp:CompareValidator>
                            <br />
                            <asp:Button ID="btnSave" runat="server" Text="Activar Usuario" CssClass="inputButton"
                                OnClick="btnSave_Click" />
                        </fieldset>
                    </asp:View>
                    <asp:View runat="server" ID="vPasswordChanged">
                        <p>
                            Su usuario ha sido activado exitosamente. Haga click en el siguiente link para ingresar
                            al sistema. <a href="Login.aspx">Ingresar al sistema</a></p>
                    </asp:View>
                    <asp:View runat="server" ID="vAccountActivatedAlready">
                        <p>
                            Su usuario había sido activado con anterioridad. Haga click en el siguiente link
                            para ingresar al sistema. <a href="Login.aspx">Ingresar al sistema</a></p>
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
