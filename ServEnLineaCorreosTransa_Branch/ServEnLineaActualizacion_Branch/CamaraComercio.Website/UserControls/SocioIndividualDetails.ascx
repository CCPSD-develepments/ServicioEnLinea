<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocioIndividualDetails.ascx.cs"
    Inherits="CamaraComercio.Website.UserControls.SocioIndividualDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--Metodo bastardo para obtener informacion que 
            condiciona el behavior del form en modo de edicion,
            PHP & asp 3.0 style! --%>
<asp:Literal ID="litTipoDocumento" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.TipoDocumento" ) %>' />
<asp:Literal ID="litAdmin" Visible="False" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.TipoRelacion" ) %>' />
<asp:Literal ID="litCiudadID" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionCiudadId" ) %>' />
<asp:Literal ID="litSectorID" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionSectorId" ) %>' />
<asp:MultiView ID="mvDatosGenerales" runat="server" ActiveViewIndex="0">
    <asp:View ID="vSocioPersona" runat="server">
        <ul>
            <li>
                <p class="title_grid">
                    Datos Generales
                </p>
            </li>
            <li>
                <label for="ddlTipoDatos">
                    Tipo de datos</label>
                <asp:DropDownList ID="ddlTipoDatos" runat="server" CssClass="dd" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlTipoDatos_SelectedIndexChanged">
                    <asp:ListItem>Persona</asp:ListItem>
                    <asp:ListItem>Empresa</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label for="txtPrimerNombre">
                    Nombre:</label>
                <telerik:RadTextBox ID="txtPrimerNombre" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaPrimerNombre" ) %>'
                    EmptyMessage="Primer Nombre" CssClass="tb" Skin="" MaxLength="30">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ErrorMessage="*"
                    Text="*" ControlToValidate="txtPrimerNombre" ValidationGroup="socio"></asp:RequiredFieldValidator>
                <telerik:RadTextBox ID="txtSegundoNombre" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaSegundoNombre" ) %>'
                    EmptyMessage="Segundo Nombre" CssClass="tb" Skin="" MaxLength="30" />
            </li>
            <li>
                <label for="txtPrimerApellido">
                    Apellido:</label>
                <telerik:RadTextBox ID="txtPrimerApellido" runat="server" CssClass="tb" EmptyMessage="Primer Apellido"
                    Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaPrimerApellido" ) %>'
                    MaxLength="30" />
                <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido"
                    ErrorMessage="*" ValidationGroup="socio" Text="*"></asp:RequiredFieldValidator>
                <telerik:RadTextBox ID="txtSegundoApellido" runat="server" CssClass="tb" EmptyMessage="Segundo Apellido"
                    Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaSegundoApellido" ) %>'
                    MaxLength="30" />
            </li>
            <li>
                <label for="ddlTipoDocumento">
                    Tipo Documento:</label>
                <asp:DropDownList ID="ddlTipoDocumento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDocumento_SelectedIndexChanged"
                    CssClass="dd">
                    <asp:ListItem Value="C">Cédula</asp:ListItem>
                    <asp:ListItem Value="P">Pasaporte</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label for="txtDocumento">
                    <asp:Literal ID="txtTitleDocumento" runat="server" Text="Cédula"></asp:Literal>
                </label>
                <telerik:RadTextBox ID="txtDocumento" runat="server" CssClass="tb" Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.Documento" ) %>'
                    MaxLength="11" />
                <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ControlToValidate="txtDocumento"
                    ErrorMessage="*" ValidationGroup="socio" Display="Dynamic">*</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="regexCedula" runat="server" ErrorMessage="Inserte una cédula válida."
                    Text="Inserte una cédula válida." ValidationGroup="socio" ControlToValidate="txtDocumento"
                    Display="Dynamic" ValidationExpression="[0-9\-]*" CssClass="validator"></asp:RegularExpressionValidator>
            </li>
            <li>
                <label for="ddlEstadoCivil">
                    Estado Civil:</label>
                <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="dd">
                </asp:DropDownList>
            </li>
        </ul>
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
                    Tipo de datos</label>
                <asp:DropDownList ID="ddlTipoDatosEmpresa" runat="server" CssClass="dd" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlTipoDatosEmpresa_SelectedIndexChanged">
                    <asp:ListItem>Persona</asp:ListItem>
                    <asp:ListItem>Empresa</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label for="txtEmpresa">
                    Nombre de la Empresa</label>
                <telerik:RadTextBox ID="txtEmpresa" runat="server" CssClass="tb" Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PersonaPrimerNombre" ) %>'
                    MaxLength="30" />
                <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="txtEmpresa"
                    ErrorMessage="*" ValidationGroup="socio">*</asp:RequiredFieldValidator>
            </li>
            <li>
                <label for="txtDocumentoEmpresa">
                    RNC:</label>
                <telerik:RadTextBox ID="txtDocumentoEmpresa" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Documento" ) %>'
                    CssClass="tb" Skin="" MaxLength="9" />
                <asp:RequiredFieldValidator ID="rfvRNC" runat="server" ControlToValidate="txtDocumentoEmpresa"
                    ErrorMessage="*" ValidationGroup="socio">*</asp:RequiredFieldValidator>
            </li>
            <li>
                <label for="txtRegistromercantilEmpresa">
                    Registro Mercantil:</label>
                <telerik:RadTextBox ID="txtRegistroMercantilEmpresa" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.RegistroMercantil" ) %>'
                    CssClass="tb" Skin="" MaxLength="10" />
            </li>
        </ul>
    </asp:View>
</asp:MultiView>
<ul>
    <li>
        <label for="chlTiposSocios">
        </label>
        <asp:CheckBoxList runat="server" ID="chlTiposSocios">
        </asp:CheckBoxList>
    </li>
    <li>
        <p class="title_grid">
            Datos de Dirección
        </p>
    </li>
    <li>
        <label for="ddlCiudades">
            Ciudad:</label>
        <asp:DropDownList ID="ddlCiudades" runat="server" AutoPostBack="True"
            CssClass="dd">
        </asp:DropDownList>
    </li>
    <li>
        <label for="ddlSectores">
            Sector:</label>
        <asp:DropDownList ID="ddlSectores" runat="server" DataSourceID="odsSectores"
            DataTextField="Nombre" DataValueField="SectorId" CssClass="dd">
        </asp:DropDownList>
    </li>
    <li>
        <label for="txtCalle">
            Calle:</label>
        <telerik:RadTextBox ID="txtCalle" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionCalle" ) %>'
            CssClass="tb" Skin="" MaxLength="256" />
    </li>
    <li>
        <label for="txtNumero">
            Número:</label>
        <telerik:RadTextBox ID="txtNumero" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionNumero" ) %>'
            CssClass="tb" Skin="" MaxLength="6" />
    </li>
    <li>
        <label for="txtApartadoPostal">
            Apartado Postal:</label>
        <telerik:RadTextBox ID="txtApartadoPostal" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionApartadoPostal" ) %>'
            CssClass="tb" Skin="" MaxLength="20" />
        <asp:DropDownList ID="ddlRepresentante" runat="server" CssClass="dd" AppendDataBoundItems="true"
            ClientIDMode="Static" DataTextField="NombreCompleto" Visible="false" DataValueField="PersonaId">
            <asp:ListItem Text="No Aplica" Value="0" Selected="True"></asp:ListItem>
        </asp:DropDownList>
    </li>
</ul>
<div style="text-align: right">
    <asp:LinkButton ID="btnUpdate" Text="Actualizar" runat="server" CommandName="Update"
        Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' ValidationGroup="socio"
        CssClass="btn"></asp:LinkButton>
    <asp:LinkButton ID="btnInsert" Text="Insertar" runat="server" CommandName="PerformInsert"
        Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>' ValidationGroup="socio"
        CssClass="btn">Insertar</asp:LinkButton>
    <asp:LinkButton ID="btnCancel" Text="Cancelar" runat="server" CausesValidation="False"
        CommandName="Cancel" CssClass="btn">Cancelar</asp:LinkButton>
</div>
<div class="clear">
</div>
<asp:ObjectDataSource ID="odsSectores" runat="server" SelectMethod="FetchByCiudad"
    TypeName="CamaraComercio.DataAccess.EF.CamaraComun.SectoresRepository">
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlCiudades" Name="ciudadId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<div class="clear">
</div>
