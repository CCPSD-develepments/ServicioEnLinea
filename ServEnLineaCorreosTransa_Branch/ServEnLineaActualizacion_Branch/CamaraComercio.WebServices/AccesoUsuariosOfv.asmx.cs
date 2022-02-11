using System;
using System.Linq;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.Membership;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Clase que maneja los accesos de los usuarios a sus empresas
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccesoUsuariosOfv : WebService
    {
        /// <summary>
        /// Modifica el estado de solicitud de un usuario que desea manejar una empresa a partir del ID de solicitud
        /// </summary>
        /// <param name="empresaPorUsuarioId">ID de la solicitud</param>
        /// <param name="estado">Estado al que se desea cambiar</param>
        /// <returns></returns>
        [WebMethod(Description = "Modifica el estado de solicitud de un usuario que desea manejar una empresa a partir del ID de solicitud")]
        public bool ActualizarSolicitudPorId(int empresaPorUsuarioId, OFV.EmpresaPorUsuarioEstado estado)
        {
            var metodoExitoso = false;

            var db = new OFV.CamaraWebsiteEntities();
            var ctrlEmpresas = new DataAccess.EF.Repository<OFV.EmpresasPorUsuario, OFV.CamaraWebsiteEntities>(db);

            var empresa = ctrlEmpresas.SelectByKey(empresaPorUsuarioId);
            if (empresa != null)
            {
                empresa.Estado = (short)estado;
                empresa.FechaUltModificacion = DateTime.Now;

                if (empresa.FechaCreacion == DateTime.MinValue)
                    empresa.FechaCreacion = DateTime.Now;

                ctrlEmpresas.Save();
                metodoExitoso = true;
            }

            return metodoExitoso;
        }

        /// <summary>
        /// Modifica el estado de solicitud de un usuario que desea manejar una empresa a partir de los datos del usuario
        /// </summary>
        /// <param name="usuario">Usuario que posee el control del registro</param>
        /// <param name="noRegistro">No. de registro mercantil</param>
        /// <param name="camaraID">Camara de comercio</param>
        /// <param name="estado">Estado en la que debe quedar actualizada la solicitud</param>
        /// <returns></returns>
        [WebMethod(Description = "Modifica el estado de solicitud de un usuario que desea manejar una empresa a partir de los datos del usuario")]
        public bool ActualizarSolicitudPorDatos(string usuario, int noRegistro, string camaraID, OFV.EmpresaPorUsuarioEstado estado)
        {
            var metodoExitoso = false;

            var ctrlEmpresas = new OFV.EmpresasPorUsuarioController();
            var col = ctrlEmpresas.FetchByUserNoRegistroCamara(usuario, noRegistro, camaraID);
            if (col.Count() > 0)
            {
                var solicitud = col.First();
                metodoExitoso = ActualizarSolicitudPorId(solicitud.ID, estado);
            }

            return metodoExitoso;
        }

        /// <summary>
        /// Modifica el estado de solicitud de un usuario al momento de cerrar una empresa en el SRM
        /// </summary>
        /// <param name="noRegistro">No. de Registro Mercantil</param>
        /// <param name="camaraID">Camara de Comercio</param>
        /// <returns></returns>
        public bool ActualizarSolicitudPorCierre(int noRegistro, string camaraID)
        {
            var ctrlEmpresas = new OFV.EmpresasPorUsuarioController();
            return ctrlEmpresas.CerrarAcceso(noRegistro, camaraID);
        }

        /// <summary>
        /// Retorna el nombre del usuario OFV a partir del transaccionId del WebSite
        /// </summary>
        /// <param name="transaccionId">TransacionId del WebSite</param>
        /// <returns></returns>
        [WebMethod]
        public String GetUsuarioTransaccionByTransId(int transaccionId)
        {
            var nombre = String.Empty;

            var db = new OFV.CamaraWebsiteEntities();
            var ctrlEmpresas = db.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId);

            if (ctrlEmpresas != null)
                nombre = ctrlEmpresas.UserName;

            return nombre;
        }

        /// <summary>
        /// Retorna el nombre del usuario OFV a partir del transaccionId del WebSite
        /// </summary>
        /// <param name="transaccionId">TransacionId del WebSite</param>
        /// <returns></returns>
        [WebMethod]
        public String GetUsuarioTransaccionBySrmId(int transaccionId)
        {
            var nombre = String.Empty;

            var db = new OFV.CamaraWebsiteEntities();
            var ctrlEmpresas = db.Transacciones.FirstOrDefault(t => t.SrmTransaccionId == transaccionId);

            if (ctrlEmpresas != null)
                nombre = ctrlEmpresas.UserName;

            return nombre;
        }

        /// <summary>
        /// Retorna el Email del usuario OFV a partir del transaccionId del SRM
        /// </summary>
        /// <param name="transaccionId">TransacionId del SRM</param>
        /// <returns></returns>
        [WebMethod]
        public String GetEmailTransaccionBySrmId(int transaccionId)
        {
            var email = String.Empty;

            var db = new OFV.CamaraWebsiteEntities();
            var ctrlEmpresas = db.Transacciones.FirstOrDefault(t => t.SrmTransaccionId == transaccionId);
            if (ctrlEmpresas != null)
            {
                using (var accountsEntities = new CamaraWebsiteAccountsEntities())
                {
                    var user = accountsEntities.aspnet_Users.FirstOrDefault(o => o.UserName == ctrlEmpresas.UserName);
                    if (user != null && user.aspnet_Membership != null)
                        email = user.aspnet_Membership.Email;
                }
            }

            return email;
        }

        /// <summary>
        /// Retorna el correo electronico del usuario OFV a partir del nombre de usuario
        /// </summary>
        /// <param name="transaccionId">Nombre del usuario</param>
        /// <returns></returns>
        [WebMethod]
        public String GetCorreoElectronico(string userName)
        {
            var email = String.Empty;

            using (var accountsEntities = new CamaraWebsiteAccountsEntities())
            {
                var user = accountsEntities.aspnet_Users.FirstOrDefault(o => o.UserName == userName);
                if (user != null && user.aspnet_Membership != null)
                    email = user.aspnet_Membership.Email;
            }


            return email;
        }
    }
}
