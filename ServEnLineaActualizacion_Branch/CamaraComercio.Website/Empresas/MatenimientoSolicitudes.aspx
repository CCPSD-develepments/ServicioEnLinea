<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatenimientoSolicitudes.aspx.cs" Inherits="CamaraComercio.Website.Empresas.MatenimientoSolicitudes" %>--%>

   <%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="MatenimientoSolicitudes.aspx.cs" Inherits="CamaraComercio.Website.Empresas.MatenimientoSolicitudes" %>


<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Import Namespace="CamaraComercio.Website" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Estilos -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link href="/res/css/Oficina.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <!-- Inline User Scripts -->
    <script type="text/javascript">
        $(document).ready(function () {
            //Navegación
            $('#navigation li').removeClass("active");
            $('#liNavCreacion').addClass("active");

            $('#subnavigation li').removeClass("active"); 
            $('#liOficina').addClass("active");

            //Tabs
            var tabsObj = $("#tabs");
            tabsObj.tabs({
                select: function (event, ui) {
                    $('#hfTabIndex').val(ui.index);
                }
            });

            var tabIndx = parseInt($('#hfTabIndex').val());
            tabsObj.tabs("select", tabIndx);

            //Mensajes de error
            $('#warning div.close').click(function () {
                $('#warning').fadeOut();
            });

            //Modal del Fancybox
            $('.fboxMensajes').fancybox(
                {
                    'centerOnScroll': true, 'titleShow': false,
                    'overlayShow': true, 'hideOnContentClick': false,
                    'hideOnOverlayClick': true, 'frameWidth': 750,
                    'frameHeight': 500, 'padding': 0
                }
            );
            $('.fboxMensajes').click(function () {
                $('.fboxMensajes #' + this.id).removeAttr("style");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server" Visible="false">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="cntMain" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <asp:HiddenField runat="server" ID="hfTabIndex" ClientIDMode="Static" Value="0" />
                <asp:Literal runat="server" ID="ltlWarningDiv" />
               <%-- <h1 id="portafolio">
                    <span class="right normal">Hola,
                        <asp:Label runat="server" ID="lblNombreUsuario">(Nombre de Usuario)</asp:Label>
                    </span>Todas las empresas
                    <br />
                </h1>--%>

            </div>
            <div id="content_body">
                <div id="tabs">
                    <ul>
                        <li><a href="#rpEmpresas">Mis Empresas</a></li>
                    <%--    <li><a href="#rpHistorico">Historial de Transacciones</a></li>
                        <li><a href="#rpTransaccionesDevueltas">Transacciones Devueltas por Problemas</a></li>
                        <li><a href="#rpMensajes">Notificaciones</a></li>--%>
                    </ul>
                    <div class="tab" id="rpEmpresas">
                   
                        <asp:Panel ID="pnlConstitucionesPendientes" runat="server">
                            <h2>Transacciones Generales En Proceso
                            </h2>
                            <h5>Estas son todas las transacciones que están siendo procesadas.</h5>
                            <telerik:RadGrid ID="rgridNuevasPendientes" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" DataSourceID="odsEmpresasNuevas" AllowSorting="True" AllowFilteringByColumn="True"
                                Skin="NoboxGrid" EnableEmbeddedSkins="False">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataSourceID="odsEmpresasNuevas" AllowFilteringByColumn="true">

                                    <Columns>
                                        <telerik:GridBoundColumn DataField="TransaccionID" DataType="System.Int32" HeaderText="No. Solicitud"
                                            SortExpression="RegistroID" UniqueName="TransaccionID" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Camara" SortExpression="CamaraID"
                                            UniqueName="CamaraID" Visible="false">
                                        </telerik:GridBoundColumn>
                                      
                                     <%--   <telerik:GridBoundColumn DataField="RegistroID" DataType="System.Int32" HeaderText="No. Registro"
                                            SortExpression="RegistroID" UniqueName="RegistroID">
                                        </telerik:GridBoundColumn>--%>

                                        <telerik:GridBoundColumn DataField="RegistroID" DataType="System.Int32" HeaderText="No. Registro"
                                        SortExpression="RegistroID" UniqueName="RegistroID" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="SociedadID" DataType="System.Int32" HeaderText="SociedadID"
                                            SortExpression="SociedadID" UniqueName="SociedadID" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TipoSociedadID" DataType="System.Int32" HeaderText="TipoSociedadID"
                                            SortExpression="TipoSociedadID" UniqueName="TipoSociedadID" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Nombre Social" SortExpression="NombreSocial"
                                            UniqueName="NombreSocial" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200">
                                        </telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="FechaSolicitud" DataType="System.DateTime" HeaderText="Fecha"
                                            SortExpression="FechaSolicitud" DataFormatString="{0:dd/MM/yyyy}" UniqueName="FechaSolicitud" AllowFiltering="false">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridTemplateColumn DataField="SiglasTipoSociedad" HeaderText="Tipo" SortExpression="SiglasTipoSociedad"
                                            UniqueName="SiglasTipoSociedad" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="SiglasTipoSociedadLabel" runat="server" Text='<%# Eval("SiglasTipoSociedad") %>'
                                                    ToolTip='<%# Eval("TipoSociedad") %>'></asp:Label>
                                            </ItemTemplate>

                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Servicio" HeaderText="Servicio"
                                            SortExpression="Servicio" UniqueName="Servicio" AllowFiltering="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EstatusTransaccion" HeaderText="Estado"
                                            SortExpression="EstatusTransaccion" UniqueName="Estado" AllowFiltering="false">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkActions" DataNavigateUrlFields="TransaccionID" AllowFiltering="false"
                                            DataNavigateUrlFormatString="VerSolicitudGeneral.aspx?nSolicitud={0}&VerDetalle=true">
                                        </telerik:GridHyperLinkColumn>

                                       <%-- <telerik:GridHyperLinkColumn Text="Cancelar" UniqueName="lnkCancel" DataNavigateUrlFields="TransaccionID"
                                            DataNavigateUrlFormatString="~/DeleteTransaccion.aspx?nSolicitud={0}">
                                        </telerik:GridHyperLinkColumn>--%>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                            UpdateImageUrl="Update.gif">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                                <FilterMenu EnableEmbeddedSkins="False">
                                </FilterMenu>
                                <HeaderContextMenu EnableEmbeddedSkins="False">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            <asp:ObjectDataSource ID="odsEmpresasNuevas" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetNuevasSociedadesPendientesDttodos" TypeName="CamaraComercio.Website.Empresas.MatenimientoSolicitudes">
                                
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </div>
                    
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>

