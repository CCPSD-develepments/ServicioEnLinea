
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CamaraComercio.WebServices.Facturacion
{
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

    /// <summary>
    /// Formas en las que se puede saldar una factura
    /// </summary>
    public enum FormaPago
    {
        Efectivo = 1,
        TarjetaCredito = 2,
        Cheque = 3,
        Especies = 4
    }

    public class SgccDictionary
    {
        static readonly Dictionary<int, string> FormaPagosDictionary = new Dictionary<int, string>();

        static SgccDictionary()
        {
            FormaPagosDictionary.Add(1, "5");
            FormaPagosDictionary.Add(2, "6");
            FormaPagosDictionary.Add(3, "7");
            FormaPagosDictionary.Add(4, "18");
        }

        public static int GetFormaPago(int id)
        {
            if (FormaPagosDictionary.Count == 0) throw new KeyNotFoundException("No existen valores en el diccionario.");

            string value;
            bool b = FormaPagosDictionary.TryGetValue(id, out value);
            if (!b) throw new KeyNotFoundException("No existen valores en el diccionario con la llave seleccionada.");
            return Convert.ToInt32(value);
        }
    }
}