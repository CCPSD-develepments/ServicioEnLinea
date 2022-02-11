<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocioDetails.ascx.cs"
    Inherits="CamaraComercio.Website.UserControls.SocioDetails" %>
<%@ Import Namespace="CamaraComercio.Website" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Literal ID="litTipoDocumento" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.TipoDocumento" ) %>' />
<asp:Literal ID="litAdmin" Visible="False" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.TipoRelacion" ) %>' />
<asp:Literal ID="litCiudadID" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionCiudadId" ) %>' />
<asp:Literal ID="litSectorID" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionSectorId" ) %>' />
<asp:Literal ID="litSocio" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Id" ) %>' />
<asp:ObjectDataSource ID="odsRepresentates" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="FindAll" TypeName="CamaraComercio.Website.RepresentanteUI"></asp:ObjectDataSource>
<div class="clear">
</div>

<div id="errorbox" style="display:none;">
    <p>
        Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud. Asegúrese de llenar todos los campos marcados con esta notificación. <img src="/res/img/error_icon.gif" width="25" height="25" />
    </p>
</div>

<div class="floatRight socioDetailCargos">
    <p class="title_grid">
                    <span style="float: left">
                    <asp:Literal runat="server" ID="litTipoCargos">Tipos de Cargos</asp:Literal> </span>
                    <label runat="server" id="lblAccionesHeader" style="float: right">
                        Cantidad de Acciones o Cuotas
                    </label>
  </p>

    <asp:Repeater runat="server" ID="rpRepeater" OnItemDataBound="rpRepeater_ItemCreated">
        <HeaderTemplate>
            <fieldset class="form-fieldset">
                <ul id="tblTiposSocios">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:CheckBox ID="chkTipoSocio" runat="server" CssClass="chkSocios" />
                <asp:DropDownList ID="ddlCargoSocios" runat="server" CssClass="dd ddlCargos" AppendDataBoundItems="true">
                    <asp:ListItem Text="Seleccione un cargo" Value="-1" />
                </asp:DropDownList>
                <telerik:RadTextBox ID="txtAcciones" runat="server" CssClass="tb noAcciones" Visible="false"
                    Text='<%#Eval("CantAcciones") %>' Width="130px" EmptyMessage="Acciones">
                </telerik:RadTextBox>
                <asp:HiddenField Value='<%#Eval("TipoSocioId") %>' runat="server" ID="hfTipoSocioId" />
                <asp:HiddenField Value='<%#Eval("GrupoValidacion") %>' runat="server" ID="hfGrupoValidacion" />
            </li>
            <li></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul> </fieldset>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div class="socioDetailMain">
    <asp:MultiView ID="mvDatosGenerales" runat="server" ActiveViewIndex="0">
        <asp:View ID="vSocioPersona" runat="server" OnLoad="vSocioPersona_Load">
            <ul>
                <li>
                    <p class="title_grid">
                        Datos Generales
                    </p>
                </li>
                <li>
                    <label for="ddlTipoDatos">
                        Tipo de datos</label>
                    <asp:DropDownList ID="ddlTipoDatos" runat="server" CssClass="dd widestInput" AutoPostBack="True"
                        ClientIDMode="Static" OnSelectedIndexChanged="ddlTipoDatos_SelectedIndexChanged">
                    </asp:DropDownList>
                </li>
                <li>
                    <label for="ddlNacionalidadPersona">
                        Nacionalidad</label>
                    <asp:DropDownList runat="server" ID="ddlNacionalidadPersona" CssClass="dd widestInput">
                    </asp:DropDownList>
                </li>
                <li>
                    <label for="txtPrimerNombre">
                        Nombre</label>
                    <telerik:RadTextBox ID="txtPrimerNombre" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaPrimerNombre" ) %>'
                        EmptyMessage="Primer Nombre" CssClass="tb" Skin="" MaxLength="30">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server"
                        Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar un nombre'/>" ControlToValidate="txtPrimerNombre" ValidationGroup="socio" />
                    <telerik:RadTextBox ID="txtSegundoNombre" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaSegundoNombre" ) %>'
                        EmptyMessage="Segundo Nombre" CssClass="tb" Skin="" MaxLength="30" />
                </li>
                <li>
                    <label for="txtPrimerApellido">
                        Apellido</label>
                    <telerik:RadTextBox ID="txtPrimerApellido" runat="server" CssClass="tb" EmptyMessage="Primer Apellido"
                        Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaPrimerApellido" ) %>'
                        MaxLength="30" />
                    <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido"
                        Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar un apellido'/>"
                        ValidationGroup="socio" />
                    <telerik:RadTextBox ID="txtSegundoApellido" runat="server" CssClass="tb" EmptyMessage="Segundo Apellido"
                        Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaSegundoApellido" ) %>'
                        MaxLength="30" />
                </li>
                <li>
                    <asp:Label runat="server" ID="lblddTipoDocumento" AssociatedControlID="ddlTipoDocumento">Tipo Documento</asp:Label>
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlTipoDocumento_SelectedIndexChanged"
                        CssClass="dd">
                        <asp:ListItem Value="C">Cédula</asp:ListItem>
                        <asp:ListItem Value="P">Pasaporte</asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <asp:Label runat="server" ID="lbltxtDocumento" AssociatedControlID="txtDocumento">
                        Cédula
                    </asp:Label>
                    <telerik:RadTextBox ID="txtDocumento" runat="server" CssClass="tb commentCtrl" 
                        Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.Documento" ).ToString().RemoverFormato() %>'
                        MaxLength="11" />
                        <div class="comments hiddenObj" id="txtDocumentoComment">
                            Sin guiones ni espacios.
                        </div>
                    <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ControlToValidate="txtDocumento"
                        ErrorMessage="*" ValidationGroup="socio" Display="Dynamic" 
                        Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar un documento de identificación'/>" />
                    <asp:RegularExpressionValidator ID="regexCedula" runat="server" 
                        class="validatorSocios comments"
                        ControlToValidate="txtDocumento" ErrorMessage="Inserte una cédula válida." 
                        ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblEstadoCivil" AssociatedControlID="ddlEstadoCivil">
                        Estado Civil
                    </asp:Label>
                    <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="dd">
                    </asp:DropDownList>
                </li>
            </ul>
            <div class="clear">
            </div>
            <asp:Panel ID="pnlMenorEdad" runat="server" Visible="false">
                <ul>
                    <li>
                        <label for="ddlRepresentante">
                            Representante
                        </label>
                        <asp:DropDownList ID="ddlRepresentante" runat="server" CssClass="dd widestInput"
                            DataSourceID="odsRepresentates" AppendDataBoundItems="true" ClientIDMode="Static"
                            DataTextField="NombreCompleto" DataValueField="PersonaId">
                            <asp:ListItem Text="Seleccione un Representante" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqRepresentante" ControlToValidate="ddlRepresentante"
                            ValidationGroup="socio" ClientIDMode="Static" InitialValue="0" runat="server"
                            Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar un representante'/>" />
                        <br />
                        <asp:HyperLink runat="server" ID="lnkAgregarRepresentantes" ClientIDMode="Static"
                            class="fboxMensajes iframe" NavigateUrl="/Operaciones/Shared/Representantes.aspx"
                            Text="Agregar Representantes" />
                    </li>
                </ul>
            </asp:Panel>
        </asp:View>
        <asp:View ID="vSocioEmpresa" runat="server">
            <ul>
                <li>
                    <p class="title_grid">
                        Datos Generales
                    </p>
                </li>
                <li>
                    <label for="ddlTipoDatosEmpresa">
                        Tipo de datos
                    </label>
                    <asp:DropDownList ID="ddlTipoDatosEmpresa" runat="server" CssClass="dd widestInput"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDatos_SelectedIndexChanged"
                        ClientIDMode="Static">
                    </asp:DropDownList>
                </li>
                <li>
                    <label for="ddlNacionalidadEmpresa">
                        Nacionalidad</label>
                    <asp:DropDownList runat="server" ID="ddlNacionalidadEmpresa" CssClass="dd widestInput">
                    </asp:DropDownList>
                </li>
                <li>
                    <label for="txtEmpresa">
                        Nombre de la empresa</label>
                    <telerik:RadTextBox ID="txtEmpresa" runat="server" CssClass="tb" Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaPrimerNombre" ) %>'
                        MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="txtEmpresa"
                        ValidationGroup="socio"  
                        Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar un nombre'/>"
                        />
                </li>
                <li>
                    <label for="txtDocumentoEmpresa">
                        RNC</label>
                    <telerik:RadTextBox ID="txtDocumentoEmpresa" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Documento" ) %>'
                        CssClass="tb commentCtrl" Skin="" MaxLength="9" />
                        <div class="comments hiddenObj" id="txtDocumentoEmpresaComment">
                            Sin guiones ni espacios
                        </div>
                    <asp:RegularExpressionValidator ID="regexRnc" runat="server" ControlToValidate="txtDocumentoEmpresa"
                        CssClass="validator" Display="Dynamic" ErrorMessage="Inserte un RNC válido."
                        Text="Inserte un RNC válido." ValidationExpression="^\d{9,}" 
                        Class="validatorSocios"
                        ValidationGroup="socio"></asp:RegularExpressionValidator>
                </li>
                <li>
                    <label for="txtRegistroMercantilEmpresa">
                        Registro Mercantil</label>
                    <telerik:RadTextBox ID="txtRegistroMercantilEmpresa" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.RegistroMercantil" ) %>'
                        CssClass="tb" Skin="" MaxLength="15" />
                </li>
            </ul>
            <ul id="empresaRepresentante">
                <li>
                    <label for="ddlRepresentanteEmpresa">
                        Representante</label>
                    <asp:DropDownList ID="ddlRepresentanteEmpresa" runat="server" CssClass="dd widestInput"
                        DataSourceID="odsRepresentates" AppendDataBoundItems="true" DataTextField="NombreCompleto"
                        DataValueField="PersonaId" ClientIDMode="Static">
                        <asp:ListItem Text="Seleccione un Representante" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqRepresentanteEmpresa" ControlToValidate="ddlRepresentanteEmpresa"
                        InitialValue="0" runat="server" 
                        Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar un representante'/>" />
                    <br />
                    <asp:HyperLink runat="server" ID="lnkRepresentanteEmpresa" ClientIDMode="Static"
                        CssClass="fboxMensajes iframe" NavigateUrl="/Operaciones/Shared/Representantes.aspx"
                        Text="Agregar Representantes" />
                </li>
            </ul>
        </asp:View>
        <asp:View ID="vSocioPortador" runat="server">
            <ul>
                <li>
                    <p class="title_grid">
                        Datos Generales
                    </p>
                </li>
                <li>
                    <asp:Label ID="lblddlTipoDatosPortador" runat="server" AssociatedControlID="ddlTipoDatosPortador">
                        Tipo de Datos
                    </asp:Label>
                    <asp:DropDownList ID="ddlTipoDatosPortador" runat="server" CssClass="dd" AutoPostBack="True"
                        ClientIDMode="Static" OnSelectedIndexChanged="ddlTipoDatos_SelectedIndexChanged">
                    </asp:DropDownList>
                </li>
            </ul>
            <p>&nbsp;
                
            </p>
            <div class="clear" />
        </asp:View>
    </asp:MultiView>
    <asp:Panel runat="server" ID="pnlDireccion">
        <ul>
            <li>
                <p class="title_grid">
                    Datos de Dirección
                </p>
            </li>
            <li>
                <label for="ddlCiudades">
                    Ciudad:
                </label>
                <asp:DropDownList ID="ddlCiudades" runat="server" AutoPostBack="True" CssClass="dd widestInput">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlCiudades" ControlToValidate="ddlCiudades" InitialValue="0"
                    runat="server" ValidationGroup="socio" 
                    Text="<img src='/res/img/icons/error_icon.gif' title'Debe seleccionar una ciudad'/>"
                    />
            </li>
            <li>
                <label for="ddlSectores">
                    Sector</label>
                <asp:DropDownList ID="ddlSectores" runat="server" DataSourceID="odsSectores" DataTextField="Nombre"
                    DataValueField="SectorId" CssClass="dd widestInput">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlSectores" ControlToValidate="ddlSectores" InitialValue="0"
                    runat="server" ValidationGroup="socio" 
                    Text="<img src='/res/img/icons/error_icon.gif' title'Debe seleccionar un sector'/>"
                    />
            </li>
            <li>
                <label for="txtCalle">
                    Calle</label>
                <telerik:RadTextBox ID="txtCalle" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionCalle" ) %>'
                    CssClass="tb widestInput" Skin="" MaxLength="250" />
                <asp:RequiredFieldValidator ID="rfvtxtCalle" ControlToValidate="txtCalle" 
                    runat="server" ValidationGroup="socio" 
                    Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar la dirección'/>"                    
                    />
            </li>
            <li>
                <label for="txtNumero">
                    Número</label>
                <telerik:RadTextBox ID="txtNumero" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionNumero" ) %>'
                    CssClass="tb widestInput" Skin="" MaxLength="10" />
                <asp:RequiredFieldValidator ID="rfvtxtNumero" ControlToValidate="txtNumero" 
                    runat="server" ValidationGroup="socio" 
                    Text="<img src='/res/img/icons/error_icon.gif' title'Debe especificar el número de la dirección'/>"
                    />
            </li>
            <li>
                <label for="txtApartadoPostal">
                    Apartado Postal</label>
                <telerik:RadTextBox ID="txtApartadoPostal" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionApartadoPostal" ) %>'
                    CssClass="tb widestInput" Skin="" MaxLength="20" />
                <asp:RegularExpressionValidator ID="regexCodigoPostal" runat="server" 
                    ControlToValidate="txtApartadoPostal" ValidationExpression="^\d+$"
                    Text="&lt;img src='/res/img/icons/error_icon.gif' title'Debe especificar el número de la dirección'/&gt; <br/>El código portal debe ser numérico." 
                    ValidationGroup="socio" />
            </li>
        </ul>
    </asp:Panel>
</div>
<div class="footer_go">
    <asp:LinkButton ID="btnUpdate" Text="Actualizar" runat="server" CommandName="Update"
        Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' ValidationGroup="socio"
        CssClass="btn"></asp:LinkButton>
    <asp:LinkButton ID="btnInsert" Text="Insertar" runat="server" CommandName="PerformInsert"
        Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>' ValidationGroup="socio"
        CssClass="btn">Añadir</asp:LinkButton>
    <asp:LinkButton ID="btnCancel" Text="Cancelar" runat="server" CausesValidation="False"
        CommandName="Cancel" CssClass="btn">Cancelar</asp:LinkButton>
    <div class="clear" />
</div>
<div class="clear">
</div>
<asp:ObjectDataSource ID="odsSectores" runat="server" SelectMethod="FetchByCiudad"
    TypeName="CamaraComercio.DataAccess.EF.CamaraComun.SectoresRepository">
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlCiudades" Name="ciudadId" PropertyName="SelectedValue"
            Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
