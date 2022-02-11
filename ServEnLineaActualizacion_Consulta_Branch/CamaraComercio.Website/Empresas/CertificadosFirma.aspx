<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/res/nobox.master"  CodeBehind="CertificadosFirma.aspx.cs" 
    Inherits="CamaraComercio.Website.Empresas.CertificadosFirma" %>


<%--<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="CertificadosFirma.aspx.cs" Inherits="CamaraComercio.Website.Empresas.CertificadosFirma" %>--%>




<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header" style="display:table; width:100%;">
                <%--     <div class="infoBox">
                                <div class="infoContent">
                                    <asp:LinkButton ID="hlRenovacionSimple" runat="server" Text="Renovación Simple" CssClass="btn"
                                        Style="float: none;" ClientIDMode="Static"></asp:LinkButton>
                                    <p>
                                        Selecciona esta opción si deseas renovar la empresa sin cambiar la información 
                                        existente en el Registro Mercantil.
                                    </p>
                                </div>
                            </div>--%>
                <div id="" style="display:table-cell; min-width:375px; vertical-align:middle">
                    <h1 >
                        Certificados de Firma Digital
                    </h1>
                </div>
                <div class="right normal" style="display:table-cell; padding-left:30px; color:#00587C; text-align:right; vertical-align:middle">
                    <asp:Label ID="litNombreEmpresaTitM" CssClass="right normal"  runat="server" style="font-size: 2.3em; text-align:right; width:100%;"></asp:Label>
                </div>
            </div>
            <div id="content_body">
                <asp:MultiView runat="server" ID="mvRenovacion" ActiveViewIndex="1">
                
                    <asp:View runat="server" ID="vRenovacion">

       


                     
                        <div id="divFormasEntregaWrapper" style="text-align: center">

                          



                            <br />
                          
                            <br /><br />
                        </div>
                    </asp:View>


                    <asp:View ID="vNoExiste" runat="server">


                        <asp:Panel ID="Panel1" runat="server">
                         


                   <asp:Label ID="Label1" runat="server" Text="Tipo de servicio : "></asp:Label>
                            <asp:DropDownList ID="ddltipoproducto" runat="server">
                                <asp:ListItem Value="1">Nueva Emisión</asp:ListItem>
                                <asp:ListItem Value="2">Renovación</asp:ListItem>
                            </asp:DropDownList>

                        <!--                        <h2><a href="/Empresas/Oficina.aspx">Retornar a la página de inicio</a></h2>-->
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:Label ID="Label2" runat="server" Text="Validez : "></asp:Label>
                                             <asp:DropDownList ID="ddltiempo" runat="server">
                                                  <asp:ListItem Value="1">Un (1) año</asp:ListItem>
                                                  <asp:ListItem Value="2">Dos (2) años</asp:ListItem>
                                             </asp:DropDownList>
                                             &nbsp;&nbsp;
                                             <asp:Label ID="Label3" runat="server" Text="Cantidad certificados : "></asp:Label>
                                             <asp:TextBox ID="txtcantidad" runat="server" Width="68px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                                             <br />
                                             <br /><br />

                            <asp:Label ID="Label4" runat="server" Text="Tipo de factura : "></asp:Label>
                            <asp:DropDownList ID="ddltipofactura" runat="server">
                                <asp:ListItem Value="1">Factura de credito fiscal</asp:ListItem>
                                <asp:ListItem Value="2">Factura de consumo</asp:ListItem>
                            </asp:DropDownList>

                            
                                    &nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="lblRnc" runat="server" AssociatedControlID="txtRnc" Width="135px">
                                    RNC o Cédula</asp:Label>
                                                <asp:TextBox ID="txtRnc" runat="server" MaxLength="11"   Width="175px" />
                                               


                                  <div class="footer_go">
                            <asp:Button Text="Continuar" runat="server" CssClass="btn" ID="btnContinuarSinCosto" OnClick="btnContinuarSinCosto_Click"
                                 />
                            <div class="clear" />
                        </div>
                               </asp:Panel>

              <asp:Panel ID="pnlDetalles" runat="server">
                            <h2>Total a Pagar
                            </h2>
                            <h5>Verifica los detalles de la factura incluyendo el listado de servicios y sus costos.
                            </h5>
                            

                        <asp:Repeater ID="rpDetalleServicio" runat="server">
                                <HeaderTemplate>
                                    <table class="hor-minimalist-b" style="margin-top: -15px">
                                        <thead>
                                            <tr>
                                                <th>Detalle
                                                </th>
                                                <th style="text-align: center">Cantidad
                                                </th>
                                                <th style="text-align: right">Costo
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNombreServicio" runat="server" Text='<%#Eval("Descripcion") %>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblCantidadCertificaciones" runat="server" Text='<%# Eval("Cantidad") %>'
                                                ReadOnly="true" Width="60px"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="txtCosto" runat="server" Text='<%# String.Format("{0:n}", Eval("Costo")) %>'
                                                ReadOnly="true" Width="60px"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                                <FooterTemplate>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                         <br />
                            <br />
                            <br />

                         <div>
                            <table style="float: right; font-size: 14px" id="totalDetails" width="40%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold">Nota de Crédito: </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblCredito" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">Total Transacci&oacute;n</td>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblTotalTransaccion" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">Total a Pagar </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="Panel" runat="server" Visible="false">
                                            <td style="font-weight: bold">Reembolso </td>
                                            <td style="text-align: right">
                                        <asp:Label ID="lblReembolso" runat="server"></asp:Label></td>
                                        </asp:Panel>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                   <br />
                                             <br />
                   <br />
                                             <br />
                   <br />

                   <div class="footer_go">
                            <asp:Button Text="Pagar" runat="server" CssClass="btn" ID="btnregresar" OnClick="btnregresar_Click"/>
                            <asp:Button ID="Button2" runat="server" Text="Volver atrás" CssClass="btn" ClientIDMode="Static" OnClick="Button2_Click" />
                            <div class="clear" />
                  </div>

                                             <br />
    </asp:Panel>

                   




                    </asp:View>
                    

                  

                </asp:MultiView>

                

            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>

