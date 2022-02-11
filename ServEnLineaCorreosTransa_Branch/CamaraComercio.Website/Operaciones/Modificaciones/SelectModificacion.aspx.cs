using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SelectModificacion'
    public partial class SelectModificacion : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SelectModificacion'
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SelectModificacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SelectModificacion.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                InitializeSociedad();

                hfTipoSociedadId.Value = this.SociedadRegistro.Sociedades.TipoSociedadId.Value.ToString();
                hfTipoServicioId.Value = Request.QueryString["TipoServicioId"];
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SelectModificacion.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SelectModificacion.btnContinuar_Click(object, EventArgs)'
        {
            LoadModificacionesSeleccionadas();
            Response.Redirect("Modificacion.aspx");


        }

        private void LoadModificacionesSeleccionadas()
        {
            foreach (GridDataItem item in from GridDataItem item in gridModificaciones.MasterTableView.Items
                                          let chkSelccionado = item.FindControl("chkServicio") as CheckBox
                                          where chkSelccionado.Checked
                                          select item)
                this.ServiciosSeleccionados.Add(
                    (int) gridModificaciones.MasterTableView.DataKeyValues[item.ItemIndex]["ServicioId"]);
        }
    }
}