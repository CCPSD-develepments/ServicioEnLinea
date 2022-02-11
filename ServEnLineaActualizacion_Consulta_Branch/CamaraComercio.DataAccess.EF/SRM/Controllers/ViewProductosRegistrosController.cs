using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Controlador para la vista de Productos por Registro
    /// </summary>
    [DataObject]
    public partial class ViewRegistrosProductosController
    {
        /// <summary>
        /// Obtiene los Productos Registrados para un registro Mercantil.
        /// </summary>
        /// <param name="registroId">Id del Registro Mercantil.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna todas las productos de una empresa registrada.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ViewRegistrosProductos> FetchbyRegistroId(int registroId, string camaraId)
        {
            var db = new CamaraSRMEntities(Helpers.GetCamaraConnString(camaraId));

            var query = db.ViewRegistrosProductos.Where(a => a.RegistroId == registroId);

            return query.ToList();
        }
    }
}
