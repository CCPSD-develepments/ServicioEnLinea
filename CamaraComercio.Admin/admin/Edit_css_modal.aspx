<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_Edit_css_modal" ValidateRequest="false" Codebehind="Edit_css_modal.aspx.cs" %>

<%@ Register Src="controls/admin-edit-css-modal.ascx" TagName="admin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSS Details</title>
    <link href="themes/default/default.css" rel="stylesheet" type="text/css" />
</head>
<body class="modalPG">
    <form id="form1" runat="server">
    <uc1:admin ID="admin1" runat="server" />
    </form>
</body>
</html>
