using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Telerik.Web.UI;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using Transacciones = CamaraComercio.DataAccess.EF.SRM.Transacciones;

namespace CamaraComercio.Website.Helpers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'LogTransaccionesMethods'
    public static class LogTransaccionesMethods
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'LogTransaccionesMethods'
    {
        //grabar el log de la transaccion, en la web que esta y si la completo.
        /// <summary>
        /// grabar el log de la transaccion, en la web que esta y si la completo.
        /// </summary>
        /// <param name="transaccionId">Id de transaccion de la web</param>
        /// <param name="url">url en la que se quedo</param>
        /// <param name="completed">si completo la solicitud o no</param>
        /// <param name="username">usuario que hizo la solicitud</param>
        /// <returns></returns>
        public static bool GrabarLogTransacciones(int transaccionId, string url, bool completed, string username)
        {
            var dbWebSite = new CamaraWebsiteEntities();
            OFV.LogTransacciones log = new OFV.LogTransacciones();
            
            log.TransaccionId = transaccionId;
            log.URL = url;
            log.Completed = completed;
            log.UserName = username.ToLower();
            log.Date = DateTime.Now;

            dbWebSite.LogTransacciones.AddObject(log);

            return dbWebSite.SaveChanges() > 0;
        }
        //Este metodo tambien esta duplicado en \CamaraComercio.DataAccess.EF\OFV\Repository\SociedadesRepository  (Refactorizar)
        /// <summary>
        /// Verifica si la transaccion esta completa o no
        /// </summary>
        /// <param name="transaccionId">Id de la transaccion web</param>
        /// <returns></returns>
        public static bool EstaCompleta(int transaccionId)
        {
            var dbWebSite = new CamaraWebsiteEntities();

            //Verifico que si la transaccion no tiene log por lo tanto esta se hizo antes del cambio
            // de grabar los log de la transaccion por lo tanto me tiene que permitir verla.
            var verificar = from tran in dbWebSite.LogTransacciones
                            where tran.TransaccionId.Equals(transaccionId)
                            select tran;

            if (verificar.Count() <= 0)
                return true;

            var query = from tran in dbWebSite.LogTransacciones
                        where tran.TransaccionId.Equals(transaccionId) && tran.Completed.Equals(true)
                        select tran;

            return query.Count() > 0;
        }

        //Obtener la ultima url que quedo el usuario haciendo la solicitud
        /// <summary>
        /// Obtener la ultima url que se llego haciendo la solicitud
        /// </summary>
        /// <param name="transaccionId">Id de la transaccion web.</param>
        /// <returns></returns>
        public static string ObtenerUltimaURL(int transaccionId) 
        {
            var dbWebSite = new CamaraWebsiteEntities();
            string result = string.Empty;
            var query = (from tran in dbWebSite.LogTransacciones
                         where tran.TransaccionId.Equals(transaccionId)
                         orderby tran.Id descending
                         select tran).FirstOrDefault();
            if (query != null)
            {
                result = query.URL;
            }

            return result;
        }

        //verificar si es otro usuario que la dejo incompleta y devolver el username.
        /// <summary>
        /// Verifica si fue el usuario actual que empezo la transaccion de ser haci returna string.emty, de lo contrario
        /// me retorna el usuario que hizo la transaccion.
        /// </summary>
        /// <param name="transaccionId">Id de la transaccion web</param>
        /// <param name="userName">Username actual (el que hizo la consulta)</param>
        /// <returns>retorna string.empty si fue el mismo usuario que el hizo la solicitud, de lo contrario retorna quien la hizo.</returns>
        public static string VerificarSiEstaIncompletaPorOtroUsuario(int transaccionId, string userName) 
        {
            userName.ToLower();
            var dbWebSite = new CamaraWebsiteEntities();
            string userLog = string.Empty;

            var verificar = (from tran in dbWebSite.LogTransacciones
                            where tran.TransaccionId.Equals(transaccionId)
                            orderby tran.Id descending
                            select tran).FirstOrDefault();

            if (!verificar.UserName.Equals(userName))
                userLog = verificar.UserName;

            return userLog;
        }
        
    }
}