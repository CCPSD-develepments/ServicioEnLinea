<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="DatosSociedad.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Registro.DatosSociedad" %>

<%@ Register Src="~/UserControls/ManejoSocios.ascx" TagName="ManejoSocios" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls"
    TagPrefix="cc1" %>
<asp:Content ID="HeadResx" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- CSS -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/fbTextbox/TextboxList.css" rel="stylesheet" type="text/css" />
    <link href="/res/js/fbTextbox/TextboxList.Autocomplete.css" rel="stylesheet" type="text/css" />
    
    <!-- Plugins -->
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/jquery.fieldtag.js" type="text/javascript"></script>
    <script src="/res/js/jquery.maskedinput.js" type="text/javascript"></script>
    <script src="/res/js/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>
    
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/TextboxList.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/TextboxList.Autocomplete.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/GrowingInput.js" type="text/javascript"></script>
    
    <!-- Javascript de este formulario -->
    <script type="text/javascript" src="/res/js/ui.adecuacion.js"></script>
    <script type="text/javascript" src="/res/js/ui.datossociedad.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //Menu de navegación
            $('#subnavigation li').removeClass("active");
            $('#navigation li').removeClass("active");
            $('#liNavCreacion').addClass("active");

            //*** Validacion del recibo de DGII ***//
            //Variables
            var btnRecibo = $("#btnValidarNoRecibo");
            var btnOnapi = $("#btnValidarReciboOnapi");
            var txtnoReciboOnapi = $("#txtNombreComercialNumero");
            var imgWaitingOnapi = $("#imgWaitingOnapi");
            var txtNombreComercialDesc = $("#txtNombreComercialDesc");
            var txtNoRecibo = $("#txtNoRecibo");
            var txtEstado = $("#txtRestadoReciboDgii");
            var txtMontoDGII = $("#txtMontoDGII");
            var imgWaiting = $("#imgWaiting");
            var pnlDgii = $("#pnlInformacionDGII");
            var hfMontoDgii = $("#hfMontoDgiiStr");
            var hfEstatusDgii = $("#hfEstadoDgiiStr");
            var hfFechaDgii = $("#hfFechaDgiiStr");

            //Se limita el textbox del recibo de DGII a caracteres numéricos
            txtNoRecibo.numeric();
            $("#txtNombreComercialNumero").numeric();

            //Si hay un postback, hay que asignar nuevamente los labels
            if (hfMontoDgii.val().length > 0) {
                txtMontoDGII.text(hfMontoDgii.val())
                txtEstado.text(hfEstatusDgii.val());
                $("#radFechaRecibo").text(hfFechaDgii.val());
                $("#txtMontoDGII").formatCurrency({ symbol: "RD$" });
            }
            else {
                pnlDgii.hide();
            }

            //Recibo de DGII, deshabilitando el botón de validacion
            imgWaiting.hide();
            imgWaitingOnapi.hide();
            if (txtNoRecibo.val().length == 0)
                btnRecibo.attr("disabled", "disabled");

            //Capturando la entrada en el textbox del recibo para habilitar el boton
            txtNoRecibo.live("change keyup", function () {
                if (txtNoRecibo.val().length > 0)
                    btnRecibo.removeAttr("disabled");
                else
                    btnRecibo.attr("disabled", "disabled");
            });
            //Consulta con el ws de onapi
            btnOnapi.click(function () {
                var noReciboOnapi = $("#txtNombreComercialNumero").val();
                if (noReciboOnapi.length == 0) return;

                imgWaitingOnapi.show();
                btnOnapi.css('cursor', 'wait');

                $.ajax({ type: 'GET', url: '/api.aspx?op=reciboonapi&Id=' + noReciboOnapi, dataType: 'json',
                    async: false,
                    success: function (data) {
                        if (data == null) {
                            alert("El número de recibo de onapi es incorrecto");
                            $("#txtNombreComercialDesc").val("");
                            imgWaitingOnapi.hide();
                            btnOnapi.css('cursor', 'auto');
                            return 
                        
                        };

                        var nombreComercial = data.Texto;

                        $("#txtNombreComercialDesc").val(nombreComercial);
                        imgWaitingOnapi.hide();
                        btnOnapi.css('cursor', 'auto');
                    },
                    error: function (err) {
                        alert("El número de recibo de onapi es incorrecto");
                    }
                });

            });
            //Consulta con el WS de la DGII
            btnRecibo.click(function () {
                var noRecibo = txtNoRecibo.val();
                if (noRecibo.length == 0) return;

                //Elementos del UI que indican que se está esperando una acción
                imgWaiting.show();
                btnRecibo.css('cursor', 'wait');

                $.ajax({ type: 'GET', url: '/api.aspx?op=recibodgii&Id=' + noRecibo, dataType: 'json',
                    async: false,
                    success: function (data) {
                        if (data == null) return;

                        //Se muestra el panel con informaciones
                        pnlDgii.fadeIn();

                        //Variables retornadas por el servicio
                        var monto = data.MontoAutorizacionPago;
                        var pagada = data.Pagada;
                        var fecha = new Date(parseInt(data.FechaPagoAutorizacion.substr(6)));
                        var estatus = data.DescripcionMensaje;
                        var codigo = data.CodigoMensaje;

                        //Monto
                        $("#hfMontoDgiiStr").val(monto);
                        $("#txtMontoDGII").text(monto);
                        $("#txtMontoDGII").formatCurrency({ symbol: "RD$" });

                        //Se verifica si el web service retorna estatus 4 (pendiente revisar para los demas)
                        if (codigo == 4 || !pagada || data.Vencida)
                            txtEstado.addClass("validator");

                        //Estatus de la transacción (mensaje)
                        if (estatus.length > 0) {
                            txtEstado.text(estatus);
                            txtEstado.val(estatus);
                        }

                        //Fecha de pago (si se pagó)
                        if (pagada) {
                            $("#hfFechaReciboDgii").val(fecha.format("yyyy-MM-dd"));

                            $("#hfFechaDgiiStr").val(fecha.format("dd/MMM/yyyy"));
                            $("#radFechaRecibo").text(fecha.format("dd/MMM/yyyy"));
                        }
                    },
                    error: function (err) {
                        alert("El número de recibo de la DGII es incorrecto");
                    }
                });

                //Elementos del UI de vuelta a su estado original
                imgWaiting.hide();
                imgWaitingOnapi.hide();
                btnRecibo.css('cursor', 'auto');
            });
        });
        

    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <!-- Hidden Fields -->
    <asp:HiddenField ID="hfNuevoRegistro" ClientIDMode="Static" Value="1" runat="server" />
    <asp:HiddenField ID="hfFechaReciboDgii" ClientIDMode="Static" runat="server"/>
    
    <asp:HiddenField ID="hfMontoDgiiStr" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hfFechaDgiiStr" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hfEstadoDgiiStr" ClientIDMode="Static" runat="server" />

    <!-- Ajax Manager para Telerik -->
    <telerik:RadAjaxManager runat="server" ID="radAjaxMgr">
    </telerik:RadAjaxManager>
    
    <!-- Main Container -->
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1 id="creacion">
                    <span class="right normal">
                        <asp:Literal runat="server" ID="litNombreEmpresa" />
                    </span>Creación de Empresas
                </h1>
            </div>
            <div id="content_body">
                <div class="stepsTl" id="stepsTl">
                    <ul>
                        <li><a href="#" class="stepNobox">Solicitud</a></li>
                        <li><a href="#" class="stepDone">Datos Generales</a></li>
                        <li><a href="#" class="stepLast">Datos de la Empresa</a></li>
                        <li><a href="#">Verificación</a></li>
                        <li><a href="#">Pago por Servicios</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <fieldset class="form-fieldset">
                    <h2>
                        Datos Financieros de la Empresa</h2>
                    <h5>
                        Añade los socios, propietarios y/o accionistas de la empresa y la información financiera
                        de la empresa, luego presione el botón de "Siguiente". Si tienes alguna duda con
                        un término visita nuestro <a target="_blank" href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                            Glosario de Términos</a>. <strong>Los campos marcados con asteriscos (*) son obligatorios.</strong></h5>
                    <h3>
                        <a href="#" class="botoncillo" id="btnAddSocios" style="float: right;">Ingresar Propietario
                            / Socio / Accionista</a> Información de Propietarios/Socios/Accionistas</h3>
                    <!-- Call to action de socios -->
                    <div id="cto_socios">
                        <img alt="Ingresar el primer propietario, socio y/o accionista de la empresa." src="/res/img/cto_accionistas.jpg" />
                    </div>
                    <asp:HiddenField runat="server" ID="hfSosciosVisible" Value="1" ClientIDMode="Static" />
                    <!-- End Call to action de socios -->
                    <!-- Manejo de Socios -->
                    <div id="divManejoSocios">
                        <uc1:ManejoSocios ID="ManejoSocios1" runat="server" TipoRelacion="A" NumeroSocios="2"
                            EsModificacion="false" PropertyName="CantidadSocios" Enabled="True" />
                    </div>
                    <!-- End Manejo de Socios -->
                    <h5 class="sectDetail">
                        <asp:Literal runat="server" ID="litDescripcionSociedad" />
                    </h5>
                    <h3>
                        Información Financiera</h3>
                    <ul>
                        <li>
                            <label for="txtCapitalSocialActual">
                                <asp:Label ID="lbltxtCapitalSocialActual" runat="server" Visible="False"> Capital Social Actual 
                                </asp:Label>
                            </label>
                            <telerik:RadNumericTextBox ID="txtCapitalSocialActual" runat="server" CssClass="tb shortInput commentCtrl"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" Visible="False">
                            </telerik:RadNumericTextBox>
                        </li>
                        <li id="liCapitalSocial">
                            <label for="txtCapitalSocialNuevo">
                                <cc1:LabelOfv ID="lbltxtCapitalSocialNuevo" runat="server" PropertyName="CapitalSocial">Capital Social Autorizado</cc1:LabelOfv>
                                <cc1:SpanOfv runat="server" ID="spnTxtCapitalSocialNuevo" PropertyName="CapitalSocial"
                                    CssClass="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:NumericTextBoxOfv ID="txtCapitalSocialNuevo" runat="server" CssClass="tb shortInput commentCtrl"
                                MaxValue="999999999999.99" Culture="Spanish (Dominican Republic)" Type="Currency"
                                Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false"
                                PropertyName="CapitalSocial">
                            </cc1:NumericTextBoxOfv>
                            <asp:DropDownList runat="server" ID="ddlMonedaCapitalSocial" CssClass="shortdd" Enabled="False"
                                Visible="False" />
                            
                            
                                <cc1:CheckBoxOfv runat="server" ID="chkLlevaCapitalSocial" PropertyName="LibreCapitalSocial"
                                    ClientIDMode="Static" Visible="false"/>
                                <cc1:LabelOfv runat="server" ID="lblLlevaCapital" PropertyName="LibreCapitalSocial">
                                </cc1:LabelOfv>
                            
                            
                            <cc1:RequiredValidatorOfv ID="txtCapitalSocialNuevoReq" runat="server" SetFocusOnError="true"
                                ErrorMessage="El campo de capital social de la empresa es requerido." ControlToValidate="txtCapitalSocialNuevo"
                                CssClass="validator summary" ValidationGroup="3" ClientIDMode="Static" PropertyName="CapitalSocial"
                                Display="None" />
                            <cc1:RangeValidatorOfv ID="rvCapitalSocialNuevo" runat="server" CssClass="validator summary"
                                ErrorMessage="El capital social mínimo requerido para este tipo de empresa es <%= FormatDecimalString(rvCapitalSocialNuevo.MinimumValue) %>"
                                Type="Currency" MaximumValue="999999999999.99" MinimumValue="0.00" ValidationGroup="3"
                                ControlToValidate="txtCapitalSocialNuevo" PropertyName="CapitalSocial" Enabled="false"
                                Display="None" ClientIDMode="Static"></cc1:RangeValidatorOfv>
                            <div class="comments" id="MainContent_txtCapitalSocialNuevo_textComment">
                                Ingresa el
                                <cc1:SpanOfv runat="server" ID="spnCommentCapSocial1" PropertyName="CapitalSocial" />
                                de la empresa. El
                                <cc1:SpanOfv runat="server" ID="spnCommentCapSocial2" PropertyName="CapitalSocial" />
                                es el capital fijado en el acto constitutivo.
                                <asp:Literal runat="server" ID="litCapitalSocialComment" />
                            </div>
                        </li>
                        <li>
                            <label for="txtCapSuscrito">
                                <cc1:LabelOfv ID="lbltxtCapSuscrito" runat="server" PropertyName="CapitalSuscrito">Capital Suscrito y Pagado </cc1:LabelOfv>
                                <cc1:SpanOfv ID="spanCapSuscrito" runat="server" PropertyName="CapitalSuscrito" class="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:NumericTextBoxOfv ID="txtCapSuscrito" runat="server" CssClass="tb shortInput commentCtrl"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" PropertyName="CapitalSuscrito">
                            </cc1:NumericTextBoxOfv>
                            <asp:DropDownList runat="server" ID="ddlMonedaCapitalSuscrito" PropertyName="CapitalSuscrito"
                                CssClass="shortdd" Enabled="False" Visible="False" />
                            <cc1:RequiredValidatorOfv ID="txtCapSuscritoReq" runat="server" SetFocusOnError="true"
                                ErrorMessage="El campo de capital suscrito de la empresa es requerido." ControlToValidate="txtCapSuscrito"
                                CssClass="validator summary" ValidationGroup="3" ClientIDMode="Static" PropertyName="CapitalSuscritoReq"
                                Display="None"></cc1:RequiredValidatorOfv>
                            <div class="comments" id="MainContent_txtCapSuscrito_textComment">
                                Ingresa el capital suscrito de la empresa. 
                                <asp:Label runat="server" ID="lblCapSuscritoComment" Visible="false">
                                    El capital suscrito mínimo es el 10%
                                    del capital social autorizado. Para más información visita nuestro <a target="_blank"
                                    href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                    Glosario de Términos</a>.
                                    </asp:Label>
                            </div>
                        </li>
                        <li>
                            <asp:Label ID="lbltxtBienesRaices" runat="server" AssociatedControlID="txtBienesRaices"
                                Text="Bienes Raíces" />
                            <telerik:RadNumericTextBox ID="txtBienesRaices" runat="server" CssClass="tb shortInput commentCtrl"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false">
                            </telerik:RadNumericTextBox>
                            <asp:DropDownList runat="server" ID="ddlMonedaBienesRaices" CssClass="shortdd" Enabled="False"
                                Visible="False" />
                            <div class="comments" id="MainContent_txtBienesRaices_textComment">
                                Ingresa el valor total en RD$ de inmuebles y bienes raíces que la empresa posee.
                                Este valor puede ser cero. Este campo es opcional.</div>
                        </li>
                        <li>
                            <cc1:LabelOfv ID="lbltxtActivos" runat="server" AssociatedControlID="txtActivos"
                                PropertyName="Activos">Activos </cc1:LabelOfv>
                            <cc1:NumericTextBoxOfv ID="txtActivos" runat="server" CssClass="tb shortInput commentCtrl"
                                Culture="Spanish (Dominican Republic)" Type="Currency" Skin="" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" PropertyName="Activos" />
                            <asp:DropDownList runat="server" ID="ddlMonedaActivos" CssClass="shortdd" Enabled="False"
                                Visible="False" />
                            <div class="comments" id="MainContent_txtActivos_textComment">
                                Ingresa el valor total en RD$ de activos que la empresa posee. Este campo es opcional.</div>
                        </li>
                        <li>
                                        <label for="txtNoRecibo">
                                            <cc1:LabelOfv ID="lbltxtNoRecibo" runat="server" PropertyName="ReciboDGII">
                                            No. Recibo DGII
                                        </cc1:LabelOfv>
                                            <cc1:SpanOfv runat="server" ID="spnTxtNoRecibo" PropertyName="ReciboDGII" class="required">*</cc1:SpanOfv>
                                        </label>
                                        <cc1:TextBoxOfv ID="txtNoRecibo" runat="server"
                                            MaxLength="15" ClientIDMode="Static" PropertyName="ReciboDGII" 
                                            CssClass="tb shortInput commentCtrl" />
                                        &nbsp;
                                        <cc1:ButtonOfv runat="server" id="btnValidarNoRecibo" ClientIDMode="Static" 
                                            CssClass="btnSmall" PropertyName="ReciboDGII" Text="Validar"/>
                                        
                                        <img src="/res/img/icons/Progress.gif" alt="Esperando llamada remota" 
                                            id="imgWaiting" style="padding-left:6px; margin-top: px;"/>
                                        
                                        <div id="txtNoReciboComment" class="comments" >
                                            Ingresa el número de recibo del pago por impuesto de constitución.
                                            Para más información
                                            visita la <a href="https://www.dgii.gov.do/" target="_blank">Dirección General de Impuestos
                                                (DGII).</a>
                                        </div>
                                        &nbsp;
                                        <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="txtNoReciboReq" runat="server"
                                            ErrorMessage="El campo de número de recibo de la DGII  es requerido." ControlToValidate="txtNoRecibo"
                                            CssClass="validator summary" ValidationGroup="3" ClientIDMode="Static" PropertyName="ReciboDGII"
                                            Display="None"></cc1:RequiredValidatorOfv>
                                    </li>
                        <li>
                            <asp:Panel ID="pnlInformacionDGII" runat="server" ClientIDMode="Static" CssClass="PanelDgii">
                                <ul>
                                    <li>
                                        <label for="txtMontoDGII">
                                            <cc1:LabelOfv ID="lbltxtMontoDGII" runat="server" PropertyName="MontoReciboDGII">
                                            Monto Pagado DGII
                                      </cc1:LabelOfv>
                                        </label>
                                        <asp:Label ID="txtMontoDGII" runat="server" CssClass="tb shortInput commentCtrl"
                                            ClientIDMode="Static" ReadOnly="true" />
                                    </li>
                                    <li>
                                        <label for="radFechaRecibo">
                                            <cc1:LabelOfv ID="lblradFechaRecibo" runat="server" PropertyName="FechaReciboDGII">
                                                Fecha Recibo
                                      </cc1:LabelOfv>
                                        </label>
                                        <asp:Label ID="radFechaRecibo" runat="server"
                                            Enabled="False" ClientIDMode="Static"></asp:Label>
                                        <div class="clear">
                                        </div>
                                    </li>
                                    <li>
                                        <label for="txtEstadoReciboDgii">
                                            Estado del Recibo
                                        </label>
                                        <asp:Label runat="server" ID="txtRestadoReciboDgii" ClientIDMode="Static" />
                                    </li>
                                </ul>
                            </asp:Panel>
                        </li>
                        <li>
                            <label for="calInicioOperaciones">
                                Fecha de Inicio Operaciones
                                <cc1:SpanOfv runat="server" ID="spnFechaInicioReq" CssClass="required" PropertyName="FechaInicio">* </cc1:SpanOfv>
                            </label>
                            <telerik:RadDatePicker ID="calInicioOperaciones" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                CssClass="calendario" Nullable="True">
                            </telerik:RadDatePicker>
                            <cc1:RequiredValidatorOfv runat="server" ID="calInicioOperacionesReq" PropertyName="FechaInicio"
                                Display="None" ControlToValidate="calInicioOperaciones" ValidationGroup="3" ErrorMessage="El campo de fecha de inicio de operaciones de la empresa es requerido."
                                CssClass="validator summary" ClientIDMode="Static"></cc1:RequiredValidatorOfv>
                            <div class="comments" id="lblFechaInicioReqComment">
                                Oprime el botón del calendario y selecciona la fecha de inicio de operaciones de
                                la empresa. La fecha puede ser distinta a la fecha de constitución. Para más información
                                visita nuestro <a target="_blank" href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                    Glosario de Términos</a>
                            </div>
                            <div class="clear">
                            </div>
                        </li>
                        <li>
                            <label for="calUltimaAsamblea">
                                <cc1:LabelOfv runat="server" ID="lblcalUltimaAsamblea" PropertyName="FechaUltAsamblea">Fecha de Estatutos</cc1:LabelOfv>
                                <cc1:SpanOfv runat="server" ID="spnCalUltimaAsamble" PropertyName="FechaUltAsamblea"
                                    class="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:CalendarOfvRad ID="calUltimaAsamblea" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una fecha"
                                Nullable="True" VisibleDate="" CssClass="calendario" PropertyName="FechaUltAsamblea">
                            </cc1:CalendarOfvRad>
                            <cc1:RequiredValidatorOfv SetFocusOnError="true" ID="calUltimaAsambleaReq" ErrorMessage="El campo de fecha de la asamblea constitutiva es requerido."
                                runat="server" ControlToValidate="calUltimaAsamblea" CssClass="validator summary"
                                ValidationGroup="3" ClientIDMode="Static" PropertyName="FechaUltAsamblea" Display="None"></cc1:RequiredValidatorOfv>
                            <div class="comments" id="calUltimaAsambleaComment">
                                Oprime el botón del calendario y selecciona la fecha de la asamblea constitutiva
                                o de la ultima asamblea oficial de la empresa. Para más información visita nuestro
                                Glosario de Términos. <a target="_blank" href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                    Glosario de Términos</a>
                            </div>
                            <div class="clear">
                            </div>
                        </li>
                    </ul>
                    <h3>
                        Información Empresarial</h3>
                    <ul>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtDuracionSociedad" ID="lbltxtDuracionSociedad"> Duración de la Empresa</asp:Label>
                            <asp:DropDownList ID="ddlDuracionSociedad" runat="server" CssClass="sociedadIndefinidaDdl"
                                ClientIDMode="Static">
                                <asp:ListItem Text="Indefinida" Value="1" />
                                <asp:ListItem Text="A Tiempo Fijo" Value="2" />
                            </asp:DropDownList>
                            <asp:TextBox ID="txtDuracionSociedad" runat="server" CssClass="tb inputDuracionSociedad commentCtrl"
                                Width="80px" ClientIDMode="Static"></asp:TextBox>
                            <div class="comments" id="txtDuracionSociedadComment">
                                Selecciona si la duración de la empresa es a tiempo fijo o indefinida. En el caso
                                de que sea a tiempo fijo, especifique la duración en cantidad de años.
                            </div>
                        </li>
                        <li>
                            <label for="txtDuracionOrganoAdmin">
                                <cc1:LabelOfv runat="server" ID="lbltxtDuracionOrganoAdmin" PropertyName="DuracionConsejo">Duración del Órgano Administrativo </cc1:LabelOfv>
                                <cc1:SpanOfv runat="server" ID="spnDuracionOrganoAdmin" PropertyName="DuracionConsejo"
                                    CssClass="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:NumericTextBoxOfv ID="txtDuracionOrganoAdmin" runat="server" CssClass="tb commentCtrl"
                                Culture="Spanish (Dominican Republic)" MaxValue="99" MinValue="1" Type="Number"
                                Width="80px" Skin="" DataType="System.String" IncrementSettings-InterceptArrowKeys="false"
                                IncrementSettings-InterceptMouseWheel="false" PropertyName="DuracionConsejo">
                                <NumberFormat DecimalDigits="0" />
                            </cc1:NumericTextBoxOfv>
                            <cc1:RequiredValidatorOfv runat="server" ID="txtDuracionOrganoAdminReq" CssClass="validator summary"
                                ControlToValidate="txtDuracionOrganoAdmin" PropertyName="DuracionConsejo" ErrorMessage="La duración del órgano de administración es requerida"
                                ClientIDMode="Static" Display="None" />
                            <cc1:RangeValidatorOfv ID="rvDuracionConsejo" runat="server" CssClass="validator summary"
                                Type="Integer" MaximumValue="6" MinimumValue="0" ValidationGroup="3" ControlToValidate="txtDuracionOrganoAdmin"
                                PropertyName="DuracionConsejo" Enabled="false" Display="None" ClientIDMode="Static"></cc1:RangeValidatorOfv>
                            <div class="comments" id="MainContent_txtDuracionOrganoAdmin_textComment">
                                Ingresa la duración del consejo de dirección en cantidad de años.
                                <cc1:LabelOfv runat="server" ID="lblDuracionOrganoAdminComment" PropertyName="DuracionConsejo" />
                            </div>
                        </li>
                        <li>
                            <label for="rblEsEnteRegulado">
                                <cc1:LabelOfv runat="server" ID="lblrblEsEnteRegulado" PropertyName="EnteRegulado">Es Ente Regulado? </cc1:LabelOfv>
                                <cc1:SpanOfv runat="server" ID="spnRblEsEnteRegulado" PropertyName="EnteRegulado"
                                    class="required">*</cc1:SpanOfv>
                            </label>
                            <cc1:RadioButtonListOfv ID="rblEsEnteRegulado" runat="server" RepeatLayout="Flow"
                                RepeatDirection="Horizontal" ClientIDMode="Static" CssClass="radio-empleados radio commentCtrlHov"
                                PropertyName="EnteRegulado">
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </cc1:RadioButtonListOfv>
                            <cc1:RequiredValidatorOfv PropertyName="EnteRegulado" runat="server" ID="rfvEsEnteRegulado"
                                ControlToValidate="rblEsEnteRegulado" ValidationGroup="3" CssClass="validator summary"
                                ErrorMessage="El campo de ente regulado de la empresa es requerido." Display="none" />
                            <div class="comments" id="rblEsEnteReguladoComment">
                                Especifica si la empresa es un ente regulado. Los entes regulados son las empresas
                                que se rigen por una ley especial o entidad reguladora. Ej: banca, telecomunicaciones,
                                etc. En el caso de que sea regulada por una ley especial, selecciona la zona y ingresa
                                el número de resolución. Para más información visita nuestro <a target="_blank" href="http://www.camarasantodomingo.do/productos-y-servicios/registro-mercantil/glosario/">
                                    Glosario de Términos</a>.
                            </div>
                            <div class="clear">
                            </div>
                        </li>
                        <li>
                            <div id="pnlEmpresasReguladas" style="margin-left: 0px">
                                <ul>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="ddlTipoEnteRegulado" ID="lblddlTipoEnteRegulado"> Tipo de Ente</asp:Label>
                                        <asp:DropDownList ID="ddlTipoEnteRegulado" runat="server" CssClass="dd">
                                            <asp:ListItem>Por definir</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtNoResolucion" ID="lbltxtNoResolucion"> No. de Resolución</asp:Label>
                                        <asp:TextBox ID="txtNoResolucion" runat="server" CssClass="tb" Width="106px"></asp:TextBox>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <asp:Panel ID="pnlTipoDeAcciones" runat="server">
                                <ul>
                                    <li>
                                        <label for="rblTipoAccionesExtranjeras">
                                            <cc1:LabelOfv runat="server" ID="lblrblTipoAccionesExtranjeras" Visible="False" PropertyName="AccionesNominales">
                                            Tipo de Acciones  </cc1:LabelOfv>
                                        </label>
                                        <cc1:RadioButtonListOfv ID="rblTipoAccionesExtranjeras" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Table" CssClass="radio" Visible="False" PropertyName="AccionesNominales">
                                            <asp:ListItem>con valor nominal</asp:ListItem>
                                            <asp:ListItem>sin valor nominal</asp:ListItem>
                                        </cc1:RadioButtonListOfv>
                                        <cc1:RequiredValidatorOfv runat="server" ID="rfvTipoAccionesExtranjeras" ControlToValidate="rblTipoAccionesExtranjeras"
                                            PropertyName="AccionesNominales" ValidationGroup="3" CssClass="validator summary"
                                            ErrorMessage="El campo de tipo de acciones es requerido." Display="None" />
                                    </li>
                                </ul>
                            </asp:Panel>
                        </li>
                        <li id="liSucursales">
                            <label for="txtSucursales" id="lbltxtSucursales">
                                Sucursales</label>
                            <input type="text" id="txtSucursales" class="commentCtrl" />
                            <div class="comments" id="txtSucursalesComment">
                                Ingresa las sucursales que comprende su empresa separadas por coma. Ej: Sucursal
                                de Servicios, Sucursal Ejecutiva, etc. Este campo es opcional.</div>
                            <asp:HiddenField ID="hfTxtSucursales" ClientIDMode="Static" runat="server" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtEmpleadosM" ID="lbltxtEmpleadosM"> Empleados</asp:Label>
                            <asp:TextBox ID="txtEmpleadosM" runat="server" CssClass="tb inputEmpleados commentCtrl"
                                Title="Masculinos" autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                            &nbsp;
                            <asp:TextBox ID="txtEmpleadosF" runat="server" CssClass="tb inputEmpleados commentCtrl"
                                Title="Femeninos" autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                            <div class="comments" id="txtEmpleadosMComment">
                                Ingresa el número total de empleados de la empresa. Especifique aqúi la cantidad
                                de empleados masculinos.
                            </div>
                            <div class="comments" id="txtEmpleadosFComment">
                                Ingresa el número total de empleados de la empresa. Especifique aqúi la cantidad
                                de empleados femeninos.
                            </div>
                        </li>
                        <li>
                            <label>
                            </label>
                            <strong>Total: <span id="total-empleados"></span></strong>
                            </li>
                    </ul>
                    <h3>
                        Referencias y Registros</h3>
                    <ul>
                        <li id="liReferenciasComerciales">
                            <label for="txtReferenciasComerciales">
                                Referencias Comerciales
                            </label>
                            <input type="text" id="txtReferenciasComerciales" class="commentCtrl" />
                            <div id="txtReferenciasComercialesComment" class="comments">
                                Ingresa todas las referencias comerciales que desees, separando cada una utilizando
                                una coma .Ingresa las sucursales que comprende su empresa separadas por coma. Ej:
                                Sucursal de Servicios, Sucursal Ejecutiva, etc. Este campo es opcional.</div>
                            <asp:HiddenField ID="hfReferenciasComerciales" ClientIDMode="Static" runat="server" />
                        </li>
                        <li id="liReferenciasBancarias">
                            <asp:Label runat="server" AssociatedControlID="txtReferenciasBancarias" ID="lbltxtReferenciasBancarias"> Referencias Bancarias </asp:Label>
                            <asp:TextBox runat="server" ID="txtReferenciasBancarias" ClientIDMode="Static" class="commentCtrl" />
                            <asp:HiddenField ID="hfReferenciasBancarias" ClientIDMode="Static" runat="server" />
                            <div id="txtReferenciasBancariasComment" class="comments">
                                Ingresa las referencias bancarias de la empresas separadas por coma. Este campo
                                es opcional.</div>
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtNombreComercialNumero" ID="lbltxtNombreComercialNumero"> Registro de Nombre Comercial</asp:Label>
                            <telerik:RadTextBox ID="txtNombreComercialNumero" runat="server" EmptyMessage="No. registro"
                                Width="100px" CssClass="tb commentCtrl" Skin="">
                            </telerik:RadTextBox>
                            <cc1:ButtonOfv runat="server" id="btnValidarReciboOnapi" ClientIDMode="Static" 
                                            CssClass="btnSmall" PropertyName="validacionOnapi" 
                                Text="Validar" onclick="btnValidarReciboOnapi_Click" Visible ="false" />&nbsp;&nbsp;<img src="/res/img/icons/Progress.gif" alt="Esperando llamada remota" 
                                                                                                    id="imgWaitingOnapi" style="padding-left:6px; margin-top: px;"/> 
                                <br />
                            <telerik:RadTextBox ID="txtNombreComercialDesc" runat="server" EmptyMessage="Nombre Comercial"
                                Width="195px" CssClass="tb commentCtrl" Skin="">
                            </telerik:RadTextBox>
                            <div class="comments" id="MainContent_txtNombreComercialNumero_textComment">
                                Ingresa el número del registro comercial aprobado por ONAPI. Para más información
                                visita la <a target="_blank" href="http://onapi.gob.do/">Oficina Nacional de la Propiedad
                                    Industrial (ONAPI)</a>. Este campo es opcional.</div>
                            <div class="comments" id="MainContent_txtNombreComercialDesc_textComment">
                                Ingresa el nombre del registro comercial aprobado por ONAPI. Para más información
                                visita la <a target="_blank" href="http://onapi.gob.do/">Oficina Nacional de la Propiedad
                                    Industrial (ONAPI)</a>. Este campo es opcional.</div>
                        </li>
                        <li>
                            <div class="footer_go">
                                <asp:Button ID="btnDatosFinancierosLlenos" runat="server" Text="Siguiente" OnClick="btnDatosFinancierosLlenos_Click"
                                    ValidationGroup="3" CssClass="btn btnFormNext" /><div style="clear: both;">
                                    </div>
                            </div>
                        </li>
                        <li>
                        </li>
                    </ul>
                </fieldset>
                <asp:ValidationSummary runat="server" ID="errorbox" HeaderText="&lt;p&gt;Hemos detectado uno ó múltiples errores en la información sometida en tu solicitud.
                        Por favor verifica los errores listados e intenta nuevamente.&lt;/p&gt;"
                    ClientIDMode="Static" ValidationGroup="3" DisplayMode="List" />
                    
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
                        
</asp:Content>
