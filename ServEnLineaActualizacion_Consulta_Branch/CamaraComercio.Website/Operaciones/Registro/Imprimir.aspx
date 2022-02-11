<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imprimir.aspx.cs" Inherits="CamaraComercio.Website.Operaciones.Registro.Imprimir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Impresion de Formulario</title>
    <script type="text/javascript">
    </script>
    <link href="/res/css/stylesPrint.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body onload="javascript:window.print();">
    <form id="form1" runat="server">
    <div id="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="width: 100%">
                    <h1 class="maintitle">
                        Registro Mercantil - Datos Enviados via Portal Web</h1>
                </td>
            </tr>
            <tr>
                <td class="tituloFormCell">
                    <table class="style1">
                        <tr>
                            <td width="50%">
                                <table width="100%" border="0" cellspacing="10" cellpadding="0">
                                    <tr>
                                        <td>
                                            <p style="font-size: medium; color: #000000;">
                                                Número de Cita</p>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNoCita" runat="server" Style="font-size: medium" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p style="font-size: medium; color: #000000;">
                                                Fecha de Cita</p>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFechaCita" runat="server" Style="font-size: medium" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <asp:Image ID="imgCodigoBarras" runat="server" Height="70px" Width="200px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div class="warning">
                        <p>
                            Recuerde que para poder reclamar su cita debe presentarse por lo menos 20 minutos
                            antes de la hora indicada.
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <h1>
                                    Confirmación de datos</h1>
                            </td>
                            <td class="pasoForm">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td class="confirm_tab" valign="top">
                                <div>
                                    Datos Generales</div>
                            </td>
                            <td class="confirm_data">
                                <table width="100%" class="confirm_title">
                                    <tr>
                                        <td colspan="2">
                                            <h2>
                                                Información de Registro</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            No. Registro
                                        </td>
                                        <td>
                                            <asp:Literal ID="litNoRegistro" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            RNC
                                        </td>
                                        <td>
                                            <asp:Literal ID="litRnc" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Razón Social / Cédula
                                        </td>
                                        <td>
                                            <asp:Literal ID="litRazonSocial" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Tipo de Empresa
                                        </td>
                                        <td>
                                            <asp:Literal ID="litTipoEmpresa" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Fecha de Emisión
                                        </td>
                                        <td>
                                            <asp:Literal ID="litFechaEmision" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Fecha Vencimiento
                                        </td>
                                        <td>
                                            <asp:Literal ID="litFechaVencimiento" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Nacionalidad
                                        </td>
                                        <td>
                                            <asp:Literal ID="litNacionalidad" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title" colspan="2">
                                            <h2>
                                                Informacion de Contacto</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Dirección
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDireccion" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Teléfono Primario
                                        </td>
                                        <td>
                                            <asp:Literal ID="litTelefonoPrimario" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Teléfono Secundario
                                        </td>
                                        <td>
                                            <asp:Literal ID="litTelefonoSecundario" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Fax
                                        </td>
                                        <td>
                                            <asp:Literal ID="litFax" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            E-mail
                                        </td>
                                        <td>
                                            <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <h2>
                                                Informacion de Actividades</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Descripción del Negocio
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDescripcionNegocio" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Principales Productos
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPrincipalesProductos" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Actividades
                                        </td>
                                        <td>
                                            <asp:Literal ID="litActividades" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td class="confirm_tab">
                                <div>
                                    Datos Sociedades</div>
                            </td>
                            <td class="confirm_data">
                                <table width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <h2>
                                                Información de Sociedad</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Capital Social Autorizado
                                        </td>
                                        <td>
                                            <asp:Literal ID="litCapitalSocial" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Capital Suscrito y Pagado
                                        </td>
                                        <td>
                                            <asp:Literal ID="litCapitalSuscrito" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Bienes Raíces
                                        </td>
                                        <td>
                                            <asp:Literal ID="litBienesRaices" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Activos
                                        </td>
                                        <td>
                                            <asp:Literal ID="litActivos" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Fecha Inicio Operaciones
                                        </td>
                                        <td>
                                            <asp:Literal ID="litFechaInicio" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Fecha Última Asamblea
                                        </td>
                                        <td>
                                            <asp:Literal ID="litFechaAsamblea" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Duración de la Sociedad
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDuracionSociedad" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Duración del Consejo
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDuracionConsejo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Regulacion
                                        </td>
                                        <td>
                                            <asp:Literal ID="litregulacion" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Distribución Acciones
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDitribucionAcciones" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Empleados
                                        </td>
                                        <td>
                                            <asp:Literal ID="litEmpleados" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title" colspan="2">
                                            <h2>
                                                Informacion de Referencia</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Referencias Comerciales
                                        </td>
                                        <td>
                                            <asp:Literal ID="litReferenciasComerciales" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Referencias Bancarias
                                        </td>
                                        <td>
                                            <asp:Literal ID="litReferenciasBancarias" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <h2>
                                                Informacion Comercial</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Nombre Comercial
                                        </td>
                                        <td>
                                            <asp:Literal ID="litNombreComercial" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Marca de Fabrica
                                        </td>
                                        <td>
                                            <asp:Literal ID="litMarcaFabrica" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Patente de Invención
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPatente" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="confirm_title">
                                            Sucursales
                                        </td>
                                        <td>
                                            <asp:Literal ID="litSucursales" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="border-bottom: solid 1px #eff0f1;" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="150px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <div class="window" style="margin: 0px; width: 230px; background-color: #fff;">
                                                <h1>
                                                    Solicitante</h1>
                                                <p style="padding: 10px">
                                                    Yo
                                                    <asp:Label ID="lblSolicitante" runat="server"></asp:Label>
                                                    &nbsp;<br />
                                                    En calidad de
                                                    <asp:Label ID="lblSolicitanteCargo" runat="server"></asp:Label>
                                                    &nbsp;<br />
                                                    por la presente afirmo bajo juramento que los datos son correctos y completos y
                                                    que no he omitido ni falseado dato alguno.<br />
                                                    <br />
                                                    __________________________________<br />
                                                </p>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="window" style="margin: 0px; width: 250px; background-color: #fff;">
                                                <h1>
                                                    Autorizacion Representante</h1>
                                                <p style="padding: 10px">
                                                    Autorizo la siguiente persona representarnos, en la presente y Tramite de Registro
                                                    Mercantil<br />
                                                    <br />
                                                    Nombre _______________________________<br />
                                                    Apellidos ______________________________<br />
                                                    Cédula ________________________________<br />
                                                    En calidad de ___________________________<br />
                                                </p>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="window" style="margin: 0px; width: 200px; background-color: #fff;">
                                                <h1>
                                                    Constancia de Recepcion</h1>
                                                <p style="padding: 10px">
                                                    Abogado ______________________<br />
                                                    Fecha ________________________<br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                </p>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="150px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="150px" colspan="2" style="background-color: #768FA5">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
