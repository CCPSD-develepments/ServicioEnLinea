using System;
using System.Web;
using System.Web.UI;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Primera página que un usuario visita al momento de abrir una nueva cuenta
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class InicioUsuario : Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'InicioUsuario.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'InicioUsuario.Page_Load(object, EventArgs)'
        {
            //Verificacion de usuario autenticado
            if (!this.User.Identity.IsAuthenticated) return;

            //Nombre del usuario actual
            var user = HttpContext.Current.User.Identity.Name;
            var profile = OficinaVirtualUserProfile.GetUserProfile(user);
            this.lblNombreUsuario.Text = profile.NombreSolicitante;

        }
    }
}