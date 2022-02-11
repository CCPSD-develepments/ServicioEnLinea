<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirFactura.aspx.cs"
    Inherits="CamaraComercio.Website.Empresas.ImprimirFactura" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Impresion Solicitud</title>
    <link href="/res/css/stylesPrint.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="content" style="border-left-color:white; border-right-color:white;">
        <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
            <asp:View ID="v1" runat="server">
                <script type="text/javascript">
                    window.print();
                </script> 
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    
                    <tr>
                        <td colspan="2">
                            <center><img style="width:24%" src="../res/img/logo.png" /></center>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 100%; text-align: center" colspan="2">
                         <h2>
                                <asp:Label runat="server" ID="lblDireccionCamara" />
                            </h2>
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="margin-bottom:3%; border-bottom:thin">
                                 <center><asp:Label ID="lbTipoFactura" runat="server" Font-Bold="true" Font-Size="15px"></asp:Label></center>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <div class="window">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            NCF :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltNCF" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div class="window">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            Cliente :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltCliente" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Reg. Solicitado :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltRegSolicitado" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Transacción : 
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltTipoServicio" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Producto :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltProducto" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Capital Aut. :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltCapAutorizado" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal runat="server" ID="ltCapModificadoLbl" Visible="true">
                                                Cap. Modificado :
                                            </asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltCapModificado" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <div class="window">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            RNC/Ced :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltRNC" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            No. Solicitud:
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltNoTransaccion" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltFecha" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            No. Reg :
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltNoRegistro" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Caja :
                                        </td>
                                        <td>
                                            <asp:Literal ID="litCaja" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Repeater runat="server" ID="rpServicios">
                                <HeaderTemplate>
                                    <div class="window" style="width: 89%">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" width="100%">
                                            <tr>
                                                <td style="width:60%">
                                                    Servicios Solicitados
                                                </td>
                                                <td style="width:10%">
                                                    Cantidad
                                                </td>
                                                <td style="width:15%; text-align:right;">
                                                    Precio Unitario
                                                </td>
                                                <td style="width:15%; text-align:right;">
                                                    Total
                                                </td>
                                            </tr>
                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("TransaccionDetalle.Detalle")%>
                                        </td>
                                        <td>
                                            <%#Eval("TransaccionDetalle.Cantidad")%>
                                        </td>
                                        <td style="text-align:right">
                                            <%#String.Format("{0:N}", Eval("TransaccionDetalle.PrecioUnitario"))%>
                                        </td>
                                        <td style="text-align:right">
                                            <%#String.Format("{0:N}", Eval("TransaccionDetalle.Total"))%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                    <tr>
                                        <td colspan="4" >&nbsp;</td>
                                    </tr>
                                        <tr>
                                            <td colspan="3" style="text-align:right">
                                                <strong>Nota de Credito</strong>
                                            </td>
                                            <td style="text-align:right">
                                                <asp:Label ID="lblCredito" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    <tr>
                                        <td colspan="3" style="text-align:right">
                                            <strong>Total Transacción</strong>
                                        </td>
                                        <td style="text-align:right">
                                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align:right">
                                            <strong>Total a Pagar</strong>
                                        </td>
                                        <td style="text-align:right">
                                            <%#String.Format("{0:N}", Eval("TotalPagar")) %>
                                            <asp:Label ID="lblTotalNeto" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </tr>
                                        </table>
                                    </div>
                                 </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" >
                            <div style="margin-bottom:1%">

                            
                            <center><label style="font-weight:bold;font-size:15px">Documentos Enviados</label></center>
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Repeater runat="server" ID="rpDocumentosEnviados">
                                <HeaderTemplate>
                                    <div class="window" style="width:89%">
                                        <table  border="0" cellpadding="0" cellspacing="0" style="width: 100%" width="100%">
                                    <tr>
                                        <td>No.</td>
                                        <td>Documento</td>
                                        <td>Fecha Doc.</td>
                                        <td>Original</td>
                                        <td>Copia</td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("TransaccionesDocumentosId")%></td>
                                        <td><%#Eval("NombreDocumento")%></td>     
                                        <td><%#Eval("FechaEnvio")%></td>
                                        <td><%#Eval("CantidadOriginal")%></td>
                                        <td><%#Eval("CantidadCopia")%></td>
                                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                      </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <div class="window">
                                 <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            Procesador de pago:
                                        </td>
                                        <td>
                                            Azul&nbsp;</td>
                                    </tr>
                                     <tr>
                                        <td>
                                            Modo de pago:
                                        </td>
                                        <td>
                                            Tarjeta de crédito Visa
                                        </td>
                                     </tr>
                                     <tr>
                                         <td>
                                            Codigo Autorizacion:
                                        </td>
                                         <td>
                                             <asp:Literal ID="LiteralAuthCode" runat="server"></asp:Literal>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                            Tarjeta:
                                        </td>
                                         <td>
                                             <asp:Literal ID="LiteralMaskCard" runat="server"></asp:Literal>
                                         </td>
                                     </tr>
                                 </table>
                             </div>
                        </td>
                        <td>
                            <div class="window">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            Forma de Pago
                                        </td>
                                        <td style="width:15%; text-align:right;">
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                        Tarjeta de Credito
                                    </td>
                                    <td align="right">
                                        <asp:Literal ID="LiteralPagadoConTarjeta" runat="server"></asp:Literal>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                        Nota de Credito
                                    </td>
                                    <td align="right">
                                        <asp:Literal ID="LiteralPagadoConNC" runat="server"></asp:Literal>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                        Total Pagado
                                    </td>
                                    <td align="right">
                                        <asp:Literal ID="LiteralTotalPagado" runat="server"></asp:Literal>
                                    </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; " colspan="2">
                          <center>
                           <table  style="width: 95%">
                               <tr>
                                   <td align="center">
                                       <p>ACEPTO PAGAR ESTE MONTO SUJETO A LOS TERMINOS DEL CONTRATO CELEBRADO CON EL EMISOR DE LA TARJETA</p>                                      
                                   </td>
                               </tr>
                               <tr>
                                   <td colspan="2" style="background-color: #4B91AC">&nbsp;
                                   </td>
                               </tr>
                           </table>
                          </center> 
                          
                        </td>
                    </tr>
                </table>

            </asp:View>
            <asp:View ID="v2" runat="server">
                <h1>
                    No Existe Factura
                </h1>
                <p>
                    No Existe Factura asociadas a esta transacción.
                </p>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
