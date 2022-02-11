<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="Confirmacion.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.Confirmacion" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls"
    TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Referencia para el js especifico a este form -->
    <script type="text/javascript" src="/res/js/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="/res/js/ui.adecuacion.js"></script>
    <link href="../../res/css/ConfirmationPrint.css" rel="stylesheet" type="text/css" media = "print" />
    <!--Objetos en el menu-->
    <script type="text/javascript">
        $(document).ready(function () {
            //Menu
            $('#navigation li').removeClass("active");
            $('#liNavCreacion').removeClass("active");
            $('#liNavRM').addClass("active");
            $('#subnavigation li').removeClass("active");

            $('#btnConfirmarDatos').click(function (e) {
                e.preventDefault();

                $("#dialog-confirm").attr("title", "Confirmación de Solicitud");
                $("#dialog-content").text("Una vez confirmados estos datos, no podrán ser modificados.");
                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: 250,
                    width: 400,
                    modal: true,
                    buttons: {
                        "Confirmar Solicitud": function () {
                            $(this).dialog("close");
                            <%=this.Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this.btnConfirmarDatos))%>;
                        },
                        "Cancelar": function () {
                            $(this).dialog("close");
                            return false;
                        }
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="creacion">
                    Modificación de Empresas <span class="right normal">
                        <asp:Label runat="server" ID="lblNombreEmpresa" />
                        /
                        <asp:Label runat="server" ID="lblTipoEmpresa" />
                    </span>
                    <asp:Literal ID="ltServicio" runat="server" />
                </h1>
            </div>
            <div id="content_body">
                <div class="stepsTl" id="stepsTl">
                    <ul>
                        <li><a href="#" class="stepNobox">Solicitud</a></li>
                        <li><a href="#" class="stepNobox">Datos Generales</a></li>
                        <li><a href="#" class="stepDone">Datos de la Empresa</a></li>
                        <li><a href="#" class="stepLast">Verificación</a></li>
                        <li><a href="#">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <div id="confirmacionDiv">
                    <h2>
                        Verificación de Datos</h2>
                    <h5>
                        Verifica la información de la solicitud. Si no estas satisfecho con algún campo
                        puedes hacer click en el botón de "Modificar. Si verificaste la información y confirmaste
                        que es correcta haz click en "Confirmar". <strong>Nota Importante: Una vez confirmados
                            estos datos, no podrán ser modificados. </strong>
                    </h5>
                    <h4>
                        Servicios solicitados:
                        </h4>
                        <fieldset class="form-fieldset">
                        <div id="listadoServicios">
                            <asp:Literal runat="server" ID="litListadoServicios" ClientIDMode="Static" />
                        </div>

                        <div id="infoSociedadDiv">
                            <ul>
                                <li>
                                    <h3>
                                        Información de Registro</h3>
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="litNoRegistroLbl" AssociatedControlID="litNoRegistro">
                                        No. Registro
                                    </asp:Label>
                                    <asp:Literal runat="server" ID="litNoRegistro" />
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="litRncLbl" AssociatedControlID="litRnc">
                                        RNC
                                    </asp:Label>
                                    <asp:Literal runat="server" ID="litRnc" />
                                </li>
                                <li>
                                    <label>
                                        Denominación Social
                                    </label>
                                    <label>
                                        <asp:Literal ID="litRazonSocial" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Tipo de Empresa</label>
                                    <label>
                                        <asp:Literal ID="litTipoEmpresa" runat="server"></asp:Literal>
                                    </label>
                                </li>
                            </ul>
                            <h3>
                                Información de Empresa</h3>
                            <ul>
                                <li>
                                    <cc1:LabelOfv runat="server" ID="lblCapitalSocialTitle" AssociatedControlID="litCapitalSocial"
                                        PropertyName="CapitalSocial">
                            Capital Social
                                </cc1:LabelOfv>
                                    <label>
                                        <asp:Literal ID="litCapitalSocial" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <cc1:LabelOfv runat="server" ID="lblCapitalSuscritoTitle" AssociatedControlID="litCapitalSuscrito"
                                        PropertyName="CapitalSuscrito">
                            Capital Suscrito    
                                </cc1:LabelOfv>
                                    <label>
                                        <asp:Literal ID="litCapitalSuscrito" runat="server" />
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Bienes Raíces
                                    </label>
                                    <label>
                                        <asp:Literal ID="litBienesRaices" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <cc1:LabelOfv runat="server" PropertyName="Activos" AssociatedControlID="litActivos"
                                        ID="lblActivosTitle">                            
                            Activos
                                </cc1:LabelOfv>
                                    <label>
                                    <cc1:LabelOfv ID="litActivos" runat="server" PropertyName="Activos" />
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Fecha Inicio Operaciones</label>
                                    <label>
                                        <asp:Literal ID="litFechaInicio" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Fecha de Estatutos / Asamblea Constitutiva</label>
                                    <label>
                                        <asp:Literal ID="litFechaAsamblea" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Duración de la Sociedad</label>
                                    <label>
                                        <asp:Literal ID="litDuracionSociedad" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Duración del Consejo</label>
                                    <label>
                                        <asp:Literal ID="litDuracionConsejo" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Regulación</label>
                                    <label>
                                        <asp:Literal ID="litregulacion" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Empleados</label>
                                    <label>
                                        <asp:Literal ID="litEmpleados" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Referencias Comerciales</label>
                                    <label>
                                        <asp:Literal ID="litReferenciasComerciales" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Referencias Bancarias</label>
                                    <label>
                                        <asp:Literal ID="litReferenciasBancarias" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Nombre Comercial</label>
                                    <label>
                                        <asp:Literal ID="litNombreComercial" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        No. Registro ONAPI</label>
                                    <label>
                                        <asp:Literal ID="litRegistroOnapi" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Sucursales</label>
                                    <label>
                                        <asp:Literal ID="litSucursales" runat="server"></asp:Literal>
                                    </label>
                                </li>
                            </ul>
                        </div>
                        <div id="infoGeneralDiv" style="width: 400px">
                            <h3>
                                Informaciones de Contacto Comercial</h3>
                            <ul>
                                <li>
                                    <label>
                                        Nacionalidad
                                    </label>
                                    <label>
                                    <asp:Literal runat="server" ID="litNacionalidad" />
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Dirección</label>
                                    <label>
                                        <asp:Literal ID="litDireccion" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Teléfono Primario</label>
                                    <label>
                                        <asp:Literal ID="litTelefonoPrimario" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Teléfono Secundario</label>
                                    <label>
                                        <asp:Literal ID="litTelefonoSecundario" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Fax</label>
                                    <label>
                                        <asp:Literal ID="litFax" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        E-mail</label>
                                    <label>
                                        <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Dirección Web</label>
                                    <label>
                                        <asp:Literal ID="litWebsite" runat="server"></asp:Literal>
                                    </label>
                                </li>
                            </ul>
                            <h3>
                                Actividades de la Empresa</h3>
                            <ul>
                                <li>
                                    <label>
                                        Descripción del Negocio</label>
                                    <label>
                                        <asp:Literal ID="litDescripcionNegocio" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Principales Productos</label>
                                    <label>
                                        <asp:Literal ID="litPrincipalesProductos" runat="server"></asp:Literal>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        Actividades</label>
                                    <label>
                                        <asp:Literal ID="litActividades" runat="server"></asp:Literal>
                                    </label>
                                </li>
                            </ul>
                        </div>
                    </fieldset>
                    <div id="sociosDiv">
                        <h3>
                            Información de Propietarios/Socios/Accionistas</h3>
                        <telerik:RadGrid runat="server" ID="gvSociosT" EnableEmbeddedSkins="False" 
                            Skin="NoboxGrid" onitemdatabound="gvSociosT_ItemDataBound" 
                            onneeddatasource="gvSociosT_NeedDataSource" GridLines="None">
<MasterTableView AutoGenerateColumns="False">
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" 
            UniqueName="column1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Cargos" HeaderText="Cargos" 
            UniqueName="column2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Documento" HeaderText="Documento" 
            UniqueName="column3">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Cuotas" HeaderText="Cuotas" 
            UniqueName="column4">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Direccion" HeaderText="Dirección" 
            UniqueName="column">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableEmbeddedSkins="False"></FilterMenu>

<HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                        </telerik:RadGrid>
                        <div class="clear" />
                    </div>
                    <div class="footer_go">
                        <asp:LinkButton ID="btnConfirmarDatos" runat="server" CssClass="btn" OnClick="btnConfirmarDatos_Click"
                            ClientIDMode="Static" ToolTip="Confirmar que los datos mostrados son válidos"
                            Text="Confirmar" />
                        <asp:LinkButton ID="btnModificarDatos" runat="server" CssClass="btn" OnClick="btnModificarDatos_Click"
                            ToolTip="Si necesita modificar uno o varios datos de su registro" Text="Modificar" />
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
                <div class="clear" />
            </div>
            <!-- end grid_24 -->
        </div>
</asp:Content>
