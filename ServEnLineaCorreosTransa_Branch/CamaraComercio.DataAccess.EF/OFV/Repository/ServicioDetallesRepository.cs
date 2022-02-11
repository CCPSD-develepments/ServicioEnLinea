using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Repositorio para el detalle de servicios
    /// </summary>
    [DataObject]
    public class ServicioDetallesRepository : Repository<ServicioDetalles, CamaraWebsiteEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public ServicioDetallesRepository()
            : base(new CamaraWebsiteEntities())
        {

        }

        /// <summary>
        /// Obtiene el detalle de los servicios de una lista de IDs
        /// </summary>
        /// <param name="lstServicios">Listado de servicios para los que se requiere el detalle</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ServicioDetalles> GetServicios(List<int> lstServicios)
        {
            var db = this.Session;
            return db.ServicioDetalles.Where(a => lstServicios.Contains(a.ServicioId)).ToList();
        }
    }
}
