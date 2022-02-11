<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CamaraComercio.Website.Account.Register2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Log In</title>
    <link rel="shortcut icon" href="~/res/img/favccpsd.ico" type="image/x-icon" />
    <link href="~/res/css/bootstrap.css" rel="stylesheet" />
    <link href="~/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
   

<script src="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js"></script>

<!-- CSS -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.min.css"/>
<!-- Default theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.min.css"/>
<!-- Semantic UI theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.min.css"/>
<!-- Bootstrap theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/bootstrap.min.css"/>

<!-- 
    RTL version
-->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.rtl.min.css"/>
<!-- Default theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.rtl.min.css"/>
<!-- Semantic UI theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/semantic.rtl.min.css"/>
<!-- Bootstrap theme -->
<link rel="stylesheet" href="//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/bootstrap.rtl.min.css"/>



    <style>
        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        html, body {
            width: 100%;
            min-height: 100%;
            min-width:100%;
            height:auto;
            background-image: url('/res/img/fondo.jpg');
        }

        body {
            display: flex;
            flex: 0 0 auto;
            min-height: 100%;
            min-width:100%;
            align-items: stretch;
            flex-direction: column;
            justify-content: space-between;
        }

        .header, .footer {
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#1E5478), color-stop(100%,#0a2c42));
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#1e5799', endColorstr='#032D46',GradientType=0 ); /* IE6-9 */
            background: linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
            color: white;
            text-align:center;
        }

        .header {
            height: 100px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding-left: 10px;
            padding-right: 10px;
            background-color: rgba(238, 238, 238, 1);
        }

            .header > .left-logo {
                display: block;
                width: 270px;
                height: 100px;
                background-image: url('/res/img/logo.jpg');
                background-repeat: no-repeat;
                background-position: left top;
            }

        .main {
            flex: 0 0 auto;
            display: flex;
            height:100%;
            padding: 50px 150px;
        }

        .register-box {
            width: 30%;
            height:100%;
            min-width:400px;
            background-color: #20325F;
            color: #FFF;
            margin-right: 10px;
            border-radius: 10px;
            //display: flex;
            flex-direction: column;
            justify-content: space-between;
            overflow:hidden;
        }

        .register-box-header {
            font-size: 20px;
            height: 80px;
            text-align: center;
            line-height: 80px;
            position:relative;
        }

        .register-box-main {
            flex: 1 0 auto;
            
            padding: 3px;
            height:100%;
            padding-left: 14px;
            padding-right: 14px;
        }

        .register-box-footer {
            color: #FFF;
            height: 60px;
            background-color: #428DC9;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 17px;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
        }

            .register-box-footer:hover {
                color: #FFF;
            }

        .image-box {
            flex: 1;
            /*background-color: #000;*/
            background-image: url('/res/img/1920X1080.png');
            background-repeat: no-repeat;
            background-size: 100% 100%;
        }

        .footer {
            height: 40px;
            width: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .circle {
            width: 22px;
            height: 22px;
            line-height: 22px;
            border-radius: 50%;
            text-align: center;
            background-color: #FFF;
            color: #20325F;
        }

        .register-box-main a {
            color: #FFF;
        }

        div.validation {
            padding: 5px 30px;
            margin-top: 1px;
        }

        div.denied {
            background-color: #fce9e9;
            border-bottom: 1px solid #e5b7b7;
            border-top: 1px solid #f4dada;
            background-image: url(/res/img/denied.gif);
            background-repeat: no-repeat;
            background-position: 10px 4px;
            color: #b46e6e;
        }

        input.validationMark {
            background-color: #fce9e9 !important;
            border: 1px solid #e8c8c8 !important;
        }
    </style>
    <link href="/res/js/tipsy/tipsy.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header class="header">
        <a href="/" class="left-logo"></a>
    </header>
    <main class="main">

        <div class="register-box" id="register-box-div">
            <div class="register-box-header">¿Aún no has creado una cuenta?</div>
            <form class="register-box-main" runat="server">
                <asp:Panel ID="pnlErrorLogin" runat="server" Visible="false" CssClass="form-group validation denied">
                    <asp:Label ID="lblMensajes" Text="Nombre de Usuario / Contraseña Inválidos" runat="server" />
                </asp:Panel>
                <div class="form-group">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario</asp:Label>
                    <asp:TextBox ID="UserName" runat="server" style="text-transform:lowercase;" CssClass="form-control" ValidationGroup="LoginUserValidationGroup" placeholder="Usuario" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" CssClass="validator summary" ErrorMessage="El nombre de usuario es requerido." Display="None" ToolTip="Nombre de usuario requerido." ClientIDMode="Static" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserName" ValidationGroup="RegisterUserValidationGroup" ErrorMessage="El campo usuario no puede tener espacios, números, ni caracteres especiales." ValidationExpression="^\D[0-9-a-zA-Z]*\.?[0-9-a-zA-Z]*[^.]$" CssClass="validator summary" Display="None" ClientIDMode="AutoID" ToolTip="El campo contiene caracteres invalidos">*</asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="cvUserName" runat="server" Text="*" ControlToValidate="UserName" ErrorMessage="El nombre de usuario ya existe." ValidationGroup="RegisterUserValidationGroup" OnServerValidate="cvUserName_ServerValidate" Display="None" CssClass="validator"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                    <asp:TextBox ID="Email" runat="server" CssClass="form-control" style="text-transform:lowercase;" original-title="Correo electrónico del usuario." placeholder="E-mail"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" CssClass="validator summary" ErrorMessage="El campo Correo Electronico es requerido." Display="None" ToolTip="Correo electronico es requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email" ErrorMessage="Direccion de correo invalida" ToolTip="Direccion de correo invalida" CssClass="validator summary" Display="None" ValidationGroup="RegisterUserValidationGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidatorEmailDuplicado" runat="server" ControlToValidate="Email" ValidationGroup="RegisterUserValidationGroup" CssClass="validator summary" Text="*" Display="None" ErrorMessage="La dirección de correo digitada ya existe. Por favor verifique y trate de nuevo." OnServerValidate="CustomValidatorEmailDuplicado_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" ViewStateMode="Enabled" original-title="Contraseña. Debe tener al menos 8 caracteres, una mayúscula, una minúscula y un dígito" MaxLength="15" placeholder="Contraseña" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ForeColor="Red" CssClass="validator summary" ErrorMessage="El campo de contraseña es requerido." Display="None" ToolTip="La contraseña es requerida." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña debe tener al menos 8 caracteres,  una mayúscula una minúscula y un dígito." ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" Display="None" CssClass="validator summary" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Repetir Contraseña</asp:Label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" ViewStateMode="Enabled" MaxLength="15" placeholder="Repetir Contraseña" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ForeColor="Red" ControlToValidate="ConfirmPassword" CssClass="validator summary" Display="None" ErrorMessage="La contraseña y la confirmacion de contraseña deben ser iguales." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" CssClass="validator summary" Display="None" ErrorMessage="El campo repertir contraseña es requerido." ToolTip="El campo repertir contraseña es requerido." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTipoDocumento" runat="server" AssociatedControlID="ddlTipoDocumento">Tipo Documento</asp:Label>
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control" original-title="Tipo de documento">
                        <asp:ListItem Value="Cedula">Cédula</asp:ListItem>
                        <asp:ListItem Value="Pasaporte">Pasaporte</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula">No. Documento</asp:Label>
                    <asp:TextBox ID="txtCedula" runat="server" MaxLength="13" CssClass="form-control" original-title="Número del documento. Escribir sin espacios ni guiones." placeholder="No. Documento" />
                    <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ClientIDMode="Static" ValidationGroup="RegisterUserValidationGroup" CssClass="validator summary" Text="*" Display="None" ControlToValidate="txtCedula" ErrorMessage="Debe digitar el número de documento."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="vcExisteCedula" runat="server" Text="*" ControlToValidate="txtCedula" ErrorMessage="El no. de documento existe en el sistema." ValidationGroup="RegisterUserValidationGroup" OnServerValidate="vcExisteCedula_ServerValidate" Display="None" CssClass="validator summary"></asp:CustomValidator>
                    <asp:CustomValidator ID="vcTipoCedula" runat="server" Text="*" ControlToValidate="txtCedula" ErrorMessage="El número de cédula no debe contener guiones." CssClass="validator summary" ValidationGroup="RegisterUserValidationGroup" OnServerValidate="vcTipoCedula_ServerValidate" Display="None"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <div class="checkbox">
                        <asp:Label ID="lblFirmaDigital" runat="server" AssociatedControlID="chkFirmaDigital"><asp:CheckBox runat="server" ID="chkFirmaDigital" type="checkbox" value=""/>Posee Firma Digital?</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="NombreCompletoLable" runat="server" AssociatedControlID="NombreCompletoTextBox">Nombre Completo</asp:Label>
                    <asp:TextBox ID="NombreCompletoTextBox" runat="server" cssclass="form-control" original-title="Nombres y apellidos del usuario." MaxLength="180" placeholder="Nombre Completo" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NombreCompletoTextBox" CssClass="validator summary" ErrorMessage="El campo nombre es requerido." ToolTip="El campo nombre es requerido." ValidationGroup="RegisterUserValidationGroup" Display="None">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="NombreCompletoTextBox" ErrorMessage="El nombre contiene caracteres invalidos" ValidationExpression="^[a-zA-Z\s\.áéíóúÁÉÍÓÚñÑ]+$" CssClass="validator summary" Display="None" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtTelefono" ID="lblTelefonoTIt">Teléfono de Contacto</asp:Label>
                    <asp:TextBox runat="server" ID="txtTelefono" ClientIDMode="Static" CssClass="form-control" original-title="No. de teléfono de contacto (opcional)" placeholder="No. Teléfono" />
                </div>
              <%--  <h5>Datos de la Empresa (<em>llenar estos datos si representas una oficina de abogados o un departamento legal</em>)</h5>--%>
           <%--     <div class="form-group">
                    <asp:Label ID="lblNumeroRegistroMercantil" runat="server" AssociatedControlID="txtNumeroRegistroMercantil">Número de Registro Mercantil</asp:Label>
                    <asp:CheckBox ID="ckbIsValidNumeroRegistroMercantil" runat="server" Visible="false" />
                    <div class="input-group">
                        <asp:TextBox ID="txtNumeroRegistroMercantil" runat="server" CssClass="form-control" OnTextChanged="txtNumeroRegistroMercantil_TextChanged" original-title="Número de identificación fiscal de la empresa que ud. representa" placeholder="Número Registro Mercantil" />
                        <span class="input-group-btn">
                            <button class="btn btn-default" id="btnSearchEmpresa" runat="server" onserverclick="btnSearchEmpresa_ServerClick">Buscar</button>
                        </span>
                    </div>
                </div>--%>
           <%--     <div class="form-group">
                    <asp:Label ID="lblNombreEmpresa" runat="server" AssociatedControlID="txtNombreEmpresa">Nombre de Empresa</asp:Label>
                    <asp:TextBox ID="txtNombreEmpresa" runat="server" Enabled="false" CssClass="form-control" original-title="Nombre de la empresa que ud. representa" placeholder="Nombre de Empresa" />
                </div>--%>
                <div class="form-group">
                    <asp:CheckBox runat="server" ID="chkTerminosUso" ClientIDMode="Static" cssclass="tipsyBoxLeft" original-title="Debe revisar los términos de uso antes de crear su usuario."/> Acepto los <a class="tipsyBox fancybox" id="termsIFrame" title="Debe revisar los términos de uso antes de crear su usuario." href="/TerminosUso.html">Términos de uso</a>
                </div>
                <div class="form-group text-center">
                    <asp:Button runat="server" ID="btnRegister" Text="Registrarse" CssClass="btn btn-primary btn-block" ValidationGroup="RegisterUserValidationGroup" OnClick="btnRegister_Click" />
                </div>
                <div style="padding-left: 20px">
                    <asp:ValidationSummary ID="errorbox" ClientIDMode="Static" runat="server" ValidationGroup="RegisterUserValidationGroup" />
                </div>
            </form>
        </div>
        <div class="image-box" id="img-box"></div>
    </main>
    <footer class="footer" id="mainFooter" style="bottom:0px;">
        <div style="width:100%">
        <span>Cámara de Comercio y Producción de Santo Domingo. República Dominicana &reg; 2019 Todos los Derechos Reservados.</span>
        <i style="margin-left: 4px;" class="fa fa-phone circle"></i>
        <span style="margin-left: 4px;">809.682.2688</span>
        <span style="margin-left: 4px;">|</span>
        <a href="javascript:void(0)" style="margin-left: 4px;" class="circle">
            <i class="fab fa-facebook-f"></i>
        </a>
        <a href="javascript:void(0)" style="margin-left: 4px;" class="circle">
            <i class="fab fa-instagram"></i>
        </a>
        <a href="javascript:void(0)" style="margin-left: 4px;" class="circle">
            <i class="fab fa-twitter"></i>
        </a>
         </div>
    </footer>

    <script src="/res/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/res/js/jquery.maskedinput.js" type="text/javascript"></script>
    <script src="/res/js/tipsy/jquery.tipsy.js" type="text/javascript"></script>
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.js"></script>
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

            if ($.browser.msie && $.browser.version < 11) {
                
                $('#mainFooter').css("bottom", "0px");
                //$('#contenedorIE9').css("display", "table");
                $('#register-box-div').css("display", "table-cell");
                $('#contenedor').css("width", "100%");
                $('#contenedor').css("height", "100%");
                $('#img-box').css("display", "table-cell");
                $('#img-box').css("background-size", "99% 100%");
                $('#img-box').css("background-position", "center right");
                //img - box
                //var h = document.getElementById('login-box-div').style.height;
                //document.getElementById('img-box').style.height = "100px";
                //document.getElementById('img-box').style.width = "200px";
            }

            if ($.browser.safari) {
                //$('#mainFooter').css("position", "absolute");
                //$('#mainFooter').css("bottom", "0px");
                //$('#contenedor').css("display", "table");
                //$('#login-box-div').css("display", "table-cell");
                //$('#img-box').css("display", "table-cell");
            }
            
            //Quitando los tab stops del captcha
            $('#recaptcha_table a').each(function () { this.tabIndex = -1 });

            //Ayuda y comentarios de campos
            $(".tipsyBox").tipsy({ trigger: 'focus', gravity: 'w', opacity: 0.8 });
            $(".tipsyBoxLeft").tipsy({ trigger: 'focus', gravity: 'e', opacity: 0.8 });
            
            $("a#termsIFrame").fancybox({
                maxWidth    : 600,
                maxHeight   : 600,
                fitToView   : true,
                width       : '70%',
                height      : '70%',
                autoSize    : true,
                closeClick  : true,
                type        : 'iframe',
                openEffect  : 'none',
                closeEffect : 'none'
            });
        });

        
        
    </script>
</body>
</html>
