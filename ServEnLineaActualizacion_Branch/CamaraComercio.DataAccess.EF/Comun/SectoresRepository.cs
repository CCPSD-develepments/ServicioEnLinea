using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio de Sectores
    /// </summary>
    [DataObject]
    public class SectoresRepository : Repository<CamaraComun.Sectores, CamaraComun.CamaraComunEntities>
    {   
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public SectoresRepository()
        {
        }

        /// <summary>
        /// Obtiene todos los sectores en una ciudad
        /// </summary>
        /// <param name="ciudadId">ID de la ciudad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CamaraComun.Sectores> FetchByCiudad(int ciudadId)
        {
            return Session.Sectores.Where(a => a.CiudadId == ciudadId && !String.IsNullOrEmpty(a.Nombre)).OrderBy(
                    a => a.Nombre).ToList();
        }
    }
}
