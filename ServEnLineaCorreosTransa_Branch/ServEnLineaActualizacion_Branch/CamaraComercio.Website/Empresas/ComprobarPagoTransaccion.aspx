<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="ComprobarPagoTransaccion.aspx.cs" Inherits="CamaraComercio.Website.ComprobarPagoTransaccion" %>

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
                        <span class="right normal"></span>CONSULTAR ESTADO PAGO EMPRESARIAL
                    </h1>
                </div>
            </div>
            <div id="content_body">
                <h3>Comprobar estado del pago de la transacción.</h3>
                <div id="divFormasEntregaWrapper" style="text-align: center">
                    <div class="infoBox">
                        <div class="infoContent">
                            <asp:Button runat="server" ID="btnBack" CssClass="btn" Text="Cancelar"
                                OnClick="btnBack_Click"></asp:Button>
                            <asp:Button runat="server" ID="btnComprobar" CssClass="btn" Text="Comprobar"
                                OnClick="btnComprobar_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="clear" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
