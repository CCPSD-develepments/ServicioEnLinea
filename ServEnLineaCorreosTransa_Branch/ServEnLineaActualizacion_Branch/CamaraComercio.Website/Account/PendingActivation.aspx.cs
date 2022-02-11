using System;

namespace CamaraComercio.Website.Account
{
    ///<summary>
    /// Página que el usuario visualiza justo después de crear un nuevo usuario.
    ///</summary>
    public partial class PendingActivation : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PendingActivation.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PendingActivation.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            Master.HideNavigation();
        }
    }
}