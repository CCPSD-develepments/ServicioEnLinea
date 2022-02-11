<%@ Control Language="C#" AutoEventWireup="true" Inherits="controls_login_with_captcha" Codebehind="login-with-captcha.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<%-- LOGIN USER CONTROL WITH CAPTCHA --%>
<div class="liWrap">
    <a name="login" id="login" style="display: block; height: 0px; width: 0px; border: 0px;"></a>
    <div class="liTitle">
        ACCESO</div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ValidationGroup="Login1" EnableClientScript="False" />
    <%-- success label --%>
    <div class="LiMessage">
        <asp:HyperLink ID="lblFailureText" runat="server" Width="240px" Visible="false" EnableViewState="false"></asp:HyperLink>
    </div>
    <div class="clearBoth"></div>
    <asp:Literal ID="Msg" runat="server" Visible="false"></asp:Literal>
    <asp:LoginView ID="loginBox" runat="server">
        <LoggedInTemplate>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div class="loginIcon">
            </div>
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoginError="Login1_LoginError" VisibleWhenLoggedIn="False" OnLoggingIn="Login1_LoggingIn">
                <LayoutTemplate>
                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="LoginButton">
                        <div class="clearBoth2">
                        </div>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de Usuario:*</asp:Label>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es requerido." ToolTip="El nombre de usuario es requerido." ValidationGroup="Login1" Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="UserName" runat="server" TabIndex="1" ToolTip="digite su nombre de usuario." MaxLength="50" Width="99%"></asp:TextBox>
                        <div class="clearBoth2">
                        </div>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:*</asp:Label>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es requerida." ToolTip="La contraseña es requerida." ValidationGroup="Login1" Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="Password" runat="server" TabIndex="2" TextMode="Password" ToolTip="digite su contraseña" MaxLength="50" Width="99%"></asp:TextBox>
                        <div class="clearBoth2">
                        </div>
                        <div class="hr">
                            <b>CODIGO DE SEGURIDAD</b>
                        </div>
                        <div title="Digite el código mostra arriba.">
                            <cc1:CaptchaControl ID="CAPTCHA" runat="server"  LayoutStyle="Vertical" 
                                ShowSubmitButton="False" TabIndex="3" CaptchaFontWarping="Medium" 
                                CssClass="captcha" ToolTip="Digite el código mostrado" 
                                Text="Digite el código mostrado"  />
                        </div>
                        <div class="clearBoth2">
                        </div>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" TabIndex="4" Text="Iniciar Sesión" ValidationGroup="Login1" />
                        <div class="clearBoth2">
                        </div>
                        <br />
                        </asp:Panel>
                </LayoutTemplate>
            </asp:Login>
        </AnonymousTemplate>
    </asp:LoginView>
    <asp:LoginView ID="userStatus" runat="server">
        <LoggedInTemplate>
            <div class="logoutIcon">
            </div>
            <div style="font-size: 20px;">
                Bienvenido!
                <asp:LoginName ID="LoginName1" runat="server" />
            </div>
            
            <br />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </LoggedInTemplate>
    </asp:LoginView>
</div>
