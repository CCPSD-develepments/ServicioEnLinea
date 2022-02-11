<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorWeb.aspx.cs" Inherits="CamaraComercio.Website.Empresas.VisorWeb" %>
<%@ Register Src="~/Kofax/WebDocumentViewer.ascx" TagName="Kofax" TagPrefix="ucKofax" %>
<%--<link href="../Kofax/Site.css"rel="stylesheet" type="text/css" />--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Kofax/Print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="../Kofax/Site.css" rel="stylesheet" type="text/css" media="screen" />
    <script src ="/res/js/jquery-1.4.1.js" type ="text/javascript"> </script>
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>

</head>
<body oncontextmenu="return false;">
    <form id="form1" runat="server">
       <div class="header">
       <asp:Label ID ="lblCount" Text ="1 / 0" runat ="server" Font-Size="Medium"></asp:Label>
        &nbsp &nbsp
            <asp:Button runat ="server" ID ="btnBack" Text ="Anterior" onclick="btnBack_Click" />
            <asp:Button runat ="server" ID ="btnNext" Text ="Siguiente"  onclick="btnNext_Click" />
       </div>
    <br />
        <div>
        <telerik:RadBinaryImage  runat ="server" ID ="binaryImage" />
        </div>
    </form>
</body>
</html>
