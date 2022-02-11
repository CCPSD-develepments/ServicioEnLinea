using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Web.Configuration;
using System.Web.Security;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActivacionUsuario'
    public partial class ActivacionUsuario : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActivacionUsuario'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActivacionUsuario.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActivacionUsuario.Page_Load(object, EventArgs)'
        {
            //Page.IsPostback está invertido, era mucho codigo y asi se reduce el nesting
            if (Page.IsPostBack) return;

            //Se esconde navegación principal
            Master.HideNavigation();

            //Lectura de parametros y obtencion del usuario a activar
            var userID = Request.QueryString["ID"] ?? "";
            Guid gd;
            if (!Guid.TryParse(userID, out gd))
            {
                lblEstadoActivacion.Text = "Usuario no Valido.";
                return;
            }
            var currentUser = Membership.GetUser(gd);
            if (currentUser == null)
            {
                lblEstadoActivacion.Text = "Usuario no Valido.";
                return;
            }

            //Activacion
            var usuario = currentUser.UserName.ToLower();
            if (!currentUser.IsApproved)
            {
                Roles.AddUserToRole(usuario, ConfigurationManager.AppSettings["usuariosrolpordefecto"]); 
                currentUser.IsApproved = true;

                Membership.UpdateUser(currentUser);
                MembershipHelper.LogUserActivity("Nuevo usuario activado", currentUser.UserName);

                lblUsuario.Text = currentUser.UserName.ToLower();
                lblFechaCreacion.Text = currentUser.CreationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (currentUser.IsApproved)
                {
                    lblEstadoActivacion.Text = "Activo";
                    lblEstadoActivacion.ForeColor = Color.Green;
                }
                else
                {
                    lblEstadoActivacion.Text = "En espera";
                    lblEstadoActivacion.ForeColor = Color.Yellow;
                }
            }
            else
            {
                lblEstadoActivacion.Text = "Este usuario no existe en la base de datos o ya fue aprobado previamente. Por favor verificar la dirección URL utilizada.";
                lblEstadoActivacion.ForeColor = Color.Blue;
            }
        }

    }

}