using System;
using System.Web.Security;
using System.Web.Profile;
using CamaraComercio.DataAccess.EF.Membership;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ValidateUser'
    public partial class ValidateUser : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ValidateUser'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ValidateUser.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ValidateUser.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                Master.HideNavigation();

                if (Request.Params["key"] != null)
                {
                    //busca el username y lo pone en el label
                    var username = UsuariosController.GetUsernameByActivateUserKey(Request.Params["key"].ToString());
                    var user = Membership.GetUser(username.ToLower());
                    
                    //revisa si el usuario está aprobado
                    if (user.IsApproved)
                    {
                        this.multiView.SetActiveView(this.vAccountActivatedAlready);
                    }
                    else
                    {
                        this.lblUsuario.Text = user.UserName;
                    }
                }
                else
                {
                    throw new ApplicationException("Usuario no especificado en los parámetros del formulario");
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ValidateUser.btnSave_Click(object, EventArgs)'
        protected void btnSave_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ValidateUser.btnSave_Click(object, EventArgs)'
        {
            if (Request.Params["key"] != null)
            {
                //actualiza el password al digitado.
                var username = UsuariosController.GetUsernameByActivateUserKey(Request.Params["key"].ToString());
                var user = Membership.GetUser(username);

                user.ChangePassword(user.GetPassword(), this.txtPassword.Text);
                
                //activa el usuario
                user.IsApproved = true;

                var profile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName);
                profile.IsActive = true;
                profile.Save();
                Membership.UpdateUser(user);

                //muestra mensaje de exito
                this.multiView.SetActiveView(this.vPasswordChanged);
            }
            else
            {
                throw new ApplicationException("Usuario no especificado en los parámetros del formulario");
            }
        }
    }
}