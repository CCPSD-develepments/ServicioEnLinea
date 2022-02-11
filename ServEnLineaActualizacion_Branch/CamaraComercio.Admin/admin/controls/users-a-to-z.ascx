﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="admin_controls_users_a_to_z" Codebehind="users-a-to-z.ascx.cs" %>
<%@ Register Src="js-include2.ascx" TagName="js" TagPrefix="uc1" %>
<%@ Register Src="js-include3.ascx" TagName="js" TagPrefix="uc3" %>
<%@ Register Src="~/js/js/jquery.ascx" TagName="jquery" TagPrefix="uc4" %>
<%@ Register src="a-z-menu.ascx" tagname="a" tagprefix="uc2" %>
<%@ Register src="search-box.ascx" tagname="search" tagprefix="uc5" %>
<%-- gridview banner --%>

<%-- sidebar help js --%>
<uc3:js ID="js3" runat="server" />
<%-- jquery js --%>
<uc4:jquery ID="jquery1" runat="server" />
<%-- check allcheckboxes javascript --%>
<uc1:js ID="js1" runat="server" />



<div class="gvBanner">
    <span class="gvBannerUsers">
        <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/decoy-icon-36px.png" />
    </span>Usuarios Registrados A-Z
    <asp:Literal ID="categoryID" runat="server"></asp:Literal>
    <uc5:search ID="search1" runat="server" />
</div>
<%-- a-z repeater control --%>
<uc2:a ID="a1" runat="server" />
<%-- gridview a-z membership users --%>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="true" DataSourceID="ObjectDataSource1" DataKeyNames="userName" EmptyDataText="No se encontraron registros..." OnDataBound="GridView1_DataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" CssClass="gv">
    <Columns>
        <asp:TemplateField>
            <HeaderStyle CssClass="gvHeader" Width="1px" />
            <ItemStyle CssClass="gvHeader" Width="1px" />
        </asp:TemplateField>
        <asp:BoundField DataField="RowNumber" HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" />
        <asp:TemplateField HeaderText="Del">
            <HeaderTemplate>
                <input id="chkAll" onclick="SelectAllCheckboxes('chkRows',this.checked);" runat="server" type="checkbox" title="Seleccionar todo" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRows" runat="server" ToolTip="Seleccionar este usuario." />
            </ItemTemplate>
            <ItemStyle Width="25px" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre Usuario" SortExpression="UserName">
            <ItemTemplate>
                <span class="gvShortcut"><a href='edit_user_modal.aspx?username=<%# Eval("UserName") %>' rel="gb_page_center[850, 600]" title="Editar detalles">
                    <%# Eval("UserName") %></a></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email" SortExpression="Email">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                »: <a href='Mailto:<%# Eval("Email") %>' title="Clic para enviar email.">
                    <%#Eval("Email")%></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="createdate" HeaderText="Creada En" SortExpression="createdate" />
        <asp:BoundField DataField="lastlogindate" HeaderText="Ultimo Acceso" SortExpression="lastlogindate" />
        <asp:CheckBoxField DataField="IsApproved" HeaderText="Aprobada?" SortExpression="IsApproved">
            <ItemStyle HorizontalAlign="Center" />
        </asp:CheckBoxField>
        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Bloqueada?" SortExpression="IsLockedOut">
            <ItemStyle HorizontalAlign="Center" />
        </asp:CheckBoxField>
    </Columns>
    <RowStyle CssClass="gvRowStyle" />
    <AlternatingRowStyle CssClass="gvAlternateRowStyle" />
    <SelectedRowStyle CssClass="gvSelected" />
    <HeaderStyle CssClass="gvHeader" />
    <EditRowStyle CssClass="gvEdit" />
    <PagerTemplate>
        <div class="gvPagerFont">
            <asp:Label ID="Label2" runat="server" Text="Mostrar registros:" />
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="gvPagerFont">
                <asp:ListItem Value="5" />
                <asp:ListItem Value="10" />
                <asp:ListItem Value="15" />
                <asp:ListItem Value="20" />
                <asp:ListItem Value="40" />
                <asp:ListItem Value="80" />
                <asp:ListItem Value="1000" />
            </asp:DropDownList>
            &nbsp; Pag.
            <asp:TextBox ID="txtGoToPage" runat="server" AutoPostBack="true" OnTextChanged="GoToPage_TextChanged" Width="40px" CssClass="gvPagerFont" />&nbsp;de
            <asp:Label ID="lblTotalNumberOfPages" runat="server" />&nbsp;
            <asp:Button ID="btnFirst" runat="server" CommandName="Page" ToolTip="Primera" CommandArgument="First" Text="Primera" />
            <asp:Button ID="btnPrevious" runat="server" CommandName="Page" ToolTip="Pag. Previa" CommandArgument="Prev" Text="Prev" />
            <asp:Button ID="btnNext" runat="server" CommandName="Page" ToolTip="Pag. Proxima" CommandArgument="Next" Text="Prox" />
            <asp:Button ID="btnLast" runat="server" CommandName="Page" ToolTip="Ultima" CommandArgument="Last" Text="Ult" />
        </div>
    </PagerTemplate>
</asp:GridView>
<%-- gridview datasource  --%>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="sp_wsat_GetUsersByName" TypeName="sp_wsat_Users" OnSelected="ObjectDataSource1_Selected" EnablePaging="True" SelectCountMethod="TotalNumberOfUsersByName">
    <SelectParameters>
        <asp:Parameter Name="UserName" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<%-- panel hide items if gridview empty --%>
<asp:Panel ID="pnlHideItems" runat="server" Visible="false">
    <%-- paging information label --%>
    <div class="messageWrap">
        <asp:HyperLink ID="PagingInformation" runat="server"></asp:HyperLink>
    </div>
    <%-- total record count --%>
    <div class="messageWrap">
        <asp:HyperLink ID="totalRecordCount" runat="server"></asp:HyperLink>
    </div>
    <%-- delete selected users button --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnDeleteSelected" runat="server" OnClick="btnDeleteSelected_Click" OnClientClick="return confirm('DELETE selected users?');" ToolTip="DELETE the selected users.">Borrar</asp:LinkButton>
    </div>
    <%-- delete all membership user acounts and all related data (profiles, users from roles etc) --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="deleteAllUsers" runat="server" OnClick="deleteAllUsers_Click" ToolTip="DELETE ALL membership USERS and ALL related information." OnClientClick="return confirm('DELETE ALL membership USERS and ALL related information.? Warning! This action connot be reversed. If in doubt, backup your database first.');">Borrar Todo</asp:LinkButton>
    </div>
    <%-- approve selected users --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnApproveSelected" runat="server" OnClick="btnApproveSelected_Click" OnClientClick="return confirm('APPROVE the selected users?');" ToolTip="APPROVE the selected users." EnableViewState="False">Aprobar</asp:LinkButton>
    </div>
    <%-- approve ALL users --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnApproveAllUsers" runat="server" OnClick="btnApproveAllUsers_Click" OnClientClick="return confirm('APPROVE ALL users?');" ToolTip="APPROVE ALL users." EnableViewState="False">Aprobar Todo</asp:LinkButton>
    </div>
    <%-- unapprove selected users --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnUnApproveSelected" runat="server" OnClick="btnUnApproveSelected_Click" OnClientClick="return confirm('UNAPPROVE the selected users?');" ToolTip="UNAPPROVE the selected users." EnableViewState="False">No Aprobar</asp:LinkButton>
    </div>
    <%-- unapprove ALL users --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnUnapproveAllUsers" runat="server" OnClick="btnUnapproveAllUsers_Click" OnClientClick="return confirm('UNAPPROVE ALL users?');" ToolTip="UNAPPROVE ALL users." EnableViewState="False">No Aprobar Todo</asp:LinkButton>
    </div>
    <%-- unlock selected users --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnUnlockSelected" runat="server" OnClick="btnUnlockSelected_Click" OnClientClick="return confirm('UNLOCK the selected users?');" ToolTip="UNLOCK the selected users." EnableViewState="False">Desbloquear</asp:LinkButton>
    </div>
    <%-- unlock ALL users --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnUnlockAllUsers" runat="server" OnClick="btnUnlockAllUsers_Click" OnClientClick="return confirm('UNLOCK ALL users?');" ToolTip="UNLOCK ALL users." EnableViewState="False">Desbloquear Todo</asp:LinkButton>
    </div>
    <%-- remove all users from all roles --%>
    <div class="buttonCSS">
        <asp:LinkButton ID="btnRemoveAllUsersFromAllRoles" runat="server" OnClick="btnRemoveAllUsersFromAllRoles_Click" OnClientClick="return confirm('REMOVE ALL USERS from ALL ROLES?');" ToolTip="REMOVE ALL users from ALL ROLES." EnableViewState="False">Remover Todo</asp:LinkButton>
    </div>
    <%-- add users to selected role --%>
    <div class="ddlWrap">
        <asp:DropDownList ID="ddlAddUsersToRole" runat="server" AutoPostBack="True" DataSourceID="RolesDataSource" DataTextField="RoleName" DataValueField="RoleName" AppendDataBoundItems="True" EnableViewState="False" Font-Size="11px" OnSelectedIndexChanged="ddlAddUsersToRole_SelectedIndexChanged" ToolTip="ADD selected users to selected ROLE.">
            <asp:ListItem Selected="True">Agregar A</asp:ListItem>
        </asp:DropDownList>
    </div>
    <%-- add all users to selected role --%>
    <div class="ddlWrap">
        <asp:DropDownList ID="ddlAddAllUsersToRole" runat="server" AutoPostBack="True" DataSourceID="RolesDataSource" DataTextField="RoleName" DataValueField="RoleName" AppendDataBoundItems="True" EnableViewState="False" Font-Size="11px" OnSelectedIndexChanged="ddlAddAllUsersToRole_SelectedIndexChanged" ToolTip="ADD ALL users to selected ROLE.">
            <asp:ListItem Selected="True">Agregar Todo A</asp:ListItem>
        </asp:DropDownList>
    </div>
    <%-- remove users from selected role --%>
    <div class="ddlWrap">
        <asp:DropDownList ID="ddlRemoveUsersFromRole" runat="server" AutoPostBack="True" DataSourceID="RolesDataSource" DataTextField="RoleName" DataValueField="RoleName" AppendDataBoundItems="True" EnableViewState="False" Font-Size="11px" OnSelectedIndexChanged="ddlRemoveUsersFromRole_SelectedIndexChanged" ToolTip="REMOVE selected users from selected ROLE.">
            <asp:ListItem Selected="True">Remover De</asp:ListItem>
        </asp:DropDownList>
    </div>
    <%-- remove all users from selected role --%>
    <div class="ddlWrap">
        <asp:DropDownList ID="ddlRemoveAllUsersFromRole" runat="server" AutoPostBack="True" DataSourceID="RolesDataSource" DataTextField="RoleName" DataValueField="RoleName" AppendDataBoundItems="True" EnableViewState="False" Font-Size="11px" OnSelectedIndexChanged="ddlRemoveAllUsersFromRole_SelectedIndexChanged" ToolTip="REMOVE ALL users from selected ROLE.">
            <asp:ListItem Selected="True">Remover Todo De</asp:ListItem>
        </asp:DropDownList>
    </div>
    <%-- delete all users from selected role --%>
    <div class="ddlWrap">
        <asp:DropDownList ID="ddlDeleteAllUsersFromRole" runat="server" AutoPostBack="True" DataSourceID="RolesDataSource" DataTextField="RoleName" DataValueField="RoleName" AppendDataBoundItems="True" EnableViewState="False" Font-Size="11px" OnSelectedIndexChanged="ddlDeleteAllUsersFromRole_SelectedIndexChanged" ToolTip="DELETE ALL user accounts present in the selected ROLE.">
            <asp:ListItem Selected="True">Borrar Todo De</asp:ListItem>
        </asp:DropDownList>
    </div>
    <%-- dropdown list datasource --%>
    <asp:ObjectDataSource ID="RolesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="wsat_GetRoles" TypeName="wsat_RolesTableAdapter"></asp:ObjectDataSource>
</asp:Panel>
<%-- a div padding between buttons and label --%>
<div class="padding"></div>
<%-- message label --%>
<div class="messageWrap">
    <asp:HyperLink ID="Msg" runat="server" Visible="False" EnableViewState="false"></asp:HyperLink>
</div>
<%-- help sidebar --%>

