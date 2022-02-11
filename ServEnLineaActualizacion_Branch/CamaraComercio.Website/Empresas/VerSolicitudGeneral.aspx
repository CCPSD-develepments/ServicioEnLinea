<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerSolicitudGeneral.aspx.cs" Inherits="CamaraComercio.Website.Empresas.VerSolicitudGeneral" %>


<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirSolicitud.aspx.cs"  Inherits="CamaraComercio.Website.Empresas.ImprimirSolicitud" %>

<%@ Register assembly="CamaraComercio.Website" namespace="CamaraComercio.Website.Helpers.ExtendedControls" tagprefix="cc1" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Impresion Solicitud</title>
    <link href="/res/css/stylesPrint.css" rel="stylesheet" type="text/css" />
    <link href="/res/css/nobox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .auto-style1 {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="content">
        <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
            <asp:View ID="v1" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-left:10px;margin-right:10px;">
                    <tr>
                        <td valign="top" style="width: 100%">
                            <h1 class="maintitle" style="width: 81%;">
                                <strong>Formalizate.gob.do</strong>
                                <asp:Literal runat="server" ID="litServicio" Text="Solicitud de Registro" />
                                <br />
                                <asp:Literal runat="server" ID="litExpress" Text="Express" />
                            </h1>
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
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNoCita" runat="server" Style="font-size: medium" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <p style="font-size: medium; color: #000000;">
                                                        Fecha de Solicitud</p>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFechaCita" runat="server" Style="font-size: medium" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right">
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
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
                                            Resumen de Solicitud</h1>
                                    </td>
                                    <td class="pasoForm">&nbsp;
                                        
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
                                                        Información de Solicitud</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    No. Solicitud
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litNoRegistro" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Servicio
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litTipoServicio" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Comentario
                                                </td>
                                                <td>
                                                    <asp:Literal ID="LiteralComentario" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                            </table>

                                            <asp:Panel runat="server" ID="pnlInfoEmpresa">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <h2>
                                                        Información de Registro</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                        Denominación Social
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litDenomSocial" runat="server"></asp:Literal>
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
                                                     <asp:Literal ID="litFechaConstitucionTit" runat="server">
                                                        Fecha Constitución
                                                    </asp:Literal>
                                                 </td>
                                                 <td>
                                                     <asp:Literal ID="litFechaConstitucion" runat="server"></asp:Literal>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    No. Registro Mercantil
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltRegistroMercantil" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="confirm_title">&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <h2>
                                                        Información de Empresa</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Capital Social</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litCapitalSocial" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td class="confirm_title">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title" colspan="2">
                                                    <h2>
                                                        Información del Contacto Comercial</h2>
                                                </td>
                                            </tr>
                                           
                                          
                                            <tr>
                                                <td class="confirm_title">
                                                    Tel. Primario</td>
                                                <td>
                                                    <asp:Literal ID="litTelefonoPrimario" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td class="confirm_title">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            </table>
                                            </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                   
                        </td>
                    </tr>
                </table>
            </asp:View>
         
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
