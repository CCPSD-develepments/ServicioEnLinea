<%--<%@ Page Title="Login" Language="C#" MasterPageFile="~/themes/default/default.master" AutoEventWireup="true" Inherits="login" EnableViewState="false" Codebehind="login.aspx.cs" %>--%>
<%@ Register Src="controls/login-with-captcha.ascx" TagName="LoginWithCaptcha" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="robots" content="NOINDEX, NOFOLLOW"/>
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.captcha input').attr('autocomplete', 'off')
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:LoginWithCaptcha ID="LoginWithCaptcha1" runat="server" />
</asp:Content>