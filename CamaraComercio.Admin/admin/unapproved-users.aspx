<%@ Page Title="Approved / Unapproved Users" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_unapproved_users" MaintainScrollPositionOnPostback="true" Codebehind="unapproved-users.aspx.cs" %>

<%@ Register src="controls/unapproved-users.ascx" tagname="unapproved" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:unapproved ID="unapproved1" runat="server" />
</asp:Content>

