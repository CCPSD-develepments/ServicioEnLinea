<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DatosGenerales.aspx.cs" Inherits="CamaraComercio.Website.Empresas.DatosGenerales" %>

<%@ MasterType VirtualPath="~/res/nobox.Master" %>
<%@ Register Src="~/UserControls/ManejoSocios.ascx" TagName="ManejoSocios" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Submenu.ascx" TagName="Submenu" TagPrefix="uc1" %>
<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        .auto-style1 {
            width: 100%;
            table-layout: auto;
        }
        .upper-case
        {
            text-transform: uppercase
        }
    </style>

    <!-- Plugins -->
    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/jquery.fieldtag.js" type="text/javascript"></script>
    
    <script src="/res/js/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>

    <script src="/res/lib/chosen/docsupport/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="/res/lib/chosen/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.pack.js" type="text/javascript"></script>
    <script src="/Empresas/TextboxList.js" type="text/javascript"></script>
    <script src="/Empresas/TextboxList.Autocomplete.js" type="text/javascript"></script>
    <script src="/res/js/fbTextbox/GrowingInput.js" type="text/javascript"></script>
	<script src="/res/js/jquery.maskedinput-1.4.1.min.js" type="text/javascript"></script>
    <!-- Javascript de este formulario -->
    <script type="text/javascript" src="/res/js/ui.adecuacion.js"></script>

    <!-- Inline user script -->
    <script type="text/javascript" language="javascript">
        var validateSession = false;
        //dataUpdate:
        var _UpdConta = "";
        var _UpdCoEmp = "";

        var _UpdT1 = "";
        var _UpdT2 = "";


        $.noConflict();
        jQuery(document).ready(function ($) {

      //  debugger;

            _UpdConta = document.getElementById('<%=txtCorreoContacto.ClientID%>').value;
            _UpdCoEmp = document.getElementById('<%=txtCorreoEmpresa.ClientID%>').value;

            _UpdT1 = document.getElementById('<%=txtTelefonoCasa.ClientID%>').value;
            _UpdT2 = document.getElementById('<%=txtTelefonoOficina.ClientID%>').value;


            SetDefault();

            //Menu
            $('#subnavigation li').removeClass("active");
            $('#liConsultas').addClass("active");

            function updateEmpleadosTotales() {
                var empleadosM = Number($('#txtEmpleadosM').val());
                var empleadosF = Number($('#txtEmpleadosF').val());

                if (isNaN(empleadosM)) empleadosM = 0;
                if (isNaN(empleadosF)) empleadosF = 0;

                $('#txtEmpleadosT').val(empleadosM + empleadosF);
            }

            updateEmpleadosTotales();
            $('#txtEmpleadosM').on('input', function () {
                this.value = this.value.replace(/\D/g, '');
                updateEmpleadosTotales();
            });
            $('#txtEmpleadosF').on('input', function () {
                this.value = this.value.replace(/\D/g, '');
                updateEmpleadosTotales();
            });

            $('#MainContent_txtRnc_text').on('input', function () {
                this.value = this.value.replace(/\D/g, '');
            });

            //Instanciando el control de Facebook Tags para las referencias comerciales
            t2 = new $.TextboxList('#txtReferenciasComerciales', { bitsOptions: { editable: { addKeys: [106] } } });
            t2.addEvent('focus', function () { showdiv('#txtReferenciasComercialesComment'); });
            t2.addEvent('bitBoxAdd', function (newEntry) {
                if (typeof newEntry != 'undefined') {
                    if (newEntry.value[1] == "") {
                        newEntry.remove();
                        $('#txtReferenciasBancarias').focus();
                    }
                }
            });
            t2.addEvent('blur', function () {
                hidediv('#txtReferenciasComercialesComment');

                //Se verifica si hay objetos en edicion
                var controlEdicion = $('#liReferenciasComerciales .textboxlist-bit-editable-input:last');
                var valorActual = controlEdicion.val();
                if (typeof valorActual != 'undefined' && valorActual.length > 0) {
                    controlEdicion.val("");
                    t2.add(valorActual);
                }

                //Tab en blanco para salir del control
                var arr = t2.getValues();
                var str = "";
                var cant = arr.length;

                //Asignacion de valores en el Hidden Field
                for (var i = 0; i < cant; i++) {
                    str += arr[i][1];
                    if (i != cant - 1) str += "*";
                }
                $('#hfReferenciasComerciales').val(str);
            });

            //Instanciando el control chosen para las referencias bancarias
            var $dropdown = $('#ddlReferenciasBancarias');
            $dropdown.attr('data-placeholder', 'Seleccione un Banco');
            $dropdown.chosen({
                no_results_text: 'No se han encontrado resultados',
                width: '350px'
            });




        });





        function SetDefault() {
         //   debugger;

            var _CorreoContacto = document.getElementById('<%=txtCorreoContacto.ClientID%>').value;
            var _CorreoEmpresa = document.getElementById('<%=txtCorreoEmpresa.ClientID%>').value;

            _TL1 = document.getElementById('<%=txtTelefonoCasa.ClientID%>').value;
            _TL2 = document.getElementById('<%=txtTelefonoOficina.ClientID%>').value;

            var mySave = document.getElementById('<%= this.btnSave.ClientID %>');
            var mySaveEmpty = document.getElementById('<%= this.btnSaveEmpty.ClientID %>');
            

            if (_CorreoContacto == "" || _CorreoEmpresa == "") {
                             
                $(mySave).attr('disabled', 'disabled');              
              
                $(mySave).hide();
                $(mySaveEmpty).show();

                document.getElementById('<%=btnSaveEmpty.ClientID %>').style.display = "block";
      

            }
            else {
                ValidateEmail(_CorreoContacto);
                ValidateEmail(_CorreoEmpresa);

                $(mySave).removeAttr('disabled');            
                        
                $(mySave).show();
                $(mySaveEmpty).hide();

                var x = document.getElementById('<%=txtCorreoEmpresa.ClientID%>').value;   

                if (_CorreoContacto != _UpdConta || _CorreoEmpresa != _UpdCoEmp) {

                    document.getElementById('<%=btnSave.ClientID%>').value = 'Actualizar';
                }

                if (_TL1 != _UpdT1 || _TL2 != _UpdT2) {

                    document.getElementById('<%=btnSave.ClientID%>').value = 'Actualizar';
                 }
            }

          
            
        }



        function myFunction(btn) {       
                       
            document.getElementById('<%=btnSaveEmpty.ClientID %>').style.display = "block";
         //   alert("Button has been disabled.");
       }
            

        function TrimIt(sender, args) {
         //   debugger;
            var value = args.get_newValue();
            var trimmed = value.replace(/^\s+|\s+$/g, '');
            args.set_newValue(trimmed);
        }

        function ValidateEmail(field) {// field is the textbox.
          //  debugger;
            if (!checkEmail(field.replace(/ /g, ''))) {
                {
                 //   alert("Invalid Email: " + field);
                    //  field.focus();

                    var mySave = document.getElementById('MainContent_btnSave');
                    var mySaveEmpty = document.getElementById('MainContent_btnSaveEmpty');

                    $(mySave).attr('disabled', 'disabled');

                    $(mySave).hide();
                    $(mySaveEmpty).show();

                    document.getElementById('MainContent_btnSaveEmpty').style.display = "block";

                    //rojos:
                    document.getElementById('MainContent_EmpEmailValidatorEmpty').style.color = "red";
                    document.getElementById('MainContent_EmpEmailValidatorValid').style.color = "red";

                    document.getElementById('MainContent_ContemailValidatorEmpty').style.color = "red";
                    document.getElementById('MainContent_ContEmailValidatorValid').style.color = "red";

                }
            }
        }
        
        function checkEmail(email) {
            var regex = /(^[a-z]([a-z_\.]*)@([a-z_\.]*)([.][a-z]{3})$)|(^[a-z]([a-z_\.]*)@([a-z_\.]*)(\.[a-z]{3})(\.[a-z]{2})*$)/i;
            return regex.test(email);
        }


        function MostrarDialogMensaje() {

            document.getElementById('<%=btnSaveEmpty.ClientID %>').style.display = "block";

            $("#modal_dialog").dialog({

                title: "Validación de datos.",
                height: 250,
                width: 630,

                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },

                modal: true

            });

            return false;
        };



    </script>
</asp:Content>
<asp:Content ID="cntSubmenu" ContentPlaceHolderID="SubMenu" runat="server">
    <uc1:Submenu ID="Submenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <!-- Ajax Manager para Telerik -->
    <telerik:RadAjaxManager runat="server" ID="radAjaxMgr">
    </telerik:RadAjaxManager>

    <div class="container_24">
        <div class="grid_24">
            <div class="datos_form">
                <div id="content_header">
                    <h1 id="detalles">
                        <span class="right normal">
                            <asp:Literal ID="litTitulo" runat="server" Text="" />
                        </span>
                        Actualizar Datos Generales
                    </h1>
                </div>
                <div id="content_body">
                    <asp:MultiView runat="server" ID="mainMultiView" ActiveViewIndex="0">
                        <asp:View runat="server" ID="succesfullView">
                            <fieldset class="form-fieldset">

                                  <br />
                    <asp:Panel runat="server" ID="pnlComentarioServicio" Visible="false"  CssClass="sectDetail" >                    
                        <strong style="font-size: 15px;">
                            <asp:Label ID="lblMensaje" runat="server" style="color:black" Visible="False" CssClass="sectDetail" BorderStyle="None"></asp:Label>
                        </strong>                    
                </asp:Panel>
                <br />


                                <ul>


                                     <asp:Panel id="pnlDatosGenerales"  runat="server"> 


                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtNombreComercial">
                                        Denominación/ Razón Social <span class="required"></span>
                                        </asp:Label>
                                        <telerik:RadTextBox ID="txtNombreComercial" runat="server" ReadOnly="true" CssClass="tb" Width="350px" EmptyMessage="Nombre Comercial" Skin="" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtRnc">
                                        Rnc <span class="required"></span>
                                        </asp:Label>
                                        <telerik:RadMaskedTextBox ID="txtRnc" runat="server" ReadOnly="false" CssClass="tb" EmptyMessage="Rnc" Skin="" Mask="#-##-#####-#" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtEmpleadosM" ID="lbltxtEmpleadosM">Empleados Masculinos</asp:Label>
                                        <asp:TextBox ID="txtEmpleadosM" runat="server" CssClass="tb inputEmpleados commentCtrl"
                                            Title="Empleados Masculinos" autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                                        <div class="comments" id="txtEmpleadosMComment">
                                            Ingresa el número total de empleados de la empresa. Especifique aqúi la cantidad de empleados masculinos.
                                        </div>
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtEmpleadosF" ID="lbltxtEmpleadosF">Empleados Femeninos</asp:Label>
                                        <asp:TextBox ID="txtEmpleadosF" runat="server" CssClass="tb inputEmpleados commentCtrl"
                                            Title="Empleados Femeninos" autocomplete="off" Width="90px" ClientIDMode="Static"></asp:TextBox>
                                        <div class="comments" id="txtEmpleadosFComment">
                                            Ingresa el número total de empleados de la empresa. Especifique aqúi la cantidad de empleados femeninos.
                                        </div>
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtEmpleadosT" ID="lbltxtEmpleadosT">Empleados Totales</asp:Label>
                                        <asp:TextBox ID="txtEmpleadosT" runat="server" CssClass="tb inputEmpleados" ReadOnly="true" Title="Empleados Total" Width="90px" ClientIDMode="Static"></asp:TextBox>
                                    </li>


                         </asp:Panel>




                                    <asp:Panel id="pnlCorreos"  runat="server"> 

                                          <li>

                                        <asp:Label runat="server" AssociatedControlID="txtCorreoEmpresa">
                                        Correo de Empresa <span class="required"></span>                                          
                                            <span class="spanRed">*</span>
                                        </asp:Label>                                                
                                               
                                        <%--<telerik:RadTextBox ID="txtCorreoEmpresa" runat="server" CssClass="tb" 
                                            Width="250px" EmptyMessage="Correo de Empresa" Skin="" EmptyMessageStyle-ForeColor="#cccccc" onchange="SetDefault();" onpaste="this.onchange();" />--%>

                                                <telerik:RadTextBox ID="txtCorreoEmpresa" runat="server" CssClass="tb" Width="250px" 
                                          onchange="SetDefault();"    EmptyMessage="Correo de Empresa" Skin="" EmptyMessageStyle-ForeColor="#cccccc" >
                                            <ClientEvents OnValueChanging="TrimIt" />
                                          </telerik:RadTextBox>

                                          <asp:RegularExpressionValidator ID="EmpEmailValidatorValid" runat="server" Display="Dynamic"
                                            ErrorMessage="Por favor, ingresar un correo electrónico valido."
                                              ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                            ControlToValidate="txtCorreoEmpresa">
                                          </asp:RegularExpressionValidator>
                                          <asp:RequiredFieldValidator ID="EmpEmailValidatorEmpty" runat="server" Display="Dynamic"
                                            ControlToValidate="txtCorreoEmpresa" ErrorMessage="Por favor, ingresar un correo electrónico!" />



                                             
                                    </li>
                              

                                        <li>
                                            <asp:Label runat="server" AssociatedControlID="txtCorreoContacto">
                                               Correo de Contacto <span class="spanRed">*</span>  <br /> de la solicitud <span class="required"></span>                                                                                                 
                                      </asp:Label>
                                       
                                                                                        

                                         <telerik:RadTextBox ID="txtCorreoContacto" runat="server" CssClass="tb" Width="250px" 
                                          onchange="SetDefault();"    EmptyMessage="Correo de Contacto" Skin="" EmptyMessageStyle-ForeColor="#cccccc" >
                                            <ClientEvents OnValueChanging="TrimIt" />
                                          </telerik:RadTextBox>

                                          <asp:RegularExpressionValidator ID="ContEmailValidatorValid" runat="server" Display="Dynamic"
                                            ErrorMessage="Por favor, ingresar un correo electrónico valido."
                                              ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                            ControlToValidate="txtCorreoContacto">
                                          </asp:RegularExpressionValidator>
                                          <asp:RequiredFieldValidator ID="ContemailValidatorEmpty" runat="server" Display="Dynamic"
                                            ControlToValidate="txtCorreoContacto" ErrorMessage="Por favor, ingresar un correo electrónico!" />

                                        </li>





</asp:Panel>

                                      <asp:Panel id="pnlPaginasWeb"  runat="server"> 

                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtPaginaWeb">
                                        Página Web
                                        </asp:Label>
                                        <telerik:RadTextBox ID="txtPaginaWeb" runat="server" CssClass="tb" Width="250px" EmptyMessage="Página Web" Skin="" />
                                    </li>

                                          </asp:Panel>


<%--                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtApartadoPostal">
                                        Apartado Postal
                                        </asp:Label>
                                        <telerik:RadTextBox ID="txtApartadoPostal" runat="server" CssClass="tb" EmptyMessage="Apartado Postal" Skin="" />
                                    </li>--%>

                                    <asp:Panel id="pnlTelefonos"  runat="server"> 

                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtTelefonoCasa">
                                        Teléfono Casa
                                        </asp:Label>
                                        <telerik:RadMaskedTextBox ID="txtTelefonoCasa" runat="server" CssClass="tb"  
                                            EmptyMessage="Teléfono Casa" Skin="" EmptyMessageStyle-ForeColor="#cccccc" Mask="(###) ###-####" onchange="SetDefault();" onpaste="this.onchange();" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtTelefonoOficina">
                                        Teléfono Oficina
                                        </asp:Label>
                                        <telerik:RadMaskedTextBox ID="txtTelefonoOficina" runat="server" CssClass="tb" EmptyMessage="Teléfono Oficina" 
                                            Skin="" EmptyMessageStyle-ForeColor="#cccccc" Mask="(###) ###-####" onchange="SetDefault();" onpaste="this.onchange();" />
                                        <%--<telerik:RadTextBox ID="txtExtension" runat="server" CssClass="tb" Width="60px" EmptyMessage="Extensión" Skin="" />--%>
                                    </li>


                            </asp:Panel>



                                     <asp:Panel id="pnlFaxSocios"  runat="server"> 


                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtFax">
                                        Fax
                                        </asp:Label>
                                        <telerik:RadMaskedTextBox ID="txtFax" runat="server" CssClass="tb" EmptyMessage="Fax" Skin="" Mask="(###) ###-####" />
                                    </li>



                                    <li style="visibility:hidden">
                                        <asp:Label runat="server" AssociatedControlID="txtFechaAsamblea">
                                        Fecha Última Asamblea
                                        </asp:Label>
                                        <telerik:RadDatePicker ID="txtFechaAsamblea" runat="server" Culture="es-DO" ImageUrl="/res/img/calendar.png"
                                            Text="" ControlDisplay="TextBoxImage" GoToTodayText="Hoy" NullableLabelText="Seleccione una Fecha"
                                            CssClass="calendario" Nullable="True" Calendar-RangeMinDate="1/1/1900 12:00:00 AM" MinDate="1/1/1900 12:00:00 AM">
                                            <DateInput runat="server" DateFormat="dd/MM/yyyy"></DateInput>
                                        </telerik:RadDatePicker>
                                    </li>
                                    <li id="liReferenciasComerciales">
                                        <label for="txtReferenciasComerciales">
                                            Referencias Comerciales
                                        </label>
                                        <asp:TextBox ID="txtReferenciasComerciales" ClientIDMode="Static"  style="text-transform:uppercase;" runat="server" CssClass="commentCtrl" />
                                        <asp:HiddenField ID="hfReferenciasComerciales" ClientIDMode="Static" runat="server" />
                                        <div id="txtReferenciasComercialesComment" class="comments">
                                            Ingresa todas las referencias comerciales que desees, separando cada una utilizando
                                            un asterisco .Ingresa las sucursales que comprende su empresa separadas por coma. Ej:
                                            Sucursal de Servicios, Sucursal Ejecutiva, etc. Este campo es opcional.
                                        </div>
                                    </li>
                                    <li id="liReferenciasBancarias">
                                        <asp:Label runat="server" AssociatedControlID="ddlReferenciasBancarias" ID="lbltxtReferenciasBancarias"> Referencias Bancarias </asp:Label>
                                        <%--<select id="ddlReferenciasBancarias" runat="server" clientidmode="Static" class="commentCtrl"></select>--%>
                                        <asp:ListBox runat="server" ID="ddlReferenciasBancarias" ClientIDMode="Static" CssClass="commentCtrl" SelectionMode="Multiple"></asp:ListBox>
                                        <%--<asp:DropDownList ID="ddlReferenciasBancarias" runat="server" ClientIDMode="Static" Width="350px" CssClass="commentCtrl"></asp:DropDownList>--%>
                                        <div id="ddlReferenciasBancariasComment" class="comments">
                                            Ingresa las referencias bancarias de la empresa. Este campo es opcional.
                                        </div>
                                    </li>
                                    <li>
                                        <div class="RadGrid RadGrid_NoboxGrid">
                                            <table class="auto-style1" style="empty-cells: show;" cellspacing="0">
                                                <thead>
                                                    <tr>
                                                        <th class="rgHeader"></th>
                                                        <th class="rgHeader">Socio</th>
                                                        <th class="rgHeader">Dirección</th>
                                                        <th class="rgHeader">Nacionalidad</th>
                                                        <th class="rgHeader">Estado Civil</th>
                                                        <th class="rgHeader">Documento de Identidad</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="sociosRepeater" runat="server" OnItemCommand="sociosRepeater_ItemCommand">
                                                        <ItemTemplate>
                                                            <tr class="rgRow">
                                                                <td style="width: 16px">
                                                                    <asp:ImageButton ID="linkEditSocio" runat="server" ImageUrl="/res/img/icons/Edit.gif" AlternateText="Editar" ToolTip="Editar" BorderWidth="0px" CommandName="Edit" CommandArgument='<%# Eval("SrmId") %>' />
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <%# Eval("PersonaPrimerNombre") + " " + Eval("PersonaSegundoNombre") + " " + Eval("PersonaPrimerApellido") + " " + Eval("PersonaSegundoApellido") %>
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <%# Eval("DireccionCalle") + " " + Eval("DireccionNombreSector") + ", " + Eval("DireccionNombreCiudad") %>
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <%# Eval("Nacionalidad") %>
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <%# Eval("PersonaEstadoCivil") %>
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <%# Eval("Documento") %>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </li>


  </asp:Panel>

                                   

                                    <li>
                                        <div class="footer_go">

                                            <asp:Button ID="btnSave" runat="server" Text="Completar" OnClick="btnSave_Click" CssClass="btn btnFormNext" />  
                                            <asp:Button  style="BACKGROUND-COLOR: lightgrey" ID="btnSaveEmpty" runat="server" Text="Completar" 
                                                OnClientClick="MostrarDialogMensaje(this); return false;"  CssClass="btn btnFormNext" />

                                                                                                                                
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" CssClass="btn btnFormNext" />

                                           

                                            <div style="clear: both;" />
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                        </asp:View>
                        <asp:View runat="server" ID="socioEditView">
                            <fieldset class="form-fieldset">
                                <ul>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="ddlSocioPais">Nacionalidad</asp:Label>
                                        <asp:DropDownList ID="ddlSocioPais" runat="server" CssClass="tb widestInput"></asp:DropDownList>
                                    </li>
                                    <li>
                                        <asp:HiddenField ID="txtSocioId" runat="server" />
                                        <asp:Label runat="server" AssociatedControlID="txtSocioNombre">Nombre</asp:Label>
                                        <telerik:RadTextBox ID="txtSocioNombre" runat="server" ReadOnly="true" CssClass="tb widestInput" Width="300px" EmptyMessage="Nombre" Skin="" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" ID="lblSocioDocumento" AssociatedControlID="txtSocioDocumento">Documento</asp:Label>
                                        <telerik:RadTextBox ID="txtSocioDocumento" runat="server" CssClass="tb widestInput" Width="180px" EmptyMessage="Documento" Skin=""  ReadOnly ="true"/>
                                    </li>
                                    <li>
                                        <div runat="server" Id="divEstadoCivil">
                                            <asp:Label runat="server" AssociatedControlID="ddlSocioEstadoCivil">Estado Civil</asp:Label>
                                            <asp:DropDownList ID="ddlSocioEstadoCivil" runat="server" CssClass="tb widestInput">
                                                <asp:ListItem value ="D" Text="Selecione"/>
                                                <asp:ListItem Value="C" Text="Casado(a)" />
                                                <asp:ListItem Value="S" Text="Soltero(a)" />
                                            </asp:DropDownList>
                                        </div>
                                        
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="ddlSocioCiudades">Ciudad</asp:Label>
                                        <asp:DropDownList ID="ddlSocioCiudades" runat="server" CssClass="tb widestInput" AutoPostBack="true" OnSelectedIndexChanged="ddlSocioCiudades_SelectedIndexChanged"></asp:DropDownList>
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="ddlSocioSectores">Sector</asp:Label>
                                        <asp:DropDownList ID="ddlSocioSectores" runat="server" CssClass="tb widestInput" AutoPostBack="true"></asp:DropDownList>
                                    </li>
                                    <li>
                                        <asp:Label runat="server" AssociatedControlID="txtSocioDireccionCalle">Calle</asp:Label>
                                        <telerik:RadTextBox ID="txtSocioDireccionCalle" runat="server" style="text-transform:uppercase;" CssClass="tb widestInput" Width="350px" EmptyMessage="Calle" Skin="" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" ID="lblSocioDireccionNumero" AssociatedControlID="txtSocioDireccionNumero">Número</asp:Label>
                                        <telerik:RadTextBox ID="txtSocioDireccionNumero" runat="server" CssClass="tb widestInput" EmptyMessage="Número" Skin="" />
                                    </li>
                                    <li>
                                        <asp:Label runat="server" ID="lblSocioDireccionApartadoPostal" AssociatedControlID="txtSocioDireccionApartadoPostal">Apartado Postal</asp:Label>
                                        <telerik:RadTextBox ID="txtSocioDireccionApartadoPostal" runat="server" CssClass="tb widestInput" EmptyMessage="Apartado Postal" Skin="" />
                                    </li>
                                    <li>
                                        <div class="footer_go">
                                            <asp:Button ID="btnSaveSocio" runat="server" Text="Actualizar" OnClick="btnSaveSocio_Click" CssClass="btn btnFormNext" />
                                            <asp:Button ID="btnCancelSocio" runat="server" Text="Cancelar" OnClick="btnCancelSocio_Click" CssClass="btn btnFormNext" />
                                            <div style="clear: both;" />
                                        </div>
                                    </li>
                                </ul>
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
    </div>



        <div class="clear"></div>    
    <div id="modal_dialog" style="display: none">
         <br />
       
            <h5> Favor completar los datos de Correo Electrónico marcados con asterisco (*).</h5>
        
       
       <br />
        

       
        
</div>

</asp:Content>
