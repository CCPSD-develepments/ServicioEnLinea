using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    public class TipoSociedadServicioCargoRepository : Repository<TipoSociedadServicioCargo, CamaraComunEntities>
    {
        /// <summary>
        /// Obtiene las validaciones de cargos para un servicio (de modificación) a partir del tipo de sociedad y servicios escogidos
        /// </summary>
        /// <param name="tipoSociedadId">Tipo de sociedad para la cual se realiza una modificacion</param>
        /// <param name="servicioIds">Servicios solicitados</param>
        /// <returns></returns>
        public IEnumerable<TipoSociedadServicioCargo> GetValidations(int tipoSociedadId, IEnumerable<Int32?> servicioIds)
        {
            var validaciones = from s in this.Session.TipoSociedadServicioCargo
                               where s.ServicioID != null
                                     && servicioIds.Contains(s.ServicioID)
                                     && s.TipoSociedadID == tipoSociedadId
                               select s;
            return validaciones;
        }
    }
}
