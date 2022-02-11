<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="VerDetalleEmpresa.aspx.cs" Inherits="CamaraComercio.Website.Consultas.VerDetalleEmpresa" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Inline user script -->
    <script type="text/javascript" language="javascript">
        var validateSession = false;
        $(document).ready(function () {
            //Menu
            $('#subnavigation li').removeClass("active");
            $('#liConsultas').addClass("active");

            //Tabs
            $("#tabs").tabs();
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
            <div id="content_header" style="display:table">
                   <%--<h1 id="detalles">
                        <span class="right normal">
                        <asp:Literal ID="litTitulo" runat="server" Text="" />
                        </span>
                    Detalles de Empresa
                    </h1>--%>
                <div id="detalles" style="display:table-cell; min-width:375px; vertical-align:middle">
                    <h1 >
                        Detalles de Empresa
                    </h1>
                </div>
                <div class="right normal" style="display:table-cell; padding-left:30px; color:#00587C; text-align:right; vertical-align:middle;">
                    <asp:Label ID="litTituloM" CssClass="right normal"  runat="server" style="font-size: 2.3em; text-align:right; width:100%;"></asp:Label>
                </div>
            </div>
            <div id="content_body">
                <div id="acciones" class="submenu floatRight">
                    <fieldset class="form-fieldset">
                        <ul>
                            <asp:HyperLink runat="server" ID="lnkCertificacion" Text='Certificación' 
                                CssClass="btn"></asp:HyperLink>                            
                        </ul>
                        <ul>
                            <asp:HyperLink runat="server" ID="lnkCopiasRegistradas"  Text='Copias Certificadas' 
                                CssClass="btn"></asp:HyperLink>                            
                        </ul>
                                </fieldset>
                </div>

                <fieldset class="form-fieldset" style="width:60%;">
                    <ul>
                        <li>
                            <label for="txtEstatus" runat="server" id="lblEstatus">
                                Estatus</label>
                            <asp:Literal runat="server" ID="txtStatus" />
                        </li>
                        <li>
                            <label for="txtDenominacion">
                                Denominación</label>
                            <asp:Literal runat="server" ID="txtDenominacion" />
                        </li>
                        <li>
                            <label for="txtTipoSociedad">
                                Tipo Sociedad</label>
                            <asp:Literal runat="server" ID="txtTipoSociedad" />
                        </li>
                        <li>
                            <label for="txtRNC">
                                RNC</label>
                            <asp:Literal runat="server" ID="txtRNC" />
                        </li>
                        <li>
                            <label for="txtCedula" runat="server" id="lblCedula" visible="false">
                                Documento</label>
                            <asp:Literal runat="server" ID="txtCedula" visible="false"/>
                        </li>
                        <li>
                            <label for="txtFechaConstitucion" runat="server" id="lblFechaConstitucion">
                                Fecha Constitución</label>
                            <asp:Literal runat="server" ID="txtFechaConstitucion" />
                        </li>
                        <li>
                            <label for="txtDuracionSociedad" runat="server" id="lblDuracionSociedad">
                                Duración Sociedad</label>
                            <asp:Literal runat="server" ID="txtDuracionSociedad" />
                        </li>
                        <li>
                            <label for="txtDuracionConsejo" id="lblDuracionConsejo" runat="server">
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
                            <asp:Label AssociatedControlID="txtNumeroNaveInd" runat="server" ID="lbltxtNumeroNaveInd">
                    No. Nave Ind.</asp:Label>
                            <asp:Literal runat="server" ID="txtNumeroNaveInd" />
                        </li>
                    </ul>
                </fieldset>
                
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
