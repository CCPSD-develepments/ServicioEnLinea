<%@ Page Title="" Language="C#" MasterPageFile="~/admin/themes/default/default.master" AutoEventWireup="true" CodeBehind="admin-actividades.aspx.cs" Inherits="CamaraComercio.Admin.admin.admin_actividades" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            color: #333;
        }
        
        .RadGrid_Default
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            color: #333;
        }
        
        .RadGrid_Default
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Default .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Default .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid_Default .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        
        .RadGrid_Default .rgMasterTable
        {
            border-collapse: separate;
        }
        
        .RadGrid_Default .rgHeader
        {
            cursor: default;
        }
        
        .RadGrid_Default .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            padding-top: 5px;
            padding-bottom: 4px;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid_Default .rgHeader
        {
            color: #333;
            text-decoration: none;
        }
        
        .RadGrid_Default .rgHeader
        {
            cursor: default;
        }
        
        .RadGrid_Default .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            padding-top: 5px;
            padding-bottom: 4px;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
            text-align: left;
            font-weight: normal;
        }
        
        .RadGrid_Default .rgHeader
        {
            color: #333;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminHelp">
        En esta sección puede visualizar las últimas actividades de los usuarios a través
        del portal.
    </div>
    <div class="gvBanner">
        <span class="gvBannerThemes">
            <asp:Image ID="Image2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/decoy-icon-36px.png" /></span>
        Últimas Actividades en el Portal</div>
    <telerik:RadGrid runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        DataSourceID="odsActividades" GridLines="None" ID="gvActivities" 
        OnItemDataBound="gvActivities_ItemDataBound" Width="900px" PageSize="25" 
        AllowFilteringByColumn="True">
        <MasterTableView DataSourceID="odsActividades">
            <Columns>
                <telerik:GridBoundColumn DataField="ActivityLogID" HeaderText="ActivityLogID" SortExpression="ActivityLogID"
                    Visible="False" UniqueName="ActivityLogID" DataType="System.Guid">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserId" HeaderText="UserId" SortExpression="UserId"
                    Visible="False" UniqueName="UserId" DataType="System.Guid">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ActivityDate" HeaderText="Fecha" SortExpression="ActivityDate"
                    UniqueName="Fecha" DataType="System.DateTime">
                    <HeaderStyle Width="120px"></HeaderStyle>
                    <ItemStyle Width="120px"></ItemStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserName" HeaderText="Nombre Usuario" 
                    UniqueName="UsrName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Activity" HeaderText="Actividad" SortExpression="Activity"
                    UniqueName="Actividad">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn DataField="PageUrl" HeaderText="URL" UniqueName="PURL">
                    <ItemTemplate>
                        <asp:Label Text='<%#  Convert.ToString(Eval("PageUrl")).Length > 30 ? Eval("PageUrl").ToString().Substring(0, 30) + "..." : Eval("PageUrl") %>'
                            ID="lblPUrl" runat="server" ToolTip='<%# Eval("PageUrl") %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="250px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="IpAddress" HeaderText="Direcci&#243;n IP" SortExpression="IpAddress"
                    UniqueName="DireccionIP">
                    <HeaderStyle Width="100px"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PageUrl" HeaderText="URL" SortExpression="PageUrl"
                    Visible="False" UniqueName="URL">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
        <PagerStyle FirstPageToolTip="Primera" NextPageToolTip="Siguiente" LastPageToolTip="Ultima"
            PrevPageToolTip="Previa" NextPagesToolTip="Siguiente" PrevPagesToolTip="Previa"
            ShowPagerText="False"></PagerStyle>
    </telerik:RadGrid>
    <br />
    <asp:ObjectDataSource ID="odsActividades" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAllActivityDt" 
        TypeName="CamaraComercio.DataAccess.EF.Membership.UsuariosController">
    </asp:ObjectDataSource>
</asp:Content>
