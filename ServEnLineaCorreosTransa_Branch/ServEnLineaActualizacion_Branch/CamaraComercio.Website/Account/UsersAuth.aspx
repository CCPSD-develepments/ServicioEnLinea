<%@ Page Title="Autorización de Usuarios" Language="C#" MasterPageFile="~/res/nobox.Master"
    AutoEventWireup="true" CodeBehind="UsersAuth.aspx.cs" Inherits="CamaraComercio.Website.Account.UsersAuth" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ MasterType VirtualPath="~/res/ccpsd.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    <asp:Label ID="lblUsuarioPadre" runat="server" Text="[Empresa]"></asp:Label>
                    - Autorización de Usuarios
                    <asp:Label ID="lblEmpresa" runat="server" Text="[Empresa]"></asp:Label></h1>
            </div>
            <div id="content_body">
                <div style="text-align: right; margin-bottom: 4px">
                    <asp:LinkButton ID="lbAddUser" runat="server" OnClick="lbNewUserDesc_Click">Autorizar nueva persona</asp:LinkButton>
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                    <asp:HiddenField ID="hfCurrentUser" runat="server" />
                    <asp:ObjectDataSource ID="odsUsers" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="AuthUsersGetByUsername" TypeName="CamaraComercio.DataAccess.EF.Membership.MembershipController">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCurrentUser" Name="usuarioPadre" PropertyName="Value"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
                </div>
                <div>
                    <telerik:RadGrid ID="gvUsers" runat="server" DataSourceID="odsUsers" OnItemCommand="gvUsers_ItemCommand"
                        AllowPaging="True" AutoGenerateColumns="False" GridLines="None" OnItemDataBound="gvUsers_ItemDataBound"
                        PageSize="8">
                        <ClientSettings EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataSourceID="odsUsers" NoMasterRecordsText="No existen usuarios autorizados a hacer trámites en la cámaras.">
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"
                                    UniqueName="Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cedula" HeaderText="Cédula" SortExpression="Cedula"
                                    UniqueName="Cedula">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreEmpresa" HeaderText="Empresa" SortExpression="NombreEmpresa"
                                    UniqueName="NombreEmpresa">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NoRegistro" DataType="System.Int32" HeaderText="Número Registro"
                                    SortExpression="NoRegistro" UniqueName="NoRegistro">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreCamara" HeaderText="Cámara" SortExpression="NombreCamara"
                                    UniqueName="NombreCamara">
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="Activo" DataType="System.Boolean" HeaderText="Activo"
                                    SortExpression="Activo" UniqueName="Activo">
                                </telerik:GridCheckBoxColumn>
                                <telerik:GridBoundColumn DataField="CamaraID" Display="False" HeaderText="CamaraID"
                                    UniqueName="CamaraID">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Última" NextPageToolTip="Próxima"
                            PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" ShowPagerText="False" />
                    </telerik:RadGrid>
                </div>
                <div>
                    <asp:MultiView ID="mvUsers" runat="server" ActiveViewIndex="0">
                        <asp:View runat="server" ID="ViewManageUsers">
                            <fieldset>
                                <h2 style="margin-top: 8px">
                                    Administración de Usuarios Autorizados</h2>
                                <div>
                                    <p>
                                        Esta sección del portal permite a un gestor administrar las personas que estarán
                                        autorizadas para hacer tramites en las cámaras.</p>
                                    <ul>
                                        <li>Para agregar un nuevo usuario haga clic en el link
                                            <asp:LinkButton ID="lbNewUserDesc" runat="server" OnClick="lbNewUserDesc_Click">Autorizar nuevo usuario</asp:LinkButton>
                                            en la esquina superior derecha. </li>
                                        <li>Para modificar o desactivar un usuario, seleccione el deseado haciendo click de
                                            la lista de usuarios.</li>
                                    </ul>
                                </div>
                            </fieldset>
                        </asp:View>
                        <asp:View runat="server" ID="NewAuthUser">
                            <fieldset>
                                <h2>
                                    Agregar nuevo usuario autorizado</h2>
                                <div style="margin-left: 25px">
                                    <asp:ValidationSummary ID="vSummaryNewUser" CssClass="valSummary" runat="server"
                                        ValidationGroup="NewUser" />
                                </div>
                                <br />
                                <label for="txtNewUser">
                                    Nombre:</label>
                                <asp:TextBox ID="txtNewUser" runat="server" ClientIDMode="static" CssClass="inputField"
                                    Width="170px" ValidationGroup="NewUser"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNewNombre" runat="server" ControlToValidate="txtNewUser"
                                    ErrorMessage="El campo Nombre es requerido." ForeColor="Red" ValidationGroup="NewUser">*</asp:RequiredFieldValidator>
                                <br />
                                <label for="txtCedula">
                                    Cédula:</label>
                                <asp:TextBox ID="txtCedula" ClientIDMode="static" runat="server" CssClass="inputField"
                                    Width="170px" ValidationGroup="NewUser" MaxLength="14"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNewCedula" runat="server" ControlToValidate="txtCedula"
                                    ErrorMessage="El campo Cedula es requerido." ForeColor="Red" ValidationGroup="NewUser"
                                    Display="Dynamic">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvKey" runat="server" ControlToValidate="txtCedula" Display="Dynamic"
                                    ErrorMessage="Este usuario ya esta asignado a esta camara para esa empresa."
                                    ForeColor="Red" OnServerValidate="cvKey_ServerValidate" ValidationGroup="NewUser">*</asp:CustomValidator>
                                <br />
                                <label for="ddlCamara">
                                    Cámara:</label>
                                <asp:DropDownList ID="ddlCamara" runat="server" CssClass=".inputField" Width="175px"
                                    ValidationGroup="NewUser">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvNewCamara" runat="server" ControlToValidate="ddlCamara"
                                    ErrorMessage="Debe seleccionar una cámara." ForeColor="Red" InitialValue="Seleccione una opción...">*</asp:RequiredFieldValidator>
                                <br />
                                <label for="ddlNoRegistro">
                                    Empresa:</label>
                                <asp:DropDownList ClientIDMode="Static" ID="ddlNoRegistro" runat="server" CssClass=".inputField"
                                    Width="175px" ValidationGroup="NewUser">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvNewNoRegistro" runat="server" ControlToValidate="ddlNoRegistro"
                                    ErrorMessage="Debe seleccionar un No. Registro." ForeColor="Red" InitialValue="Seleccione una opción...">*</asp:RequiredFieldValidator>
                                <br />
                                <div class="divSubmit">
                                    <asp:Button ID="btnNewCancel" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnNewCancel_Click" />
                                    <asp:Button ID="btnNewInsert" runat="server" Text="Agregar" CssClass="btn" ValidationGroup="NewUser"
                                        OnClick="btnNewInsert_Click" />
                                    <asp:Label ID="lblResultado" ForeColor="Green" Font-Bold="true" runat="server" Text=""></asp:Label>
                                </div>
                            </fieldset>
                        </asp:View>
                        <asp:View runat="server" ID="EditAuthUser">
                            <fieldset>
                                <h2>
                                    Edicion de Usuario Autorizado</h2>
                                <div style="margin-left: 25px">
                                    <asp:ValidationSummary ID="vSummaryUpdateUser" runat="server" ValidationGroup="UpdateUser" />
                                </div>
                                <br />
                                <label for="txtUser">
                                    Nombre:</label>
                                <asp:TextBox ID="txtUser" ClientIDMode="Static" Width="170px" runat="server" CssClass=".inputField"
                                    Enabled="False"></asp:TextBox>
                                <br />
                                <label for="txtCedulaEdit">
                                    Cédula:</label>
                                <asp:TextBox ID="txtCedulaEdit" ClientIDMode="static" Width="170px" runat="server"
                                    CssClass=".inputField" Enabled="False" MaxLength="14"></asp:TextBox>
                                <br />
                                <label for="ddlCamaraEdit">
                                    Cámara:</label>
                                <asp:DropDownList ID="ddlCamaraEdit" runat="server" CssClass=".inputField" ClientIDMode="Static"
                                    Width="175px" Enabled="False">
                                </asp:DropDownList>
                                <br />
                                <label for="ddlNoRegistroEdit">
                                    No. Registro:</label>
                                <asp:DropDownList ClientIDMode="Static" ID="ddlNoRegistroEdit" runat="server" CssClass=".inputField"
                                    Width="175px" Enabled="False">
                                </asp:DropDownList>
                                <br />
                                <div style="width: 329px; text-align: right">
                                    <asp:CheckBox ID="cbSetInactive" runat="server" CssClass=".checkBox" Text="Activo"
                                        TextAlign="Left" />
                                </div>
                                <br />
                                <div class="divSubmit">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" ValidationGroup="UpdateUser"
                                        CssClass="btn" OnClick="btnUpdate_Click" />
                                </div>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
