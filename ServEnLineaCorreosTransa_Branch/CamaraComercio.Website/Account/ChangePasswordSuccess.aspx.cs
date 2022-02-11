using System;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangePasswordSuccess'
    public partial class ChangePasswordSuccess : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangePasswordSuccess'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangePasswordSuccess.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangePasswordSuccess.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            Master.HideNavigation();
        }
    }
}
