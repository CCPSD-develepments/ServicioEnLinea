using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Controlador de socios por registro
    /// </summary>
    [DataObject]
    public class RegistrosSociosController
    {
        /// <summary>
        /// Obtiene todos los socios que pertenencen a un registro mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna todas las socios de una empresa registrada.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ViewRegistrosSocios> FetchAllSociosByRegistroId(int registroId, String camaraId)
        {
            var db = new CamaraSRMEntities(Helpers.GetCamaraConnString(camaraId));

            var query = db.ViewRegistrosSocios.Where(a => a.RegistroId == registroId);

            return query.ToList();
        }


        /// <summary>
        /// Obtiene todos los socios que pertenencen a un registro mercantil Segun Tipo De Relacion
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <param name="tipoRelacion">Identifica el tipo de socio.</param>
        /// <returns>Retorna todas las socios de una empresa registrada.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ViewRegistrosSocios> FetchAllSociosByRegistroIdAndTipoRelacion(int registroId, String camaraId, string tipoRelacion)
        {
            var db = new CamaraSRMEntities(Helpers.GetCamaraConnString(camaraId));

            var query = db.ViewRegistrosSocios.Where(a => a.RegistroId == registroId && a.TipoRelacion == tipoRelacion);

            return query.ToList();
        }
    }
}
