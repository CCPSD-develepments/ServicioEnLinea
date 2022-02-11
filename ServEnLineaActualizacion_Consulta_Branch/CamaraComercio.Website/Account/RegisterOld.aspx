<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="RegisterOld.aspx.cs" Inherits="CamaraComercio.Website.Account.Register" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>

<asp:Content ID="headContents" ContentPlaceHolderID="HeadContent" runat="server">
    
    <link href="/res/css/login.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/tipsy/tipsy.css" rel="stylesheet" type="text/css" />

    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
    <script src="/res/js/jquery.maskedinput.js" type="text/javascript" ></script>
    <script src="/res/js/tipsy/jquery.tipsy.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            //Formato para telefonos
            $('#txtTelefono').mask('(999) 999-9999')


            //Reformateo del CAPTCHA
            $('#recaptcha_logo').hide();
            $('#recaptcha_tagline').hide();
            $('#recaptcha_switch_audio_btn').click(function () {
                $('.recaptcha_audio_cant_hear_link:eq(0)').text("Reproducir nuevamente");
                $('.recaptcha_audio_cant_hear_link:eq(1)').text("Descargar como MP3");
            });
            
            //Quitando los tab stops del captcha
            $('#recaptcha_table a').each(function () { this.tabIndex = -1 });

            //Ayuda y comentarios de campos
            $(".tipsyBox").tipsy({ trigger: 'focus', gravity: 'w', opacity: 0.8 });
            $(".tipsyBoxLeft").tipsy({ trigger: 'focus', gravity: 'e', opacity: 0.8 });
        });
    </script>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
            </div>
            <div id="dashboard" style="width: 450px;">
                <div id="dashboard_header">
                    <h2>
                        Inscríbete</h2>
                    <!--	<a href="#" id="rem">Registrar empresa nueva</a>
			        <a href="#" id="aee">Autorizar empresa existente</a>-->
                </div>
                <div id="dashboard_body">
                    <div class="centered">
                        <div>
                            <h2>
                                ¿Aún no has creado una cuenta?</h2>
                            <p>
                                Registra tu cuenta en pocos segundos.</p>
                        </div>
                        <fieldset class="login-fieldset">
                            <div class="login-form">
                                <p class="field">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario</asp:Label>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="commentCtrl tipsyBox" 
                                        original-title="Nombre del usuario. Debe ser único" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="validator summary" ErrorMessage="El nombre de usuario es requerido."
                                        Display="None" ToolTip="Nombre de usuario requerido." ClientIDMode="Static" ValidationGroup="RegisterUserValidationGroup">*
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserName"
                                        ValidationGroup="RegisterUserValidationGroup" ErrorMessage="El campo usuario no puede tener espacios, números, ni caracteres especiales."
                                        ValidationExpression="^\D[0-9-a-zA-Z]*\.?[0-9-a-zA-Z]*[^.]$" CssClass="validator summary"
                                        Display="None" ClientIDMode="AutoID" ToolTip="El campo contiene caracteres invalidos">*</asp:RegularExpressionValidator>
                                    <asp:CustomValidator ID="cvUserName" runat="server" Text="*" ControlToValidate="UserName"
                                        ErrorMessage="El nombre de usuario ya existe." ValidationGroup="RegisterUserValidationGroup"
                                        OnServerValidate="cvUserName_ServerValidate" Display="None" CssClass="validator"></asp:CustomValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry tipsyBox" original-title="Correo electrónico del usuario."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        CssClass="validator summary" ErrorMessage="El campo Correo Electronico es requerido."
                                        Display="None" ToolTip="Correo electronico es requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email"
                                        ErrorMessage="Direccion de correo invalida" ToolTip="Direccion de correo invalida"
                                        CssClass="validator summary" Display="None" ValidationGroup="RegisterUserValidationGroup"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    <asp:CustomValidator ID="CustomValidatorEmailDuplicado" runat="server" ControlToValidate="Email"
                                        ValidationGroup="RegisterUserValidationGroup" CssClass="validator summary" Text="*"
                                        Display="None" ErrorMessage="La dirección de correo digitada ya existe. Por favor verifique y trate de nuevo."
                                        OnServerValidate="CustomValidatorEmailDuplicado_ServerValidate"></asp:CustomValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry tipsyBox" TextMode="Password"
                                        ViewStateMode="Enabled" 
                                        original-title="Contraseña. Debe tener al menos 8 caracteres, una mayúscula, una minúscula y un dígito" 
                                        MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ForeColor="Red" CssClass="validator summary" ErrorMessage="El campo de contraseña es requerido."
                                        Display="None" ToolTip="La contraseña es requerida." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="Password"
                                        ErrorMessage="La contraseña debe tener al menos 8 caracteres,  una mayúscula una minúscula y un dígito."
                                        ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" Display="None"
                                        CssClass="validator summary" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Repetir Contraseña</asp:Label>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                                        ViewStateMode="Enabled" MaxLength="15"></asp:TextBox>
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ForeColor="Red" ControlToValidate="ConfirmPassword" CssClass="validator summary"
                                        Display="None" ErrorMessage="La contraseña y la confirmacion de contraseña deben ser iguales."
                                        ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="validator summary" Display="None" ErrorMessage="El campo repertir contraseña es requerido."
                                        ToolTip="El campo repertir contraseña es requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="lblTipoDocumento" runat="server" AssociatedControlID="ddlTipoDocumento">Tipo Documento</asp:Label>
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="158px" CssClass="tipsyBox" original-title="Tipo de documento">
                                        <asp:ListItem Value="Cedula">Cédula</asp:ListItem>
                                        <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                                <p class="field">
                                    <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula">No. Documento</asp:Label>
                                    <asp:TextBox ID="txtCedula" runat="server" MaxLength="13" CssClass="tipsyBox" original-title="Número del documento. Escribir sin espacios ni guiones." />
                                    <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ClientIDMode="Static" ValidationGroup="RegisterUserValidationGroup"
                                        CssClass="validator summary" Text="*" Display="None" ControlToValidate="txtCedula"
                                        ErrorMessage="Debe digitar el número de documento."></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="vcExisteCedula" runat="server" Text="*" ControlToValidate="txtCedula"
                                        ErrorMessage="El no. de documento existe en el sistema." ValidationGroup="RegisterUserValidationGroup"
                                        OnServerValidate="vcExisteCedula_ServerValidate" Display="None" CssClass="validator summary"></asp:CustomValidator>
                                    <asp:CustomValidator ID="vcTipoCedula" runat="server" Text="*" ControlToValidate="txtCedula"
                                        ErrorMessage="El número de cédula no debe contener guiones." CssClass="validator summary"
                                        ValidationGroup="RegisterUserValidationGroup" OnServerValidate="vcTipoCedula_ServerValidate"
                                        Display="None"></asp:CustomValidator>
                                </p>
                                <p class="field">
                                    <asp:Label ID="NombreCompletoLable" runat="server" AssociatedControlID="NombreCompletoTextBox">Nombre Completo</asp:Label>
                                    <asp:TextBox ID="NombreCompletoTextBox" runat="server" cssclass="tipsyBox" 
                                        original-title="Nombres y apellidos del usuario." MaxLength="180"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NombreCompletoTextBox"
                                        CssClass="validator summary" ErrorMessage="El campo nombre es requerido." ToolTip="El campo nombre es requerido."
                                        ValidationGroup="RegisterUserValidationGroup" Display="None">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="NombreCompletoTextBox"
                                        ErrorMessage="El nombre contiene caracteres invalidos" ValidationExpression="^[a-zA-Z\s\.áéíóúÁÉÍÓÚñÑ]+$"
                                        CssClass="validator summary" Display="None" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>
                                </p>
                                <p class="field">
                                    <asp:Label runat="server" AssociatedControlID="txtTelefono" ID="lblTelefonoTIt">Teléfono de Contacto</asp:Label>
                                    <asp:TextBox runat="server" ID="txtTelefono" ClientIDMode="Static" CssClass="tipsyBox" original-title="No. de teléfono de contacto (opcional)"/>
                                </p>
                                
                                <br />
                                <div id="datosUsuarioLegal">
                                    <h5>Datos de la Empresa (<em>llenar estos datos si representas una oficina de abogados o un departamento legal</em>)</h5>

                                    <p class="field">
                                        <asp:Label ID="lblNombreEmpresa" runat="server" AssociatedControlID="txtNombreEmpresa">Nombre de Empresa</asp:Label>
                                        <asp:TextBox ID="txtNombreEmpresa" runat="server" CssClass="tipsyBox" original-title="Nombre de la empresa que ud. representa"/>
                                    </p>
                                    <p class="field">
                                        <asp:Label ID="lblNombreCompleto" runat="server" AssociatedControlID="txtNombreCompleto">RNC</asp:Label>
                                        <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="tipsyBox" 
                                            original-title="RNC o Número de identificación fiscal de la empresa que ud. representa" />
                                    </p>
                                </div>

                                <p>
                                    <asp:CheckBox runat="server" ID="chkTerminosUso" ClientIDMode="Static" 
                                       cssclass="tipsyBoxLeft" original-title="Debe revisar los términos de uso antes de crear su usuario."/>
                                    Acepto los <a class="tipsyBox" original-title="Debe revisar los términos de uso antes de crear su usuario."
                                     href="/TerminosUso.htm" target="_blank">Términos de uso</a>
                                </p>

                                
                            </div>
                            <div class="footer_go">
                                <%--<asp:Label runat="server" ID="lblErrorCaptcha" CssClass="validator" Text="" />--%>
                                <%--<recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LdQXscSAAAAAHrFPZmFt6SZl_P52Uj1rOLIeamq "
                                    PrivateKey="6LdQXscSAAAAADjdMDGN99t5IF3sVVG0Gh0e6ZN6 " Theme="clean" Language="es"
                                    OverrideSecureMode="True" /--%>
                                
                                <asp:Button runat="server" ID="btnRegister" Text="Registrarse" CssClass="btn btnFormNext"
                                    ValidationGroup="RegisterUserValidationGroup" OnClick="btnRegister_Click" />
                                <div class="clear" />
                            </div>
                        </fieldset>
                        <div class="clear" />
                    </div>
                    <div>
                        <asp:ValidationSummary ID="errorbox" ClientIDMode="Static" runat="server" ValidationGroup="RegisterUserValidationGroup" />
                    </div>
                </div>
                <div class="clear" />
            </div>
            <!-- end grid_24 -->
        </div>
    </div>
</asp:Content>
