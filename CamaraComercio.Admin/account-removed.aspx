<%@ Page Title="Account Removed" Language="C#" MasterPageFile="~/themes/default/default.master" AutoEventWireup="true" Inherits="account_removed" EnableViewState="false" Codebehind="account-removed.aspx.cs" %>
<%@ Register Src="controls/account-removed.ascx" TagName="account" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:account ID="account1" runat="server" />
</asp:Content>