using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Servicio Comun. Usado para la integración con el sistema de gestión. 
    /// </summary>
    [Serializable]
    public class ServicioComun
    {
        /// <summary>
        /// ID del Servicio
        /// </summary>
        public int ServicioId { get; set; }

        /// <summary>
        /// Nombre del servicio
        /// </summary>
        public String Nombre { get; set; }

        /// <summary>
        /// ID del tipo de servicio
        /// </summary>
        public int TipoServicioId { get; set; }

        /// <summary>
        /// Numero de cuenta
        /// </summary>
        public String Cuenta { get; set; }

        /// <summary>
        /// Costo unitario
        /// </summary>
        public Decimal PrecioUnitario { get; set; }
    }

 
}
