<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="RegDup.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Shared.RegDup" %>
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
            $("#txtDescripcion").attr('maxlength', '250');
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
                   <h1 id="detalles">
                    <span class="right normal">
                    <asp:Literal ID="litTitulo" runat="server" Text="" />
                    </span>
                    Solicitud Registro Duplicado
                </h1>
            </div>
            <div id="content_body">
                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <label for="txtEstatus" id="lblEstatus" runat="server">
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
                            <label for="txtNoRegistro">
                                Registro Mercantil</label>
                            <asp:Literal runat="server" ID="txtNoRegistro" />
                        </li>
                        <li>
                            <label for="txtRNC">
                                RNC</label>
                            <asp:Literal runat="server" ID="txtRNC" />
                        </li>
                        <li>
                            <label for="txtFechaConstitucion">
                                Fecha Constitución</label>
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
                            <label for="txtEnteRegulado" runat="server" id="lblEntreRegulado">
                                Ente Regulado</label>
                            <asp:Literal runat="server" ID="txtEnteRegulado" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtNumeroResolucion" runat="server" ID="lblNumeroResolucion">Número Resolución</asp:Label>
                            <asp:Literal runat="server" ID="txtNumeroResolucion" />
                        </li>
                        <li>
                        </li>
                    </ul>
                </fieldset>
            <div class="fieldsetCotainer">
                                        <br />
                        <asp:Panel runat="server" ID="pnlCampoDescripcion" ClientIDMode="Static" Visible="True">
                            <ul>
                                <li>
                                    <label for="txtDescripcion">
                                        Comentarios</label></li>
                                <li>
                                    <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="250" ClientIDMode="Static"
                                        TextMode="MultiLine" Rows="4" Width="450px" />
                                    <div id="txtDescripcionComment" class="comments">
                                        <strong>CAMPO OBLIGATORIO. </strong>Está certificación será trabajada por un analista
                                        en la cámara de comercio. Si posees alguna instrucción o solicitud especifica puedes
                                        escribirla aquí. Máximo 250 caracteres.
                                    </div>
                                </li>
                            </ul>
                        </asp:Panel>
                        <br />
<%--                        <h3>
                            Seleccione los documentos a solicitar.</h3>--%>
                        <telerik:RadGrid runat="server" ID="rgDocumentos" AutoGenerateColumns="False"
                                GridLines="None" EnableEmbeddedSkins="false"
                                Skin="NoboxGrid" Visible="False">
                                <ValidationSettings ValidationGroup="ConsultaPersonas" />
                                <MasterTableView>
                                    <NoRecordsTemplate>
                                        No se encontraron documentos en la búsqueda.
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ID" Display="false" HeaderText="ID"
                                            UniqueName="ID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="docpath" Display="false" HeaderText="Ruta"
                                            UniqueName="docpath">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="NOMBRE DOCUMENTO" Display="true" HeaderText="Nombre Documento"
                                            UniqueName="NOMBRE DOCUMENTO">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FECHA_DOCUMENTO" HeaderText="Fecha Documento" UniqueName="FECHA_DOCUMENTO">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CANTIDAD_DE_PAGINAS" HeaderText="Cant Pagina" UniqueName="CANTIDAD_DE_PAGINAS">
                                        </telerik:GridBoundColumn>
<%--                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkVerDocumento" runat="server" CausesValidation="false" Text="Ver" NavigateUrl ="~/Empresas/VisorWeb.aspx?id=" Eval />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                        <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkVerDocumento" DataNavigateUrlFields="ID"
                                            DataNavigateUrlFormatString="~/Empresas/VisorWeb.aspx?id={0}" Target = "_blank">
                                        </telerik:GridHyperLinkColumn>

                                        <telerik:GridTemplateColumn UniqueName="TemplateColumnCheck">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="lnkSeleccionDocumento" runat="server" CausesValidation="true" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                <EditFormSettings>
                                <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
                                </EditFormSettings>
                                </MasterTableView>

                            <FilterMenu EnableEmbeddedSkins="False"></FilterMenu>

                            <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                            </telerik:RadGrid>
<%--                        <asp:ObjectDataSource ID="odsViewDocumentos" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetNuevasSociedadesPendientesDt" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.SociedadesRepository">
                    </asp:ObjectDataSource>--%>
                    </div> 
                <div class="footer_go">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn" 
                        onclick="btnConfirmar_Click" />
                                            <asp:Label runat="server" ID="lblDescripcionObligatoria" CssClass="validator" Text="Debe indicar una descripción"
                            Visible="false" />
                <div class="clear" />

            </div>   
            </div>
            <div class="clear" />

    </div>
    </div>
</asp:Content>
