using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.SRM
{
    public partial class ReferenciasComercialesController
    {
        /// <summary>
        /// Obtiene las referencias comerciales asociadas a un registro mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna una collection que contiene todas las referencias comerciales de una empresa.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReferenciasComercialesCollection FetchReferenciasComercialesByRegistroId(int registroId, String camaraId)
        {
            using (SharedDbConnectionScope scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                ReferenciasComercialesCollection referencias = new ReferenciasComercialesCollection();

                Query query =
                    new Query(ReferenciasComerciales.Schema).WHERE(ReferenciasComerciales.Columns.RegistroId,
                                                                     registroId);

                referencias.LoadAndCloseReader(query.ExecuteReader());

                return referencias;
            }
        }
    }
}
