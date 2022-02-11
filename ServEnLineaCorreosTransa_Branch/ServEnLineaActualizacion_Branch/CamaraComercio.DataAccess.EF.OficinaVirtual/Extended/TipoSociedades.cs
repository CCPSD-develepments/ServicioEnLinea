using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    [Serializable()]
    public class TipoSociedades
    {
        /// <summary>
        /// Propiedad Extendida: Tipo Sociedad ID
        /// </summary>
        public int TipoSociedadId { get; set; }

        /// <summary>
        /// Propiedad Extendida: Nombre de un tipo de sociedad
        /// </summary>
        public String Nombre { get; set; }
    }
}
