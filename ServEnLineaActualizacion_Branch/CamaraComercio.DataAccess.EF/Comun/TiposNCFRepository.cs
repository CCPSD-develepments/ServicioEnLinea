using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio para tipos de NCF
    /// </summary>
    [DataObject(true)]
    public class TiposNcfRepository : Repository<TiposNcf, CamaraComun.CamaraComunEntities>
    {
        /// <summary>
        /// Constructor que acepta CamaraID
        /// </summary>
        /// <param name="camaraId"></param>
        public TiposNcfRepository(string camaraId)
            : base(new CamaraComun.CamaraComunEntities())
        {

        }

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public TiposNcfRepository()
        {
        }

        /// <summary>
        /// Obtiene todos los tipos de NCF disponibles
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TiposNcf> GetAll()
        {
            var db = this.Session;
            return db.TiposNcf.Where(a => a.SiteVisible).ToList();
        }
    }
}
