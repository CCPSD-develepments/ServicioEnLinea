<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="Renovacion.aspx.cs" Inherits="CamaraComercio.Website.Empresas.Renovacion" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Adecuación Requerida</title>
    <!-- Inline user script -->
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            //Objetos en el menu
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");

            //Manejo de eventos client-side
            $("#hlRenovacionSimple").click(function (e) {
                e.preventDefault();

                $("#dialog:ui-dialog").dialog("destroy");
                $("#dialog-confirm").attr("title", "Confirmación para realizar Renovación");
                $("#dialog-content").text("La Renovación simple permite renovar su registro mercantil sin realizar ningún cambio a los datos de su registro.");

                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: 350,
                    width: 460,
                    modal: true,
                    buttons: {
                        "Realizar Renovación": function () {
                            $(this).dialog("close");

                             <%= this.Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this.hlRenovacionSimple))%>
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    });
            });

        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header" style="display:table; width:100%;">
                <%--<h1 id="renovacion">
                    <span class="right normal">
                        <asp:Literal runat="server" ID="litNombreEmpresaTit" />
                    </span>Renovación Obligatoria
                </h1>--%>
                <div id="renovacion" style="display:table-cell; min-width:375px; vertical-align:middle">
                    <h1 >
                        Renovación Obligatoria
                    </h1>
                </div>
                <div class="right normal" style="display:table-cell; padding-left:30px; color:#00587C; text-align:right; vertical-align:middle">
                    <asp:Label ID="litNombreEmpresaTitM" CssClass="right normal"  runat="server" style="font-size: 2.3em; text-align:right; width:100%;"></asp:Label>
                </div>
            </div>
            <div id="content_body">
                <asp:MultiView runat="server" ID="mvRenovacion" ActiveViewIndex="1">
                    <asp:View runat="server" ID="vTransExistente">
                        <h3>Su sociedad/empresa ya posee una solicitud para renovación.
                        </h3>
                        <p>
                            Su sociedad/empresa debe ser renovada para poder solicitar cualquier servicio. Actualmente
                            ya existe una solicitud de renovación en nuestro sistema.
                        </p>
                        <p>
                            &nbsp;
                        </p>
                        <p>
                            Para visualizar el estado de su solicitud acceda el
                            <asp:HyperLink runat="server" ID="lnkVerDetalle">Status de la Solicitud</asp:HyperLink>
                        </p>
                    </asp:View>
                    <asp:View runat="server" ID="vRenovacion">
                        <div class="sectDetailBlue">
                            <h1>
                                <asp:Label ID="labelregistrovencido"   runat="server"></asp:Label>
                            </h1>
                            <p>
                                El registro mercantil debe ser renovado para poder realizar cualquier operación,
                                exceptuando la solicitud de certificaciones y copias certificadas.
                                Selecciona una de las siguientes alternativas:
                            </p>
                        </div>
                        <div id="divFormasEntregaWrapper" style="text-align: center">
                            <div class="infoBox">
                                <div class="infoContent">
                                    <asp:LinkButton ID="hlRenovacionSimple" runat="server" Text="Renovación Simple" CssClass="btn"
                                        Style="float: none;" ClientIDMode="Static" OnClick="hlRenovacion_Click"></asp:LinkButton>
                                    <p>
                                        Selecciona esta opción si deseas renovar la empresa sin cambiar la información 
                                        existente en el Registro Mercantil.
                                    </p>
                                </div>
                            </div>
                            <div class="infoBox" style="display: none">
                                <div class="infoContent">
                                    <asp:LinkButton ID="lbRenovacionMod" runat="server" Text="Renovación con Modificación"
                                        CssClass="btn" Style="float: none;" ClientIDMode="Static" OnClick="lbRenovacionMod_Click" />
                                    <p>
                                        Selecciona esta opción si deseas renovar la empresa y modificar la información
                                        del Registro Mercantil.
                                    </p>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnlRenovacionTransf" CssClass="infoBox" Visible="false">
                                <div class="infoContent">
                                    <asp:LinkButton ID="lnkRenovacionTrans" runat="server" Text="Renovación con Transformación"
                                        CssClass="btn" Style="float: none;" ClientIDMode="Static" OnClick="lnkRenovacionTrans_Click" />
                                    <p>
                                        Selecciona esta opción si deseas renovar el Registro Mercantil y al mismo tiempo 
                                        transformar la empresa a un nuevo tipo de sociedad.
                                    </p>
                                </div>
                            </asp:Panel>
                            <div class="infoBox" style="display: none">
                                <div class="infoContent">
                                    <asp:LinkButton ID="lnkRenovacionCierre" runat="server" Text="Renovación y Cierre Registral"
                                        CssClass="btn" Style="float: none;" ClientIDMode="Static" OnClick="lnkRenovacionCierre_Click" />
                                    <p>
                                        Selecciona esta opción si deseas realizar un cierre registral. Para ello, la empresa debe estar
                                        al día para poder realizar la solicitud.
                                    </p>
                                </div>
                            </div>
                            <div class="infoBox">
                                <div class="infoContent">
                                    <asp:LinkButton ID="lnkCopiasCertificadas" runat="server" Text="Copias Certificadas"
                                        CssClass="btn" Style="float: none;" ClientIDMode="Static"
                                        OnClick="lnkCopiasCertificadas_Click" />
                                    <p>
                                        Selecciona esta opción si deseas solicitar copias certificadas.
                                    </p>
                                </div>
                            </div>

                            <div class="infoBox">
                                <div class="infoContent">
                                    <asp:LinkButton ID="lnkSolicitudCertificacion" runat="server" Text="Solicitud de Certificaciones"
                                        CssClass="btn" ClientIDMode="Static"
                                        Style="float: none; background-color: #BD4932"
                                        OnClick="lnkSolicitudCertificacion_Click" />
                                    <p>
                                        Selecciona esta opción si deseas solicitar una certificación de la empresa.
                                    </p>
                                </div>
                                <div class="clear" />
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="vNoExiste" runat="server">
                        <!--                        <h2><a href="/Empresas/Oficina.aspx">Retornar a la página de inicio</a></h2>-->
                    </asp:View>
                    <asp:View runat="server" ID="failView">
                        <div class="sectDetailBlue">
                            <h2 id="txtMessageTitle" runat="server"></h2>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
