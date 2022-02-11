<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/res/noboxForm.Master" CodeBehind="PersonaFisica.aspx.cs" Inherits="CamaraComercio.Website.Formularios.PersonaFisica" %>
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

                    .lbTipoSociedad {
                        background-color: #fafafa;
                        margin: 1rem;
                        padding: 1rem;
                        border: 2px solid #ccc;
                        /* IMPORTANTE */
                        text-align: center;
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
                            <div id="servicio" class="RadGrid RadGrid_NoboxGrid" style="padding:2px">

                                <br />
                                    <asp:Label ID="Label1" Text="SERVICIO: " AssociatedControlID="txtServicio" runat="server" Font-Size="14px" Height="21px" Width="212px"></asp:Label>
                                    <asp:Label ID="txtServicio" CssClass="tb over" runat="server" Width="703px" ReadOnly="True" AssociatedControlID="txtServicio"></asp:Label>
                                <br />
                                <br />
                                <br />

                            </div>
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center">DATOS GENERALES</h4>
                            <div id="gestorData" class="RadGrid RadGrid_NoboxGrid">
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <%--<li>
                                        <asp:Label ID="lbSolicitante" Text="SOLICITANTE: " AssociatedControlID="txtSolicitante" runat="server"></asp:Label>
                                        <asp:Label ID="txtSolicitante" Text="" runat="server" ReadOnly="True" CssClass="tb over" Width="70%"></asp:Label>
                                        <br />
                                        <br />
                                    </li>--%>
                                    <li>
                                        <asp:Label ID="lbNombreCont" Text="SOLICITANTE Y/O NOMBRE DE LA PERSONA DE CONTACTO: " AssociatedControlID="txtNombreCont" runat="server"></asp:Label>
                                        <asp:Label ID="txtNombreCont" Text="" runat="server" ReadOnly="True" CssClass="tb over" Width="70%"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbCedula" Text="CÉDULA DE CONTACTO: " AssociatedControlID="txtCedula" runat="server"></asp:Label>
                                        <asp:Label ID="txtCedula" Text="" runat="server" CssClass="tb over" Height="70%" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbEmail" Text="CORREO ELECTRÓNICO: " AssociatedControlID="txtEmail" runat="server"></asp:Label>
                                        <asp:Label ID="txtEmail" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    
                                    <li>
                                        <asp:Label ID="lbTelefono" Text="TELÉFONO: " AssociatedControlID="txtTelefono" runat="server"></asp:Label>
                                        <asp:Label ID="txtTelefono" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />

                                    </li>
                                </ul>
                            </div>
                            <div id="sociedadData" class="RadGrid RadGrid_NoboxGrid">
                                <br />
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <asp:Label ID="lbRazSocial" Text="PERSONA FISICA A MATRICULAR/ MODIFICACION/ RENOVAR: " AssociatedControlID="txtRazSocial" runat="server"></asp:Label>
                                        <asp:Label ID="txtRazSocial" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblTelefonoCasa" Text="TELÉFONO PERSONA FISICA A MATRICULAR/ MODIFICACION/ RENOVAR " AssociatedControlID="txtTelefonoCasa" runat="server"></asp:Label>
                                        <asp:Label ID="txtTelefonoCasa" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblDocumento" Text="CEDULA/PASAPORTE: " AssociatedControlID="txtDocumento" runat="server"></asp:Label>
                                        <asp:Label ID="txtDocumento" Text="" runat="server" CssClass="tb over"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbRNCSociedad" Text="REGISTRO NACIONAL DE CONTRIBUYENTE (RNC): " AssociatedControlID="txtRNCSoc" runat="server"></asp:Label>
                                        <asp:Label ID="txtRNCSoc" Text="" runat="server" CssClass="tb over"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbDireccionPF" Text="DIRECCIÓN: " AssociatedControlID="txtDireccionPF" runat="server"></asp:Label>
                                        <asp:Label ID="txtDireccionPF" Text="" runat="server" CssClass="tb over"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNoRegistro" Text="REGISTRO NO.: " AssociatedControlID="txtNoRegistro" runat="server"></asp:Label>
                                        <asp:Label ID="txtNoRegistro" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblNacionalidad" Text="PAÍS DE ORIGEN: " AssociatedControlID="txtNacionalidad" runat="server"></asp:Label>
                                        <asp:Label ID="txtNacionalidad" Text="" runat="server" CssClass="tb over"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblNombreEstablecimiento" Text="NOMBRE DEL ESTABLECIMIENTO: " AssociatedControlID="txtNombreEstablecimiento" runat="server"></asp:Label>
                                        <asp:Label ID="txtNombreEstablecimiento" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblDireccionEstablecimiento" Text="DIRECCIÓN DEL ESTABLECIMIENTO: " AssociatedControlID="txtDireccionEstablecimiento" runat="server"></asp:Label>
                                        <asp:Label ID="txtDireccionEstablecimiento" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbTel1" Text="TELÉFONO 1: " AssociatedControlID="txtTel1" runat="server"></asp:Label>
                                        <asp:Label ID="txtTel1" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbTel2" Text="TELÉFONO 2: " AssociatedControlID="txtTel2" runat="server"></asp:Label>
                                        <asp:Label ID="txtTel2" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbFechaEmision" Text="FECHA DE EMISIÓN: " AssociatedControlID="txtFechaEmision" runat="server"></asp:Label>
                                        <asp:Label ID="txtFechaEmision" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblFechaIO" Text="FECHA INICIO OPERACIONES: " AssociatedControlID="txtFechaIO" runat="server"></asp:Label>
                                        <asp:Label ID="txtFechaIO" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbFechaVenc" Text="FECHA DE VENCIMIENTO: " AssociatedControlID="txtFechaVenc" runat="server"></asp:Label>
                                        <asp:Label ID="txtFechaVenc" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblEmpMasc" Text="EMPLEADOS MASCULINO (s): " AssociatedControlID="txtEmpMasc" runat="server"></asp:Label>
                                        <asp:Label ID="txtEmpMasc" Text="" runat="server" CssClass="tb" Height="16px" Width="244px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblEmpFem" Text="EMPLEADOS FEMENINO (s): " AssociatedControlID="txtEmpFem" runat="server"></asp:Label>
                                        <asp:Label ID="txtEmpFem" Text="" runat="server" CssClass="tb" Height="16px" Width="244px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblTotalEmp" Text="TOTAL EMPLEADOS: " AssociatedControlID="txtTotalEmp" runat="server"></asp:Label>
                                        <asp:Label ID="txtTotalEmp" Text="" runat="server" CssClass="tb" Height="16px" Width="244px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbPagWeb" Text="PÁGINA WEB: " AssociatedControlID="txtPagWeb" runat="server"></asp:Label>
                                        <asp:Label ID="txtPagWeb" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblEmailPF" Text="CORREO ELECTRÓNICO DEL ESTABLECIMIENTO: " AssociatedControlID="txtEmailPF" runat="server"></asp:Label>
                                        <asp:Label ID="txtEmailPF" runat="server" CssClass="tb over"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNombreCom" Text="NOMBRE COMERCIAL: " AssociatedControlID="txtNombreCom" runat="server"></asp:Label>
                                        <asp:Label ID="txtNombreCom" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                     <li>
                                        <asp:Label ID="lblRegNombreCom" Text="REGISTRO NO.: " AssociatedControlID="txtRegNombreCom" runat="server"></asp:Label>
                                        <asp:Label ID="txtRegNombreCom" Text="" runat="server" CssClass="tb over"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>

                                </ul>
                            </div>
                            <hr />
                            <div id="fechaAsamblea" class="RadGrid RadGrid_NoboxGrid">
                                <div style="padding-left: 5px; padding-top: 5px">

                                    <asp:Label ID="lbFechaAsamble" Text="" AssociatedControlID="txtFechaAsamb" runat="server" ReadOnly="True"></asp:Label>
                                    <asp:Label ID="txtFechaAsamb" Text="" runat="server" ReadOnly="True"></asp:Label>

                                </div>
                                <br />
                            </div>
                            <br />
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
        #soci

        ad a {
            width: 918px;
        }
    </style>
</asp:Content>


