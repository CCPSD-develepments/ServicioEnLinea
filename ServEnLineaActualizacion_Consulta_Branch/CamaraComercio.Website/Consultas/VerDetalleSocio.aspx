<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="VerDetalleSocio.aspx.cs" Inherits="CamaraComercio.Website.Consultas.VerDetalleSocio" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var validateSession = false;
        $(document).ready(function () {
            //Menu
            $('#subnavigation li').removeClass("active");
            $('#liConsultas').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="socio">Detalle de Propietario/Socio/Accionista <span class="right normal">
                    <asp:Literal runat="server" ID="litQuery" /></span>
                </h1>
            </div>
            <div id="content_body">
                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <label for="lblNombre">
                                Nombres</label>
                            <asp:Label runat="server" ClientIDMode="Static" ID="lblNombre" />
                            &nbsp;
                            <asp:Label runat="server" ClientIDMode="Static" ID="lblSegundoNombre" />
                        </li>
                        <li>
                            <label for="lblApellido">
                                Apellidos</label>
                            <asp:Label runat="server" ClientIDMode="Static" ID="lblApellido" />
                            &nbsp;
                            <asp:Label runat="server" ClientIDMode="Static" ID="lblSegundoApellido" />
                        </li>
                        <li>
                            <label for="lblNumDocumento">
                                No. Documento</label>
                            <asp:Label runat="server" ClientIDMode="Static" ID="lblNumDocumento" />&nbsp;
                            <asp:Label runat="server" ClientIDMode="Static" ID="lblTipoDocumento" />
                        </li>
                    </ul>
                    <h3>Es Propietario/Socio/Accionista en las siguientes empresas:</h3>
                    <telerik:RadGrid runat="Server" ID="rgAccionistaEmpresas" GridLines="None" AutoGenerateColumns="False"
                        OnItemDataBound="rgridEmpresas_ItemDataBound" EnableEmbeddedSkins="False" Skin="NoboxGrid">
                        <MasterTableView>
                            <NoRecordsTemplate>
                                No se encontraron registros
                            </NoRecordsTemplate>
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="RegistroId" HeaderText="Registro ID" DataField="RegistroId"
                                    Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="NumeroRegistro" HeaderText="No. Registo" DataField="NumeroRegistro"
                                    Display="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="SocioId" HeaderText="Socio Id" DataField="SocioId"
                                    Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="FechaConstitucion" HeaderText="Fecha Constitución"
                                    DataField="FechaConstitucion" DataFormatString="{0:dd/MMM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="NombreSocial" HeaderText="Nombre/Razón Social"
                                    DataField="NombreSocial">
                                </telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn UniqueName="Estatus_fecha" HeaderText="Estatus"
                                    DataField="Estatus_fecha">
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn UniqueName="RegistroRelacion" HeaderText="Cargos/Relación"
                                    DataField="RegistroRelacion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Rnc" HeaderText="RNC" DataField="Rnc">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkVerDetalleId" runat="server" CausesValidation="false" Text="Seleccionar" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </fieldset>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
