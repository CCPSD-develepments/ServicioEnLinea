﻿<%@ Page Title="Membership Search" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_search_user" MaintainScrollPositionOnPostback="true" Codebehind="search-user.aspx.cs" %>

<%@ Register Src="controls/search-membership-users.ascx" TagName="search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:search ID="search1" runat="server" />
</asp:Content>
