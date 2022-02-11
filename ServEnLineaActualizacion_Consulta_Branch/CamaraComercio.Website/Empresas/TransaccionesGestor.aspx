<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/res/nobox.master" CodeBehind="TransaccionesGestor.aspx.cs" Inherits="CamaraComercio.Website.Empresas.TransaccionesGestor" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Import Namespace="CamaraComercio.Website" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>

<asp:Content ID="cntHead" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Estilos -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link href="/WebResource.axd?d=w90t1kPK2FCTq1I7SosAJiUD53gWPG1M6lEromu9Tt9wi9gvupD7vtcf_67e7PKlROEUxsMDnQchHuY61NBa0i0Si769zCNsHsPL2D_sarvHf0OQI0slFex9qlw5If7YYTmbMc-WGUnUU0crFmr7LJAc7ds1&amp;t=636875313358489234" type="text/css" rel="stylesheet" class="Telerik_stylesheet">
    <link href="/res/css/Oficina.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('#btnCancel').click(function () {
                window.location.href = '/Account/UsersAdmin.aspx';
            });
        });
    </script>
</asp:Content>
<asp:Content ID="cntMain" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <asp:HiddenField runat="server" ID="hfTabIndex" ClientIDMode="Static" Value="0" />
                <h1 id="portafolio">Transacciones en Proceso</h1>
                <p>Estas son las transacciones que están siendo procesadas.</p>
            </div>
            <div id="content_body">
                <h2>Nombre Gestor: <span id="lblNombreGestor" runat="server"></span></h2>
                <telerik:RadGrid ID="rgridNuevasPendientes" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    GridLines="None" DataSourceID="odsEmpresasNuevas" AllowSorting="True"
                    Skin="NoboxGrid" EnableEmbeddedSkins="False">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="odsEmpresasNuevas">
                        <Columns>
                            <telerik:GridBoundColumn DataField="TransaccionID" HeaderText="TransaccionID" UniqueName="TransaccionID"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Camara" SortExpression="CamaraID"
                                UniqueName="CamaraID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RegistroID" DataType="System.Int32" HeaderText="RegistroID"
                                SortExpression="RegistroID" UniqueName="RegistroID" Visible="false">
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
                                UniqueName="SiglasTipoSociedad">
                                <ItemTemplate>
                                    <asp:Label ID="SiglasTipoSociedadLabel" runat="server" Text='<%# Eval("SiglasTipoSociedad") %>'
                                        ToolTip='<%# Eval("TipoSociedad") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FechaSolicitud" DataType="System.DateTime" HeaderText="Fecha"
                                SortExpression="FechaSolicitud" UniqueName="FechaSolicitud">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EstatusTransaccion" HeaderText="Estado"
                                SortExpression="EstatusTransaccion" UniqueName="Estado">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn Text="Ver" UniqueName="lnkActions" DataNavigateUrlFields="TransaccionID"
                                DataNavigateUrlFormatString="VerDetalleTransaccion.aspx?nSolicitud={0}">
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridHyperLinkColumn Text="Imprimir" UniqueName="lnkActions" DataNavigateUrlFields="TransaccionID"
                                DataNavigateUrlFormatString="/Empresas/ImprimirSolicitud.aspx?nSolicitud={0}">
                            </telerik:GridHyperLinkColumn>

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
                <asp:ObjectDataSource ID="odsEmpresasNuevas" runat="server" OnSelecting="odsEmpresasNuevas_Selecting" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetNuevasSociedadesPendientesHijoDt" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.SociedadesRepository">
                    <SelectParameters>
                        <asp:ProfileParameter Name="username" PropertyName="username" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <div class="divSubmit" style="margin-top: 8px;">
                    <button type="button" class="btn" id="btnCancel">Retornar</button>
                    <div class="clear" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
