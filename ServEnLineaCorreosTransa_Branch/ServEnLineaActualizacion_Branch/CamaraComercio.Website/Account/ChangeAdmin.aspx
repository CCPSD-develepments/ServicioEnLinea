<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="ChangeAdmin.aspx.cs" Inherits="CamaraComercio.Website.Account.ChangeAdmin" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".selectUsuario").click(function (e) {

                return confirm("Está seguro que desea delegar este usuario como el nuevo administrador?");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    Cambio de Administrador
                </h1>
            </div>
            <div id="content_body">
                <asp:MultiView runat="server" ID="mv" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vCambio">
                            <h3>
                                Importante!</h3>
                            <p>
                                Este formulario realiza un cambio de responsabilidad de administración para todos
                                los usuarios de esta empresa. Si está seguro que desea ceder el poder administrativo
                                de su usuario por favor escoja el nuevo administrador de la lista:
                            </p>
                            <telerik:RadGrid ID="gvUsers" runat="server" AutoGenerateColumns="False" GridLines="None"
                                DataSourceID="odsUsers" OnItemCommand="gvUsers_ItemCommand" GroupingEnabled="False">
                                <ClientSettings EnableRowHoverStyle="true" />
                                <MasterTableView DataSourceID="odsUsers">
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn HeaderText="Nombre Completo" UniqueName="NombreSolicitante"
                                            DataField="NombreSolicitante">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Correo Electrónico" UniqueName="Email" DataField="Email">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Nombre Usuario" UniqueName="UserName" DataField="UserName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Select"
                                                    Text="Seleccionar" CssClass="selectUsuario"></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                            <asp:ObjectDataSource ID="odsUsers" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchByUsuarioPadre" TypeName="CamaraComercio.DataAccess.EF.Membership.UsuariosController">
                                <SelectParameters>
                                    <asp:Parameter Name="usuarioPadre" Type="String" />
                                    <asp:Parameter DefaultValue="true" Name="traerActivos" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </asp:View>

                    <asp:View runat="server" ID="vConfirm">
                        <h3>Usuario cambiado con éxito</h3>

                        <p>
                            Se ha delegado el control administrativo de esta empresa a otro usuario. 
                            <a href="/Empresas/Oficina.aspx">Volver al listado de empresas</a>
                        </p>
                    </asp:View>
                </asp:MultiView>
            </div>
            <!-- End content_body -->
        </div>
        <!-- End grid_24 -->
    </div>
    <!-- End container_24 -->
</asp:Content>
