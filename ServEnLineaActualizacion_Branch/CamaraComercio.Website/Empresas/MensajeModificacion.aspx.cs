using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MensajeModificacion'
    public partial class MensajeModificacion : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MensajeModificacion'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MensajeModificacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MensajeModificacion.Page_Load(object, EventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MensajeModificacion.btnSeleccionar_Click(object, EventArgs)'
        protected void btnSeleccionar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MensajeModificacion.btnSeleccionar_Click(object, EventArgs)'
        {
            if (rblDeseaContinuar.Checked)
                Response.Redirect(Session["ModificacionURL"].ToString());

            else
                Response.Redirect("/Empresas/Oficina.aspx");
        }
    }
}