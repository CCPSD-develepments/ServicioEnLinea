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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2'
    public partial class ConsultaRM2 : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2.Page_Load(object, EventArgs)'
        {
            var ctrl = new Comun.CamarasController();
            this.ddlCamara.BindCollection(ctrl.FetchAllActivas(), Comun.Camaras.PropColumns.ID, 
                Comun.Camaras.PropColumns.Nombre, Helper.IdCamaraPrincipal);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2.btnConsultar_Click(object, EventArgs)'
        protected void btnConsultar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2.btnConsultar_Click(object, EventArgs)'
        {
            //Se validan que las entradas estén correctas
            Guid numValidacion;
            Int32 numRegistro;
            Int16 TipoRegistro;
            var isValid = true;

            if (!Guid.TryParse(this.txtNumeroValidacion.Text, out numValidacion))
            {
                this.GenerateCustomError("El número de validación ingresado es incorrecto. Revise el texto e intente de nuevo");
                isValid = false;
            }
            if (!Int16.TryParse(this.ddlTipoRegistro.SelectedValue, out TipoRegistro))
            {
                this.GenerateCustomError("Debe seleccionar un tipo de registro a validar");
                isValid = false;
            }
            if (!Int32.TryParse(this.txtNumeroRegistro.Text, out numRegistro))
            {
                this.GenerateCustomError("El número de registro ingresado es incorrecto. Revise el texto e intente de nuevo");
                isValid = false;
            }
            
            this.pnlResultados.Visible = isValid;
            if (!isValid) return;

            var ctrl = new SRM.RegistroController();
            var infoRegistro = ctrl.CheckRegistroEsValido(this.ddlCamara.SelectedValue, numRegistro, numValidacion, TipoRegistro);

            if (infoRegistro == null)
            {
                Master.ShowMessageError("No se encontró información para este registro. Revise los datos e intente nuevamente.");
                return;
            }

            this.litRazonSocial.Text = infoRegistro.RazonSocial;
            this.litTipoSociedad.Text = infoRegistro.TipoSociedad;
            this.litFechaVencimiento.Text = infoRegistro.UltimoRegistro
                                                ? infoRegistro.FechaVencimiento.GetValueOrDefault().ToStringDom()
                                                : "-";
            this.litEstado.Text = (DateTime.Now <= infoRegistro.FechaVencimiento)
                                        ? "<span style='color:green'>  REGISTRO MERCANTIL AL DIA </span>"
                                        : "<span style='color:red;'>  REGISTRO MERCANTIL VENCIDO </span>";
            this.litEstadoRm.Text = infoRegistro.UltimoRegistro
                                        ? "<span style='color:green'> LA INFORMACIÓN INGRESADA PERTENECE AL ÚLTIMO REGISTRO EMITIDO SEGÚN LOS ARCHIVOS DE LA CÁMARA DE COMERCIO </span>"
                                        : "<span style='color:red;'> LA INFORMACIÓN INGRESADA NO PERTENECE AL ÚLTIMO REGISTRO EMITIDO POR LA CÁMARA DE COMERCIO </span>";
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2.btnVerCertificado_Click(object, EventArgs)'
        protected void btnVerCertificado_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaRM2.btnVerCertificado_Click(object, EventArgs)'
        {
            //Se validan que las entradas estén correctas
            Int32 numRegistro;
            Int16 TipoRegistro;
            var isValid = true;

            if (!Int16.TryParse(this.ddlTipoRegistro.SelectedValue, out TipoRegistro))
            {
                this.GenerateCustomError("Debe seleccionar un tipo de registro a validar");
                isValid = false;
            }
            if (!Int32.TryParse(this.txtNumeroRegistro.Text, out numRegistro))
            {
                this.GenerateCustomError("El número de registro ingresado es incorrecto. Revise el texto e intente de nuevo");
                isValid = false;
            }

            this.pnlResultados.Visible = isValid;
            if (!isValid) return;
            Session["numRegistro"] = numRegistro;
            Session["TipoRegistro"] = TipoRegistro;
            string url = "ReportesVisor.aspx#toolbar=0&navpanes=0";
            //string htmlTag = "window.open('" + url + "', '', 'width=auto,height=auto,left=100,top=100,resizable=yes');";
            Response.Write("<script>window.open('" + url + "','_blank');</script>");
            //ClientScript.RegisterStartupScript(this.Page.GetType(), "", htmlTag, true);
        }

    }
}