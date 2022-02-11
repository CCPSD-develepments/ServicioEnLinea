<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="SelectModificacion.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.SelectModificacion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/res/css/Grid.Ccpsd.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            //Objetos en el menu
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hfTipoSociedadId" runat="server" />
    <asp:HiddenField ID="hfTipoServicioId" runat="server" />
    <asp:ObjectDataSource ID="odsServiciosmodificacion" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetServicios" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfTipoServicioId" Name="tipoServicioId" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="empresa">
                 <span class="right normal">
                        <asp:Literal ID="ltNombreSocialTit" runat="server"></asp:Literal></span>
                    Información de la Empresa</h1>
            </div>
            <div id="content_body">
                <fieldset class="form-fieldset">
                    <ul>
                        <li>Sociedad:
                            <asp:Literal ID="ltNombreSocial" runat="server"></asp:Literal>
                        </li>
                    </ul>
                    <h2>Modificaciones a realizar</h2>

                    <ul>
                        <li>
                            <telerik:RadGrid ID="gridModificaciones" runat="server" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="False" Skin="Ccpsd" DataSourceID="odsServiciosmodificacion">
                        <HeaderContextMenu EnableEmbeddedSkins="False">
                        </HeaderContextMenu>
                        <MasterTableView DataKeyNames="ServicioId" DataSourceID="odsServiciosmodificacion">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="A Solicitar">
                                    <ItemTemplate>
                                        <asp:CheckBox Text="&nbsp;" ID="chkServicio" runat="server" CssClass="servicioModificacion"
                                            Checked="false" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Descripcion" DataType="System.String" HeaderText="Servicio">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                        </li>
                        
                        <li>
                            <div class="footer_go"> 
                            <asp:Button ID="btnContinuar" runat="server" CssClass="btn" Text="Continuar" OnClick="btnContinuar_Click" />
                            </div>
                        </li>
                    </ul>
                    
                </fieldset>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
