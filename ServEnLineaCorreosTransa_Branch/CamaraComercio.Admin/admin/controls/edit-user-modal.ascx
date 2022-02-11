<%@ Control Language="C#" AutoEventWireup="true" Inherits="admin_controls_edit_user_modal"
    CodeBehind="edit-user-modal.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="js-include3.ascx" TagName="js" TagPrefix="uc3" %>
<%@ Register Src="~/js/js/jquery.ascx" TagName="jquery" TagPrefix="uc4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .RadGrid_Default
    {
        font: 12px/16px "segoe ui" ,arial,sans-serif;
    }
    
    .RadGrid_Default
    {
        border: 1px solid #828282;
        background: #fff;
        color: #333;
    }
    
    .RadGrid_Default
    {
        font: 12px/16px "segoe ui" ,arial,sans-serif;
    }
    
    .RadGrid_Default
    {
        border: 1px solid #828282;
        background: #fff;
        color: #333;
    }
    
    .RadGrid_Default .rgMasterTable
    {
        border-collapse: separate;
    }
    
    .RadGrid_Default .rgMasterTable
    {
        font: 12px/16px "segoe ui" ,arial,sans-serif;
    }
    
    .RadGrid_Default .rgMasterTable
    {
        border-collapse: separate;
    }
    
    .RadGrid_Default .rgMasterTable
    {
        font: 12px/16px "segoe ui" ,arial,sans-serif;
    }
    
    .RadGrid_Default .rgHeader
    {
        color: #333;
        text-decoration: none;
    }
    
    .RadGrid_Default .rgHeader
    {
        border: 0;
        border-bottom: 1px solid #828282;
        padding-top: 5px;
        padding-bottom: 4px;
        background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        text-align: left;
        font-weight: normal;
    }
    
    .RadGrid_Default .rgHeader
    {
        padding-left: 7px;
        padding-right: 7px;
    }
    
    .RadGrid_Default .rgHeader
    {
        cursor: default;
    }
    
    .RadGrid_Default .rgHeader
    {
        color: #333;
        text-decoration: none;
    }
    
    .RadGrid_Default .rgHeader
    {
        border: 0;
        border-bottom: 1px solid #828282;
        padding-top: 5px;
        padding-bottom: 4px;
        background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        text-align: left;
        font-weight: normal;
    }
    
    .RadGrid_Default .rgHeader
    {
        padding-left: 7px;
        padding-right: 7px;
    }
    
    .RadGrid_Default .rgHeader
    {
        cursor: default;
    }
</style>
<div>
    <asp:HiddenField ID="hfCurrentUser" runat="server" />
    <%-- ajax update panel start --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%-- ajax tab container start --%>
            <cc1:TabContainer ID="tcntUserInfo" runat="server" ActiveTabIndex="1" Width="100%"
                Font-Size="10px" CssClass="aTab1">
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Crear Nuevo Rol" Visible="false">
                    <ContentTemplate>
                        <div class="contentTemplate">
                            <div class="formSectionTitle2">
                                Crear Nuevo Rol
                            </div>
                            <asp:TextBox runat="server" ID="NewRole" MaxLength="50" ToolTip="Type the name of a new role you want to create."></asp:TextBox><asp:Button
                                ID="Button3" runat="server" CssClass="inputButton" OnClick="AddRole" Text="Agergar Rol"
                                ToolTip="Click to create new role." /><div runat="server" id="ConfirmationMessage">
                                </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Info General">
                    <HeaderTemplate>
                        Info General
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="contentTemplate">
                            <div class="formSectionTitle2">
                                Roles
                            </div>
                            <div class="checkboxList">
                                <asp:CheckBoxList ID="UserRoles" runat="server" RepeatDirection="Horizontal" />
                            </div>
                            <br />
                            <div class="formSectionTitle2">
                                Info Usuario
                            </div>
                            <asp:DetailsView AutoGenerateRows="False" DataSourceID="MemberData" ID="UserInfo"
                                runat="server" OnItemUpdating="UserInfo_ItemUpdating" DefaultMode="Edit" CssClass="dv"
                                GridLines="None">
                                <Fields>
                                    <asp:BoundField DataField="UserName" HeaderText="Nombre Usuario" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <ControlStyle Width="245px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Comentario">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>' TextMode="MultiLine"
                                                Height="100px" Width="245px"></asp:TextBox></EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox></InsertItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField DataField="IsApproved" HeaderText="Activo"></asp:CheckBoxField>
                                    <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Bloqueado" ReadOnly="True">
                                    </asp:CheckBoxField>
                                    <asp:CheckBoxField DataField="IsOnline" HeaderText="En Línea" ReadOnly="True"></asp:CheckBoxField>
                                    <asp:BoundField DataField="CreationDate" HeaderText="Creado En" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastActivityDate" HeaderText="Ultima Actividad" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastLoginDate" HeaderText="Ultimo Acceso" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastLockoutDate" HeaderText="Ultimo Bloqueo" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="Ultimo Cambio Contraseña"
                                        ReadOnly="True"></asp:BoundField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <div class="clearBoth2">
                                            </div>
                                            <asp:Button ID="Button1" CssClass="inputButton" runat="server" CausesValidation="True"
                                                CommandName="Update" Text="Actualizar Usuario" OnClientClick="return confirm('This will UPDATE the User Info. Click OK to continue.')" /><asp:Button
                                                    ID="Button2" CssClass="inputButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="Cancelar" /><asp:Button ID="Button4" CssClass="inputButton" runat="server"
                                                        Text="Desbloquear Usuario" OnClick="UnlockUser" OnClientClick="return confirm('Click OK to unlock this user.')" /><asp:Button
                                                            ID="Button5" CssClass="inputButton" runat="server" Text="Borrar Usuario" OnClick="DeleteUser"
                                                            OnClientClick="return confirm('Are you sure? This will delete all information related to this user including the user profile.')" /></EditItemTemplate>
                                        <ItemTemplate>
                                            <div class="clearBoth2">
                                            </div>
                                            <asp:Button ID="Button1" CssClass="inputButton" runat="server" CausesValidation="False"
                                                CommandName="Edit" Text="Editar" /></ItemTemplate>
                                        <ControlStyle Font-Size="11px" />
                                    </asp:TemplateField>
                                </Fields>
                                <RowStyle CssClass="dvRowStyle" />
                                <FieldHeaderStyle CssClass="dvFieldHeader" />
                                <HeaderStyle CssClass="dvHeader" />
                                <AlternatingRowStyle CssClass="dvAlternateRowStyle" />
                            </asp:DetailsView>
                            <div class="messageWrap2">
                                <asp:Literal ID="UserUpdateMessage" runat="server"></asp:Literal></div>
                            <br />
                            <asp:ObjectDataSource ID="MemberData" runat="server" SelectMethod="GetUser" TypeName="System.Web.Security.Membership"
                                UpdateMethod="UpdateUser">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="username" QueryStringField="username" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="User Profile">
                    <ContentTemplate>
                        <div class="contentTemplate">
                            <div class="formSectionTitle2">
                                Perfil de Usuario
                            </div>
                            <div class="formLabelsText">
                                Nombre Completo:<br />
                                <asp:TextBox ID="txtFullName" runat="server" Width="22%" MaxLength="50"></asp:TextBox>
                            </div>
                            <div class="formButton">
                                <asp:Button ID="btnUpdateProfile" CssClass="inputButton" runat="server" Text="Actualizar Perfil"
                                    ValidationGroup="EditProfile" OnClick="btnUpdateProfile_Click1" />
                                <asp:Label ID="lblProfileMessage" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel3" runat="server" Visible="false" HeaderText="Información Empresa">
                    <HeaderTemplate>
                        Información Empresa</HeaderTemplate>
                    <ContentTemplate>
                        <div>
                            <div class="contentTemplate">
                                <div class="formSectionTitle2">
                                    Información General:
                                </div>
                                <asp:Label ID="lblEmpresa" runat="server" Text="Nombre Empresa: "></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblUsuarioPadre" runat="server" Text="Usuario Principal: "></asp:Label>
                                |
                                <asp:LinkButton ID="lnkCambiarUsuarioPadre" runat="server" OnClick="lnkCambiarUsuarioPadre_Click">Cambiar Usuario Principal</asp:LinkButton>
                                <br />
                                <br />
                                <asp:Panel ID="pnlCambiarUsuarioPadre" runat="server" Visible="False">
                                    <label for="ddlUsuarios">
                                        Seleccione el Nuevo usuario Padre:
                                    </label>
                                    <asp:DropDownList ID="ddlUsuarios" runat="server">
                                    </asp:DropDownList>
                                    <asp:LinkButton ID="lnkCambiar" runat="server" CausesValidation="False" OnClick="lnkCambiar_Click2">Relizar Cambio</asp:LinkButton>
                                    <asp:Literal ID="litResumenCambio" runat="server"></asp:Literal>
                                </asp:Panel>
                                <div class="formSectionTitle2">
                                    Listado de Sub-Usuarios:
                                </div>
                                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" DataSourceID="odsUsers"
                                    GridLines="None">
                                    <MasterTableView DataSourceID="odsUsers">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="Nombre Completo" UniqueName="NombreSolicitante"
                                                DataField="NombreSolicitante">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Correo Electrónico" UniqueName="Email" DataField="Email">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Nombre Usuario" UniqueName="UserName" DataField="UserName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridCheckBoxColumn DataField="IsActive" HeaderText="Activo" UniqueName="IsApproved">
                                            </telerik:GridCheckBoxColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <asp:ObjectDataSource ID="odsUsers" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="FetchByUsuarioPadre" TypeName="CamaraComercio.DataAccess.EF.Membership.UsuariosController">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfCurrentUser" DefaultValue="" Name="usuarioPadre"
                                            PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Contraseña">
                    <HeaderTemplate>
                        Cambiar Contraseña</HeaderTemplate>
                    <ContentTemplate>
                        <div class="contentTemplate">
                            <div class="formSectionTitle2">
                                Cambiar Contraseña:
                            </div>
                            
                            <div class="formLabelsText">
                                Nueva Contraseña:<br />
                                <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" ControlToValidate="PasswordTextbox"
                                    Display="Dynamic" ErrorMessage="Requerido" ValidationGroup="changepassword"></asp:RequiredFieldValidator></div>
                            <div class="formLabelsText">
                                Confirmar Nueva Contraseña:<br />
                                <asp:TextBox ID="PasswordConfirmTextbox" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordConfirmRequiredValidator" runat="server"
                                    ControlToValidate="PasswordConfirmTextbox" Display="Dynamic" ErrorMessage="Requerido"
                                    ValidationGroup="changepassword"></asp:RequiredFieldValidator><asp:CompareValidator
                                        ID="PasswordConfirmCompareValidator" runat="server" ControlToCompare="PasswordTextBox"
                                        ControlToValidate="PasswordConfirmTextbox" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden."
                                        ValidationGroup="changepassword"></asp:CompareValidator></div>
                            <div>
                                <asp:Button ID="ChangePasswordButton" CssClass="inputButton" runat="server" OnClick="ChangePassword_OnClick"
                                    Text="Cambiar Contraseña" ValidationGroup="changepassword" />
                                     <asp:Label ID="lblPassword" runat="server" />
                                    
                                    </div>
                            <div class="formSectionEnd">
                            </div>
                            <div class="formSectionTitle2" style="display: none;">
                                Cambiar Pregunta y Respuesta
                            </div>
                            <div class="formLabelsText" style="display: none;">
                                Contraseña:<br />
                                <asp:TextBox ID="qaCurrentPassword" runat="server" TextMode="Password" Width="140px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="qaCurrentPassword"
                                    ErrorMessage="Required" ValidationGroup="changePasswordQA"></asp:RequiredFieldValidator></div>
                            <div class="formLabelsText" style="display: none;">
                                Nueva Preg.:<br />
                                <asp:TextBox ID="qaNewQuestion" runat="server" MaxLength="256" Width="140px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="QuestionRequiredValidator" runat="server" ControlToValidate="qaNewQuestion"
                                    ErrorMessage="Required" ValidationGroup="changePasswordQA"></asp:RequiredFieldValidator></div>
                            <div class="formLabelsText" style="display: none;">
                                Nueva Resp.:<br />
                                <asp:TextBox ID="qaNewAnswer" runat="server" MaxLength="128" Width="140px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="AnswerRequiredValidator" runat="server" ControlToValidate="qaNewAnswer" ErrorMessage="Required"
                                    ValidationGroup="changePasswordQA"></asp:RequiredFieldValidator></div>
                            <div style="display: none;">
                                <asp:Button ID="ChangePasswordQuestionButton" CssClass="inputButton" runat="server"
                                    OnClick="ChangePasswordQuestion_OnClick" Text="Cambir P. and R." ValidationGroup="changePasswordQA" /></div>
                            <div style="display: none;">
                                <asp:Label ID="Msg" runat="server" ForeColor="Maroon"></asp:Label></div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Actividades">
                    <ContentTemplate>
                        <div class="contentTemplate">
                            <div class="formSectionTitle2">
                                Actividades del usuario.
                            </div>
                           
                            <telerik:RadGrid ID="gvActivities" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="odsActividades" GridLines="None" AllowPaging="True" 
                                AllowSorting="True" onitemdatabound="gvActivities_ItemDataBound">
                                <MasterTableView DataSourceID="odsActividades">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ActivityLogID" DataType="System.Guid" 
                                            HeaderText="ActivityLogID" SortExpression="ActivityLogID" 
                                            UniqueName="ActivityLogID" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="UserId" DataType="System.Guid" 
                                            HeaderText="UserId" SortExpression="UserId" UniqueName="UserId" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ActivityDate" DataType="System.DateTime" 
                                            HeaderText="Fecha" SortExpression="ActivityDate" UniqueName="Fecha">
                                            <HeaderStyle Width="120px" />
                                            <ItemStyle Width="120px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Activity" HeaderText="Actividad" 
                                            SortExpression="Activity" UniqueName="Actividad">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="PageUrl" HeaderText="URL" 
                                            UniqueName="PURL">
                                            <ItemTemplate>
                                                <asp:Label Text='<%#  Convert.ToString(Eval("PageUrl")).Length > 30 ? Eval("PageUrl").ToString().Substring(0, 30) + "..." : Eval("PageUrl") %>' ID="lblPUrl" runat="server" ToolTip='<%# Eval("PageUrl") %>' />
                                            </ItemTemplate>
                                            
                                            <HeaderStyle Width="250px" />
                                            
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="IpAddress" HeaderText="Dirección IP" 
                                            SortExpression="IpAddress" UniqueName="DireccionIP">
                                            <HeaderStyle Width="100px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PageUrl" HeaderText="URL" 
                                            SortExpression="PageUrl" UniqueName="URL" Visible="False">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" 
                                    NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" 
                                    PrevPagesToolTip="Previa" PrevPageToolTip="Previa" ShowPagerText="False" />
                            </telerik:RadGrid>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
            <asp:ObjectDataSource ID="odsActividades" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllUserActivity" 
                TypeName="CamaraComercio.DataAccess.EF.Membership.UsuariosController">
                <SelectParameters>
                    <asp:QueryStringParameter Name="userName" QueryStringField="username" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <%-- ajax update panel end --%>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<%-- ajax update panel end --%><%-- help sidebar --%>
<uc3:js ID="js3" runat="server" />
<%-- sidebar help js --%>
<uc4:jquery ID="jquery1" runat="server" />
