<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepresentanteDetails.ascx.cs"
    Inherits="CamaraComercio.Website.UserControls.RepresentanteDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table cellspacing="2" cellpadding="1" width="100%" border="1" rules="none" style="border-collapse: collapse">
    <tr>
        <td>
            <asp:Literal ID="litTipoDocumento" Visible="false" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.TipoDocumento" ) %>' />
            <asp:MultiView ID="mvDatosGenerales" runat="server" ActiveViewIndex="0">
                <asp:View ID="vSocioPersona" runat="server">
                    <h1>Datos Generales</h1>
                    <fieldset class="form-fieldset">
                        <ul>
                            <li>
                                <asp:Label runat="server" ID="lbltxtPrimerNombre" AssociatedControlID="txtPrimerNombre">
                                    Nombres: 
                                </asp:Label>
                                <telerik:RadTextBox ID="txtPrimerNombre" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.PrimerNombre" ) %>'
                                    EmptyMessage="Primer Nombre" CssClass="tb" Skin="" MaxLength="30">
                                </telerik:RadTextBox>
                                <telerik:RadTextBox ID="txtSegundoNombre" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.SegundoNombre" ) %>'
                                    EmptyMessage="Segundo Nombre" CssClass="tb" Skin="" />
                                <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ErrorMessage="*"
                                    Text="*" ControlToValidate="txtPrimerNombre" ValidationGroup="socio" CssClass="validator"></asp:RequiredFieldValidator>
                            </li>

                            <li>
                                <asp:Label runat="server" ID="lbltxtPrimerApellido" AssociatedControlID="txtPrimerApellido">
                                    Apellidos:
                                </asp:Label>

                                <telerik:RadTextBox ID="txtPrimerApellido" runat="server" CssClass="tb" EmptyMessage="Primer Apellido"
                                    Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.PrimerApellido" ) %>'
                                    MaxLength="30" />
                                <telerik:RadTextBox ID="txtSegundoApellido" runat="server" CssClass="tb" EmptyMessage="Segundo Apellido"
                                Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.SegundoApellido" ) %>'
                                MaxLength="30" />

                                <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido"
                                    ErrorMessage="*" ValidationGroup="socio" Text="*" CssClass="validator"></asp:RequiredFieldValidator>
                            </li>

                            <li>
                                 <asp:Label runat="server" ID="lblddlTipoDocumento" AssociatedControlID="ddlTipoDocumento">
                                    Tipo Documento:
                                 </asp:Label>

                                 <asp:DropDownList ID="ddlTipoDocumento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDocumento_SelectedIndexChanged"
                                    CssClass="dd">
                                    <asp:ListItem Value="C">Cédula</asp:ListItem>
                                    <asp:ListItem Value="P">Pasaporte</asp:ListItem>
                                </asp:DropDownList>
                            </li>

                            <li>
                                <asp:Label runat="server" ID="txtTitleDocumento" 
                                    AssociatedControlID="txtDocumento" Text="Cédula" />
                                                                
                                <telerik:RadTextBox ID="txtDocumento" runat="server" CssClass="tb" Skin="" Text='<%# DataBinder.Eval( Container, "DataItem.Documento" ) %>'
                                    MaxLength="11" />
                                <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ControlToValidate="txtDocumento"
                                    ErrorMessage="*" ValidationGroup="socio" Display="Dynamic" CssClass="validator">*</asp:RequiredFieldValidator>
                                &nbsp;<asp:RegularExpressionValidator ID="regexCedula" runat="server" ErrorMessage="Inserte una cédula válida."
                                    Text="Inserte una cédula válida." ValidationGroup="socio" ControlToValidate="txtDocumento"
                                    Display="Dynamic" ValidationExpression="[0-9\-]*" CssClass="validator"></asp:RegularExpressionValidator>
                            </li>

                            <li>
                                <asp:Label runat="server" AssociatedControlID="ddlEstadoCivil" ID="lblddlEstadoCivil">
                                    Estado Civil:
                                </asp:Label>

                                <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="dd">
                                </asp:DropDownList>
                            </li>
                        </ul>
                    </fieldset>

                </asp:View>
            </asp:MultiView>
        </td>
        <tr>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </tr>
    <tr>
        <td align="right">
            <asp:LinkButton ID="btnUpdate" Text="Actualizar" runat="server" CommandName="Update"
                Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' ValidationGroup="socio"
                CssClass="btn"></asp:LinkButton>
            <asp:LinkButton ID="btnInsert" Text="Insertar" runat="server" CommandName="PerformInsert"
                Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>' ValidationGroup="socio"
                CssClass="btn">Insertar</asp:LinkButton>
            <asp:LinkButton ID="btnCancel" Text="Cancelar" runat="server" CausesValidation="False"
                CommandName="Cancel" CssClass="btn">Cancelar</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;
        </td>
    </tr>
</table>
