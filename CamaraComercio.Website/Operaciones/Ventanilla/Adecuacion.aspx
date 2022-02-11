<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="Adecuacion.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Ventanilla.Adecuacion" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Referencia para el js que controla el UX en este form -->
    <script type="text/javascript" language="javascript" src="/res/js/ui.adecuacionInicio.js"></script>
    <!--Objetos en el menu-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1>
                        Adecuación a la nueva ley de sociedades</h1>
                </div>
                <div id="content_body">
                    <div class="stepsTl" id="stepsTl">
                        <ul>
                            <li><a href="<%# ObtenerUrlPrimerPaso() %>" class="stepLast">Solicitud</a></li>
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                    <fieldset class="form-fieldset">
                        <ul>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddlCamaras" ID="lblddlCamara">
                    Cámara Comercio</asp:Label>
                                <asp:DropDownList ID="ddlCamaras" runat="server" DataSourceID="odsCamaras" DataTextField="Nombre"
                                    DataValueField="ID">
                                </asp:DropDownList>
                                <div class="comments" style="width: 93%;" id="ddlCamarasComment">
                                    Camara donde se esta registrada la empresa.
                                </div>
                            </li>
                            <asp:ObjectDataSource ID="odsCamaras" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FetchAllActivas" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.CamarasController">
                            </asp:ObjectDataSource>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="txtNoRegistroMercantil" ID="lbltxtNoRegistroMercantil">
            Registro Mercantil</asp:Label>
                                <telerik:RadNumericTextBox ID="txtNoRegistroMercantil" runat="server" CssClass="tb"
                                    Culture="English (United States)" DataType="System.Int32" MaxValue="9999999"
                                    MinValue="0" Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="txtNoRegistroMercantilReq" runat="server" ControlToValidate="txtNoRegistroMercantil"
                                    CssClass="validator" ValidationGroup="1">El No. de Registro Mercantil es obligatorio</asp:RequiredFieldValidator>
                                <div class="comments" style="width: 93%;" id="txtNoRegistroMercantilComment">
                                    Número del registro mercantil de la empresa. Este número se encuentra en el documento
                                    original en el extremo superior derecho.
                                </div>
                            </li>
                            <li>
                                <asp:Label Text="RNC" runat="server" AssociatedControlID="txtNoRnc" ID="lbltxtNoRnc" />
                                <asp:TextBox ID="txtNoRnc" runat="server" CssClass="tb" />
                                <div class="comments" id="txtNoRncComment">
                                    <p>
                                        RNC de la empresa.
                                    </p>
                                </div>
                            </li>
                            <li>
                                <div class="footer_go"> 
                                <asp:Button ID="btnValidarNoRegistro" runat="server" Text="Siguiente" OnClick="btnValidarNoRegistro_Click"
                                    ValidationGroup="1" CssClass="btn" />
                                    </div>
                            </li>
                        </ul>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
