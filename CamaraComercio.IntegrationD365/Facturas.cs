
using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.Objects;
using System.Linq;
//using System.Transactions;
using System.Web.Services;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;

using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;


using CamaraComercio.IntegrationD365.WSIntegrationDynamics365;

using ServicioD365 = CamaraComercio.WebServices.Servicios.ServicioD365;

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
        FacturaD365 GenerarFacturaD365(string rnc, string nombre, int tipoComprobante,
                               string camaraId, string usuario, List<WebServices.Servicios.ServicioD365> serviciosFacturados,
                                List<RegistroPagoD365> registroPagos, bool? reclamaSaldoPendiente);
    }

    /// <summary>
    /// Representa una factura a ser insertada en cualquiera de los sistemas de contabilidad
    /// </summary>
    public class FacturaD365
    {
        public string NumeroFactura { get; set; }
        public string NCF { get; set; }
        public EstadoFactura Estado { get; set; }
    }

    /// <summary>
    /// Define un registro de pago asociado a una factura
    /// </summary>
    public class RegistroPagoD365
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
   // [WebService(Namespace = "http://www.registromercantil.org.do/")]
    public class SistemaFacturacionD365: IFacturaHandler
    {


        Boolean FacturaDynamics = Convert.ToBoolean(ConfigurationManager.AppSettings["ActiveDiynamics365Factura"]);
        string Appid = ConfigurationManager.AppSettings["AppId"].ToString();
        string countryRegionId = ConfigurationManager.AppSettings["countryRegionId"].ToString();
        string customerGroupId = ConfigurationManager.AppSettings["customerGroupId"].ToString();
        string salesCurrencyCode = ConfigurationManager.AppSettings["salesCurrencyCode"].ToString();
        string UserDynamics365 = ConfigurationManager.AppSettings["UsuarioIdDynamics365"].ToString();


        public FacturaD365 GenerarFacturaD365(string rnc, string nombre, int tipoComprobante,
         string camaraId, string usuario, List<WebServices.Servicios.ServicioD365> serviciosFacturados,
         List<RegistroPagoD365> registroPagos, bool? reclamaSaldoPendiente)
        {
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

            var TransaccionId = (from ServicioD365 data in serviciosFacturados
                                 where data.Total > 0
                                 select data.TransaccionId).FirstOrDefault();

            //colocar en un key un booleano que identifique el destino contable.
            //dynamics
            //if (FacturaDynamics)
            //{
                string camaraIdDynamics = string.Empty;
                int TimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["wsTimeoutDynamics365"].ToString());
                var dynamicsClient = new IntegrationD365.WSIntegrationDynamics365.IntegracionDynamics365WS
                {
                    Url = ConfigurationManager.AppSettings["SgccServicePath"],
                    UserIntegrationValue = new IntegrationD365.WSIntegrationDynamics365.UserIntegration
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


                var facturaArg = new IntegrationD365.WSIntegrationDynamics365.WSFacturasArg();

                facturaArg.idEmpresa = ConfigurationManager.AppSettings["camaraIdDynamics"].ToString();
                // = camaraIdDynamics;

                //colocar esto en key
                facturaArg.appId = Appid; // 03 = SEL, esto es para saber el origen de la app en dynamics, se queda statico
                facturaArg.countryRegionId = countryRegionId; // region a cual saldra la factura, se queda statico
                facturaArg.customerGroupId = customerGroupId; // grupo de cliente en dynamics, se queda statico
                facturaArg.salesCurrencyCode = salesCurrencyCode; // tipo de moneda a facturar, se queda estatico
                facturaArg.unidadNegocio = ConfigurationManager.AppSettings["unidadNegocio"].ToString();
                //

                facturaArg.factura = new IntegrationD365.WSIntegrationDynamics365.WSFactura
                {
                    Cliente = nombreFinal,
                    RncCliente = rncSinGuiones,
                    TipoNcf = "B" + tipoComprobante.ToString().PadLeft(2, '0'),
                    Complementaria = string.Empty,
                    Fecha = DateTime.Now,
                    TransaccionId = TransaccionId,
                    Usuario = "",//UserDynamics365, // id del usuario en dynamics (Eliz Saul), colocar en key con el id de usuario definitivo
                };

                facturaArg.detalle = (from ServicioD365 data in serviciosFacturados
                                      where data.Total > 0
                                      select new IntegrationD365.WSIntegrationDynamics365.WSDetalleFacturas
                                      {
                                          Cantidad =0,// data.Cantidad.ConvertToInt32Value(),
                                          IdProducto = "RM" + data.Codigo.PadLeft(4, '0'),
                                          Descuento = data.Descuento,
                                          Precio = data.PrecioUnitario,
                                          Descripcion = data.Descripcion
                                      }).ToArray();


                // 1 carner
                //2 BOTONBHD



                facturaArg.pagos = (from RegistroPagoD365 data in registroPagos
                                    select new IntegrationD365.WSIntegrationDynamics365.WSPago
                                    {
                                        Monto = data.Monto,
                                        TipoPago = (data.MetodoPago == 1) ? IntegrationD365.WSIntegrationDynamics365.TipoPago.TCAZUL :
                                            (data.MetodoPago == 8) ? IntegrationD365.WSIntegrationDynamics365.TipoPago.NOTACREDITO : IntegrationD365.WSIntegrationDynamics365.TipoPago.BOTONBHD, // especificar tipo de tarjeta segun solicitud
                                        Nota = string.Empty, // aqui colocar los 4 ultimos digitos de tarjeta si se captura.
                                        VoucherNotaCredito = data.VoucherNotaCredito
                                    }).ToArray();



                var dynamicsFact = dynamicsClient.AgregarFactura(facturaArg);


                if (dynamicsFact.hasError == 1)
                {
                    throw new Exception(dynamicsFact.errores[0].mensaje);
                    //throw new Exception("Errores en el proceso de facturación.");
                }


            return new FacturaD365
            {
                Estado = EstadoFactura.Emitida,
                NCF = dynamicsFact.NCFId,
                NumeroFactura = dynamicsFact.InvoiceId
            };
          //  return dynamicsFact.NCFId;
           // }




        }




    }


    public enum EstadoFactura
    {
        Emitida = 1,
        Cancelada = 2,
        NotaDeCredito = 3
    }




}



/*

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
                    DiasTranscurridos = 0,
                    IdNotaCredito = 0


                };
            }

            // Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            //  return new FormasPagoViewModel();
        }



    }

   */


    #endregion
