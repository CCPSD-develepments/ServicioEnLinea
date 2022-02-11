using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaCERT'
    public partial class ConsultaCERT : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaCERT'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaCERT.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaCERT.Page_Load(object, EventArgs)'
        {
            var ctrl = new Comun.CamarasController();
            this.ddlCamara.BindCollection(ctrl.FetchAllActivas(), Comun.Camaras.PropColumns.ID,
                Comun.Camaras.PropColumns.Nombre, (Request["id"] == null) ? Helper.IdCamaraPrincipal : Helper.IdCamaraSecundaria);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaCERT.btnConsultar_Click(object, EventArgs)'
        protected void btnConsultar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaCERT.btnConsultar_Click(object, EventArgs)'
        {
            //Se validan que las entradas estén correctas
            Guid numValidacion;
            Int32 numCertificacion;
            var isValid = true;

            if (!Guid.TryParse(this.txtNumeroValidacion.Text, out numValidacion))
            {
                this.GenerateCustomError("El número de validación ingresado es incorrecto. Revise el texto e intente de nuevo");
                isValid = false;
            }
            if (!Int32.TryParse(this.txtNumeroCertificacion.Text, out numCertificacion))
            {
                this.GenerateCustomError("El número de certificación de registro ingresado es incorrecto. Revise el texto e intente de nuevo");
                isValid = false;
            }
            
            this.pnlResultados.Visible = isValid;
            if (!isValid) return;

            var ctrl = new SRM.Transacciones();
            var infoRegistro = ctrl.CheckCertificacionEsValida(this.ddlCamara.SelectedValue, numCertificacion, numValidacion);

            if (infoRegistro == null)
            {
                Master.ShowMessageError("No se encontró información para esta certificación de registro mercantil. Revise los datos e intente nuevamente.");
                return;
            }

            this.litRazonSocial.Text = infoRegistro.RazonSocial;
            this.litFechaEmision.Text = infoRegistro.FechaEmision.GetValueOrDefault().ToStringDom();
            this.litFechaVencimiento.Text = infoRegistro.FechaVencimiento.GetValueOrDefault().ToStringDom();
            this.litEstadoRm.Text = infoRegistro.UltimoRegistro
                                        ? "<span style='color:green'> ESTA CERTIFICACION ESTA VIGENTE </span>"
                                        : "<span style='color:red'> ESTA CERTIFICACION NO ESTA VIGENTE </span>";
        }
    }
}