<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SucursalesDetails.ascx.cs" Inherits="CamaraComercio.Website.UserControls.SucursalesDetails" %>
<%@ Import Namespace="CamaraComercio.Website" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel runat="server" ID="pnlDireccion">
        <ul>
            <li>
                <label for="txtDescripcion">Descripción</label>
                <asp:TextBox runat="server" id="txtDescripcion" ClientIDMode="Static"/>
            </li>
            <li>
                <label for="ddlCiudades">
                    Ciudad
                </label>
                <asp:DropDownList ID="ddlCiudades" runat="server" AutoPostBack="True" CssClass="dd widestInput">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlCiudades" ControlToValidate="ddlCiudades" InitialValue="0"
                    CssClass="validator" runat="server" ErrorMessage="*" ValidationGroup="socio" />
            </li>
            <li>
                <label for="ddlSectores">
                    Sector</label>
                <asp:DropDownList ID="ddlSectores" runat="server" DataSourceID="odsSectores" DataTextField="Nombre"
                    DataValueField="SectorId" CssClass="dd widestInput">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlSectores" ControlToValidate="ddlSectores" InitialValue="0"
                    CssClass="validator" runat="server" ErrorMessage="*" ValidationGroup="socio" />
            </li>
            <li>
                <label for="txtCalle">
                    Calle</label>
                <telerik:RadTextBox ID="txtCalle" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionCalle" ) %>'
                    CssClass="tb widestInput" Skin="" MaxLength="250" />
                <asp:RequiredFieldValidator ID="rfvtxtCalle" ControlToValidate="txtCalle" CssClass="validator"
                    runat="server" ErrorMessage="*" ValidationGroup="socio" />
            </li>
            <li>
                <label for="txtNumero">
                    Número</label>
                <telerik:RadTextBox ID="txtNumero" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionNumero" ) %>'
                    CssClass="tb widestInput" Skin="" MaxLength="10" />
                <asp:RequiredFieldValidator ID="rfvtxtNumero" ControlToValidate="txtNumero" CssClass="validator"
                    runat="server" ErrorMessage="*" ValidationGroup="socio" />
            </li>
            <li>
                <label for="txtApartadoPostal">
                    Apartado Postal</label>
                <telerik:RadTextBox ID="txtApartadoPostal" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.DireccionApartadoPostal" ) %>'
                    CssClass="tb widestInput" Skin="" MaxLength="20" />
            </li>
            <li>
                <label for="txtTelefono">Teléfono</label>
                <asp:TextBox runat="server" id="txtTelefono" ClientIDMode="Static"/>
            </li>
            <li>
                <label for="txtEmail">E-mail</label>
                <asp:TextBox runat="server" id="txtEmail" ClientIDMode="Static"/>
                <asp:RegularExpressionValidator runat="server" ID="regexMail" ControlToValidate="txtEmail"
                CssClass="validator" Text="Correo inválido" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
            </li>
        </ul>
    </asp:Panel>

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