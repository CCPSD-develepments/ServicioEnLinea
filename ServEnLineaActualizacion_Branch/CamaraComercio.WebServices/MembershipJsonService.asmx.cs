using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Security;
using CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.Website;
using System.Web.Profile;
using System.Text.RegularExpressions;
using CamaraComercio.WebServices.Usuarios;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Web service que permite la integración con las demás aplicaciones del portal web de CCPSD (JSON)
    /// </summary>
    [WebService(Namespace = "http://www.camarasantodomingo.org")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MembershipJsonService : WebService
    {
        /// <summary>
        /// Recibe un usuario, password y app Token para y devuelve el resultado de la autenticacion.
        /// </summary>
        /// <param name="username">Username del website de la camara.</param>
        /// <param name="password">Password del usuario del website</param>
        /// <param name="systemToken">Token de la aplicacion que hace la llamada</param>
        /// <returns>True si el usuario es autenticado, de lo contrario false.</returns>
        [WebMethod]
        public string AuthenticateUser(string username, string password, string systemToken)
        {
            return new MembershipService().AuthenticateUser(username, password, systemToken).ToJSON();
        }

        /// <summary>
        /// Crea un nuevo usuario en el Website de la Camara de Comercio
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">ContraseÑa</param>
        /// <param name="email">Correo electrónico</param>
        /// <param name="nombreSolicitante">Nombre del solicitante</param>
        /// <param name="nombreEmpresa">Nombre de la empresa a la que pertenece</param>
        /// <param name="RNC">RNC</param>
        /// <returns></returns>
        [WebMethod]
        public string RegisterUser(string username, string password, string email, string nombreSolicitante, string nombreEmpresa, string RNC)
        {
            return new MembershipService().RegisterUser(username, password, email, nombreSolicitante,
                                                        nombreEmpresa, RNC).ToJSON();
        }

        /// <summary>
        /// Retorna true si existe el usaurio en la base de datos.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns></returns>
        [WebMethod]
        public string UsernameExists(string username)
        {
            return new MembershipService().UsernameExists(username).ToJSON();
        }

        /// <summary>
        /// Retorna si el email suministrado es existe
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [WebMethod]
        public string EmailExists(string email)
        {
            return new MembershipService().EmailExists(email).ToJSON();
        }

        /// <summary>
        /// Genera un token en la base de datos para permitir autenticar automaticamente un usuario que viene de fuera.
        /// </summary>
        /// <param name="username">Username del usuario a autenticar</param>
        /// <param name="password">Password del usuario a autenticar</param>
        /// <param name="systemId">Token de la aplicacion que hace la llamada</param>
        /// <returns></returns>
        [WebMethod]
        public string DelegateLogin(string username, string password, string systemId)
        {
            return new MembershipService().DelegateLogin(username, password, systemId).ToJSON();
        }

        /// <summary>
        /// Envia un correo al usuario que se acaba de registrar para que valide su usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="profile"></param>
        private void EnviarCorreo(MembershipUser user, OficinaVirtualUserProfile profile)
        {
            //Armar el link de confirmacion
            var url = string.Format("http://localhost:2899/account/Activacionusuario.aspx?id={0}",
                                       user.ProviderUserKey);

            //Armar el correo a enviar
            var parametros = new Dictionary<string, string>
                                 {
                                     {"[NombreCompleto]", profile.NombreSolicitante},
                                     {"[UserName]", user.UserName},
                                     {"[link]", url}
                                 };
            MailBot.MailBot.SendMail(user.Email, null, null, "ccpsd@camarasantodomingo.org.do", "RDU", 
                Helper.MailServer, 1, parametros);
        }
    }
}
