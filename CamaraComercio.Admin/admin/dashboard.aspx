<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" Inherits="admin_dashboard" Codebehind="dashboard.aspx.cs" %>

<%@ Register Src="controls/dashboard.ascx" TagName="dashboard" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:dashboard ID="dashboard1" runat="server" />
</asp:Content>
