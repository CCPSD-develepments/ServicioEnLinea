<%@ Page Title="" Language="C#" MasterPageFile="~/res/ccpsd.Master" AutoEventWireup="true" CodeBehind="VentanillaUnica.aspx.cs" Inherits="CamaraComercio.Website.VentanillaUnica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- Scripts -->
    <script src="/res/js/fancybox/jquery.fancybox-1.3.1.js" type="text/javascript"></script>
    <script src="/res/js/fancybox/jquery.easing-1.3.pack.js" type="text/javascript"></script>
    
    <!-- CSS -->
    <link href="/res/js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />

    <!-- Inline Page Script -->
    <script type="text/javascript">
        var validateSession = false;

        $(document).ready(function () { 
            $('#btnNombreComercial').fancybox();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainDescription">
        <h3>
            Pasos para el registro de una nueva empresa
        </h3>
    </div>
    
    <div class="stepbox">
      <div class="step-header">
    <h1>1. Reg. Nombre Comercial    </h1>
    </div>
    <div class="step-content">
      <p>La Oficina Nacional de Registro de la Propiedad Industrial (ONAPI) es la entidad 
          encargada del registro de los nombres comerciales en nuestros país. </p>
      <ul>
        <li>Costo: RD$3,776.00</li>
        <li>Vías de solicitud: Presencial y Online</li>
          <li>Tiempo entrega: 5 días </li>
        </ul>
    <%--<input name="button" type="submit" class="btn" id="btnNombreComercial" value="Portal Web de ONAPI" />--%>
    <a href="/VU/onapi.htm" class="btn" id="btnNombreComercial">Portal Web de ONAPI</a>
    </div>
    </div>
    <div class="stepbox">
      <div class="step-header">
        <h1>2. Pago Impuestos DGII</h1>
      </div>
      <div class="step-content">
        <p>La constitución de una nueva empresa requiere el pago del impuesto de registro de 
            nuevas empresas en la Dirección General de Impuestos Internos (DGII)</p>
          <ul>
              <li>Costo: % del Capital Social</li>
              <li>Vía de solicitud: Presencial, Online y en Bancos nacionales</li>
              <li>Tiempo entrega: Inmediato.</li>
          </ul>
          <input name="button2" type="submit" class="btn" id="btnImpuestoDgii" value="Pagar el impuesto" />
      </div>
    </div>
    <div class="stepbox">
      <div class="step-header">
        <h1>3. Registro Mercantil CCPSD</h1>
      </div>
      <div class="step-content">
        <p>Para la emisión del registro mercantil es necesario llenar el formulario en línea 
            o proceder a cualquiera de las cámaras de comercio del país. </p>
        <ul>
          <li>Costo: % del Capital Social</li>
          <li>Vía de solicitud: Presencial y Online <br />
          </li>
          <li>Tiempo entrega: 1 semana<br />
            </li>
        </ul>
        <input name="button3" type="submit" class="btn" id="btnRegMercantil" value="Ir a Oficina Virtual" />
      </div>
    </div>
    <div class="stepbox">
      <div class="step-header">
        <h1>4. Emision del RNC</h1>
      </div>
      <div class="step-content">
        <p>Luego de emitido el Registro Mercantil, se debe solicitar la inscripción en el 
            RNC. Documento necesario para tributar y operar como empresa/sociedad. </p>
        <ul>
          <li>Costo: Gratis</li>
          <li>Vía de solicitud: Presencial y Online</li>
            <li>Tiempo entrega: 3 días?</li>
        </ul>
        <input name="button4" type="submit" class="btn" id="button4" value="Ir a solicitud RNC" />
      </div>
    </div>
    <div class="clear" />
</asp:Content>
