using System;
using System.Linq;
using CamaraComercio.DataAccess.EF.CamaraComun;
using ComunEF = CamaraComercio.DataAccess.EF.CamaraComun;
using Oficina = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapital'
    public partial class ModAumentoCapital : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapital'
    {
        /// <summary>
        /// Clase que sera convertida en XML para ser enviada a SRM.
        /// </summary>
        private class ModificacionAumentoCapital : EntitySerializer<ModAumentoCapital>
        {
#pragma warning disable CS0114 // 'ModAumentoCapital.ModificacionAumentoCapital.GetXML()' hides inherited member 'EntitySerializer<ModAumentoCapital>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            /// <summary>
            /// Objeto de serialización
            /// </summary>
            /// <returns></returns>
            public string GetXML()
#pragma warning restore CS0114 // 'ModAumentoCapital.ModificacionAumentoCapital.GetXML()' hides inherited member 'EntitySerializer<ModAumentoCapital>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            {
                return Serializer<ModificacionAumentoCapital>.Serialize(this);
            }

            #region Propiedades Decorator Pattern
            [ControlName(NombreControl = "ltCapAutorizado", id = "ltCapAutorizado", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal CapitalAutorizado
            {
                get
                {
                    var capitalAutorizadoStr = instance.ltCapAutorizado.Text;
                    decimal capitalAutorizado;
                    Decimal.TryParse(capitalAutorizadoStr, out capitalAutorizado);
                    return capitalAutorizado;
                }
            }

            [ControlName(NombreControl = "txtCapitalSocialNuevo", id = "txtCapitalSocialNuevo", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal NuevoCapitalAutorizado
            {
                get { return instance.txtCapitalSocialNuevo.DecimalValue(); }
            }

            [ControlName(NombreControl = "radFechaRecibo", id = "radFechaRecibo", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public DateTime? FechaRecibo
            {
                get { return instance.radFechaRecibo.SelectedDate; }
            }

            [ControlName(NombreControl = "txtMontoDGII", id = "txtMontoDGII", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal MontoRecibo
            {
                get { return instance.txtMontoDGII.DecimalValue(); }
            }

            [ControlName(NombreControl = "txtNoRecibo", id = "txtNoRecibo", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String NumeroRecibo
            {
                get { return instance.txtNoRecibo.Text; }
            }
            #endregion
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapital.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapital.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            //Busco Datos de Sociedad
            InitializeSociedad();

            //Si es la primera vez que se llama este formulario, se cargan valores existentes
            if (!IsFormularionConfirmacion)
                InitializeSessionData();
            else
                InitInterface();
               
            //Datos de validación
            var dbComun = new CamaraComunEntities();
            var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId);
            if (tipoSociedad != null)
            {
                var capMinimo = tipoSociedad.CapitalAutorizado;
                rvCapitalSocialNuevo.MinimumValue = capMinimo.ToString();
                txtCapitalSocialNuevo.MinValue = (Double) capMinimo;
                ltTipoSociedadTitulo.Text = tipoSociedad.Etiqueta;
            }

            //Limites para el nuevo capital autorizado
            var capitalAutorizado = String.Format("{0:n}", this.SociedadRegistro.Registros.CapitalAutorizado ?? 0m);
            ltCapAutorizado.Text = capitalAutorizado;
            rvCapitalSocialAnterior.MinimumValue = capitalAutorizado;

            //Asignando el Capital Social Anterior
            this.CapitalSocialOriginal = this.SociedadRegistro.Registros.CapitalAutorizado.GetValueOrDefault();

            //Títulos - Empresa actual
            ltNombreSocial.Text = this.SociedadRegistro.Sociedades.NombreSocial;
            ltNombreSocialTitulo.Text = this.SociedadRegistro.Sociedades.NombreSocial;

            //Títulos - Nombre del capital social
            var dbWebsite = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
            var propiedad =
                dbWebsite.PropiedadesPorSociedad.FirstOrDefault(
                    p => p.PropiedadesUI.Nombre == "CapitalSocial" && p.TipoSociedadID == this.TipoSociedadId);
            if (propiedad != null && !String.IsNullOrEmpty(propiedad.Descripcion))
            {
                this.lblNombreCapitalSocial.Text = propiedad.Descripcion;
                this.lbltxtCapitalSocialNuevo.Text = propiedad.Descripcion;
            }

            //Limite de fecha para el recibo de la DGII)
            this.radFechaRecibo.MaxDate = DateTime.Today;

            //Restricciones para controles
            this.PropiedadesSociedadActual = new Oficina.PropiedadesPorSociedadRepository().GetPropiedadesByTipo(TipoSociedadId);
            RenderizarControles(this.Form.Controls);

            //Revisión de objetos en sesión, para limpiar campos si es necesario
            VerificarRevisionDatos();
        }

        /// <summary>
        /// Verifica si se accedio al formulario por revisión de datos
        /// </summary>
        private void VerificarRevisionDatos()
        {
            if (String.IsNullOrEmpty(Request.QueryString["revisionDatos"]))
            {
                this.txtCapitalSocialNuevo.Text = String.Empty;
                this.txtMontoDGII.Text = String.Empty;
                this.txtNoRecibo.Text = String.Empty;
                this.radFechaRecibo.SelectedDate = null;
            }
        }

        private void InitInterface()
        {
            radFechaRecibo.SelectedDate = this.ReciboDGII.FechaReciboDGII;
            txtNoRecibo.Text = this.ReciboDGII.NoReciboDGII;
            if (this.ReciboDGII.MontoDGII.HasValue)
                txtMontoDGII.Text = this.ReciboDGII.MontoDGII.GetValueOrDefault().ToString();

            if (this.RegistroNuevo.CapitalSocial > 0)
                this.txtCapitalSocialNuevo.Text = this.RegistroNuevo.CapitalSocial.ToString();
            
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapital.btnEnviarModificacion_Click(object, EventArgs)'
        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModAumentoCapital.btnEnviarModificacion_Click(object, EventArgs)'
        {
            //Instancia para Generar XML
            var instance = new ModificacionAumentoCapital();
#pragma warning disable CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'
            this.InstanceXML = instance.GetXML();
#pragma warning restore CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'

            
            this.RegistroNuevo.CapitalSocial = instance.NuevoCapitalAutorizado; ;
            if (this.RegistroNuevo.CapitalSocial > this.CapitalSocialOriginal)
            {
                this.ReciboDGII.FechaReciboDGII = radFechaRecibo.SelectedDate;
                this.ReciboDGII.NoReciboDGII = txtNoRecibo.Text;
                this.ReciboDGII.MontoDGII = txtMontoDGII.DecimalValue();
            }
            else
                this.ReciboDgii = new Website.ReciboDGII();

            //Especifico Tipo Servicio
            int servicioId = 0;
            int.TryParse(this.Request.QueryString["CurrentServicioId"], out servicioId);

            if (servicioId <= 0)
            {
                ErrorMessage = "Servicio Invalido.";
                Response.Redirect("SolicitudOperacion.aspx");
            }
            this.ServicioId = servicioId;
            
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
}