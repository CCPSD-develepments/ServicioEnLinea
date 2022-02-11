<%@ Page Title="Email Broadcast" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_email_broadcast" ValidateRequest="false" Codebehind="email-broadcast.aspx.cs" %>

<%@ Register Src="controls/email-broadcast.ascx" TagName="email" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:email ID="email1" runat="server" />
</asp:Content>