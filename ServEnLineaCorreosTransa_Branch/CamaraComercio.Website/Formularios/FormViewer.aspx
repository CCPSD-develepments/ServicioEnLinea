<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="FormViewer.aspx.cs" Inherits="CamaraComercio.Website.Formularios.FormViewer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="con">
                Cargando...
            </div>
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="hidden"></asp:Label>
            <div class="" __designer:mapid="ba8">
                <asp:Button ID="ConfirmarDatos" runat="server" CssClass="btn btnFormNext noDisplay" OnClick="ConfirmarDatos_Click" Text="Confirmar Datos" Width="204px" />
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Volver atrás" CssClass="btn" />
                <div class="clear" __designer:mapid="bab" />
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
            position: relative center;
        }

        .hidden {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#con').load($('#MainContent_Label1').text());
        });
    </script>
</asp:Content>

