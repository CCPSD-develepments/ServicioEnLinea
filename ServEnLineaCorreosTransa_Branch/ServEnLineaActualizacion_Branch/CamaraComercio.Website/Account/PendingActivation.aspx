<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="PendingActivation.aspx.cs" Inherits="CamaraComercio.Website.Account.PendingActivation" %>
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
            <h1 id="account" style="width: 670px; margin-left:auto; margin-right:auto;">Cuenta Creada</h1>
            </div>
            <div id="content_body" style="width: 670px">
                   
                    <h3>
                        Tu cuenta de usuario ha sido creada.
                    </h3>
                    <p>
                        Recibirás un correo electrónico con información que te permitirá activar tu cuenta. 
                        Favor de seguir las instrucciones.
                    </p>                   
                
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
