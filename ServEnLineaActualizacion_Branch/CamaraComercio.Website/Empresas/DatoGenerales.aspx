<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DatoGenerales.aspx.cs" Inherits="CamaraComercio.Website.Empresas.DatoGenerales" %>

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

                                         <br />



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
