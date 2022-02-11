<%@ Page Title="Locked Out Users" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_locked_users" MaintainScrollPositionOnPostback="true" Codebehind="locked-users.aspx.cs" %>

<%@ Register Src="controls/users-locked-out.ascx" TagName="users" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:users ID="users1" runat="server" />
</asp:Content>
