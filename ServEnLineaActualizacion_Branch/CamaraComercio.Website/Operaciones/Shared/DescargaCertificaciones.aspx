<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="DescargaCertificaciones.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Shared.DescargaCertificaciones" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#navigation li').removeClass("active");
            $('#subnavigation li').removeClass("active");
            $('#liNavRM').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="transac">
                    Transaccion Completada
                </h1>
            </div>
            <div id="content_body">
            <div class="sectDetailBlue">
                        <h1>
                           Su solicitud fue completada satisfactoriamente.</h1>
                        <p>
              
                         Seleccione la operación que desea hacer de las opciones disponibles,El registro mercantil debe ser renovado para poder realizar cualquier operación. Selecciona una de las siguientes alternativas:
                        </p>
                            </div>
            
                <div id="wrapperContent" style="text-align: center">
                    <div class="infoBox" id="div1">
                        <div class="infoContent">
                            <asp:HyperLink ID="hlVerSolicitud" runat="server" CssClass="btn" Style="float:none;" Text="Imprimir Solicitud"
                                Target="_blank" ClientIDMode="Static" />
                            <p>
                                Seleccione esta opcion si desea visualizar los datos de la solicitud y el inventario de documentos de forma imprimible.
                            </p>
                        </div>
                    </div>
                    <div class="infoBox" id="divFactura">
                        <div class="infoContent">
                            <asp:HyperLink runat="server" ID="hlVerFactura" Target="_blank" Style="float:none;" Text="Ver Factura"
                                CssClass="btn" NavigateUrl="~/Empresas/ImprimirFactura.aspx" />
                            <p>
                                Seleccione esta opcion si desea visualizar la factura de esta solicitud en línea.
                            </p>
                        </div>
                    </div>
                    <div class="infoBox" id="divSolicitud">
                        <div class="infoContent">
                            <asp:HyperLink ID="lbDescargar" runat="server" CssClass="btn" Text="Descargar Certificación"
                                ClientIDMode="Static" Target="_blank" Style="float:none;" />
                            <p>
                                Seleccione esta opcion si desea descargar la solicitud realizada.
                            </p>
                        </div>
                    </div>
                    <div class="infoBox" id="div2">
                        <div class="infoContent">
                            <asp:HyperLink ID="hlNuevaSolicitud" runat="server" CssClass="btn" Style="float:none;" Text="Nueva Certificación"
                                ClientIDMode="Static" />
                            <p>
                                Seleccione esta opcion si desea solicitar una nueva certificación.
                            </p>
                        </div>
                    </div>
                    <div class="clear" />
                    <p>
                    </p>
                </div>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
