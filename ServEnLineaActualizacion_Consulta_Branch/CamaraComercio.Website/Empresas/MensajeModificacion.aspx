<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="MensajeModificacion.aspx.cs" Inherits="CamaraComercio.Website.Empresas.MensajeModificacion" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link href="/res/css/Oficina.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
<uc1:submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="container_24">
<div class="grid_24">
<div id="content_body">
 <h4 style="color: #FF0000">Esta compañia ya esta siendo modificada, ¿desea continuar?</h4>
                        <div class="infoBox">
                            <div class="infoContent">
                                <asp:RadioButton runat="server" ID="rblDeseaContinuar" 
                                    Text="Si,Deseo continuar" GroupName="Entrega" Checked="True" />
                                <p>
                                    Selecciona esta opción si deseas continuar con la modificacion de la compañia.
                                    </p>
                            </div>
                        </div>
                        <div class="infoBox">
                            <div class="infoContent">
                                <asp:RadioButton runat="server" ID="rblNoDeseaContinuar" 
                                    Text="No, No deseo continuar." GroupName="Entrega" />
                                <p>
                                    Selecciona esta opción si no desea continuar con la modificacion de la compañia.
                                    </p>
                            </div>
                        </div>

                        <div class="footer_go">
                            <asp:Button ID="btnSeleccionar" runat="server" CssClass="btn" 
                                Text="Siguiente" onclick="btnSeleccionar_Click" />
                            <div class="clear" />
                        </div>
                        </div>
                        </div>
                        </div>
</asp:Content>
