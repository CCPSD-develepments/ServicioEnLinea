<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Submenu.ascx.cs" Inherits="CamaraComercio.Website.UserControls.Submenu" %>
<div id="subnavigation">
    <div class="container_24">
        <div class="grid_24">
            <ul>
                <li id="liOficina"><a href="/Empresas/Oficina.aspx">Mis Empresas</a></li>
                <li id="liSolInclusion"><a href="/Empresas/SolicitudInclusion.aspx">Solicitar Acceso
                    a Empresa</a></li>
                <li id="liConsultas"><a href="/Consultas/Busqueda.aspx">Consultas, Certificaciones y Copias Certificadas</a></li>
                <asp:Literal runat="server" ID="litAdminGestores" />
                <li id="liCambiarPass"><a href ="../Account/ChangePassword.aspx">Cambiar Contraseña </a>  </li>
            </ul>
        </div>
    </div>
</div>
