using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using System.Web.Security;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member '_Default'
    public partial class _Default : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member '_Default'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member '_Default.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member '_Default.Page_Load(object, EventArgs)'
        {
            
            if (User.Identity.IsAuthenticated)
                Response.Redirect("/Empresas/Oficina.aspx", true);
            else
                Response.Redirect(Helper.NoboxLogin);
        }
    }
}
