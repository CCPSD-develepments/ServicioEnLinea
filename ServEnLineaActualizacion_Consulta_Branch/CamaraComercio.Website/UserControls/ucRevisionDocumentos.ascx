<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRevisionDocumentos.ascx.cs" Inherits="CamaraComercio.Website.UserControls.ucRevisionDocumentos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:ObjectDataSource ID="odsDocsRequeridos" runat="server" SelectMethod="GetDocumentosRequeridos"
    TypeName="CamaraComercio.Website.DTO.ServicioDocumentoRequeridoUI" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" PropertyName="Value"
            Type="Int32" />
        <asp:Parameter Name="grupo" DefaultValue="0" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsDocsRequeridosPorGrupo" runat="server" SelectMethod="GetDocumentosRequeridos"
    TypeName="CamaraComercio.Website.DTO.ServicioDocumentoRequeridoUI" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" PropertyName="Value"
            Type="Int32" />
        <asp:Parameter Name="grupo" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsDocPorGrupo" runat="server" SelectMethod="GetGrupoDocumentosRequeridos"
    TypeName="CamaraComercio.Website.DTO.ServicioDocumentoRequeridoUI" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" PropertyName="Value"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfTipoSociedadId" runat="server" />
<asp:HiddenField ID="hfServicioId" runat="server" />
<asp:HiddenField ID="hfCantExOriginal" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hfCantExCopia" runat="server" ClientIDMode="Static" />
<h2>Servicios seleccionados</h2>
<h4>
    <asp:Repeater runat="server" ID="rpServiciosSeleccionados"
        OnItemCommand="rpServiciosSeleccionados_ItemCommand">
        <ItemTemplate>
            <%# Eval("DescripcionWeb")%><br />
        </ItemTemplate>
    </asp:Repeater>
</h4>

<div>
    <asp:Label runat="server" ID="lbCertificaciones" AssociatedControlID="txtCantidadCertificaciones" CssClass="denominacion">Cuántas certificaciones quiere? </asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtCantidadCertificaciones" runat="server" CssClass="tb wideInput" Text="1" />
</div>
<br />
<asp:MultiView runat="server" ID="mv1" ActiveViewIndex="0">
    <asp:View ID="v1" runat="server">
        <asp:Panel ID="pnDocRequeridos" runat="server">
            <p>
                <asp:Literal runat="server" ID="litCopiasExoneradas" Visible="False">
                                        El registro del original y su primera copia no estan sujetos a cargos.
                </asp:Literal>
            </p>
            <h2>Documentos Requeridos
            </h2>
            <telerik:RadGrid ID="rgriddocumentos" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                GridLines="None" Style="margin-top: 0px" DataSourceID="odsDocsRequeridos" OnItemDataBound="rgriddocumentos_ItemDataBound">
                <MasterTableView DataSourceID="odsDocsRequeridos" DataKeyNames="TipoDocumentoID,Requerido,TipoDocumento.Nombre,
                                    TipoDocumento.CostoOriginal,TipoDocumento.CostoCopia,Grupo,ServicioId,TipoSociedadId,TipoDocumento.Registrable">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="Documento" UniqueName="TipoDocumento.Nombre">
                            <ItemStyle CssClass="NombreDocumento" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNombreDocumento" Text='<%# Bind("TipoDocumento.Nombre") %>' />
                                <asp:HiddenField runat="server" ID="hfDescripcionDoc" ClientIDMode="Predictable"
                                    Value='<%# Bind("TipoDocumento.Descripcion") %>' />
                                <div class="NombreDocumentoHelp" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Fecha Documento">
                            <ItemTemplate>
                                <telerik:RadDatePicker ID="radFechaDocumento" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                    Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                    CssClass="calendario" Nullable="True">
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="reqFecha" runat="server" ErrorMessage="Fecha Documento"
                                    ToolTip="Fecha Documento Requerida" ControlToValidate="radFechaDocumento" Text="*"
                                    ValidationGroup="add" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Costo Original" UniqueName="TipoDocumento.CostoOriginal">
                            <ItemTemplate>
                                <asp:Label runat="server" CssClass="lblCostoOriginal" ID="lblCostoOriginal" Text="0.00" />
                                <span class="hfCostoOriginalRow">
                                    <asp:HiddenField runat="server" ID="hfCostoOriginalRow" Value='<%# Bind("TipoDocumento.CostoOriginal") %>' />
                                </span>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Costo Copia" UniqueName="TipoDocumento.CostoCopia">
                            <ItemTemplate>
                                <asp:Label runat="server" CssClass="lblCostoCopia" ID="lblCostoCopia" Text="0.00" />
                                <span class="hfCostoCopiaRow">
                                    <asp:HiddenField runat="server" ID="hfCostoCopiaRow" Value='<%# Bind("TipoDocumento.CostoCopia") %>' />
                                </span>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Cant. Original" UniqueName="TipoDocumento.CantidadOriginal">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCantidadDocOriginal" runat="server" CssClass="txtUpDown inputNumerico original main"
                                    Text='<%#Bind("CantidadOriginal") %>' Width="45px" />
                                <asp:Label ID="lblOriginal" runat="server" Text="No Requerido" Visible="false" />
                                <asp:HiddenField ID="hfCostoOriginal" runat="server" Value='<%#Eval("TipoDocumento.CostoOriginal") %>' />
                                <asp:HiddenField ID="hfEsRegistrable" runat="server" Value='<%#Eval("TipoDocumento.Registrable") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Cant. Copias" UniqueName="TipoDocumento.CantidadCopia"
                            HeaderStyle-CssClass="copiaColumn rgHeader" ItemStyle-CssClass="copiaColumn">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCantidadDoc" runat="server" CssClass="txtUpDown inputNumerico copia"
                                    Text='<%#Bind("CantidadCopia") %>' Width="45px" /><asp:HiddenField ID="hfCostoCopia"
                                        runat="server" Value='<%#Eval("TipoDocumento.CostoCopia") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="copiaColumn rgHeader" />
                            <ItemStyle CssClass="copiaColumn" />
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView><PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
            </telerik:RadGrid>
        </asp:Panel>
        <asp:Repeater ID="rpGrupoDoc" runat="server" DataSourceID="odsDocPorGrupo" OnItemDataBound="rpGrupoDoc_ItemDataBound">
            <ItemTemplate>
                <h3>Debes seleccionar por lo menos un documento del siguiente grupo</h3>
                <telerik:RadGrid ID="rGridDocumentosPorGrupo" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    GridLines="None" Style="margin-top: 0px">
                    <MasterTableView DataKeyNames="TipoDocumentoID,Requerido,TipoDocumento.Nombre,
                                            TipoDocumento.CostoOriginal,TipoDocumento.CostoCopia,Grupo,ServicioId,TipoSociedadId">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Documento" UniqueName="TipoDocumentoPorGrupo.Nombre">
                                <ItemStyle CssClass="NombreDocumento" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNombreDocumentoPorGrupo" Text='<%# Bind("TipoDocumento.Nombre") %>' />
                                    <asp:HiddenField runat="server" ID="hfDescripcionDoc" ClientIDMode="Predictable"
                                        Value='<%# Bind("TipoDocumento.Descripcion") %>' />
                                    <div class="NombreDocumentoHelp" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>


                            <telerik:GridTemplateColumn HeaderText="Fecha Documento">
                                <ItemTemplate>
                                    <telerik:RadDatePicker ID="radFechaDocumentoPorGrupo" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                        Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                        CssClass="calendario" Nullable="True">
                                    </telerik:RadDatePicker>
                                    <asp:Label runat="server" ID="lblValidacionCalPorGrupo" CssClass="validator calValidator" Text="*" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Costo Original" UniqueName="TipoDocumentoPorGrupo.CostoOriginal">
                                <ItemTemplate>
                                    <asp:Label runat="server" CssClass="lblCostoOriginal" ID="lblCostoOriginalPorGrupo" Text="0.00" />
                                    <span class="hfCostoOriginalRow">
                                        <asp:HiddenField runat="server" ID="hfCostoOriginalRowPorGrupo" Value='<%# Bind("TipoDocumento.CostoOriginal") %>' />
                                    </span>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Costo Copia" UniqueName="TipoDocumentoPorGrupo.CostoCopia">
                                <ItemTemplate>
                                    <asp:Label runat="server" CssClass="lblCostoCopia" ID="lblCostoCopiaPorGrupo" Text="0.00" />
                                    <span class="hfCostoCopiaRow">
                                        <asp:HiddenField runat="server" ID="hfCostoCopiaRowPorGrupo" Value='<%# Bind("TipoDocumento.CostoCopia") %>' />
                                    </span>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Cant. Original" UniqueName="TipoDocumentoPorGrupo.CantidadOriginal">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidadDocOriginalPorGrupo" runat="server" CssClass="txtUpDown inputNumerico original grupo"
                                        Text='<%#Bind("CantidadOriginal") %>' Width="45px" UniqueName="TipoDocumentoPorGrupo.CostoOriginal" />
                                    <asp:HiddenField ID="hfCostoOriginalPorGrupo"
                                        runat="server" Value='<%#Eval("TipoDocumento.CostoOriginal") %>' />
                                    <asp:Label ID="lblOriginalPorGrupo" runat="server" Text="No Requerido" Visible="false" />
                                    <asp:HiddenField ID="hfEsRegistrablePorGrupo" runat="server" Value='<%#Eval("TipoDocumento.Registrable") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Cant. Copias" HeaderStyle-CssClass="copiaColumn rgHeader" UniqueName="TipoDocumentoPorGrupo.CantidadCopia"
                                ItemStyle-CssClass="copiaColumn">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidadDocPorGrupo" runat="server" CssClass="txtUpDown inputNumerico copia grupo"
                                        Text='<%#Bind("CantidadCopia") %>' Width="45px" /><asp:HiddenField ID="hfCostoCopiaPorGrupo"
                                            runat="server" Value='<%#Eval("TipoDocumento.CostoCopia") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView><PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                </telerik:RadGrid>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
        <asp:Panel runat="server" ID="pnlAgregarDocumento">
            <div id="divAgregarDocsLink">
                <p>
                    &nbsp;
                </p>

                <a href="#">Agregar documentos adicionales</a>
                <asp:HiddenField runat="server" ID="hfDocsAdicionales" ClientIDMode="Static" Value="false" />
            </div>
            <div id="divAgregarDocs">
                <fieldset class="form-fieldset">
                    <ul>
                        <li>
                            <h2>Agregar Documentos Adicionales</h2>
                        </li>
                        <li>
                            <asp:Label ID="lblDocumento" runat="server" AssociatedControlID="ddlDocumentos" Text="Documento" />
                            <asp:DropDownList ID="ddlDocumentos" runat="server" DataSourceID="odsDocumentos"
                                Width="300px" DataTextField="Nombre" DataValueField="TipoDocumentoId" AppendDataBoundItems="True"
                                OnDataBound="ddlDocumentos_DataBound">
                                <asp:ListItem>Seleccione un Documento</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsDocumentos" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="SelectAll" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.TipoDocumentoRepository">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="true" Name="siteVisible" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </li>
                        <li>
                            <asp:Label ID="lblcalInicioOperaciones" runat="server" AssociatedControlID="radFechaDocumento"
                                Text="Fecha Documento" />
                            <telerik:RadDatePicker ID="radFechaDocumento" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                CssClass="calendario" Nullable="True">
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="reqFecha" runat="server" ErrorMessage="Fecha Documento"
                                ControlToValidate="radFechaDocumento" Text="*" ValidationGroup="addOpcionales"
                                CssClass="validator"></asp:RequiredFieldValidator>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"
                                    ValidationGroup="addOpcionales" CssClass="btn" />
                                <div class="clear" />
                            </div>
                        </li>
                        <li>
                            <telerik:RadGrid ID="gDocumentosAgregados" runat="server" SkinID="NoboxGrid"
                                GridLines="None">
                                <MasterTableView NoMasterRecordsText="No Documentos Agregados" NoDetailRecordsText="No Documentos Agregados"
                                    AutoGenerateColumns="false"
                                    DataKeyNames="TipoDocumentoID,Requerido,TipoDocumento.Nombre,TipoDocumento.CostoOriginal,TipoDocumento.CostoCopia,Grupo,ServicioId,TipoSociedadId,TipoDocumento.Registrable">
                                    <Columns>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <asp:ImageButton CommandArgument='<%#gDocumentosAgregados.Items.Count %>' OnClick="gDocumentosAgregados_Command"
                                                    runat="server" ImageUrl="~/res/img/icons/cross.png" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Nombre" HeaderText="TipoDocumento">
                                            <ItemStyle Width="450px" />
                                            <HeaderStyle Width="450px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="Fecha" HeaderText="Fecha Documento"
                                            UniqueName="Fecha">
                                            <ItemTemplate>
                                                <asp:Label ID="FechaLabel" runat="server" Text='<%# Eval("Fecha", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="CostoOriginal" HeaderText="Costo Original"
                                            UniqueName="CostoOriginal">
                                            <ItemTemplate>
                                                <asp:Label runat="server" CssClass="lblCostoOriginal" ID="lblCostoOriginal" Text="0.00" />
                                                <span class="hfCostoOriginalRow">
                                                    <asp:HiddenField runat="server" ID="hfCostoOriginalRow" Value='<%# Bind("CostoOriginal") %>' />
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="CostoCopia" HeaderText="Costo Copia" UniqueName="CostoCopia">
                                            <ItemTemplate>
                                                <asp:Label runat="server" CssClass="lblCostoCopia" ID="lblCostoCopia" Text="0.00" />
                                                <span class="hfCostoCopiaRow">
                                                    <asp:HiddenField runat="server" ID="hfCostoCopiaRow" Value='<%# Bind("CostoCopia") %>' />
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cant. Original">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidadDocOriginal" runat="server" CssClass="txtUpDown inputNumerico original agregados"
                                                    Width="45px">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hfCostoOriginal" runat="server" Value='<%#Eval("CostoOriginal") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cant. Copia">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidadDoc" runat="server" CssClass="txtUpDown inputNumerico copia agregados"
                                                    Width="45px">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hfCostoCopia" runat="server" Value='<%#Eval("CostoCopia") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </li>
                    </ul>
                </fieldset>
            </div>
        </asp:Panel>
        <fieldset class="form-fieldset">
            <h2 style="display: none">Total de cargos por registro de documentos</h2>
            <ul>
                <li style="display: none">
                    <label for="txtCosto">
                        Total por seleccionados:</label>
                    <asp:TextBox ID="txtCosto" runat="server" ReadOnly="true" CssClass="tb" ClientIDMode="Static"></asp:TextBox>
                </li>
                <li></li>
                <li>
                    <div class="footer_go">
                        <asp:Button ID="btnContinuar" Text="Continuar" runat="server" OnClick="btnContinuar_Click"
                            ValidationGroup="add" CssClass="btn" />
                        <div class="clear" />
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validator"
                        HeaderText="Por favor verificar que se han llegado todos los campos requeridos"
                        ShowSummary="False" />
                </li>
            </ul>
        </fieldset>
    </asp:View>

    <asp:View runat="server" ID="v2">
        <div class="sectDetailBlue">
            <h1>No se requiere ningún documento.</h1>
            <p>
                El servicio seleccionado no requiere de ningún documento. Haz clikc en "Continuar"
                                para finalizar la transacción.
            </p>
        </div>
        <br />

        <br />
        <div class="footer_go">
            <asp:Button ID="btnContinuar2" Text="Continuar" runat="server" CssClass="floatRight btn"
                OnClick="btnContinuar_Click" />
            <div class="clear" />
        </div>
    </asp:View>
</asp:MultiView>
