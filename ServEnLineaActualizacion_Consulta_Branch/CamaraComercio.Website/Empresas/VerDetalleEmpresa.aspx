<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="VerDetalleEmpresa.aspx.cs" Inherits="CamaraComercio.Website.Empresas.VerDetalleEmpresa" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/res/js/jquery.tools.min.js" type="text/javascript"></script>

    <!-- Inline user script -->
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("#tabs").tabs();

            $(".btnRenovacion a[title]").tooltip();
            $(".help img[title]").tooltip();
        });
    </script>

    <!-- Estilo del tooltip -->
    <style type="text/css">
        .tooltip
        {
            display: none;
            background: transparent url(/res/img/black_arrow.png);
            font-size: 10px;
            height: auto;
            width: auto;
            max-width:45%;
            padding: 50px;
            padding-top:20px;
            color: #fff;
            background-repeat: no-repeat;
            background-size: 100% 100%;
            font-size:small;
        }
    </style>

</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header" style="display:table; width:100%;">
                <%--<h1 id="detalles">
                     <span class="right normal"><asp:Literal ID="litTitulo" runat="server" Text="" /></span>
                    Detalles de Empresa
                </h1>--%>
                <div id="detalles" style="display:table-cell; min-width:375px; vertical-align:middle">
                    <h1 >
                        Detalles de Empresa
                    </h1>
                </div>
                <div class="right normal" style="display:table-cell; padding-left:30px; color:#00587C; text-align:right; vertical-align:middle">
                    <asp:Label ID="litTituloM" CssClass="right normal"  runat="server" style="font-size: 2.3em; text-align:right; width:100%;"></asp:Label>
                </div>
            </div>
            <div id="content_body">
            
                <div id="acciones" class="submenu floatRight">
                    <fieldset class="form-fieldset">
                        <ul style="display:table; height:100%; width:100%" class="help">
                            <asp:Repeater ID="tpTipoTransacciones" runat="server" OnItemDataBound="tpTipoTransacciones_OnItemCreated">
                                <ItemTemplate>
                                    <li style="display:table-row;">
                                        <li style="display:table-cell; vertical-align:middle">
                                            <asp:Image ID="HelpImg" runat="server"  ToolTip="" ImageUrl='/res/img/icons/help.png' visible="true"  />
                                        </li>
                                        <li style="display:table-cell">
                                            <asp:LinkButton runat="server" ID="hlOpcion" style="padding-top:23px" Text='<%#Eval("Descripcion") %>' CssClass="btn"
                                                CommandName='<%#Eval("WebKey") %>' OnClick="GoOption"></asp:LinkButton>
                                            <asp:HiddenField runat="server" ID="hfServicioId" ClientIdMode="Static" Value='<%# Eval("TipoServicioId") %>'/>
                                        </li>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                            <li style="display:table-row">
                                <li style="display:table-cell; vertical-align:middle">
                                    <asp:Image ID="HelpImgCC" runat="server"  ToolTip="" ImageUrl='/res/img/icons/help.png' visible="true"  />
                                </li>
                                <li style="display:table-cell">
                                    <asp:HyperLink runat="server" ID="lnkCopiasRegistradas" style="padding-top:23px" Text='Copias Certificadas' 
                                        CssClass="btn" ></asp:HyperLink>                    
                                </li>
                            </li>
                            <li style="display:table-row">
                                 <li style="display:table-cell; vertical-align:middle">
                                     <asp:Image ID="HelpImgAD" runat="server"  ToolTip="" ImageUrl='/res/img/icons/help.png' visible="true"  />
                                 </li>
                                 <li style="display:table-cell">
                                    <asp:HyperLink runat="server" ID="lnkActualizarDatosGenerales" style="padding-top:23px" Text=' Actualizar Datos Generales' 
                                        CssClass="btn"></asp:HyperLink>                          

                                 </li>
                             </li>
                        </ul>
                        
                        <asp:ObjectDataSource ID="odsTipoTransacciones" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetTipoServiciosByTipoSociedad" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.TipoServicioDetallesController">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="tipoSociedadId" QueryStringField="TipoSociedadId"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </fieldset>
                </div>
                <div id="infoEmpresa">
                <h2> Datos Generales</h2>
                <fieldset class="form-fieldset">
                    <ul>
                   <%-- <li><label>Nombre o Razón Social</label> <asp:Literal ID="litTitulo1" runat="server" Text="" /></li>--%>
                        <li>
                            <label for="txtEstatus" runat="server" id="lblEstatus">
                                Estatus</label>
                            <asp:Literal runat="server" ID="txtStatus" />
                        </li>
                        <li>
                            <label for ="txtNumeroRegistro"> Numero Registro
                            </label>
                           <asp:Literal runat ="server" id ="txtNumeroRegistro"></asp:Literal>
                           
                        </li>
                        <li style="width:475px;">
                            <label for="txtDenominacion">
                                Denominación</label>
                            <asp:Literal runat="server" ID="txtDenominacion" />
                        </li>
                        <li>
                            <label for="txtTipoSociedad" id="lblTipoSociedad" runat="server">
                                Tipo Sociedad</label>
                            <label for="txtTipoSociedad" id="lblTipoEntidad" runat="server" visible="false">
                                Tipo Entidad</label>
                            <asp:Literal runat="server" ID="txtTipoSociedad" />
                        </li>
                        <li>
                            <label for="txtRNC">
                                RNC o Documento</label>
                            <asp:Literal runat="server" ID="txtRNC" />
                        </li>
                        <li>
                            <label for="txtFechaConstitucion" id="lblFechaConstitucion" runat="server" visible="true">
                                Fecha Constitución</label>
                            <label for="txtFechaConstitucion" id="lblFechaInicioOperacion" runat="server" visible="false">
                                Fecha Inicio de Operación</label>
                            <asp:Literal runat="server" ID="txtFechaConstitucion" />
                        </li>
                        
                        <li>
                            <label for="txtDuracionSociedad" runat="server" id="lblDuracionSociedad">
                                Duración Sociedad</label>
                            <asp:Literal runat="server" ID="txtDuracionSociedad" />
                        </li>
                        <li>
                            <label for="txtDuracionConsejo" runat="server" id="lblDuracionConsejo">
                                Duración Consejo</label>
                            <asp:Literal ID="txtDuracionConsejo" runat="server" />
                        </li>
                        <li>
                            <label for="txtFechaUltActo" runat="server" id="lblFechaUltActo">
                                Fecha Ultimo Acto</label>
                            <asp:Literal runat="server" ID="txtFechaUltActo" />
                        </li>
                        <li>
                            <label for="txtEnteRegulado" id="lblEnteRegulado" runat="server">
                                Ente Regulado</label>
                            <asp:Literal runat="server" ID="txtEnteRegulado" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtNumeroResolucion" runat="server" ID="lblNumeroResolucion">Número Resolución</asp:Label>
                            <asp:Literal runat="server" ID="txtNumeroResolucion" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtNumeroNaveInd" runat="server" ID="lblNumeroNaveInd">
                    No. Nave Ind.</asp:Label>
                            <asp:Literal runat="server" ID="txtNumeroNaveInd" />
                        </li>
                    
                    </ul>
                </fieldset>
                    <div class="clear" />
                </div>
                
                <div id="tabs">
                    <ul>
                        <li><a href="#rpDireccion">Dirección</a></li>
                        <li><a href="#rpRegistros">Generales</a></li>
                        <li><a href="#rpActividades">Actividades</a></li>
                        <li><a href="#rpSocios">Socios</a></li>
                        <li><a href="#rpProductos">Productos</a></li>
                        <li><a href="#rpReferencias">Referencias</a></li>
                    </ul>
                    <div class="tab" id="rpDireccion">
                        <h3>
                            Dirección</h3>
                        <fieldset class="form-fieldset">
                            <ul>
                                <li>
                                    <label for="txtDireccion">
                                        Dirección</label>
                                    <asp:Label runat="server" ID="txtDireccion" CssClass="textboxLarge" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtNumero">
                                        Número</label>
                                    <asp:Label runat="server" ID="txtNumero" CssClass="textboxNumero" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="ddlPais">
                                        País</label>
                                    <asp:Label runat="server" ID="ddlPais" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="ddlCiudad">
                                        Ciudad</label>
                                    <asp:Label runat="server" ID="ddlCiudad" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="ddlSector">
                                        Sector</label>
                                    <asp:Label runat="server" ID="ddlSector" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtApartadoPostal">
                                        Apartado Postal</label>
                                    <asp:Label runat="server" ID="txtApartadoPostal" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtTelefono1">
                                        Telefono 1</label>
                                    <asp:Label runat="server" ID="txtTelefono1" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtTelefono2">
                                        Telefono 2</label>
                                    <asp:Label runat="server" ID="txtTelefono2" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtFax">
                                        Fax</label>
                                    <asp:Label runat="server" ID="txtFax" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtEmail">
                                        Email</label>
                                    <asp:Label runat="server" ID="txtEmail" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtWebSite">
                                        Website</label>
                                    <asp:Label runat="server" ID="txtWebSite" ClientIDMode="Static" />
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                    <div class="tab" id="rpRegistros">
                        <h3>
                            Registro</h3>
                        <fieldset class="form-fieldset">
                            <ul>
                                <li>
                                    <label for="txtFechaEmision">
                                        Fecha Emisión</label>
                                    <asp:Label runat="server" ID="txtFechaEmision" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtFechaVencimiento">
                                        Fecha Vencimiento</label>
                                    <asp:Label runat="server" ID="txtFechaVencimiento" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtFechaInicioOperacion">
                                        Inicio Operación</label>
                                    <asp:Label runat="server" ID="txtFechaInicioOperacion" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtFechaUltModificacion">
                                        Fecha Ult. Modificación</label>
                                    <asp:Label runat="server" ID="txtFechaUltModificacion" ClientIDMode="Static" />
                                </li>
                            </ul>
                        </fieldset>
                        <fieldset class="form-fieldset">
                            <h3>
                                Capital
                            </h3>
                            <ul>
                                <li>
                                    <label for="txtAutorizado">
                                        Autorizado</label>
                                    <asp:Label runat="server" ID="ddlMonedaAutorizado" CssClass="moneda" DataSourceID="odsMonedas"
                                        DataTextField="Abreviatura" DataValueField="TipoMonedaId" />
                                    <asp:Label runat="server" ID="txtAutorizado" CssClass="textboxDinero" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtPagado">
                                        Pagado</label>
                                    <asp:Label runat="server" ID="ddlMonedaPagado" CssClass="moneda" DataSourceID="odsMonedas"
                                        DataTextField="Abreviatura" DataValueField="TipoMonedaId" />
                                    <asp:Label runat="server" ID="txtPagado" CssClass="textboxDinero" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtGeneral">
                                        General</label>
                                    <asp:Label runat="server" ID="ddlMonedaGeneral" CssClass="moneda" DataSourceID="odsMonedas"
                                        DataTextField="Abreviatura" DataValueField="TipoMonedaId" />
                                    <asp:Label runat="server" ID="txtGeneral" CssClass="textboxDinero" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtActivos">
                                        Activos</label>
                                    <asp:Label runat="server" ID="ddlMonedaActivos" CssClass="moneda" DataSourceID="odsMonedas"
                                        DataTextField="Abreviatura" DataValueField="TipoMonedaId" />
                                    <asp:Label runat="server" ID="txtActivos" CssClass="textboxDinero" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="txtBienes">
                                        Bienes Raices</label>
                                    <asp:Label runat="server" ID="ddlMonedaBienes" CssClass="moneda" DataSourceID="odsMonedas"
                                        DataTextField="Abreviatura" DataValueField="TipoMonedaId" />
                                    <asp:Label runat="server" ID="txtBienes" CssClass="textboxDinero" ClientIDMode="Static" />
                                </li>
                            </ul>
                            <asp:ObjectDataSource ID="odsMonedas" runat="server" SelectMethod="SelectAll" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.TipoMonedaRepository">
                            </asp:ObjectDataSource>
                        </fieldset>
                        <fieldset class="form-fieldset">
                            <h3>
                                Empleados</h3>
                            <ul>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="txtMasculinos" ID="lblMasculinos">
                            Cantidad de Empleados
                                    </asp:Label>
                                    <asp:Label runat="server" ID="txtMasculinos" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <asp:Literal runat="server" ID="lblEmpleadosVacio" />
                                </li>
                            </ul>
                        </fieldset>
                        <fieldset class="form-fieldset">
                            <h3>
                                Registros</h3>
                            <ul>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="txtNombreComercial" ID="lblNombreComercial">
                            Nombre Comercial
                                    </asp:Label>
                                    <asp:Label runat="server" ID="txtNombreComercial" ClientIDMode="Static" />
                                    <asp:Label runat="server" ID="txtNombreComercialNumero" />
                                </li>
                                <li>
                                    <asp:Literal runat="server" ID="lblNombreComercialVacio" />
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                    <div class="tab" id="rpActividades">
                        <fieldset class="form-fieldset">
                            <h3>
                                Actividades</h3>
                            <ul>
                                <li>
                                    <label for="txtActividad">
                                        Actividades</label>
                                    <asp:Label runat="server" ID="txtActividad" Width="80%" TextMode="MultiLine" Wrap="true"
                                        ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="cblTipoActividades">
                                        Tipos Actividades</label>
                                    <asp:CheckBoxList ID="cblTipoActividades" runat="server" DataTextField="Actividad"
                                        DataValueField="TipoActividadId" RepeatColumns="2" Width="100%" ClientIDMode="Static"
                                        Enabled="false">
                                    </asp:CheckBoxList>
                                </li>
                                <li>
                                    <label for="txtServicio">
                                        Productos y servicios</label>
                                    <asp:Label runat="server" ID="txtServicio" ClientIDMode="Static" />
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                    <div class="tab" id="rpSocios">
                        <fieldset class="form-fieldset">
                            <h3>
                                Socios Accionistas</h3>
                            <asp:ObjectDataSource ID="odsSocios" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchAllSociosByRegistroIdAndTipoRelacion" TypeName="CamaraComercio.DataAccess.EF.SRM.RegistrosSociosController">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="registroId" QueryStringField="registroId" Type="Int32" />
                                    <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                                    <asp:Parameter Name="tipoRelacion" DefaultValue="A" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <telerik:RadGrid ID="rgridSocios" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" DataSourceID="odsSocios"
                                EnableEmbeddedSkins="False" Skin="NoboxGrid">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <NoRecordsTemplate>
                                        No hay empresas registradas.
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Documento" HeaderText="Documento" UniqueName="Documento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Socio" UniqueName="Socio">
                                            <ItemTemplate>
                                                <span>
                                                    <%#Eval("Accionista")%>
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Cargo" HeaderText="Cargo" UniqueName="Cargo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EstadoCivil" HeaderText="Estado Civil" UniqueName="EstadoCivil">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RelacionSocio" HeaderText="Relación Socio" UniqueName="RelacionSocio">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <ItemStyle HorizontalAlign="Left" />
                                </MasterTableView>
                            </telerik:RadGrid>
                            <h3>
                                Socios Administración</h3>
                            <asp:ObjectDataSource ID="odsSociosAdministracion" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchAllSociosByRegistroIdAndTipoRelacion" TypeName="CamaraComercio.DataAccess.EF.SRM.RegistrosSociosController">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="registroId" QueryStringField="registroId" Type="Int32" />
                                    <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                                    <asp:Parameter Name="tipoRelacion" DefaultValue="C" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <telerik:RadGrid ID="rgridSociosAdministracion" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" GridLines="None" DataSourceID="odsSociosAdministracion"
                                EnableEmbeddedSkins="False" Skin="NoboxGrid">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <NoRecordsTemplate>
                                        No hay empresas registradas.
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Documento" HeaderText="Documento" UniqueName="Documento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Socio" UniqueName="Socio">
                                            <ItemTemplate>
                                                <span>
                                                    <%#Eval("Accionista")%>
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Cargo" HeaderText="Cargo" UniqueName="Cargo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EstadoCivil" HeaderText="Estado Civil" UniqueName="EstadoCivil">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RelacionSocio" HeaderText="Relación Socio" UniqueName="RelacionSocio">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <ItemStyle HorizontalAlign="Left" />
                                </MasterTableView>
                            </telerik:RadGrid>
                            <h3>
                                Firmas Autorizadas</h3>
                            <asp:ObjectDataSource ID="odsSociosFirmas" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchAllSociosByRegistroIdAndTipoRelacion" TypeName="CamaraComercio.DataAccess.EF.SRM.RegistrosSociosController">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="registroId" QueryStringField="registroId" Type="Int32" />
                                    <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                                    <asp:Parameter Name="tipoRelacion" DefaultValue="F" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <telerik:RadGrid ID="rgridSociosFirmas" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" DataSourceID="odsSociosFirmas"
                                EnableEmbeddedSkins="False" Skin="NoboxGrid">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <NoRecordsTemplate>
                                        No hay empresas registradas.
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Documento" HeaderText="Documento" UniqueName="Documento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Socio" UniqueName="Socio">
                                            <ItemTemplate>
                                                <span>
                                                    <%#Eval("Accionista")%>
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Cargo" HeaderText="Cargo" UniqueName="Cargo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EstadoCivil" HeaderText="Estado Civil" UniqueName="EstadoCivil">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RelacionSocio" HeaderText="Relación Socio" UniqueName="RelacionSocio">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <ItemStyle HorizontalAlign="Left" />
                                </MasterTableView>
                            </telerik:RadGrid>
                        </fieldset>
                    </div>
                    <div class="tab" id="rpProductos">
                        <h3>
                            Productos y Servicios</h3>
                        <asp:ObjectDataSource ID="odsProductos" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchbyRegistroId" TypeName="CamaraComercio.DataAccess.EF.SRM.ViewRegistrosProductosController">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="registroId" QueryStringField="registroId" Type="Int32" />
                                <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <telerik:RadGrid ID="rgridProductos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" DataSourceID="odsProductos"
                            EnableEmbeddedSkins="False" Skin="NoboxGrid">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <NoRecordsTemplate>
                                    No hay productos registrados.
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción" UniqueName="Descripción">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DescripcionSisAmort" HeaderText="Sistema Amortización"
                                        UniqueName="SistemaAmortización">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ItemStyle HorizontalAlign="Left" />
                            </MasterTableView>
                        </telerik:RadGrid>
                        <h3>
                            Sucursales
                        </h3>
                        <asp:ObjectDataSource ID="odsSucursales" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchSucursalesByRegistroId" TypeName="CamaraComercio.DataAccess.EF.SRM.SuscursalesController">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="sociedadId" QueryStringField="sociedadId" Type="Int32" />
                                <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <telerik:RadGrid ID="rgridSucursales" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" DataSourceID="odsSucursales"
                            EnableEmbeddedSkins="False" Skin="NoboxGrid">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <NoRecordsTemplate>
                                    No hay Sucursales registrados.
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción" UniqueName="Descripción">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ItemStyle HorizontalAlign="Left" />
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                    <div class="tab" id="rpReferencias">
                        <h3>
                            Referencias Bancarias</h3>
                        <asp:ObjectDataSource ID="odsBancos" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchReferenciasBancariasByRegistroId" TypeName="CamaraComercio.DataAccess.EF.SRM.ReferenciasBancariasController">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="registroId" QueryStringField="registroId" Type="Int32" />
                                <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <telerik:RadGrid ID="rgridRefBancos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" DataSourceID="odsBancos"
                            EnableEmbeddedSkins="False" Skin="NoboxGrid">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <NoRecordsTemplate>
                                    No hay referencias bancarias registradas.
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Banco" HeaderText="Descripción" UniqueName="Descripción">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ItemStyle HorizontalAlign="Left" />
                            </MasterTableView>
                        </telerik:RadGrid>
                        <h3>
                            Referencias Comerciales</h3>
                        <asp:ObjectDataSource ID="odsComerciales" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="FetchReferenciasComercialesByRegistroId" TypeName="CamaraComercio.DataAccess.EF.SRM.ReferenciasComercialesController">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="registroId" QueryStringField="registroId" Type="Int32" />
                                <asp:QueryStringParameter Name="camaraId" QueryStringField="camaraId" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <telerik:RadGrid ID="rgridRefComerciales" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" DataSourceID="odsComerciales"
                            EnableEmbeddedSkins="False" Skin="NoboxGrid">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" EnableNoRecordsTemplate="true">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <NoRecordsTemplate>
                                    No hay referencias comerciales registradas.
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción" UniqueName="Descripción">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ItemStyle HorizontalAlign="Left" />
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
                <div class="clear" />
            </div>
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
