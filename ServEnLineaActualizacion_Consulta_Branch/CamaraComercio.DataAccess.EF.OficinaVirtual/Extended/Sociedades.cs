using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public partial class Sociedades
    {
        /// <summary>
        /// Propiedad Extendida: Indica si la empresa se registra sin capital social
        /// </summary>
        public bool TieneCapitalSocial 
        { 
            get { return this.tieneCapitalSocial; }
            set { this.tieneCapitalSocial = value; }
        }

        private bool tieneCapitalSocial = true;
    }
}
