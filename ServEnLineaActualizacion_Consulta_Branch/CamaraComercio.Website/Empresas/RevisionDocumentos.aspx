<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="RevisionDocumentos.aspx.cs" Inherits="CamaraComercio.Website.Empresas.RevisionDocumentos" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Plugins -->
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/ui.spinner.js" type="text/javascript"></script>
    <script src="/res/js/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>
    <script src="/res/js/jquery.tools.min.js" type="text/javascript"></script>
    <script src="/res/js/ui.revisiondocumentos.js" type="text/javascript"></script>
    <script src="/res/js/ui.enviodatos.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

    </script>

    <!--Styles-->
    <style type="text/css">
        .tooltip {
            display: none;
            background: transparent url(/res/img/black_arrow.png);
            font-size: 10px;
            height: 70px;
            width: 160px;
            padding: 25px;
            color: #fff;
        }

        .txtUpDown {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="radScriptManager1" runat="server" EnablePageMethods="true">
    </telerik:RadScriptManager>
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
    <asp:HiddenField ID="hfTransaccionId" runat="server" />
    <asp:HiddenField ID="hfServicioId" runat="server" />
    <asp:HiddenField ID="hfCantExOriginal" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hfCantExCopia" runat="server" ClientIDMode="Static" />
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="documentos">
                    <span class="right normal">
                        <asp:Label runat="server" ID="lblNombreEmpresa" />
                    </span>Revisión de Documentos
                </h1>
            </div>
            <div id="content_body">
                <h2>Servicios seleccionados</h2>
                <h4>
                    <asp:Repeater runat="server" ID="rpServiciosSeleccionados"
                        OnItemCommand="rpServiciosSeleccionados_ItemCommand">
                        <ItemTemplate>
                            <%# Eval("DescripcionWeb")%><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </h4>

                <div id="certificacionDiv" runat="server">
                    <asp:Label runat="server" ID="lbCertificaciones" AssociatedControlID="txtCantidadCertificaciones" CssClass="denominacion" Visible="false">¿Cuántas copias originales quiere? </asp:Label>
                
                    <asp:TextBox ID="txtCantidadCertificaciones" runat="server" Visible="false" CssClass="tb   inputNumerico" Text="1"
                        MaxLength="3" Mask="000" CausesValidation="true" OnTextChanged="txtCantidadCertificaciones_TextChanged"  ReadOnly="true" hidden/>

                    <asp:RegularExpressionValidator ID="cantidadCertificacionesRegulator" runat="server"
                        ControlToValidate="txtCantidadCertificaciones" ErrorMessage="*Ingrese solo Números del 1 al 999"
                        ForeColor="Red"
                        ValidationExpression="\d+"
                        EnableClientScript="true"
                        Display="Static"
                        >
                    </asp:RegularExpressionValidator>
                   
                    <asp:Label runat="server" ID="lblImpresoDoc" AssociatedControlID="" CssClass="denominacion" Visible="false" hidden>¿Desea que los documentos solicitados sean impresos por la CCPSD o desea recibirlos en formato digital?</asp:Label>
                  
                    <br />
               <asp:Label runat="server" ID="lblIDepositarCansilleria" CssClass="denominacion" Visible="true">¿Estos documentos serán depositados en cancillería?</asp:Label>
                <br />
                <br />
                <asp:RadioButtonList ID="rblDepositarCansilleria"  OnSelectedIndexChanged="rblDepositarCansilleria_SelectedIndexChanged" 
                    runat="server" Visible="true" AutoPostBack="True">
                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
                <br />


                   <%--   <asp:RadioButtonList ID="rblImpreso" runat="server" Visible="false" 
                        OnSelectedIndexChanged="rblImpreso_SelectedIndexChanged" AutoPostBack="True" >
                      <asp:ListItem Text="Imprimir en CCPSD y pasar a retirar."  Value="0"></asp:ListItem>
                        <asp:ListItem Text=""  Value="1"></asp:ListItem>
                    </asp:RadioButtonList>--%>
                    <div style="background: #FFC;">
                     <asp:Label runat="server"  ID="Label1" CssClass="denominacion" Visible="false" ></asp:Label>
                      </div>

                    <br /><br />
                    <asp:Label runat="server" ID="lblINombreQuein" CssClass="denominacion" Visible="true">¿A nombre de quien se emitirá?</asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtNombreQuien" runat="server" CssClass="tb wideInput" MaxLength="200" Visible="true"  style="text-transform:uppercase;" />
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblICedulaQuein" CssClass="denominacion" Visible="true">Cedula o RNC.</asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="ddTipoDocumento" runat="server" Width="225px" CssClass="commentCtrl"
                            ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddTipoDocumento_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="1">Cédula</asp:ListItem>
                            <asp:ListItem Value="2">RNC</asp:ListItem>
                        </asp:DropDownList>
                    <br />
                    <br />

    

                    <%--<asp:TextBox runat="server" ID="txtDocumentoNombreQuien" Visible="true" ClientIDMode="Static" AutoPostBack="true"
                        CssClass="tb inputNumerico tipsyBox" MaxLength="11">
                    </asp:TextBox>--%>
                    
                    <%-- <telerik:RadMaskedTextBox runat="server" ID="txtDocumentoNombreQuien" 
                         CssClass="tb tipsyBox inputNumerico" ClientIDMode="Static" AutoPostBack="true" Mask="###-#######-#"
                        onKeyup="op()"
                         original-title="Número de cédula o rnc del usuario. No usar espacios o guiones, solo números">
                     </telerik:RadMaskedTextBox>--%>
                    <telerik:RadMaskedTextBox runat="server" ID="txtDocumentoNombreQuienMask" Mask="###-#######-#" CssClass="tb wideInput">
                    </telerik:RadMaskedTextBox>
                    


                </div>
                <br />
                <br />
              
                <asp:Panel runat="server" ID="pnlComentarioServicio" Visible="false"  CssClass="sectDetail">                    
                    <strong style="font-size: 15px;">
                        <asp:Label ID="lblMensaje" runat="server" style="color:black" Visible="False" CssClass="sectDetail" BorderStyle="None"></asp:Label>
                    </strong>               
                </asp:Panel>
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
                            <telerik:RadGrid ID="rgriddocumentos" runat="server" AllowSorting="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" GridLines="None" Style="margin-top: 0px" DataSourceID="odsDocsRequeridos" OnItemDataBound="rgriddocumentos_ItemDataBound">
                                <MasterTableView DataSourceID="odsDocsRequeridos" AllowAutomaticUpdates="true" EditMode="EditForms" DataKeyNames="TipoDocumentoID,Requerido,TipoDocumento.Nombre,TipoDocumento.CostoOriginal,TipoDocumento.CostoCopia,Grupo,ServicioId,TipoSociedadId,TipoDocumento.Registrable">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Documento" UniqueName="TipoDocumento.Nombre">
                                            <ItemStyle CssClass="NombreDocumento" />
                                            <ItemTemplate>
                                                
                                                <asp:Label runat="server" ID="lblNombreDocumento" Text='<%# Bind("TipoDocumento.Nombre") %>' Enabled="true" />
                                                <asp:HiddenField runat="server" ID="hfDescripcionDoc" ClientIDMode="Predictable" Value='<%# Bind("TipoDocumento.Descripcion") %>' />
                                                <asp:Image ID="HelpImg" runat="server" ImageUrl='/res/img/icons/help.png'
                                                ToolTip='' visible="false"/>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Fecha Documento" EditFormHeaderTextFormat="{0:dd/MM/yyyy}">
                                            <ItemTemplate>
                                                <telerik:RadDatePicker ID="radFechaDocumento" runat="server" Calendar-TitleFormat ="dd/MM/yyyy" 
                                                    DateInput-DateFormat="dd/MM/yyyy" DateInput-DisplayDateFormat="dd/MM/yyyy" 
                                                    ImageUrl="/res/img/calendar.png" Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy"
                                                    
                                                    NullableLabelText="Seleccione una fecha" CssClass="calendario" Nullable="True" 
                                                    Calendar-CultureInfo="es-DO" DateInput-Culture="es-DO" Calendar-CellDayFormat="%d" AutoPostBack="true">
                                                </telerik:RadDatePicker>
                                                <asp:RequiredFieldValidator ID="reqFecha" runat="server" ErrorMessage="Fecha Documento" ToolTip="Fecha Documento Requerida" ControlToValidate="radFechaDocumento" Text="*" ValidationGroup="add" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Costo Original" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" UniqueName="TipoDocumento.CostoOriginal">
                                            <ItemTemplate>
                                                <asp:Label runat="server" CssClass="lblCostoOriginal" ID="lblCostoOriginal" Text="0.00" />
                                                <span class="hfCostoOriginalRow">
                                                    <asp:HiddenField runat="server" ID="hfCostoOriginalRow" Value='<%# Bind("TipoDocumento.CostoOriginal") %>' />
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Costo Copia" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" UniqueName="TipoDocumento.CostoCopia">
                                            <ItemTemplate>
                                                <asp:Label runat="server" CssClass="lblCostoCopia" ID="lblCostoCopia" Text="0.00" />
                                                <span class="hfCostoCopiaRow">
                                                    <asp:HiddenField runat="server" ID="hfCostoCopiaRow" Value='<%# Bind("TipoDocumento.CostoCopia") %>' />
                                                </span>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cant. Original" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" UniqueName="TipoDocumento.CantidadOriginal">
                                            <ItemTemplate>
                                                    <asp:TextBox ID="txtCantidadDocOriginal" runat="server" CssClass="txtUpDown inputNumerico original main" 
                                                        Text='<%#Bind("CantidadOriginal") %>' Width="45px" />
                                                    <asp:Label ID="lblOriginal" runat="server" Text="No Requerido" Visible="false" />
                                                    <asp:HiddenField ID="hfCostoOriginal" runat="server" Value='<%#Eval("TipoDocumento.CostoOriginal") %>' />
                                                    <asp:HiddenField ID="hfEsRegistrable" runat="server" Value='<%#Eval("TipoDocumento.Registrable") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cant. Copias" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" UniqueName="TipoDocumento.CantidadCopia" HeaderStyle-CssClass="copiaColumn rgHeader" ItemStyle-CssClass="copiaColumn">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidadDoc" runat="server" CssClass="txtUpDown inputNumerico copia" Text='<%#Bind("CantidadCopia") %>' Width="45px" Visible="true" Enabled="true" />
                                                <asp:HiddenField ID="hfCostoCopia" runat="server" Value='<%#Eval("TipoDocumento.CostoCopia") %>' />
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
                                <telerik:RadGrid ID="rGridDocumentosPorGrupo" runat="server" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" 
                                     Style="margin-top: 0px" DataSourceID="odsDocsRequeridosPorGrupo" OnItemDataBound="rGridDocumentosPorGrupo_ItemDataBound" >
                                    <MasterTableView DataKeyNames="TipoDocumentoID,Requerido,TipoDocumento.Nombre,TipoDocumento.CostoOriginal,TipoDocumento.CostoCopia,Grupo,ServicioId,TipoSociedadId">
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Documento" UniqueName="TipoDocumento.Nombre">
                                                <ItemStyle CssClass="NombreDocumento" />
                                                <ItemTemplate>
                                                    
                                                    <asp:Label runat="server" ID="lblNombreDocumentoPorGrupo" Text='<%# Bind("TipoDocumento.Nombre") %>' />
                                                    <asp:HiddenField runat="server" ID="hfDescripcionDoc" ClientIDMode="Predictable"
                                                        Value='<%# Bind("TipoDocumento.Descripcion") %>' />
                                                    <asp:Image ID="HelpImg" runat="server" ImageUrl='/res/img/icons/help.png'
                                                        ToolTip='' visible="false" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Fecha Documento">
                                                <ItemTemplate>
                                                    <telerik:RadDatePicker ID="radFechaDocumento" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                                        Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                                        CssClass="onFlyUpdate calendario" EditFormHeaderTextFormat="{0:dd/MM/yyyy}"
                                                        DateInput-DateFormat="dd/MM/yyyy" Nullable="True">
                                                    </telerik:RadDatePicker>
                                                    <asp:Label runat="server" ID="lblValidacionCal" CssClass="validator calValidator" Text="*" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Costo Original" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                UniqueName="TipoDocumento.CostoOriginal">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" CssClass="lblCostoOriginal" ID="lblCostoOriginalPorGrupo" Text="0.00" />
                                                    <span class="hfCostoOriginalRow">
                                                        <asp:HiddenField runat="server" ID="hfCostoOriginalRow" Value='<%# Bind("TipoDocumento.CostoOriginal") %>' />
                                                    </span>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Costo Copia" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                UniqueName="TipoDocumento.CostoCopia">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" CssClass="lblCostoCopia" ID="lblCostoCopia" Text="0.00" />
                                                    <span class="hfCostoCopiaRow">
                                                        <asp:HiddenField runat="server" ID="hfCostoCopiaRow" Value='<%# Bind("TipoDocumento.CostoCopia") %>' />
                                                    </span>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Cant. Original" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                UniqueName="TipoDocumento.CantidadOriginal">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCantidadDocOriginal" runat="server" CssClass="onFlyUpdate txtUpDown inputNumerico original grupo"
                                                        Text='<%#Bind("CantidadOriginal") %>' Width="45px" UniqueName="TipoDocumento.CostoOriginal" />
                                                    <asp:HiddenField ID="hfCostoOriginal"
                                                        runat="server" Value='<%#Eval("TipoDocumento.CostoOriginal") %>' />
                                                    <asp:Label ID="lblOriginal" runat="server" Text="No Requerido" Visible="false" />
                                                    <asp:HiddenField ID="hfEsRegistrable" runat="server" Value='<%#Eval("TipoDocumento.Registrable") %>' />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Cant. Copias" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="copiaColumn rgHeader" UniqueName="TipoDocumento.CantidadCopia"
                                                ItemStyle-CssClass="copiaColumn">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCantidadDoc" runat="server" CssClass="onFlyUpdate txtUpDown inputNumerico copia grupo"
                                                        Text='<%#Bind("CantidadCopia") %>' Width="45px" /><asp:HiddenField ID="hfCostoCopia"
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
                        <%--                        <asp:Panel runat="server" ID="pnlAgregarDocumento">
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
                                            <h2>
                                                Agregar Documentos Adicionales</h2>
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
                        </asp:Panel>--%>
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
                                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Volver atrás" CssClass="btn" />

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
                            <asp:Button ID="Button2" runat="server" OnClick="btnBack_Click" Text="Volver atrás" CssClass="btn" />
                            <div class="clear" />
                        </div>
                    </asp:View>
                </asp:MultiView>

            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
