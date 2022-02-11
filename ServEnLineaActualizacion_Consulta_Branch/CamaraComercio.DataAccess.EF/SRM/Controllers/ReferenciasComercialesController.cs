using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Controlador de referencias comerciales
    /// </summary>
    public partial class ReferenciasComercialesController
    {
        /// <summary>
        /// Obtiene las referencias comerciales asociadas a un registro mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna una collection que contiene todas las referencias comerciales de una empresa.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReferenciasComerciales> FetchReferenciasComercialesByRegistroId(int registroId, String camaraId)
        {
            var db = new CamaraSRMEntities(Helpers.GetCamaraConnString(camaraId));

            var query = db.ReferenciasComerciales.Where(a => a.RegistroId == registroId);

            return query.ToList();
        }
    }
}
