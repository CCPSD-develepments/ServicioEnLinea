using Ccpsd.IntegrationsD365.IntegrationDynamics365WS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;


namespace Ccpsd.IntegrationsD365
{
    public static class FacturaWS
    {

        


        public static Boolean FacturaDynamics = Convert.ToBoolean(ConfigurationManager.AppSettings["ActiveDiynamics365Factura"]);
        public static string Appid = ConfigurationManager.AppSettings["AppId"].ToString();
        public static string countryRegionId = ConfigurationManager.AppSettings["countryRegionId"].ToString();
        public static string customerGroupId = ConfigurationManager.AppSettings["customerGroupId"].ToString();
        public static string salesCurrencyCode = ConfigurationManager.AppSettings["salesCurrencyCode"].ToString();
        public static string UserDynamics365 = ConfigurationManager.AppSettings["UsuarioIdDynamics365"].ToString();

        public static WsFacturaD365 GenerarFactura(string rnc, string nombre, int tipoComprobante,
   string camaraId, string usuario, List<Servicio> serviciosFacturados,
   List<RegistroPago> registroPagos, bool? reclamaSaldoPendiente)

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

            var TransaccionId = (from Servicio data in serviciosFacturados
                                 where data.Total > 0
                                 select data.TransaccionId).FirstOrDefault();

            string camaraIdDynamics = string.Empty;
            int TimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["wsTimeoutDynamics365"].ToString());
            var dynamicsClient = new IntegrationDynamics365WS.IntegracionDynamics365WS
            {
                Url = ConfigurationManager.AppSettings["SgccServicePath"],
                UserIntegrationValue = new IntegrationDynamics365WS.UserIntegration
                {
                    
                    UserName = ConfigurationManager.AppSettings["UserDynamics365"].ToString(), // usuario del header de request
                    Password = ConfigurationManager.AppSettings["PasswordDynamics365"].ToString() // usuario del header de request
                },
                Timeout = TimeOut // 5 min de espera de respuesta
            };


            var facturaArg = new IntegrationDynamics365WS.WSFacturasArg();

            facturaArg.idEmpresa = ConfigurationManager.AppSettings["camaraIdDynamics"].ToString();
            // = camaraIdDynamics;

            //colocar esto en key
            facturaArg.appId = Appid; // 03 = SEL, esto es para saber el origen de la app en dynamics, se queda statico
            facturaArg.countryRegionId = countryRegionId; // region a cual saldra la factura, se queda statico
            facturaArg.customerGroupId = customerGroupId; // grupo de cliente en dynamics, se queda statico
            facturaArg.salesCurrencyCode = salesCurrencyCode; // tipo de moneda a facturar, se queda estatico
            facturaArg.unidadNegocio = ConfigurationManager.AppSettings["unidadNegocio"].ToString();


            facturaArg.factura = new IntegrationDynamics365WS.WSFactura
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
                                  select new IntegrationDynamics365WS.WSDetalleFacturas
                                  {
                                      Cantidad = data.Cantidad,
                                      IdProducto = "RM" + data.Codigo.PadLeft(4, '0'),
                                      Descuento = data.Descuento,
                                      Precio = data.PrecioUnitario,
                                      Descripcion = data.Descripcion
                                  }).ToArray();



            facturaArg.pagos = (from RegistroPago data in registroPagos
                                select new IntegrationDynamics365WS.WSPago
                                {
                                    Monto = data.Monto,
                                    TipoPago = (data.MetodoPago == 1) ? IntegrationDynamics365WS.TipoPago.TCAZUL :
                                        (data.MetodoPago == 8) ? IntegrationDynamics365WS.TipoPago.NOTACREDITO : IntegrationDynamics365WS.TipoPago.BOTONBHD, // especificar tipo de tarjeta segun solicitud
                                    Nota = string.Empty, // aqui colocar los 4 ultimos digitos de tarjeta si se captura.
                                    VoucherNotaCredito = data.VoucherNotaCredito
                                }).ToArray();



            var dynamicsFact = dynamicsClient.AgregarFactura(facturaArg);


            if (dynamicsFact.hasError == 1)
            {
                throw new Exception(dynamicsFact.errores[0].mensaje);
                //throw new Exception("Errores en el proceso de facturación.");
            }


            return new WsFacturaD365
            {                
                Estado = EstadoFactura.Emitida,
                NCF = dynamicsFact.NCFId,
                NumeroFactura = dynamicsFact.InvoiceId
            };


        }



        //TODO: Jason: Quitar este metodo temporal
        public static int ConvertToInt32Value(this string value)
        {
            var valueInt = 0;
            Int32.TryParse(value, out valueInt);
            return valueInt;
        }

    }
}

namespace Ccpsd.IntegrationsD365
{
    public class WsFacturaD365
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

    /// <summary>
    /// Describe los servicios registrados en el sistema de gestión
    /// </summary>
    public class Servicio
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        /// <summary>
        /// Optienes o establece la fecha de la transacción
        /// </summary>
        /// <value>Tipo <see cref="DateTime"/>.</value>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Obtienes o estableces la relación del registro.
        /// </summary>
        /// <value>Tipo <see cref="Guid"/>.</value>
        public Guid CgControl { get; set; }
        /// <summary>
        /// Obtienes o estableces el Id del registro.
        /// </summary>
        /// <value>Tipo <see cref="Guid"/>.</value>
        public Guid IdReg { get; set; }
        public string Contacto { get; set; }
        public string Cliente { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalPagar { get; set; }
        public int TransaccionId { get; set; }

    }

    /// <summary>
    /// Estado en el que puede estar una factura luego de solicitar su emisión
    /// </summary>
    public enum EstadoFactura
    {
        Emitida = 1,
        Cancelada = 2,
        NotaDeCredito = 3
    }
    /// <summary>
    /// Posibles tipos de comprobante fiscal que se pueden solicitar para una factura
    /// </summary>
    public enum TipoComprobanteFiscal
    {
        [Description("Factura con valor fiscal")]
        ValorFiscal = 1,
        [Description("Factura para consumidor final")]
        ConsumidorFinal = 2,
        [Description("Factura para Regimenes Especiales")]
        RegimenEspecial = 6,
        [Description("Comprobante de Gastos Menores")]
        GastosMenores = 8,
        [Description("Factura para Instituciones Gubernamentales")]
        Gubernamental = 3
    }
}