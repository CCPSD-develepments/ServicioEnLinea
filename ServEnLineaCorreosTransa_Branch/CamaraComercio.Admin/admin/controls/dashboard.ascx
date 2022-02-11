<%@ Control Language="C#" AutoEventWireup="true" Inherits="admin_controls_dashboard" Codebehind="dashboard.ascx.cs" %>
<div class="adminHelp">
    <br />
    Esta página provee estadisticas de los usuarios registrados.
</div>
<link href="../themes/dark/default.css" rel="stylesheet" type="text/css" />
<table class="dashboardCategoryWrap">
    <tr>
        <td>
            <div class="dashboardCategoryTitle dashboardTopPadding">
                Nuevos Miembros</div>
            <asp:Repeater ID="rptNewestMembers" runat="server" DataSourceID="odsNewestMembers">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">
                            <%# Eval("UserName") %></span> <span style="float: right;">
                                <%# Eval("CreateDate") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsNewestMembers" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetNewestMembers" TypeName="wsat_DashNewestMembersTableAdapter"></asp:ObjectDataSource>
        </td>
        <td>
            <div class="dashboardCategoryTitle dashboardTopPadding">
                Estatus de Registro</div>
            <asp:Repeater ID="rptLockedOut" runat="server" DataSourceID="odsLockedOut">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Cuentas Bloqueadas</span> <span style="float: right;">
                            <%# Eval("LockedOut") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLockedOut" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLockedOut" TypeName="wsat_DashStatusTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptUnapproved" runat="server" DataSourceID="odsUnapproved">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Cuentas No Aprobadas</span> <span style="float: right;">
                            <%# Eval("Unapproved") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsUnapproved" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountUnapproved" TypeName="wsat_DashStatusTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptTotalCount" runat="server" DataSourceID="odsTotalCount">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Total de Cuentas</span> <span style="float: right;">
                            <%# Eval("TotalCount") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsTotalCount" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTotalCount" TypeName="wsat_DashStatusTableAdapter"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td>
            <div class="dashboardCategoryTitle">
                Ultimos Accesos</div>
            <asp:Repeater ID="rptLatestLogins" runat="server" DataSourceID="odsLatestLogins">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">
                            <%# Eval("UserName") %></span> <span style="float: right;">
                                <%# Eval("LastLoginDate") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLatestLogins" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLatestLogins" TypeName="wsat_DashLatestLoginsTableAdapter"></asp:ObjectDataSource>
        </td>
        <td>
            <div class="dashboardCategoryTitle">
                Ultimo Acceso</div>
            <asp:Repeater ID="rptLoggedIn30" runat="server" DataSourceID="odsLoggedIn30">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Ultimos 30 Días</span> <span style="float: right;">
                            <%# Eval("LastLoggedIn30") %>
                            usuarios(s)</span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLoggedIn30" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLoggedIn30" TypeName="wsat_DashLoggedInTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptLoggedIn60" runat="server" DataSourceID="odsLoggedIn60">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">30 - 60 Días</span> <span style="float: right;">
                            <%# Eval("LastLoggedIn60") %>
                            usuarios(s)</span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLoggedIn60" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLoggedIn60" TypeName="wsat_DashLoggedInTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptLoggedIn90" runat="server" DataSourceID="odsLoggedIn90">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">60 - 90 Días</span> <span style="float: right;">
                            <%# Eval("LastLoggedIn90") %>
                            usuarios(s)</span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLoggedIn90" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLoggedIn90" TypeName="wsat_DashLoggedInTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptLoggedInOver90" runat="server" DataSourceID="odsLoggedInOver90">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Más de 90 Días</span> <span style="float: right;">
                            <%# Eval("LastLoggedInOver90") %>
                            usuarios(s)</span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLoggedInOver90" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLoggedInOver90" TypeName="wsat_DashLoggedInTableAdapter"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td>
            <div class="dashboardCategoryTitle">
                Registros</div>
            <asp:Repeater ID="rptLast30" runat="server" DataSourceID="odsLast30">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Ultimos 30 Días</span> <span style="float: right; padding-left: 15px;">
                            <%# Eval("Last30Days") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLast30" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLast30Days" TypeName="wsat_DashRegistrationsTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptLast60" runat="server" DataSourceID="odsLast60">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">30 - 60 Días</span> <span style="float: right; padding-left: 15px;">
                            <%# Eval("Last60Days") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLast60" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLast60Days" TypeName="wsat_DashRegistrationsTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptLast90" runat="server" DataSourceID="odsLast90">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">60 - 90 Días</span> <span style="float: right; padding-left: 15px;">
                            <%# Eval("Last90Days") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsLast90" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountLast90Days" TypeName="wsat_DashRegistrationsTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptOver90" runat="server" DataSourceID="odsOver90">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Más de 90 Días</span> <span style="float: right; padding-left: 15px;">
                            <%# Eval("Over90Days") %></span><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsOver90" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountOver90Days" TypeName="wsat_DashRegistrationsTableAdapter"></asp:ObjectDataSource>
        </td>
        <td>
            <div class="dashboardCategoryTitle">
                Roles</div>
            <asp:Repeater ID="rptRoles" runat="server" DataSourceID="odsRoles">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">
                            <%# Eval("RoleName") %></span>
                        <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsRoles" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRoles" TypeName="wsat_DashRolesTableAdapter"></asp:ObjectDataSource>
            <asp:Repeater ID="rptTotalRoles" runat="server" DataSourceID="odsTotalRoles">
                <ItemTemplate>
                    <div class="dashboardCategoryItem">
                        <span style="float: left; padding-left: 15px;">Total Roles</span> <span style="float: right; padding-left: 15px;">
                            <%# Eval("RoleCount") %></span>
                        <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsTotalRoles" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountRoles" TypeName="wsat_DashRolesTableAdapter"></asp:ObjectDataSource>
        </td>
    </tr>
</table>
