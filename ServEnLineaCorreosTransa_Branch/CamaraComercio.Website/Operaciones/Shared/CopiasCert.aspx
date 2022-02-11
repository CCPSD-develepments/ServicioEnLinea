<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="CopiasCert.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Shared.CopiasCert" %>

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
            <div id="content_header" style="display:table; width:100%;">
                <div id="detalles" style="display:table-cell; min-width:375px; vertical-align:middle">
                    <h1 >
                        <%--<span class="right normal">
                            <asp:Literal ID="litTitulo" runat="server" Text="" />
                        </span>--%>
                        Solicitud copias certificadas
                    </h1>
                </div>
                <div class="right normal" style="display:table-cell; padding-left:30px; color:#00587C; text-align:right;">
                    <asp:Label ID="litTituloM" CssClass="right normal"  runat="server" style="font-size: 2.3em; text-align:right; width:100%;"></asp:Label>
                </div>
            </div>
            <div id="content_body">
                <asp:Label ID="lblTransaccionId" runat="server" Text="0" Visible="false"></asp:Label>
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
                            <label for="txtDuracionSociedad" id="lblDuracionSociedad" runat="server">
                                Duración Sociedad</label>
                            <asp:Literal runat="server" ID="txtDuracionSociedad" />
                        </li>
                        <li>
                            <label for="txtDuracionConsejo" id="lblDuracionConsejo" runat="server">
                                Duración Consejo</label>
                            <asp:Literal ID="txtDuracionConsejo" runat="server" />
                        </li>
                        <li>
                            <label for="txtFechaUltActo" id="lblFechaUltActo" runat="server">
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
                        <li></li>
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
                                    TextMode="MultiLine" Rows="4" Width="450px"  style="text-transform:uppercase;"/>
                                <div id="txtDescripcionComment" class="comments">
                                    <p>Favor indicar en este campo el detalle de su solicitud especificando el/los documentos deseados, así como la fecha de los mismos en caso de conocerla.</p>
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
                                    DataNavigateUrlFormatString="~/Empresas/VisorWeb.aspx?id={0}" Target="_blank">
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
                    <asp:Label runat="server" ID="lblDescripcionObligatoria" CssClass="validator" Text="Debe indicar una descripción"
                        Visible="false" />

                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn"
                        OnClick="btnConfirmar_Click" />
                    <div class="clear" />

                </div>
            </div>
            <div class="clear" />

        </div>
    </div>
</asp:Content>
