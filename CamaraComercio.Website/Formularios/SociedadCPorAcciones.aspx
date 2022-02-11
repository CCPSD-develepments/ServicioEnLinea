<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/res/noboxForm.Master" CodeBehind="SociedadCPorAcciones.aspx.cs" Inherits="CamaraComercio.Website.Formularios.SociedadCPorAcciones" %>

<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">

                <!-- CSS -->
                <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
                <link href="/res/js/fbTextbox/TextboxList.css" rel="stylesheet" type="text/css" />
                <link href="/res/js/fbTextbox/TextboxList.Autocomplete.css" rel="stylesheet" type="text/css" />
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
                            <div id="servicio" class="RadGrid RadGrid_NoboxGrid" style="padding: 2px">
                                <br />
                                <asp:Label ID="Label2" Text="SERVICIO: " runat="server" AssociatedControlID="txtServicio" Font-Size="14px" Height="26px" Width="174px"></asp:Label>
                                &nbsp;
                                <asp:Label ID="txtServicio" runat="server" CssClass="tb over" Width="70%" ReadOnly="True" AssociatedControlID="txtServicio"></asp:Label>
                                <br />
                                <br />
                            </div>
                            <div style="text-transform: uppercase;">
                                <h4 style="align-content: center; height: 2px; font-size: large;" align="center">DATOS DEL GESTOR</h4>
                                <div id="gestorData" class="RadGrid RadGrid_NoboxGrid">
                                    <ul style="padding-left: 5px; padding-top: 5px">
                                        <%--<li>
                                            <asp:Label ID="lbSolicitante" AssociatedControlID="txtSolicitante" Text="SOLICITANTE: " runat="server"></asp:Label>
                                            &nbsp;
                                        <asp:Label ID="txtSolicitante" Text="" runat="server" ReadOnly="True" CssClass="tb over" Width="70%"></asp:Label>
                                            <br />
                                            <br />
                                        </li>--%>
                                        <%--<li>
                                            <asp:Label ID="lbRNC1" Text="RNC/CEDULA DE SOLICITANTE: " AssociatedControlID="txtRNC1" runat="server"></asp:Label>
                                            &nbsp;
                                        <asp:Label ID="txtRNC1" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                            <br />
                                            <br />
                                        </li>--%>
                                        <li>
                                            <asp:Label ID="lbNombreCont" AssociatedControlID="txtNombreCont" Text="SOLICITANTE Y/O NOMBRE DE LA PERSONA DE CONTACTO: " runat="server"></asp:Label>
                                            &nbsp;
                                        <asp:Label ID="txtNombreCont" Text="" runat="server" ReadOnly="True" CssClass="tb over" Width="70%"></asp:Label>
                                            <br />
                                            <br />
                                        </li>
                                        <li>
                                            <asp:Label ID="lbCedula" Text="CÉDULA DE CONTACTO: " AssociatedControlID="txtCedula" runat="server"></asp:Label>
                                            &nbsp;
                                        <asp:Label ID="txtCedula" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                            <br />
                                            <br />
                                        </li>
                                        <li>
                                            <asp:Label ID="lbEmail" AssociatedControlID="txtEmail" Text="CORREO ELECTRÓNICO: " runat="server"></asp:Label>
                                            &nbsp;
                                        <asp:Label ID="txtEmail" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                            <br />
                                            <br />
                                        </li>
                                        <li>
                                            <asp:Label ID="lbTelefono" Text="TELÉFONO: " runat="server" AssociatedControlID="txtTelefono"></asp:Label>
                                            &nbsp;
                                        <asp:Label ID="txtTelefono" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                            <br />
                                            <br />
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <h4 style="align-content: center; height: 2px; font-size: large;" align="center">DATOS DE LA SOCIEDAD</h4>
                            <div id="sociedadData" class="RadGrid RadGrid_NoboxGrid">
                                <br />
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li>
                                        <asp:Label ID="lbRazSocial" Text="DENOMINACIÓN SOCIAL/ RAZÓN SOCIAL: " AssociatedControlID="txtRazSocial" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtRazSocial" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblTipoSocietario" Text="TIPO SOCIETARIO:" AssociatedControlID="txtTipoSocietario" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTipoSocietario" Text="" runat="server" CssClass="tb over" style="text-transform: uppercase;"  Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNoRegistro" Text="REGISTRO NO." AssociatedControlID="txtNoRegistro" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtNoRegistro" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbRNCSociedad" Text="REGISTRO NACIONAL DE CONTRIBUYENTE (RNC):" AssociatedControlID="txtRNCSoc" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtRNCSoc" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbFechaEmision" Text="FECHA DE EMISIÓN: " AssociatedControlID="txtFechaEmision" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtFechaEmision" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbFechaVenc" Text="FECHA DE VENCIMIENTO: " AssociatedControlID="txtFechaVenc" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtFechaVenc" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbFecaConst" Text="FECHA DE ACTO CONSTITUTIVO: " AssociatedControlID="txtFechaConst" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtFechaConst" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lnDuracionSociedad" runat="server" AssociatedControlID="txtDuracionSociedad" Text="DURACIÓN DE LA SOCIEDAD: " Height="16px" Width="212px"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtDuracionSociedad" runat="server" Text="" CssClass="tb over" Width="70%"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    
                                    <li>
                                        <asp:Label ID="lbEstadoAct" Text="ESTADO ACTUAL DE LA SOCIEDAD: " AssociatedControlID="txtEstadoSociedad" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtEstadoSociedad" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <br />
                                        <h5 style="align-content: center; height: 5px; color:black">DIRECCIÓN DE LA SOCIEDAD</h5>
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbDireccionSociedad" Text="DIRECCIÓN DE LA SOCIEDAD:" AssociatedControlID="txtDireccionSociedad" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtDireccionSociedad" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbTel1" Text="TELÉFONO 1: " AssociatedControlID="txtTel1" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTel1" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbTel2" Text="TELÉFONO 2: " AssociatedControlID="txtTel2" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTel2" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lblCorreoSociedad" Text="CORREO ELECTRÓNICO SOCIEDAD:" AssociatedControlID="txtDireccionSociedad" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtCorreoSociedad" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbPagWeb" Text="PÁGINA WEB:" AssociatedControlID="txtPagWeb" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtPagWeb" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNacionalidad" Text="PAÍS DE ORIGEN:" AssociatedControlID="txtPagWeb" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtNacionalidad" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>

                                    <br />
                                    <h5 style="align-content: center; height: 5px; color:black">CANTIDAD DE EMPLEADOS</h5>
                                    <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbMasculino" Text="Masculino: " AssociatedControlID="txtMasculino" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtMasculino" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbFemenino" Text="Femenino: " AssociatedControlID="txtFemenino" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtFemenino" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbTotal" Text="Total: " AssociatedControlID="txtTotal" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTotal" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbNombreComercial" Text="NOMBRE COMERCIAL: " AssociatedControlID="txtEstadoSociedad" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtNombreComercial" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbRegitroNComercial" Text="REGISTRO NO.: " AssociatedControlID="txtRegitroNComercial" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtRegitroNComercial" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <br />
                                        <h5 style="align-content: center; height: 5px; color:black">ACTIVIDAD DE LA SOCIEDAD</h5>
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbDesc" Text="DESCRIPCION DEL NEGOCIO: " AssociatedControlID="txtDesc" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtDesc" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbActividad" Text="ACTIVIDAD: " AssociatedControlID="txtActividad" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtActividad" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <br />
                                        <h5 style="align-content: center; height: 5px; color:black">CAPITAL SOCIAL</h5>
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbMonto" Text="MONTO: " AssociatedControlID="txtMonto" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtMonto" Text="" runat="server" CssClass="tb over" Width="70%" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <asp:Label ID="lbMonenda" Text="TIPO MONEDA: " AssociatedControlID="txtMoneda" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtMoneda" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    
                                    <li>
                                    <h5 style="align-content: center; height: 5px; color:black">ÚLTIMA ASAMBLEA</h5>
                                    <br />
                                        <asp:Label ID="lbFechaAsamble" Text="FECHA: " AssociatedControlID="txtFechaAsamb" runat="server" ReadOnly="True"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtFechaAsamb" Text="" runat="server" ReadOnly="True"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                </ul>
                            </div>

                            <div id="Socios">
                                <br />
                                <div id="OrganoGestor" class="RadGrid RadGrid_NoboxGrid">
                                    <%--  --%>
                                    <div id="SociosC" runat="server">
                                        <h4 style="align-content: center; height: 5px;" align="center">DATOS SOCIO COMANDITADO</h4>
                                        <br />
                                        <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                            <thead>
                                                <tr>
                                                    <%--<th class="rgHeader">CARGO</th>--%>
                                                    <th class="rgHeader">NOMBRE(S) Y APELLIDO(S)</th>
                                                    <th class="rgHeader">CÉDULA/PASAPORTE/RNC/RM</th>
                                                    <th class="rgHeader">DIRECCIÓN</th>
                                                    <th class="rgHeader">NACIONALIDAD</th>
                                                    <th class="rgHeader">ESTADO CIVIL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ComanditadosRep" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="rgRow">
                                                            <%--<td><span><%# Eval("Cargo") %></span></td>--%>
                                                            <td><span><%# Eval("Accionista") %></span></td>
                                                            <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(""+Eval("Documento"))%></span></td>
                                                            <td><span><%# Eval("Calle")+ " " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                            <td><span><%# Eval("Nacionalidad") %></span></td>
                                                            <td><span><%# Eval("EstadoCivil") %></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <h2 runat="server" style="display: none;">No hay datos para mostrar. </h2>
                                        <asp:Label ID="lblTotalSociosComanditado" style="padding-left:15px;" runat="server" Text="CANTIDAD TOTAL SOCIOS: " CssClass="tb"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTotalSociosComanditado" style="padding-left:15px;" runat="server" Text="" CssClass="tb"></asp:Label>
                                        <br />

                                        <asp:Label ID="Label1" runat="server" style="padding-left:15px;" AssociatedControlID="txtTotalAccionesComanditado" Text="CANTIDAD TOTAL ACCIONES : "></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTotalAccionesComanditado" style="padding-left:15px;" runat="server" Text="" CssClass="tb"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <%--  --%>
                                    <%--  --%>
                                    <div id="SociosCo" runat="server">
                                        <h4 style="align-content: center; height: 5px;" align="center">DATOS DE SOCIOS COMADITARIOS</h4>
                                        <table class="auto-style2" style="width: 100%; empty-cells: show;" cellspacing="0" align="center">
                                            <thead>
                                                <tr>
                                                    <th class="rgHeader">NOMBRE(S) Y APELLIDO(S)</th>
                                                    <th class="rgHeader">CÉDULA/PASAPORTE/RNC/RM</th>
                                                    <th class="rgHeader">DIRECCIÓN</th>
                                                    <th class="rgHeader">NACIONALIDAD</th>
                                                    <th class="rgHeader">ESTADO CIVIL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ComanditariosRep" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="rgRow">
                                                            <td><span><%# Eval("Accionista") %></span></td>
                                                            <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(""+Eval("Documento"))%></span></td>
                                                            <td><span><%# Eval("Calle") %></span></td>
                                                            <td><span><%# Eval("Nacionalidad") %></span></td>
                                                            <td><span><%# Eval("EstadoCivil") %></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <h2 runat="server" style="display: none;">No hay datos para mostrar. </h2>
                                        <asp:Label ID="lblTotalSociosComanditario" style="padding-left:15px;" runat="server" Text="CANTIDAD TOTAL SOCIOS: " CssClass="tb"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTotalSociosComanditario" style="padding-left:15px;" runat="server" Text="" CssClass="tb"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label5" runat="server" style="padding-left:15px;" AssociatedControlID="txtTotalAccionesComanditario" Text="CANTIDAD TOTAL ACCIONES : "></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="txtTotalAccionesComanditario" style="padding-left:15px;" runat="server" Text="" CssClass="tb"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <%--  --%>
                                    <%--  --%>
                                    <div id="SociosGe" runat="server">
                                        <h4 style="align-content: center; height: 5px;" align="center">DATOS DEL ÓRGANO DE GESTIÓN / GERENTES</h4>
                                        <br />
                                        <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                            <thead>
                                                <tr>
                                                    <th class="rgHeader">NOMBRE(S) Y APELLIDO(S)</th>
                                                    <th class="rgHeader">CARGO</th>
                                                    <th class="rgHeader">CÉDULA/PASAPORTE/RNC/RM</th>
                                                    <th class="rgHeader">DIRECCIÓN</th>
                                                    <th class="rgHeader">NACIONALIDAD</th>
                                                    <th class="rgHeader">ESTADO CIVIL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="orgGestionRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="rgRow">
                                                            <td><span><%# Eval("Accionista") %></span></td>
                                                            <td><span><%# Eval("Cargo") %></span></td>
                                                            <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(""+Eval("Documento"))%></span></td>
                                                            <td><span><%# Eval("Calle") + " " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                            <td><span><%# Eval("Nacionalidad") %></span></td>
                                                            <td><span><%# Eval("EstadoCivil") %></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <h2 runat="server" style="display: none;">No hay datos para mostrar. </h2>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <%--  --%>
                                    <%--  --%>
                                    <div id="SociosFi" runat="server">
                                        <h4 style="align-content: center; height: 5px;" align="center">DATOS DE ADMINISTRADORES Y/O PERSONAS AUTORIZADAS A FIRMAR EN SU NOMBRE</h4>
                                        <br />
                                        <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                            <thead>
                                                <tr>
                                                    
                                                    <th class="rgHeader">NOMBRE(S) Y APELLIDO(S)</th>
                                                    <th class="rgHeader">CÉDULA/PASAPORTE/RNC/RM</th>
                                                    <th class="rgHeader">DIRECCIÓN</th>
                                                    <th class="rgHeader">NACIONALIDAD</th>
                                                    <th class="rgHeader">ESTADO CIVIL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="sociosAutRep" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="rgRow">
                                                            
                                                            <td><span><%# Eval("Accionista") %></span></td>
                                                            <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(""+Eval("Documento"))%></span></td>
                                                            <td><span><%# Eval("Calle") + " " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                            <td><span><%# Eval("Nacionalidad") %></span></td>
                                                            <td><span><%# Eval("EstadoCivil") %></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <h2 runat="server" style="display: none;">No hay datos para mostrar. </h2>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <%--  --%>
                                    <%--  --%>
                                    <div id="SociosCom" runat="server">
                                        <h4 style="align-content: center; height: 5px;" align="center">COMISARIO DE CUENTAS</h4>
                                        <br />
                                        <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                            <thead>
                                                <tr>
                                                    <th class="rgHeader">NOMBRE(S) Y APELLIDO(S)</th>
                                                    <th class="rgHeader">CÉDULA/PASAPORTE/RNC/RM</th>
                                                    <th class="rgHeader">DIRECCIÓN</th>
                                                    <th class="rgHeader">NACIONALIDAD</th>
                                                    <th class="rgHeader">ESTADO CIVIL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="sociosComisario" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="rgRow">
                                                            <td><span><%# Eval("Accionista") %></span></td>
                                                            <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(""+Eval("Documento"))%></span></td>
                                                            <td><span><%# Eval("Calle") + " " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                            <td><span><%# Eval("Nacionalidad") %></span></td>
                                                            <td><span><%# Eval("EstadoCivil") %></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <h2 runat="server" style="display: none;">No hay datos para mostrar. </h2>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                    <%--  --%>
                                    <%--  --%>
                                    <div id="SociosVi" runat="server">
                                        <h4 style="align-content: center; height: 5px;" align="center">CONSEJO DE VIGILANCIA</h4>
                                        <br />
                                        <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                            <thead>
                                                <tr>
                                                    <th class="rgHeader">NOMBRE(S) Y APELLIDO(S)</th>
                                                    <th class="rgHeader">CÉDULA/PASAPORTE/RNC/RM</th>
                                                    <th class="rgHeader">DIRECCIÓN</th>
                                                    <th class="rgHeader">NACIONALIDAD</th>
                                                    <th class="rgHeader">ESTADO CIVIL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="consejoRep" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="rgRow">
                                                            <td><span><%# Eval("Accionista") %></span></td>
                                                            <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(""+Eval("Documento"))%></span></td>
                                                            <td><span><%# Eval("Calle") + " " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                            <td><span><%# Eval("Nacionalidad") %></span></td>
                                                            <td><span><%# Eval("EstadoCivil") %></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <h2 runat="server" style="display: none;">No hay datos para mostrar. </h2>
                                        <br />
                                        <br />
                                        <br />
                                    <%--  --%>
                                    </div>
                                </div>

                                <div runat="server" id="entesReguladosDiv" visible="false">
                                    <div id="entesRegTbl" class="RadGrid RadGrid_NoboxGrid">
                                    <h4 style="align-content: center; height: 2px;" align="center">&nbsp;ENTES REGULADOS</h4>
                                    <br />
                                    <table class="auto-style1" style="width: 100%; empty-cells: show;" cellspacing="0" align="center">
                                        <thead style="text-align: center;">
                                            <tr>
                                                <th class="rgHeader">TIPO DE ENTE REGULADO</th>
                                                <th class="rgHeader">NO. RESOLUCIÓN</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="entesRegRep" runat="server">
                                                <ItemTemplate>
                                                    <tr class="rgRow">
                                                        <td><span><%# Eval("EnteReguladoDescripcion") %></span></td>
                                                        <td><span><%# Eval("NoResolucion") %></span></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                    <br />
                                </div>
                                </div>
                                
                            </div>
                            <div id="productos" runat="server" class="RadGrid RadGrid_NoboxGrid">
                                <h4 style="align-content: center; height: 2px;" align="center">&nbsp;PRINCIPALES PRODUCTOS/SERVICIOS</h4>
                                <br />
                                <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                    <thead>
                                        <tr>
                                            <th class="rgHeader">DESCRIPCIÓN</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="productosRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr class="rgRow">
                                                    <td><span><%# Eval("Descripcion") %></span></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                            </div>
                            <div id="sucursales" runat="server" class="RadGrid RadGrid_NoboxGrid">
                                <h4 style="align-content: center; height: 2px; font-size: large;" align="center">&nbsp;SUCURSALES</h4>
                                <br />
                                <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                    <thead>
                                        <tr>
                                            <th class="rgHeader">DESCRIPCIÓN</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="sucursalRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr class="rgRow">
                                                    <td><span><%# Eval("Descripcion") %></span></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                            </div>
                            <hr />
                            <div id="refs" class="RadGrid RadGrid_NoboxGrid">
                                <ul style="padding-left: 5px; padding-top: 5px">
                                    <li></li>
                                    <li>
                                        <label for="txtReferenciasComerciales">
                                            REFERENCIAS COMERCIALES
                                        </label>
                                        <asp:Label ID="txtReferenciasComerciales" runat="server" ClientIDMode="Static" CssClass="commentCtrl" ReadOnly="True" />
                                        &nbsp;
                                        <asp:HiddenField ID="hfReferenciasComerciales" runat="server" ClientIDMode="Static" />
                                    </li>
                                    <li>
                                        <label for="txtRefBancarias">
                                            REFERENCIAS BANCARIAS
                                        </label>
                                        <asp:Label ID="txtRefBancarias" ClientIDMode="Static" runat="server" CssClass="commentCtrl" ReadOnly="True" />
                                        &nbsp;
                                        <asp:HiddenField ID="hfRefBancarias" ClientIDMode="Static" runat="server" />
                                    </li>
                                </ul>
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


