using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Account
{
    ///<summary>
    /// Página que sirve para solicitar un cambio de contraseña
    ///</summary>
    public partial class ChangePassword : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangePassword.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangePassword.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            Master.HideNavigation();


        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangePassword.btnRegister_Click(object, EventArgs)'
        protected void btnRegister_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangePassword.btnRegister_Click(object, EventArgs)'
        {
            //Primero se valida que la contraseña actual sea la correcta
            var passActual = this.txtOldPassword.Text;
            if (!Membership.ValidateUser(User.Identity.Name, passActual))
            {
                this.GenerateCustomError("La contraseña actual no es válida", 
                    "RegisterUserValidationGroup");
                return;
            }

            //Objetos del perfil y el membership
            var profile = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);
            var user = Membership.GetUser(User.Identity.Name);
            if (user == null || profile == null)
            {
                this.GenerateCustomError("Error al intentar actualizar el usuario. Contacte a soporte",
                              "RegisterUserValidationGroup");
                return;
            }

            //Intento de cambio de contraseña
            var cambiado = user.ChangePassword(passActual, this.Password.Text);

            if (cambiado)
            {
                profile.DebeCambiarPass = false;
                profile.Save();

                Master.ShowMessageError("Contraseña cambiada exitosamente");
                Response.Redirect("/Empresas/Oficina.aspx", true);
            }
            else
            {
                this.GenerateCustomError("Error al intentar actualizar la contraseña. Contacte a soporte",
                             "RegisterUserValidationGroup");
            }
        }
    }
}
