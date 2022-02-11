<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest.aspx.cs" Inherits="CamaraComercio.Website.Empresas.WebFormTest" EnableEventValidation = "false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
    
    <asp:TextBox ID ="txtValue" runat =server Width="191px"></asp:TextBox>
        <br />
        <asp:RadioButtonList ID="rbList" runat ="server">
        <asp:ListItem Text ="RM" Selected="True">        
        </asp:ListItem>
        <asp:ListItem Text ="Nombre">        
        </asp:ListItem>
<%--         <asp:ListItem Text ="RNC">        
         </asp:ListItem>--%>
         <asp:ListItem Text ="Cedula">        
         </asp:ListItem>
        </asp:RadioButtonList>
        <asp:GridView ID="rdDocumentos" runat ="server"></asp:GridView>
        <asp:Button ID="btnTest" runat="server" onclick="Button1_Click" Text="Probar" />
        <br />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" Visible ="false"/>
        <br />
        <asp:Image runat ="server" CssClass="page1 active" ImageUrl="http://content/VisorWebPaginas/9924480620b1d08f5e1af9435239b0b1f30f5b0c3_1.png" alt="" />
    </div>
    </form>
</body>
</html>
