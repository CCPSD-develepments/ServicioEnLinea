using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página en la que un usuario firma el contrato/acuerdo de uso para operaciones
    /// del registro mercantil 
    ///</summary>
    public partial class Firma_Contrato : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Firma_Contrato.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Firma_Contrato.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;



            //Se revisa si el usuario ya ha firmado su contrato
            var usr = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);

            if (Request?.QueryString["TipoContrato"] != "AccesoEmpresa")
            {
                if (usr.ContratoFirmado.GetValueOrDefault())
                    Response.Redirect("/Empresas/Oficina.aspx");
            }


            //Revision de usuario padre o hijo
            if (usr.IsGestorAdmin())
            {
                Master.NombreActividad = "Firma de Contrato Registro Mercantil";
                
                this.litTituloContrato.Text = "Aceptación de Acuerdo - Uso del Registro Mercantil en Línea";
                this.lnkImpresion.NavigateUrl = "/ContratoOfv.htm";
                this.hfUsuarioHijo.Value = "0";
            }
            else
            {
                Master.NombreActividad = "Aceptación de términos de uso (usuario hijo)";
             
                this.litTituloContrato.Text = "Términos de uso de la Cámara de Santo Domingo en la Red";
                this.lnkImpresion.NavigateUrl = "/TerminosUso.htm";
                this.hfUsuarioHijo.Value = "1";
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Firma_Contrato.btnAceptarContrato_Click(object, EventArgs)'
        protected void btnAceptarContrato_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Firma_Contrato.btnAceptarContrato_Click(object, EventArgs)'
        {      
            if(!User.Identity.IsAuthenticated)
            {
                Master.ShowMessageError("Error de autenticación con el usuario actual");
                return;
            }

            if (!this.chkAceptacion.Checked)
            {
                Master.ShowMessageError("Debe aceptar los términos de uso del portal para continuar");
                return;
            }

            if (Request?.QueryString["TipoContrato"] == "AccesoEmpresa")
            {
                Response.Redirect("/Empresas/SolicitudInclusion.aspx?firma=si");
            }
            else
            {
                var usr = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);
                usr.ContratoFirmado = true;
                usr.IpFirma = Request.UserHostAddress;
                usr.Save();
                Response.Redirect("/Empresas/Oficina.aspx");
            }
        }
    }
}