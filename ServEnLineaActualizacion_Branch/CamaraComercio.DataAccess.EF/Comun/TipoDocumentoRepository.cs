using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio para el tipo de documentos
    /// </summary>
    [DataObject]
    public class TipoDocumentoRepository : Repository<TipoDocumento, CamaraComunEntities>
    {
        /// <summary>
        /// Obtiene todos los documentos
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public new IList<TipoDocumento> SelectAll()
        {
            return base.SelectAll().OrderBy(a => a.Nombre).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IList<TipoDocumento> SelectAll(bool siteVisible)
        {
            return base.Session.TipoDocumento.Where(td => td.SiteVisible).OrderBy(td => td.Nombre).ToList();
        }

        /// <summary>
        /// Obtiene todos los documentos por transacción
        /// </summary>
        /// <param name="TransaccionId">ID de la transacción</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IList<TipoDocumento> SelectAllByTransId(int TransaccionId)
        {
            var db = this.Session;

            var dbWebSite = new CamaraWebsiteEntities();

            var DocSeleccionados = dbWebSite.TransaccionDocSeleccionado.Where(a => a.TransaccionId == TransaccionId).Select(a => a.TipoDocumentoId).ToList();

            var result = db.TipoDocumento.Where(a => DocSeleccionados.Contains(a.TipoDocumentoId) && a.SiteVisible)
                .OrderBy(a => a.Nombre).ToList();
            var otro = db.TipoDocumento.Where(a => a.Nombre == "Otros").FirstOrDefault();
            if (otro == null) return result;
            
            result.Add(otro);
            return result;
        }

        /// <summary>
        /// Obtiene todos los documentos por transacción
        /// </summary>
        /// <param name="TransaccionId">ID de la transacción</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public new TipoDocumento SelectByID(int tipoDocumentoId)
        {
            var db = this.Session;
         
            return db.TipoDocumento.FirstOrDefault(td => td.TipoDocumentoId == tipoDocumentoId);

        }
    }
}
