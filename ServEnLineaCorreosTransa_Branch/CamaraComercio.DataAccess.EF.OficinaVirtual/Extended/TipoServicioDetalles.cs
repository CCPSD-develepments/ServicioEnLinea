using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public partial class TipoServicioDetalles
    {
        /// <summary>
        /// Propiedad Extendida: Descripción de un detalle de tipo de servicio
        /// </summary>
        public String Descripcion
        {
            get
            {
                return new  CamaraComun.CamaraComunEntities().TipoServicio.FirstOrDefault(a => a.TipoServicioId == this.TipoServicioId).DescripcionWeb;
            }
        }

    }
}
