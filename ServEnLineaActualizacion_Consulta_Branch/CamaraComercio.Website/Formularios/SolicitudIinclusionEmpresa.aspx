<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/res/noboxForm.Master" CodeBehind="SolicitudIinclusionEmpresa.aspx.cs" Inherits="CamaraComercio.Website.Formularios.SolicitudIinclusionEmpresa" %>

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
                    li{
                        min-height:17px;
                        height:auto;
                    }
                    #over{
                        min-height:15px; height:auto;
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
                                        <asp:Label ID="txtServicio" Text="" CssClass="tb over" runat="server"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </li>
                                </ul>
                            </div>
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center">CONFIRMACIÓN DATOS</h4>
                            <div id="datosGenerales" class="RadGrid RadGrid_NoboxGrid">
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <label>
                                            CÁMARA</label>
                                        <asp:Label ID="lblCamara" runat="server" ClientIDMode="Static" />
                                    </li>
                                    <li>
                                        <label for="lblEmpresa">
                                            DENOMINACIÓN/RAZÓN SOCIAL</label>
                                        <asp:Label ID="lblEmpresa" runat="server" CssClass="over" ClientIDMode="Static" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="lblTipoEmpresa" ID="titlelblTipoEmpresa">TIPO SOCIETARIO</asp:Label>
                                        <asp:Label ID="lblTipoEmpresa" runat="server" ClientIDMode="Static" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="lblNoRegistro" ID="titlelblNoRegistro">NO. REGISTRO</asp:Label>
                                        <asp:Label ID="lblNoRegistro" runat="server" ClientIDMode="Static" />
                                    </li>
                                    <li>
                                        <label for="lblFechaRecepcion">
                                            FECHA DE SOLICITUD</label>
                                        <asp:Label ID="lblFechaRecepcion" runat="server" ClientIDMode="Static" />
                                    </li>
                                    <li>
                                        <label for="lblTransaccion">
                                            NO. SOLICITUD</label>
                                        <asp:Label ID="lblTransaccion" runat="server" ClientIDMode="Static" />
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center">DATOS DEL GESTOR</h4>
                            <div id="gestorData" class="RadGrid RadGrid_NoboxGrid">
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <asp:Label ID="lbSolicitante" Text="SOLICITANTE: " AssociatedControlID="txtSolicitante" runat="server"></asp:Label>
                                        <asp:Label ID="txtSolicitante" Text="" runat="server" ReadOnly="True" CssClass="tb" Height="16px" Width="250px"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbCedula" Text="CÉDULA DEL SOLICITANTE: " AssociatedControlID="txtCedula" runat="server"></asp:Label>
                                        <asp:Label ID="txtCedula" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbEmail" Text="CORREO ELECTRÓNICO: " AssociatedControlID="txtEmail" runat="server"></asp:Label>
                                        <asp:Label ID="txtEmail" runat="server" CssClass="tb" Height="16px" Width="250px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNombreCont" Text="NOMBRE DE LA PERSONA DE CONTACTO: " AssociatedControlID="txtNombreCont" runat="server"></asp:Label>
                                        <asp:Label ID="txtNombreCont" Text="" runat="server" ReadOnly="True" CssClass="tb" Height="16px" Width="200px"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbTelefono" Text="TELÉFONO: " AssociatedControlID="txtTelefono" runat="server"></asp:Label>
                                        <asp:Label ID="txtTelefono" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                </ul>
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
