<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="PagoTransaccion.aspx.cs" Inherits="CamaraComercio.Website.TarjetaCredito.PagoTransaccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .loader {
                  border: 16px solid #f3f3f3;
                  border-radius: 50%;
                  border-top: 16px solid #3498db;
                  width: 120px;
                  height: 120px;
                  -webkit-animation: spin 2s linear infinite; /* Safari */
                  animation: spin 2s linear infinite;
                }
                
                /* Safari */
                @-webkit-keyframes spin {
                  0% { -webkit-transform: rotate(0deg); }
                  100% { -webkit-transform: rotate(360deg); }
                }
                
                @keyframes spin {
                  0% { transform: rotate(0deg); }
                  100% { transform: rotate(360deg); }
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div id="content_header">
                <h1 id="transac">
                    <span class="right normal">
                        
                    </span>Estamos procesando su transacción, por favor espere!
                </h1>
            
                <center>
                    <div class="loader"></div>
                    <asp:Button ID="btnContinuar" runat="server" Height="0px" Width="0px" 
                        style="opacity:0; filter: alpha(opacity=0);" CssClass="" 
                        OnClick="btnContinuar_Click" Text=""  ClientIDMode="Static" Enabled="true"/>
                </center>
            <div class="clear" />
            </div>
    </div>
    <asp:ScriptManager ID="sm1" runat="server" 
            EnablePageMethods="True">
    </asp:ScriptManager>


    <script language="javascript" type="text/javascript">

        window.onload = function () {
            document.onkeydown = function (e) {
                alert("F5 Reload");
                return (e.which || e.keyCode) != 116;
            };
        }

        $(document).ready(function () {
            document.getElementById("btnContinuar").click();
        });
    </script>
</asp:Content>