<%@ Page Title="Log In" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="LoginHansel.aspx.cs" Inherits="CamaraComercio.Website.Account.LoginHansel" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/res/css/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var validateSession = false;
        $(document).ready(function () {
            //Menu
            $('#subnavigation li').removeClass("active");

            $('#RememberMe').change(function () {
                var chkBox = $('#RememberMe');
                var hiddenDiv = $('#datosUsuarioLegal');
                hiddenDiv.removeClass("hiddenObj");

                if (chkBox[0].checked) {
                    hiddenDiv.show();
                    disableAspNEtValidator('rfvEmpresa', true);
                    disableAspNEtValidator('rfvRNC', true);
                }
                else {

                    hiddenDiv.hide();
                    disableAspNEtValidator('rfvEmpresa', false);
                    disableAspNEtValidator('rfvRNC', false);
                }

            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
            </div>
            <div id="content_body">
                <asp:Panel ID="pnlRegister" runat="server" DefaultButton="btnRegister">
                    <div class="loginbox floatRight">
                        <div>
                            <asp:ValidationSummary ID="vsRegister" runat="server" ValidationGroup="RegisterUserValidationGroup"
                                CssClass="valSummary" />
                        </div>
                        <div class="form-caption">
                            <h1>
                                Aún no posees una cuenta?</h1>
                            <p>
                                Registrate tu cuenta en pocos segundos</p>
                        </div>
                        <asp:Panel ID="pnlErrorRegister" runat="server" Visible="false" CssClass="validation denied">
                            Debes completar todos los campos marcados en rojo.
                        </asp:Panel>
                        <fieldset class="login-fieldset">
                            <div class="login-form">
                                <p class="field">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ForeColor="Red" CssClass="validator" ErrorMessage="El nombre de usuario es requerido."
                                        Display="Dynamic" ToolTip="Nombre de usuario requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserName"
                                        ForeColor="Red" ValidationGroup="RegisterUserValidationGroup" ErrorMessage="El campo usuario contiene valores no validos."
                                        ValidationExpression="^\D[0-9-a-zA-Z]*\.?[0-9-a-zA-Z]*[^.]$" CssClass="validator"
                                        Display="Dynamic" ClientIDMode="AutoID" ToolTip="El campo contiene caracteres invalidos">*</asp:RegularExpressionValidator>
                                    <asp:CustomValidator ID="cvUserName" runat="server" ForeColor="Red" Text="*" ControlToValidate="UserName"
                                        ErrorMessage="El nombre de usuario ya existe." ValidationGroup="RegisterUserValidationGroup"
                                        OnServerValidate="cvUserName_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ForeColor="Red" CssClass="validator" ErrorMessage="El campo Correo Electronico es requerido."
                                        Display="Dynamic" ToolTip="Correo electronico es requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email"
                                        ErrorMessage="Direccion de correo invalida" ToolTip="Direccion de correo invalida"
                                        ForeColor="Red" CssClass="validator" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    <asp:CustomValidator ID="CustomValidatorEmailDuplicado" runat="server" ControlToValidate="Email"
                                        ValidationGroup="RegisterUserValidationGroup" CssClass="validator" ForeColor="Red"
                                        Text="*" Display="Dynamic" ErrorMessage="La direccion de correo digitada ya existe. Por favor verifique y trate denuevo."
                                        OnServerValidate="CustomValidatorEmailDuplicado_ServerValidate"></asp:CustomValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Enabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ForeColor="Red" CssClass="validator" ErrorMessage="El campo password es requerido."
                                        Display="Dynamic" ToolTip="La contraseña es requerida." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="Password"
                                        ErrorMessage="La contraseña debe tener al menos 8 caracteres,  una mayúscula una minúscula y un dígito."
                                        ForeColor="Red" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$"
                                        ValidationGroup="RegisterUserValidationGroup" Display="Dynamic">*</asp:RegularExpressionValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Repetir Contraseña:</asp:Label>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Enabled"></asp:TextBox>
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ForeColor="Red" ControlToValidate="ConfirmPassword" CssClass="validator" Display="Dynamic"
                                        ErrorMessage="La contraseña y la confirmacion de contraseña deben ser iguales."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="validator" Display="Dynamic" ErrorMessage="El campo Password confirmacion es requerido."
                                        ForeColor="Red" ToolTip="El campo repertir contraseña es requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="lblTipoDocumento" runat="server" AssociatedControlID="ddlTipoDocumento">Tipo Documento:</asp:Label>
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="158px">
                                        <asp:ListItem Value="Cedula">Cédula</asp:ListItem>
                                        <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                                <p class="field">
                                    <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula">No. Documento:</asp:Label>
                                    <asp:TextBox ID="txtCedula" runat="server" MaxLength="13"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ClientIDMode="Static" ValidationGroup="RegisterUserValidationGroup"
                                        Text="*" Display="Dynamic" ControlToValidate="txtCedula" ForeColor="Red" ErrorMessage="Debe digitar el número de documento."></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="vcExisteCedula" runat="server" Text="*" ControlToValidate="txtCedula"
                                        ForeColor="Red" ErrorMessage="El no. de documento existe en el sistema." ValidationGroup="RegisterUserValidationGroup"
                                        OnServerValidate="vcExisteCedula_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="NombreCompletoLable" runat="server" AssociatedControlID="NombreCompletoTextBox">Nombre Completo:</asp:Label>
                                    <asp:TextBox ID="NombreCompletoTextBox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NombreCompletoTextBox"
                                        CssClass="validator" ErrorMessage="El campo nombre es requerido." ToolTip="El campo nombre es requerido."
                                        ForeColor="Red" ValidationGroup="RegisterUserValidationGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="NombreCompletoTextBox"
                                        ErrorMessage="El nombre contiene caracteres invalidos" ValidationExpression="^[a-zA-Z\s\.áéíóúÁÉÍÓÚñÑ]+$"
                                        ForeColor="Red" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>
                                </p>
                                <div class="clear">
                                </div>
                                <p class="rememberme">
                                    <asp:CheckBox ID="RememberMe" runat="server" ClientIDMode="Static" />
                                    <label for="RememberMe">
                                        Represento una oficina de abogados o dep. legal corporativo</label>
                                </p>
                                <div class="clear">
                                </div>
                                <br />
                                <div id="datosUsuarioLegal" class="hiddenObj">
                                    <p class="field">
                                        <asp:Label ID="lblNombreEmpresa" runat="server" AssociatedControlID="txtNombreEmpresa">Nombre de Empresa:</asp:Label>
                                        <asp:TextBox ID="txtNombreEmpresa" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ClientIDMode="Static"
                                            ForeColor="Red" ValidationGroup="RegisterUserValidationGroup" Text="*" ControlToValidate="txtNombreEmpresa"
                                            ErrorMessage="Debe digitar el nombre de la empresa."></asp:RequiredFieldValidator>
                                    </p>
                                    <p class="field">
                                        <asp:Label ID="lblNombreCompleto" runat="server" AssociatedControlID="txtNombreCompleto">RNC:</asp:Label>
                                        <asp:TextBox ID="txtNombreCompleto" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRNC" runat="server" ClientIDMode="Static" ValidationGroup="RegisterUserValidationGroup"
                                            Text="*" Display="Dynamic" ControlToValidate="txtNombreCompleto" ForeColor="Red"
                                            ErrorMessage="Debe digitar el RNC de la empresa."></asp:RequiredFieldValidator>
                                    </p>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                            <div class="form-footer">
                                <p class="submitButton">
                                    <asp:Button runat="server" ID="btnRegister" Text="Registrarse" CssClass="btn" ValidationGroup="RegisterUserValidationGroup"
                                        OnClick="btnRegister_Click" />
                                </p>
                                <div class="clear" />
                            </div>
                        </fieldset>
                    </div>
                </asp:Panel>
                <asp:Login ID="LoginUser" runat="server" EnableViewState="false" FailureText="Su intento de acceso no fue satisfactorio, por favor intente nuevamente."
                    PasswordRecoveryIconUrl="~/res/img/help.gif" PasswordRecoveryUrl="~/Account/ForgotPassword.aspx"
                    PasswordRecoveryText="¿Olvidó su contraseña? haga clic aquí." RenderOuterTable="False"
                    OnLoginError="LoginUser_LoginError" OnLoggingIn="LoginUser_LoggingIn" OnLoggedIn="LoginUser_LoggedIn">
                    <LayoutTemplate>
                        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="LoginButton">
                            <div class="loginbox" id="loginForm">
                                <div class="form-caption">
                                    <h1>
                                        ¿Ya estás registrado?</h1>
                                    <p>
                                        Accede al sistema usando tus credenciales</p>
                                </div>
                                <asp:Panel ID="pnlErrorLogin" runat="server" Visible="false" CssClass="validation denied">
                                    <asp:Label ID="lblMensajes" Text="Nombre de Usuario / Contraseña Inválidos" runat="server" />
                                </asp:Panel>
                                <fieldset class="login-fieldset">
                                    <div class="login-form">
                                        <p class="field">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" ValidationGroup="LoginUserValidationGroup"></asp:TextBox>
                                        </p>
                                        <p class="field">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"
                                                ValidationGroup="LoginUserValidationGroup"></asp:TextBox>
                                        </p>
                                        <p>
                                            <a href="ForgotPassword.aspx">¿Olvidó su contraseña?</a>
                                        </p>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <div class="form-footer">
                                        <p class="rememberme">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Recordarme en esta PC" />
                                        </p>
                                        <p class="submitButton">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar sesion"
                                                ValidationGroup="LoginUserValidationGroup" CssClass="btn" 
                                                onclick="LoginButton_Click" />
                                        </p>
                                        <p>
                                            <div class="clear" />
                                            <br />
                                            
                                            <p>
                                            </p>
                                            <div class="clear">
                                            </div>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                        </p>
                                    </div>
                                </fieldset>
                            </div>
                        </asp:Panel>
                    </LayoutTemplate>
                </asp:Login>
                <div class="clear" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
    <div class="clear" />
</asp:Content>
