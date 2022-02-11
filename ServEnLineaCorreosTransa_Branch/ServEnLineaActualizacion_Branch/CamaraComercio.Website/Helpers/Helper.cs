using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Telerik.Web.UI;
using System.Reflection;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TipoSocio = CamaraComercio.DataAccess.EF.OficinaVirtual.TipoSocio;
#pragma warning disable CS0105 // The using directive for 'CamaraComercio.DataAccess.EF.CamaraComun' appeared previously in this namespace
using CamaraComercio.DataAccess.EF.CamaraComun;
#pragma warning restore CS0105 // The using directive for 'CamaraComercio.DataAccess.EF.CamaraComun' appeared previously in this namespace
#pragma warning disable CS0105 // The using directive for 'CamaraComercio.DataAccess.EF.OficinaVirtual' appeared previously in this namespace
using CamaraComercio.DataAccess.EF.OficinaVirtual;
#pragma warning restore CS0105 // The using directive for 'CamaraComercio.DataAccess.EF.OficinaVirtual' appeared previously in this namespace
#pragma warning disable CS0105 // The using directive for 'Telerik.Web.UI' appeared previously in this namespace
using Telerik.Web.UI;
#pragma warning restore CS0105 // The using directive for 'Telerik.Web.UI' appeared previously in this namespace
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website
{
    /// <summary>
    /// Accesos al Web Config. Configuraciones del sistema
    /// </summary>
    public class Helper
    {
        private decimal totalFactura;
        private static int CertificacionId = 7;
        private static int CopiaCertificadaId = 39;

        private int ObtenerTipoServicio(int servicioId)
        {
            var dbComun = new CamaraComunEntities();
            var servicio = dbComun.Servicio.FirstOrDefault(t => t.ServicioId == servicioId);

            if (servicio != null) return servicio.TipoServicioId;

            return 0;
        }


      
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.GrabarAlSrm(string, int, string, string, out string)'
        public bool GrabarAlSrm(string CamaraId, int nSolicitud, string personaContacto, string telefonoContacto, out string ErrorMessage)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.GrabarAlSrm(string, int, string, string, out string)'
        {
            #region Envio de datos al srm
            //Creating Repositories
            var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            var repTransaccion = new SRM.TransaccionesRepository(context);
            var repSubTransaccion = new SRM.SubTransaccionesRepository(context);
            var repFacturas = new SRM.FacturasSrmRepository(context);
            var repDetalle = new SRM.TransaccionDetalleRepository(context);
            var repFormasPago = new SRM.FormaPagoRepository(context);
            var repUsuario = new SRM.UsuarioRepository(context);
            var repDocumentos = new SRM.DocumentosTransaccionesRepository(context);
            var repTransaccinesSociedades = new SRM.TransaccionesSociedadesRepository(context);
            var repTransaccinesPersona = new SRM.TransaccionesPersonasRepository(context);
            var repTransaccinesPersonas = new SRM.TransaccionesPersonasRepository(context);
            var repSeguimiento = new DataAccess.EF.Repository<SRM.SeguimientoTransacciones, SRM.CamaraSRMEntities>(context);
            bool actualizarTransacccion = false;
            var dbWebSite = new CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            var repNotasCredito = new SRM.NotasCreditosRepository(context);
            



            //Variable usada para reglas de calculo en las subtransacciones
#pragma warning disable CS0219 // The variable 'considerarMods' is assigned but its value is never used
            var considerarMods = true;
#pragma warning restore CS0219 // The variable 'considerarMods' is assigned but its value is never used

            //Objetos de la transaccion en website necesarios para crear la información dentro del SRM
            var tranId = nSolicitud;
            var trans = dbWebSite.Transacciones.Where(a => a.TransaccionId == tranId).FirstOrDefault();
            var factura = dbWebSite.Facturas.Where(f => f.TransaccionId == tranId).OrderByDescending(x => x.FacturaId).FirstOrDefault();
            var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(t => t.TipoSociedadId == trans.TipoSociedadId);
            var esCertificacion = Helper.HabilarPagoTarjeta(trans.ServicioId);
            var estatusId = ObtenerTipoServicio(trans.ServicioId) == CertificacionId
                            ? Helper.EstatusTransIdCertificacion
                            : Helper.EstatusTransIdAnalisis;

            if (trans.ServicioId == 745 || trans.ServicioId == 746 || trans.ServicioId == 747 || trans.ServicioId == 748)
            {
                estatusId = 14;
            }

            //Validando factura este pagada.
            if (!trans.bPagada && trans.ServicioId != Helper.ServicioInclusionId)
            {
                ErrorMessage = "La factura debe ser pagada en su totalidad para poder enviar la solicitud.";
                return false;
            }
            if (factura == null && trans.ServicioId != Helper.ServicioInclusionId)
            {
                ErrorMessage = "Hay un error con los datos de su factura. Por favor contactar al personal de soporte";
                return false;
            }

            var servicio = dbComun.Servicio.Where(a => a.ServicioId == trans.ServicioId).FirstOrDefault();

            #region Transaccion principal

            var tipoSer = ObtenerTipoServicio(trans.ServicioId);
            var esCertOCopiaCert = (tipoSer == CertificacionId || tipoSer == CopiaCertificadaId);

            bool exitsteSDQ = context.Transacciones.Any(x => x.TransaccionIdAnterior == trans.TransaccionId && x.DesdeOfv == true);

            var transSrm = new SRM.Transacciones();
            var contextU = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            var transaccionUpdateSDQ = contextU.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == trans.TransaccionId && x.DesdeOfv == true);
            var contextUDocSubTRans = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);


            var Status = Helper.EstatusTransIdAnalisis;
            if (trans.ServicioId == 745 || trans.ServicioId == 746 || trans.ServicioId == 747 || trans.ServicioId == 748)
            {
                Status = 14;
            }

            //new 2021-08-23-:
      //      var webRegistro = dbWebSite.Registros.Where(rd => rd.SrmRegistroId == trans.RegistroId).FirstOrDefault();
            var webRegistro = dbWebSite.Registros.Where(d => d.SrmRegistroId == trans.RegistroId).OrderByDescending(u => u.RegistroId).FirstOrDefault(); // last

            if (!exitsteSDQ)
            {

                //Creando Transaccion Principal
                transSrm = new SRM.Transacciones
                {
                    TipoServicioId = servicio.ServicioId,
                    TipoTransaccionId = servicio.TipoServicioId,
                    Fecha = DateTime.Now,
                    RNCSolicitante = trans.RNCSolicitante,
                    NombreContacto = !string.IsNullOrEmpty(personaContacto) ? personaContacto : trans.NombreContacto,
                    TelefonoContacto = !string.IsNullOrEmpty(telefonoContacto) ? telefonoContacto : trans.TelefonoContacto,
                    Salicitante = trans.Solicitante,
                    Servicio = servicio.Descripcion,
                    Estatus = Status,
                    Estatus2 = Status,
                    DesdeOfv = true,
                    ImprimirCopias = trans.ImprimirCopias,
                    Tipo = trans.TipoSociedadId == Helper.TipoSociedadPersonaFisica
                                                  ? 1
                                                  : 0,
                    Prioridad = trans.Prioridad == 1 ? "0" : "1",
                    TipoServicio = servicio.TipoServicio.Descripcion,
                    FaxContacto = trans.FaxContacto,
                    NoReciboDGII = trans.NoReciboDGII,
                    FechaReciboDGII = trans.FechaReciboDGII,
                    CustomInt1 = trans.TipoSociedadId,
                    CustomInt2 = trans.NumeroRegistro,
                    CustomString1 = trans.NombreSocialPersona,
                    CustomString2 = String.Empty,
                    CustomString3 = String.Empty,
                    CustomDecimal1 = trans.CapitalSocial,
                    CustomDecimal2 = trans.ModificacionCapital,
                    FlowId = Guid.NewGuid(),
                    rowguid = Guid.NewGuid(),
                    ComentarioHtml = trans.Comentario,
                    TransaccionIdAnterior = trans.TransaccionId,
                    OrigenTransaccion = trans.CamaraId,
                    SolicitanteWeb = trans.ANombreQuien,
                    RNCSolicitanteWeb = trans.DocumentoNombreQuien,
                    //new 2021-08-23, 
                    CorreoEmpresa = webRegistro.CorreoEmpresa,
                    CorreoContacto = webRegistro.CorreoContacto
                };
                //Si es una certificacion o copia certificada poner el tipo certificacion simple.
                if (esCertOCopiaCert)
                    transSrm.Tipo = 2;

                repTransaccion.Add(transSrm);
            }
            else
            {

                transaccionUpdateSDQ.TipoServicioId = servicio.ServicioId;
                transaccionUpdateSDQ.TipoTransaccionId = servicio.TipoServicioId;
                transaccionUpdateSDQ.Fecha = DateTime.Now;
                transaccionUpdateSDQ.RNCSolicitante = trans.RNCSolicitante;
                transaccionUpdateSDQ.NombreContacto = !string.IsNullOrEmpty(personaContacto) ? personaContacto : trans.NombreContacto;
                transaccionUpdateSDQ.TelefonoContacto = !string.IsNullOrEmpty(telefonoContacto) ? telefonoContacto : trans.TelefonoContacto;
                transaccionUpdateSDQ.Salicitante = trans.Solicitante;
                transaccionUpdateSDQ.Servicio = servicio.Descripcion;
                transaccionUpdateSDQ.Estatus = Status;
                transaccionUpdateSDQ.Estatus2 = Status;
                transaccionUpdateSDQ.DesdeOfv = true;
                transaccionUpdateSDQ.Tipo = trans.TipoSociedadId == Helper.TipoSociedadPersonaFisica
                                                     ? 1
                                                     : 0;
                transaccionUpdateSDQ.Prioridad = trans.Prioridad == 1 ? "0" : "1";
                transaccionUpdateSDQ.VieneProblemas = false;
                transaccionUpdateSDQ.TipoServicio = servicio.TipoServicio.Descripcion;
                transaccionUpdateSDQ.FaxContacto = trans.FaxContacto;
                transaccionUpdateSDQ.NoReciboDGII = trans.NoReciboDGII;
                transaccionUpdateSDQ.FechaReciboDGII = trans.FechaReciboDGII;
                transaccionUpdateSDQ.CustomInt1 = trans.TipoSociedadId;
                transaccionUpdateSDQ.CustomInt2 = trans.NumeroRegistro;
                transaccionUpdateSDQ.CustomString1 = trans.NombreSocialPersona;
                transaccionUpdateSDQ.CustomString2 = String.Empty;
                transaccionUpdateSDQ.CustomString3 = String.Empty;
                transaccionUpdateSDQ.CustomDecimal1 = trans.CapitalSocial;
                transaccionUpdateSDQ.CustomDecimal2 = trans.ModificacionCapital;
                transaccionUpdateSDQ.FlowId = Guid.NewGuid();
                transaccionUpdateSDQ.ComentarioHtml = trans.Comentario;
                transaccionUpdateSDQ.TransaccionIdAnterior = trans.TransaccionId;
                transaccionUpdateSDQ.OrigenTransaccion = trans.CamaraId;
                transaccionUpdateSDQ.SolicitanteWeb = trans.ANombreQuien;
                transaccionUpdateSDQ.RNCSolicitanteWeb = trans.DocumentoNombreQuien;
                transaccionUpdateSDQ.ImprimirCopias = trans.ImprimirCopias;

                //new 2021-08-23, 
                transaccionUpdateSDQ.CorreoEmpresa = webRegistro.CorreoEmpresa;
                transaccionUpdateSDQ.CorreoContacto = webRegistro.CorreoContacto;

                //Si es una certificacion o copia certificada poner el tipo certificacion simple.
                if (esCertOCopiaCert)
                    transaccionUpdateSDQ.Tipo = 2;

                var subTransacciones = contextUDocSubTRans.SubTransacciones.Where(x => x.TransaccionId == transaccionUpdateSDQ.TransaccionId);
                foreach (var item in subTransacciones)
                {
                    contextUDocSubTRans.SubTransacciones.DeleteObject(item);
                }

                var documentoTransacciones = contextUDocSubTRans.DocumentosTransacciones.Where(x => x.TransaccionId == transaccionUpdateSDQ.TransaccionId);
                foreach (var item in documentoTransacciones)
                {
                    contextUDocSubTRans.DocumentosTransacciones.DeleteObject(item);
                }

                contextUDocSubTRans.SaveChanges();

            }

            #endregion

            #region Subtransacciones
            //Validacion para subtransacciones. Hay algunas que no se cobran dependiendo del primer servicio seleccionado
            if (!servicio.SeCobraEnSubTransaccion && servicio.TransaccionJerarquia > 0 ||
                   Helper.ServiciosHeaderIds.Contains(servicio.ServicioId))
                considerarMods = false;

            var subtransList = new List<SRM.SubTransacciones>();
            foreach (var subtrans in trans.SubTransacciones)
            {
                var subserv = dbComun.Servicio.Where(a => a.ServicioId == subtrans.ServicioId).FirstOrDefault();
                var subTransSrm = new SRM.SubTransacciones()
                {
                    TipoServicioId = subserv.ServicioId,
                    TipoTransaccionId = subserv.TipoServicioId,
                    Servicio = subserv.Descripcion,
                    Estatus = Status,
                    TipoServicio = subserv.TipoServicio.Descripcion,
                    CustomInt1 = trans.TipoSociedadId,
                    CustomInt2 = trans.NumeroRegistro,
                    CustomString1 = trans.NombreSocialPersona,
                    CustomString2 = String.Empty,
                    CustomString3 = String.Empty,
                    CustomDecimal1 = trans.CapitalSocial,
                    CustomDecimal2 = trans.ModificacionCapital,
                    FechaModificacion = DateTime.Now,
                    FlowId = Guid.NewGuid(),

                };
                subtransList.Add(subTransSrm);

            }
            #endregion

            #region Detalle Transaccion


                var listTransDetalle = new List<SRM.TransaccionDetalle>();
            var transDetalle = dbWebSite.TransaccionDetalle.Where(t => t.FacturaId == factura.FacturaId);

            if (transDetalle.Count() > 0)
            {
                listTransDetalle.AddRange(
                    transDetalle.Select(td =>
                                        new SRM.TransaccionDetalle()
                                        {
                                            Cantidad = td.Cantidad,
                                            Cuenta = td.Cuenta,
                                            Detalle = td.Detalle,
                                            PrecioUnitario = td.PrecioUnitario,
                                            Total = td.Total,
                                            TotalBruto = td.TotalBruto
                                        }
                        )
                    );
            }

            #endregion

            #region Factura / Pagos

            totalFactura = listTransDetalle.Sum(l => l.Total).GetValueOrDefault();
            var facturaSrm = new SRM.Facturas
            {
                Complementaria = false,
                Estado = 1,
                Fecha = DateTime.Now,
                Ncf = factura.Ncf,
                TipoNcf = (factura.TipoNcf != null) ? ((factura.TipoNcf == "1") ? "Factura con Valor Fiscal" : (factura.TipoNcf == "2") ? "Factura para Consumidor Final" : (factura.TipoNcf == "14") ? "Factura para Regímenes Especiales" : "Factura para Organismos Gubernamentales") : "",
                Usuario = Helper.UsuarioFacturacion,
                CamaraId = CamaraId,
                TotalFactura = totalFactura,
                RNC = trans.RNCSolicitante,
                NombreCliente = trans.Solicitante, // trans.NombreSocialPersona,
                TipoComprobanteId = trans.TipoComprobanteId

            };
            if (exitsteSDQ) facturaSrm.TransaccionId = Convert.ToInt32(transaccionUpdateSDQ.TransaccionId != 0 ? transaccionUpdateSDQ.TransaccionId : 0);
            repFacturas.Add(facturaSrm);

            var formasPagoSrm = new List<SRM.FormasPagos>();
            if (factura.PagoAnterior > 0)
            {
                formasPagoSrm = new List<SRM.FormasPagos>()
                {
                    new SRM.FormasPagos
                    {
                        Valor =(totalFactura - factura.PagoAnterior) >= 0 ? (totalFactura - factura.PagoAnterior): 0m,
                        ValorEntregado = (totalFactura - factura.PagoAnterior) >= 0 ? (totalFactura - factura.PagoAnterior): 0m,
                        ValorDevuelto = 0m,
                        FormaPago = Helper.MetodoPago.ToString(),
                        FechaCuadre = DateTime.Today.Date,
                        Tasa = 1m,
                        Referencia = "Orden enviada por website",
                        NoTarjeta = String.Empty
                    },
                    new SRM.FormasPagos
                    {
                        Valor = factura.PagoAnterior,
                        ValorEntregado = factura.PagoAnterior,
                        ValorDevuelto = 0m,
                        FormaPago = "4",
                        FechaCuadre = DateTime.Today.Date,
                        Tasa = 1m,
                        Referencia = "Orden enviada por website",
                        NoTarjeta = String.Empty
                    }
                };
            }
            else
            {
                formasPagoSrm = new List<SRM.FormasPagos>()
                {
                    new SRM.FormasPagos
                    {
                        Valor = totalFactura,
                        ValorEntregado = totalFactura,
                        ValorDevuelto = 0m,
                        FormaPago = Helper.MetodoPago.ToString(),
                        FechaCuadre = DateTime.Today.Date,
                        Tasa = 1m,
                        Referencia = "Orden enviada por website",
                        NoTarjeta = String.Empty
                    }
                };
            }

            #endregion

            #region Documentos

            var documentosSrm = new List<SRM.DocumentosTransacciones>();
            foreach (var doc in trans.TransaccionesDocumentos)
            {
                var tipoDoc = dbComun.TipoDocumento.FirstOrDefault(d => d.TipoDocumentoId == doc.TipoDocumentoId);
                if (tipoDoc == null) continue;

                var docSrm = new SRM.DocumentosTransacciones()
                {
                    WebDocumentoId = doc.TransaccionesDocumentosId,
                    Analizado = true,  // se puso true porque los documentos vienen desde la web.
                    Comentario = "Documento enviado desde portal Web",
                    FechaDocumento = doc.FechaDocumento,
                    NoOriginales = doc.CantidadOriginal,
                    NoCopias = doc.CantidadCopia,
                    CheckValidated = true,
                    Deleted = false,
                    FechaModificacion = DateTime.Now,
                    rowguid = Guid.NewGuid(),
                    Documento = tipoDoc.Nombre,
                    Registrable = tipoDoc.Registrable,
                    CostoOriginal = tipoDoc.CostoOriginal,
                    CostoCopia = tipoDoc.CostoCopia,
                    DocumentoId = doc.TipoDocumentoId.GetValueOrDefault()
                };
                documentosSrm.Add(docSrm);
            }

            #endregion

            var srmUpdated = false;
            if (trans.TipoSociedadId == 7)
            {
                #region TransaccionesPersonaFisica
                var transPer = new SRM.TransaccionesPersonas();
                var personaId = 0;
                if (trans.RegistroId > 0)
                {
                    personaId = context.PersonasRegistros.Where(a => a.RegistroId.Equals(trans.RegistroId))
                                        .FirstOrDefault()
                                        .PersonaId;
                }

                transPer.FechaModificacion = DateTime.Now;
                transPer.rowguid = Guid.NewGuid();
                transPer.PersonaId = personaId;
                #endregion


                using (var scope = new System.Transactions.TransactionScope())
                {
                    using (var tnx = repTransaccion.BeginTransaction())
                    {
                        try
                        {
                            //Se guarda la transaccion y se obtiene el ID 
                            if (!exitsteSDQ) repTransaccion.Save();
                            var transId = transSrm.TransaccionId != 0 ? transSrm.TransaccionId : transaccionUpdateSDQ.TransaccionId;


                            if (!exitsteSDQ)
                            {
                                transPer.TransaccionId = transId;
                                repTransaccinesPersona.Add(transPer);
                                repTransaccinesPersona.Save();
                            }


                            //Se actualizan las subtransacciones
                            foreach (var subtransItem in subtransList)
                            {
                                subtransItem.TransaccionId = transId;
                                repSubTransaccion.Add(subtransItem);
                            }
                            repSubTransaccion.Save();


                            ////ep: 2021-05-10:
                            ////actualizar Notas Creditos:
                            if (factura.PagoAnterior > 0)
                            {
                                var FacturaNotaSRM_ = new SRM.NotasCredito();
                                var LastFacturaSRM = context.Facturas.Where(a => a.TransaccionId == transId && a.Estado == 3).OrderByDescending(a => a.FacturaId).FirstOrDefault();

                                var FacturaNotaSRM = context.NotasCredito.Where(a => a.FacturaID == LastFacturaSRM.FacturaId).FirstOrDefault();
                                // FacturaNotaSRM.Activa = false;
                                var _NotaCredito = repNotasCredito.UpdateNotasCredito(FacturaNotaSRM.NotaCreditoID);
                            }



                            //Se somete la factura y se obtiene el Id
                            facturaSrm.TransaccionId = transId;
                            repFacturas.Save();
                            var facturaId = facturaSrm.FacturaId;
                                                                                                              
                            //Se actualiza el detalle de la factura
                            foreach (var transDetalleItem in listTransDetalle)
                            {
                                transDetalleItem.FacturaId = facturaId;
                                repDetalle.Add(transDetalleItem);
                            }
                            repDetalle.Save();

                            //Se actualiza la forma de pagos
                            foreach (var item in formasPagoSrm)
                            {
                                item.FacturaId = facturaId;
                                repFormasPago.Add(item);
                            }
                            repFormasPago.Save();

                            //Se actualizan los documentos adjuntos
                            foreach (var docInTrans in documentosSrm)
                            {
                                docInTrans.FacturaId = facturaId;
                                docInTrans.TransaccionId = transId;
                                repDocumentos.Add(docInTrans);
                            }
                            repDocumentos.Save();

                            //Se asigna la transacción a un analista
                            var usuarioAntId = repUsuario.GetUsuarioIdByUsername(Helper.UsuarioFacturacion);

                            repTransaccion.AsignarTransaccion(transId, estatusId, usuarioAntId);

                            //Se actualiza el objeto web (para poder tener el tracking)
                            trans.SrmTransaccionId = transId;
                            trans.bLoadedInSRM = true;

                          
                            //Commit de la transacción. Se usa la variable srmUpdated para no tener que usar el MSDTC entre dos bases de datos distintas
                            tnx.Commit();
                            scope.Complete();
                            srmUpdated = true;
                            if (exitsteSDQ) actualizarTransacccion = true;
                        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        {
                            tnx.Rollback();
                            ErrorMessage = "Ha ocurrido un error al intentar procesar su transacción. Contacte al personal de soporte.";
                            return false;
                        }
                    }
                }
            }
            else
            {
                #region Transacciones Sociedades
                var transSoc = new SRM.TransaccionesSociedades();

                //if (esCertificacion)
                //{
                var sociedadId = 0;
                if (trans.RegistroId > 0)
                {
                    sociedadId = context.SociedadesRegistros.Where(a => a.RegistroId.Equals(trans.RegistroId))
                                        .FirstOrDefault()
                                        .SociedadId;
                }

                transSoc.FechaModificacion = DateTime.Now;
                transSoc.rowguid = Guid.NewGuid();
                transSoc.SociedadId = sociedadId;
                //}

                #endregion

               

                using (var scope = new System.Transactions.TransactionScope())
                {
                    using (var tnx = repTransaccion.BeginTransaction())
                    {
                        try
                        {
                            //Se guarda la transaccion y se obtiene el ID 
                            if (!exitsteSDQ) repTransaccion.Save();
                            var transId = transSrm.TransaccionId != 0 ? transSrm.TransaccionId : transaccionUpdateSDQ.TransaccionId;

                            //Si es certificacion grabar la Transacciones Sociedad
                            //if (esCertificacion)
                            //{
                            if (!exitsteSDQ)
                            {
                                transSoc.TransaccionId = transId;
                                repTransaccinesSociedades.Add(transSoc);
                                repTransaccinesSociedades.Save();
                            }
                            //}

                            //Se actualizan las subtransacciones
                            foreach (var subtransItem in subtransList)
                            {
                                subtransItem.TransaccionId = transId;
                                repSubTransaccion.Add(subtransItem);
                            }
                            repSubTransaccion.Save();



                            //ep: 2021-05-10:
                            //actualizar Notas Creditos:
                            if (factura.PagoAnterior > 0)
                            {
                                var FacturaNotaSRM_ = new SRM.NotasCredito();
                                var LastFacturaSRM = context.Facturas.Where(a => a.TransaccionId == transId && a.Estado ==3).OrderByDescending(a => a.FacturaId).FirstOrDefault();

                                var FacturaNotaSRM = context.NotasCredito.Where(a => a.FacturaID == LastFacturaSRM.FacturaId).FirstOrDefault();
                                // FacturaNotaSRM.Activa = false;
                                var _NotaCredito = repNotasCredito.UpdateNotasCredito(FacturaNotaSRM.NotaCreditoID);
                            }




                            //Se somete la factura y se obtiene el Id
                            facturaSrm.TransaccionId = transId;
                            repFacturas.Save();
                            var facturaId = facturaSrm.FacturaId;

                            //Se actualiza el detalle de la factura
                            foreach (var transDetalleItem in listTransDetalle)
                            {
                                transDetalleItem.FacturaId = facturaId;
                                repDetalle.Add(transDetalleItem);
                            }
                            repDetalle.Save();

                            //Se actualiza la forma de pagos
                            foreach (var item in formasPagoSrm)
                            {
                                item.FacturaId = facturaId;
                                repFormasPago.Add(item);
                            }
                            repFormasPago.Save();

                            //Se actualizan los documentos adjuntos
                            foreach (var docInTrans in documentosSrm)
                            {
                                docInTrans.FacturaId = facturaId;
                                docInTrans.TransaccionId = transId;
                                repDocumentos.Add(docInTrans);
                            }
                            repDocumentos.Save();

                            //Se asigna la transacción a un analista
                            var usuarioAntId = repUsuario.GetUsuarioIdByUsername(Helper.UsuarioFacturacion);

                            repTransaccion.AsignarTransaccion(transId, estatusId, usuarioAntId);

                            //Se actualiza el objeto web (para poder tener el tracking)
                            trans.SrmTransaccionId = transId;
                            trans.bLoadedInSRM = true;

                            //Commit de la transacción. Se usa la variable srmUpdated para no tener que usar el MSDTC entre dos bases de datos distintas
                            tnx.Commit();
                            scope.Complete();
                            srmUpdated = true;
                            if (exitsteSDQ) actualizarTransacccion = true;
                        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        {
                            tnx.Rollback();
                            ErrorMessage = "Ha ocurrido un error al intentar procesar su transacción. Contacte al personal de soporte.";
                            return false;
                        }
                    }
                }
            }

            


            if (srmUpdated)                                                                                                 
            {
                if (actualizarTransacccion) contextU.SaveChanges();
                dbWebSite.SaveChanges();
            }

            //btnEnvioTransaccion.Enabled = !trans.SrmTransaccionId.HasValue;

            ErrorMessage = "Su Transacción se ha enviado para ser procesada por un analista.";
            //Response.Redirect("~/Empresas/Oficina.aspx");
            #endregion

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.HabilarPagoTarjeta(int)'
        public static bool HabilarPagoTarjeta(int servicioId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.HabilarPagoTarjeta(int)'
        {
            var servicios = ConfigurationManager.AppSettings["ServiciosPagoOnline"].Split(',');
            foreach (var servicio in servicios)
            {
                var serId = 0;
                int.TryParse(servicio, out serId);

                if (serId.Equals(servicioId))
                    return true;
            }
            return false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.ServicioVip(int)'
        public static bool ServicioVip(int servicioId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.ServicioVip(int)'
        {
            var servicios = ConfigurationManager.AppSettings["ServiciosNoVip"].Split(',');
            foreach (var servicio in servicios)
            {
                var serId = 0;
                int.TryParse(servicio, out serId);

                if (serId.Equals(servicioId))
                    return false;
            }
            return true;
        }
        #region IDs predeterminados

        /// <summary>
        /// Retorna el ID del Modelo para la certificación de RM no existente
        /// </summary>
        public static int ServicioIdRmNoExiste
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("ServicioIdRmNoExiste");
            }
        }

        /// <summary>
        /// Retorna el ID del Modelo para la certificación de RM existente
        /// </summary>
        public static int ModeloIdRmNoExiste
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("ModeloIdRmNoExiste");
            }
        }

        /// <summary>
        /// Retorna el tipo de servicio para modificaciones
        /// </summary>
        public static int TipoServicioId
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("TipoServicioId");
            }
        }

        /// <summary>
        /// Retorna el tipo de servicio para modificaciones
        /// </summary>
        public static int TipoServicioIdCreacion
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("TipoServicioIdCreacion");
            }
        }

        /// <summary>
        /// Retorna el listado de servicios que son complementarios (ej. Aumento Capital Autorizado y Suscrito)
        /// </summary>
        public static Dictionary<Int32, Int32> ServiciosComplementariosIds
        {
            get
            {
                var coleccion = new Dictionary<Int32, Int32>();
                var strValores = HtmlHelper.GetAppVariable("ServiciosComplementariosIds").Split(';');
                foreach (var str in strValores)
                {
                    int key, val;
                    var item = str.Split(',');
                    if (Int32.TryParse(item[0], out key) && Int32.TryParse(item[1], out val))
                        coleccion.Add(key, val);
                }
                return coleccion;
            }
        }

        /// <summary>
        /// Servicios complementarios que debe ser seleccionados al momento de realizar cualquier transformación
        /// </summary>
        public static List<Int32> ServiciosTransfComplementarioIds
        {
            get
            {
                return HtmlHelper.GetAppVariable("ServiciosTransfComplementarioIds")
                    .Split(',').Select(Int32.Parse).ToList();
            }
        }

        /// <summary>
        /// Retorna el listado de servicios que invalidan el cobro de sub-modificaciones
        /// </summary>
        public static List<Int32> ServiciosHeaderIds
        {
            get
            {
                var serviciosStr = HtmlHelper.GetAppVariable("ServiciosHeaderIds");
                return serviciosStr.Split(',').Select(s => int.Parse(s)).ToList();
            }
        }

        /// <summary>
        /// Retorna el limite de registros que un gestor puede realizar en un dia
        /// </summary>
        public static int DuracionRegistroMercantilAnos
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("DuracionRegistroMercantilAños");
            }
        }

        /// <summary>
        /// Estatus Transaccion ID que marca una orden completada
        /// </summary>
        public static int EstatusTransIdCompletado
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("EstatusTransIdCompletado");
            }
        }

        /// <summary>
        /// Retorna el ID del tipo de comprobante fiscal a utilizar en caso de no especificarse uno en el UI
        /// </summary>
        public static string TipoComprobanteIdDefault
        {
            get { return HtmlHelper.GetAppVariable("TipoComprobanteIdDefault"); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.MensajeNotaNovDiasDetalleTransaccion'
        public static string MensajeNotaNovDiasDetalleTransaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.MensajeNotaNovDiasDetalleTransaccion'
        {
            get { return HtmlHelper.GetAppVariable("MensajeNotaNovDiasDetalleTransaccion"); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.MensajeNotaNovDiasConfirmacionPago'
        public static string MensajeNotaNovDiasConfirmacionPago
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.MensajeNotaNovDiasConfirmacionPago'
        {
            get { return HtmlHelper.GetAppVariable("MensajeNotaNovDiasConfirmacionPago"); }
        }

        /// <summary>
        /// Listado de Estatus Transaccion ID que indican una orden que aun no ha sido sometida para analisis
        /// </summary>
        public static List<Int32> EstatusTransIdStandBy
        {
            get
            {
                var strEstatusTrans = HtmlHelper.GetAppVariable("EstatusTransIdStandBy");
                return strEstatusTrans.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        /// <summary>
        /// Retorna el ID del estatus que tiene una transaccion en el momento de analisis
        /// </summary>
        public static int EstatusTransIdAnalisis
        {
            get { return HtmlHelper.GetAppVariableAsInt("EstatusTransIdAnalisis"); }
        }

        /// <summary>
        /// Retorna el ID del estatus que tiene una transaccion en el momento de analisis
        /// </summary>
        public static int EstatusTransIdCertificacion
        {
            get { return HtmlHelper.GetAppVariableAsInt("EstatusTransIdCertificacion"); }
        }

        /// <summary>
        /// Estatus que debe llevar una transaccion al momento de crearse por primera vez
        /// </summary>
        public static Int32 EstatusTransIdNuevo
        {
            get { return HtmlHelper.GetAppVariableAsInt("EstatusTransIdNuevo"); }
        }

        /// <summary>
        /// Estatus que debe llevar una transaccion al momento de crearse por primera vez
        /// </summary>
        public static Int32 EstatusTransIdEnSRM
        {
            get { return HtmlHelper.GetAppVariableAsInt("EstatusTransIdEnSRM"); }
        }

        /// <summary>
        /// TIpos de sociedades que no permiten menores de edad como accionistas
        /// </summary>
        public static List<int> TipoSociedadNoEmpresasMenoresEdad
        {
            get
            {
                var strTiposSociedades = HtmlHelper.GetAppVariable("TipoSociedadNoEmpresasMenoresEdad");
                return strTiposSociedades.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        /// <summary>
        /// Tipo Sociedad No Poseen Reduccion de Capital en Transformacion.
        /// </summary>
        public static List<int> TipoSociedadNoReduccionEnTransformacion
        {
            get
            {
                var strTiposSociedades = HtmlHelper.GetAppVariable("TipoSociedadNoReduccionEnTransformacion");
                return strTiposSociedades.Split(',').Select(int.Parse).ToList();

            }
        }

        ///<summary>
        /// Retorna los IDs de tipos de sociedades que permiten
        /// registrar acciones al portador
        ///</summary>
        public static List<int> TipoSociedadAlPortador
        {
            get
            {
                var strSociedades = HtmlHelper.GetAppVariable("TipoSociedadAlPortador");
                return strSociedades.Split(',').Select(s => int.Parse(s)).ToList();
            }
        }

        /// <summary>
        /// Retorna los IDs de tipos de sociedades que tienen 
        /// su domicilio social principal fuera del país (empresas extranjeras)
        /// </summary>
        public static List<int> TipoSociedadExtranjera
        {
            get
            {
                var strExtranjeras = HtmlHelper.GetAppVariable("TipoSociedadExtranjera");
                return strExtranjeras.Split(',').Select(s => int.Parse(s)).ToList();
            }
        }

        /// <summary>
        /// Retorna los IDs de tipos de sociedades para los cuales el capital 
        /// suscrito/pagado debe ser por lo menos el 10% del capital social
        /// </summary>
        public static List<int> TipoSociedadPorcSuscrito
        {
            get
            {
                var strPorSuscrito = HtmlHelper.GetAppVariable("TipoSociedadPorcSuscrito");
                return strPorSuscrito.Split(',').Select(s => int.Parse(s)).ToList();
            }
        }

        /// <summary>
        /// ID del tipo de sociedad para Personas Físicas
        /// </summary>
        public static Int32 TipoSociedadPersonaFisica
        {
            get { return HtmlHelper.GetAppVariableAsInt("TipoSociedadPersonaFisica"); }
        }

        /// <summary>
        /// Retorna los IDs de los servicios que no requieren presentar documentos. 
        /// Este campo se usa para evitar las pantallas de entrega de documentos
        /// </summary>
        public static List<int> ServicioIdsSinDocumentos
        {
            get
            {
                var strServicios = HtmlHelper.GetAppVariable("ServicioIdsSinDocumentos");
                return strServicios.Split(',').Select(s => int.Parse(s)).ToList();
            }
        }

        /// <summary>
        /// ID de servicio para reduccion de capitl social a cero (extranjeras)
        /// </summary>
        public static int ReduccionCapSocialCeroId
        {
            get { return HtmlHelper.GetAppVariableAsInt("ReduccionCapSocialCeroId"); }
        }

        /// <summary>
        /// Obtiene el ID de Republica Dominicana para filtrar listas
        /// </summary>
        public static int IdPaisRD
        {
            get { return HtmlHelper.GetAppVariableAsInt("IdPaisRepDominicana"); }
        }

        /// <summary>
        /// Retorna los IDs de tipos de sociedades que no permiten 
        /// menores de edad o empresas como accionistas
        /// </summary>


        /// <summary>
        /// Obtiene el ID de la cámara predeterminada
        /// </summary>
        public static string IdCamaraPrincipal
        {
            get { return HtmlHelper.GetAppVariable("IdCamaraPrincipal"); }
        }

        /// <summary>
        /// Obtiene el ID de la cámara secundarioa
        /// </summary>
        public static string IdCamaraSecundaria
        {
            get { return HtmlHelper.GetAppVariable("IdCamaraSecundaria"); }
        }

        /// <summary>
        /// Obtiene IDs de las principales ciudades en Rep. Dominicana
        /// </summary>
        public static List<Int32> CiudadesPrincipales
        {
            get
            {
                var strCiudades = HtmlHelper.GetAppVariable("IdCiudadesPrincipales");
                return strCiudades.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        /// <summary>
        /// Obtiene IDs de las principales ciudades en Rep. Dominicana
        /// </summary>
        public static List<Int32> TipoSociedadOrdenConstitucion
        {
            get
            {
                var strCiudades = HtmlHelper.GetAppVariable("TipoSociedadOrdenConstitucion");
                return strCiudades.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        /// <summary>
        /// Obtiene IDs de los estatus de Transaccion Cerrados
        /// </summary>
        public static List<Int32> EstatusTransaccionCerrados
        {
            get
            {
                var strEstatus = HtmlHelper.GetAppVariable("IdEstatusTransaccionesCerradas");
                return strEstatus.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        /// <summary>
        /// Obtiene IDs de los estatus de Transaccion que permiten duplicar que algunas transacciones restringidas
        /// </summary>
        public static List<Int32> IdEstatusTransaccionesDuplicar
        {
            get
            {
                var strEstatus = HtmlHelper.GetAppVariable("IdEstatusTransaccionesDuplicar");
                return strEstatus.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        /// <summary>
        /// Obtiene IDs de los estatus de Transaccion Cerrados
        /// </summary>
        public static List<Int32> TiposNcfIdVisible
        {
            get
            {
                var strEstatus = HtmlHelper.GetAppVariable("TiposNcfIdVisible");
                return strEstatus.Split(',').Select(c => int.Parse(c)).ToList();
            }
        }

        ///<summary>
        /// ID del servicio de constitución
        ///</summary>
        public static string ServicioIdConstitucion
        {
            get { return HtmlHelper.GetAppVariable("ServicioIdConstitucion"); }

        }

        /// <summary>
        /// ID del servicio de renovación
        /// </summary>
        public static string ServicioIdRenovacion
        {
            get { return HtmlHelper.GetAppVariable("ServicioIdRenovacion"); }
        }

        /// <summary>
        /// Servicio ID de adecuacion
        /// </summary>
        public static string ServicioIdAdecuacion
        {
            get { return HtmlHelper.GetAppVariable("ServicioIdAdecuacion"); }
        }

        /// <summary>
        /// Tipos de socios que no reciben cargos
        /// </summary>
        public static List<string> TipoSocioSinCargo
        {
            get
            {
                var strEstatus = HtmlHelper.GetAppVariable("TipoSocioSinCargo");
                return strEstatus.Split(',').ToList();
            }
        }

        /// <summary>
        /// Tipos de socios que reciben acciones
        /// </summary>
        public static List<string> TipoSocioConAcciones
        {
            get
            {
                var strEstatus = HtmlHelper.GetAppVariable("TipoSocioConAcciones");
                return strEstatus.Split(',').ToList();
            }
        }

        /// <summary>
        /// ID del Servicio Flow que indica si una transacción require analisis o no.
        /// </summary>
        public static Int32 ServicioFlowIdNoRequiereAnalisis
        {
            get { return HtmlHelper.GetAppVariableAsInt("ServicioFlowIdNoRequiereAnalisis"); }
        }

        /// <summary>
        /// Estatus en el SRM que indica cuando una transacción/solicitud fue cerrada
        /// </summary>
        public static Int32 EstatusTransaccionCompletaSrm
        {
            get { return HtmlHelper.GetAppVariableAsInt("EstatusTransaccionCompletaSrm"); }
        }

        /// <summary>
        /// ID de servicio utilizado para generacion de certificaciones
        /// </summary>
        public static Int32 ServicioCertificacionId
        {
            get { return HtmlHelper.GetAppVariableAsInt("ServicioCertificacionId"); }
        }

        /// <summary>
        /// ID de servicio utilizado para generacion de certificaciones
        /// </summary>
        public static Int32 ServicioCopiasCertificadasId
        {
            get { return HtmlHelper.GetAppVariableAsInt("ServicioCopiasCertificadasId"); }
        }

        /// <summary>
        /// Tipo de Servicio ID para transformaciones
        /// </summary>
        public static int TipoServicioIdTransformacion
        {
            get { return HtmlHelper.GetAppVariableAsInt("TipoServicioIdTransformacion"); }
        }

        /// <summary>
        /// Tipo de Servicio ID para renovaciones
        /// </summary>
        public static int TipoServicioIdRenovacion
        {
            get { return HtmlHelper.GetAppVariableAsInt("TipoServicioIdRenovacion"); }
        }

        /// <summary>
        /// Tipo de servicio ID para los cierres registrales
        /// </summary>
        public static int TipoServicioIdCierreRegistral
        {
            get { return HtmlHelper.GetAppVariableAsInt("TipoServicioIdCierreRegistral"); }
        }

        /// <summary>
        /// Servicio ID para inclusión de una nueva empresa
        /// </summary>
        public static int ServicioInclusionId
        { get { return HtmlHelper.GetAppVariableAsInt("ServicioInclusionId"); } }

        #endregion //Ids Ti

        #region Financieros

        /// <summary>
        /// Porcentaje permitido para el capital suscrito y pagado
        /// </summary>
        public static Decimal PorcentajeCapitalPagado
        {
            get
            {
                return HtmlHelper.GetAppVariableAsDecimal("PorcentajeCapitalPagado");
            }
        }

        /// <summary>
        /// Retorna el limite de registros que un gestor puede realizar en un dia
        /// </summary>
        public static int CantidadCopiasGratisNuevaEmpresa
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("CantidadCopiasGratisNuevaEmpresa");
            }
        }

        /// <summary>
        /// Retorna el limite de registros que un gestor puede realizar en un dia
        /// </summary>
        public static int CantidadOriginalGratisNuevaEmpresa
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("CantidadOriginalGratisNuevaEmpresa");
            }
        }

        /// <summary>
        /// Costo de realizar una adecuacion o transformación
        /// </summary>
        public static decimal PorcentajeVIP
        {
            get
            {
                return HtmlHelper.GetAppVariableAsDecimal("PorcentajeVIP");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.PasswordMondorRates'
        public static string PasswordMondorRates
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.PasswordMondorRates'
        {
            get
            {
                return HtmlHelper.GetAppVariable("PasswordMondorRates");
            }
        }

        /// <summary>
        /// Costo de realizar una adecuacion o transformación
        /// </summary>
        public static decimal CostoAdecuacion
        {
            get
            {
                return HtmlHelper.GetAppVariableAsDecimal("CostoAdecuacion");
            }
        }

        /// <summary>
        /// Costo de deposito por cada documento original
        /// </summary>
        public static decimal CostoDepositoOriginal
        {
            get
            {
                return HtmlHelper.GetAppVariableAsDecimal("CostoDepositoOriginal");
            }
        }

        /// <summary>
        /// Costo de deposito por cada copia
        /// </summary>
        public static decimal CostoDepositoCopia
        {
            get { return HtmlHelper.GetAppVariableAsDecimal("CostoDepositoCopia"); }
        }

        /// <summary>
        /// ID preferido del método de pago
        /// </summary>
        public static int MetodoPago
        {
            get { return HtmlHelper.GetAppVariableAsInt("MetodoPago"); }
        }

        #endregion //Financieros

        #region Configuraciones

        /// <summary>
        /// Retorna el limite de meses que deben transcurrir para poder procesar una solicitud de renovación
        /// </summary>
        public static int TiempoMinimoPermitirRenovacionMeses
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("TiempoMinimoPermitirRenovacionMeses");
            }
        }

        /// <summary>
        /// Retorna el limite de dias en los que se puede solicitar una renovación
        /// </summary>
        public static int TiempoMinimoPermitirRenovacionDias
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("TiempoMinimoPermitirRenovacionDias");
            }
        }

        /// <summary>
        /// Retorna el limite de registros que un gestor puede realizar en un dia
        /// </summary>
        public static int LimiteRegistrosPorGestor
        {
            get
            {
                return HtmlHelper.GetAppVariableAsInt("LimiteRegistrosPorGestor");
            }
        }

        /// <summary>
        /// Hora en que la Camara de Comercio inicia a trabajar.
        /// </summary>
        public static TimeSpan HoraInicioOficina
        {

            get { return HtmlHelper.GetAppVariableAsTimeSpan("HoraInicioOficina"); }
        }

        /// <summary>
        /// Hora en que la Camara Comercio termina de trabajar.
        /// </summary>
        public static TimeSpan HoraFinOficina
        {

            get { return HtmlHelper.GetAppVariableAsTimeSpan("HoraFinOficina"); }
        }

        /// <summary>
        /// Determina si es necesario utilizar Transaction Scope o no
        /// </summary>
        public static bool UseTransactionScopeOnSave
        {
            get { return HtmlHelper.GetAppVariableAsBool("UseTransactionScopeOnSave"); }
        }

        /// <summary>
        /// URL base del portal (root)
        /// </summary>
        public static string UrlPortal
        {
            get { return ConfigurationManager.AppSettings["UrlPortal"]; }
        }

        /// <summary>
        /// Correo desde donde se envían las alertas
        /// </summary>
        public static string FromEmailCorreoCamara
        {
            get { return ConfigurationManager.AppSettings["FromCorreoCamara"]; }
        }

        /// <summary>
        /// Servidor desde donde se envian los correos
        /// </summary>
        public static string MailServer
        {
            get { return HtmlHelper.GetAppVariable("mailserver"); }
        }


        /// <summary>
        /// Usuario de facturación del sistema de gestión
        /// </summary>
        public static string UsuarioFacturacion
        {
            get { return HtmlHelper.GetAppVariable("UsuarioFacturacion"); }
        }

        #endregion //Configuraciones

        #region Integracion con Terceros

        /// <summary>
        /// Dirección URL del API de acceso a las aplicaciones de Nobox
        /// </summary>
        public static string NoboxAPI
        {
            get { return HtmlHelper.GetAppVariable("NoboxAPI"); }
        }

        /// <summary>
        /// Direccion URL del form para loguearse en las aplicaciones de Nobox
        /// </summary>
        public static string NoboxLogin
        {
            get { return HtmlHelper.GetAppVariable("NoboxLogin"); }
        }

        /// <summary>
        /// Direccion URL del form para salir de las aplicaciones de Nobox
        /// </summary>
        public static string NoboxLogout
        {
            get { return HtmlHelper.GetAppVariable("NoboxLogout"); }
        }

        /// <summary>
        /// Dirección URL de la página principal de Nobox
        /// </summary>
        public static string NoboxMainpage
        {
            get { return HtmlHelper.GetAppVariable("NoboxMainPage"); }
        }

        /// <summary>
        /// Application Key en la tabla de tokens de CamaraWebsiteAccounts para Nobox
        /// </summary>
        public static string NoboxApplicationKey
        {
            get { return HtmlHelper.GetAppVariable("NoboxApplicationKey"); }
        }

        /// <summary>
        /// Application Key del url del sistema transaccional donde se envia el pago
        /// </summary>
        public static string TransGatewayUrl
        {
            get { return HtmlHelper.GetAppVariable("TransGatewayUrl"); }
        }

        /// <summary>
        /// Application Key del url del sistema transaccional donde se confirma el token
        /// </summary>
        public static string TransGatewayConfirmUrl
        {
            get { return HtmlHelper.GetAppVariable("TransGatewayConfirmUrl"); }
        }

        /// <summary>
        /// Application Key que almacena el tipo de orden que identifica el Registro Mercantil OFV
        /// </summary>
        public static string TransOrderType
        {
            get { return HtmlHelper.GetAppVariable("TransGatewayOrderType"); }
        }

        /// <summary>
        /// Application Key que almacena la llave del API para hacer llamadas al transaccional
        /// </summary>
        public static string TransGatewayApiKey
        {
            get { return HtmlHelper.GetAppVariable("TransGatewayApiKey"); }
        }

        /// <summary>
        /// Usuario para hacer llamadas al web service de la dgii
        /// </summary>
        public static string WsDgiiUsername
        {
            get { return HtmlHelper.GetAppVariable("wsDgiiUsername"); }
        }

        /// <summary>
        /// Contraseña para hacer llamadas al web service de la dgii
        /// </summary>
        public static string WsDgiiPassword
        {
            get { return HtmlHelper.GetAppVariable("wsDgiiPassword"); }
        }

        /// <summary>
        /// Usado para habilitar integración con ShareBase
        /// </summary>
        public static bool ShareBaseEnabled
        {
            get { return HtmlHelper.GetAppVariableAsBool("ShareBaseEnabled"); }
        }

        /// <summary>
        /// Token usado para autenticar contra ShareBase
        /// </summary>
        public static string ShareBaseToken
        {
            get { return HtmlHelper.GetAppVariable("ShareBaseToken"); }
        }

        #endregion //Integracion con Terceros

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.CorreoPrueba'
        public static bool CorreoPrueba
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.CorreoPrueba'
        {
            get { return HtmlHelper.GetAppVariableAsBool("CorreoPrueba"); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.ReaperturarCasoAccesoActivo'
        public static bool ReaperturarCasoAccesoActivo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.ReaperturarCasoAccesoActivo'
        {
            get { return HtmlHelper.GetAppVariableAsBool("ReaperturarCasoAccesoActivo"); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.ReaperturarCasoAccesoUsers'
        public static List<string> ReaperturarCasoAccesoUsers
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.ReaperturarCasoAccesoUsers'
        {
            get {
                    var users = HtmlHelper.GetAppVariable("ReaperturarCasoAccesoUsers");
                    return users.Split(',').ToList();
                }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.TooltipFirmaDigitalEnvioDatos'
        public static string TooltipFirmaDigitalEnvioDatos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.TooltipFirmaDigitalEnvioDatos'
        {
            get { return HtmlHelper.GetAppVariable("TooltipFirmaDigitalEnvioDatos"); }
        }


        //variable para usuarios factura caja:
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Helper.UsuarioCajaFactura'
        public static string UsuarioCajaFactura
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Helper.UsuarioCajaFactura'
        {
            get { return ConfigurationManager.AppSettings["UsuarioCaja"]; }

           

        }


        //documentos en sharedBase (folder):
        /// <summary>
        /// URL base del portal (root)
        /// </summary>
        public static string NombreCarpetaShareBase
        {
            get { return ConfigurationManager.AppSettings["NombreCarpetaShareBase"]; }
        }

        //documentos en sharedBase (folder):
        /// <summary>
        /// URL base del portal (root)
        /// </summary>
        public static int TimeOutWS
        {
            get {
                return Convert.ToInt32(ConfigurationManager.AppSettings["TimeOutWS"]);
            }
        }


        //Estados BHD:     

        /// <summary>
        ///  <!--new Key sera el estado completado a validar respuesta BHD, para asi guardarlo en la tabla :-->
        /// </summary>
        public static string IdEstadoBHDEmpresarial
        {
            get { return ConfigurationManager.AppSettings["IdEstadoBHDEmpresarial"]; }
        }        


        /// <summary>
        /// Estado a guadar en la tabla local, para desde ahi tomar la descion o No de crear la factura
        /// cuando hayan aprobados en BHD un pago Empresarial.
        /// </summary>
        public static int IdEstadoBHDLocal
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["IdEstadoBHDLocal"]);
            }
        }


        /// <summary>
        /// Estado a guadar en la tabla local, luego que haya sido pagado
        /// cuando hayan aprobados en BHD un pago Empresarial.
        /// </summary>
        public static int IdEstadoBHDLocalPagado
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["IdEstadoBHDLocalPagado"]);
            }
        }


        /// <summary>
        ///  <!--new Key sera el estado rechazado respuesta BHD, para asi guardarlo en la tabla :-->
        /// </summary>
        public static string IdEstadoBHDEmpresarialRechazo
        {
            get { return ConfigurationManager.AppSettings["IdEstadoBHDEmpresarialRechazo"]; }
        }

        //IDestado Rechazado:
      public static int IdEstadoBHDLocalRechazado
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["IdEstadoBHDLocalRechazado"]);
            }
        }


        
        /// <summary>
        ///  <!--new Key url estado transacciones BHD :-->
        /// </summary>
        public static string urlBHDConsultar
        {
            get { return ConfigurationManager.AppSettings["urlConsultar"]; }
        }


        /// <summary>
        ///  <!--new Key url estado transacciones BHD :-->
        /// </summary>
        public static string providerIdBHD
        {
            get { return ConfigurationManager.AppSettings["providerId"]; }
        }

        /// <summary>
        ///  <!--new Key url estado transacciones BHD :-->
        /// </summary>
        public static string serviceIdBHD
        {
            get { return ConfigurationManager.AppSettings["serviceId"]; }
        }





    }

    /// <summary>
    /// Utilitarios
    /// </summary>
    public class Utils
    {


        /// <summary>
        /// Formatea una fecha con el CultureInfo de Rep. Dominicana
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="incluirHora"></param>
        /// <returns></returns>
        public static string FormatearFecha(DateTime fecha, bool incluirHora = false)
        {
            return !incluirHora
                    ? fecha.ToString("dd 'de' MMMM, yyyy", new CultureInfo("es-DO"))
                    : fecha.ToString("dd 'de' MMMM yyyy, hh:mm tt", new CultureInfo("es-DO")).ToUpper();
        }

        /// <summary>
        /// method for validating a url with regular expressions
        /// </summary>
        /// <param name="url">url we're validating</param>
        /// <returns>true if valid, otherwise false</returns>
        public static bool isValidUrl(string url)
        {
            const string pattern = @"^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$";
            var reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        /// <summary>
        /// Construccion de un string para una direccion a partir de un registro de OFV
        /// </summary>
        /// <returns></returns>
        public static string ConstruirDireccion(Registros registro, SRM.Registros registroOrg)
        {
            var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities();

            var sb = new StringBuilder();

            sb.AppendFormat(registroOrg != null && registro.DireccionCalle != registroOrg.Direcciones.Calle
                                ? "<span class='modified'>{0}, </span>"
                                : "{0}, "
                            , registro.DireccionCalle);

            sb.AppendFormat(registroOrg != null && registro.DireccionNumero != registroOrg.Direcciones.Numero
                                ? "<span class='modified'>{0}</br></span>"
                                : "{0}<br/>"
                            , registro.DireccionNumero);

            if (registro.DireccionSectorId.HasValue)
            {
                var nombreSector = dbComun.Sectores.FirstOrDefault(a => a.SectorId == registro.DireccionSectorId).Nombre;
                sb.AppendFormat(registroOrg != null && registro.DireccionSectorId != registroOrg.Direcciones.SectorId
                                ? "<span class='modified'>{0}</br></span>"
                                : "{0}<br/>"
                            , nombreSector);
            }

            var nombreCiudad = registro.DireccionCiudadId.HasValue
                ? dbComun.Ciudades.FirstOrDefault(a => a.CiudadId == registro.DireccionCiudadId).Nombre
                : registro.DireccionCiudad;

            sb.AppendFormat(registroOrg != null && registro.DireccionCiudadId != registroOrg.Direcciones.CiudadId
                                ? "<span class='modified'>{0}</br></span>"
                                : "{0}<br/>"
                            , nombreCiudad);

            return sb.ToString();
        }

        /// <summary>
        /// Construccion de un string para una direccion a partir de un Registro SRM
        /// </summary>
        /// <returns></returns>
        public static string ConstruirDireccion(SRM.Registros registro)
        {
            var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities();

            var sb = new StringBuilder();
            sb.Append(registro.Direcciones.Calle + ", ");
            sb.Append(registro.Direcciones.Numero + "<br/>");

            if (registro.Direcciones.SectorId.HasValue)
            {
                var nombreSector = dbComun.Sectores.FirstOrDefault(a => a.SectorId == registro.Direcciones.SectorId).Nombre;
                sb.Append(nombreSector + "<br/>");
            }

            var nombreCiudad = registro.Direcciones.CiudadId.HasValue
                ? dbComun.Ciudades.FirstOrDefault(a => a.CiudadId == registro.Direcciones.CiudadId).Nombre
                : registro.Direcciones.CiudadDescripcion;

            sb.Append(nombreCiudad + "<br/>");

            return sb.ToString();
        }

        /// <summary>
        /// Clona una entidad T cualquiera
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T Clone<T>(T entity) where T : new()
        {
            //Se usa reflection para obtener todos los fields del tipo, incluyendo los privados
            var fis = entity.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            // Se crea un nuevo objeto vacío
            var newObject = new T();
            //Se itera por todos los fields y se copia la información de la clase anterior
            foreach (var fi in fis)
            {
                fi.SetValue(newObject, fi.GetValue(entity));
            }
            // Se retorna el objeto clonado
            return newObject;
        }

        /// <summary>
        /// Clona una entidad T tipo diccionario cualquiera
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T Clone<T, E>(E entity) where T : new()
        {
            var fis = entity.GetType().GetProperties();

            var newObject = new T();

            var fisNewObject = new List<PropertyInfo>(newObject.GetType().GetProperties());

            foreach (var fi in fis)
            {
                var fi1 = fi;
                var prop = fisNewObject.Find(info => info.Name == fi1.Name);
                if (prop != null)
                    prop.SetValue(newObject, fi.GetValue(entity, null), null);
            }
            return newObject;
        }

        /// <summary>
        /// Determina si la fecha actual es de horario de oficina
        /// </summary>
        /// <returns></returns>
        public static bool IsHorarioOficina()
        {
            var esHorario = false;
            var fecha = DateTime.Now;

            if (fecha.DayOfWeek != DayOfWeek.Saturday && fecha.DayOfWeek != DayOfWeek.Sunday)
                esHorario = Helper.HoraInicioOficina <= fecha.TimeOfDay && Helper.HoraFinOficina >= fecha.TimeOfDay;

            return esHorario;
        }
    }

    /// <summary>
    /// Extension Methods para interactuar con controles de Telerik
    /// </summary>
    public static class RadUtils
    {

        ///<summary>
        /// Obtiene informacion sobre un socio en el control SocioDetails.ascx
        ///</summary>
        ///<param name="tipoRelacion"></param>
        ///<param name="control"></param>
        ///<param name="socioId"></param>
        ///<returns></returns>
        public static Socios GetSocioFromControl(string tipoRelacion, UserControl control, int socioId)
        {
            //Se determina si el socio es de tipo empresa
            var isEmpresa = (TipoSocioView)((MultiView)(control.FindControl("mvDatosGenerales"))).ActiveViewIndex;

            //Se asignan las propiedades del objeto dependiendo del tipo
            Socios socio;

            //Se toma el tipo de documento para validar el formato de cédulas
            var tipoDocumento = GetDropDownValue(control, "ddlTipoDocumento");

            switch (isEmpresa)
            {
                case TipoSocioView.Empresa:
                    //Agregar Informacion aplicable solo a empresas
                    socio = new Socios
                    {
                        Id = socioId,
                        TipoSocio = TipoSocio.Sociedad.ToString(),
                        TipoDocumento = tipoDocumento,
                        PersonaPrimerNombre = GetTextboxValue(control, "txtEmpresa"),
                        SociedadNombreSocial = GetTextboxValue(control, "txtEmpresa"),
                        Documento = tipoDocumento == "C"
                                                    ? GetTextboxValue(control, "txtDocumentoEmpresa").FormatRnc()
                                                    : GetTextboxValue(control, "txtDocumentoEmpresa"),
                        RegistroMercantil = GetTextboxValue(control, "txtRegistroMercantilEmpresa"),
                        RepresentanteId = int.Parse(GetDropDownValue(control, "ddlRepresentanteEmpresa")),
                        NacionalidadId = int.Parse(GetDropDownValue(control, "ddlNacionalidadEmpresa"))
                    };
                    break;
                case TipoSocioView.Persona:
                    //Agregar Informacion aplicable solo a personas fisicas
                    socio = new Socios
                    {
                        Id = socioId,
                        TipoSocio = TipoSocio.Persona.ToString(),
                        PersonaPrimerNombre = GetTextboxValue(control, "txtPrimerNombre"),
                        PersonaSegundoNombre = GetTextboxValue(control, "txtSegundoNombre"),
                        PersonaPrimerApellido = GetTextboxValue(control, "txtPrimerApellido"),
                        PersonaSegundoApellido = GetTextboxValue(control, "txtSegundoApellido"),
                        Documento = tipoDocumento == "C"
                                                    ? GetTextboxValue(control, "txtDocumento").FormatRnc()
                                                    : GetTextboxValue(control, "txtDocumento"),
                        PersonaEstadoCivil = GetDropDownValue(control, "ddlEstadoCivil"),
                        TipoDocumento = GetDropDownValue(control, "ddlTipoDocumento"),
                        RepresentanteId = int.Parse(GetDropDownValue(control, "ddlRepresentante")),
                        NacionalidadId = int.Parse(GetDropDownValue(control, "ddlNacionalidadPersona"))
                    };
                    break;

                case TipoSocioView.AlPortador:
                    socio = new Socios
                    {
                        Id = socioId,
                        TipoSocio = TipoSocio.Persona.ToString(),
                        PersonaPrimerNombre = "AL PORTADOR",
                        PersonaPrimerApellido = String.Empty,
                        PersonaSegundoApellido = String.Empty,
                        PersonaSegundoNombre = String.Empty,
                        Documento = "AL PORTADOR",
                        TipoDocumento = "O"
                    };
                    break;
                default:
                    socio = new Socios();
                    break;

            }

            //Agregar la informacion de la direccion del socio
            socio.DireccionCalle = GetTextboxValue(control, "txtCalle");
            socio.DireccionNumero = GetTextboxValue(control, "txtNumero");
            socio.DireccionApartadoPostal = GetTextboxValue(control, "txtApartadoPostal");
            socio.DireccionCiudadId = Convert.ToInt32("0" + GetDropDownValue(control, "ddlCiudades"));
            socio.DireccionSectorId = Convert.ToInt32("0" + GetDropDownValue(control, "ddlSectores"));

            //Agrego Cargo para socios del organo amnistrador
            var cargo = GetDropDownValue(control, "ddlCargos");
            if (cargo == "CONTROL " + "ddlCargos" + " NOT FOUND!!!")
                cargo = String.Empty;


            //Determinar si la persona se va a agregar como socio.
            socio.TipoRelacion = tipoRelacion;
            socio.CargoId = String.IsNullOrWhiteSpace(cargo) ? 0 : int.Parse(cargo);
            return socio;
        }

        ///<summary>
        /// Obtiene informacion sobre un empresentante del user control RepresentanteDetails.ascx
        ///</summary>
        ///<param name="control"></param>
        ///<param name="personaId"></param>
        ///<returns></returns>
        public static Personas GetRepresentanteFromControl(UserControl control, int personaId)
        {
            var tipoDocumento = GetDropDownValue(control, "ddlTipoDocumento");

            //Se asignan las propiedades del objeto dependiendo del tipo
            //Agregar Informacion aplicable solo a personas fisicas
            var representante = new Personas
            {
                PersonaId = personaId,
                PrimerNombre = GetTextboxValue(control, "txtPrimerNombre"),
                SegundoNombre = GetTextboxValue(control, "txtSegundoNombre"),
                PrimerApellido = GetTextboxValue(control, "txtPrimerApellido"),
                SegundoApellido = GetTextboxValue(control, "txtSegundoApellido"),
                Documento = GetTextboxValue(control, "txtDocumento"),
                EstadoCivil = GetDropDownValue(control, "ddlEstadoCivil"),
                TipoDocumento = tipoDocumento
            };

            //Determinar si la persona se va a agregar como socio.
            return representante;
        }

        private static string GetDropDownValue(UserControl control, string id)
        {
            var dropDown = control.FindControl(id) as DropDownList;
            if (dropDown == null) return "CONTROL " + id + " NOT FOUND!!!";
            return dropDown.SelectedItem == null ? (dropDown.SelectedValue ?? "") : dropDown.SelectedItem.Value;
        }

        private static string GetTextboxValue(UserControl control, string id)
        {
            var textBox = control.FindControl(id) as RadTextBox;
            return textBox == null ? "CONTROL " + id + " NOT FOUND!!!" : textBox.Text.Trim();
        }

        ///<summary>
        /// Obtiene el valor de un checkbox desde un user control
        ///</summary>
        ///<param name="control"></param>
        ///<param name="id"></param>
        ///<returns></returns>
        public static bool GetCheckboxValue(UserControl control, string id)
        {
            var checkBox = control.FindControl(id) as CheckBox;
            return checkBox == null ? false : checkBox.Checked;
        }

        /// <summary>
        /// Obtiene el valor de un checkboxList desde un user control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="id"></param>
        /// <param name="tipoSocioId"></param>
        /// <returns></returns>
        public static bool GetCheckboxListValue(UserControl control, string id, string tipoSocioId)
        {
            var checkBox = control.FindControl(id) as CheckBoxList;
            if (checkBox == null) return false;

            var list = checkBox.Items.FindByValue(tipoSocioId);
            return list == null ? false : list.Selected;
        }

        /// <summary>
        /// Obtiene el valor de un checkbox dentro de un repeater
        /// </summary>
        /// <param name="control"></param>
        /// <param name="repeaterId"></param>
        /// <param name="id"></param>
        /// <param name="hiddenFieldid"></param>
        /// <param name="tipoSocioId"></param>
        /// <returns></returns>
        public static bool GetCheckboxInsideRepeater(UserControl control, string repeaterId, string id, string hiddenFieldid, string tipoSocioId)
        {
            var repControl = control.FindControl(repeaterId) as Repeater;

            if (repControl != null)
                foreach (RepeaterItem item in repControl.Items)
                {
                    var checkSocio = item.FindControl(id) as CheckBox;
                    var hfTipoSocio = item.FindControl(hiddenFieldid) as HiddenField;

                    if (checkSocio == null || hfTipoSocio == null)
                        return false;
                    if (hfTipoSocio.Value == tipoSocioId)
                        return checkSocio.Checked;
                }
            return false;
        }

#pragma warning disable CS1573 // Parameter 'id' has no matching param tag in the XML comment for 'RadUtils.CheckValidationGroupInRepeater(UserControl, string, string, string)' (but other parameters do)
        /// <summary>
        /// Revisa si más de un elemento contiene el mismo validation group
        /// </summary>
        /// <param name="control"></param>
        /// <param name="repeaterId"></param>
        /// <param name="hiddenFieldId"></param>
        /// <returns></returns>
        public static bool CheckValidationGroupInRepeater(UserControl control, string repeaterId, string id, string hiddenFieldId)
#pragma warning restore CS1573 // Parameter 'id' has no matching param tag in the XML comment for 'RadUtils.CheckValidationGroupInRepeater(UserControl, string, string, string)' (but other parameters do)
        {
            var list = new List<Int32>();
            var valid = true;
            var repControl = control.FindControl(repeaterId);
            if (repControl != null && repControl is Repeater)
            {
                //Se recorre toda la colección para obtener los IDs de grupos 
                foreach (RepeaterItem item in ((Repeater)repControl).Items)
                {
                    var checkSocio = item.FindControl(id) as CheckBox;
                    var hf = item.FindControl(hiddenFieldId) as HiddenField;
                    if (checkSocio != null && checkSocio.Checked &&
                        hf != null && !String.IsNullOrEmpty(hf.Value))
                    {
                        var grupo = 0;
                        Int32.TryParse(hf.Value, out grupo);
                        list.Add(grupo);
                    }
                }
                var grouped = list.Where(l => l > 0).GroupBy(l => l)
                                  .Select(g => new { Grupo = g.Key, Cantidad = g.Sum() });
                valid = grouped.Where(g => g.Cantidad > 1).Count() == 0;
            }

            return valid;
        }

        /// <summary>
        /// Obtiene el valor de un dropdown desde un user control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="repeaterId"></param>
        /// <param name="id"></param>
        /// <param name="hiddenFieldid"></param>
        /// <param name="dropDownId"></param>
        /// <param name="tipoSocioId"></param>
        /// <returns></returns>
        public static string GetDropDownValueInsideRepeater(UserControl control, string repeaterId, string id, string hiddenFieldid,
            string dropDownId, string tipoSocioId)
        {
            var repControl = control.FindControl(repeaterId) as Repeater;

            if (repControl != null)
                foreach (RepeaterItem item in repControl.Items)
                {
                    var checkSocio = item.FindControl(id) as CheckBox;
                    var hfTipoSocio = item.FindControl(hiddenFieldid) as HiddenField;
                    var dropDown = item.FindControl(dropDownId) as DropDownList;

                    if (checkSocio == null || hfTipoSocio == null)
                        return String.Empty;
                    if (hfTipoSocio.Value == tipoSocioId && dropDown != null)
                        return dropDown.SelectedValue;
                }

            return String.Empty;
        }

        /// <summary>
        /// Obtiene el valor de un textbox desde un user control
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="repeaterId"></param>
        /// <param name="id"></param>
        /// <param name="hiddenFieldid"></param>
        /// <param name="tipoSocioId"></param>
        /// <returns></returns>
        public static string GetTextBoxValueInsideRepeater<T>(UserControl control, string repeaterId, string id, string hiddenFieldid,
            string tipoSocioId) where T : class, ITextControl
        {
            var repControl = control.FindControl(repeaterId) as Repeater;

            if (repControl != null)
                foreach (RepeaterItem item in repControl.Items)
                {
                    var txtNoAcciones = item.FindControl(id) as T;
                    var hfTipoSocio = item.FindControl(hiddenFieldid) as HiddenField;

                    if (txtNoAcciones == null || hfTipoSocio == null)
                        return String.Empty;
                    if (hfTipoSocio.Value == tipoSocioId)
                        return txtNoAcciones.Text;
                }

            return String.Empty;
        }
    }

    /// <summary>
    /// Indica el tipo de socio que estoy procesando desde el UI.
    /// </summary>
    public enum TipoSocioView
    {
        /// <summary>
        /// Indica si es un socio de tipo Persona.
        /// </summary>
        Persona = 0,

        /// <summary>
        /// /// Indica si es un socio de tipo Empresa.
        /// </summary>
        Empresa = 1,

        /// <summary>
        /// Indica si el tipo de socio es Al Portador.
        /// </summary>
        AlPortador = 2
    }

    ///<summary>
    /// Helper de HTML
    ///</summary>
    public static class HtmlHelper
    {
        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static string GetAppVariable(string varName)
        {
            var reader = new AppSettingsReader();
            return (string)reader.GetValue(varName, typeof(string));
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Int
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static int GetAppVariableAsInt(string varName)
        {
            var reader = new AppSettingsReader();
            return (Int32)reader.GetValue(varName, typeof(Int32));
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Booleano
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static bool GetAppVariableAsBool(string varName)
        {
            var reader = new AppSettingsReader();
            return (bool)reader.GetValue(varName, typeof(Boolean));
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Decimal
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static decimal GetAppVariableAsDecimal(string varName)
        {
            var response = 0m;
            var reader = new AppSettingsReader();
            response = (Decimal)reader.GetValue(varName, typeof(Decimal));
            return response;
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Decimal
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static TimeSpan GetAppVariableAsTimeSpan(string varName)
        {
            var reader = new AppSettingsReader();
            return ((String)reader.GetValue(varName, typeof(String))).ToTimeSpan();
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como TimeSpan
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static T GetAppVariableAsT<T>(string varName)
        {
            var reader = new AppSettingsReader();
            return (T)reader.GetValue(varName, typeof(T));
        }

        ///<summary>
        /// Crea un attachment
        ///</summary>
        ///<param name="strId"></param>
        ///<returns></returns>
        public static string CreateAttachment(String strId)
        {
            //Generando Codigo de Barras
            var objCodigo = CodigoBarras.ObtenerCodigoBarras(strId);
            var stream = new MemoryStream(objCodigo);

            var fileName = "codigo" + strId + ".png";
            var sw = new StreamWriter(fileName);
            stream.WriteTo(sw.BaseStream);

            return fileName;
        }

        ///<summary>
        /// Convierte un string a Timespan
        ///</summary>
        ///<param name="s"></param>
        ///<returns></returns>
        public static TimeSpan ToTimeSpan(this string s)
        {
            var result = s.Split(":".ToCharArray()).Select(c => int.Parse(c)).ToList();
            var t = new TimeSpan(result[0], result[1], result[2]);
            return t;
        }

        /// <summary>
        /// Obtiene un parametro del Request String
        /// </summary>
        /// <param name="request">Objeto del request</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns></returns>
        public static string GetParam(this HttpRequest request, string paramName)
        {
            return !String.IsNullOrWhiteSpace(request.QueryString[paramName])
                       ? request.QueryString[paramName]
                       : String.Empty;
        }

    }
}
