<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="CopiasCertificadas.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Shared.CopiasCertificadas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <asp:Label runat="server" ID="lblHidSelectedCamaraID" Visible="false" />
    <asp:Label runat="server" ID="lbHidSelectedRegistro" Visible="false" />
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
            </div>
            <div id="content_body">
                <asp:MultiView runat="server" ID="mvCopiasCertificadas" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vSearch">
                        <fieldset class="form-fieldset">
                            <h1>
                                Solicitud de Copias Certificadas - Búsqueda de Empresa</h1>
                            <ul>
                                <li>
                                    <label for="txtBusqueda">
                                        Búsqueda</label>
                                    <asp:TextBox runat="server" ID="txtBusqueda" CssClass="tb wideInput" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="lblCamara">
                                        Cámara de Comercio</label>
                                    <asp:DropDownList runat="server" ID="ddlCamara" CssClass="wideInput" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </li>
                                <li>
                                    <label for="ddlTipoBusqueda">
                                        Tipo de búsqueda</label>
                                    <asp:DropDownList runat="server" ID="ddlTipoBusqueda" CssClass="wideInput" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <div class="footer_go"> 
                                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"
                                        class="btn" />
                                        </div>
                                </li>
                                <li></li>
                            </ul>
                            <div class="clear" />
                            <telerik:RadGrid ID="rgridEmpresas" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" OnItemCommand="rgridEmpresas_ItemCommand">
                                <MasterTableView>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="NumeroRegistro" HeaderText="No. Registro" UniqueName="NumeroRegistro">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Empresa/Sociedad" UniqueName="NombreSocial">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FechaConstitucion" HeaderText="Fecha Constitución"
                                            UniqueName="FechaConstitucion">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Select"
                                                    CommandArgument='<%# Eval("NumeroRegistro") + "-" + Eval("NombreSocial")%>' Text="Seleccionar"></asp:LinkButton></ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView></telerik:RadGrid>
                            <asp:ObjectDataSource ID="odsDocumentosTransaccion" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetDocumentosByNoRegistroDt" TypeName="CamaraComercio.DataAccess.EF.SRM.DocumentosTransaccionesRepository">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lbHidSelectedRegistro" Name="noRegistro" PropertyName="Text"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="lblHidSelectedCamaraID" Name="camaraID" PropertyName="Text"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </fieldset>
                    </asp:View>
                    <asp:View runat="server" ID="vDocumentos">
                        <h1>
                            Solicitud de Copias Certificadas - Selección Documentos (<asp:Literal runat="server"
                                ID="lblNombreEmpresa" />)</h1>
                        <telerik:RadGrid ID="rgridDocumentos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" PageSize="20">
                            <MasterTableView>
                                <NoRecordsTemplate>
                                    No se encontraron registros con la búsqueda realizada.
                                </NoRecordsTemplate>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="DocumentoTransaccionID" Display="False" DataField="DocumentoTransaccionID"
                                        DataType="System.Int32" EmptyDataText="0">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaDocumento" HeaderText="Fecha Documento"
                                        UniqueName="FechaDocumento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaModificacion" HeaderText="Fecha Registro"
                                        UniqueName="FechaModificacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreDocumento" HeaderText="Documento" UniqueName="TipoDocumento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn DataField="CostoCopia" HeaderText="Costo" UniqueName="CostoCopia"
                                        Aggregate="Sum" DataFormatString="{0:n2}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridNumericColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="Seleccionar">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSeleccionDoc" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView></telerik:RadGrid>
                        
                        <div class="footer_go"> 
                        <asp:Button runat="server" ID="btnSeleccionarDocs" Text="Confirmar Selección" CssClass="btn"
                            OnClick="btnSeleccionarDocs_Click" />
                            </div>
                        
                    </asp:View>
                    <asp:View runat="server" ID="vPrecios">
                        <h1>
                            Solicitud de Copias Certificadas - Confirmación
                        </h1>
                        <telerik:RadGrid ID="rgridConfirmacionDocs" runat="server" AutoGenerateColumns="False"
                            GridLines="None">
                            <MasterTableView ShowFooter="True">
                                <NoRecordsTemplate>
                                    No se han seleccionado documentos.
                                </NoRecordsTemplate>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="FechaDocumento" HeaderText="Fecha Documento"
                                        UniqueName="FechaDocumento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaModificacion" HeaderText="Fecha Registro"
                                        UniqueName="FechaModificacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreDocumento" HeaderText="Documento" UniqueName="TipoDocumento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn DataField="CostoCopia" HeaderText="Costo" UniqueName="CostoCopia"
                                        Aggregate="Sum" DataFormatString="{0:n2}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridNumericColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br />

                        <div class="footer_go"> 
                        <asp:Button ID="btnModificarDoca" runat="server" CssClass="btn" Text="Modificar"
                            OnClick="btnModificarDoca_Click" />
                        <asp:Button ID="btnConfirmarDocs" runat="server" CssClass="btn" Text="Confirmar" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
