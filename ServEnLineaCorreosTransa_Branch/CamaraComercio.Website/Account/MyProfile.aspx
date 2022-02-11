<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="MyProfile.aspx.cs" Inherits="CamaraComercio.Website.Account.MyProfile" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        fieldset {
            padding: 10px;
        }

            fieldset legend {
                font-size: small;
                font-weight: bold;
            }

            fieldset label {
                display: inline-block;
                font-weight: bold;
                width: 150px;
                margin-right: 8px;
            }

            fieldset hr {
                margin: 10px 0px;
            }

        .inputField {
            width: 175px;
        }
    </style>
    <script src="/res/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //called when key is pressed in textbox
            $('#txtRNC').keypress(function (e) {
                //if the letter is not digit then display error and don't type anything
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    //display error message
                    //$(""#errmsg"").html(""Digits Only"").show().fadeOut(""slow"");
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1 id="creacion">Mi Perfil</h1>
                </div>
                <div id="content_body">
                    <asp:ValidationSummary ID="vSummary" runat="server" />
                    <br />
                    <fieldset>
                        <div style="width: 400px">
                            <br />
                            <label for="lblUsuario">
                                Usuario:</label>
                            <asp:TextBox ID="txtUsuario" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="lblUsuario" runat="server" Text="N/A" CssClass="inputField"></asp:Label>--%>
                            <br />
                            <br />
                            <label for="txtNombre">
                                Nombre Completo:</label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                Display="Dynamic" ErrorMessage="El nombre es requerido." Text="*"></asp:RequiredFieldValidator>
                            <hr />
                            <label for="lblEmail">
                                Correro Electrónico:</label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                Display="Dynamic" ErrorMessage="El correo electrónico es requerido." Text="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" runat="server"
                                ErrorMessage="El correo electrónico tiene el formato incorrecto." Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="cvEmail" runat="server" Text="*" ErrorMessage="El correo electrónico ya existe, intente con otro."
                                ControlToValidate="txtEmail" OnServerValidate="cvEmail_ServerValidate"></asp:CustomValidator>
                            <%-- <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>--%>
                            <hr />
                            <label for="ddlTipoDocumento">
                                Tipo de Documento:</label>
                            <%--<asp:Label ID="lblTipoDocumento" runat="server" Text=""></asp:Label>--%>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                                <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                                <asp:ListItem Text="Cedula" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Pasaporte" Value="P"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server" InitialValue="Seleccione"
                                ControlToValidate="ddlTipoDocumento" Display="Dynamic" ErrorMessage="El tipo de documento es requerido."
                                Text="*"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <label for="txtNoDocumento">
                                No. Documento:</label>
                            <%-- <asp:Label ID="lblNoDocumento" runat="server" Text=""></asp:Label>--%>
                            <asp:TextBox ID="txtNoDocumento" runat="server" MaxLength="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNoDocumento" runat="server" ControlToValidate="txtNoDocumento"
                                Display="Dynamic" ErrorMessage="El número de documento es requerido." Text="*"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvNoDocumento" runat="server" ControlToValidate="txtNoDocumento"
                                Text="*" ErrorMessage="Cédula debe ser solo números sin guiones ni espacios."
                                OnServerValidate="cvNoDocumento_ServerValidate"></asp:CustomValidator>
                            <br />
                            <hr />
                            <div id="divEmpresa" runat="server">
                                <label for="txtEmpresa">
                                    Nombre Emrpesa:</label>
                                <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="txtEmpresa"
                                    Display="Dynamic" ErrorMessage="El nombre de la empresa es requerido." Text="*"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                <label for="txtRNC">
                                    RNC:</label>
                                <asp:TextBox ID="txtRNC" ClientIDMode="Static" runat="server" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRNC" runat="server" ControlToValidate="txtRNC"
                                    Display="Dynamic" ErrorMessage="El RNC de la empresa es requerido." Text="*"></asp:RequiredFieldValidator>
                                <hr />
                            </div>
                            <div class="footer_go" __designer:mapid="ba8" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" CssClass="btn" />
                                <asp:Label ID="lblResultado" ForeColor="Green" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
