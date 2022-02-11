using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Security;
using CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.Website;
using System.Web.Profile;
using System.Text.RegularExpressions;
using CamaraComercio.WebServices.Usuarios;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Web service que permite la integración con las demás aplicaciones del portal web de CCPSD
    /// </summary>
    [WebService(Namespace = "http://www.camarasantodomingo.org")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MembershipService : WebService
    {

        /// <summary>
        /// Recibe un usuario, password y app Token para y devuelve el resultado de la autenticacion.
        /// </summary>
        /// <param name="username">Username del website de la camara.</param>
        /// <param name="password">Password del usuario del website</param>
        /// <param name="systemToken">Token de la aplicacion que hace la llamada</param>
        /// <returns>True si el usuario es autenticado, de lo contrario false.</returns>
        [WebMethod]
        public bool AuthenticateUser(string username, string password, string systemToken)
        {
            Guid token;
            //parsear el guid
            if (!Guid.TryParse(systemToken, out token))
                throw new FormatException("GUID not in a correct format");

            MembershipHelper.LogUserActivity("Usuario autenticado mediante API", username);

            //revisar que el application token es valido
            return UsuariosController.SourceSystemExists(token) && Membership.ValidateUser(username, password);
        }

        /// <summary>
        /// Recibe un usuario y un toke, para pasar la validación de un usuario desde el site de Nextmedia al de Nobox
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <param name="systemToken"></param>
        /// <returns></returns>
        [WebMethod]
        public bool AuthenticateHandOver(string username, string token, string systemToken)
        {
            var exitoso = UsuariosController.ValidateUserToken(username, token, 30);
            var mensaje = exitoso 
                              ? "Acceso Exitoso al portal de Nobox con HandOver"
                              : "Intento de Accedo denegado hacia el portal de Nobox";
            MembershipHelper.LogUserActivity(mensaje, username);
            return exitoso;
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
        public int RegisterUser
            (string username, string password, string email, string nombreSolicitante, string nombreEmpresa, string RNC)
        {
            MembershipUser user;
            OficinaVirtualUserProfile profile;
            int newUserId;
            
            var uc = new UsuariosController();

            //validar tamaño username.
            if (username.Length < 4)
            {
                //El tamaño del nombre de usuario debe ser 4 caracteres.
                return (int)RegisterUserResult.FormatoUsuarioInvalido;
            }

            //validar si usuario existe.
            if (uc.ExisteUsuario(username))
            {
                //Nombre de usuario ya existe.
                return (int)RegisterUserResult.UsuarioExiste;
            }

            //validar formato email
            var regExp = Regex.Match(email,@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!regExp.Success)
            {
                //El formato de email es inválido.
                return (int)RegisterUserResult.FormatoEmailInvalido;
            }

            //Validar que el email existte.
            string usuario = Membership.GetUserNameByEmail(email);
            if (!string.IsNullOrEmpty(usuario))
            {
                //El email ya existe en el sistema.
                return (int)RegisterUserResult.EmailExiste;
            }

            try
            {
                //crear usuario.
                user = Membership.CreateUser(username, password, email);

                //marcar el usuario como no activo.
                user.IsApproved = false;
                Membership.UpdateUser(user);

                profile = (OficinaVirtualUserProfile)ProfileBase.Create(username);

                //agregar propiedades al perfil
                profile.NombreSolicitante = nombreSolicitante;

                //si es gestor revisar dos propiedades adicionales
                if (nombreEmpresa != null)
                {
                    profile.NombreEmpresa = nombreEmpresa;
                    profile.RNC = RNC;
                }
                else
                {
                    // no es gestor por lo que se pone su mismo username como gestor.
                    profile.UsuarioPadre = user.UserName;
                }

                //salvar el perfil
                profile.Save();

            }
            catch (Exception)
            {
                //no se pudo crear el usuario
                return (int)RegisterUserResult.UsuarioNoCreado;
            }

            //enviar el mail de notificacion
            try
            {
                EnviarCorreo(user, profile);
                //usuario creado satisfactoriamente
                newUserId = (int)RegisterUserResult.UsuarioCreado;
            }
            catch (Exception)
            {
                //rollback
                Membership.DeleteUser(user.UserName);
                //no se puedo crear el usuario.
                newUserId = (int)RegisterUserResult.UsuarioNoCreado;
            }

            return newUserId;
        }

        /// <summary>
        /// Retorna true si existe el usaurio en la base de datos.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns></returns>
        [WebMethod]
        public bool UsernameExists(string username)
        {
            var uc = new UsuariosController();
            return uc.ExisteUsuario(username);
        }

        /// <summary>
        /// Retorna si el email suministrado es existe
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [WebMethod]
        public bool EmailExists(string email)
        {
            return UsuariosController.ExisteEmail(email);
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
            Guid appToken;

            //parsear el guid
            if (Guid.TryParse(systemId, out appToken))
            {
                //revisar que el application token es valido
                if (UsuariosController.SourceSystemExists(appToken))
                {
                    //revisar si el usuario y password coinciden
                    if (Membership.ValidateUser(username, password))
                    {
                        //insertar row en tabla de tokens
                        Guid userToken = UsuariosController.AddAuthenticationToken(username, appToken);
                        MembershipHelper.LogUserActivity("Acceso a portal autorizado mediante API", username);

                        //retornar el nuevo guid
                        return userToken.ToString();
                    }
                    
                    throw new Exception("Usuario / contraseña invalida.");
                }
                
                //la aplicacion no existe
                throw new Exception("La aplicación no esta registrada en el sistema.");
            }
            //guid no valido
            throw new FormatException("GUID not in a correct format.");
        }

        /// <summary>
        /// Revisa si un usuario está logueado en alguna aplicación del Membership
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod (Description = "Revisa si un usuario aún está logueado en la aplicación")]
        public bool CheckIfLoggedIn(string username)
        {
            var ctrl = new UsuariosController();
            var fecha = ctrl.GetLastUserActivityDate(username);
            if (!fecha.HasValue)
                return false;
            
            var tokenLife = (DateTime.Now - fecha.Value).TotalSeconds;
            return (tokenLife < 15*60);
        }

        /// <summary>
        /// Obtiene información de un usuario del portal
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod (Description = "Obtiene información de un usuario del portal")]
        public UserInfoDTO UserInfo(string username)
        {
            var ctrl = new UsuariosController();
            var ctrlEmpresas = new OFV.EmpresasPorUsuarioController();

            var viewProperties = UsuariosController.GetInfoUsuarioByUserName(username);
            var fechaCreacion = ctrl.GetUserCreatedDate(username);
            var empresas = ctrlEmpresas.FetchAllByUserName(username);

            if (viewProperties != null && fechaCreacion != null)
            {
                var listadoEmpresas = empresas.Select(e => new EmpresaDTO()
                                                            {CamaraID = e.CamaraID, 
                                                             Nombre = e.NombreEmpresa, 
                                                             NumeroRegistro = e.NoRegistro
                                                            }).ToList();
                return new UserInfoDTO()
                    {
                        EmpresasAsociadas = listadoEmpresas,
                        FechaCreacion = fechaCreacion,
                        NombreCompleto = viewProperties.NombreSolicitante,
                        NombreUsuario = username
                    };
            }

            return null;
        }

        /// <summary>
        /// Obtiene información de un usuario del portal y su contrato
        /// </summary>
        /// <param name="username">Nombre de usuario del portal</param>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene información de un usuario del portal y su contrato")]
        public UserInfoContratoDTO UserInfoContrato(string username)
        {
            var user = OficinaVirtualUserProfile.GetUserProfile(username);
            if (user == null)
                return null;

            return new UserInfoContratoDTO()
                       {
                           CedulaRnc = user.RNC,
                           ContratoFirmato = user.ContratoFirmado.GetValueOrDefault(),
                           NombreCompleto = user.NombreSolicitante,
                           NombreUsuario = user.UserName
                       };
        }

        /// <summary>
        /// Valida la firma del contrato del usuario del portal.
        /// </summary>
        /// <param name="username">Nombre de usuario del portal.</param>
        /// <returns></returns>
        [WebMethod(Description = "Valida la firma del contrato del usuario del portal.")]
        public bool MarcarContratoFirmato(string username)
        {
            var opExitosa = false;

            var user = OficinaVirtualUserProfile.GetUserProfile(username);
            if (user != null)
            {
                user.ContratoFirmado = true;
                user.Save();
                opExitosa = true;
            }

            return opExitosa;
        }

        

        /// <summary>
        /// Obtiene todos los usuarios hijos o hermanos del usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene todos los usuarios hijos o hermanos del usuario")]
        public List<UserInfoDTO> ObtenerUsuariosRelacionados(string username)
        {
            var ctrl = new UsuariosController();
            var usrActual = UsuariosController.GetInfoUsuarioByUserName(username);

            if (usrActual.UsuarioPadre != null)
            {
                var lista = new List<UserInfoDTO>();
                var usuarioPadre = UsuariosController.GetInfoUsuarioByUserName(usrActual.UsuarioPadre);
                var usuariosHijos = ctrl.FetchByUsuarioPadre(usrActual.UsuarioPadre);

                var usuarioPadreDto = new UserInfoDTO()
                                          {
                                              EmpresasAsociadas = null,
                                              FechaCreacion = usuarioPadre.LastUpdatedDate,
                                              NombreCompleto = usuarioPadre.NombreSolicitante,
                                              NombreUsuario = usuarioPadre.UserName
                                          };
                lista.Add(usuarioPadreDto);

                foreach (var hijo in usuariosHijos)
                {
                    var usrHijo = new UserInfoDTO()
                    {
                        EmpresasAsociadas = null,
                        FechaCreacion = hijo.LastUpdatedDate,
                        NombreCompleto = hijo.NombreSolicitante,
                        NombreUsuario = hijo.UserName
                    };
                    lista.Add(usrHijo);
                }
                return lista;
            }

            return null;
        }
        
        /// <summary>
        /// Envia un correo al usuario que se acaba de registrar para que valide su usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="profile"></param>
        private static void EnviarCorreo(MembershipUser user, OficinaVirtualUserProfile profile)
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

            MailBot.MailBot.SendMail(user.Email, null, null, 
                "ccpsd@camarasantodomingo.org.do", "RDU",
                Helper.MailServer, 1, parametros);
        }
        
    }

    public class UserInfoDTO
    {
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public List<EmpresaDTO> EmpresasAsociadas { get; set; }
    }

    public class EmpresaDTO
    {
        public int? NumeroRegistro { get; set; }
        public string Nombre { get; set; }
        public string CamaraID { get; set; }
    }

    public class UserInfoContratoDTO
    {
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string CedulaRnc { get; set; }
        public bool ContratoFirmato { get; set; }
    }
}
