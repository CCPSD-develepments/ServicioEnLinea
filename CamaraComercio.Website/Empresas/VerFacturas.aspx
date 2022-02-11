<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="VerFacturas.aspx.cs" Inherits="CamaraComercio.Website.Empresas.VerFacturas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Ver Detalle de Facturas</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    Facturas Complementarias</h1>
            </div>
            <div id="content_body">
                <telerik:RadGrid ID="rgridHistorico" runat="server" AutoGenerateColumns="False" GridLines="None"
                    Width="90%" AllowPaging="True" AllowSorting="True" DataSourceID="odsHistoricosTransacciones"
                    EnableEmbeddedSkins="false" Skin="NoboxGrid"
                    OnItemCommand="rgridHistorico_OnItemCommand">
                    <MasterTableView DataSourceID="odsHistoricosTransacciones" NoMasterRecordsText="No existen facturas pendientes."
                        DataKeyNames="FacturaId,CamaraID">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Número Factura" UniqueName="FacturaId" DataField="FacturaId">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Fecha Factura" UniqueName="FachaFactura" DataField="Fecha"
                                DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="CamaraId" HeaderText="Cámara" UniqueName="CamaraID">
                                <ItemTemplate>
                                    <asp:Label ID="NombreCamaraLabel" runat="server" Text='<%# Eval("CamaraID") %>' ToolTip='<%# Eval("Camara") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="Ncf" UniqueName="Ncf" DataField="Ncf">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Total Factura" UniqueName="Solicitud" DataField="TotalFactura"
                                DataFormatString="{0:N}">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn HeaderText="&nbsp;" ConfirmText="Desea pagar su factura?"
                                ConfirmTitle="Pagar su factura" CommandName="Pagar" ButtonType="LinkButton" Text="Pagar"
                                ConfirmDialogType="RadWindow">
                            </telerik:GridButtonColumn>
                            <%--       <telerik:GridTemplateColumn HeaderText="&nbsp;">
                    <ItemTemplate>
                        <asp:LinkButton OnClick="lbPagarFacturar_Click" ID="lbPagarFacturar" runat="server"
                            Text="Pagar" CommandArgument='<%# Eval("FacturaId") %>'></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                </telerik:RadGrid>
                <br />
                <asp:ObjectDataSource ID="odsHistoricosTransacciones" runat="server" EnablePaging="True"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetFacturas" TypeName="CamaraComercio.DataAccess.EF.SRM.FacturasRepository"
                    SelectCountMethod="GetCountFacturas">
                    <SelectParameters>
                        <asp:ProfileParameter Name="userName" PropertyName="UserName" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
