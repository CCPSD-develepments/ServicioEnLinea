<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="VerMensaje.aspx.cs" Inherits="CamaraComercio.Website.Empresas.VerMensaje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mensajes</title>
    <!-- Estilos -->
    <link href="/res/css/Mensajes.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <h1><asp:Label runat="server" id="lblMensajeTitulo" /></h1>
    <hr />
    <asp:MultiView runat="server" ID="mvMensajes">
        <asp:View runat="server" ID="vError">
          <p>
            Ha ocurrido un error al intentar visualizar este mensaje. Por favor intente más tarde. 
          </p>  
        </asp:View>

        <asp:View runat="server" ID="vMensaje">
            
            <table>
                <tr>
                    <td class="firstColumn">
                        <strong>Enviado por</strong></td>
                    <td>
                        <asp:Label runat="server" ID="lblEnviadoPor" /></td>
                </tr>
                <tr>
                    <td class="firstColumn">
                        <strong>Fecha</strong></td>
                    <td>
                        <asp:Label runat="server" ID="lblFecha" /></td>
                </tr>
                <tr>
                    <td class="firstColumn">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="lblMensaje" Text="Mensajes"/> </td>
                </tr>
            </table>
            
        </asp:View>
    </asp:MultiView>
    </form>
</body>
</html>
