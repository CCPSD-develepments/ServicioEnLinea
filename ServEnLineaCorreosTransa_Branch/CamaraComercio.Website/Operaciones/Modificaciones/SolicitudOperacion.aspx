<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="SolicitudOperacion.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Modificaciones.SolicitudOperacion" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //Objetos en el menu
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");

            //Eventos Client-Side
            $(document).ready(function () {
                //Validacion de que el dropdown de transformación trae datos
                if ($("#ddlTransformacion option").length == 0) {
                    $("#chkTransformacion").attr("disabled", "disabled");
                    $("#ddlTransformacion").attr("disabled", "disabled");
                }

                //Manejo del checkbox de Renovacion
                $("#chkRenovacion").click(function () {
                    if ($("#hfRenovacionObligatoria").val() == "1") {
                        $(this).attr('checked', 'checked');
                    }
                });

                var cantRenovacionesStr = $("#hfCantidadRenovaciones").val();
                var cantRenovaciones = parseInt(cantRenovacionesStr);
                $("#spnCantidadRenovaciones").hide().css('visibility', 'visible')
                if (cantRenovaciones > 1) {
                    $("#spnCantidadRenovaciones").fadeIn();
                }

                //Manejo de checkboxes de transformación
                var hfTransfComp = $("#hfTransfCompIds");
                if (hfTransfComp.val().length > 0) {
                    var transfComp = $.parseJSON(hfTransfComp.val());
                    for (var i = 0; i < transfComp.length; i++) {
                        var tr = $(".servicioId input[value=" + transfComp[i] + "]").closest("tr");
                        var chkComp = tr.find("input[type=checkbox]");
                        var mensaje = tr.find(".mensajeComplementario");
                        mensaje.hide().css('visibility', 'visible');

                        chkComp.attr('checked', 'checked');
                        chkComp.data("complementario", 1);
                        mensaje.fadeIn();
                    }
                }
                else {
                    var tr = $(".servicioId input").closest("tr");
                    var chkComp = tr.find("input[type=checkbox]");
                    var mensaje = tr.find(".mensajeComplementario");
                    mensaje.hide().css('visibility', 'visible');

                    chkComp.removeAttr('checked');
                    chkComp.data("complementario", null);
                    mensaje.fadeOut();
                }

                //Manejo de Checkboxes de modificacion
                var chkTransfItems = $(".servicioModificacion input[type=checkbox]");
                if ($("#hfSeleccionUnitaria").val() == "1") {
                    chkTransfItems.click(function () {
                        //Se deseleccionan todos los checkboxes
                        chkTransfItems.removeAttr('checked');
                        //Solo se selecciona el actual
                        $(this).attr('checked', 'checked');
                    });
                }
                else {
                    chkTransfItems.click(function () {
                        if ($(this).data("complementario") == 1) {
                            $(this).attr("checked", "checked");
                            return false;
                        }

                        //Se revisa si el checkbox actual posee un valor complementario
                        var hf = $(this).closest("tr").find(".servicioComplementario input")
                        if (hf != undefined && hf.val().length > 0) {

                            var tr = $(".servicioId input[value=" + hf.val() + "]").closest("tr");
                            var chkComp = tr.find("input[type=checkbox]");
                            var mensaje = tr.find(".mensajeComplementario");
                            mensaje.hide().css('visibility', 'visible');

                            if ($(this).attr('checked')) {
                                chkComp.attr('checked', 'checked');
                                chkComp.data("complementario", 1);
                                mensaje.fadeIn();
                            }
                            else {
                                chkComp.removeAttr('checked');
                                chkComp.data("complementario", null);
                                mensaje.fadeOut();
                            }
                        }
                    });
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="smManager" runat="server">
    </asp:ScriptManager>
    <!-- Hidden Fields -->
    <asp:HiddenField ID="hfTipoSociedadId" runat="server" />
    <asp:HiddenField ID="hfTipoServicioId" runat="server" />
    <asp:HiddenField ID="hfSinCapital" runat="server" />
    <asp:HiddenField ID="hfTransformacionId" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hfSeleccionUnitaria" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hfTransfCompIds" runat="server" ClientIDMode="Static" />
    <asp:ObjectDataSource ID="odsServiciosmodificacion" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetServicios" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfTipoServicioId" Name="tipoServicioId" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="hfSinCapital" Name="sinCapital" PropertyName="Value"
                Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsServiciosTransformacion" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetServicios" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfTransformacionId" Name="tipoServicioId" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" PropertyName="Value"
                Type="Int32" />
            <asp:ControlParameter ControlID="hfSinCapital" Name="sinCapital" PropertyName="Value"
                Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="empresa">
                    <span class="right normal">
                        <asp:Literal ID="ltNombreSocial" runat="server"></asp:Literal>,
                        <asp:Literal ID="ltTipoSociedad" runat="server"></asp:Literal>
                    </span>Solicitud de Operaciones
                </h1>
            </div>
            <div id="content_body">
                <fieldset class="form-fieldset">
                    <h2>
                        Tipos de Operaciones
                    </h2>
                    <h5>
                        Selecciona los tipos de modificaciones que quieres realizar, completa la información
                        de los datos solicitados y luego presiona el botón de "Someter". Si tienes alguna duda con un término, visita
                        nuestro <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                            Glosario de Términos</a>. <strong>Todos los campos de la solicitud son obligatorios.</strong></h5>
                    <!--<h3>
                        Operaciones a Realizar</h3>-->
                    <asp:Panel ID="pnlRenovacion" runat="server" Visible="false">
                        <h3>
                            Renovación de Registro</h3>
                        <span>
                            <asp:CheckBox ID="chkRenovacion" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfRenovacionObligatoria" />
                            <asp:HiddenField runat="server" ClientIdMode="Static" ID="hfCantidadRenovaciones" />
                            <span style="padding-left: 30px">Renovación Registro Mercantil con Modificación</span>
                            <span id="spnCantidadRenovaciones" style="color:Red; visibility:hidden">
                                (se cobrarán <asp:Label runat="server" ID="lblCantRenovaciones" /> renovaciones en total)
                            </span>
                        </span>
                    </asp:Panel>
                    <asp:Panel ID="pnlTransformacion" runat="server" Visible="false">
                        <h3>
                            Transformaciones</h3>
                        <span>
                            <asp:CheckBox ID="chkTransformacion" runat="server" ClientIDMode="Static" 
                            AutoPostBack="True" oncheckedchanged="ddlTransformacion_SelectedIndexChanged" />
                            <span style="padding-left: 30px; padding-right: 5px">Transformación a </span><span
                                style="padding-top: 5px;">
                                <asp:DropDownList runat="server" ID="ddlTransformacion" 
                            ClientIDMode="Static" DataSourceID="odsServiciosTransformacion"
                                    DataTextField="Descripcion" DataValueField="ServicioId" 
                            Width="450px" AutoPostBack="True" 
                            onselectedindexchanged="ddlTransformacion_SelectedIndexChanged" />
                            </span></span>
                    </asp:Panel>
                    <h3>
                        Modificaciones</h3>
                    <telerik:RadGrid ID="gridModificaciones" runat="server" AutoGenerateColumns="False"
                        ShowHeader="False" GridLines="None" EnableEmbeddedSkins="False" Skin="Ccpsd"
                        DataSourceID="odsServiciosmodificacion" 
                        onitemdatabound="gridModificaciones_ItemDataBound">
                        <FilterMenu EnableEmbeddedSkins="False">
                        </FilterMenu>
                        <HeaderContextMenu EnableEmbeddedSkins="False">
                        </HeaderContextMenu>
                        <MasterTableView DataKeyNames="ServicioId,UrlModificacion" DataSourceID="odsServiciosmodificacion">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="A Solicitar">
                                    <ItemTemplate>
                                        <asp:CheckBox Text="&nbsp;" ID="chkServicio" runat="server" CssClass="servicioModificacion"
                                            Checked="false"/>

                                        <span class="servicioComplementario">
                                            <asp:HiddenField runat="server" ClientIDMode="Predictable" ID="hfServicioComplementarioId" />
                                        </span>

                                        <span class="servicioId">
                                            <asp:HiddenField runat="server" ClientIDMode="Predictable" ID="hfServicioId" Value='<%# Eval("ServicioId") %>' />
                                        </span>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="Descripcion" HeaderText="Servicio" UniqueName="Descripcion">
                                    <ItemTemplate >
                                        <asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                        <span class="mensajeComplementario" style="color:Red; visibility:hidden">
                                            &nbsp;(servicio seleccionado de forma automática como requisito)
                                        </span>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="GrupoServicio" HeaderText="GrupoServicio"
                                    UniqueName="column" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="GrupoServicioLabel" runat="server" Text='<%# Eval("GrupoServicio") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </fieldset>
                <div class="footer_go">
                    <asp:Button ID="btnContinuar" runat="server" Text="Someter" CssClass="btn" OnClick="btnContinuar_Click" />
                    <div class="clear" />
                </div>
            </div>
            <asp:Panel runat="server" ID="pnlErrorBox" ClientIDMode="Static" Visible="False"
                Style="margin-top: 20px;">
                <div id="errorbox">
                    <p>
                        <asp:Literal runat="server" ID="ltError">
                        </asp:Literal>
                    </p>
                </div>
            </asp:Panel>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
