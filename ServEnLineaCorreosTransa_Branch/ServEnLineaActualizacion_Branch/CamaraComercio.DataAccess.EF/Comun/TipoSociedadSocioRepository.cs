using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    public partial class TipoSociedadSocioRepository : Repository<TipoSociedadSocio, CamaraComunEntities>
    {
        /// <summary>
        /// 
        /// </summary>
        public TipoSociedadSocioRepository()
            : base(new CamaraComunEntities())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbComun"></param>
        public TipoSociedadSocioRepository(CamaraComunEntities dbComun)
            : base(dbComun)
        {
        }
        
    }
}
