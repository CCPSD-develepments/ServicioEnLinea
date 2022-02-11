using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio para los documentos requeridos por servicio
    /// </summary>
    [DataObject()]
    public class ServicioDocumentoRequeridoRepository : Repository<ServicioDocumentoRequerido, CamaraComunEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public ServicioDocumentoRequeridoRepository()
            : base(new CamaraComun.CamaraComunEntities())
        {
        }

        /// <summary>
        /// Obtiene los documentos requeridos para un servicio y tipo de sociedad específicos
        /// </summary>
        /// <param name="servicioId">ID del servicio</param>
        /// <param name="tipoSociedadId">ID del tipo de sociedad</param>
        /// <param name="transaccionId">ID de la transacción</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<ServicioDocumentoRequerido> GetDocumentosSeleccionados(int? servicioId, int? tipoSociedadId, int transaccionId)
        {
            var dbWebSite = new OficinaVirtual.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            var docSeleccionados = dbWebSite.TransaccionDocSeleccionado
                                    .Where(a => a.TransaccionId == transaccionId)
                                    .Select(a => a.TipoDocumentoId).ToList();
            var query = dbComun.ServicioDocumentoRequerido.Include("TipoDocumento")
                        .Where(c => docSeleccionados.Contains(c.TipoDocumentoId)
                            && c.TipoSociedadId == tipoSociedadId
                            && c.ServicioId == servicioId && c.TipoDocumento.SiteVisible);

            return query;
        }

        /// <summary>
        /// Obtiene los documentos asociados a una transacción
        /// </summary>
        /// <param name="tipoSociedadId"></param>
        /// <param name="transaccionId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<TipoDocumento> GetDocumentosInTransaccion(int? tipoSociedadId, int transaccionId)
        {
            var dbWebSite = new OficinaVirtual.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            
            var transaccion = dbWebSite.Transacciones.Where(t => t.TransaccionId == transaccionId);
            var subtrans = dbWebSite.Transacciones.Where(t => t.SubTransaccionId == transaccionId);
            
            var servicioIdList = new List<Int32>();
                servicioIdList.AddRange(transaccion.Select(t => t.ServicioId).Distinct());
                servicioIdList.AddRange(subtrans.Select(t => t.ServicioId).Distinct());

            var docSeleccionados = dbWebSite.TransaccionDocSeleccionado
                                    .Where(a => a.TransaccionId == transaccionId)
                                    .Select(a => a.TipoDocumentoId).ToList();

            if (docSeleccionados.Count() > 0)
            {
                var docsRequeridos = dbComun.ServicioDocumentoRequerido
                                    .Where(c => docSeleccionados.Contains(c.TipoDocumentoId)
                                    && c.TipoSociedadId == tipoSociedadId
                                    && servicioIdList.Contains(c.ServicioId) && c.TipoDocumento.SiteVisible)
                                    .Select(d => d.TipoDocumentoId).Distinct();
                return dbComun.TipoDocumento.Where(td => docsRequeridos.Contains(td.TipoDocumentoId))
                            .OrderBy(td => td.Nombre);    
            }
            else
            {
                var docsRequeridos = dbComun.ServicioDocumentoRequerido
                                    .Where(c => c.TipoSociedadId == tipoSociedadId
                                    && servicioIdList.Contains(c.ServicioId) && c.TipoDocumento.SiteVisible)
                                    .Select(d => d.TipoDocumentoId).Distinct();
                return dbComun.TipoDocumento.Where(td => docsRequeridos.Contains(td.TipoDocumentoId))
                            .OrderBy(td => td.Nombre);    
            }
        }

        /// <summary>
        /// Obtiene los documentos requeridos para un servicio y tipo de sociedad específicos
        /// </summary>
        /// <param name="servicioId">ID del servicio</param>
        /// <param name="tipoSociedadId">ID del tipo de sociedad</param>
        /// <param name="transaccionId">ID de la transacción</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<ServicioDocumentoRequerido> GetDocumentosSeleccionados(int? servicioId, int? tipoSociedadId)
        {
            var dbWebSite = new OficinaVirtual.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            var query = dbComun.ServicioDocumentoRequerido.Include("TipoDocumento")
                .Where(c => c.TipoSociedadId == tipoSociedadId
                            && c.ServicioId == servicioId && c.TipoDocumento.SiteVisible && c.SiteVisible);
            return query;
        }
    }
}
