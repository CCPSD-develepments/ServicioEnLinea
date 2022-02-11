using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    ///<summary>
    /// Repositorio de propiedades que se pueden acceder en los formularios de modificación
    ///</summary>
    public class PropiedadesModUIRepository : Repository<PropiedadesModificacionUI, CamaraWebsiteEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public PropiedadesModUIRepository()
            : base(new CamaraWebsiteEntities())
        {
        }

        /// <summary>
        /// Obtiene los nombres de los controles que no se bloequean en el form de modificacion
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<String> GetControlesByServicioIDs(IEnumerable<int> ids)
        {
            return (Session.PropiedadesModificacionUI
                .Where(props => ids.Contains(props.ServicioID.Value) || props.ServicioID == null)
                .Select(props => props.NombreControl)).Distinct().AsEnumerable();
        }
    }

}
