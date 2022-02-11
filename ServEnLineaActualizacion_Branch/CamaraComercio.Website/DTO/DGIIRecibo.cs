using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website
{
    ///<summary>
    /// Clase que define los campos de un recibo de pago en DGII
    ///</summary>
    public class ReciboDGII
    {
        ///<summary>
        /// Número del recibo de pago de DGII
        ///</summary>
        public String NoReciboDGII { get; set; }
        
        /// <summary>
        /// Fecha de generación de la autorización de pagos
        /// </summary>
        public DateTime? FechaReciboDGII { get; set; }
        
        ///<summary>
        /// Monto pagado
        ///</summary>
        public Decimal? MontoDGII { get; set; }
    }
}