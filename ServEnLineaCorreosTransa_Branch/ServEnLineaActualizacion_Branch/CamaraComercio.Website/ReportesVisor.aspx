<%@ Page Title="Cámaras de Comercio y Producción" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="ReportesVisor.aspx.cs" Inherits="CamaraComercio.Website.ReportesVisor" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Client Scripts -->    
    <script type="text/javascript">
        window.focus();
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_body">
                    <%--<div id="dialog" style="width: 200px; height: 200px; background-color: gray;display:none">
                        <iframe id="pdfIFrame" runat="server" scrolling="auto" style="width:100%; height:100%"/>            
                    </div>--%>
                    <asp:ValidationSummary runat="server" ID="errorbox" 
                                    HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores.&lt;/p&gt;"
                                    CssClass="summary errorbox" Display="static" />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
