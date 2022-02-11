<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CamaraComercio.Website.Account.Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Log In</title>
    <link rel="shortcut icon" href="~/res/img/favccpsd.ico" type="image/x-icon" />
    <link href="~/res/css/bootstrap.css" rel="stylesheet" />
    <script src="/res/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    <style>
        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        html, body {
            height:100%;
            width: 100%;
            min-height: 100%;
            min-width:100%;
            background-image: url('/res/img/fondo.jpg');
        }

        body {
            display: flex;
            flex: 0 0 auto;
            /*position:relative;*/
            min-height: 700px;
            min-width:100%;
            align-items: stretch;
            flex-direction: column;
            justify-content: space-between;
        }

        .header, .footer {
            /*background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#1E5478), color-stop(100%,#0a2c42));*/
            background: -o-linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
		    background: -moz-linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
		    background: -webkit-linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
		    background: linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#1e5799', endColorstr='#032D46',GradientType=0 ); /* IE6-9 */
            /*background-image: linear-gradient(to bottom left, #23527c 0%, #16D611 50%, #23527c 80%);*/
            color: white;
            text-align:center;
            height:1px;
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
                flex: 1;
                display: flex;
                padding: 50px 150px;
            }

        .login-box {
            height:100%;
            width:30%;
            min-width:400px;
            min-height:500px;
            background-color: #20325F;
            color: #FFF;
            margin-right: 10px;
            border-radius: 10px;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            /*overflow:hidden;*/
        }

        .login-box-header {
            font-size: 20px;
            height: 80px;
            text-align: center;
            line-height: 80px;
        }

        .login-box-main {
            flex: 1;
            padding: 3px;
            padding-left: 14px;
            padding-right: 14px;
            min-height:360px;
        }

        .login-box-footer {
            color: #FFF;
            height: 60px;
            background-color: #428DC9;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 17px;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            text-align:center;
        }

            .login-box-footer:hover {
                color: #FFF;
            }

        .image-box {
            flex: 1;
            display:flex;
            min-height:500px;
            height:100%;
            /*background-color: #000;*/
            background-image: url(/res/img/1920X1080.png);
            background-repeat: no-repeat;
            background-size: 100% 100%;
        }

        .footer {
            width: 100%;
            height: 40px;
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

        .login-box-main a {
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
</head>
<body>
    <header class="header">
        <a href="javascript:void(0)" class="left-logo"></a>
    </header>
    <main class="main" id="contenedor">

        <div class="login-box" style="height:100%;" id="login-box-div">
            <div class="login-box-header">Servicios En Línea</div>
            <form class="login-box-main" runat="server">
                <asp:Login ID="LoginUser" runat="server" EnableViewState="false" FailureText="Su intento de acceso no fue satisfactorio, por favor intente nuevamente."
                    PasswordRecoveryIconUrl="~/res/img/help.gif" PasswordRecoveryUrl="~/Account/ForgotPassword.aspx"
                    PasswordRecoveryText="¿Olvidó su contraseña? haga clic aquí." RenderOuterTable="False"
                    OnLoginError="LoginUser_LoginError" OnLoggingIn="LoginUser_LoggingIn" OnLoggedIn="LoginUser_LoggedIn">
                    <LayoutTemplate>
                        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="LoginButton">
                            <asp:Panel ID="pnlErrorLogin" runat="server" Visible="false" CssClass="form-group validation denied">
                                <asp:Label ID="lblMensajes" Text="Nombre de Usuario / Contraseña Inválidos" runat="server" />
                            </asp:Panel>
                            <div class="form-group">
                                <asp:TextBox ID="UserName" runat="server" style="text-transform:lowercase;" CssClass="form-control" ValidationGroup="LoginUserValidationGroup" placeholder="Usuario"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="LoginUserValidationGroup" placeholder="Contraseña">Camara123</asp:TextBox>
                            </div>
                            <div class="form-group text-center">
                                &nbsp;<br />
                                <asp:LinkButton ID="lblForgot" runat="server" OnClick="lblForgot_Click">¿Olvidó su Nombre de Usuario o Contraseña? </asp:LinkButton>
                            </div>
                            <div class="form-group text-center">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar sesion" ValidationGroup="LoginUserValidationGroup" CssClass="btn btn-primary btn-block" />
                            </div>

                            <br /><br />

          <div class="portfolio-item">
            <div class="hover-bg"> <a href="https://www.youtube.com/watch?v=FJvgJV4cVfQ" title="Project Title" data-lightbox-gallery="gallery1">
              <div class="hover-text">
              </div>
              <iframe width="100%" height="200px;" 
         src="https://www.youtube.com/embed/FJvgJV4cVfQ?autoplay=0" allowfullscreen></iframe></a> </div>
          </div>



                        </asp:Panel>
                    </LayoutTemplate>
                </asp:Login>
            </form>
            <footer class="login-box-footer">
                <a href="/Account/Register.aspx" class="login-box-footer">
                    <span>Solicitar Acceso</span>
                </a>
            </footer>
            
        </div>

        <div class="image-box" id="img-box">
        </div>        

    </main>
    <footer class="footer" id="mainFooter">
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

    <script type="text/javascript">
        $(document).ready(
            function () {
                if ($.browser.msie && $.browser.version < 11) {
                    //$('#mainFooter').css("position", "absolute");
                    $('#mainFooter').css("bottom", "0px");
                    $('#contenedor').css("display", "table");
                    $('#contenedor').css("width", "100%");
                    //$('#contenedor').css("height", "100%");
                    $('#login-box-div').css("display", "table-cell");
                    $('#img-box').css("display", "table-cell");
                    $('#img-box').css("background-size", "99% 100%");
                    $('#img-box').css("background-position", "center right");
                    
                    //img - box
                    var h = document.getElementById('login-box-div').style.height;
                    //document.getElementById('img-box').style.height = "100px";
                    //document.getElementById('img-box').style.width = "200px";
                }
                if ($.browser.msie && $.browser.version < 10) {
                    
                }

                if($.browser.safari) {
                    //$('#mainFooter').css("position", "absolute");
                    $('#mainFooter').css("bottom", "0px");
                    //$('#contenedor').css("display", "table");
                    //$('#login-box-div').css("display", "table-cell");
                    //$('#img-box').css("display", "table-cell");
                }
            }
        );
    </script>
    </body>
</html>
