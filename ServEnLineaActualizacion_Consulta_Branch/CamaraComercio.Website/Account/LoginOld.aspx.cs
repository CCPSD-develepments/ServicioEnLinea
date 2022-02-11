using CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.Website.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login'
    public partial class Login : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                Master.HideNavigation();

                if (this.RememberMe.Checked)
                {
                    this.rfvEmpresa.Enabled = true;
                    this.rfvRNC.Enabled = true;
                }
                else
                {
                    this.rfvEmpresa.Enabled = false;
                    this.rfvRNC.Enabled = false;
                }
            }

            //si el usuario está autenticado, lo redirecciono a la página por default
            if (User.Identity.IsAuthenticated)
                Response.Redirect(ConfigurationManager.AppSettings["RedirectLogin"], false);

            //revisar si existe los loggin attempts
            if (Session["Attempts"] == null)
                Session["Attempts"] = 0;

            //Si no está autenticado, se revisa si viene por autenticacion automática.
            var paramUsr = Request.Params["usr"];
            var paramTkn = Request.Params["tkn"];
            
            //Si no se pasan los parametros se presenta la página de autenticacion
            if (String.IsNullOrEmpty(paramUsr) || String.IsNullOrEmpty(paramTkn))
            {
                //Si el flujo del control llega aqui quiere decir que se debe redireccionar al usuario a la página de accede
             //   Response.Redirect(Helper.NoboxLogin, true);
            }

            //De lo contrario se valida el token
            if (UsuariosController.ValidateUserToken(paramUsr, paramTkn, 30))
            {
                FormsAuthentication.SetAuthCookie(paramUsr, false);

                var paramUrl = Request.Params["ReturnUrl"];
                if (!String.IsNullOrWhiteSpace(paramUrl))
                    Response.Redirect(paramUrl);

                Response.Redirect(ConfigurationManager.AppSettings["RedirectLogin"], false);
            }
            else
            {
                var paramUrl = Request.Params["FailReturnUrl"];
                if (paramUrl != null)
                {
                    var failUrl = paramUrl;

                    //validar formato de url.
                    Uri uri;
                    if (Uri.TryCreate(failUrl,UriKind.RelativeOrAbsolute,out uri))
                    {
                        Response.Redirect(failUrl);
                    }
                }
            }
        }

        #region Login
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.LoginUser_LoginError(object, EventArgs)'
        protected void LoginUser_LoginError(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.LoginUser_LoginError(object, EventArgs)'
        {
            var pnl = this.LoginUser.FindControl("pnlErrorLogin") as Panel;
            var user = Membership.GetUser(LoginUser.UserName);

            if (user != null && user.IsLockedOut)
                ((Label)LoginUser.FindControl("lblMensajes")).Text = "Su cuenta ha sido bloqueada por seguridad.";

            if (pnl != null)
                pnl.Visible = true;

            //log user activity
            MembershipHelper.LogUserActivity("Intento de accesso denegado", ((TextBox)this.LoginUser.FindControl("UserName")).Text);

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.btnRegister_Click(object, EventArgs)'
        protected void btnRegister_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.btnRegister_Click(object, EventArgs)'
        {
            if (!Page.IsValid) return;

            //crear usuario.
            var user = Membership.CreateUser(this.UserName.Text.Trim(), this.Password.Text.Trim(), this.Email.Text.Trim());

            //marcar el usuario como no activo.
            user.IsApproved = false;
            Membership.UpdateUser(user);

            var profile = (OficinaVirtualUserProfile)ProfileBase.Create(this.UserName.Text.Trim());

            //agregar propiedades al perfil
            profile.NombreSolicitante = this.NombreCompletoTextBox.Text.Trim();

            //agregar tipo de documento
            profile.TipoDocumento = this.ddlTipoDocumento.SelectedValue;

            //agregar numero de documento (en control es cédula pero es cedula o pasaporte)
            profile.NumeroDocumento = this.txtCedula.Text.Trim();

            //formatear cedula
            if (ddlTipoDocumento.SelectedValue == "Cedula")
                profile.NumeroDocumento = profile.NumeroDocumento.FormatRnc();


            //si es gestor revisar dos propiedades adicionales
            if (RememberMe.Checked)
            {
                profile.NombreEmpresa = this.txtNombreEmpresa.Text.Trim();
                profile.RNC = this.txtNombreCompleto.Text.Trim();
            }
            else
            {
                // no es gestor por lo que se pone su mismo username como gestor.
                profile.UsuarioPadre = user.UserName;
            }

            //salvar el perfil
            profile.Save();

            try
            {
                string url = string.Empty;

                //enviar el mail de notificacion
                EnviarCorreo(user, profile, out url);

                //Guardar link de confirmacion en tabla de log
                LogTransaccionesMethods.GrabarLogTransacciones(0, url, true, user.UserName);
                //
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //rollback
                Membership.DeleteUser(user.UserName);

                //poner mensaje
                Master.ShowMessageError("Ha ocurrido un error al crear su cuenta, favor intente nuevamente.");
                return;
            }

            //redireccionar al pending activation
            Response.Redirect("PendingActivation.aspx");
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.LoginUser_LoggingIn(object, LoginCancelEventArgs)'
        protected void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.LoginUser_LoggingIn(object, LoginCancelEventArgs)'
        {
            var txtUser = ((TextBox)LoginUser.FindControl("UserName"));
            var txtPass = ((TextBox)LoginUser.FindControl("Password"));
            var stopAuth = false;

            if (txtUser.Text.Length == 0)
            {
                txtUser.CssClass = "textEntry validationMark";
                stopAuth = true;
            }

            if (txtPass.Text.Length == 0)
            {
                txtPass.CssClass = "passwordEntry validationMark";
                stopAuth = true;
            }

            e.Cancel = stopAuth;

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.LoginUser_LoggedIn(object, EventArgs)'
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.LoginUser_LoggedIn(object, EventArgs)'
        {
            //log user activity
            MembershipHelper.LogUserActivity("Acceso a portal autorizado.", ((TextBox)this.LoginUser.FindControl("UserName")).Text);
        }
        #endregion

        #region Register
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.CustomValidatorEmailDuplicado_ServerValidate(object, ServerValidateEventArgs)'
        protected void CustomValidatorEmailDuplicado_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.CustomValidatorEmailDuplicado_ServerValidate(object, ServerValidateEventArgs)'
        {
            var usuario = Membership.GetUserNameByEmail(args.Value);
            args.IsValid = String.IsNullOrEmpty(usuario);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.vcExisteCedula_ServerValidate(object, ServerValidateEventArgs)'
        protected void vcExisteCedula_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.vcExisteCedula_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si el mail existe
            if (UsuariosController.ExisteNoDocumento(this.txtCedula.Text.Trim()))
                args.IsValid = false;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si existe el usuario
            var uc = new UsuariosController();

            if (uc.ExisteUsuario(this.LoginUser.UserName.Trim()))
                args.IsValid = false;
        }
        #endregion

#pragma warning disable CS1573 // Parameter 'linkAct' has no matching param tag in the XML comment for 'Login.EnviarCorreo(MembershipUser, OficinaVirtualUserProfile, out string)' (but other parameters do)
        /// <summary>
        /// Envia un correo al usuario que se acaba de registrar para que valide su usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="profile"></param>
        private static void EnviarCorreo(MembershipUser user, OficinaVirtualUserProfile profile, out string linkAct)
#pragma warning restore CS1573 // Parameter 'linkAct' has no matching param tag in the XML comment for 'Login.EnviarCorreo(MembershipUser, OficinaVirtualUserProfile, out string)' (but other parameters do)
        {
            linkAct = string.Empty;

            //check for nulls
            if (user == null || user.ProviderUserKey == null) return;

            //Armar el link de confirmacion            
            var url = string.Format("{0}/account/Activacionusuario.aspx?id={1}", Helper.UrlPortal, user.ProviderUserKey);

            linkAct = url;

            //Armar correo a enviar
            var parametros = new Dictionary<string, string>
                                 {
                                     {"[NombreCompleto]", profile.NombreSolicitante},
                                     {"[UserName]", user.UserName},
                                     {"[link]", url}
                                 };

            MailBot.MailBot.SendMail(user.Email, null, null, Helper.FromEmailCorreoCamara, "RDU",
                Helper.MailServer, 1, parametros);
        }
    }
}
