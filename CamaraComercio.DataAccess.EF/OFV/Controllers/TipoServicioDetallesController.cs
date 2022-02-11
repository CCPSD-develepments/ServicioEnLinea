using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Controlador para el detalle de los tipos de servicios
    /// </summary>
    [DataObject]
    public class TipoServicioDetallesController
    {
        /// <summary>
        /// Obtiene los Tipos de Servicios disponibles para un tipo de sociedad.
        /// </summary>
        /// <param name="tipoSociedadId">Id del tipo de sociedad.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<TipoServicioDetalles> GetTipoServiciosByTipoSociedad(int tipoSociedadId)
        {
            var dbComun = new CamaraComun.CamaraComunEntities();
            //Busco todos los tipos de servicios que son visibles para el site
            var tiposServicios = (from c in dbComun.ServicioDocumentoRequerido
                                  where 
                                  c.TipoSociedadId == tipoSociedadId && 
                                  c.Servicio.SiteVisible == true &&
                                  c.Servicio.TipoServicio.SiteVisible == true
                                  select c.Servicio.TipoServicioId).Distinct().ToList();

            //Obtengo los tipos de servicios que tienen servicios configurados
            var dbWebSite = new OficinaVirtual.CamaraWebsiteEntities();

            var result = from c in dbWebSite.TipoServicioDetalles
                         where tiposServicios.Contains(c.TipoServicioId)
                         select c;

            return result.ToList();
        }

    }
}
