using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Transactions;
using System.Web.Services;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.WebServices.GestionWs;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.WebServices.Helpers;
using Servicio = CamaraComercio.WebServices.Servicios.Servicio;

//using CamaraComercio.WebServices.Dynamics365WS;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.TarjetaCredito;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website;

namespace CamaraComercio.WebServices.Facturacion
{

    /// <summary>
    /// Interace que define los metodos de interaccion con los sistemas de gestión/contabilidad
    /// </summary>
    public interface IFacturaHandler
    {
        /// <summary>
        /// Método que genera una factura en el sistema de gestión
        /// </summary>
        /// <param name="rnc">Cedula o RNC del cliente para quien se genera la factura</param>
        /// <param name="nombre">Nombre del cliente para quien se genera la factura</param>
        /// <param name="tipoComprobante">Tipo de comprobante fiscal</param>
        /// <param name="camaraID">ID de la cámara para la cual se solicita la factura</param>
        /// <param name="usuario">Usuario del sistema de gestión que solicita la factura </param>
        /// <param name="serviciosFacturados">Listado de servicios que se facturan</param>
        /// <param name="registroPagos">Listado de las formas de pago con que se salda la factura</param>
        /// <returns></returns>
        Factura GenerarFactura(string rnc, string nombre, int tipoComprobante,
                               string camaraId, string usuario, List<Servicio> serviciosFacturados,
                                List<RegistroPago> registroPagos, bool? reclamaSaldoPendiente);
    }

    /// <summary>
    /// Representa una factura a ser insertada en cualquiera de los sistemas de contabilidad
    /// </summary>
    public class Factura
    {
        public string NumeroFactura { get; set; }
        public string NCF { get; set; }
        public EstadoFactura Estado { get; set; }
    }

    /// <summary>
    /// Define un registro de pago asociado a una factura
    /// </summary>
    public class RegistroPago
    {
        public int MetodoPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal ValorEntregado { get; set; }
        public decimal ValorDevuelto { get; set; }
        public string Nota { get; set; }
        public string Refenrencia { get; set; }
        public string TarjetaCredito { get; set; }
        public int BancoID { get; set; }
        public int NotaCreditoId { get; set; }
        public string VoucherNotaCredito { get; set; }
    }

    #region Implementaciones

    /// <summary>
    /// Servicio de facturacion integrado con el nuevo sistema de gestión
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    public class SistemaGestionFacturaHandler : WebService, IFacturaHandler
    {


        Boolean FacturaDynamics = Convert.ToBoolean(ConfigurationManager.AppSettings["ActiveDiynamics365Factura"]);
        string Appid = ConfigurationManager.AppSettings["AppId"].ToString();
        string countryRegionId = ConfigurationManager.AppSettings["countryRegionId"].ToString();
        string customerGroupId = ConfigurationManager.AppSettings["customerGroupId"].ToString();
        string salesCurrencyCode = ConfigurationManager.AppSettings["salesCurrencyCode"].ToString();
        string UserDynamics365 = ConfigurationManager.AppSettings["UsuarioIdDynamics365"].ToString();

        public bool wsGuardarComentarioNCF = Convert.ToBoolean(ConfigurationManager.AppSettings["wsGuardarComentarioNCF"]);



        [WebMethod(Description = "Obtiene el detalle de una nota de creditos existente")]
        public FormaPagosSRM GetNotaCreditoMonto(int TransaccionSRMId, string camaraId)
        {

            // WebServices DGII
            string UrlwsFacturacionSRM = ConfigurationManager.AppSettings["wsFacturacionSRM"].ToString();


            var dbComun = new CamaraComunEntities();

            try
            {

                var _wsFacturacionSRM = new WebSrmWS.FacturacionSRM
                {
                    Url = UrlwsFacturacionSRM
                };

                var RetornarMonto = _wsFacturacionSRM.AgregaPagosConNotasVigentesSRM(TransaccionSRMId, camaraId);

                return new FormaPagosSRM
                {
                    NumeroNotaCredito = (RetornarMonto.NumeroNotaCredito == null) ? 0 : RetornarMonto.NumeroNotaCredito,
                    Valor = RetornarMonto.Valor,
                    Referencia = RetornarMonto.Referencia,
                    FormaPagoDesc = RetornarMonto.FormaPagoDesc,
                    FormaPago = RetornarMonto.FormaPago,
                    NotaCreditoValida = RetornarMonto.NotaCreditoValida,
                    FechaCreacionNota = RetornarMonto.FechaCreacionNota, 
                    Voucher =  RetornarMonto.Voucher
                };
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new FormaPagosSRM
                {
                    NumeroNotaCredito = 0,
                    Valor = 0,
                    Referencia = "Error",
                    FormaPagoDesc = ex.Message,
                    FormaPago = "0",
                    NotaCreditoValida ="false",
                    FechaCreacionNota = DateTime.MinValue, 
                    Voucher = ""


                };
            }

            // Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            //  return new FormasPagoViewModel();
        }


        [WebMethod]
        public Factura GenerarFactura(string rnc, string nombre, int tipoComprobante,
     string camaraId, string usuario, List<Servicio> serviciosFacturados,
     List<RegistroPago> registroPagos, bool? reclamaSaldoPendiente)
        {

            //codigo temporal, simulacion ambiente forzado: 2021-07-10:
            Random rnd = new Random();
            int ncfRN = rnd.Next(621, 999);   // creates a number between 1 and 6             

            return new Factura
            {
                Estado = EstadoFactura.Emitida,
                NCF = "B0200107" + ncfRN.ToString(), //B0200107620
                NumeroFactura = "FACT-" + ncfRN.ToString() //dynamicsFact.InvoiceId
            };
            //end simulacion ncf


            //var nombreFinal = rnc.Trim().Length == 0 ? "Persona Física" : nombre;
            string nombreFinal = string.Empty;
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["PersonaFisica"]))
            {
                nombreFinal = rnc.Trim().Length == 0 ? "Persona Física" : nombre;
            }
            else
                nombreFinal = nombre;

            var tipoCompFinal = rnc.Trim().Length == 0 ? 2 : tipoComprobante;
            var rncSinGuiones = rnc.Replace("-", "");

            var correlativo = 1;

            var TransaccionId = (from Servicio data in serviciosFacturados
                                 where data.Total > 0
                                 select data.TransaccionId).FirstOrDefault();

            //colocar en un key un booleano que identifique el destino contable.
            //dynamics
            if (FacturaDynamics)
            {
                string camaraIdDynamics = string.Empty;
                int TimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["wsTimeoutDynamics365"].ToString());
                var dynamicsClient = new WSIntegrationDynamics365.IntegracionDynamics365WS
                {
                    Url = ConfigurationManager.AppSettings["SgccServicePath"],
                    UserIntegrationValue = new WSIntegrationDynamics365.UserIntegration
                    {

                        UserName = ConfigurationManager.AppSettings["UserDynamics365"].ToString(), // usuario del header de request
                        Password = ConfigurationManager.AppSettings["PasswordDynamics365"].ToString() // usuario del header de request
                    },
                    Timeout = TimeOut // 5 min de espera de respuesta
                };

                //var validarUsuario = dynamicsClient.ValidarRepresentante(UserDynamics365, Appid);

                //if (validarUsuario.Any())
                //{
                //    throw new Exception(validarUsuario[0].mensaje);
                //}

                //using (var db = new CamaraComunEntities())
                //{
                //    var currentCamara = db.Camaras.Where(s => s.ID == camaraId).FirstOrDefault();

                //    if (camaraId == "SDQ")
                //    {
                //        camaraIdDynamics = "CCPS";
                //    }
                //    else
                //    {
                //      //  camaraIdDynamics = currentCamara.CamaraIdEnDynamics;
                //    }

                //}


                var facturaArg = new WSIntegrationDynamics365.WSFacturasArg();

                facturaArg.idEmpresa = ConfigurationManager.AppSettings["camaraIdDynamics"].ToString(); 
                // = camaraIdDynamics;

                //colocar esto en key
                facturaArg.appId = Appid; // 03 = SEL, esto es para saber el origen de la app en dynamics, se queda statico
                facturaArg.countryRegionId = countryRegionId; // region a cual saldra la factura, se queda statico
                facturaArg.customerGroupId = customerGroupId; // grupo de cliente en dynamics, se queda statico
                facturaArg.salesCurrencyCode = salesCurrencyCode; // tipo de moneda a facturar, se queda estatico
                facturaArg.unidadNegocio = ConfigurationManager.AppSettings["unidadNegocio"].ToString();
                facturaArg.desicionSaldoPendienteField =(reclamaSaldoPendiente.Value) ? WSIntegrationDynamics365.DesicionSaldoPendiente.ReclamaraSaldoPendiente: WSIntegrationDynamics365.DesicionSaldoPendiente.None;
                //

                facturaArg.factura = new WSIntegrationDynamics365.WSFactura
                {
                    Cliente = nombreFinal,
                    RncCliente = rncSinGuiones,
                    TipoNcf = "B" + tipoComprobante.ToString().PadLeft(2, '0'),
                    Complementaria = string.Empty,
                    Fecha = DateTime.Now,
                    TransaccionId = TransaccionId,
                    Usuario = "",//UserDynamics365, // id del usuario en dynamics (Eliz Saul), colocar en key con el id de usuario definitivo
                };

                facturaArg.detalle = (from Servicio data in serviciosFacturados
                                      where data.Total > 0
                                      select new WSIntegrationDynamics365.WSDetalleFacturas
                                      {
                                          Cantidad = data.Cantidad.ConvertToInt32Value(),
                                          IdProducto = "RM" + data.Codigo.PadLeft(4, '0'),
                                          Descuento = data.Descuento,
                                          Precio = data.PrecioUnitario,
                                          Descripcion = data.Descripcion
                                      }).ToArray();


                // 1 carner
                //2 BOTONBHD



                facturaArg.pagos = (from RegistroPago data in registroPagos
                                    select new WSIntegrationDynamics365.WSPago
                                    {
                                        Monto = data.Monto,
                                        TipoPago = (data.MetodoPago == 1) ? WSIntegrationDynamics365.TipoPago.TCAZUL : 
                                            (data.MetodoPago == 8) ? WSIntegrationDynamics365.TipoPago.NOTACREDITO : WSIntegrationDynamics365.TipoPago.BOTONBHD, // especificar tipo de tarjeta segun solicitud
                                        Nota = string.Empty, // aqui colocar los 4 ultimos digitos de tarjeta si se captura.
                                        VoucherNotaCredito = data.VoucherNotaCredito
                                    }).ToArray();


              
                var dynamicsFact = dynamicsClient.AgregarFactura(facturaArg);


                //guardar log: in BD:
                if (wsGuardarComentarioNCF)
                {
               var  ccOmentario = "nombreF: " + nombre + "-Nollego: " + nombre + "-NCF_llego: "
                        + tipoComprobante + "-tipoNC: " + tipoCompFinal + "-ENVIA: " + facturaArg.factura.TipoNcf + "Resp.: " + dynamicsFact.NCFId;

                    GuadarLogNCF(TransaccionId, ccOmentario);
                }


                if (dynamicsFact.hasError == 1)
                {

                    UtilError.InscribirLogError(dynamicsFact.errores[0].mensaje, "ERROR RESPONSE 365");

                    throw new Exception(dynamicsFact.errores[0].mensaje);
                    //throw new Exception("Errores en el proceso de facturación.");
                }


                return new Factura
                {
                    Estado = EstadoFactura.Emitida,
                    NCF = dynamicsFact.NCFId,
                    NumeroFactura = dynamicsFact.InvoiceId
                };
            }
            //gestion
            else
            {
                var servicios = (from Servicio data in serviciosFacturados
                                 where data.Total > 0
                                 select new cDetallefacturas
                                 {
                                     Cantidad = data.Cantidad.ConvertToInt32Value(),
                                     IdProducto = data.Codigo.ConvertToInt32Value(),
                                     Descuento = data.Descuento,
                                     Precio = data.PrecioUnitario,
                                     Correlativo = correlativo++
                                 }).ToArray();

                correlativo = 1;
                var pagos = (from RegistroPago data in registroPagos
                             select new cIngresopago
                             {
                                 Correlativo = correlativo++,
                                 TipoTrasaccion = SgccDictionary.GetFormaPago(data.MetodoPago),
                                 Total = data.Monto,
                                 IdEmisorBanco = data.BancoID,
                                 NoBoleta = data.NotaCreditoId.ToString(),
                             }).ToArray();

                var servicio = new Contabilidad { Url = ConfigurationManager.AppSettings["SgccServicePath"] };
                //todo : Jason pasa el numero de transaccion correcto al WebService
                var gestFact = servicio.Ingreso_Factura(CamarasController.GetGestionId(camaraId),
                    usuario, rncSinGuiones, nombreFinal, DateTime.Now, tipoCompFinal,
                    servicios, pagos, 1, TransaccionId , DesicionSaldoPendiente.None);
                return new Factura
                {
                    Estado = EstadoFactura.Emitida,
                    NCF = gestFact.NCF,
                    NumeroFactura = gestFact.NoFactura.ToString()
                };
            }
        }


        /// <summary>
        /// @josantos
        /// actualiza la camara cuando se seleccione otra diferente
        /// </summary>
        /// <param name="transaccionId"></param>
        private void GuadarLogNCF(int transaccionId, string comentario)
        {
            if (transaccionId == 0) return;
            //si la camara en seccion es igual a la camara seleccionada, se finaliza el metodo.

            using (var db = new OFV.CamaraWebsiteEntities())
            {
                using (var scope = new TransactionScope())
                {

                    var transOnapi = db.Transacciones.FirstOrDefault(f => f.TransaccionId == transaccionId);
                    if (transOnapi == null)
                        return;
                    else
                    {
                        transOnapi.Comentario = comentario;
                        // transOnapi.Camara = camara;
                        db.SaveChanges();
                        scope.Complete();
                    }
                }

            }
        }


        [WebMethod(Description = "Obtiene el detalle de una nota de creditos existente")]
        public VigenciaNotaCreditoSRM ValidacionVigenciaNotaCredito(int TransaccionSRMId, string camaraId)
        {

            // WebServices DGII
            string UrlwsFacturacionSRM = ConfigurationManager.AppSettings["wsFacturacionSRM"].ToString();


            var dbComun = new CamaraComunEntities();

            try
            {

                var _wsFacturacionSRM = new WebSrmWS.FacturacionSRM
                {
                    Url = UrlwsFacturacionSRM
                };

                var RetornarMonto = _wsFacturacionSRM.ValidacionVigenciaNotaCreditoSRM(TransaccionSRMId, camaraId);

                return new VigenciaNotaCreditoSRM
                {
                    
                    NotaCreditoValida = RetornarMonto.NotaCreditoValida,
                    FechaCreacionNota = RetornarMonto.FechaCreacionNota,
                    DiasTranscurridos = RetornarMonto.DiasTranscurridos,
                    IdNotaCredito = RetornarMonto.IdNotaCredito

                };
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new VigenciaNotaCreditoSRM
                {
                    
                    NotaCreditoValida = "false",
                    FechaCreacionNota = DateTime.MinValue,
                    DiasTranscurridos =0,
                    IdNotaCredito =0


                };
            }

            // Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            //  return new FormasPagoViewModel();
        }

        //pagos TransaccionesEmpresariales_BHD:
        [WebMethod(Description = "Generar Facturas para boton pagos Empresarial")]
        public void EnviarFacturasPagosEmpresarial(int _SolicitudId, string _usuario)
        {

            // WebServices DGII
           

            var dbComun = new CamaraComunEntities();

            try
            {

               

                PagosTarjeta PagoTarj = new PagosTarjeta();
                var result = PagoTarj.ProcesarTransaccionMandarSRM(_SolicitudId, true);
                var dbWeb = new CamaraWebsiteEntities();
                var resultadofbd = dbWeb.TransaccionesEmpBHD.Where(x => x.SolicitudId == _SolicitudId).FirstOrDefault();

                if (resultadofbd != null)
                {

                    using (var db = new CamaraWebsiteEntities())
                    {
                        var resultt = db.TransaccionesEmpBHD.Where(x => x.SolicitudId == _SolicitudId).FirstOrDefault();
                        if (resultt != null)
                        {
                            resultt.Estatus = Helper.IdEstadoBHDLocalPagado; // 2;
                            db.SaveChanges();
                        }
                    }
                }



            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }

            // Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            //  return new FormasPagoViewModel();
        }



    }

    /// <summary>
    /// Servicio de facturacion integrado con DbFlex
    /// </summary>
    [Obsolete("Método para integración el dbFlex. Ya no se utiliza")]
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    public class DbFlexFacturaHandler : WebService, IFacturaHandler
    {
        [WebMethod(Description = "Genera una factura en el BigFlex")]
        public Factura GenerarFactura(string rnc, string nombre, int tipoComprobante,
            string camaraId, string usuario, List<Servicio> serviciosFacturados, List<RegistroPago> registroPagos, bool? reclamaSaldoPendiente = null)
        {
            if (serviciosFacturados == null || serviciosFacturados.Count == 0)
                return new Factura { Estado = EstadoFactura.Cancelada, NCF = "", NumeroFactura = "" };

            var header = serviciosFacturados[0];
            var ncf = string.Empty;

            //Se busca la camara para la cual se solicita la creacion de la factura
            var camaraCtrl = new Comun.CamarasController();
            var camarasCol = camaraCtrl.FetchByID(camaraId);
            if (camarasCol == null || camarasCol.Count() == 0)
            {
                return new Factura { Estado = EstadoFactura.Cancelada, NCF = "", NumeroFactura = "" };
            }
            var camara = camarasCol.First();
            var empresaId = camara.GestionID.HasValue ? camara.GestionID.Value : 0;

            using (var ts = new TransactionScope())
            {
                try
                {
                    var srm = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(camaraId));

                    //Valida los ncf.
                    var ncfRepository = new Repository<TiposNcf, CamaraSRMEntities>(srm);
                    var tipoNcf = ncfRepository.SelectByKey(TiposNcf.PropColumns.TipoNcfId, (int)tipoComprobante);

                    //TODO Se Comento la linea de generacion de ncf, toca corregir o remover este metodo.
                    //var result = srm.GetNcfSecuencia(tipoNcf.Codigo);
                    //ncf = result.FirstOrDefault();
                    ncf = String.Empty;

                    if (String.IsNullOrEmpty(ncf))
                        throw new Exception("No se pudo generar la factura por que no se creo el Ncf.");

                    srm.SentInvoiceHeaderToAccounting(header.TransaccionId, header.Fecha.Date, rnc, header.CgControl,
                                                      header.Cliente, header.IdReg, ncf, 0, usuario, header.TotalPagar);

                    foreach (var facturado in serviciosFacturados)
                        srm.SentInvoiceDetailToAccounting(facturado.TransaccionId, facturado.Fecha, usuario,
                                                              facturado.Codigo, facturado.Descripcion,
                                                              Convert.ToDecimal(facturado.Cantidad),
                                                              facturado.PrecioUnitario, facturado.Descuento,
                                                              facturado.Total, facturado.TotalBruto, facturado.CgControl);

                    foreach (var registroPago in registroPagos)
                    {
                        srm.SentPaymentMethodsToAccounting(header.TransaccionId,
                                                               registroPago.Fecha.Date,
                                                               Convert.ToInt32(registroPago.MetodoPago).ToString(),
                                                               registroPago.Monto, 1, registroPago.Refenrencia,
                                                               registroPago.TarjetaCredito, 1,
                                                               registroPago.ValorEntregado, registroPago.ValorDevuelto,
                                                               registroPago.Nota, usuario, header.TotalPagar,
                                                               header.CgControl);
                    }

                    ts.Complete();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return new Factura { Estado = EstadoFactura.Cancelada, NCF = ncf, NumeroFactura = header.TransaccionId.ToString() };
                }
            }
            return new Factura { Estado = EstadoFactura.Emitida, NCF = ncf, NumeroFactura = header.TransaccionId.ToString() };
        }



    }

    [Obsolete("Método de mockup(pruebas). NO UTILIZAR")]
    public class MockupFacturaHandler : WebService, IFacturaHandler
    {
        [WebMethod(Description = "Genera una factura para pruebas del web service")]
        public Factura GenerarFactura(string rnc, string nombre, int tipoComprobante,
            string camaraId, string usuario, List<Servicio> serviciosFacturados, List<RegistroPago> registroPagos,
            bool? reclamaSaldoPendiente = null)
        {
            return new Factura()
            {
                Estado = EstadoFactura.Emitida,
                NCF = GetNcf(tipoComprobante, camaraId),
                NumeroFactura = ""
            };
        }

        private static string GetNcf(int tipoComprobante, string camaraId)
        {
            var dbComun = new CamaraComunEntities();
            var tipoNcfId = (int)tipoComprobante;
            var tipoNcf = dbComun.TiposNcf.FirstOrDefault(a => a.TipoNcfId == tipoNcfId);
            return "A" + new Random().Next(10000000).ToString();
        }
    }

    #endregion
}