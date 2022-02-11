<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="SolicitudInclusion.aspx.cs" Inherits="CamaraComercio.Website.Empresas.SolicitudInclusion" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>--%>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Texbox Autonumeico -->
    <script type="text/javascript" language="javascript" src="/res/js/jquery.alphanumeric.js"></script>
    <!-- Javascript general -->
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
        <script src="http://digitalbush.com/wp-content/uploads/2013/01/jquery.maskedinput-1.3.1.min_.js" type="text/javascript"></script>
    <!-- Inline user script -->
    <script type="text/javascript">
        $(document).ready(function () {
            //Menu
            $('#navigation li').removeClass("active");
            $('#liNavRM').addClass("active");

            $('#subnavigation li').removeClass("active");
            $('#liSolInclusion').addClass("active");

            //Traducción del error de validación automático del reCaptcha
            var errores = $("#errorbox li");
            if (errores.length > 0) {
                for (var i = 0; i < errores.length; i++) {
                    if (errores.eq(i).text() == "The verification words are incorrect.")
                        errores.eq(i).text("Error de validación. Intente ingresar las dos palabras nuevamente.");
                }
            }
            //txtTelefonoContacto
            //Quitando los tab stops del captcha
            $('#recaptcha_table a').each(function () { this.tabIndex = -1 });
                 $('#txtTelefonoContacto').mask('(999) 999-9999');
            //Se activa la validacion para textboxes numericos
            $('.inputNumerico').numeric();
        });
    </script>
    <!-- Estilos -->
    <style type="text/css">
        td
        {
            vertical-align: top;
        }
        rbl
        {
            color:black;
        }
    </style>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="container_24">
        <asp:Label ID="lblTransId" runat="server" Visible="false" Text="0"></asp:Label> 
        <div class="grid_24">
            <div id="content_header">
                <h1 class="inclusion">
                    Solicitar Acceso a Empresa Existente</h1>
            </div>
            <div id="content_body">
                <h2>
                    Acceso a Empresa Existente</h2>
                <br />
                <asp:MultiView ActiveViewIndex="0" runat="server" ID="mvInclusion">
                    <asp:View runat="server" ID="vFormulario">
                        <h5>
                            Introduce la información correspondiente en cada campo y haz click sobre "Verificar".
                            Si tienes alguna duda con un término, visita nuestro 
                            <a href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/Glosario"
                            target="_blank">Glosario de Términos.</a> <strong>Todos
                                los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                        <fieldset class="form-fieldset">
                            <ul>
                                <li>
                                    <label for="ddlTest">
                                        Cámara <span class="validator">*</span>
                                    </label>
                                    <asp:DropDownList ID="ddlCamara" runat="server" DataSourceID="odsCamaras" DataTextField="Nombre" Enabled="false"
                                        DataValueField="Id" CssClass="dd commentCtrlHov" ClientIDMode="Static">
                                    </asp:DropDownList>
                                    <div id="ddlCamaraComment" class="comments">
                                        Selecciona la provincia donde esté domiciliada tu empresa. Esto va determinar en
                                        qué cámara de comercio se registrará su empresa.
                                    </div>
                                    <asp:ObjectDataSource ID="odsCamaras" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="FetchAllActivas" TypeName="CamaraComercio.DataAccess.EF.CamaraComun.CamarasController">
                                    </asp:ObjectDataSource>
                                </li>
                                <li>
                                    <label for="txtSociedadPersonaFisica">
                                        Seleccione el tipo de empresa<span class="validator">*</span>
                                    </label>
                                    <asp:DropDownList ID="ddlTipoSociedadPersona" runat="server" CssClass="dd commentCtrlHov" ClientIDMode="Static">
                                        <asp:ListItem Value="0" Text="Selecciona el tipo"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Sociedad"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Persona Física"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="ddlTipoSociedadPersonaComment" class="comments">
                                        Selecciona el tipo de empresa.
                                    </div>
                                </li>
                                <li>
                                    <label for="txtNumeroRegistro">
                                        No. Registro Mercantil <span class="validator">*</span>
                                    </label>
                                    <asp:TextBox ID="txtNumeroRegistro" runat="server" CausesValidation="true" autocomplete="off"
                                        CssClass="inputNumerico tb commentCtrl" MaxLength="10" ClientIDMode="Static"
                                        Width="150px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumeroRegistro"
                                        ErrorMessage="Debe especificar el número de Registro Mercantil de la sociedad"
                                        CssClass="validator summary" Display="None" />
                                    <div class="comments" id="txtNumeroRegistroComment">
                                        Número de registro mercantil. Ignorar guiones y letras.
                                    </div>
                                </li>
                                <li>
                                    <label for="txtCaptcha">
                                    Codigo Captcha <span class="validator">*</span>
                                    </label>
                                 <asp:TextBox runat = "server" ID = "txtCaptcha" 
                                        CssClass="tb widestInput commentCtrl" Display="None" Width="150px" AutoCompleteType="Disabled"
                                        autocomplete="off" ></asp:TextBox>
                                    <div align="left" >
                                    <cc1:CaptchaControl ID="ccJoin" runat="server" 
                                         CaptchaLength="5" CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="Low" 
                                         CaptchaMinTimeout="5" CaptchaMaxTimeout="240" 
                                        CustomValidatorErrorMessage="Error de validación, intente ingresar la palabra nuevamente." 
                                        Width="902px" CaptchaBackgroundNoise="Medium"  />
                                   </div>
                                </li>
                                <li>
                                    <div class="footer_go">
                                        <asp:Button ID="btnVerificacion" runat="server" Text="Verificar" OnClick="btnSolicitud_Click"
                                            CssClass="btn btnFormNext" Height="52px" /><div style="clear: both;">
                                            </div>
                                    </div>
                                </li>
                            </ul>
                        </fieldset>
                        <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                                Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                            ClientIDMode="Static" />
                    </asp:View>
                    <asp:View runat="server" ID="vSeleccionEmpresas">
                        Se encontró más de una empresa o sociedad con este accionista. Por favor seleccione
                        la empresa para la cual desea solicitar acceso.
                        <telerik:RadGrid runat="server" ID="rgridMultiplesEmpresas" AllowPaging="True" AutoGenerateColumns="False"
                            GridLines="None" Skin="NoboxGrid" EnableEmbeddedSkins="False">
                            <MasterTableView>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="NumeroRegistro" HeaderText="No. Registro" UniqueName="NumeroRegistro">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Empresa/Sociedad" UniqueName="NombreSocial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaConstitucion" HeaderText="Fecha Constitución"
                                        UniqueName="FechaConstitucion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn Text="Seleccionar" UniqueName="lnkSeleccionarEmpresa">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView></telerik:RadGrid>
                    </asp:View>
                    <asp:View runat="server" ID="vRevision">
                        <h1>
                            Confirmación de datos</h1>
                        <fieldset>
                            <ul>
                                <li>
                                    <label for="lblRnc">
                                        RNC o Cédula</label>
                                    <asp:Label Text="" runat="server" ID="lblRnc" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="lblRegistro">
                                        No. Registro Mercantil</label>
                                    <asp:Label Text="" runat="server" ID="lblRegistro" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="lblNombreEmpresa">
                                        Denominación/Razón Social
                                    </label>
                                    <asp:Label Text="" runat="server" ID="lblNombreEmpresa" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="lblFechaConstitucion">
                                        Fecha Constitución</label>
                                    <asp:Label Text="" runat="server" ID="lblFechaConstitucion" ClientIDMode="Static" />
                                </li>
                                <li>
                                    <label for="lblCamaraID">
                                        Cámara</label>
                                    <asp:Label ID="lblCamaraID" runat="server" ClientIDMode="Static" />
                                </li>

                                <li>
                                    <label for="txtPersonaContacto">Persona Contacto</label>
                                    <asp:TextBox runat="server" ID="txtPersonaContacto" ClientIDMode="Static" 
                                    CssClass="tb commentCtrl" style="text-transform:uppercase;"/>
                                    <div class="comments" id="txtPersonaContactoComment">
                                        Especifica la persona de contacto a llamar para dar seguimiento a esta solicitud. 
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPersonaContacto" ClientIDMode="Static" 
                                        Text="*" ErrorMessage="Debe especificar la persona de contacto"
                                        CssClass="validator summary" ValidationGroup="ContactoVal"
                                        ControlToValidate="txtPersonaContacto" />
                                </li>
                                
                                <li>
                                    <label for="txtTelefonoContacto">Teléfono Contacto</label>
                                    <asp:TextBox runat="server" id="txtTelefonoContacto" ClientIDMode="Static" MaxLength="15"
                                        CssClass="tb commentCtrl numeric" />
                                    <div class="comments" id="txtTelefonoContactoComment">
                                        Especifica el número telefónico de la persona de contacto.
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvTelefonoContacto" ClientIDMode="Static" 
                                        Text="*" ErrorMessage="Debe especificar el teléfono de contacto"
                                        CssClass="validator summary" ValidationGroup="ContactoVal"
                                        ControlToValidate="txtTelefonoContacto" />
                                </li>

                                <li>
                                    <div class="footer_go">
                                        <asp:Button ID="btnSolicitar" runat="server" Text="Confirmar" OnClick="btnSolicitar_Click"
                                            CssClass="btn btnFormNext" Height="52px" /><div style="clear: both;">
                                            </div>
                                    </div>
                                    <div class="clear"/>
                                </li>
                            </ul>
                        </fieldset>
                        <asp:ValidationSummary runat="server" ID="errorBoxPersonaVal" 
                            CssClass="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                                Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                            ClientIDMode="Static" ValidationGroup="ContactoVal" />
                    </asp:View>
                    <asp:View runat="server" ID="vConfirmacion">
                        <br />
                        <p>
                            <span style="font-size: 12pt">Su número de solicitud es el
                                <asp:Label runat="server" ID="lblNoRecibo" Style="font-weight: bold;" ForeColor="SteelBlue" />
                            </span>
                        </p>
                        <h2>
                            Próximos Pasos
                        </h2>
                        <h3>
                            Entrega de poder de Representación u otro documento que le apodere.
                        </h3>
                        <p>
                            Es necesario presentar un poder de representación para poder incluir su acceso a 
                            esta empresa bajo su cuenta de usuario.
                            Favor recordar que al momento de cargar al portal su poder de representación el mismo debe estar legalizado y notarizado.
                            <br />
                        </p>
                        <h3>
                            Descarga de plantilla: <a href="/res/pdf/Poder Autorizacion Form.pdf" target="_blank">Poder de Representación
                                <img src="/res/img/icons/page.png" alt="Descarga Poder Representación" style="border: none" />
                            </a>
                        </h3>
                        Para realizar la entrega del poder ahora acceda al formulario de envío <asp:HyperLink runat="server" ID="lnkFormEnvioDatos">formulario de envío de datos</asp:HyperLink>
                        <asp:Label ID="lblMensajesConfirmacion" runat="server" ForeColor="Firebrick" Text="&lt;strong&gt;Nota:&lt;/strong&gt; Esta sociedad ya está registrada con otro usuario. En el caso de realizarse el cambio de dueño se notificará al usuario actual."
                            Visible="False" />
                        <div class="clear" />
                        <div id="wrapperContent" style="text-align: center">
                            <div class="infoBox" id="divEnvioDocs">
                                <div class="infoContent">
                                    <asp:HyperLink runat="server" ID="hlEntregaFisica" Target="_blank" Text="Entrega Física"
                                        CssClass="btn" NavigateUrl="#" />
                                    <p>
                                        <asp:Literal ID="ltrDireccionCamara" runat="server"></asp:Literal>
                                    </p>
                                </div>
                            </div>
                            <div class="infoBox" id="div1">
                                <div class="infoContent">
                                    <asp:HyperLink runat="server" ID="HyperLink1" Target="_blank" Text="Entrega En Línea"
                                        CssClass="btn" NavigateUrl="/Empresas/EnvioDatos.aspx" />
                                    <p>
                                        Mediante el
                                        <asp:HyperLink runat="server" ID="hlnkEnvioDatos" NavigateUrl="/Empresas/EnvioDatos.aspx">
                            Formulario de envío de datos
                                        </asp:HyperLink>
                                        <br />
                                        <br />
                                        Todos los documentos enviados deben
                                        <br />
                                        contar una firma digital válida.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="clear" />
                    </asp:View>
                    <asp:View runat="server" ID="vError">
                        <asp:Label ID="lblError" runat="server" ForeColor="Firebrick" Text="Ha ocurrido un error en el sistema. Por favor intente su solicitud nuevamente" />
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
