using System;
using System.Globalization;
using System.Linq;
using CamaraComercio.Website.Operaciones.Modificaciones;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using CamaraComun = CamaraComercio.DataAccess.EF.CamaraComun;
using EF = CamaraComercio.DataAccess.EF;
using System.Web.Security;
using System.Text;
using System.Collections.Generic;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website
{
    public partial class ActualizarUsuarioJackie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user =  OficinaVirtualUserProfile.GetUserProfile("Jacqueline");
            user.RNC = "001-1451564-6";
            user.Save();
        }
    }
}