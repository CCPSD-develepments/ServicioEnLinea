<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/members/themes/default/default.master" AutoEventWireup="true" Inherits="members_Default" Codebehind="Default.aspx.cs" %>

<%@ Register Src="controls/membership-info.ascx" TagName="membership" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:membership ID="membership1" runat="server" />
</asp:Content>
