using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun = CamaraComercio.DataAccess.Comun;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class TipoServicioDetalles
    {
        /// <summary>
        /// Nombre o Descripción del Tipo de Servicio.
        /// </summary>
        public String Descripcion
        {
            get
            {
                return new Comun.TipoServicioController().FetchByID(this.TipoServicioId).FirstOrDefault().Descripcion;
            }

        }
    }
}
