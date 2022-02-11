<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="Certificaciones.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Shared.Certificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .divHover {
            background-color: #FFC;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".infoContent").click(function () {
                $(".infoContent input").attr("checked", false);
                if (!$(this).find("input").attr("disabled"))
                    $(this).find("input").attr("checked", true);
            });

            $("#txtDescripcion").attr('maxlength', '250');

            $(".infoContent").hover(
                function () { $(this).addClass("divHover") },
                function () { $(this).removeClass("divHover") });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header" style="display:table; width:100%;">
                <%--<h1 id="transac">
                    <span class="right normal">
                        <asp:Label runat="server" ID="lblNombreEmpresa" />
                        /
                        <asp:Label runat="server" ID="lblTipoEmpresa" />
                    </span>Solicitud de Certificaciones</h1>--%>
                <div id="transac" style="display:table-cell; min-width:375px; vertical-align:middle">
                    <h1 >
                        Solicitud de Certificaciones
                    </h1>
                </div>

                <div class="right normal" style="display:table-cell; padding-left:30px; color:#00587C; text-align:right; vertical-align:middle">
                    <asp:Label ID="lblNombreEmpresaM" CssClass="right normal"  runat="server" style="font-size: 2.3em; text-align:right; width:100%;"></asp:Label>
                </div>
            </div>
            <div id="content_body">
                <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="1">
                    <asp:View ID="vSeleccion" runat="server">
                        <h4>Selecciona como deseas recibir tu certificación</h4>
                        <div class="infoBox">
                            <div class="infoContent">
                                <asp:RadioButton runat="server" ID="rblCertificacionFisica"
                                    Text="Entrega Física" GroupName="Entrega" Checked="True" />
                                <p>
                                    Selecciona esta opción si deseas recoger el certificado en las oficinas de la Cámara
                                    de Comercio
                                </p>
                            </div>
                        </div>
                        <%--                        <div class="infoBox">
                            <div class="infoContent">
                                <asp:RadioButton runat="server" ID="rblCertificacionFirma" 
                                    Text="Descarga Digital" GroupName="Entrega" />
                                <p>
                                    Selecciona esta opción para descargar el certificado firmado de forma digital
                                    <asp:Label runat="server" ID="lblNoAplica" Visible="false" ForeColor="Gray">
                                    (No aplica para el tipo de certificación seleccionada)</asp:Label>
                                </p>
                            </div>
                        </div>--%>

                        <div class="footer_go">
                            <asp:Button ID="btnSeleccionar" runat="server" CssClass="btn"
                                Text="Siguiente" OnClick="btnSeleccionar_Click" />
                            <div class="clear" />
                        </div>
                    </asp:View>
                    <asp:View ID="v1" runat="server">
                        <asp:ObjectDataSource ID="odsModelos" runat="server" SelectMethod="GetModelosCertificacion"
                            TypeName="CamaraComercio.DataAccess.EF.SRM.ModelosCertifacionesRepository">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:QueryStringParameter QueryStringField="TipoSociedadId" Name="tipoSociedadId"
                                    Type="Int32" />
                                <asp:Parameter Name="esEmpresa" DefaultValue="True" Type="Boolean" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsCertificacionesAvanzadas" runat="server" SelectMethod="GetServiciosCertificacionAvanzados"
                            TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:Parameter Name="tipoServicioId" Type="Int32" />
                                <asp:QueryStringParameter QueryStringField="TipoSociedadId" Name="tipoSociedadId"
                                    Type="Int32" />
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:Parameter DefaultValue="True" Name="esEmpresa" Type="Boolean" />
                                <asp:Parameter Name="servicioFlowIdNoRequiereAnalisis" Type="Int32" DefaultValue="" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:Panel ID="panelTransAnterior" runat="server" Visible="False">

                            <h2>Certificacion Anterior
                            </h2>
                            <telerik:RadGrid ID="rgridCertificacionesAnteriores" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" OnItemCommand="rgridEmpresas_ItemCommand"
                                Skin="NoboxGrid" EnableEmbeddedSkins="false">
                                <MasterTableView>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                            UniqueName="Descripcion">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CostoServicio" HeaderText="Monto" UniqueName="CostoServicio"
                                            DataFormatString="{0:N}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%# "0|" + Eval("ServicioId")%>'
                                                    Text="Continuar"></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </asp:Panel>
                        <h2>Certificaciones Generales
                        </h2>
                        <h5>Las Certificaciones Especiales requieren de la gestión de un analista con los datos
                            solicitados por el cliente.</h5>
                        <telerik:RadGrid ID="rgridCertificacionAvanzadas" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None" DataSourceID="odsCertificacionesAvanzadas"
                            EnableEmbeddedSkins="False" Skin="NoboxGrid" OnItemCommand="rgridEmpresas_ItemCommand" OnItemDataBound="rgridCertificacionAvanzadas_ItemDataBound">
                            <MasterTableView DataSourceID="odsCertificacionesAvanzadas">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                        UniqueName="Descripcion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CostoServicio" HeaderText="Monto" UniqueName="Monto"
                                        DataFormatString="{0:N}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%# "0|" + Eval("ServicioId")%>'
                                                Text="Solicitar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br />
                    </asp:View>
                    <asp:View ID="vCertSimple" runat="server">
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetModelosCertificacion"
                            TypeName="CamaraComercio.DataAccess.EF.SRM.ModelosCertifacionesRepository">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:Parameter Name="esPersona" DefaultValue="True" Type="Boolean" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetServiciosCertificacionAvanzados"
                            TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="TipoServicioId" Name="tipoServicioId"
                                    Type="Int32" />
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:Parameter Name="esPersona" DefaultValue="True" Type="Boolean" />
                                <asp:Parameter Name="servicioFlowIdNoRequiereAnalisis" Type="Int32" DefaultValue="" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <h2>Certificaciones Generales
                        </h2>
                        <h5>Las Certificaciones Generales se emiten como resultado de la búsqueda automática
                            en el sistema. No requiere la gestión de un analista.</h5>
                        <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None" OnItemCommand="rgridEmpresas_ItemCommand"
                            DataSourceID="odsModelosPersonas" Skin="NoboxGrid" EnableEmbeddedSkins="false">
                            <MasterTableView DataSourceID="odsModelosPersonas">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                        UniqueName="Descripcion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Monto" HeaderText="Monto" UniqueName="Monto"
                                        DataFormatString="{0:N}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ModeloId") + "|" + Eval("ServicioId")%>'
                                                Text="Solicitar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:View>

                    <asp:View ID="vPersona" runat="server">
                        <asp:ObjectDataSource ID="odsModelosPersonas" runat="server" SelectMethod="GetModelosCertificacion"
                            TypeName="CamaraComercio.DataAccess.EF.SRM.ModelosCertifacionesRepository">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:Parameter Name="esPersona" DefaultValue="True" Type="Boolean" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsCertificacionPersonaAvanzadas" runat="server" SelectMethod="GetServiciosCertificacionAvanzados"
                            TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="TipoServicioId" Name="tipoServicioId"
                                    Type="Int32" />
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:Parameter Name="esPersona" DefaultValue="True" Type="Boolean" />
                                <asp:Parameter Name="servicioFlowIdNoRequiereAnalisis" Type="Int32" DefaultValue="" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <h2>Certificaciones Generales
                        </h2>
                        <h5>Las Certificaciones Generales se emiten como resultado de la búsqueda automática
                            en el sistema. No requiere la gestión de un analista.</h5>
                        <telerik:RadGrid ID="rgridCertificacionesPersona" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None" OnItemCommand="rgridEmpresas_ItemCommand"
                            DataSourceID="odsModelosPersonas" Skin="NoboxGrid" EnableEmbeddedSkins="false">
                            <MasterTableView DataSourceID="odsModelosPersonas">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                        UniqueName="Descripcion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Monto" HeaderText="Monto" UniqueName="Monto"
                                        DataFormatString="{0:N}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ModeloId") + "|" + Eval("ServicioId")%>'
                                                Text="Solicitar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <h2>Certificaciones Especiales
                        </h2>
                        <h5>Las Certificaciones Especiales requieren de la gestión de un analista con los datos
                            solicitados por el cliente.</h5>
                        <telerik:RadGrid ID="rgridCertificacionAvanzadasPersonas" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None" DataSourceID="odsCertificacionPersonaAvanzadas"
                            EnableEmbeddedSkins="False" Skin="NoboxGrid" OnItemCommand="rgridEmpresas_ItemCommand">
                            <MasterTableView DataSourceID="odsCertificacionPersonaAvanzadas">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                        UniqueName="Descripcion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CostoServicio" HeaderText="Monto" UniqueName="Monto"
                                        DataFormatString="{0:N}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%# "0|" + Eval("ServicioId")%>'
                                                Text="Solicitar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br />
                    </asp:View>
                    <asp:View runat="server" ID="v2">
                        <h2>Verificación de Datos
                        </h2>
                        <telerik:RadGrid ID="rgridServicioSeleccionado" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="False" Skin="NoboxGrid">
                            <MasterTableView>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                        UniqueName="Descripcion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CostoServicio" HeaderText="Monto" UniqueName="Monto"
                                        DataFormatString="{0:N}">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br />
                        <asp:Panel runat="server" ID="pnlCampoDescripcion" ClientIDMode="Static" Visible="False">
                            <ul>
                                <li>
                                    <label for="txtDescripcion">
                                        Comentarios</label></li>
                                <li>
                                    <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="250" ClientIDMode="Static"
                                        TextMode="MultiLine" Rows="4" Width="450px"  style="text-transform:uppercase;" />
                                    <div id="txtDescripcionComment" class="comments">
                                        <strong>CAMPO OBLIGATORIO. </strong>Está certificación será trabajada por un analista
                                        en la cámara de comercio. Si posees alguna instrucción o solicitud especifica puedes
                                        escribirla aquí. Máximo 250 caracteres.
                                    </div>
                                </li>
                            </ul>
                        </asp:Panel>
                        <br />
                        <div class="footer_go">
                            <asp:Button ID="btnConfirmar" runat="server" CssClass="btn" Text="Siguiente" OnClick="btnContinuar_Click" />
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Volver atrás" CssClass="btn" />
                            <div class="clear" />
                        </div>
                        <asp:Label runat="server" ID="lblDescripcionObligatoria" CssClass="validator" Text="Debe indicar una descripción"
                            Visible="false" />
                    </asp:View>
                    <asp:View ID="ViewDescargaDigital" runat="server">
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetModelosCertificacion"
                            TypeName="CamaraComercio.DataAccess.EF.SRM.ModelosCertifacionesRepository">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:QueryStringParameter QueryStringField="TipoSociedadId" Name="tipoSociedadId"
                                    Type="Int32" />
                                <asp:Parameter Name="esEmpresa" DefaultValue="True" Type="Boolean" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetServiciosCertificacionAvanzados"
                            TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioRepository" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:Parameter Name="tipoServicioId" Type="Int32" />
                                <asp:QueryStringParameter QueryStringField="TipoSociedadId" Name="tipoSociedadId"
                                    Type="Int32" />
                                <asp:QueryStringParameter QueryStringField="CamaraId" Name="camaraId" Type="String" />
                                <asp:Parameter DefaultValue="True" Name="esEmpresa" Type="Boolean" />
                                <asp:Parameter Name="servicioFlowIdNoRequiereAnalisis" Type="Int32" DefaultValue="" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <h2>Certificaciones Generales
                        </h2>
                        <h5>Las Certificaciones Generales se emiten como resultado de la búsqueda automática
                            en el sistema. No requiere la gestión de un analista. <strong>Nota: Estas certificaciones
                                solo pueden ser pagadas en línea mediante tarjeta de crédito. </strong>
                        </h5>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" OnItemCommand="rgridEmpresas_ItemCommand" DataSourceID="odsModelos"
                            Skin="NoboxGrid" EnableEmbeddedSkins="false">
                            <MasterTableView DataSourceID="odsModelos">
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Descripcion" ItemStyle-Width="70%" HeaderText="Descripción"
                                        UniqueName="Descripcion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Monto" HeaderText="Monto" UniqueName="Monto"
                                        DataFormatString="{0:N}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ModeloId") + "|" + Eval("ServicioId")%>'
                                                Text="Solicitar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br />
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
