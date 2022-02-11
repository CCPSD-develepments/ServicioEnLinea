using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public partial class Personas
    {
        /// <summary>
        /// Propiedad Extendida: Nombre completo de una persona
        /// </summary>
        public String NombreCompleto
        {
            get
            {
                return String.Format("{0} {1} {2} {3}", this.PrimerNombre, this.SegundoNombre, this.PrimerApellido,
                                     this.SegundoApellido);
            }
        }
    }
}
