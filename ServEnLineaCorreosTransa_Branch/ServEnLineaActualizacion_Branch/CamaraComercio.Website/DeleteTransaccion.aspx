<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="DeleteTransaccion.aspx.cs" Inherits="CamaraComercio.Website.DeleteTransaccion" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <div>
                    <h1 id="detalles">
                        <span class="right normal"></span>CANCELAR SOLICITUD
                    </h1>
                </div>
            </div>
            <div id="content_body">
                <h3>¿Seguro desea cancelar la transaccion?</h3>
                <div id="divFormasEntregaWrapper" style="text-align: center">
                    <div class="infoBox">
                        <div class="infoContent">
                            <asp:Button runat="server" ID="btnBack" CssClass="btn" Text="No"
                                OnClick="btnBack_Click"></asp:Button>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn" Text="Si"
                                OnClick="btnDelete_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="clear" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
