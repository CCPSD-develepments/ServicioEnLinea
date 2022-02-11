using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public partial class TransaccionesDocumentos
    {
        /// <summary>
        /// Propiedad Extendida: Tipo de documento de una transacción
        /// </summary>
        public CamaraComun.TipoDocumento TipoDocumento
        {
            get
            {
                return new CamaraComun.CamaraComunEntities().TipoDocumento.Where(a => a.TipoDocumentoId == this.TipoDocumentoId).FirstOrDefault();
            }
        }
    }
}
