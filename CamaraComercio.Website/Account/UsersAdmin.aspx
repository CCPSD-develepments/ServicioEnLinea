<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="UsersAdmin.aspx.cs" Inherits="CamaraComercio.Website.Account.UsersAdmin" %>

<%@ Import Namespace="CamaraComercio.Website" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Oficina Virtual - Administración de Usuarios</title>

    <link href="/res/js/tipsy/tipsy.css" rel="stylesheet" type="text/css" />

    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/tipsy/jquery.tipsy.js" type="text/javascript"></script>
    <script src="http://digitalbush.com/wp-content/uploads/2013/01/jquery.maskedinput-1.3.1.min_.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //Navegación
            $('#navigation li').removeClass("active");
            $('#liGestores').addClass("active");

            $('#subnavigation li').removeClass("active");
            $('#liOficina').addClass("active");

            //Validaciones de textboxes
            $(".cedula").numeric();

            //Ayuda y comentarios de campos
            $(".tipsyBox").tipsy({ trigger: 'focus', gravity: 'w', opacity: 0.8 });
            $('#txtTelefono').mask('(999) 999-9999');

        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    <asp:Label ID="lblUsuarioPadre" runat="server" Text="[Empresa]" />
                    - Gestor Administrador
                </h1>
            </div>
            <div id="content_body">
                <div>
                    <div style="text-align: right;">
                        <%--<a href="ChangeAdmin.aspx" style="float:right; margin-left: 6px" class="botoncillo">
                            Cambiar Administrador
                        </a>--%>

                        <asp:LinkButton ID="lbAddUser" runat="server" OnClick="lbAddUser_Click" Style="float: right;" CssClass="botoncillo">
                            Agregar nuevo gestor
                        </asp:LinkButton>

                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        </telerik:RadScriptManager>

                        <asp:HiddenField ID="hfCurrentUser" runat="server" />
                        <br />
                        <br />
                    </div>
                    <div>
                        Ver gestores:
                        <asp:LinkButton runat="server" ID="lnkActivos" Text="Activos" OnClick="lnkActivos_Click"
                            Font-Bold="True" />
                        &nbsp;<asp:LinkButton runat="server" ID="lnkInactivos" Text="Inactivos" OnClick="lnkInactivos_Click" />
                        <asp:HiddenField runat="server" ID="hfVerActivos" />


                        <telerik:RadGrid ID="gvUsers" runat="server" AutoGenerateColumns="False" GridLines="None"
                            DataSourceID="odsUsers" OnItemCommand="gvUsers_ItemCommand">
                            <ClientSettings EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView DataSourceID="odsUsers">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Nombre Gestor" UniqueName="NombreSolicitante"
                                        DataField="NombreSolicitante">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Correo Electrónico" UniqueName="Email" DataField="Email">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Nombre Usuario" UniqueName="UserName" DataField="UserName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Teléfono" UniqueName="Phone" DataField="Phone">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Extensión" UniqueName="Extension" DataField="Extension">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridCheckBoxColumn DataField="IsApproved" HeaderText="Verificado" UniqueName="column">
                                    </telerik:GridCheckBoxColumn>
                                    <telerik:GridHyperLinkColumn Text="Empresas" UniqueName="lnkActions" DataNavigateUrlFields="UserName"
                                        DataNavigateUrlFormatString="~/Empresas/EmpresasPorGestores.aspx?UserName={0}">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridHyperLinkColumn Text="Gestiones Activas" UniqueName="lnkActions" DataNavigateUrlFields="UserName"
                                        DataNavigateUrlFormatString="~/Empresas/TransaccionesGestor.aspx?UserName={0}">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>


                        <asp:ObjectDataSource ID="odsUsers" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchByUsuarioPadre" TypeName="CamaraComercio.DataAccess.EF.Membership.UsuariosController">
                            <SelectParameters>
                                <asp:Parameter Name="usuarioPadre" Type="String" />
                                <asp:ControlParameter ControlID="hfVerActivos" DefaultValue="true" Name="traerActivos"
                                    PropertyName="Value" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <br />
                    <asp:MultiView ID="mvUsers" runat="server" ActiveViewIndex="0">
                        <asp:View runat="server" ID="ViewManageUsers">
                            <fieldset>
                                <h2>Administración de Gestores</h2>
                                <div style="padding: 10px">
                                    <p>
                                        Esta sección del portal permite al gestor administrador definir cuales gestores 
                                        operativos están autorizados para que lo asistan en el proceso de creación y 
                                        modificación de Empresas/Sociedades.
                                    </p>
                                    <br />
                                    <ul>
                                        <li>Para agregar un nuevo gestor, haga clic en el enlace
                                            <asp:LinkButton ID="lbNewUserDesc" runat="server"
                                                OnClick="lbAddUser_Click" Text="Agregar nuevo gestor " />
                                            en la esquina superior derecha. </li>
                                        <li>Para modificar o desactivar un gestor, seleccione a la persona y haga click de
                                            la lista de usuarios.</li>
                                    </ul>
                                </div>
                        </asp:View>
                        <asp:View runat="server" ID="ViewNewUser">
                            <fieldset>
                                <h2>Agregar nuevo gestor</h2>
                                <div style="margin-left: 25px">
                                    <asp:ValidationSummary ID="vSummaryNewUser" runat="server" ValidationGroup="NewUser" />
                                </div>
                                <ul>
                                    <li>
                                        <label for="txtNewUser">
                                            Nombre usuario:</label>
                                        <asp:TextBox ID="txtNewUser" style="text-transform:lowercase;" runat="server" CssClass="tb tipsyBox" original-title="Nombre del usuario. Debe ser único." />
                                        <asp:RequiredFieldValidator ID="rfvUser" runat="server" Text="*" Display="Dynamic"
                                            CssClass="validator" ControlToValidate="txtNewUser" ValidationGroup="NewUser"
                                            ErrorMessage="El campo Nombre usuario es requerido."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revUsuario" runat="server" ControlToValidate="txtNewUser"
                                            CssClass="validator" ValidationGroup="NewUser" ErrorMessage="El campo Nombre usuario contiene valores no validos."
                                            ValidationExpression="^\D[0-9-a-zA-Z]*\.?[0-9-a-zA-Z]*[^.]{4,128}$" Display="Dynamic"
                                            ClientIDMode="AutoID" ToolTip="El campo Nombre usuario contiene valores no validos.">*</asp:RegularExpressionValidator>
                                        <asp:CustomValidator ID="cvUsername" runat="server" Text="*" ControlToValidate="txtNewUser"
                                            CssClass="validator" ErrorMessage="El nombre de usuario ya existe, ingrese un nombre de usuario distinto."
                                            OnServerValidate="cvUsername_ServerValidate" ValidationGroup="NewUser" Display="Dynamic"></asp:CustomValidator>
                                    </li>
                                    <li>
                                        <label for="txtNewEmail">
                                            Correo electrónico:</label>
                                        <asp:TextBox ID="txtNewEmail" style="text-transform:lowercase;" runat="server" CssClass="tb tipsyBox"
                                            original-title="Correo electrónico del usuario. A esta dirección se enviará el mensaje de confirmación" />
                                        <asp:RequiredFieldValidator ID="rvfNewEmail" runat="server" Text="*" ControlToValidate="txtNewEmail"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="El campo Email es requerido."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revNewEmail" runat="server" ControlToValidate="txtNewEmail"
                                            ValidationGroup="NewUser" ErrorMessage="El formato del correo electrónico es incorrecto."
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                            CssClass="validator" ClientIDMode="AutoID" ToolTip="El formato del correo electrónico es incorrecto.">*</asp:RegularExpressionValidator>
                                        <asp:CustomValidator ID="cvEmail" runat="server" Display="Dynamic" ValidationGroup="NewUser"
                                            CssClass="validator" Text="*" ErrorMessage="El correo electrónico ya existe en el sistema, intente con otro."
                                            OnServerValidate="cvEmail_ServerValidate"></asp:CustomValidator>
                                    </li>
                                    <li>
                                        <label for="txtConfirmNewEmail">
                                            Confirmar Correo electrónico:</label>
                                        <asp:TextBox ID="txtConfirmNewEmail" runat="server" CssClass="tb tipsyBox" style="text-transform:lowercase;"
                                            original-title="Confirmar Correo electrónico del usuario. A esta dirección se enviará el mensaje de confirmación" />
                                        <asp:RequiredFieldValidator ID="rvfcustomnewemail" runat="server" Text="*" ControlToValidate="txtconfirmnewemail"
                                            CssClass="validator" Display="dynamic" ValidationGroup="newuser" ErrorMessage="el campo confirmar email es requerido."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revconfirmnewemail" runat="server" ControlToValidate="txtconfirmnewemail"
                                            ValidationGroup="newuser" ErrorMessage="el formato del correo electrónico de confirmación es incorrecto."
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="dynamic"
                                            CssClass="validator" ClientIDMode="autoid" ToolTip="el formato del correo electrónico es incorrecto.">*</asp:RegularExpressionValidator>
                                        <asp:CompareValidator runat="server" ID="cvalEmail" ControlToValidate="txtNewEmail"
                                            ControlToCompare="txtConfirmNewEmail" Display="Dynamic" ValidationGroup="NewUser"
                                            ErrorMessage="Los correos no coinciden" Text="*" CssClass="validator" />
                                    </li>
                                    <li>
                                        <label for="txtNewFullName">
                                            Nombre completo:</label>
                                        <asp:TextBox ID="txtNewFullName" runat="server" CssClass="tb tipsyBox" original-title="Nombres y apellidos del usuario" />
                                        <asp:RequiredFieldValidator ID="rfvNewFullName" runat="server" Text="*" ControlToValidate="txtNewFullName"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="El campo Nombre completo es requerido." />
                                    </li>
                                    <li>
                                        <label for="ddlTipoDocumento">Tipo Documento:</label>
                                        <asp:DropDownList runat="server" ID="ddlTipoDocumento" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDocumento_SelectedIndexChanged">
                                            <asp:ListItem Value="C">Cédula</asp:ListItem>
                                            <asp:ListItem Value="P">Pasaporte</asp:ListItem>
                                        </asp:DropDownList></li>
                                    <li>
                                        <label for="txtCedula">
                                            Número Documento:
                                        </label>
                                        <asp:TextBox runat="server" ID="txtCedula"
                                            CssClass="tb cedula tipsyBox" ClientIDMode="Static" MaxLength="11"
                                            original-title="Número de cédula o identificación del usuario. No usar espacios o guiones, solo números" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvTxtCedula" Text="*" ControlToValidate="txtCedula"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="Debe indicar la cédula del usuario" />
                                    </li>
                                    <li>
                                        <label for="txtPassword">
                                            Contraseña:
                                        </label>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ClientIDMode="Static"
                                            CssClass="tb tipsyBox" original-title="Contraseña. Debe tener al menos 8 caracteres, una mayúscula, una minúscula y un dígito" />
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Text="*" ControlToValidate="txtPassword"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="Se requiere especificar una contraseña" />
                                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="La contraseña debe tener al menos 8 caracteres,  una mayúscula una minúscula y un dígito."
                                            ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" Display="Dynamic"
                                            CssClass="validator summary" ValidationGroup="NewUser">*</asp:RegularExpressionValidator>
                                    </li>
                                    <li>
                                        <label for="txtConfirmPassword">
                                            Confirmar:
                                        </label>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" ClientIDMode="Static"
                                            CssClass="tb tipsyBox" original-title="Repita la misma contraseña" />
                                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" Text="*" ControlToValidate="txtConfirmPassword"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="Repita la contraseña" />
                                        <asp:CompareValidator runat="server" ID="cvalPassword" ControlToValidate="txtPassword"
                                            ControlToCompare="txtConfirmPassword" Display="Dynamic" ValidationGroup="NewUser"
                                            ErrorMessage="Las contraseñas no coinciden" Text="*" CssClass="validator" />
                                    </li>
                                    <li>
                                        <label for="chkFirmaDigita">Tiene Firma Digital?</label>
                                        <asp:CheckBox ID="chkFirmaDigita" runat="server" CssClass="validator" />

                                    </li>
                                    <li>
                                        <label for="txtTelefono">
                                            Teléfono:
                                        </label>

                                        <asp:TextBox runat="server" ID="txtTelefono"
                                            CssClass="tb tipsyBox" ClientIDMode="Static" 
                                            original-title="Número de teléfono del usuario. No usar espacios o guiones, solo números" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvTelefono" Text="*" ControlToValidate="txtTelefono"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="Debe indicar el número de teléfono del usuario" />
                                    </li>
                                    <li>
                                        <label for="txtExtension">
                                            Extensión:
                                        </label>
                                        <asp:TextBox runat="server" ID="txtExtension"
                                            CssClass="tb tipsyBox" ClientIDMode="Static" original-title="Extensión. No usar espacios o guiones, solo números" />
                                    </li>
                                </ul>
                                <div class="divSubmit">
                                    <asp:Button ID="btnNewCancel" runat="server" Text="Cancelar" CssClass="btn"
                                        OnClick="btnNewCancel_Click" />
                                    <asp:Button ID="btnNewInsert" runat="server" Text="Agregar" CssClass="btn"
                                        OnClick="btnNewInsert_Click" ValidationGroup="NewUser" />
                                    <asp:Label ID="lblResultado" ForeColor="Green" Font-Bold="true" runat="server" Text=""></asp:Label>
                                    <div class="clear" />
                                </div>

                                <div>
                                    <asp:ValidationSummary ID="errorbox" ClientIDMode="Static" runat="server" ValidationGroup="NewUser" />
                                    <div class="clear" />
                                </div>
                            </fieldset>
                        </asp:View>
                        <asp:View runat="server" ID="viewUpdateUser">
                            <fieldset>
                                <h2>Edición de Perfil</h2>
                                <div style="margin-left: 25px">
                                    <asp:ValidationSummary ID="vSummaryUpdateUser" runat="server" ValidationGroup="UpdateUser" />
                                </div>
                                <ul>
                                    <li>
                                        <label for="txtUser">
                                            Nombre usuario:</label>
                                        <asp:Label ID="txtUser" runat="server"></asp:Label>
                                    </li>
                                    <li>
                                        <label for="txtEmail">
                                            Correo electrónico:</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="tb tipsyBox" style="text-transform:lowercase;"
                                            original-title="Correo electrónico del usuario" Enabled="False" />
                                    </li>
                                    <li>
                                        <label for="txtFullName">
                                            Nombre completo:</label>
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="tb tipsyBox"
                                            original-title="Nombres y apellidos del usuario" />
                                        <asp:RequiredFieldValidator ID="rfvFullName" runat="server" Text="*" ControlToValidate="txtFullName"
                                            Display="Dynamic" ValidationGroup="UpdateUser" CssClass="validator" ErrorMessage="El campo Nombre completo es requerido."></asp:RequiredFieldValidator>
                                    </li>
                                        <asp:UpdatePanel ID="udpViewUpdateUser" runat="server">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlTipoDocumentoUpdate" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <li>
                                                    <label for="ddlTipoDocumentoEdit">Tipo Documento:</label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoDocumentoUpdate" ClientIDMode="Static" OnSelectedIndexChanged="ddlTipoDocumentoUpdate_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="C">Cédula</asp:ListItem>
                                                        <asp:ListItem Value="P">Pasaporte</asp:ListItem>
                                                    </asp:DropDownList>
                                                </li>
                                                <li>
                                                    <label for="txtCedulaEdit">
                                                        Cédula de Identidad:
                                                    </label>
                                                    <telerik:RadMaskedTextBox runat="server" ID="txtCedulaEdit" 
                                                        CssClass="tb cedula tipsyBox" ClientIDMode="Static" MaxLength="11"
                                                        original-title="Número de cédula o identificación del usuario. No usar espacios o guiones, solo números">

                                                    </telerik:RadMaskedTextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvTxtCedulaEdit" Text="*" ControlToValidate="txtCedulaEdit"
                                                        CssClass="validator" Display="Dynamic" ValidationGroup="UpdateUser" ErrorMessage="Debe indicar la cédula del usuario" />
                                                </li>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    <li>
                                        <label for="txtTelefonoEdit">
                                            Teléfono:
                                        </label>
                                        <asp:TextBox runat="server" ID="txtTelefonoEdit"
                                            CssClass="tb tipsyBox" ClientIDMode="Static" MaxLength="10"
                                            original-title="Número de teléfono del usuario. No usar espacios o guiones, solo números" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvTxtTelefonoEdit" Text="*" ControlToValidate="txtTelefonoEdit"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="Debe indicar el número de teléfono del usuario" />
                                    </li>
                                    <li>
                                        <label for="txtExtensionEdit">
                                            Extensión:
                                        </label>
                                        <asp:TextBox runat="server" ID="txtExtensionEdit"
                                            CssClass="tb tipsyBox" ClientIDMode="Static" original-title="Extensión. No usar espacios o guiones, solo números" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvTxtExtensionEdit" Text="*" ControlToValidate="txtExtensionEdit"
                                            CssClass="validator" Display="Dynamic" ValidationGroup="NewUser" ErrorMessage="Debe indicar el número de extension del usuario" />
                                    </li>
                                    <li>
                                        <asp:CheckBox ID="cbSetInactive" runat="server" CssClass=".checkBox" Text="Activo" Checked="true" />
                                    </li>
                                </ul>
                                <div class="divSubmit">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn"
                                        OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" ValidationGroup="UpdateUser"
                                        CssClass="btn" OnClick="btnUpdate_Click" />
                                    <div class="clear" />
                                </div>

                                <div>
                                    <asp:ValidationSummary ID="ValidationSummary1" class="errorbox"
                                        ClientIDMode="Static" runat="server" ValidationGroup="UpdateUser" />
                                    <div class="clear" />
                                </div>

                                <br />
                                <h2>Actividades del Gestor Operativo</h2>
                                <telerik:RadGrid ID="gvUserActivities" runat="server" AutoGenerateColumns="False"
                                    GridLines="None">
                                    <ClientSettings>
                                    </ClientSettings>
                                    <MasterTableView>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn>
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="CamaraId" HeaderText="Cámara de Comercio" UniqueName="Empresa1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroRegistro" HeaderText="NoRegistro" UniqueName="Empresa2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Empresa/Sociedad" UniqueName="Empresa">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreServicio" HeaderText="Operación" UniqueName="Operacion">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha" UniqueName="Fecha">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <telerik:RadGrid ID="rgridHistorico" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    OnItemDataBound="RgridHistoricoItemDataBound" AllowPaging="True" AllowSorting="True">
                                    <MasterTableView>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn>
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="Fecha" UniqueName="FechaSolicitud" DataField="Fecha"
                                                DataFormatString="{0:dd/MM/yyyy}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="NombreCamara" HeaderText="Cámara" UniqueName="CamaraID">
                                                <ItemTemplate>
                                                    <asp:Label ID="NombreCamaraLabel" runat="server" Text='<%# Eval("CamaraID") %>' ToolTip='<%# Eval("Camaras.Nombre") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn HeaderText="Sociedad" UniqueName="Sociedad" DataField="NombreSocialPersona">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Solicitud" UniqueName="Solicitud" DataField="Servicio.Nombre">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado">
                                                <ItemTemplate>
                                                    <asp:Image ID="EstadoImg" runat="server" ImageUrl='<%# Eval("EstatusTransId") != null ? new StatusIconHelper().GetStatusIcon(Convert.ToInt32(Eval("EstatusTransId"))) : "/res/img/icons/bullet_white.png" %>'
                                                        ToolTip='<%# Eval("EstatusTransacciones.EstatusTransaccion") %>' />
                                                    <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("EstatusTransacciones.EstatusTransaccion") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkHistoricoActions">
                                            </telerik:GridHyperLinkColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                                </telerik:RadGrid>
                            </fieldset>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
    <script type="text/javascript" language="javascript">
        $(Document).ready(
            function () {
                document.getElementById('ddlTipoDocumento').addEventListener('onchange', function () {
                    if ($('ddlTipoDocumento').SelectedValue == "C") {
                        $('#txtCedulaEdit').setAttribute('MaxLength', "11");
                        $('#txtCedulaEdit').Text = String.Empty;
                        $('#txtCedulaEdit').addClass("cedula");
                    }
                    else if ($('ddlTipoDocumento').SelectedValue == "P") {

                        $('#txtCedulaEdit').setAttribute('MaxLength', "15");
                        $('#txtCedulaEdit').Text = String.Empty;

                        if ($('#txtCedulaEdit').hasClass("cedula")) {
                            $('#txtCedulaEdit').removeClass("cedula");
                        }
                    }
                });
            }
        );
    </script>
</asp:Content>
