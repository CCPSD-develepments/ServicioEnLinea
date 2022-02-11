<%@ Page Title="Edit Admin Themes" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_admin_edit_themes" MaintainScrollPositionOnPostback="true" Codebehind="admin-edit-themes.aspx.cs" %>

<%@ Register Src="controls/admin-edit-themes.ascx" TagName="admin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:admin ID="admin1" runat="server" />
</asp:Content>