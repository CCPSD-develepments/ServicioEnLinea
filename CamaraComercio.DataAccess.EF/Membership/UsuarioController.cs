using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.Membership
{
    /// <summary>
    /// Controlador para usuarios del Membership
    /// </summary>
    [DataObject()]
    public class UsuariosController
    {

        CamaraWebsiteAccountsEntities db = new CamaraWebsiteAccountsEntities();

        /// <summary>
        /// Obtiene todos los usuarios hijos de un usuario padre
        /// </summary>
        /// <param name="usuarioPadre">Nombre del usuario</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<ViewProfileProperties> FetchByUsuarioPadre(string usuarioPadre)
        {
            var qry = from c in db.ViewProfileProperties
                      where c.UsuarioPadre == usuarioPadre
                      select c;    
            return qry;
        }

        /// <summary>
        /// Obtiene todos los usuarios hijos de un usuario padre filtrando por usuarios activos
        /// </summary>
        /// <param name="usuarioPadre">Nombre del usuario</param>
        /// <param name="traerActivos">Valor que indica si se deben traer los usuarios activos o inactivos1</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<ViewProfileProperties> FetchByUsuarioPadre(string usuarioPadre, string traerActivos)
        {
            var qry = from c in db.ViewProfileProperties
                      where c.UsuarioPadre == usuarioPadre && c.IsActive == traerActivos
                      select c;
            return qry;
        }

        /// <summary>
        /// Revisa si existe el usuario en la base de datos
        /// </summary>
        /// <param name="usuario">Usuario a revisar</param>
        /// <returns>Devuelvue true si existe el usuario, de lo contrario false</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public bool ExisteUsuario(string usuario)
        {
            var qry = (from c in db.ViewProfileProperties
                       where c.UserName == usuario
                       select c).Count();
            return qry > 0;
        }

        /// <summary>
        /// Verifica si el correo electrónico de un usuario existe en la base de datos
        /// </summary>
        /// <param name="email">Correo electrónico </param>
        /// <returns></returns>
        public static bool ExisteEmail(string email)
        {
            var db = new CamaraWebsiteAccountsEntities();

            return (db.ViewProfileProperties.Where(c => c.Email == email).Count()) > 0;
        }

        /// <summary>
        /// Revisa si existe el numero de documento en la base de datos.
        /// </summary>
        /// <param name="noDocumento">Numero de documento (cedula o pasaporte)</param>
        /// <returns>retorna true si encuentra un registro con el número de documento</returns>
        public static bool ExisteNoDocumento(string noDocumento)
        {
            var db = new CamaraWebsiteAccountsEntities();

            var qry = db.ViewProfileProperties.Where(c => c.NumeroDocumento == noDocumento).Count();

            return qry > 0;
        }

        public static string DevuelveUsernamePorDocumento(string noDocumento)
        {
            string result = string.Empty;

            var db = new CamaraWebsiteAccountsEntities();
            var user = db.ViewProfileProperties.FirstOrDefault(c => c.NumeroDocumento == noDocumento.Trim());
            if (user != null)
                result = user.UserName.ToLower();

            return result;
        }

        public static bool ValidadBorradoRegistroMas24HorasSinAprobar(string userName)
        {
            bool result = false;
            var db = new CamaraWebsiteAccountsEntities();
            var profile = db.ViewProfileProperties.FirstOrDefault(c => c.UserName == userName.ToLower());
            if (profile != null)
            {
                var membresia = db.aspnet_Membership.FirstOrDefault(c => c.UserId == profile.UserId);
                if(membresia != null)
                {
                    TimeSpan ts = DateTime.Now - membresia.CreateDate;
                    int horas = ts.Hours;

                    if(!membresia.IsApproved && horas > 24)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Trae el email basandose en el username
        /// </summary>
        /// <param name="username">El nombre usuario</param>
        /// <returns>Retorna el email del usuario</returns>
        public static string GetEmailByUsername(string username)
        {
            var d = new CamaraWebsiteAccountsEntities();
            var qry = (from c in d.ViewProfileProperties
                       where c.UserName == username
                       select c.Email).FirstOrDefault();
            return qry;
        }

        /// <summary>
        /// Busca el username en base al Password reset key generado en el formulario forgotpassword.
        /// </summary>
        /// <param name="passwordResetKey">Guid generado</param>
        /// <returns>Retorna el username</returns>
        public static string GetUsernameByPasswordResetKey(string passwordResetKey)
        {
            var d = new CamaraWebsiteAccountsEntities();
            var qry = (from c in d.ViewProfileProperties
                       where c.PasswordResetKey == passwordResetKey
                       select c.UserName).FirstOrDefault();
            return qry;
        }

        /// <summary>
        /// Obtiene un nombre de usuario a partir del key de reactivación de un usuario
        /// </summary>
        /// <param name="activateUserKey">Llave de activación para un usuario</param>
        /// <returns></returns>
        public static string GetUsernameByActivateUserKey(string activateUserKey)
        {
            var d = new CamaraWebsiteAccountsEntities();
            var qry = (from c in d.ViewProfileProperties
                       where c.ActivateUserKey == activateUserKey
                       select c.UserName).FirstOrDefault();
            return qry;
        }

        /// <summary>
        /// Busca el usuario padre pasado en el usuario que se le pasa
        /// </summary>
        /// <param name="username">Username del que se quiere saber su usuario padre</param>
        /// <returns>Retorna el usuario padre y si retorna null es que el username es el usuario padre.</returns>
        public static string GetUsuarioPadreByUsername(string username)
        {
            var db = new CamaraWebsiteAccountsEntities();
            
            var qry = (from c in db.ViewProfileProperties
                     where c.UserName == username
                     select c.UsuarioPadre).FirstOrDefault();
            //si no trae usuario padre significa que el username es el usuario padre
            return string.IsNullOrEmpty(qry) ? username : qry;
        }

        /// <summary>
        /// Obtiene la información de los parametros personalizados de un usuario en la base de datos de membership a partir del padre de un usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario</param>
        /// <returns></returns>
        public static ViewProfileProperties GetInfoUsuarioPadreByUserName(string userName)
        {
            var usuarioPadre = GetUsuarioPadreByUsername(userName);
            var db = new CamaraWebsiteAccountsEntities();
            var qry = db.ViewProfileProperties.Where(c => c.UserName == usuarioPadre).FirstOrDefault();
            return qry;
        }

        /// <summary>
        /// Obtiene la información de los parametros personalizados de un usuario en la base de datos de membership
        /// </summary>
        /// <param name="userName">Nombre del usuario</param>
        /// <returns></returns>
        public static ViewProfileProperties GetInfoUsuarioByUserName(string userName)
        {
            var db = new CamaraWebsiteAccountsEntities();
            var qry = db.ViewProfileProperties.Where(c => c.UserName == userName).FirstOrDefault();
            return qry;
        }

        /// <summary>
        /// Desactiva el usuario padre y retorna la colección de sus hijos
        /// </summary>
        /// <param name="usuarioPadre">El usuario padre a desactivar.</param>
        /// <returns>Retorna la colección de sus hijos</returns>
        public static IQueryable<ViewProfileProperties> DesactivarUsuarioPadre(string usuarioPadre)
        {
            var db = new CamaraWebsiteAccountsEntities();

            //desactivar el usuario padre
            var userPadre = db.aspnet_Users.Where(c => c.UserName == usuarioPadre).FirstOrDefault();
            userPadre.aspnet_Membership.IsApproved = false;

            db.SaveChanges();

            //cambiar el usuario padre de todos los  sub usuarios
            //traer de la db todos los usuarios hijos
            var uc = new UsuariosController();
            return uc.FetchByUsuarioPadre(usuarioPadre);
        }

        /// <summary>
        /// Valida si existe el sistema fuente en la tabla de Systemas.
        /// </summary>
        /// <param name="systemId">Guid que representa el systema.</param>
        /// <returns>Retorna true si existe el systema</returns>
        public static bool SourceSystemExists(Guid systemId)
        {
            var db = new CamaraWebsiteAccountsEntities();
            //busca por id la aplicacion.
            var qry = db.camara_Systems.Where(c => c.SystemId == systemId && c.Active == true);
            return qry.Count() > 0;
        }

        /// <summary>
        /// Agrega un token de autenticacion para autenticación automática.
        /// </summary>
        /// <param name="username">Nombre de usuario a autenticar.</param>
        /// <param name="systemId">System id que pide la autenticacion.</param>
        /// <returns></returns>
        public static Guid AddAuthenticationToken(string username, Guid systemId)
        {
            var db = new CamaraWebsiteAccountsEntities();

            var token = new CamaraTokens
                            {
                                SystemId = systemId,
                                Username = username,
                                CreatedOn = DateTime.Now,
                                TokenId = Guid.NewGuid()
                            };

            db.camara_Tokens.AddObject(token);
            db.SaveChanges();
            return token.TokenId;
        }


        /// <summary>
        /// Valida si un token para un usuario aun está activo
        /// </summary>
        /// <param name="username">Usuario que genera el token</param>
        /// <param name="token">Token generado</param>
        /// <param name="desiredTokenLife">Timepo de vida deseado para el token</param>
        /// <returns></returns>
        public static bool ValidateUserToken(string username, string token, int desiredTokenLife)
        {
            Guid userToken;
            
            //parsear el guid
            if (!Guid.TryParse(token, out userToken))
            {
                return false;
            }
            
            var db = new CamaraWebsiteAccountsEntities();

            //validar que existe un usuario con ese token.
            var x = db.camara_Tokens.Where(c => c.TokenId == userToken && c.Username == username).FirstOrDefault();

            if (x == null)
                return false; //no se encontró el token.
            
            var tokenLife = (DateTime.Now - x.CreatedOn).TotalSeconds;
            return (tokenLife <= desiredTokenLife);
        }
        
        ///<summary>
        /// Inserta un nuevo usuario autorizado
        ///</summary>
        ///<param name="userName">Nombre del usuario</param>
        ///<param name="noRegistro">Numero de registro mercantil</param>
        ///<param name="camaraID">Cámara de comercio</param>
        ///<param name="cedula">Cedula del usuario</param>
        ///<param name="nombre">Nombre Completo</param>
        public static void UsuarioAutorizadoInsert(string userName, int noRegistro, string camaraID, string cedula, string nombre)
        {
            var db = new CamaraWebsiteAccountsEntities();

            var authUser = new CamaraAuthUsers()
                            {
                                UserName = userName,
                                NoRegistro = noRegistro,
                                CamaraID = camaraID,
                                Cedula = cedula,
                                Nombre = nombre,
                                Activo = true
                            };

            db.camara_Auth_Users.AddObject(authUser);
            db.SaveChanges();
        }
        
        /// <summary>
        /// Actualiza un usuario autorizado
        /// </summary>
        ///<param name="userName">Nombre del usuario</param>
        ///<param name="noRegistro">Numero de registro mercantil</param>
        ///<param name="camaraID">Cámara de comercio</param>
        ///<param name="cedula">Cedula del usuario</param>
        ///<param name="nombre">Nombre Completo</param>
        /// <param name="Activo">Indica si el usuario está activo o no</param>
        public static void UsuarioAutorizadoUpdate(string userName, int noRegistro, string camaraID, string cedula, string nombre, bool Activo)
        {
            var db = new CamaraWebsiteAccountsEntities();

            var usuario = db.camara_Auth_Users.Where(c =>   c.UserName == userName && c.NoRegistro == noRegistro && c.CamaraID == camaraID && c.Cedula == cedula).FirstOrDefault();
            usuario.Activo = Activo;
            db.SaveChanges();

        }
        
        /// <summary>
        /// Verifica si un usuario autorizado existe
        /// </summary>
        /// <param name="userName">Nombre del usuario</param>
        /// <param name="noRegistro">Número de registro mercantil</param>
        /// <param name="cedula">Cédula</param>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <returns></returns>
        public static bool ExisteUsuarioAutorizado(string userName, int noRegistro, string cedula, string camaraId)
        {
            var db = new CamaraWebsiteAccountsEntities();

            var qry = db.camara_Auth_Users.Where(c => c.UserName == userName &&
                                                        c.NoRegistro == noRegistro &&
                                                        c.Cedula == cedula &&
                                                        c.CamaraID == camaraId).Count();

            return qry > 0;
        }

        /// <summary>
        /// Agrega una entrada en la tabla de actividades de usuarios logeados
        /// </summary>
        /// <param name="userName">Nombre del usuario</param>
        /// <param name="activity">Actividad realizada</param>
        /// <param name="pageUrl">URL de la página donde se efectuó la actividad</param>
        /// <param name="activityDate"></param>
        public static void LogUserActivity(string userName, string activity, string pageUrl, DateTime activityDate, string ipAddress)
        {
            var db = new CamaraWebsiteAccountsEntities();

            var qry = db.aspnet_Users.Where(c => c.UserName == userName).FirstOrDefault();
            qry.LastActivityDate = DateTime.UtcNow;

            var al = new ActivityLog
                         {
                             ActivityLogID = Guid.NewGuid(),
                             UserId = qry.UserId,
                             Activity = activity,
                             PageUrl = pageUrl.Length >= 255 ? pageUrl.Substring(0,254) : pageUrl,
                             ActivityDate = activityDate.ToUniversalTime(),
                             IpAddress = ipAddress
                         };
            db.ActivityLog.AddObject(al);
            db.SaveChanges();
        }

        /// <summary>
        /// Retorna la última fecha de actividad de un usuario a partir de su nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns></returns>
        public DateTime? GetLastUserActivityDate(string username)
        {
            var user = db.aspnet_Users.Where(s => s.UserName == username).FirstOrDefault();
            if (user != null)
            {
                return user.LastActivityDate;
            }
            
            return null;
        }

        /// <summary>
        /// Obtiene la fecha de creación de un usuario nuevo
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns></returns>
        public DateTime? GetUserCreatedDate(string username)
        {
            var user = db.aspnet_Users.Where(s => s.UserName == username).FirstOrDefault();
            if (user != null)
            {
                return user.aspnet_Membership.CreateDate;
            }

            return null;
        }

        /// <summary>
        /// Retorna las actidades de un usuario en el portal
        /// </summary>
        /// <param name="userName">Username deseado</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<ActivityLog> GetAllUserActivity(string userName)
        {
            return db.ActivityLog.Where(c => c.aspnet_Users.UserName == userName).OrderByDescending(c => c.ActivityDate);           
        }

        /// <summary>
        /// Retorna las actidades en el portal.
        /// </summary>      
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetAllActivityDt()
        {
            return db.ActivityLog.OrderByDescending(c => c.ActivityDate).Select(c => new { c.ActivityDate, c.aspnet_Users.UserName, c.Activity, c.PageUrl, c.IpAddress}).ToDataTable();
        }

        /// <summary>
        /// Retorna las actidades de un usuario en el portal
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllActivity()
        {
            return this.GetAllActivity();
        }

    }
}
