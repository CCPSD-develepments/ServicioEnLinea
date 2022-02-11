<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/res/nobox.master"
    AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CamaraComercio.Website.Account.ChangePassword" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_body">
              <div id="dashboard" style="width: 450px;">
                <div id="dashboard_header">
                    <h2>
                        Cambia tu Contraseña</h2>
                    <!--	<a href="#" id="rem">Registrar empresa nueva</a>
			        <a href="#" id="aee">Autorizar empresa existente</a>-->
                </div>
                <div id="dashboard_body">
                    <div class="centered">
                        <div>
                            <p>Recuerda que la contraseña debe tener al menos 8 caracteres,  
                            una mayúscula una minúscula y un dígito.</p>
                        </div>
                        <fieldset class="login-fieldset">
                            <div class="login-form">
                                <p class="field">
                                    <asp:Label ID="lblContraActual" runat="server" AssociatedControlID="txtOldPassword">Contraseña Actual</asp:Label>
                                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Enabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTxtOldPassword" runat="server" ControlToValidate="txtOldPassword"
                                        ForeColor="Red" CssClass="validator summary" ErrorMessage="El campo de contraseña actual es requerido."
                                        Display="None" ToolTip="La contraseña es requerida." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </p>
                                
                                <p class="field">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Nueva Contraseña</asp:Label>
                                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Enabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ForeColor="Red" CssClass="validator summary" ErrorMessage="El campo de contraseña es requerido."
                                        Display="None" ToolTip="La contraseña es requerida." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="Password"
                                        ErrorMessage="La contraseña debe tener al menos 8 caracteres,  una mayúscula una minúscula y un dígito."
                                        ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" Display="None" CssClass="validator summary"
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Repetir Contraseña</asp:Label>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Enabled"></asp:TextBox>
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ForeColor="Red" ControlToValidate="ConfirmPassword" CssClass="validator summary" Display="None"
                                        ErrorMessage="La contraseña y la confirmacion de contraseña deben ser iguales."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="validator summary" Display="None" ErrorMessage="El campo repertir contraseña es requerido."
                                        ToolTip="El campo repertir contraseña es requerido." 
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </p>
                            </div>
                            <div class="footer_go">
                                <asp:Button runat="server" ID="btnRegister" Text="Cambiar" CssClass="btn btnFormNext" 
                                    ValidationGroup="RegisterUserValidationGroup" 
                                    onclick="btnRegister_Click" />
                                <div class="clear" />
                            </div>
                        </fieldset>
                        <div class="clear" />
                    </div>
                    <div>
                        <asp:ValidationSummary ID="errorbox" ClientIDMode="Static"
                            runat="server" ValidationGroup="RegisterUserValidationGroup" />
                    </div>
                </div>
                <div class="clear" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
        <script type="text/javascript">
    
        $(document).ready(function () {
            //Menu
            $('#navigation li').removeClass("active");
            $('#liContrasena').addClass("active");

      
        });
</script>
</asp:Content>

