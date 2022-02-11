using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Controlador para Referencias Bancarias
    /// </summary>
    public class ReferenciasBancariasController
    {
        /// <summary>
        /// Obtiene las referencias bancarias asociadas a un registro mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna una collection que contiene todas las referencias bancarias de una empresa.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ViewReferenciasBancarias> FetchReferenciasBancariasByRegistroId(int registroId, String camaraId)
        {
            var db = new CamaraSRMEntities(Helpers.GetCamaraConnString(camaraId));
            var query = db.ViewReferenciasBancarias.Where(a => a.RegistroId == registroId);
            return query.ToList();
        }

    }
}
