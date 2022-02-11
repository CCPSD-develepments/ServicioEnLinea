using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.SRM
{

    public partial class ReferenciasBancariasController
    {
        /// <summary>
        /// Obtiene las referencias bancarias asociadas a un registro mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna una collection que contiene todas las referencias bancarias de una empresa.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewReferenciasBancariasCollection FetchReferenciasBancariasByRegistroId(int registroId, String camaraId)
        {
            using (SharedDbConnectionScope scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                ViewReferenciasBancariasCollection referencias = new ViewReferenciasBancariasCollection();

                Query query =
                 new Query(ViewReferenciasBancarias.Schema).WHERE(ViewReferenciasBancarias.Columns.RegistroId,
                                                             registroId);
                referencias.LoadAndCloseReader(query.ExecuteReader());

                return referencias;
            }
        }

    }
}
