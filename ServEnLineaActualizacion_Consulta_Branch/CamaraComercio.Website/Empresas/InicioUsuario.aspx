<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="InicioUsuario.aspx.cs" Inherits="CamaraComercio.Website.Empresas.InicioUsuario" %>
    <%@ Register src="~/UserControls/Submenu.ascx" tagname="Submenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Nuevo Usuario </title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");

            $('#subnavigation li').removeClass("active");
            $('#liOficina').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
     <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="creacion"><span class="right normal">
                    Hola, <asp:Label runat="server" ID="lblNombreUsuario" />
                </span>
                    Registro Mercantil
                    
                </h1>
            </div>
            <div id="content_body">
            <h2></h2>
                <p>
                    Bienvenido al portal de Productos y Servicios de la Cámara de Santo Domingo.
                    Para poder utilizar los servicios en línea, debes de registrar por lo menos una empresa
                    bajo tu cuenta.
                </p>
                <h3>
                    Seleccione una opción:
                </h3>
                <div id="boxWrapper" style="text-align: center;">
                    <%-- DESCOMENTAR ESTA SECCIÓN PARA IMPLEMENTAR LA OPCION DE NUEVO REGISTRO DE EMPRESA --%>
                    <%--<div class="infoBox">
                        <div class="infoContent">
                            <a href="/Operaciones/Registro/NuevoRegistro.aspx" runat="server" style="margin-left:auto; margin-right:auto; float:none;" class="btn">Crear una empresa nueva</a>
                            <br />
                            <p>
                                Selecciona esta opción si deseas crear/registrar una nueva empresa en la Cámara
                                de Santo Domingo. No te preocupes, te explicamos todo el proceso de registro mediante
                                instructivos fáciles de seguir.
                            </p>
                        </div>
                    </div>--%>
                    <div class="infoBox" style="margin-left:auto; margin-right:auto; float:none">
                        <div class="infoContent">
                            <a href="/Empresas/SolicitudInclusion.aspx"  style="margin-left:auto; margin-right:auto; float:none;" class="btn">Solicitar Acceso a Empresa</a>
                            <p>
                                Si ya posees una empresa con registro mercantil y lo que deseas es poder solicitar
                                servicios en línea, selecciona esta opción para registrar tu usuario con tu empresa.
                                Debes tener a mano el número de registro mercantil de la empresa.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="clear" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
