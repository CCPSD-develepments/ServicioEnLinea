    <%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="Oficina.aspx.cs" Inherits="CamaraComercio.Website.Empresas.Oficina" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Import Namespace="CamaraComercio.Website" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>

<%@ Register assembly="CamaraComercio.Website" namespace="CamaraComercio.Website.Helpers.ExtendedControls" tagprefix="cc1" %>

<asp:Content ID="cntHead" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Oficina Virtual - Mis Empresas</title>
    <!-- Estilos -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link href="/res/css/Oficina.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>


       <%-- query inc Bootstrap:--%>
   <%-- <script src="../res/js/bootstrap/bootstrap.js" type="text/javascript"></script>--%>
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
  
<%--   <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js" type="text/javascript"></script>--%>


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

        //function GetKeyCode(evt) {
        //    var keyCode;
        //    if (evt.keyCode == 13) {
        //        __doPostBack('Button3', '');
        //    }
        //}

        function filterDigits(eventInstance) {
            eventInstance = eventInstance || window.event;
            key = eventInstance.keyCode || eventInstance.which;
            if ((47 < key) && (key < 58) || key == 45 || key == 8) {
                return true;

               /* MostrarDialogMensaje();*/
            }
            else
            {
                if (eventInstance.preventDefault) eventInstance.preventDefault();
                eventInstance.returnValue = false;

                dlgMsgRM();
                return false;
            } //if
        } //filterDigits

        function filterDigitsSol(eventInstance) {
            eventInstance = eventInstance || window.event;
            key = eventInstance.keyCode || eventInstance.which;
            if ((47 < key) && (key < 58) || key == 45 || key == 8) {
                return true;

                /* MostrarDialogMensaje();*/
            }
            else {
                if (eventInstance.preventDefault) eventInstance.preventDefault();
                eventInstance.returnValue = false;

                dlgMsgSolicitud();
                return false;
            } //if
        } //filterDigits

        function dlgMsgRM() {      

            $("#modal_dialog").dialog({

                title: "Validación de datos.",
                height: 250,
                width: 430,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },

                modal: true

            });

            return false;
        };

        function dlgMsgSolicitud() {

            $("#modal_dialog_so").dialog({

                title: "Validación de datos.",
                height: 250,
                width: 430,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },

                modal: true

            });

            return false;
        };

        

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
                <h1 id="portafolio">
                    <span class="right normal">Hola,
                        <asp:Label runat="server" ID="lblNombreUsuario">(Nombre de Usuario)</asp:Label>
                    </span>Mis Empresas
                    <br />
                </h1>

            </div>
            <div id="content_body">
                <div id="tabs">
                    <ul>
                        <li><a href="#rpEmpresas">Mis Empresas</a></li>
                        <li><a href="#rpHistorico">Historial de Transacciones</a></li>
                        <li><a href="#rpTransaccionesDevueltas">Transacciones Devueltas por Problemas</a></li>
                        <li><a href="#rpMensajes">Notificaciones</a></li>
                       <%-- <li><a href="#rpTransaccionesPendienteAutorizar">Pendientes Autorizar</a></li>--%>
                    </ul>
                    <div class="tab" id="rpEmpresas">
                        <h2>Empresas con Acceso Autorizado</h2>
                        <h5>Estas son las empresas a las que tienes acceso autorizado en el Registro Mercantil.
                            Para tener acceso a una nueva empresa, favor de completar la <a href="/Empresas/SolicitudInclusion.aspx?TipoContrato=AccesoEmpresa">solicitud de acceso  </a>.</h5>

                        <telerik:RadGrid ID="rgridEmp" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataSourceID="odsEmpresasRegistradasSF" GridLines="None" 
                            OnItemDataBound="rgridEmp_ItemDataBound" Skin="NoboxGrid" EnableEmbeddedSkins="False"
                            AllowFilteringByColumn="True">
                            <GroupingSettings CaseSensitive="false"></GroupingSettings>
                            <MasterTableView DataSourceID="odsEmpresasRegistradasSF" AllowFilteringByColumn="true">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Cámara" SortExpression="CamaraID"
                                        UniqueName="CamaraID" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200" AllowFiltering="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NumeroRegistro" DataType="System.Int32" HeaderText="No. Registro"
                                        SortExpression="RegistroId" UniqueName="RegistroId" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="NombreSocialPersona" HeaderText="Empresa" UniqueName="NombreSocial" 
                                        CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200">
                                        <ItemTemplate>
                                            <asp:Image ID="EstadoImg" runat="server" ImageUrl='/res/img/icons/bullet_green.png'
                                                ToolTip='Activa' />
                                            <asp:Label ID="NombreSocialLabel" runat="server" Text='<%# Eval("NombreSocialPersona") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Sufijo" HeaderText="Tipo" SortExpression="Sufijo"
                                        UniqueName="Sufijo" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTipoEntidad" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="FechaConstitucion" DataType="System.DateTime"
                                        HeaderText="Fecha Constitución" SortExpression="FechaConstitucion"
                                        UniqueName="FechaConstitucion" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterDelay="200" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaConstitucion" runat="server" Text=''></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkActions" DataNavigateUrlFields="SociedadId,RegistroId,CamaraID,TipoSociedadId"
                                        DataNavigateUrlFormatString="VerDetalleEmpresa.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}"
                                        ShowFilterIcon="false" AllowFiltering="false">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                        UpdateImageUrl="Update.gif">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                        </telerik:RadGrid>
                       
                        <asp:ObjectDataSource ID="odsEmpresasRegistradasSF" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchAllEntidadesC" SelectCountMethod="FetchAllEntidadesCount"
                            TypeName="CamaraComercio.DataAccess.EF.SRM.SociedadesController" StartRowIndexParameterName="pagInicio"
                            MaximumRowsParameterName="pagTamano" EnablePaging="True">
                            <SelectParameters>
                                <asp:ProfileParameter Name="usuario" PropertyName="username" Type="String" />
                                <asp:Parameter Name="estado" Type="Object" DefaultValue="2" />
                                <asp:ControlParameter ControlID="rgridEmp" Name="pagInicio" PropertyName="CurrentPageIndex" Type="Int32" />
                                <asp:ControlParameter ControlID="rgridEmp" Name="pagTamano" PropertyName="PageSize" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>

                        <asp:ObjectDataSource ID="odsEmpresasRegistradas" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchAllSociedadesByUserDt" SelectCountMethod="CountSociedadesByUser"
                            TypeName="CamaraComercio.DataAccess.EF.SRM.SociedadesController" StartRowIndexParameterName="pagInicio"
                            MaximumRowsParameterName="pagTamano" EnablePaging="True">
                            <SelectParameters>
                                <asp:ProfileParameter Name="usuario" PropertyName="username" Type="String" />
                                <asp:Parameter Name="estado" Type="Object" DefaultValue="2" />
                                <asp:ControlParameter ControlID="rgridEmp" Name="pagInicio" PropertyName="CurrentPageIndex" Type="Int32" />
                                <asp:ControlParameter ControlID="rgridEmp" Name="pagTamano" PropertyName="PageSize" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:Panel runat="server" ID="pnlEmpresasPendientes">
                            <h2>Empresas Pendientes de Acceso Autorizado</h2>
                            <h5>Estas son las empresas a las cuales tu acceso en el Registro Mercantil esta pendiente
                                de autorización.</h5>
                            <telerik:RadGrid ID="rgridPendientes" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" GridLines="None" DataSourceID="odsEmpresasPendientesSF"
                                OnItemDataBound="rgridPendientes_ItemDataBound" Skin="NoboxGrid" EnableEmbeddedSkins="False">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataSourceID="odsEmpresasPendientesSF">
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Cámara" UniqueName="CamaraID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NumeroRegistro" HeaderText="No. Registro" UniqueName="NumeroRegistro">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="NombreSocialPersona" HeaderText="Empresa" UniqueName="NombreSocial">
                                        <ItemTemplate>
                                            <asp:Label ID="NombreSocialLabel" runat="server" Text='<%# Eval("NombreSocialPersona") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Sufijo" HeaderText="Tipo" SortExpression="Sufijo"
                                        UniqueName="Sufijo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTipoEntidad" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="FechaConstitucion" DataType="System.DateTime"
                                        HeaderText="Fecha Constitución" SortExpression="FechaConstitucion"
                                        UniqueName="FechaConstitucion">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaConstitucion" runat="server" Text=''></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                        <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkHistoricoActions" DataNavigateUrlFields="TransaccionId,CamaraID"
                                            DataNavigateUrlFormatString="VerDetalleTransaccion.aspx?nSolicitud={0}&CamaraId={1}&VerDetalle=true">
                                        </telerik:GridHyperLinkColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                            UpdateImageUrl="Update.gif">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                            </telerik:RadGrid>

                            <asp:ObjectDataSource ID="odsEmpresasPendientesSF" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchAllEntidadesC" SelectCountMethod="CountSociedadesByUser"
                                TypeName="CamaraComercio.DataAccess.EF.SRM.SociedadesController"
                                StartRowIndexParameterName="pagInicio" MaximumRowsParameterName="pagTamano">
                                <SelectParameters>
                                    <asp:ProfileParameter Name="usuario" PropertyName="username" Type="String" />
                                    <asp:Parameter Name="estado" Type="Object" DefaultValue="1" />
                                    <asp:ControlParameter ControlID="rgridPendientes" Name="pagInicio" PropertyName="CurrentPageIndex"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="rgridPendientes" Name="pagTamano" PropertyName="PageSize"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>

                            <asp:ObjectDataSource ID="odsEmpresasPendientes" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchAllSociedadesByUserDt" SelectCountMethod="CountSociedadesByUser"
                                TypeName="CamaraComercio.DataAccess.EF.SRM.SociedadesController"
                                StartRowIndexParameterName="pagInicio" MaximumRowsParameterName="pagTamano">
                                <SelectParameters>
                                    <asp:ProfileParameter Name="usuario" PropertyName="username" Type="String" />
                                    <asp:Parameter Name="estado" Type="Object" DefaultValue="1" />
                                    <asp:ControlParameter ControlID="rgridPendientes" Name="pagInicio" PropertyName="CurrentPageIndex"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="rgridPendientes" Name="pagTamano" PropertyName="PageSize"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                        <asp:Panel ID="pnlConstitucionesPendientes" runat="server">
                            <h2>Transacciones En Proceso
                            </h2>
                            <h5>Estas son las transacciones que están siendo procesadas.</h5>
                            <telerik:RadGrid ID="rgridNuevasPendientes" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" DataSourceID="odsEmpresasNuevas" AllowSorting="True"
                                Skin="NoboxGrid" EnableEmbeddedSkins="False">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView DataSourceID="odsEmpresasNuevas">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="TransaccionID" DataType="System.Int32" HeaderText="No. Solicitud" SortExpression="RegistroID" UniqueName="TransaccionID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Camara" SortExpression="CamaraID"
                                            UniqueName="CamaraID" Visible="false">
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="FechaSolicitud" DataType="System.DateTime" HeaderText="Fecha"
                                            SortExpression="FechaSolicitud" DataFormatString="{0:dd/MM/yyyy}" UniqueName="FechaSolicitud">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RegistroID" DataType="System.Int32" HeaderText="No. Registro"
                                            SortExpression="RegistroID" UniqueName="RegistroID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SociedadID" DataType="System.Int32" HeaderText="SociedadID"
                                            SortExpression="SociedadID" UniqueName="SociedadID" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TipoSociedadID" DataType="System.Int32" HeaderText="TipoSociedadID"
                                            SortExpression="TipoSociedadID" UniqueName="TipoSociedadID" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Nombre Social" SortExpression="NombreSocial"
                                            UniqueName="NombreSocial">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="SiglasTipoSociedad" HeaderText="Tipo" SortExpression="SiglasTipoSociedad"
                                            UniqueName="SiglasTipoSociedad" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="SiglasTipoSociedadLabel" runat="server" Text='<%# Eval("SiglasTipoSociedad") %>'
                                                    ToolTip='<%# Eval("TipoSociedad") %>'></asp:Label>
                                            </ItemTemplate>

                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Servicio" HeaderText="Servicio"
                                            SortExpression="Servicio" UniqueName="Servicio">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EstatusTransaccion" HeaderText="Estado"
                                            SortExpression="EstatusTransaccion" UniqueName="Estado">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkActions" DataNavigateUrlFields="TransaccionID"
                                            DataNavigateUrlFormatString="VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true">
                                        </telerik:GridHyperLinkColumn>
<%--                                        <telerik:GridHyperLinkColumn Text="Imprimir" UniqueName="lnkActions" DataNavigateUrlFields="TransaccionID"
                                            DataNavigateUrlFormatString="/Empresas/ImprimirSolicitud.aspx?nSolicitud={0}">
                                        </telerik:GridHyperLinkColumn>--%>

                                        <telerik:GridHyperLinkColumn Text="Cancelar" UniqueName="lnkCancel" DataNavigateUrlFields="TransaccionID"
                                            DataNavigateUrlFormatString="~/DeleteTransaccion.aspx?nSolicitud={0}">
                                        </telerik:GridHyperLinkColumn>
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
                                SelectMethod="GetNuevasSociedadesPendientesDt" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.SociedadesRepository">
                                <SelectParameters>
                                    <asp:ProfileParameter Name="username" PropertyName="username" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </div>



                    <div class="tab" id="rpHistorico">

                        <%--<div class="row">--%>

                            <%--<div class="container">--%>


                        <h2>Historial de Transacciones</h2>
                        <h5>Estas son las transacciones que tu haz realizado en el portal de Productos y Servicios
                            de la Cámara de Santo Domingo.</h5>

                       <%-- <asp:DropDownList ID="ddAdecuacion" runat="server" Width="225px" CssClass="commentCtrl"
                            ClientIDMode="Static" AutoPostBack="True"
                            OnSelectedIndexChanged="ddAdecuacion_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Ningunas</asp:ListItem>
                            <asp:ListItem Value="9999">Todas</asp:ListItem>
                            <asp:ListItem Value="40">Solicitud Incompleta</asp:ListItem>
                            <asp:ListItem Value="39">En Digitalizaci&oacute;n Control Calidad</asp:ListItem>
                            <asp:ListItem Value="3">En an&aacute;lisis</asp:ListItem>
                            <asp:ListItem Value="11">Listo para entrega</asp:ListItem>
                            <asp:ListItem Value="15">En problema</asp:ListItem>
                            <asp:ListItem Value="14">Completado</asp:ListItem>
                            <asp:ListItem Value="41">Descargada</asp:ListItem>
                            <asp:ListItem Value="42">Descargada(Problema)</asp:ListItem>
                           
                        </asp:DropDownList> --%>
                         <%--<asp:ListItem Value="18">Devuelto al solicitante</asp:ListItem>--%>


                         <div class="row">

      
                           <div class="col-md-2">
                                     
                         <asp:DropDownList ID="ddAdecuacion" runat="server" Width="150px" CssClass="commentCtrl" Height="30px"
                            ClientIDMode="Static" AutoPostBack="True"  
                            OnSelectedIndexChanged="ddAdecuacion_SelectedIndexChanged">
                            <asp:ListItem Value="Todas">Todas</asp:ListItem>
                            <asp:ListItem Value="Sociedad">Sociedad</asp:ListItem>
                            <asp:ListItem Value="Persona">Persona Fisica</asp:ListItem>
                            <asp:ListItem Value="Estado">Estado</asp:ListItem>
                            <asp:ListItem Value="RM">RM</asp:ListItem>
                            <asp:ListItem>Fecha</asp:ListItem>
                            <asp:ListItem Value="SolicitudId">No. Solicitud</asp:ListItem>                         
                        </asp:DropDownList>
                              
                </div> 

           <asp:Panel runat="server" class="tab" id="pnlFechasCons" Visible="false">      
                <div class="col-md-1">                
                         <label id="lblDesde" class="font-weight-bold">Desde</label>                    
                 </div>              
                <div class="col-md-2">                
                   
          <cc1:CalendarOfvRad ID="dtFechaDesde" runat="server" ClientIDMode="Static" ControlDisplay="TextBoxImage"
              CssClass="calendario" Culture="es-DO" GoToTodayText="Hoy" Height="26px" 
              ImageUrl="/res/img/calendar.png" MinDate="1900-01-01" Nullable="True" 
              NullableLabelText="Seleccione una fecha" PropertyName="dtFechaDesde" Text="" 
              VisibleDate="" Width="150px">
                                                 <Calendar UseColumnHeadersAsSelectors="False" 
                                                     UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                 </Calendar>
                                                 <DateInput Height="26px">
                                                 </DateInput>                                                
                                             </cc1:CalendarOfvRad>   

                
                </div>         

<div class="col-md-1">                 
           <label for="txtHasta" class="font-weight-bold">Hasta</label>              
                              
 </div>

                <div class="col-md-1">               
                   
          <cc1:CalendarOfvRad ID="dtFechaHasta" runat="server" Height="23px" Width="170px"
              OnSelectedDateChanged="GetByFilter"
               AutoPostBack="true" >
             
                                                 <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                 </Calendar>
                                                 <DateInput Height="23px">
                                                 </DateInput>
                                               
                                             </cc1:CalendarOfvRad>
            <asp:CompareValidator ID="CompareValidator2"
                    runat="server"
                    ControlToValidate="dtFechaDesde"
                    Operator="DataTypeCheck"
                    Type="Date">Date invalid, please check format. 
        </asp:CompareValidator>


</div>
</asp:Panel>



<%--    RM:--%>
<asp:Panel runat="server" class="tab" id="pnlNumeroRM" Visible="false">    
                <div class="col-md-3">                
                            <asp:DropDownList ID="ddlTipoSociedad" CssClass="form-control" runat="server" Width="170px" Height="30px"
                        DataTextField="Seleccione un tipo sociedad" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoSociedad_SelectedIndexChanged">

                                <asp:ListItem Value="-1">Tipo de empresa</asp:ListItem>
                                <asp:ListItem Value="Persona">Persona Fisica</asp:ListItem>
                                <asp:ListItem>Sociedad</asp:ListItem>

                    </asp:DropDownList>              
                 </div>              
                    
                       
        <div class="col-md-5">                    
                        <asp:TextBox ID="txtNumeroRM" runat="server" Width="150px" Height="30px"  onkeypress="filterDigits(event)"
                            placeholder="No. RM"  OnTextChanged ="GetByFilter" AutoPostBack="true" ></asp:TextBox>
                    </div>             

         </asp:Panel>

    <%--    Num Solicitud:--%>
<asp:Panel runat="server" class="tab" id="pnlNumSolicitud" Visible="false"> 
                                           
          <div class="col-md-2">                    
                        <asp:TextBox ID="txtNumSolicitud" runat="server" 
                            Width="150px" Height="30px" placeholder="No. Solicitud"  
                            OnTextChanged ="GetByFilter" AutoPostBack="true" onkeypress="filterDigitsSol(event)" ></asp:TextBox>
                    </div>             

</asp:Panel>


    <%--    ESTADO:--%>
<asp:Panel runat="server" class="tab" id="pnlEstadoSol" Visible="false">    
                <div class="col-md-2">                
                            <asp:DropDownList ID="ddlEstadoSol" CssClass="form-control" runat="server" Width="170px" Height="30px"
                        DataTextField="Seleccione un estado" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoSol_SelectedIndexChanged">

                                <asp:ListItem Value="-1">Seleccione un estado</asp:ListItem>
                                <asp:ListItem Value="15">En revision por problemas</asp:ListItem>
                                <asp:ListItem Value="41">Descargada en linea</asp:ListItem>

                                <asp:ListItem Value="3">Incompleto</asp:ListItem>
                                <asp:ListItem Value="14">Completado</asp:ListItem>
                                <asp:ListItem Value="11">Entrega</asp:ListItem>
                                <asp:ListItem Value="15">Problema</asp:ListItem>
                                <asp:ListItem Value="3">Analisis</asp:ListItem>
                                <asp:ListItem Value="39">En Digitalización control de calidad</asp:ListItem>

                    </asp:DropDownList>              
                 </div>              
                 
</asp:Panel>


 <%--    Num RM Socid:--%>
<asp:Panel runat="server" class="tab" id="pnlSociedadRM" Visible="false">    
                                           
<div class="col-md-2">                    
  <asp:TextBox ID="txtSociedadNombre" runat="server" Width="250px" Height="30px" 
      placeholder="Nombre de la sociedad"  OnTextChanged ="GetByFilter" AutoPostBack="true" ></asp:TextBox>
     </div>             

</asp:Panel>

 <%--    Num RM Socid:--%>
<asp:Panel runat="server" class="tab" id="pnlPersonaFRM" Visible="false">    
                                           
 <div class="col-md-2">                    
       <asp:TextBox ID="txtPersonaFisicaNombre" runat="server" Width="250px" 
           Height="30px" placeholder="Nombre de la persona fisica"  OnTextChanged ="GetByFilter" AutoPostBack="true" ></asp:TextBox>
        
    </div>             

</asp:Panel>

    
                      
 </div>


                          <telerik:RadGrid ID="rgridHistorico" runat="server" AutoGenerateColumns="False" GridLines="None"
                            OnItemDataBound="RgridHistoricoItemDataBound" AllowPaging="True" AllowSorting="True"
                          
                            Skin="NoboxGrid" EnableEmbeddedSkins="False" OnPageIndexChanged="rgridHistorico_PageIndexChanged">
                           <%-- <MasterTableView DataSourceID="odsHistoricosTransacciones">--%>
                             <MasterTableView>
                                <NoRecordsTemplate>
                                    No existen transacciones previas.
                                </NoRecordsTemplate>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TransaccionID" DataType="System.Int32" HeaderText="No. Solicitud" SortExpression="RegistroID" UniqueName="TransaccionID">
                                        </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha" UniqueName="FechaSolicitud" DataField="Fecha"
                                        DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="50px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="NombreCamara" HeaderText="Cámara" UniqueName="CamaraID"
                                        SortExpression="CamaraID">
                                        <ItemTemplate>
                                            <asp:Label ID="NombreCamaraLabel" runat="server" Text='<%# Eval("CamaraID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                        <HeaderStyle Width="30px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn HeaderText="Sociedad" UniqueName="Sociedad" DataField="NombreSocialPersona">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Solicitud" UniqueName="Solicitud" DataField="NombreServicio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="EstatusTransId" HeaderText="Estado" UniqueName="Estado"
                                        SortExpression="EstatusTransId">
                                        <ItemTemplate>
                                            <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("EstatusTransacciones.EstatusTranNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkHistoricoActions" DataNavigateUrlFields="TransaccionId"
                                        DataNavigateUrlFormatString="VerDetalleTransaccion.aspx?nSolicitud={0}">
                                    </telerik:GridHyperLinkColumn>
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


                        <asp:ObjectDataSource ID="odsHistoricalQry" runat="server" EnablePaging="True"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataEstado"
                            TypeName="CamaraComercio.Website.Empresas.Oficina"
                            SelectCountMethod="GetDataEstado">
                            <SelectParameters>                                
                                <asp:Parameter Name="startRowIndex" Type="Int32" />
                                <asp:Parameter Name="maximumRows" Type="Int32" />                                
                            </SelectParameters>
                        </asp:ObjectDataSource>



                </div>


                   


                    <div class="tab" id="rpTransaccionesDevueltas">
                        <h2>Transacciones Devueltas por Problemas</h2>
                        <h5>Estas son las transacciones que están devueltas por problemas.
                        </h5>
                        <telerik:RadGrid ID="rgridTransaccionesDevueltas" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowPaging="True" AllowSorting="True" DataSourceID="" OnNeedDataSource="rgridTransaccionesDevueltas_NeedDataSource"
                            Skin="NoboxGrid" EnableEmbeddedSkins="False">
                            <MasterTableView DataSourceID="">
                                <NoRecordsTemplate>
                                    No existen transacciones devueltas.
                                </NoRecordsTemplate>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TransaccionID" DataType="System.Int32" HeaderText="No. Solicitud" SortExpression="RegistroID" UniqueName="TransaccionID">
                                        </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha" UniqueName="FechaSolicitud" DataField="Fecha"
                                        DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="50px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="NombreCamara" HeaderText="Cámara" UniqueName="CamaraID"
                                        SortExpression="CamaraID">
                                        <ItemTemplate>
                                            <asp:Label ID="NombreCamaraLabel" runat="server" Text='<%# Eval("CamaraID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                        <HeaderStyle Width="30px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn HeaderText="Sociedad" UniqueName="Sociedad" DataField="NombreSocialPersona">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Solicitud" UniqueName="Solicitud" DataField="NombreServicio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="EstatusTransId" HeaderText="Estado" UniqueName="Estado"
                                        SortExpression="EstatusTransId">
                                        <ItemTemplate>
                                            <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("EstatusTransacciones.EstatusTranNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkHistoricoActions" DataNavigateUrlFields="TransaccionId"
                                        DataNavigateUrlFormatString="VerDetalleTransaccion.aspx?nSolicitud={0}">
                                    </telerik:GridHyperLinkColumn>
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
                        <asp:ObjectDataSource ID="odsTransaccionesDevueltas" runat="server" EnablePaging="True"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetTransaccionesHistoriaDtP"
                            TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionesController"
                            SelectCountMethod="GetCountTransaccionesHistoriaDtP">
                            <SelectParameters>
                                <asp:ProfileParameter Name="userId" PropertyName="username" Type="String" />
                                <asp:Parameter Name="startRowIndex" Type="Int32" />
                                <asp:Parameter Name="maximumRows" Type="Int32" />
                                <asp:Parameter Name="Estatus" Type="Int32" DefaultValue="15" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>



                    <div class="tab" id="rpMensajes">
                        <h2>Notificaciones
                        </h2>
                        <h5>Esta es tu correspondencia oficial con la Cámara de Santo Domingo.</h5>
                        <asp:ObjectDataSource ID="odsMsg" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchByUsuarioPadre" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.MensajesController"
                            SelectCountMethod="CountByUsuarioPadre" StartRowIndexParameterName="pagInicio"
                            MaximumRowsParameterName="pagTamano" EnablePaging="True" OnSelecting="odsMsg_Selecting">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="" Name="usuarioPadre" Type="String" />
                                <asp:ControlParameter ControlID="rgridMsg" Name="pagInicio" PropertyName="CurrentPageIndex"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="rgridMsg" Name="pagTamano" PropertyName="PageSize"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <telerik:RadGrid ID="rgridMsg" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataSourceID="odsMsg" GridLines="None" OnItemDataBound="rgridMsg_ItemDataBound"
                            Skin="NoboxGrid" EnableEmbeddedSkins="False">
                            <MasterTableView DataSourceID="odsMsg" PageSize="10">
                                <NoRecordsTemplate>
                                    No existen mensajes para este usuario.
                                </NoRecordsTemplate>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Id" HeaderText="ID" UniqueName="MensajeID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaEnvio" HeaderText="Fecha" UniqueName="FechaEnvio" DataFormatString="{0:dd/MM/yyyy}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Titulo" HeaderText="Título" UniqueName="Titulo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="UsuarioSistema" HeaderText="Enviado Por" UniqueName="UsuarioSistema">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Usuario" HeaderText="Enviado Para" UniqueName="Usuario">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Tipo de Mensaje" UniqueName="TipoMensaje">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTipoMensaje" runat="server" Text='<%# ((CamaraComercio.DataAccess.EF.OficinaVirtual.TipoMensaje)Eval("TipoMensaje")).ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="lnkMensajeActions">
                                        <ItemTemplate>
                                            <a href='/Empresas/VerMensaje.aspx?msgID=<%# Eval("ID") %>' class="fboxMensajes iframe"
                                                id='<%# Eval("ID") %>'>Ver</a>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="FechaLectura" DataType="System.DateTime" EmptyDataText=""
                                        HeaderText="FechaLectura" UniqueName="FechaLectura" Visible="False" DataFormatString="{0:dd/MM/yyyy}">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                        UpdateImageUrl="Update.gif">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                        </telerik:RadGrid>
                    </div>

                  <%--  Pagos BHD:--%>
                    <%--  <div class="tab" id="rpTransaccionesPendienteAutorizar">
                        <h2>Transacciones pendientes autorizacion por el banco</h2>
                        <h5>Estas son las transacciones que están pendientes autorizar pago.
                        </h5>

                          <telerik:RadGrid ID="gvPendientesAutorizar" runat="server" AutoGenerateColumns="False" Width="96%"
                                    GridLines="None">
                                    <ClientSettings>
                                    </ClientSettings>
                                    <MasterTableView>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="30px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn>
                                            <HeaderStyle Width="30px" />
                                        </ExpandCollapseColumn>


                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Empresa1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="reference" HeaderText="Referencia/No. Transacción" UniqueName="Empresa2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TransactionId" HeaderText="Transaccion (BHD)" UniqueName="Empresa">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EstadoString" HeaderText="Estado" UniqueName="Empresa">
                                            </telerik:GridBoundColumn>
                                                                                    

                                              <telerik:GridHyperLinkColumn  Text="Actualizar" UniqueName="lnkHistoricoActions" DataNavigateUrlFields="reference"
                                            DataNavigateUrlFormatString="ComprobarPagoTransaccion.aspx?nSolicitud={0}">
                                                  <HeaderStyle Width="90px" />
                                                  <ItemStyle Width="90px"></ItemStyle>
                                        </telerik:GridHyperLinkColumn>
                                                                                     

                                           
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>


                        
                
                    </div>--%>



                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- end grid_24 -->
    </div>

    <%-- </div>--%>

       <div class="clear"></div>    
    <div id="modal_dialog" style="display: none">
         <br />       
            <h5> Favor colocar un Número de RM válido.</h5>               
       <br />    
</div>

         <div class="clear"></div>    
    <div id="modal_dialog_so" style="display: none">
         <br />       
            <h5> Favor colocar un Número de Solicitud válido.</h5>               
       <br />    
</div>

</asp:Content>

    

