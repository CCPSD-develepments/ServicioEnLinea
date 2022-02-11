using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Controlador para sucursales
    /// </summary>
    public class SuscursalesController
    {
        /// <summary>
        /// Obtiene todas las sucursales de una empresa.
        /// </summary>
        /// <param name="sociedadId">Id de la sociedad.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna todas las sucursales de una empresa registrada.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Suscursales> FetchSucursalesByRegistroId(int sociedadId, string camaraId)
        {
            var db = new CamaraSRMEntities(Helpers.GetCamaraConnString(camaraId));

            var query = db.Suscursales.Where(a => a.SociedadId == sociedadId);

            return query.ToList();
        }
    }
}
