using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class MensajesController
    {
        /// <summary>
        /// Obtiene todos los mensajes enviados a un usuario en particular
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD. Usar "0" para mostrar todos los registros</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MensajesCollection FetchByUser(string usuario, int pagInicio = 1, int pagTamano = 15)
        {
            var col = new MensajesCollection();
            var qry = new Query(Mensajes.Schema)
                    .WHERE(Mensajes.Columns.Usuario, usuario)
                    .ORDER_BY(Mensajes.Columns.FechaEnvio);
            qry.PageIndex = pagInicio / pagTamano + 1;
            qry.PageSize = pagTamano;
            col.LoadAndCloseReader(qry.ExecuteReader());
            return col;
        }

        /// <summary>
        /// Obtiene el count de todos los mensjaes para un usuario especifico
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchByUser</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchByUser</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int CountByUser(string usuario, int pagInicio = 0, int pagTamano = 0)
        {
            var qry = new Query(Mensajes.Schema)
                        .WHERE(Mensajes.Columns.Usuario, usuario);
            return qry.GetRecordCount();
        }

        /// <summary>
        /// Obtiene todos los mensajes enviados a un usuario referentes a una misma sociedad
        /// </summary>
        /// <param name="sociedadId">ID de la sociedad</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MensajesCollection FetchByUserAndSociedad(int sociedadId, int pagInicio = 1, int pagTamano = 15)
        {
            var col = new MensajesCollection();
            var qry = new Query(Mensajes.Schema)
                .WHERE(Mensajes.Columns.SociedadID, sociedadId)
                .ORDER_BY(Mensajes.Columns.FechaEnvio);
            qry.PageIndex = pagInicio / pagTamano + 1;
            qry.PageSize = pagTamano;
            col.LoadAndCloseReader(qry.ExecuteReader());
            return col;
        }

        /// <summary>
        /// Obtiene el count de todos los mensjaes para una sociedad especifica
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="sociedadId">ID de la sociedad</param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchByUserAndSociedad</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchByUserAndSociedad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int CountByUserAndSociedad(string usuario, int sociedadId, int pagInicio = 0, int pagTamano = 15)
        {
            var qry = new Query(Mensajes.Schema)
                .WHERE(Mensajes.Columns.SociedadID, sociedadId);
            return qry.GetRecordCount();
        }

        
    }
}