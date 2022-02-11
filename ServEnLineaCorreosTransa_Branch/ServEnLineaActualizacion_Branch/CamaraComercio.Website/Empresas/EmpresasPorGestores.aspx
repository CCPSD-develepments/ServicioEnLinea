<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/res/nobox.master" CodeBehind="EmpresasPorGestores.aspx.cs" Inherits="CamaraComercio.Website.Empresas.EmpresasPorGestores" %>

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
            var $table = $('#rgridEmp').find('table');

            $('#txtTableFilter').keyup(function () {
                toggleRows($(this).val(), $('#ddlFiltroAcceso').val());
            });

            $('#ddlFiltroAcceso').change(function () {
                toggleRows($('#txtTableFilter').val(), $(this).val());
            });

            $('.check-empresa').click(function () {
                toggleRows($('#txtTableFilter').val(), $('#ddlFiltroAcceso').val());
            });

            $('#checkAllEmpresas').click(function () {
                var checked = this.checked
                $table.find('tbody > tr:visible').each(function () {
                    $(this).find('td.check-empresa > input[type="checkbox"]').attr('checked', checked);
                });
                toggleRows($('#txtTableFilter').val(), $('#ddlFiltroAcceso').val());
            });

            function toggleRows(text, filterAccess) {
                filterAccess = Number(filterAccess);
                if (isNaN(filterAccess)) filterAccess = 0;

                text = text.toLowerCase();
                $table.find('tbody > tr').each(function () {
                    var nombreSocial = $(this).find('td.nombre-social').text().toLowerCase().trim();
                    var checked = $(this).find('td.check-empresa > input[type="checkbox"]').is(':checked');

                    if (nombreSocial.indexOf(text) !== -1) {
                        if (filterAccess === 0) $(this).show();
                        else if (filterAccess === 1 && checked) $(this).show();
                        else if (filterAccess === 1 && !checked) $(this).hide();
                        else if (filterAccess === 2 && checked) $(this).hide();
                        else if (filterAccess === 2 && !checked) $(this).show();
                    } else {
                        $(this).hide();
                    }
                });
            }

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
                <h1 id="portafolio">Asignar Empresas a Gestor
                </h1>

            </div>
            <div id="content_body">
                <h2>Nombre Gestor: <span id="lblNombreGestor" runat="server"></span></h2>
                <div>
                    <label>Buscar</label>
                    <input type="text" class="tb" id="txtTableFilter" />
                    <select class="tb" id="ddlFiltroAcceso">
                        <option value="0">Todas</option>
                        <option value="1">Acceso Permitido</option>
                        <option value="2">Acceso Denegado</option>
                    </select>
                </div>
                <telerik:RadGrid ID="rgridEmp" ClientIDMode="Static" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataSourceID="odsEmpresasRegistradas" GridLines="None"
                    Skin="NoboxGrid" EnableEmbeddedSkins="False" OnItemDataBound="rgridEmp_ItemDataBound">
                    <MasterTableView DataSourceID="odsEmpresasRegistradas">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="SociedadId" HeaderText="Sociedad ID" Visible="false"
                                UniqueName="SociedadId">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TipoSociedadId" HeaderText=" Tipo Sociedad ID" Visible="false"
                                UniqueName="TipoSociedadId">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PersonaId" HeaderText="Sociedad ID" Visible="false"
                                UniqueName="PersonaId">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Cámara" SortExpression="CamaraID"
                                UniqueName="CamaraID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NumeroRegistro" DataType="System.Int32" HeaderText="No. Registro"
                                SortExpression="RegistroId" UniqueName="RegistroId">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="NombreSocialPersona" HeaderText="Empresa" UniqueName="NombreSocial">
                                        <ItemTemplate>
                                            <asp:Image ID="EstadoImg" runat="server" ImageUrl='/res/img/icons/bullet_green.png'
                                                ToolTip='Activa' />
                                            <asp:Label ID="NombreSocialLabel" runat="server" Text='<%# Eval("NombreSocialPersona") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="Sufijo" HeaderText="Tipo" SortExpression="Sufijo"
                                UniqueName="Sufijo">
                                <ItemTemplate>
                                            <asp:Label ID="lblTipoEntidad" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FechaConstitucion" DataType="System.DateTime"
                                DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Constitución" SortExpression="FechaConstitucion"
                                UniqueName="FechaConstitucion">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="CheckEmpresa" HeaderText="Permitir Acceso" ItemStyle-CssClass="check-empresa">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkAllEmpresas" ClientIDMode="Static" /> Permitir Acceso
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkEmpresa" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                UpdateImageUrl="Update.gif">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                </telerik:RadGrid>
                <asp:ObjectDataSource ID="odsEmpresasRegistradas" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="FetchAllEntidadesC" SelectCountMethod="FetchAllEntidadesCount"
                    TypeName="CamaraComercio.DataAccess.EF.SRM.SociedadesController" StartRowIndexParameterName="pagInicio"
                    MaximumRowsParameterName="pagTamano" EnablePaging="True">
                    <SelectParameters>
                        <asp:ProfileParameter Name="usuario" PropertyName="username" Type="String" />
                        <asp:Parameter Name="estado" Type="Object" DefaultValue="2" />
                        <asp:ControlParameter ControlID="rgridEmp" Name="pagInicio" PropertyName="CurrentPageIndex"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="rgridEmp" Name="pagTamano" PropertyName="PageSize"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <div class="divSubmit" style="margin-top: 8px;">
                    <button type="button" class="btn" id="btnCancel">Cancelar</button>
                    <asp:Button Text="Guardar" CssClass="btn" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                    <div class="clear" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
