<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" 
    CodeBehind="ReaperturarCaso.aspx.cs" Inherits="CamaraComercio.Website.Mantenimiento.ReaperturarCaso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div id="content_header">
            <br />
            <br />
            <asp:Label ID="lblnSolicitud" runat="server" Text="TransaccionIdSRM"></asp:Label>
            <asp:TextBox ID="txtProceder" runat="server" ToolTip="nSolicitud"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnProceder" runat="server" Text="Proceder" CssClass="" OnClick="btnProceder_Click" />
            <br />
            <br />
            <br />
            <hr />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enviar solo al SRM : Transaccion ID :"></asp:Label>
&nbsp;
            <asp:TextBox ID="txttransaccionsrm" runat="server" Height="32px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Generar NCF ? "></asp:Label>
            <asp:CheckBox ID="Checkboxncf" runat="server" />
            <br />
            <br />
            <br />
            <asp:Button ID="BtnEnviarSrmtransaccion" runat="server" Height="38px" OnClick="BtnEnviarSrmtransaccion_Click" Text="Enviar SRM" Width="104px" />
            <br />
            <br />

            <br />
       

            <br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
