﻿<%@ Page Title="Select Admin Theme" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_admin_themes" MaintainScrollPositionOnPostback="true" Codebehind="admin-themes.aspx.cs" %>

<%@ Register Src="controls/admin-themes.ascx" TagName="admin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:admin ID="admin1" runat="server" />
</asp:Content>
