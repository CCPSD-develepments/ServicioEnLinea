<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true"
    CodeBehind="Busqueda.aspx.cs" Inherits="CamaraComercio.Website.Consultas.Busqueda" %>

<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .comments-2 {
            color: #666;
            background-color: #FFC;
            border: 1px solid #FC9;
            padding-left: 25px;
            padding-right: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font-size: 12px;
            font-weight: normal;
            -moz-border-radius: 5px;
            border-radius: 5px;
            margin-top: 5px;
        }
    </style>

    <!-- Javascripts -->
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script type="text/javascript">
        var validateSession = false;

        $(document).ready(function () {
            //Menu
            $('#navigation li').removeClass("active");
            $('#liNavRed').addClass("active");

            $('#subnavigation li').removeClass("active");
            $('#liConsultas').addClass("active");
            $(".inputNumerico").numeric();

            //Tabs
            var tabsObj = $("#tabs");
            tabsObj.tabs({
                select: function (event, ui) {
                    $('#hfTabIndex').val(ui.index);
                }
            });
            var tabIndx = parseInt($('#hfTabIndex').val());
            tabsObj.tabs("select", tabIndx);
        });

        $(document).ready(function () {
            var $grid = $('#<%= rgridEmpresas.ClientID %>');
            var $table = $grid.find('table');

            var $input = $('#<%= txtEmpresasFilter.ClientID %>');
            $input.keyup(function () {
                var text = this.value.toLowerCase();
                $table.find('tbody > tr').each(function () {
                    var $tdNoRegistro = $(this).find('td.no-registro');
                    var $tdNombreSocial = $(this).find('td.nombre-social');
                    if ($tdNoRegistro.text().toLowerCase().trim().indexOf(text) !== -1 || $tdNombreSocial.text().toLowerCase().trim().indexOf(text) !== -1) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                });
            });
        });
        $(document).ready(function () {
            var $grid = $('#<%= rgridEmpresasPF.ClientID %>');
            var $table = $grid.find('table');

            var $input = $('#<%= txtEmpresasFilterPF.ClientID %>');
            $input.keyup(function () {
                var text = this.value.toLowerCase();
                $table.find('tbody > tr').each(function () {
                    var $tdNoRegistro = $(this).find('td.no-registro');
                    var $tdNombreSocial = $(this).find('td.nombre-social');
                    if ($tdNoRegistro.text().toLowerCase().trim().indexOf(text) !== -1 || $tdNombreSocial.text().toLowerCase().trim().indexOf(text) !== -1) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                });
            });
        });

        function of() {
            var aquienentregaDoc = document.getElementById('txtBusquedaRNCPF');
            var cambio = aquienentregaDoc.value.replace(/-/gi, '');
            console.warn(cambio);

            if (cambio.length == 11) {
                var nuevoVal = "";
                var antVal = cambio;

                for (var i = 0; i < antVal.length; i++) {
                    if (i == 2) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else if (i == 9) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else {
                        nuevoVal += antVal[i];
                    }
                }
                aquienentregaDoc.value = nuevoVal;
            }
            
            else if (cambio.length < 11) {
                aquienentregaDoc.value = cambio;
                alert('Debe indicar la cédula o RNC valido NO tiene que agregar guiones \"-\", la Cedula o RNC que ingresaste tiene ' + cambio.length + ' números');
            }
            else {
                aquienentregaDoc.value = cambio;
                alert('Debe indicar la cédula o RNC valido NO tiene que agregar guiones \"-\", la Cedula o RNC que ingresaste tiene ' + cambio.length + ' números');

            }
        }

        function ofSociedad() {
            var aquienentregaDoc = document.getElementById('txtBusquedaRNC');
            var cambio = aquienentregaDoc.value.replace(/-/gi, '');
            console.warn(cambio);

            if (cambio.length == 11) {
                var nuevoVal = "";
                var antVal = cambio;

                for (var i = 0; i < antVal.length; i++) {
                    if (i == 2) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else if (i == 9) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else {
                        nuevoVal += antVal[i];
                    }
                }
                aquienentregaDoc.value = nuevoVal;
            }
            else if (cambio.length == 9) {
                var nuevoVal = "";
                var antVal = cambio;

                for (var i = 0; i < antVal.length; i++) {
                    if (i == 0) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else if (i == 2) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else if (i == 7) {
                        nuevoVal += antVal[i] + "-";
                    }
                    else {
                        nuevoVal += antVal[i];
                    }
                }
                aquienentregaDoc.value = nuevoVal;
            }
            else if (cambio.length > 9 && cambio.length < 11) {
                aquienentregaDoc.value = cambio;
                alert('Debe indicar la cédula o RNC valido NO tiene que agregar guiones \"-\", la Cedula o RNC que ingresaste tiene ' + cambio.length + ' números');
            }
            else {
                aquienentregaDoc.value = cambio;
                alert('Debe indicar la cédula o RNC valido NO tiene que agregar guiones \"-\", la Cedula o RNC que ingresaste tiene ' + cambio.length + ' números');

            }

        }
    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfTabIndex" Value="0" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="lblHidSelectedCamaraID" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hfSearchQry" />
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="consultas">Consultas, Certificaciones y Copias certificadas</h1>
            </div>
            <div id="content_body">
                <div id="tabs">
                    <ul>
                        <li><a href="#rpEmpresas">De Sociedades</a></li>
                        <li><a href="#rpPersonaFisica">De Persona Fisica</a></li>
                        <li><a href="#rpPersonas">De Propietario/Accionistas/Socios</a></li>
                    </ul>
                    <div class="tab" id="rpEmpresas">
                        <fieldset class="form-fieldset">
                            <h3>Búsqueda por Sociedades</h3>
                            <ul>
                                <li>
                                    <label for="lblCamara">
                                        Cámara</label>
                                    <asp:DropDownList runat="server" ID="ddlCamara" CssClass="wideInput commentCtrlHov"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas">
                                    </asp:DropDownList>
                                    <div id="ddlCamaraComment" class="comments">
                                        Selecciona la provincia donde esté domiciliada la empresa que busca.
                                    </div>
                                </li>
                                <li>
                                    <label for="ddlTipoBusqueda">
                                        Tipo de Búsqueda</label>
                                    <asp:DropDownList runat="server" ID="ddlTipoBusqueda" CssClass="wideInput commentCtrlHov"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" OnSelectedIndexChanged="ddlTipoBusqueda_SelectedIndexChanged" AutoPostBack="True" />
                                    <div id="ddlTipoBusquedaComment" class="comments">
                                        Selecciona el tipo de búsqueda que desea hacer. Las alternativas incluyen: Por Nombre,
                                        Por RNC ó Cédula y Por Número de Registro Mercantil.
                                    </div>
                                </li>
                                <li>
                                    <label for="txtBusqueda txtBusquedaRNC txtBusquedaR">
                                        Término de Búsqueda
                                    </label>
                                    <asp:TextBox runat="server" ID="txtBusqueda" CssClass="tb wideInput commentCtrl"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvtxtBusqueda" ControlToValidate="txtBusqueda"
                                        Display="None" ErrorMessage="Debe ingresar un parámetro de búsqueda" ClientIDMode="Static"
                                        CssClass="validator summary" ValidationGroup="ConsultaEmpresas"
                                        Enabled="False" />
                                    <div id="txtBusquedaComment" class="comments">
                                        Este campo tiene un máximo de 150 caracteres.
                                    </div>

                                    <asp:DropDownList ID="ddTipoDocumentoSoc" runat="server" CssClass="wideInput"
                                         ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddTipoDocumentoSoc_SelectedIndexChanged" Visible="false">
                                         <asp:ListItem Selected="True" Value="1">Cédula</asp:ListItem>
                                         <asp:ListItem Value="2">RNC</asp:ListItem>
                                     </asp:DropDownList>

                                    <div>
                                        <telerik:RadMaskedTextBox runat="server" ID="txtBusquedaRNC" CssClass="tb wideInput commentCtrl inputNumerico"
                                            ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" Mask="###-#######-#" Visible="false" style="width:200px; margin-top: 7px; margin-bottom:7px;"/>
                                        <asp:RequiredFieldValidator runat="server" ID="rvftxtBusquedaRNC" ControlToValidate="txtBusquedaRNC"
                                            Display="None" ErrorMessage="Debe ingresar un parámetro de búsqueda" ClientIDMode="Static"
                                            CssClass="validator summary" ValidationGroup="ConsultaEmpresas"
                                            Enabled="False" />
                                        <div id="txtBusquedaRNCComment" class="comments">
                                            Este campo solo acepta numeros NO tiene que agregar "-".
                                        </div>
                                    </div>

                                    <asp:TextBox runat="server" ID="txtBusquedaR" CssClass="tb wideInput commentCtrl inputNumerico"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" visible="false"/>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvtxtBusquedaR" ControlToValidate="txtBusquedaR"
                                        Display="None" ErrorMessage="Debe ingresar un parámetro de búsqueda" ClientIDMode="Static"
                                        CssClass="validator summary" ValidationGroup="ConsultaEmpresas"
                                        Enabled="False" />
                                    <div id="txtBusquedaRComment" class="comments">
                                        Este campo solo acepta numeros NO tiene que agregar el sufijo "SD".
                                    </div>

                                </li>
                                <li>
                                    <label for="ckbBusquedaExacta">
                                        Búsqueda exacta
                                    </label>
                                    <asp:CheckBox ID="ckbBusquedaExacta" runat="server" Checked="false" CssClass="wideInput commentCtrlHov" ValidationGroup="ConsultaEmpresas" />
                                    <div id="ckbBusquedaExactaComment" class="comments">
                                        Marcar si desea buscar de manera exacta un resultado, de lo contrario se buscarán los que contengan los términos de búsqueda.
                                    </div>
                                </li>
                                <li>
                                    <div class="footer_go">
                                        <asp:Button runat="server" ID="btnBuscar" Text="Buscar" class="btn btnFormNext" OnClick="btnBuscar_Click"
                                            ValidationGroup="ConsultaEmpresas" />
                                        <div style="clear: both;">
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="lblMensajeSociedades" CssClass="validator"></asp:Label></li>
                            </ul>
                            <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                                Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                                ValidationGroup="ConsultaEmpresas" ClientIDMode="Static" />
                            <asp:Panel runat="server" ID="panelEmpresasFilter" Visible="false">
                                <asp:Label AssociatedControlID="txtEmpresasFilter" runat="server" Text="Buscar" Width="100%" ClientIDMode="Static"></asp:Label>
                                <asp:TextBox ID="txtEmpresasFilter" runat="server" CssClass="tb wideInput" />
                                <div id="txtEmpresasFilterComment" class="comments-2">
                                    Esta búsqueda es sólo en los registros que se están mostrando en pantalla actualmente.
                                </div>
                            </asp:Panel>
                            <telerik:RadGrid ID="rgridEmpresas" runat="server" AllowPaging="True" AllowCustomPaging="true" MasterTableView-PageSize="20" AutoGenerateColumns="False" GridLines="None"
                                OnItemDataBound="rgridEmpresas_ItemDataBound" PageSize="50" EnableEmbeddedSkins="false"
                                Skin="NoboxGrid" Visible="False" OnNeedDataSource="rgridEmpresas_NeedDataSource" OnPreRender="rgridEmpresas_PreRender">
                                <ValidationSettings ValidationGroup="ConsultaEmpresas" />
                                <MasterTableView>
                                    <NoRecordsTemplate>
                                        No se encontraron empresas en la búsqueda. 
                                        <asp:Label id="certificacionNoEspecificada" runat="server" visible ="true">
                                            Si desea puede solicitar una certificación
                                            de una empresa no existente en el Registro Mercantil,
                                            <asp:LinkButton runat="server" ID="lnkCertNoExistente" CommandName="CertNoExistente"
                                                OnClick="lnkCertNoExiste_Click">
                                                haga click aquí.
                                            </asp:LinkButton>
                                         </asp:Label>
                                        
                                    </NoRecordsTemplate>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="SociedadId" UniqueName="SociedadId" Display="false" />
                                        <telerik:GridBoundColumn DataField="RegistroId" UniqueName="RegistroId" Display="false" />
                                        <telerik:GridBoundColumn DataField="NumeroRegistro" HeaderText="No. Registro" ItemStyle-CssClass="no-registro" UniqueName="NumeroRegistro">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Empresa/Sociedad" ItemStyle-CssClass="nombre-social" UniqueName="NombreSocial">
                                        </telerik:GridBoundColumn>

                                         <telerik:GridBoundColumn DataField="Estatus_fecha" HeaderText="Estado" ItemStyle-CssClass="nombre-social" UniqueName="NombreSocial">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="FechaConstitucion" HeaderText="Fecha Constitución"
                                            UniqueName="FechaConstitucion" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkVerDetalleId" runat="server" CausesValidation="false" Text="Seleccionar" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>

                                <FilterMenu EnableEmbeddedSkins="False"></FilterMenu>

                                <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                            </telerik:RadGrid>
                        </fieldset>
                    </div>

                    <div class="tab" id="rpPersonaFisica">
                        <fieldset class="form-fieldset">
                            <h3>Búsqueda por Persona Fisica</h3>
                            <h2>Estamos trabajando</h2>
                            <ul>
                                <li>
                                    <label for="ddlCamaraPF">
                                        Cámara</label>
                                    <asp:DropDownList runat="server" ID="ddlCamaraPF" CssClass="wideInput commentCtrlHov"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas">
                                    </asp:DropDownList>
                                    <div id="ddlCamaraPFComment" class="comments">
                                        Selecciona la provincia donde esté domiciliada la empresa que busca.
                                    </div>
                                </li>
                                <li>
                                    <label for="ddlTipoBusquedaPF">
                                        Tipo de Búsqueda</label>
                                    <asp:DropDownList runat="server" ID="ddlTipoBusquedaPF" CssClass="wideInput commentCtrlHov"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" OnSelectedIndexChanged="ddlTipoBusquedaPF_SelectedIndexChanged" AutoPostBack="True" />
                                    <div id="ddlTipoBusquedaPFComment" class="comments">
                                        Selecciona el tipo de búsqueda que desea hacer. Las alternativas incluyen: Por Nombre,
                                        Por RNC ó Cédula y Por Número de Registro Mercantil.
                                    </div>
                                </li>
                                <li>
                                    <label for="txtBusquedaPF txtBusquedaRNCPF txtBusquedaRPF">
                                        Término de Búsqueda
                                    </label>
                                    <asp:TextBox runat="server" ID="txtBusquedaPF" CssClass="tb wideInput commentCtrl soloLetra"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" Visible="true" MaxLength="150" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvTxtBusquedapf" ControlToValidate="txtBusquedaPF"
                                        Display="None" ErrorMessage="Debe ingresar un parámetro de búsqueda" ClientIDMode="Static"
                                        CssClass="validator summary" ValidationGroup="ConsultaEmpresas"
                                        Enabled="False" />
                                    <div id="txtBusquedaPFComment" class="comments">
                                        Este campo tiene un máximo de 150 caracteres.
                                    </div>
                                    
                                     <asp:DropDownList ID="ddTipoDocumento" runat="server" CssClass="wideInput"
                                         ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddTipoDocumento_SelectedIndexChanged" Visible="false">
                                         <asp:ListItem Selected="True" Value="1">Cédula</asp:ListItem>
                                         <asp:ListItem Value="2">RNC</asp:ListItem>
                                     </asp:DropDownList>

                                    <div>

                                    <telerik:RadMaskedTextBox runat="server" ID="txtBusquedaRNCPF" style="width:200px; margin-top: 7px;" CssClass="wideInput commentCtrl inputNumerico"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" Visible="false" Mask="###-#######-#"/>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvtxtBusquedaRNCPF" ControlToValidate="txtBusquedaRNCPF"
                                        Display="None" ErrorMessage="Debe ingresar un parámetro de búsqueda" ClientIDMode="Static"
                                        CssClass="validator summary" ValidationGroup="ConsultaEmpresas"
                                        Enabled="False" />
                                    <div id="txtBusquedaRNCPFComment" class="comments">
                                        Este campo solo acepta numeros NO tiene que agregar "-".
                                    </div>
                                    </div>

                                    <asp:TextBox runat="server" ID="txtBusquedaRPF" CssClass="tb wideInput inputNumerico commentCtrl"
                                        ClientIDMode="Static" ValidationGroup="ConsultaEmpresas" Visible="false" MaxLength="15" />
                                    <asp:RequiredFieldValidator runat="server" ID="rfvtxtBusquedaRPF" ControlToValidate="txtBusquedaRPF"
                                        Display="None" ErrorMessage="Debe ingresar un parámetro de búsqueda" ClientIDMode="Static"
                                        CssClass="validator summary" ValidationGroup="ConsultaEmpresas"
                                        Enabled="False" />
                                    <div id="txtBusquedaRPFComment" class="comments">
                                        Este campo solo acepta numeros NO tiene que agregar el sufijo "SD-PF".
                                    </div>

                                </li>
                                <li>
                                    <label for="ckbBusquedaExactaPF" id="lblBusquedaExactaPF" runat="server">
                                        Búsqueda exacta
                                    </label>
                                    <asp:CheckBox ID="ckbBusquedaExactaPF" runat="server" Checked="false" Visible="false" CssClass="wideInput commentCtrlHov" ValidationGroup="ConsultaEmpresas" />
                                    <div id="ckbBusquedaExactaCommentPF" class="comments">
                                        Marcar si desea buscar de manera exacta un resultado, de lo contrario se buscarán los que contengan los términos de búsqueda.
                                    </div>
                                </li>
                                <li>
                                    <div class="footer_go">
                                        <asp:Button runat="server" ID="btnBuscarPF" Text="Buscar" class="btn btnFormNext"
                                            ValidationGroup="ConsultaEmpresas" OnClick="btnBuscarPF_Click" />
                                        <div style="clear: both;">
                                        </div>
                                    </div>
                                </li>
                                 <li>
                                    <asp:Label runat="server" ID="lblMensajePF" CssClass="validator"></asp:Label></li>
                            </ul>
                            <asp:ValidationSummary runat="server" ID="errorboxPF" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                                Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                                ValidationGroup="ConsultaEmpresas" ClientIDMode="Static" />
                            <asp:Panel runat="server" ID="panelEmpresasFilterPF" Visible="false">
                                <asp:Label AssociatedControlID="txtEmpresasFilterPF" runat="server" Text="Buscar" Width="100%" ClientIDMode="Static"></asp:Label>
                                <asp:TextBox ID="txtEmpresasFilterPF" runat="server" CssClass="tb wideInput" />
                                <div id="txtEmpresasFilterCommentPF" class="comments-2">
                                    Esta búsqueda es sólo en los registros que se están mostrando en pantalla actualmente.
                                </div>
                            </asp:Panel>
                            <telerik:RadGrid ID="rgridEmpresasPF" runat="server" AllowPaging="True" AllowCustomPaging="true" MasterTableView-PageSize="20" AutoGenerateColumns="False" GridLines="None"
                                OnItemDataBound="rgridEmpresasPF_ItemDataBound" PageSize="50" EnableEmbeddedSkins="false"
                                Skin="NoboxGrid" Visible="False" OnPreRender="rgridEmpresasPF_PreRender">
                                <ValidationSettings ValidationGroup="ConsultaEmpresas" />
                                <MasterTableView>
                                    <NoRecordsTemplate>
                                        No se encontraron empresas en la búsqueda. 
                                        <asp:Label id="certificacionNoEspecificadaPF" runat="server" visible ="true">
                                            Si desea puede solicitar una certificación
                                            de una empresa no existente en el Registro Mercantil,
                                            <asp:LinkButton runat="server" ID="lnkCertNoExistentePF" CommandName="CertNoExistente"
                                                OnClick="lnkCertNoExistePF_Click">
                                                haga click aquí.
                                            </asp:LinkButton>
                                        </asp:Label>
                                    </NoRecordsTemplate>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="PersonaId" UniqueName="PersonaId" Display="false" />
                                        <telerik:GridBoundColumn DataField="RegistroId" UniqueName="RegistroId" Display="false" />
                                        <telerik:GridBoundColumn DataField="NumeroRegistro" HeaderText="No. Registro" ItemStyle-CssClass="no-registro" UniqueName="NumeroRegistro">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Entidad" UniqueName="Entidad" DataField="NombreCompleto" ItemStyle-CssClass="nombre-social">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="NombreCompletoGrid" Text=""></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Fecha Constitucion" UniqueName="FechaInicioOperacion" DataField="FechaInicioOperacion">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblFecha" text=""></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkVerDetalleId" runat="server" CausesValidation="false" Text="Seleccionar" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>

                                <FilterMenu EnableEmbeddedSkins="False"></FilterMenu>

                                <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                            </telerik:RadGrid>
                            
                        </fieldset>
                    </div>

                    <div class="tab" id="rpPersonas">
                        <h3>Búsqueda por Socios/Accionistas/Propietarios</h3>
                        <fieldset class="form-fieldset">
                            <ul>
                                <li>
                                    <label for="ddlCamaraAccionistas">
                                        Cámara</label>
                                    <asp:DropDownList runat="server" ID="ddlCamaraAccionistas" ClientIDMode="Static"
                                        CssClass="commentCtrlHov" ValidationGroup="ConsultaPersonas" />
                                    <div id="ddlCamaraAccionistasComment" class="comments">
                                        Selecciona la provincia donde esté domiciliada del socio/accionista/propietario
                                        que busca.
                                    </div>
                                </li>
                                <li>
                                    <label for="txtNombre">
                                        Nombres</label>
                                    <asp:TextBox runat="server" ID="txtNombre" ClientIDMode="Static"
                                        CssClass="tb shortInput commentCtrl" ValidationGroup="ConsultaPersonas" />
                                    &nbsp;
                                    <asp:TextBox runat="server" ID="txtSegundoNombre" ClientIDMode="Static"
                                        CssClass="tb shortInput commentCtrl" ValidationGroup="ConsultaPersonas" />
                                    <div id="txtNombreComment" class="comments">
                                        Introduce el primer nombre del socio/accionista/propietario que desea buscar.
                                    </div>
                                    <div id="txtSegundoNombreComment" class="comments">
                                        Introduce el segundo nombre del socio/accionista/propietario
                                    </div>
                                </li>
                                <li>
                                    <label for="txtApellido">
                                        Apellidos</label>
                                    <asp:TextBox runat="server" ID="txtApellido" ClientIDMode="Static"
                                        CssClass="tb shortInput commentCtrl" ValidationGroup="ConsultaPersonas" />
                                    &nbsp;
                                    <asp:TextBox runat="server" ID="txtSegundoApellido" ClientIDMode="Static"
                                        CssClass="tb shortInput commentCtrl" ValidationGroup="ConsultaPersonas" />
                                    <div id="txtApellidoComment" class="comments">
                                        Introduce el primer apellido del socio/accionista/propietario que desa buscar.
                                    </div>
                                    <div id="txtSegundoApellidoComment" class="comments">
                                        Introduce el segundo apellido del socio/accionista/propietario que desa buscar.
                                    </div>
                                </li>
                                <li>
                                    <label for="txtCedula">
                                        Cédula/Pasaporte</label>
                                    <asp:TextBox runat="server" ID="txtCedula" ClientIDMode="Static"
                                        CssClass="tb wideInput commentCtrl" ValidationGroup="ConsultaPersonas" MaxLength="14" />
                                    <div id="txtCedulaComment" class="comments">
                                        Introduce el número de cédula, pasaporte ó otro documento de identificación del
                                        socio/accionista/propietario que busca.
                                    </div>
                                </li>
                                <li>
                                    <div class="footer_go">
                                        <asp:Button runat="server" ID="btnBuscarSocios" Text="Buscar" ClientIDMode="Static"
                                            CssClass="btn btnFormNext" OnClick="btnBuscarSocios_Click" ValidationGroup="ConsultaPersonas" /><div
                                                style="clear: both;">
                                            </div>
                                    </div>
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="lblMensajeSocios" CssClass="validator"></asp:Label></li>
                            </ul>
                            <asp:ValidationSummary runat="server" ID="errorbox2" CssClass="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                                Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                                ValidationGroup="ConsultaPersonas" ClientIDMode="Static" />
                            <telerik:RadGrid runat="server" ID="rgBusquedaSocios" AutoGenerateColumns="False"
                                GridLines="None" OnItemDataBound="rgBusquedaSocios_ItemDataBound" EnableEmbeddedSkins="false"
                                Skin="NoboxGrid" Visible="False">
                                <ValidationSettings ValidationGroup="ConsultaPersonas" />
                                <MasterTableView>
                                    <NoRecordsTemplate>
                                        No se encontraron personas en la búsqueda.
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="PersonaId" Display="False" HeaderText="Persona ID"
                                            UniqueName="PersonaId">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TipoDocumento" HeaderText="Tipo Documento" UniqueName="TipoDocumento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Documento" HeaderText="No. Documento" UniqueName="Documento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PrimerNombre" HeaderText="Primer Nombre" UniqueName="PrimerNombre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SegundoNombre" HeaderText="Segundo Nombre" UniqueName="SegundoNombre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PrimerApellido" HeaderText="Primer Apellido"
                                            UniqueName="PrimerApellido">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SegundoApellido" HeaderText="Segundo Apellido"
                                            UniqueName="SegundoApellido">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkVerPersona" runat="server" CausesValidation="false" Text="Seleccionar" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>

                                <FilterMenu EnableEmbeddedSkins="False"></FilterMenu>

                                <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                            </telerik:RadGrid>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
