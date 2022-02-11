<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="EnvioDatos.aspx.cs" Inherits="CamaraComercio.Website.Empresas.EnvioDatos" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Envio de Datos de Solicitud</title>
    <!-- CSS -->
    <link href="/res/css/buttons.css" rel="stylesheet" type="text/css" />
    <!-- jQuery UI -->
    <script src="/res/js/json2.js" type="text/javascript"></script>
    <!-- Manejo del Upload client side -->
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
    <script src="/res/js/ui.enviodatos.js" type="text/javascript"></script>
    <script src="/res/js/jquery.tools.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $(".FirmaDigital img[title]").tooltip();
            $("[title]").tooltip();
        });
        
    </script>

    <style type="text/css">
        .tooltip {
            display: none;
            background: transparent url(/res/img/black_arrow.png);
            font-size: 10px;
            height: 70px;
            width: 50%;
            padding:50px;
            color: #fff;
            background-repeat: no-repeat;
            background-size: 100% 100%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="documentos">Envio de Datos <span class="right normal">Número de Solicitud <strong>
                    <asp:Label runat="server" ForeColor="SteelBlue" ID="lblNumSolicitudTitulo" /></strong></span>
                </h1>
            </div>
            <div id="content_body">
                <p>
                    Introduce la información correspondiente en cada campo, adjunta los documentos digitales
                    necesarios para la solicitud no.
                    <asp:Label runat="server" ID="lblNumSolicitud" />. y haz click sobre "Someter Documentos".
                    <br />
                    <br />
                    <%--                    Todos los documentos deben estar autenticados por una firma digital. Para obtener
                    más información sobre firmas digitales visite <a href="http://camarasantodomingo.do/productos-y-servicios/firmas-electronicas/">
                        Soluciones Digitales</a>.--%>

                    <telerik:RadScriptManager ID="radScriptManager1" runat="server" EnablePageMethods="true">
                    </telerik:RadScriptManager>
                    <telerik:RadAjaxManager ID="radAjaxManager" runat="server" UpdatePanelsRenderMode="Inline">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="rgriddocumentosEnviados" EventName="OnItemCommand">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="rgriddocumentosEnviados" LoadingPanelID="pnlDocumentosEnviados" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <asp:HiddenField ID="hfTipoSociedadId" runat="server" />
                    <asp:HiddenField ID="hfServicioId" runat="server" />
                    <asp:HiddenField ID="hfsolicitudID" ClientIDMode="Static" runat="server" />
                    <asp:HiddenField ID="hfusuarioID" ClientIDMode="Static" runat="server" />
                    <asp:HiddenField ID="hfSessionID" ClientIDMode="Static" runat="server" />
                </p>
                <h3>Documentos Requeridos / Seleccionados</h3>
                <asp:ObjectDataSource ID="odsDocsRequeridos" runat="server" SelectMethod="GetDocumentosInTransaccion"
                    TypeName="CamaraComercio.DataAccess.EF.CamaraComun.ServicioDocumentoRequeridoRepository">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="transaccionId" QueryStringField="nSolicitud" Type="Int32" />
                        <asp:ControlParameter ControlID="hfTipoSociedadId" Name="tipoSociedadId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <img id="loading" src="/res/img/Progress.gif" alt="Cargando..." style="display: none" />
                <img id="imgSucceed" src="/res/img/tick.png" alt="Actualizado" style="display: none" />
                <telerik:RadGrid ID="rgriddocumentos" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    GridLines="None" Style="margin-top: 0px" DataSourceID="odsDocsRequeridos" OnItemDataBound="rgriddocumentos_ItemDataBound">
                    <MasterTableView DataSourceID="odsDocsRequeridos" DataKeyNames="TipoDocumentoId">
                        <Columns>
                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Documento">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="cantCopia" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                HeaderText="Cantidad que puede subir">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="cantCopiasDocReq" text =""></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle PagerTextFormat="Cambiar Página: {4} &amp;nbsp;{5} registros en {1} páginas." />
                </telerik:RadGrid>
                <br />
                    <asp:Panel runat="server" ID="pnlComentarioServicio" Visible="false"  CssClass="sectDetail" >                    
                        <strong style="font-size: 15px;">
                            <asp:Label ID="lblMensaje" runat="server" style="color:black" Visible="False" CssClass="sectDetail" BorderStyle="None"></asp:Label>
                        </strong>                    
                </asp:Panel>
                <br />
                <div>
                         <h3>Agregar Documentos</h3>
                         <h5>Para agregar documentos Restantes hacer click en Subir Documentos, elija el tipo
                             de documento agrege una descripcion en caso de ser necesario y luego hacer clic
                             en Enviar.</h5>
                    <div id="divUpload" runat ="server" clientidmode="Static">
                        <asp:FileUpload runat="server" ID="uploadDocumento" ClientIDMode="Static" Style="visibility: hidden;"
                            onchange="uploadChangeEvent(this.value);"  accept="application/pdf"/>
                        <div class="buttons">
                            <a href="#" class="uploadLink" onclick="triggerFileUpload()">
                                <img src="/res/img/icons/page_attach.png" alt="" />
                                <span id="uploadText" runat="server" clientidmode="Static">Seleccionar documento</span> </a>
                            <asp:LinkButton runat="server" ID="btnUploadDocumento" ClientIDMode="Static" OnClick="btnUploadDocumento_Click">
                                <img src="/res/img/icons/add.png" alt=""/> 
                                Enviar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div id="divUploadIE" style="visibility: hidden;">
                        <asp:FileUpload style="display:table-cell; padding-top:5px; padding-right:15px; vertical-align:middle;" runat="server" ID="uploadDocumentoIE" ClientIDMode="Static" />
                        <div class="buttons" style="display:table-cell; vertical-align:middle;">
                            <asp:LinkButton runat="server" ID="btnUploadDocumentoIE" ClientIDMode="Static" OnClick="btnUploadDocumentoIE_Click">
                                <img src="/res/img/icons/add.png" alt=""/> 
                                Enviar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="clear" />
                </div>
                <br />
                &nbsp;<hr />
                <h3>Mis Documentos Enviados&nbsp;
                    <asp:ObjectDataSource ID="odDocuentosEnviados" runat="server" OldValuesParameterFormatString="{0}"
                        SelectMethod="DocumentosEnviados" TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionDocumentosController"
                        UpdateMethod="UpdateDocumentosEnviados" DeleteMethod="DeleteDocumentosEnviados">
                        <DeleteParameters>
                            <asp:Parameter Name="TransaccionesDocumentosId" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfsolicitudID" Name="_transaccionID" PropertyName="Value"
                                Type="Int32" />
                            <asp:Parameter Name="pagInicio" Type="Int32" />
                            <asp:Parameter Name="pagTamano" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="TransaccionesDocumentosId" Type="Int32" />
                            <asp:Parameter Name="Descripcion" Type="String" />
                            <asp:Parameter Name="FechaEnvio" Type="DateTime" />
                            <asp:Parameter Name="nombre" Type="String" />
                            <asp:Parameter Name="firmaDigital" Type="Boolean" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </h3>
                <telerik:RadGrid ID="rgriddocumentosEnviados" CssClass="gridEnviados" runat="server"
                    AutoGenerateColumns="False" GridLines="None" DataSourceID="odDocuentosEnviados"
                    OnItemDataBound="rgriddocumentosEnviados_ItemDataBound" AllowAutomaticUpdates="True"
                    OnItemCreated="rgriddocumentosEnviados_ItemCreated" OnItemCommand="rgriddocumentosEnviados_ItemCommand">
                    <MasterTableView DataSourceID="odDocuentosEnviados" DataKeyNames="TransaccionesDocumentosId,TipoDocumentoId"
                        AutoGenerateColumns="false" AllowAutomaticUpdates="true" EditMode="EditForms">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"
                                UniqueName="Descripcion">
                                <ItemTemplate>
                                    <asp:Label ID="DescripcionLabel" CssClass="onFlyUpdate" runat="server" Text='<%# Eval("Nombre") %>'
                                        Width="225px"></asp:Label>
                                    <asp:HiddenField runat="server" ID="hfTransaccionDocumentoId" Value='<%# Eval("TransaccionesDocumentosId")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Tipo de Documento" DataField="TipoDocumento">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" ID="ddlTiposDocumentos" CssClass="onFlyUpdate docsSeleccionados"
                                        AppendDataBoundItems="true" DataTextField="Nombre" DataValueField="TipoDocumentoId"
                                        DataSourceID="odsTipoDocumentos" Width="230px" ClientIDMode="Static">
                                        <asp:ListItem Text="Seleccione Tipo Documento" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="-1" ID="ReqDropDownList"
                                        runat="server" ControlToValidate="ddlTiposDocumentos"
                                        Text="* Debe seleccionar un tipo" ErrorMessage="ErrorMessage"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="FirmaDigital" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Firma Digital">
                                <ItemStyle CssClass="FirmaDigital" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkFirmasDigital" runat="server" CssClass="onFlyUpdate" />
                                    <asp:Image ID="HelpImg" runat="server" ImageUrl='/res/img/icons/help.png' visible="true"  />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="FechaEnvio" DataType="System.DateTime" HeaderText="FechaEnvio"
                                SortExpression="FechaEnvio" UniqueName="FechaEnvio">
                                <ItemTemplate>
                                    <asp:Label ID="FechaEnvioLabel" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("FechaEnvio")) %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="DeleteAction">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDeleteDocument" runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%# Eval("TransaccionesDocumentosId") %>'>Eliminar</asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="Edit" Text="Edit"
                                Visible="False">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings EditFormType="Template">
                            <FormTemplate>
                                <table id="Table1" cellspacing="1" cellpadding="1" width="250" border="0">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNombre" runat="server" Text="Nombre :" AssociatedControlID="txtNombre"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtNombre" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="*" ControlToValidate="txtNombre"
                                                ValidationGroup="editDoc"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion :" AssociatedControlID="txtDescripcion"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDescripcion" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqDescripcion" runat="server" ErrorMessage="*" ControlToValidate="txtDescripcion"
                                                ValidationGroup="editDoc"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFecha" runat="server" AssociatedControlID="txtFecha" Text="Fecha Envio :"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker runat="server" ID="txtFecha" SelectedDate='<%#Bind("FechaEnvio") %>'>
                                            </telerik:RadDatePicker>
                                            <asp:RequiredFieldValidator ID="reqFecha" runat="server" ErrorMessage="*" ControlToValidate="txtFecha"
                                                ValidationGroup="editDoc"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:LinkButton ID="lnkUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                                                runat="server" ValidationGroup="editDoc" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                            </asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" CausesValidation="False"
                                                CommandName="Cancel">
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </FormTemplate>
                        </EditFormSettings>
                        <EditItemTemplate>
                            <div>
                                <p>
                                    <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtNombre" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="*" ControlToValidate="txtNombre"
                                        ValidationGroup="editDoc"></asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:Label ID="lblDescripcion" runat="server" AssociatedControlID="txtDescripcion"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtDescripcion" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqDescripcion" runat="server" ErrorMessage="*" ControlToValidate="txtDescripcion"
                                        ValidationGroup="editDoc"></asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:Label ID="lblFecha" runat="server" AssociatedControlID="txtFecha"></asp:Label>
                                    <telerik:RadDatePicker runat="server" ID="txtFecha" SelectedDate='<%#Bind("FechaEnvio") %>'>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="reqFecha" runat="server" ErrorMessage="*" ControlToValidate="txtFecha"
                                        ValidationGroup="editDoc"></asp:RequiredFieldValidator>
                                </p>
                                <asp:LinkButton ID="lnkUpdate" CommandName="Update" runat="server" ValidationGroup="editDoc"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" CommandName="Cancel" CausesValidation="false" runat="server"></asp:LinkButton>
                            </div>
                        </EditItemTemplate>
                    </MasterTableView>
                    <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                </telerik:RadGrid>
                <asp:ObjectDataSource ID="odsTipoDocumentos" runat="server" TypeName ="CamaraComercio.Website.Empresas.EnvioDatos"
                    SelectMethod="SelectAllByTransId">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="nSolicitud" Name="TransaccionId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <div id="FooterButtonDiv">
                    <a href="#" class="btn" id="FooterButton" style="display: none">Enviar Documentos</a>
                    <div class="clear" />
                </div>
                <div id="FooterDiv">
                    <%--                    <ul>
                        <li>
                            <label for="txtPersonaContacto">
                                Persona Contacto</label>
                            <asp:TextBox runat="server" ID="txtPersonaContacto" ClientIDMode="Static" CssClass="tb commentCtrl" />
                            <div class="comments" id="txtPersonaContactoComment">
                                Especifica la persona de contacto a llamar para dar seguimiento a esta solicitud.
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPersonaContacto" ClientIDMode="Static"
                                Text="*" ErrorMessage="Debe especificar la persona de contacto" CssClass="validator summary"
                                ValidationGroup="ContactoVal" ControlToValidate="txtPersonaContacto" />
                        </li>
                        <li>
                            <label for="txtTelefonoContacto">
                                Teléfono Contacto</label>
                            <asp:TextBox runat="server" ID="txtTelefonoContacto" ClientIDMode="Static" CssClass="tb commentCtrl numeric" />
                            <div class="comments" id="txtTelefonoContactoComment">
                                Especifica el número telefónico de la persona de contacto.
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="rfvTelefonoContacto" ClientIDMode="Static"
                                Text="*" ErrorMessage="Debe especificar el teléfono de contacto" CssClass="validator summary"
                                ValidationGroup="ContactoVal" ControlToValidate="txtTelefonoContacto" />
                        </li>
                    </ul>--%>
                    <div class="footer_go">
                        <asp:Button ID="btnEnvioTransaccion" runat="server" Text="Someter Documentos" OnClick="btnEnviarTransaccion_Click"
                            ClientIDMode="Static" CssClass="btn" />
                        <asp:Button ID="Button2" runat="server" OnClick="btnBack_Click" Text="Volver atrás" CssClass="btn" />

                        <div class="clear" />
                    </div>
                </div>
                <asp:ValidationSummary runat="server" ID="errorBoxPersonaVal" CssClass="errorbox"
                    HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                                Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                    ClientIDMode="Static" ValidationGroup="ContactoVal" />
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>

</asp:Content>
