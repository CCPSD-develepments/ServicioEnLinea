using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website
{
    public partial class ActUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usr = OficinaVirtualUserProfile.GetUserProfile("jacqueline");
            var x = 0;
        }
    }
}