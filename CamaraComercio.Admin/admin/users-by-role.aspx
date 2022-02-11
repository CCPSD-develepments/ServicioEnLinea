<%@ Page Title="Users By Role" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_users_by_role" MaintainScrollPositionOnPostback="true" Codebehind="users-by-role.aspx.cs" %>

<%@ Register src="controls/users-by-role.ascx" tagname="users" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:users ID="users1" runat="server" />
</asp:Content>