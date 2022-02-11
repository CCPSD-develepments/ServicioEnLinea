using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;

namespace CamaraComercio.DataAccess.SRM
{
    
    public partial class DireccionesController
    {
        /// <summary>
        /// Obtiene la dirección registrada en una localidad en especifica.
        /// </summary>
        /// <param name="direccionId">Id de la dirección. Indica la direccion de la empresa registrada.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna una la dirección asociada al ID.</returns>
        public ViewDirecciones FetchById(int direccionId, String camaraId)
        {
            using (SharedDbConnectionScope scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                ViewDireccionesCollection col =
                    new ViewDireccionesCollection().Where(ViewDirecciones.Columns.DireccionId, direccionId).Load();

                return col.First();
            }
        }
    }
}
