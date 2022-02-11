<%@ Control Language="C#" AutoEventWireup="true" Inherits="admin_controls_create_user_with_role" Codebehind="create-user-with-role.ascx.cs" %>
<%@ Register Src="js-include3.ascx" TagName="js" TagPrefix="uc3" %>
<%@ Register src="~/js/js/jquery.ascx" tagname="jquery" tagprefix="uc4" %>


<%-- sidebar help js --%>
<uc3:js ID="js3" runat="server" />
<%-- jquery js --%>
<uc4:jquery ID="jquery1" runat="server" />


<div class="adminHelp">
    1.) Tamaño mínimo de contraseña = 3 chars.<br />2.) Contraseña no es case sensitive.
</div>
<%-- gridview banner --%>
<div class="gvBanner">
  <span class="gvBannerUsers">
    <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/decoy-icon-36px.png" /></span> Crear Nuevo Usuario con Rol
</div>
<%-- create user wizard with roles --%>
<div class="cuwWrap">
  <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" 
        ContinueDestinationPageUrl="~/Admin/add-user.aspx" 
        OnActiveStepChanged="RegisterUserWithRoles_ActiveStepChanged" 
        LoginCreatedUser="False" 
        CompleteSuccessText="The account has been successfully created." 
        UnknownErrorMessage="The account was not created. Please try again." 
        CreateUserButtonText="Continue - Step 2" 
        OnCreatedUser="RegisterUserWithRoles_CreatedUser">
      <CreateUserButtonStyle CssClass="inputButton" />
    <TitleTextStyle CssClass="cuwTitle" />
    <WizardSteps>
      <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="Paso 1 - Información Básica">
          <ContentTemplate>
              <table>
                  <tr>
                      <td align="center" class="cuwTitle" colspan="2">
                          Paso 1 - Información Básica</td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de Usuario:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                              ControlToValidate="UserName" ErrorMessage="Nombre de Usuario es requerido." 
                              ToolTip="Nombre de Usuario es requerido." ValidationGroup="RegisterUserWithRoles">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                              ControlToValidate="Password" ErrorMessage="Contraseña es requerida." 
                              ToolTip="Contraseña es requerida." ValidationGroup="RegisterUserWithRoles">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                              AssociatedControlID="ConfirmPassword">Confirmar Contraseña:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                              ControlToValidate="ConfirmPassword" 
                              ErrorMessage="Confirmar la Contraseña es requerida." 
                              ToolTip="Confirmar la Contraseña es requerida." ValidationGroup="RegisterUserWithRoles">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                              ControlToValidate="Email" ErrorMessage="E-mail es requerido." 
                              ToolTip="E-mail es requerido." ValidationGroup="RegisterUserWithRoles">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Pregunta de Seguridad:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                              ControlToValidate="Question" ErrorMessage="La pregunta de seguridad es requerida." 
                              ToolTip="La pregunta de seguridad es requerida." 
                              ValidationGroup="RegisterUserWithRoles">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="right">
                          <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Respuesta de Seguridad:</asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                              ControlToValidate="Answer" ErrorMessage="La respuesta de seguridad es requerida." 
                              ToolTip="La respuesta de seguridad es requerida." ValidationGroup="RegisterUserWithRoles">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="center" colspan="2">
                          <asp:CompareValidator ID="PasswordCompare" runat="server" 
                              ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                              Display="Dynamic" 
                              ErrorMessage="La contraseña y su confirmación deben coincidir." 
                              ValidationGroup="RegisterUserWithRoles"></asp:CompareValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="center" colspan="2" style="color:Red;">
                          <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                      </td>
                  </tr>
              </table>
          </ContentTemplate>
          <CustomNavigationTemplate>
              <table border="0" cellspacing="5" style="width:100%;height:100%;">
                  <tr align="right">
                      <td align="right" colspan="0">
                          <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" 
                              CssClass="inputButton" Text="Continuar - Paso 2" 
                              ValidationGroup="RegisterUserWithRoles" />
                      </td>
                  </tr>
              </table>
          </CustomNavigationTemplate>
      </asp:CreateUserWizardStep>
      <asp:WizardStep ID="SpecifyRolesStep" runat="server" StepType="Step" Title="Paso 2 -  Specificar Roles" AllowReturn="False">
        <div class="checkboxList" style="width: 100px; overflow: auto;">
          <asp:CheckBoxList ID="RoleList" runat="server">
          </asp:CheckBoxList>
        </div>
      </asp:WizardStep>
      <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
          <ContentTemplate>
              <table>
                  <tr>
                      <td align="center" class="cuwTitle" colspan="2">
                          Complete</td>
                  </tr>
                  <tr>
                      <td>
                          La cuenta se ha creado satisfactoriamente.</td>
                  </tr>
                  <tr>
                      <td align="right" colspan="2">
                          <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                              CommandName="Continue" Text="Continuar" 
                              ValidationGroup="RegisterUserWithRoles" />
                      </td>
                  </tr>
              </table>
          </ContentTemplate>
      </asp:CompleteWizardStep>
    </WizardSteps>
      <FinishCompleteButtonStyle CssClass="inputButton" />
      <StepNavigationTemplate>
          <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" 
              CommandName="MovePrevious" Text="Regresar" />
          <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" 
              Text="Continuar" />
      </StepNavigationTemplate>
  </asp:CreateUserWizard>
</div>
<%-- help sidebar --%>

