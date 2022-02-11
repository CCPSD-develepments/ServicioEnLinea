<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransaccionalTest.aspx.cs" Inherits="CamaraComercio.Website.TarjetaCredito.TransaccionalTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Simulación del sistema transaccional</h3>
    <div>
        <asp:Button runat="server" ID="btnPagoExitoso" Text="Pago Exitoso" 
            onclick="btnPagoExitoso_Click"/>
        &nbsp;<asp:Button runat="server" ID="btnPagoFallido" Text="Pago Fallido"/>
    </div>
    </form>
</body>
</html>
