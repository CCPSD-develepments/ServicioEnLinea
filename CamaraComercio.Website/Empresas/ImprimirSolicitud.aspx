<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirSolicitud.aspx.cs"
    Inherits="CamaraComercio.Website.Empresas.ImprimirSolicitud" %>

<%@ Register assembly="CamaraComercio.Website" namespace="CamaraComercio.Website.Helpers.ExtendedControls" tagprefix="cc1" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="content">
        <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
            <asp:View ID="v1" runat="server">
                <script type="text/javascript" language="javascript">
                    window.print();
                </script>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-left:10px;margin-right:10px;">
                    <tr>
                        <td valign="top" style="width: 100%">
                            <h1 class="maintitle">
                            <strong>Cámara de Santo Domingo</strong>
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
                                                    <p style="font-size: medium; color: #000000;">
                                                        Número de Solicitud</p>
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
                                        <asp:Image ID="imgCodigoBarras" runat="server" Height="70px" Width="200px" />
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
                                                    Tipo Solicitud
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litTipoSolicitud" runat="server"></asp:Literal>
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
                                                    Capital Suscrito</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litCapitalSuscrito" runat="server" />
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Bienes Raíces</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litBienesRaices" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Activos</td>
                                                <td>
                                                    <asp:Literal ID="litActivos" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Fecha Inicio Operaciones</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litFechaInicio" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Fecha Última Asamblea</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litFechaAsamblea" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Duración de la Sociedad</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litDuracionSociedad" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Duración del Consejo</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litDuracionConsejo" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Regulación
                                                </td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litregulacion" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Empleados</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litEmpleados" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Referencias Comerciales</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litReferenciasComerciales" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Referencias Bancarias</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litReferenciasBancarias" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Nombre Comercial</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litNombreComercial" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    No. Registro ONAPI</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litRegistroOnapi" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Sucursales</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litSucursales" runat="server"></asp:Literal>
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
                                                    Nacionalidad</td>
                                                <td>
                                                    <asp:Literal ID="litNacionalidad" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Dirección</td>
                                                <td>
                                                    <asp:Literal ID="litDireccion" runat="server"></asp:Literal>
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
                                                    Tel. Secundario</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litTelefonoSecundario" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Fax</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litFax" runat="server"></asp:Literal>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">E-Mail</td>
                                                <td>
                                                    <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Dirección Web</td>
                                                <td>
                                                    <label>
                                                    <asp:Literal ID="litWebsite" runat="server"></asp:Literal>
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
                                                <td class="confirm_title">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            </table>
                                            </asp:Panel>

                                             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="confirm_title" colspan="2">
                                                    <h2>
                                                        Información del Solicitante</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Nombre
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litNombreContacto" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    Cédula de Identidad</td>
                                                <td>
                                                    <asp:Literal ID="litCedulaContacto" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="confirm_title">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                        </table>
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
                            <table width="100%">
                                <tr>
                                    <td>
                                        <telerik:RadGrid runat="server" ID="gvSociosT" EnableEmbeddedSkins="false" Skin="NoboxGrid">
                                            <MasterTableView>
                                                <NoRecordsTemplate>
                                                    No existen socios registrados para esta empresa
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                           <telerik:RadGrid runat="server" ID="gvDocumentos" AutoGenerateColumns="False" 
                                                GridLines="None" EnableEmbeddedSkins="False" Skin="NoboxGrid">
                                               <MasterTableView>
                                                    <NoRecordsTemplate>
                                                        No existen documentos para esta transacción
                                                    </NoRecordsTemplate>
                                                   <RowIndicatorColumn>
                                                       <HeaderStyle Width="20px" />
                                                   </RowIndicatorColumn>
                                                   <ExpandCollapseColumn>
                                                       <HeaderStyle Width="20px" />
                                                   </ExpandCollapseColumn>
                                                   <Columns>
                                                       <telerik:GridBoundColumn DataField="Nombre" HeaderText="Documento" 
                                                            UniqueName="Nombre">
                                                           <HeaderStyle HorizontalAlign="Left" />
                                                           <ItemStyle HorizontalAlign="Left" />
                                                       </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="FechaDocumento" HeaderText="Fecha"
                                                            UniqueName="FechaDocumento">
                                                       </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="CantidadOriginal" HeaderText="Originales"
                                                            UniqueName="Originales">
                                                       </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="CantidadCopia" HeaderText="Copias"
                                                            UniqueName="Copias">
                                                       </telerik:GridBoundColumn>
                                                   </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" 
                                                            InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                               </MasterTableView>
                                               <FilterMenu EnableEmbeddedSkins="False">
                                               </FilterMenu>
                                               <HeaderContextMenu EnableEmbeddedSkins="False">
                                               </HeaderContextMenu>
                                           </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="border-bottom: solid 1px #eff0f1;" colspan="2">&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150px">&nbsp;
                                        
                                    </td>
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150px">&nbsp;
                                        
                                    </td>
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150px" colspan="2" style="background-color: #4B91AC">&nbsp;
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="v2" runat="server">
                <h1>
                    Transacción Inválida</h1>
                <p>
                    No hay transacciones registradas
                </p>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
