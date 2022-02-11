<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CamaraComercio.Website.TarjetaCredito.Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../res/css/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="background-color:grey">
          <div id="tools" style="text-align:right;padding-right:5px;padding-top:2px;">
            <button id="btPrint" class="btn btn-primary">
                Imprimir
            </button>
            <button id="btExit" class="btn btn-default">
                Salir
            </button>
        </div>
    <form id="form1" runat="server">
  
        <div id="invoice" style="background-color:white;width:40%;margin:auto;">
            <div id="invoiceHeader" style="text-align:center">
                <h3>Camara de comercio</h3>
                <p>
                  Facura comercial  
                </p>
            </div>
            <div id="invoiceBody">
               <ul style="list-style:none">
                  <li>
                    <label>No. Registro: </label><asp:Label runat="server" id="lbRegistroNo" ></asp:Label>
                  </li>
                 <li>
                    <label>Denominaci&oacute;n/Reaz&oacute;n Social: </label><asp:Label runat="server" id="lbDenominacion" ></asp:Label>
                  </li>
                   <li>
                    <label>Tipo de empresa: </label><asp:Label runat="server" id="lbTipoDeEmpresa" ></asp:Label>
                  </li>
                   
                   <li>
                     <div style="margin-top:4%;">
                           <asp:Panel ID="pnlDetalles" runat="server">
                            <asp:Repeater runat="server" id="rpDetalles" >
                           <HeaderTemplate>
                               <table class="table" style="width:92%">
                               <thead>
                                   <tr>
                                       <th>Detalle</th>
                                    <th style="text-align:right;">Costo</th>
                                   </tr>
                                   <tbody>
                               </thead>
                           </HeaderTemplate>
                           <ItemTemplate>
                               <tr>
                                   <td>
                                       <asp:Label ID="lblNombreServicio" runat="server" Text='<%#Eval("Descripcion") %>'/>
                                   </td>
                                     <td style="text-align: right">
                                            <asp:Label ID="txtCosto" runat="server" Text='<%# String.Format("{0:n}", Eval("Costo")) %>'
                                                ReadOnly="true" Width="60px"></asp:Label>
                                        </td>
                               </tr>
                           </ItemTemplate>
                           <FooterTemplate>
                               </tbody>
                               <tfoot>
                                   <tr>
                                            <td style="text-align: right; font-weight: bold">
                                                <div class="subtotal" style="text-align: right">
                                                    <asp:Label ID="lblCostoTotal" runat="server" AssociatedControlID="txtCostoTotalTransaccion"
                                                        Text="Total Transacción:" />
                                                </div>
                                            </td>
                                            <td style="text-align: right; font-weight: bold">
                                                <asp:Label runat="server" ID="txtCostoTotalTransaccion" Text='<%# String.Format("{0:n}", Eval("CostoTotal")) %>'></asp:Label>
                                            </td>
                                        </tr>
                               </tfoot>
                                </table>
                           </FooterTemplate>
                       </asp:Repeater>
                       </asp:Panel>
                     </div>
                   </li>
                </ul>
            </div>
            <div id="invoiceFooter">

            </div>
            
        </div>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(function () {
            $("body").on("click", "#btPrint", function (event) {
                    event.preventDefault();
                printDiv("invoice");
            })

                $("body").on("click", "#btExit", function (event) {
                    event.preventDefault();
                    window.location = "/Empresas/Oficina.aspx";
            })
        })
    function printDiv(nombreDiv) {
         var contenido= document.getElementById(nombreDiv).innerHTML;
         var contenidoOriginal= document.body.innerHTML;

         document.body.innerHTML = contenido;

         window.print();

         document.body.innerHTML = contenidoOriginal;
}
    </script>
</body>
</html>
