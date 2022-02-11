using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Controlador para los mensajes
    /// </summary>
    [DataObject]
    public class MensajesController
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public MensajesController()
        { }

        CamaraWebsiteEntities db = new CamaraWebsiteEntities();

        /// <summary>
        /// Obtiene todos los mensajes enviados a un usuario en particular
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD. Usar "0" para mostrar todos los registros</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Mensajes> FetchByUser(string usuario, int pagInicio = 1, int pagTamano = 15)
        {
            var qry = (from m in db.Mensajes
                       where m.Usuario == usuario
                       select m).OrderBy(ob => ob.FechaEnvio).Skip(pagInicio).Take(pagTamano);
            return qry;
        }

        /// <summary>
        /// Obtiene el count de todos los mensjaes para un usuario especifico
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchByUser</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchByUser</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int CountByUser(string usuario, string usuarioPadre, int pagInicio = 0, int pagTamano = 0)
        {
            return db.Mensajes.Where(m => m.Usuario == usuario).Count();
        }

        /// <summary>
        /// Retorna la cantidad de mensajes aun no leidos por el usuario
        /// </summary>
        /// <param name="usuario">username</param>
        /// <returns></returns>
        public int CountUnreadByUser(string usuario)
        {
            return db.Mensajes.Where(m => m.Usuario == usuario && m.FechaLectura == null).Count();
        }

        /// <summary>
        /// Obtiene todos los mensajes enviados a un usuario referentes a una misma sociedad
        /// </summary>
        /// <param name="sociedadId">ID de la sociedad</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Mensajes> FetchByUserAndSociedad(int sociedadId, int pagInicio = 1, int pagTamano = 15)
        {
            var qry = (from m in db.Mensajes
                       where m.SociedadID == sociedadId
                       select m).OrderBy(ob => ob.FechaEnvio).Skip(pagInicio).Take(pagTamano);
            return qry;
        }

        /// <summary>
        /// Obtiene el count de todos los mensajes para una sociedad especifica
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="sociedadId">ID de la sociedad</param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchByUserAndSociedad</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchByUserAndSociedad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int CountByUserAndSociedad(string usuario, int sociedadId, int pagInicio = 0, int pagTamano = 15)
        {
            return db.Mensajes.Where(m => m.SociedadID == sociedadId && m.Usuario == usuario).Count();
        }

        /// <summary>
        /// Obtiene todos los mensajes enviados a un usuario padre (todos los mensajes de una empresa gestora)
        /// </summary>
        /// <param name="usuarioPadre">Usuario logeado</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD. Usar "0" para mostrar todos los registros</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Mensajes> FetchByUsuarioPadre(string usuarioPadre, int pagInicio = 1, int pagTamano = 15)
        {
            var qry = (from m in db.Mensajes
                       where m.UsuarioPadre == usuarioPadre
                       select m).OrderByDescending(ob => ob.FechaEnvio).Skip(pagInicio).Take(pagTamano);

            foreach (var item in qry)
            {
                
                item.UsuarioSistema = "Camara Comercio y Produccion";   
            }
            return qry;
        }



        /// <summary>
        /// Obtiene el count de todos los mensjaes para un usuario padre especifico
        /// </summary>
        /// <param name="usuarioPadre">Nombre del usuario logueado</param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchByUser</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchByUser</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int CountByUsuarioPadre(string usuarioPadre, int pagInicio = 0, int pagTamano = 0)
        {
            return db.Mensajes.Where(m => m.UsuarioPadre == usuarioPadre).Count();
        }

        /// <summary>
        /// Obtiene todos los mensajes enviados a un usuario en particular
        /// </summary>
        /// <param name="transaccion">ID de la transacción</param>
        /// <param name="startRowIndex">Para los registros paginados, indica la pagina a buscar en la BD. Usar "0" para mostrar todos los registros</param>
        /// <param name="maximumRows">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Transacciones> FetchByTransaccion(int transaccion, int startRowIndex = 0, int maximumRows = 15)
        {
            var qry = (from m in db.Transacciones
                       where m.TransaccionId == transaccion
                       select m).OrderBy(ob => ob.TransaccionId).Skip(startRowIndex).Take(startRowIndex + maximumRows);
            return qry;
        }

        /// <summary>
        /// Obtiene la cantidad total de documentos por transacción
        /// </summary>
        /// <param name="transaccion">ID de la transacción</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int CountByTransaccion(int transaccion)
        {
            return db.Mensajes.Where(m => m.TransaccionId == transaccion).Count();
        }
    }
}
