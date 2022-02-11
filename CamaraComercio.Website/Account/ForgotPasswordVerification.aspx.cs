using System;
using System.Web.Security;
using CamaraComercio.DataAccess.EF.Membership;
using System.Web.Profile;

namespace CamaraComercio.Website.Account
{
    ///<summary>
    /// Página para la verificación 
    ///</summary>
    public partial class ForgotPasswordVerification : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ForgotPasswordVerification.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ForgotPasswordVerification.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            Master.HideNavigation();

           
            
            if (Request.Params["key"] != null)
            {
                //Busca el username y lo pone en el label
                Session["OlvidePassword"] = true;

                var username = UsuariosController.GetUsernameByPasswordResetKey(Request.Params["key"].ToString());
                if (username != null)
                    this.lblUsuario.Text = username;
                else
                    throw new ApplicationException("Parametros no suplidos correctamente al formulario");
            }
            else 
            {
                throw new ApplicationException("Parametros no suplidos correctamente al formulario");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ForgotPasswordVerification.btnSave_Click(object, EventArgs)'
        protected void btnSave_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ForgotPasswordVerification.btnSave_Click(object, EventArgs)'
        {
            if (! String.IsNullOrEmpty(Request.Params["key"]))
            {
                //actualiza el password al digitado.
                var user = Membership.GetUser(this.lblUsuario.Text.Trim());
                if (user != null)
                {
                    //Si el usuario esta bloqueado, entonces se debe desbloquear.
                    if (user.IsLockedOut)
                        user.UnlockUser();

                    user.ChangePassword(user.GetPassword(), this.txtPassword.Text);

                    //borrar el key generado en la base de datos.
                    var profile = (OficinaVirtualUserProfile)ProfileBase.Create(this.lblUsuario.Text.Trim());
                    profile.PasswordResetKey = string.Empty;
                    profile.Save();

                    this.multiView.SetActiveView(this.vPasswordChanged);
                }
            }
            else
            {
                throw new ApplicationException("Parametros no suplidos correctamente al formulario");
            }
        }
    }
}