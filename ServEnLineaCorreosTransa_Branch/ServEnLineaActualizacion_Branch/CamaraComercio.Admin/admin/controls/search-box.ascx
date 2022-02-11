<%@ Control Language="C#" AutoEventWireup="true" Inherits="admin_controls_search_box" EnableViewState="false" Codebehind="search-box.ascx.cs" %>
<span class="userSearchForm">Nombre Usuario:</span>
<asp:TextBox ID="txbUserName" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
<span class="userSearchForm">Email:</span>
<asp:TextBox ID="txbEmail" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" /> 
<span class="userSearchMsg">
    <asp:HyperLink ID="Msg2" runat="server" Visible="False" EnableViewState="false"></asp:HyperLink>
</span>