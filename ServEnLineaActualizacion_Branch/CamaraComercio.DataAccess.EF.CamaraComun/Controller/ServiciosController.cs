using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Controlador de servicios
    /// </summary>
    [DataObject]
    public class ServiciosController
    {
        /// <summary>
        /// Obtiene los servicios por Tipo de Sociedad y Tipo de servicio.
        /// </summary>
        /// <param name="tipoSociedadId">Id del tipo de Sociedad.</param>
        /// <param name="tipoServicioId">Id del tipo de Servicio.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Servicio> GetServiciosByTipoSociedadId(int tipoSociedadId, int tipoServicioId)
        {
            var dbComun = new CamaraComunEntities();
           
            var servicios = (from c in dbComun.ServicioDocumentoRequerido
                             where c.TipoSociedadId == tipoSociedadId &&
                             c.Servicio.TipoServicioId == tipoServicioId
                             select c.Servicio).Distinct();


            return servicios.ToList();
        }



        /// <summary>
        /// Obtiene los servicios por Tipo de Sociedad y Tipo de servicio.
        /// </summary>
        /// <param name="tipoSociedadId">Id del tipo de Sociedad.</param>
        /// <param name="tipoServicioId">Id del tipo de Servicio.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Servicio GetServiciosByID(int ServicioId_)
        {
            var dbComun = new CamaraComunEntities();

            var servicios = (from c in dbComun.Servicio
                             where c.ServicioId == ServicioId_ 
                             
                             select c).FirstOrDefault();


            return servicios;
        }



    }
}
