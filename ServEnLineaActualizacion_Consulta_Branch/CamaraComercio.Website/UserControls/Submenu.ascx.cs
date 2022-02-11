using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.UserControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Submenu'
    public partial class Submenu : System.Web.UI.UserControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Submenu'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Submenu.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Submenu.Page_Load(object, EventArgs)'
        {
            if (Page.IsPostBack) return;

            var username = HttpContext.Current.User.Identity.Name.ToLower();
            var usuario = (OficinaVirtualUserProfile)ProfileBase.Create(username);
            //Si es im gestor administrador
            if (usuario.IsGestorAdmin())
            {
                this.litAdminGestores.Text = "<li><a href='/Account/UsersAdmin.aspx'>Administración Gestores</a></li>";
            }
        }
    }
}