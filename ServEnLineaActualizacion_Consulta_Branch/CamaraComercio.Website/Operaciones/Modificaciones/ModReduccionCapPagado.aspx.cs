using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModReduccionCapPagado'
    public partial class ModReduccionCapPagado : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModReduccionCapPagado'
    {
        /// <summary>
        /// Clase que sera convertida en XML para ser enviada a SRM.
        /// </summary>
        private class ModificacionReduccionCapitalPagado : EntitySerializer<ModReduccionCapPagado>
        {
            [ControlName(NombreControl = "ltCapitalPagado", id = "ltCapitalPagado", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal CapitalPagado
            {
                get
                {
                    var capitalPagadoStr = instance.ltCapitalPagado.Text;
                    decimal capitalPagado;
                    Decimal.TryParse(capitalPagadoStr, out capitalPagado);
                    return capitalPagado;
                }
            }

            [ControlName(NombreControl = "txtCapitalSocialNuevo", id = "txtCapitalSocialNuevo", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal NuevoCapitalPagado
            {
                get
                {
                    return instance.txtCapPagado.DecimalValue();
                }
            }

#pragma warning disable CS0114 // 'ModReduccionCapPagado.ModificacionReduccionCapitalPagado.GetXML()' hides inherited member 'EntitySerializer<ModReduccionCapPagado>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            public string GetXML()
#pragma warning restore CS0114 // 'ModReduccionCapPagado.ModificacionReduccionCapitalPagado.GetXML()' hides inherited member 'EntitySerializer<ModReduccionCapPagado>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            {
                return Serializer<ModificacionReduccionCapitalPagado>.Serialize(this);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModReduccionCapPagado.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModReduccionCapPagado.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            
            //Acceso a datos
            var dbComun = new CamaraComunEntities();
            var dbWebsite = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();

            //Se buscan los datos de Sociedad
            InitializeSociedad();

            //Si es la primera vez que se llama este formulario, se cargan valores existentes
            if (!IsFormularionConfirmacion)
                InitializeSessionData();


            ltCapitalPagado.Text = String.Format("{0:n}", this.SociedadRegistro.Registros.CapitalPagado ?? 0m);
            ltNombreSocial.Text = this.SociedadRegistro.Sociedades.NombreSocial;
            ltNombreSocialTitulo.Text = this.SociedadRegistro.Sociedades.NombreSocial;
            txtCapPagado.MaxValue = Convert.ToDouble(this.SociedadRegistro.Registros.CapitalPagado);

            //Nombre del capital social según el tipo de empresa
            var nombreCapSocial = "Capital Social";
            var propCapitalSocial = dbWebsite.PropiedadesPorSociedad
                                .Where(p => p.TipoSociedadID == this.TipoSociedadId && p.PropiedadesUI.Nombre == "CapitalSocial")
                                .FirstOrDefault();
            if (propCapitalSocial != null)
                nombreCapSocial = propCapitalSocial.Descripcion;

            //Capital social mínimo para este tipo de empresa
            this.rvCapitalSocialNuevo.MinimumValue = "0.0";
            if (Helper.TipoSociedadPorcSuscrito.Contains(this.TipoSociedadId))
            {
                this.litCapPagadoComment.Visible = true;
                this.rvCapitalSocialNuevo.MinimumValue = String.Format("{0:n}", (this.RegistroNuevo.CapitalSocial *
                                                                                 Helper.PorcentajeCapitalPagado / 100));

                this.rvCapitalSocialNuevo.ErrorMessage = String.Format("El capital suscrito mínimo requerido para este " + 
                    "tipo de sociedad es {0} ({1}% del {2})", rvCapitalSocialNuevo.MinimumValue, Helper.PorcentajeCapitalPagado, nombreCapSocial);
            }
            else
            {
                this.rvCapitalSocialNuevo.ErrorMessage = "El capital suscrito mínimo requerido para este tipo de sociedad es "
                                                        + String.Format("{0}", rvCapitalSocialNuevo.MinimumValue);   
            }

            //Capital Autorizado no debe ser mayor que el actual
            rvCapitalSocialAnterior.MaximumValue = String.Format("{0:n}", this.SociedadRegistro.Registros.CapitalPagado + 1);
            rvCapitalSocialAnterior.ErrorMessage = "El nuevo valor debe ser menor que el capital pagado actual de "
                                                   + String.Format("{0}", rvCapitalSocialAnterior.MaximumValue);

            //Capital Autorizado no debe ser mayor que el capital social (aunque se haya cambiado ahora mismo)
            rvCapitalSocialComp.MaximumValue = String.Format("{0:n}", this.RegistroNuevo.CapitalSocial);
            rvCapitalSocialComp.ErrorMessage = String.Format("El nuevo valor debe ser menor que el {0} de {1}", 
                                                nombreCapSocial, rvCapitalSocialComp.MaximumValue);

            if (IsFormularionConfirmacion)
                InitInterface();

            if (this.TipoSociedadId > 0)
            {
                //Títulos - Tipo de sociedad
                var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId);
                if (tipoSociedad != null)
                    ltTipoSociedadTitulo.Text = tipoSociedad.Etiqueta;

                //Títulos - Nombre del capital suscrito
                var propiedad =
                    dbWebsite.PropiedadesPorSociedad.FirstOrDefault(
                        p => p.PropiedadesUI.Nombre == "CapitalSuscrito" && p.TipoSociedadID == this.TipoSociedadId);
                if (propiedad != null && !String.IsNullOrEmpty(propiedad.Descripcion))
                {
                    this.lblCapitalSuscritoNombre.Text = propiedad.Descripcion;
                    this.lblCapitalSuscritoNuevoNombre.Text = propiedad.Descripcion;
                }
            }
        }


        private void InitInterface()
        {
            this.txtCapPagado.Text = this.RegistroNuevo.CapitalPagado.GetValueOrDefault().ToString();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModReduccionCapPagado.btnEnviarModificacion_Click(object, EventArgs)'
        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModReduccionCapPagado.btnEnviarModificacion_Click(object, EventArgs)'
        {
            if (IsValido())
            {
                //Especifico Tipo Servicio
                var servicioId = 0;
                Int32.TryParse(this.Request.QueryString["CurrentServicioId"], out servicioId);

                if (servicioId <= 0)
                {
                    ErrorMessage = "Servicio Invalido.";
                    Response.Redirect("SolicitudOperacion.aspx");
                }
                this.ServicioId = servicioId;
                
                //Nuevo capital
                Decimal capital;
                if (Decimal.TryParse(this.txtCapPagado.Text, out capital))
                    this.RegistroNuevo.CapitalPagado = capital;

                //Guardar transaccion
                GuardarObjetoModificacion();
                this.RegistroCargado = true;

                if (!String.IsNullOrWhiteSpace(ErrorMessage))
                {
                    Master.ShowMessageError(ErrorMessage);
                    return;
                }

                //Envio a pagina siguiente. 
                GoNextPage();
                SubmitChanges();

                //Envio a pantalla de confirmacion
                if (Redirect)
                    Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
            }
        }

        private bool IsValido()
        {
            var instance = new ModificacionReduccionCapitalPagado();
            if (instance.NuevoCapitalPagado > instance.CapitalPagado)
            {
                ErrorMessage = "El monto del capital pagado debe ser inferior al capital pagado actual.";
                Master.ShowMessageError(ErrorMessage);
                return false;
            }

            return true;
        }
    }
}