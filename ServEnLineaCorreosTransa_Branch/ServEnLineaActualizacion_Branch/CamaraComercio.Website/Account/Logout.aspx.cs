using System;
using System.Web.Security;

namespace CamaraComercio.Website
{
    ///<summary>
    /// Página que permite hacer logout de la aplicación
    ///</summary>
    public partial class Logout : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Logout.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Logout.Page_Load(object, EventArgs)'
        {   
            MembershipHelper.LogUserActivity("Usuario sacado de sesion por inactividad", null);
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect(Helper.NoboxLogout);
        }
    }
}