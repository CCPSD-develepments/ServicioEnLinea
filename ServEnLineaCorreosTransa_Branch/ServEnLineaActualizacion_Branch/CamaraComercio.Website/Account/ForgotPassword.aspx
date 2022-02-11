<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs" Inherits="CamaraComercio.Website.Account.ForgotPassword" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var validateSession = true;
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    Recuperar Contraseña</h1>
            </div>
            <div id="content_body">
                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="passwordRecovery"
                    runat="server" />
                <fieldset class="form-fieldset">
                    <asp:PasswordRecovery ID="passwordRecovery" runat="server" SubmitButtonText="Recuperar Contraseña"
                        UserNameInstructionText="Digite su usuario o correo electrónico para recuperar su contraseña."
                        UserNameLabelText="Usuario:" UserNameTitleText="¿Olvidó su contraseña?" OnSendingMail="passwordRecovery_SendingMail"
                        Style="margin-left: 0px" SuccessText="Solicitud de recuperación iniciada. Un enlace de reinicio de su contraseña ha sido enviado a su correo electrónico"
                        Width="576px" GeneralFailureText="Ha ocurrido un error al intentar recuperar su contraseña. Por favor intente más tarde."
                        OnVerifyingUser="passwordRecovery_VerifyingUser" UserNameFailureText="Hemos recibido su solicitud de reinicio de contraseña. Si el usuario digitado es válido usted estará recibiendo un correo electrónico en los próximos minutos para validar una nueva contraseña">
                        <UserNameTemplate>
                            <ul>
                                <li>
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario o Correo Electrónico:</asp:Label>
                                    <asp:TextBox ID="UserName" runat="server" Width="185px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" CssClass="validator"
                                        Display="Dynamic"
                                        ControlToValidate="UserName" ErrorMessage="Usuario es requerido." ToolTip="Usuario es requerido."
                                        ValidationGroup="passwordRecovery">*</asp:RequiredFieldValidator>
                                </li>
                                <li>
                                    <label>
                                    </label>
                                    <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Recuperar Contraseña"
                                        ValidationGroup="passwordRecovery" Width="185px" CssClass="btn" />
                                </li>
                                <li>
                                    <label>
                                    </label>
                                    <strong>
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                                    </strong></li>
                            </ul>
                        </UserNameTemplate>
                    </asp:PasswordRecovery>
                </fieldset>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
