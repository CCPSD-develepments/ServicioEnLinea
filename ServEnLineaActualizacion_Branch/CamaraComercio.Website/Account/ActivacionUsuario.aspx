<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="ActivacionUsuario.aspx.cs" Inherits="CamaraComercio.Website.Account.ActivacionUsuario" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var validateSession = false;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
               <h1 id="account" style="width: 670px; margin-left:auto; margin-right:auto;">
                    Confirmación de Nuevo Usuario.</h1>
            </div>
            <div id="content_body" style="width: 670px">
                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <label for="lblUsuario">
                                Usuario
                            </label>
                            <asp:Label ID="lblUsuario" runat="server" ClientIDMode="Static"></asp:Label>
                        </li>
                        <li>
                            <label for="lblEstadoActivacion">
                                Estado de la activacion
                            </label>
                            <asp:Label ID="lblEstadoActivacion" runat="server"></asp:Label>
                        </li>
                        <li>
                            <label for="lblFechaCreacion">
                                Fecha de creacion</label>
                            <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                        </li>
                        <li>
                            <label>
                            </label>
                            <span>Para regresar al inicio hacer click en <strong>
                                <asp:HyperLink ID="linkLogin" runat="server" 
                                NavigateUrl="/Account/Login.aspx">
                             "Conéctate"</asp:HyperLink>
                            </strong></span></li>
                    </ul>
                    <p>
                    </p>
                    <div class="clear" />
                </fieldset>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
