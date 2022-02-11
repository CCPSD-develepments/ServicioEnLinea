<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/res/noboxForm.Master" CodeBehind="Certificacion.aspx.cs" Inherits="CamaraComercio.Website.Formularios.Certificacion" %>

<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <!-- CSS -->
                <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
                <link href="/res/js/fbLabel/LabelList.css" rel="stylesheet" type="text/css" />
                <link href="/res/js/fbLabel/LabelList.Autocomplete.css" rel="stylesheet" type="text/css" />
                <link href="/res/lib/chosen/chosen.min.css" rel="stylesheet" type="text/css" />
                <style type="text/css">
                    .search-choice > span,
                    .chosen-results > li {
                        font-size: 10px;
                    }
                </style>
                <div>

                    <h1 id="detalles">FORMULARIO DE SOLICITUD DE SERVICIOS
                    </h1>

                </div>
            </div>
            <div id="content_body">
                <asp:MultiView runat="server" ID="mainMultiView" ActiveViewIndex="0">
                    <asp:View runat="server" ID="succesfullView">
                        <fieldset class="form-fieldset">
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center">SERVICIOS</h4>
                            <div id="servicio" class="RadGrid RadGrid_NoboxGrid" style="padding: 2px">
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <asp:Label ID="lbServicio" Text="SERVICIO: " AssociatedControlID="txtServicio" runat="server" Font-Size="14px" Height="21px" Width="212px"></asp:Label>
                                        <asp:Label ID="txtServicio" CssClass="tb" runat="server" Height="16px" Width="702px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbCantidad" Text="CANTIDAD: " AssociatedControlID="txtcantidadServicio" runat="server" Font-Size="14px" Height="21px" Width="212px"></asp:Label>
                                        <asp:Label ID="txtcantidadServicio" Text="" CssClass="tb" runat="server" Height="16px" ReadOnly="True" Width="313px"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center">DATOS DEL GESTOR</h4>
                            <div id="gestorData" class="RadGrid RadGrid_NoboxGrid">
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <asp:Label ID="lbNombreQuien" Text="A NOMBRE DE:" AssociatedControlID="txtSolicitante" runat="server"></asp:Label>
                                        <asp:Label ID="txtNombreQuien" runat="server" style="text-transform:uppercase" ReadOnly="True" CssClass="tb" Height="16px" Width="250px"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbDocumentoNombreQuien" Text="RNC/CEDULA: " AssociatedControlID="txtSolicitante" runat="server"></asp:Label>
                                        <asp:Label ID="txtDocumentoNombreQuien" runat="server" ReadOnly="True" CssClass="tb" Height="16px" Width="250px"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbSolicitante" Text="SOLICITANTE:" AssociatedControlID="txtSolicitante" runat="server"></asp:Label>
                                        <asp:Label ID="txtSolicitante" Text="" runat="server" ReadOnly="True" style="text-transform:uppercase" CssClass="tb" Height="16px" Width="250px"></asp:Label>
                                        <br />
                                        <br />
                                    </li>

                                    <li>
                                        <asp:Label ID="lbNombreCont" Text="NOMBRE DE LA PERSONA DE CONTACTO: " AssociatedControlID="txtNombreCont" runat="server"></asp:Label>
                                        <asp:Label ID="txtNombreCont" Text="" runat="server" ReadOnly="True" style="text-transform:uppercase" CssClass="tb" Height="16px" Width="200px"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbCedula" Text="CÉDULA DE CONTACTO: " AssociatedControlID="txtCedula" runat="server"></asp:Label>
                                        <asp:Label ID="txtCedula" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbEmail" Text="CORREO ELECTRÓNICO:" AssociatedControlID="txtEmail" runat="server"></asp:Label>
                                        <asp:Label ID="txtEmail" runat="server" CssClass="tb" Height="16px" Width="250px" ReadOnly="True"></asp:Label>
                                        <br />

                                        <br />
                                    </li>
                                    
                                    <li>
                                        <asp:Label ID="lbTelefono" Text="TELÉFONO: " AssociatedControlID="txtTelefono" runat="server"></asp:Label>
                                        <asp:Label ID="txtTelefono" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbIDepositarCansilleria" Text="DEPOSITADOS EN CANCILLERÍA:" AssociatedControlID="txtTelefono" runat="server"></asp:Label>
                                        <asp:Label ID="txtIDepositarCansilleria" Text="" style="text-transform:uppercase" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>

                                     <li>
                                        <asp:Label ID="Label1" Text="TIPO DE ENTREGA:" AssociatedControlID="txtTelefono" runat="server"></asp:Label>
                                        <asp:Label ID="txtentregadigital" Text="" style="text-transform:uppercase" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>


                                </ul>
                            </div>
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center" id="encabezadoDatosSociedad" runat="server" visible="true">DATOS DE LA SOCIEDAD</h4>
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center" id="encabezadoDatosPF" runat="server" 
                                visible="false" >DATOS DE LA PERSONA FISICA </h4>
                            <div id="sociedadData" class="RadGrid RadGrid_NoboxGrid">
                                <br />
                                <br />
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <asp:Label ID="lbRazSocial" Text="RAZÓN SOCIAL: " AssociatedControlID="txtRazSocial" runat="server" Visible="true"></asp:Label>
                                        <asp:Label ID="lblNombreCompleto" Text="NOMBRE COMPLETO: " AssociatedControlID="txtRazSocial" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="txtRazSocial" Text="" runat="server" CssClass="tb" Height="16px" Width="280px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNoRegistro" Text="REGISTRO NO:" AssociatedControlID="txtNoRegistro" runat="server"></asp:Label>
                                        <asp:Label ID="txtNoRegistro" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbRNCSociedad" Text="RNC SOCIEDAD  " AssociatedControlID="txtRNCSoc" runat="server"></asp:Label>
                                        <asp:Label ID="lblRncPersona" Text="RNC SOCIEDAD RNC PERSONA:" AssociatedControlID="txtRNCSoc" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="txtRNCSoc" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <div runat="server" id="wrapComentario" visible="true">
                                <h4 style="align-content: center; height: 2px; font-size: large;" align="center">COMENTARIO</h4>
                                <div id="Comentario" class="RadGrid RadGrid_NoboxGrid" style="padding: 2px">
                                    <ul style="padding-left: 5px; padding-top: 5px">
                                        <li>
                                            <asp:Label ID="lblComentario" Text="COMENTARIO:" runat="server" Font-Size="14px" Height="21px" Width="212px"></asp:Label>
                                            <%--<asp:Label ID="txtComentario" Text="" CssClass="tb" runat="server" Height="16px" Width="313px" ReadOnly="True"></asp:Label>--%>
                                            <asp:TextBox runat="server" ID="txtComentario" Width="95%" Height="100%"  ClientIDMode="Static" 
                                                style="resize:none; overflow:hidden;" BorderColor="White" BorderStyle="None" Enabled="False"
                                                ReadOnly="True" />
                                        </li>
                                    </ul>
                                </div>

                            </div>
                        </fieldset>
                    </asp:View>
                    <asp:View runat="server" ID="failView">
                        <div class="sectDetailBlue">
                            <h2 id="txtMessageTitle" runat="server"></h2>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        # ocie
        adData {
            width: 918px;
        }
    </style>
</asp:Content>
