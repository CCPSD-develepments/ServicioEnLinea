<%@ Page Title="Users A-Z" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" 
Inherits="admin_users_a_z" MaintainScrollPositionOnPostback="true" Codebehind="users-a-z.aspx.cs" %>

<%@ Register Src="controls/users-a-to-z.ascx" TagName="users" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <!-- Javascript Plugins -->
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fbLink').fancybox();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:users ID="users1" runat="server" />
</asp:Content>
