using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapPagado'
    public partial class ModAumentoCapPagado : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapPagado'
    {
        /// <summary>
        /// Clase que sera convertida en XML para ser enviada a SRM.
        /// </summary>
        private class ModificacionCapitalPagado : EntitySerializer<ModAumentoCapPagado>
        {
            [ControlName(NombreControl = "ltCapitalPagado", id = "ltCapitalPagado", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal CapitalPagado
            {
                get
                {
                    string capitalPagadoStr = instance.ltCapitalPagado.Text;
                    decimal capitalPagado;
                    Decimal.TryParse(capitalPagadoStr, out capitalPagado);
                    return capitalPagado;
                }
            }

            [ControlName(NombreControl = "txtCapPagado", id = "txtCapPagado", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal NuevoCapitalPagado
            {
                get
                {
                    return instance.txtCapPagado.DecimalValue();
                }
            }

#pragma warning disable CS0114 // 'ModAumentoCapPagado.ModificacionCapitalPagado.GetXML()' hides inherited member 'EntitySerializer<ModAumentoCapPagado>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            public string GetXML()
#pragma warning restore CS0114 // 'ModAumentoCapPagado.ModificacionCapitalPagado.GetXML()' hides inherited member 'EntitySerializer<ModAumentoCapPagado>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            {
                return Serializer<ModificacionCapitalPagado>.Serialize(this);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapPagado.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapPagado.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            
            //Acceso a datos
            var dbWebsite = new CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            //Datos de Sociedad
            InitializeSociedad();

            //Si es la primera vez que se llama este formulario, se cargan valores existentes
            if (!IsFormularionConfirmacion)
                InitializeSessionData();

            //Inicialización de pantalla
            ltCapitalPagado.Text = String.Format("{0:n}", this.SociedadRegistro.Registros.CapitalPagado ?? 0m);
            ltNombreSocial.Text = this.SociedadRegistro.Sociedades.NombreSocial;
            ltNombreSocialTitulo.Text = this.SociedadRegistro.Sociedades.NombreSocial;
            txtCapPagado.MinValue = Convert.ToDouble(this.SociedadRegistro.Registros.CapitalPagado);

            //Nombre del capital social según el tipo de empresa
            var nombreCapSocial = "Capital Social";
            var propCapitalSocial = dbWebsite.PropiedadesPorSociedad
                                .Where(p => p.TipoSociedadID == this.TipoSociedadId && p.PropiedadesUI.Nombre == "CapitalSocial")
                                .FirstOrDefault();
            if (propCapitalSocial != null)
                nombreCapSocial = propCapitalSocial.Descripcion;

            //Capital social mínimo para este tipo de empresa
            this.rvCapitalSocialNuevo.MinimumValue = "0.0";
            rvCapitalSocialNuevo.ErrorMessage = "El capital suscrito mínimo requerido para este tipo de sociedad es " +
                                                String.Format("{0}", rvCapitalSocialNuevo.MinimumValue);
            if (Helper.TipoSociedadPorcSuscrito.Contains(this.TipoSociedadId))
            {
                this.litCapPagadoComment.Visible = true;
                rvCapitalSocialNuevo.MinimumValue = String.Format("{0:n}", (this.RegistroNuevo.CapitalSocial *
                                                    Helper.PorcentajeCapitalPagado / 100));
                
                this.rvCapitalSocialNuevo.ErrorMessage = String.Format("El capital suscrito mínimo requerido para este " +
                    "tipo de sociedad es {0} ({1}% del {2})", rvCapitalSocialNuevo.MinimumValue, Helper.PorcentajeCapitalPagado, nombreCapSocial);
            }

            //Validación del capital pagado con respecto al social
            var capSocialVal = 0m;
            if (this.RegistroNuevo != null && this.RegistroNuevo.CapitalSocial > 0)
            {
                capSocialVal = this.RegistroNuevo.CapitalSocial > this.SociedadRegistro.Registros.CapitalSocial
                                   ? this.RegistroNuevo.CapitalSocial.Value2()
                                   : this.SociedadRegistro.Registros.CapitalSocial.Value2();
            }
            else
            {
                capSocialVal = this.SociedadRegistro.Registros.CapitalSocial.Value2();
            }
            rvCapitalSocialComp.MaximumValue = String.Format("{0:n}", capSocialVal);
            rvCapitalSocialComp.ErrorMessage = String.Format("El nuevo valor debe ser menor que el {0} de {1}",
                                                nombreCapSocial, rvCapitalSocialComp.MaximumValue);

            //Asignando el Capital Social Anterior
            this.CapitalSocialOriginal = this.SociedadRegistro.Registros.CapitalSocial.GetValueOrDefault();

            //Header
            var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId);
            if (tipoSociedad != null)
                ltTipoSociedadTitulo.Text = tipoSociedad.Etiqueta;

            //Títulos - Nombre del capital suscrito
            var propiedad = dbWebsite.PropiedadesPorSociedad.FirstOrDefault(
                    p => p.PropiedadesUI.Nombre == "CapitalSuscrito" && p.TipoSociedadID == this.TipoSociedadId);
            if (propiedad != null && !String.IsNullOrEmpty(propiedad.Descripcion))
            {
                this.lblCapitalSuscritoNombre.Text = propiedad.Descripcion;
                this.lblCapitalSuscritoNuevoNombre.Text = propiedad.Descripcion;
            }

            if (IsFormularionConfirmacion)
                InitInterface();

            VerificarRevisionDatos();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapPagado.btnEnviarModificacion_Click(object, EventArgs)'
        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapPagado.btnEnviarModificacion_Click(object, EventArgs)'
        {
            if (IsValid())
            {
                //Creo Instancia para Generar XML
                var instance = new ModificacionCapitalPagado();
#pragma warning disable CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'
                this.InstanceXML = instance.GetXML();
#pragma warning restore CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'

                //Especifico Tipo Servicio
                int servicioId = 0;
                int.TryParse(this.Request.QueryString["CurrentServicioId"], out servicioId);
                if (servicioId <= 0)
                {
                    ErrorMessage = "Servicio Invalido.";
                    Response.Redirect("SolicitudOperacion.aspx");
                }
                this.ServicioId = servicioId;
                
                //Capital
                Decimal capital;
                if (Decimal.TryParse(this.txtCapPagado.Text, out capital))
                    this.RegistroNuevo.CapitalPagado = capital;

                //Guardar transaccion
                GuardarObjetoModificacion();
                this.RegistroCargado = true;

                if (!String.IsNullOrWhiteSpace(ErrorMessage))
                {
                    Master.ShowMessageError(ErrorMessage);
                    ErrorMessage = String.Empty;
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

        private void InitInterface()
        {
            this.txtCapPagado.Text = this.RegistroNuevo.CapitalPagado.GetValueOrDefault().ToString();
        }

        /// <summary>
        /// Verifica si se accedio al formulario por revisión de datos
        /// </summary>
        private void VerificarRevisionDatos()
        {
            if (String.IsNullOrEmpty(Request.QueryString["revisionDatos"]))
            {
                this.txtCapPagado.Text = String.Empty;
            }
        }

#pragma warning disable CS0108 // 'ModAumentoCapPagado.IsValid()' hides inherited member 'Page.IsValid'. Use the new keyword if hiding was intended.
        private bool IsValid()
#pragma warning restore CS0108 // 'ModAumentoCapPagado.IsValid()' hides inherited member 'Page.IsValid'. Use the new keyword if hiding was intended.
        {
            var instance = new ModificacionCapitalPagado();
            if (instance.NuevoCapitalPagado < instance.CapitalPagado)
            {
                ErrorMessage = "El monto de capital pagado debe ser superior al actual.";
                return false;
            }

            return true;
        }
    }
}