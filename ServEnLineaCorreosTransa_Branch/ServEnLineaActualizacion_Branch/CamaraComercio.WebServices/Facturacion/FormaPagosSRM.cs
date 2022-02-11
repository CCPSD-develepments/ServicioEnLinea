using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.WebServices.Facturacion
{
    public class FormaPagosSRM
    {
        /// <summary>
        /// Retornar o establece el banco descripcion.
        /// </summary>
        /// <value>
        /// The banco descripcion.
        /// </value>
        public string BancoDescripcion
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el banco id.
        /// </summary>
        /// <value>
        /// The banco id.
        /// </value>      
        public int? BancoId
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la confirmacion pago tarjeta.
        /// </summary>
        /// <value>
        /// The confirmacion pago tarjeta.
        /// </value>
        public string ConfirmacionPagoTarjeta
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la divisa.
        /// </summary>
        /// <value>
        /// The divisa.
        /// </value>
        public decimal Divisa
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el factura id.
        /// </summary>
        /// <value>
        /// The factura id.
        /// </value>
        public int FacturaId
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la fecha cuadre.
        /// </summary>
        /// <value>
        /// The fecha cuadre.
        /// </value>
        public DateTime FechaCuadre
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la forma pago.
        /// </summary>
        /// <value>
        /// The forma pago.
        /// /// </value>

        public string FormaPago
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la forma pago desc.
        /// </summary>
        /// <value>
        /// The forma pago desc.
        /// </value>
        public string FormaPagoDesc
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la nota.
        /// </summary>
        /// <value>
        /// The nota.
        /// </value>
        public string Nota
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el no tarjeta.
        /// </summary>
        /// <value>
        /// The no tarjeta.
        /// </value>        
        public string NoTarjeta
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el numero nota credito.
        /// </summary>
        /// <value>
        /// The numero nota credito.
        /// </value>
        public int? NumeroNotaCredito
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la referencia.
        /// </summary>
        /// <value>
        /// The referencia.
        /// </value>
        public string Referencia
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece la tasa.
        /// </summary>
        /// <value>
        /// The tasa.
        /// </value>
        public decimal Tasa
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el valor.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
        public decimal Valor
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el valor devuelto.
        /// </summary>
        /// <value>
        /// The valor devuelto.
        /// </value>
        public decimal ValorDevuelto
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece el valor entregado.
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public decimal ValorEntregado
        {
            get;
            set;
        }


        /// <summary>
        /// Retornar o establece si la nota es valida:
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public string NotaCreditoValida //true/false en char
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece si la nota es valida:
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public DateTime FechaCreacionNota //mostrar la fecha cuando se creo la nota
        {
            get;
            set;
        }

        public string Voucher
        {
            get;
            set;
        }



    }
}





