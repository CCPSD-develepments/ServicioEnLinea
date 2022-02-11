<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="Modificacion.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.Modificacion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //Objetos en el menu
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="odsModificaciones" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetServicios" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.ServicioDetallesRepository">
        <SelectParameters>
            <asp:SessionParameter Name="lstServicios" SessionField="ServicioSeleccionados" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
            </div>
            <div id="content_body">
                <fieldset>
                    <legend>Modificaciones</legend>
                </fieldset>
                <asp:Panel ID="plModificacion" runat="server">
                </asp:Panel>
                <br />
                <asp:Button ID="btnEnviarModificacion" runat="server" Text="Someter" OnClick="btnEnviarModificacion_Click"
                    ValidationGroup="3" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
