using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using CamaraComercio.DataAccess.EF.Membership;

namespace CamaraComercio.Website
{
    /// <summary>
    /// Clases de soporte para acceso a informacion en el Membserhip
    /// </summary>
    public static class MembershipHelper
    {
        /// <summary>
        /// Busca el MembershipUser en base al guid del campo UserId como un string string.
        /// </summary>
        /// <param name="userId">Campo UserId</param>
        public static MembershipUser GetUserByKey(string userId)
        {
            Guid myKey = new Guid(userId);
            return Membership.GetUser(((object)myKey));
        }

        /// <summary>
        /// Revisa si existe un correo electronico en el base de datos de Membership
        /// </summary>
        /// <param name="emailNuevoUsuario">Email deseado</param>
        /// <returns>Retorna true si existe el correo</returns>
        public static bool ExisteCorreo(string emailNuevoUsuario)
        {
            string usuario = Membership.GetUserNameByEmail(emailNuevoUsuario);
            return !String.IsNullOrEmpty(usuario);
        }

        /// <summary>
        /// Roles definidos en la aplicación
        /// </summary>
        public static class Roles
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Empresas'
            public const string Empresas = "Empresas";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Empresas'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Gestores'
            public const string Gestores = "Gestores";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Gestores'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Supervisores'
            public const string Supervisores = "Supervisores";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Supervisores'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Administradores'
            public const string Administradores = "Administradores";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.Roles.Administradores'
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute'
        public class MenuSiteMapAttribute : Attribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute'
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute.SiteMapProvider'
            public String SiteMapProvider { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute.SiteMapProvider'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute.MenuSiteMapAttribute()'
            public MenuSiteMapAttribute()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute.MenuSiteMapAttribute()'
                : base()
            {
            }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute.MenuSiteMapAttribute(string)'
            public MenuSiteMapAttribute(String siteMapProvider)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.MenuSiteMapAttribute.MenuSiteMapAttribute(string)'
            {
                this.SiteMapProvider = siteMapProvider;
            }
        }

        #region Log User Activity

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.LogUserActivity(string, string)'
        public static void LogUserActivity(string activity, string user)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MembershipHelper.LogUserActivity(string, string)'
        {
            var ip = HttpContext.Current.Request.UserHostAddress;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                UsuariosController.LogUserActivity(HttpContext.Current.User.Identity.Name, activity, HttpContext.Current.Request.RawUrl, DateTime.Now, ip);
            }
            else
            {
                if (user != null)
                {
                    //revisar si el usuario existe
                    if (Membership.GetUser(user) != null)
                    {             
                        //logear actividad si existe
                        UsuariosController.LogUserActivity(user, activity, HttpContext.Current.Request.RawUrl, DateTime.Now, ip);
                    }
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Clase extendida del profile base para asistir al acceso de información 
    /// almacenada en el profile del usuario logueado
    /// </summary>
    public class OficinaVirtualUserProfile : ProfileBase
    {

        #region Object Initializers

        /// <summary>
        /// Obtiene un user profile del membership provider con los accesores
        /// que facilitan acceso a las propiedades definidas para la OFV (a partir del user profile actual)
        /// </summary>
        /// <returns></returns>
        private static OficinaVirtualUserProfile Profile
        {
            get { return (OficinaVirtualUserProfile)HttpContext.Current.Profile; }
        }

        /// <summary>
        /// Obtiene un user profile del membership provider con los accesores
        /// que facilitan acceso a las propiedades definidas para la OFV (a partir de un username)
        /// </summary>
        /// <returns></returns>
        public static OficinaVirtualUserProfile GetUserProfile(string username)
        {
            return Create(username) as OficinaVirtualUserProfile;
        }

        /// <summary>
        /// Obtiene un user profile del membership provider con los accesores
        /// que facilitan acceso a las propiedades definidas para la OFV
        /// </summary>
        /// <returns></returns>
        public static OficinaVirtualUserProfile GetUserProfile()
        {
            var usuario = Membership.GetUser();
            OficinaVirtualUserProfile usuarioOfv = null;
            if (usuario != null)
            {
                usuarioOfv = Create(usuario.UserName) as OficinaVirtualUserProfile;
            }
            return usuarioOfv;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Nombre del Solicitante. Por que se le puso asi a esta propiedad?
        /// </summary>
        [SettingsAllowAnonymous(false)]
        public string NombreSolicitante
        {
            get { return base["NombreSolicitante"] as string; }
            set { base["NombreSolicitante"] = value; }
        }

        /// <summary>
        /// Tipo de documento del usuario. Puede ser pasaporte o Cedula
        /// </summary>
        [SettingsAllowAnonymous(false)]
        public string TipoDocumento
        {
            get { return base["TipoDocumento"] as string; }
            set { base["TipoDocumento"] = value; }
        }

        /// <summary>
        /// Cedula o Pasaporte del usuario
        /// </summary>
        [SettingsAllowAnonymous(false)]
        public string NumeroDocumento
        {
            get { return base["NumeroDocumento"] as string; }
            set { base["NumeroDocumento"] = value; }
        }

        /// <summary>
        /// Telefono del usuario
        /// </summary>
        [SettingsAllowAnonymous(false)]
        public string Telefono
        {
            get { return base["Telefono"] as string; }
            set { base["Telefono"] = value; }
        }

        /// <summary>
        /// Indica cual es la cuenta padre (Gestor) si es un cuenta padre lleva null y si es una cuenta sin padre lleva su mismo username repetido.
        /// </summary>
        public string UsuarioPadre
        {
            get { return base["UsuarioPadre"] as string; }
            set { base["UsuarioPadre"] = value; }
        }

        /// <summary>
        /// Guid que se genera para el mail de reseteo de password.
        /// </summary>
        public string PasswordResetKey
        {
            get { return base["PasswordResetKey"] as string; }
            set { base["PasswordResetKey"] = value; }
        }

        /// <summary>
        /// Guid que se genera para la activación de un usuario hijo.
        /// </summary>
        public string ActivateUserKey
        {
            get { return base["ActivateUserKey"] as string; }
            set { base["ActivateUserKey"] = value; }
        }

        /// <summary>
        /// Bool que determina si un usuario esta activo
        /// </summary>
        public bool IsActive
        {
            get { return Convert.ToBoolean(base["IsActive"]); }
            set { base["IsActive"] = value; }
        }

        /// <summary>
        /// Nombre de la empresa que se registra
        /// </summary>
        public string NombreEmpresa
        {
            get { return base["NombreEmpresa"] as string; }
            set { base["NombreEmpresa"] = value; }
        }

        /// <summary>
        /// Nombre de la empresa que se registra
        /// </summary>
        public string RNC
        {
            get { return base["RNC"] as string; }
            set { base["RNC"] = value; }
        }

        /// <summary>
        /// Posee firma digital??
        /// </summary>
        public bool? bFirmaDigital
        {
            get { return (bool?)base["bFirmaDigital"]; }
            set { base["bFirmaDigital"] = value; }
        }

        /// <summary>
        /// Indica si el usuario ya firmó el acuerdo de uso del portal
        /// </summary>
        public bool? ContratoFirmado
        {
            get { return (bool?) base["ContratoFirmado"]; }
            set { base["ContratoFirmado"] = value; }
        }

        /// <summary>
        /// Indica el IP desde donde fue firmado el acuerdo de uso del portal
        /// </summary>
        public string IpFirma
        {
            get { return (string) base["IpFirma"]; }
            set { base["IpFirma"] = value;}
        }

        /// <summary>
        /// Número de teléfono que se registra
        /// </summary>
        public string Phone
        {
            get { return base["Phone"] as string; }
            set { base["Phone"] = value; }
        }

        /// <summary>
        /// Extensión del número de teléfono que se registra
        /// </summary>
        public string Extension
        {
            get { return base["Extension"] as string; }
            set { base["Extension"] = value; }
        }

        /// <summary>
        /// Indica si el usuario hijo debe cambiar su contraseña al loguearse por primera vez
        /// </summary>
        public bool DebeCambiarPass
        {
            get
            {
                if (base["DebeCambiarPass"] == null)
                    base["DebeCambiarPass"] = false;
                
                return (bool) base["DebeCambiarPass"];
            }
            set { base["DebeCambiarPass"] = value; }
        }

        /// <summary>
        /// Jerarquía de usuarios asociados
        /// </summary>
        public List<Guid> JerarquiaUsuarios
        {
            get 
            {    
                try
                {
                    var usuarioPadre = UsuariosController.GetUsuarioPadreByUsername(this.UserName);
                    var hijos = new UsuariosController().FetchByUsuarioPadre(usuarioPadre);
                    return hijos.Select(h => h.UserId).ToList();
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Verifica si un documento de identidad ya existe en la base de datos del membership (cedula o pasaporte)
        /// </summary>
        /// <param name="numeroDocumento">Cedula o Pasaporte</param>
        /// <returns></returns>
        public static bool ExisteDocumento(string numeroDocumento)
        {
            var db = new CamaraWebsiteAccountsEntities();
            var qry = (from v in db.ViewProfileProperties
                       where v.NumeroDocumento == numeroDocumento
                       select v).FirstOrDefault();

            var existe = (qry != null);
            return existe;
        }

        /// <summary>
        /// Verifica si un documento de identidad ya existe en la base de datos del membership (cedula o pasaporte)
        /// </summary>
        /// <param name="numeroDocumento">Cedula o Pasaporte</param>
        /// <param name="usuario">Usuario a ignorar en la comparacion</param>
        /// <returns></returns>
        /// <remarks>Sobrecarga que toma en cuenta el usuario actual</remarks>
        public static bool ExisteDocumento(string numeroDocumento, string usuario)
        {
            var db = new CamaraWebsiteAccountsEntities();
            var qry = (from v in db.ViewProfileProperties
                       where v.NumeroDocumento == numeroDocumento
                             && v.UserName != usuario
                       select v);

            var existe = (qry.Count() > 0);
            return existe;
        }

        #endregion
    }

    /// <summary>
    /// Manejo de Sitemap basado en roles a partir de archivox XML tipo SiteMap
    /// </summary>
    public class RoleBasedXmlSiteMapProvider : XmlSiteMapProvider
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RoleBasedXmlSiteMapProvider.IsAccessibleToUser(HttpContext, SiteMapNode)'
        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RoleBasedXmlSiteMapProvider.IsAccessibleToUser(HttpContext, SiteMapNode)'
        {
            if (!this.SecurityTrimmingEnabled)
                return true;

            var result = base.IsAccessibleToUser(context, node);

            if (context.User == null)
                return result;

            foreach (string role in node.Roles)
            {
                if (role == "*")
                    return result == true;

                //Si tiene un rol asignado y no esta autenticado debe ser false por defecto, hasta que se demuestre lo contrario
                result = false;
                if (context.User.Identity.IsAuthenticated)
                {
                    result = context.User.IsInRole(role);
                    return result;
                }
                return result;
            }
            return result;
        }
    }

    /// <summary>
    /// Modulo de manejo de seguridad para el Sitemap
    /// </summary>
    public class SiteMapSecurityModule : IHttpModule
    {
        #region IHttpModule Members

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SiteMapSecurityModule.Dispose()'
        public void Dispose()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SiteMapSecurityModule.Dispose()'
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SiteMapSecurityModule.Init(HttpApplication)'
        public void Init(HttpApplication context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SiteMapSecurityModule.Init(HttpApplication)'
        {
            context.AuthenticateRequest += new EventHandler(this.AuthenticateRequest);
        }

        #endregion


        private void AuthenticateRequest(Object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var request = application.Context.Request;
            var response = application.Context.Response;
#pragma warning disable CS0219 // The variable 'allow' is assigned but its value is never used
            var allow = false; // Default is not not allow
#pragma warning restore CS0219 // The variable 'allow' is assigned but its value is never used

            if (SiteMap.CurrentNode == null) return;

            if (request.Url.AbsolutePath.ToLower() ==
            FormsAuthentication.LoginUrl.ToLower()) return;
        }

    }
}