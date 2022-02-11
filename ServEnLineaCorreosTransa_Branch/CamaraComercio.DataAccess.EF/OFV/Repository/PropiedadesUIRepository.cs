using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Repositorio de Propiedades gráficas UI para una sociedad. 
    /// </summary>
    public class PropiedadesPorSociedadRepository : Repository<PropiedadesPorSociedad, CamaraWebsiteEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public PropiedadesPorSociedadRepository() : base (new CamaraWebsiteEntities())
        {
        }

        /// <summary>
        /// Obtiene todas las propiedades y reglas según el tipo de sociedad invocada
        /// </summary>
        /// <param name="tipoSociedadID">ID del tipo de sociedad</param>
        /// <returns>Listado de objetos gráficos para renderizar el UI</returns>
        public IEnumerable<PropiedadesPorSociedad> GetPropiedadesByTipo(int tipoSociedadID)
        {
            var db = this.Session;
            return db.PropiedadesPorSociedad.Where(p => p.TipoSociedadID == tipoSociedadID);
        }
    }
}

