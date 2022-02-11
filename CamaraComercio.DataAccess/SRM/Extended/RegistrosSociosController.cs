using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.SRM
{
    
    public partial class RegistrosSociosController
    {
        /// <summary>
        /// Obtiene todos los socios que pertenencen a un registro mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna todas las socios de una empresa registrada.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewRegistrosSociosCollection FetchAllSociosByRegistroId(int registroId, String camaraId)
        {
            var socios = new SRM.ViewRegistrosSociosCollection();
            using (var scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                var query = new Query(ViewRegistrosSocios.Schema)
                    .WHERE(ViewSociedadesRegistros.Columns.RegistroId,registroId);
                socios.LoadAndCloseReader(query.ExecuteReader());
                return socios;
            }
        }
    }
}
