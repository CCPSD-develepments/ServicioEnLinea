using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oficina = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.CamaraComun;
using System.Text;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
    interface IRegisterTransaccion
    {
        void GuardarModificacion();

    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Modificacion'
    public partial class Modificacion : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Modificacion'
    {
        private System.Web.UI.UserControl[] m_dynamicUserControls;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Modificacion.OnInit(EventArgs)'
        protected override void OnInit(EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Modificacion.OnInit(EventArgs)'
        {
            base.OnInit(e);
            
            var rep = odsModificaciones.Select();
            var result = rep as List<Oficina.ServicioDetalles>;
            m_dynamicUserControls = new System.Web.UI.UserControl[result.Count];
            int i = 0;
            foreach (var item in result)
            {
                var control = (UserControl)Page.LoadControl(item.Url);
                control.ID = "ucGenerated" + i.ToString();
                m_dynamicUserControls[i++] = control;
                plModificacion.Controls.Add(control);

            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Modificacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Modificacion.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
                //Busco Datos de Sociedad
                InitializeSociedad();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Modificacion.btnEnviarModificacion_Click(object, EventArgs)'
        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Modificacion.btnEnviarModificacion_Click(object, EventArgs)'
        {

            //Ejecuto el Metodo LoadXmlFromUserControls que permite llamar todas las transacciones
            LoadXmlFromUserControls();

            //Envia Transacciones a grabar
            SubmitChanges();

            //Envio para revision de documentos.
            Response.Redirect("~/Empresas/RevisionDocumentos.aspx");

        }

        private void LoadXmlFromUserControls()
        {
            foreach (var item in m_dynamicUserControls)
            {
                var control = item as IRegisterTransaccion;
                control.GuardarModificacion();
            }
        }
    }
}