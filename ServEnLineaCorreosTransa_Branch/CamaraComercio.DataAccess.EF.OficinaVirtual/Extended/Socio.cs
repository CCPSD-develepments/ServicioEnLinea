using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public partial class Socios
    {
        ///<summary>
        /// Nombre de la ciudad en la dirección registrada
        ///</summary>
        public string DireccionNombreCiudad { get; set; }
        
        /// <summary>
        /// Nombre del sector en la dirección registrada
        /// </summary>
        public string DireccionNombreSector { get; set; }

        /// <summary>
        /// Indica que la información del socio fue modificada a nivel de UI
        /// </summary>
        public bool Modificado { get; set; }
    }
}
