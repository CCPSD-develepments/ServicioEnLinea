<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="RedireccionPago.aspx.cs" Inherits="CamaraComercio.Website.TarjetaCredito.RedireccionPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Revisión de Transacción</h2>
    <p>
        <asp:Literal runat="server" ID="litEstatusTrans"></asp:Literal>
    </p>
</asp:Content>
