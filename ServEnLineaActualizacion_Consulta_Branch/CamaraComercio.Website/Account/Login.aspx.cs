using CamaraComercio.DataAccess.EF.Membership;
using System;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2'
    public partial class Login2 : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.Page_Init(object, EventArgs)'
        protected void Page_Init(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.Page_Init(object, EventArgs)'
        {
            //Validacion de browsers modernos
            var userAgent = (!String.IsNullOrEmpty(Request.UserAgent)) ? Request.UserAgent.ToLower() : "";

            //IE6-7 Support
            if (userAgent.Contains("msie 6.0") || userAgent.Contains("msie 6.1"))
            {
                Response.Redirect("/Navegadores.htm", true);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.Page_Load(object, EventArgs)'
        {
         //   LoginUser.UserName = "epuente";
         //   LoginUser..Password = "Camara123";

            //si el usuario está autenticado, lo redirecciono a la página por default
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect(ConfigurationManager.AppSettings["RedirectLogin"], false);
            }

            //revisar si existe los loggin attempts
            if (Session["Attempts"] == null)
            {
                Session["Attempts"] = 0;
            }

            //Si no está autenticado, se revisa si viene por autenticacion automática.
            var paramUsr = Request.Params["usr"];
            var paramTkn = Request.Params["tkn"];

            //Si no se pasan los parametros se presenta la página de autenticacion
            if (string.IsNullOrEmpty(paramUsr) || string.IsNullOrEmpty(paramTkn))
            {
                //Si el flujo del control llega aqui quiere decir que se debe redireccionar al usuario a la página de accede
                //   Response.Redirect(Helper.NoboxLogin, true);
            }
            
            //De lo contrario se valida el token
            if (UsuariosController.ValidateUserToken(paramUsr, paramTkn, 30))
            {
                FormsAuthentication.SetAuthCookie(paramUsr, false);
               
                var paramUrl = Request.Params["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(paramUrl))
                {
                    Response.Redirect(paramUrl);
                }
               
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
                    if (Uri.TryCreate(failUrl, UriKind.RelativeOrAbsolute, out uri))
                    {
                        Response.Redirect(failUrl);
                    }
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginUser_LoginError(object, EventArgs)'
        protected void LoginUser_LoginError(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginUser_LoginError(object, EventArgs)'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginUser_LoggingIn(object, LoginCancelEventArgs)'
        protected void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginUser_LoggingIn(object, LoginCancelEventArgs)'
        {
            var txtUser = ((TextBox)LoginUser.FindControl("UserName"));
            var txtPass = ((TextBox)LoginUser.FindControl("Password"));
            var stopAuth = false;
            //txtUser.Text.ToLower();

            if (txtUser.Text.Length == 0)
            {
                txtUser.CssClass = "form-control validationMark";
                stopAuth = true;
            }

            if (txtPass.Text.Length == 0)
            {
                txtPass.CssClass = "form-control validationMark";
                stopAuth = true;
            }

            e.Cancel = stopAuth;

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginUser_LoggedIn(object, EventArgs)'
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginUser_LoggedIn(object, EventArgs)'
        {
            var txtUser = ((TextBox)this.LoginUser.FindControl("UserName"));
            txtUser.Text = txtUser.Text.ToLower();
            var user = txtUser.Text;
            //log user activity
            MembershipHelper.LogUserActivity("Acceso a portal autorizado.", user);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si existe el usuario
            var uc = new UsuariosController();

            var userName = this.LoginUser.UserName.Trim().ToLower();
            if (uc.ExisteUsuario(userName))
                args.IsValid = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginButton_Click(object, EventArgs)'
        protected void LoginButton_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.LoginButton_Click(object, EventArgs)'
        {
            var txtUser = ((TextBox)this.LoginUser.FindControl("UserName"));
            txtUser.Text = txtUser.Text.ToLower();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Login2.lblForgot_Click(object, EventArgs)'
        protected void lblForgot_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Login2.lblForgot_Click(object, EventArgs)'
        {            
            
            Session["OlvidePassword"] = true;          

            Response.Redirect("~/Account/ForgotPassword.aspx");
        }
    }
}