using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;
using System;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Consultas
{
    ///<summary>
    /// Página para ver el detalle de empresa en las consultas
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class VerDetalleEmpresa : System.Web.UI.Page
    {
        #region Private fields and Properties

        /// <summary>
        /// Llave Primaria de la Sociedad.  
        /// </summary>
        public int SociedadId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["sociedadId"])
                           ? int.Parse(Request.QueryString["sociedadId"])
                           : 0;
            }
        }

        /// <summary>
        /// Llave primaria del numero de registro mecartil de la empresa.
        /// </summary>
        public int RegistroId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["registroId"])
                           ? int.Parse(Request.QueryString["registroId"])
                           : 0;
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.PersonaId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["personaId"])
                           ? int.Parse(Request.QueryString["personaId"])
                           : 0;
            }

        }


        /// <summary>
        /// Camara que realizara la transaccion.
        /// </summary>
        public String CamaraId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"])
                           ? Request.QueryString["CamaraId"]
                           : String.Empty;
            }
        }

        private cvw_SociedadesRegistros SociedadRegistro;
        private PersonasRegistros PersonaRegistro;

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            if (this.RegistroId > 0 && this.CamaraId.Length > 0 && this.SociedadId > 0)
            {
                InitInterface();
                
                const string urlBase = "/Operaciones/Shared/Certificaciones.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}";
                const string urlCopiasCert = "/Operaciones/Shared/CopiasCert.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}";
             //   const string urlActualizarDatosGenerales = "/Empresas/ActualizarDatosGenerales.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}";
                
                this.lnkCertificacion.NavigateUrl = String.Format(urlBase, this.SociedadId, this.RegistroId, this.CamaraId, this.SociedadRegistro.TipoSociedadId, Helper.ServicioCertificacionId);
                this.lnkCopiasRegistradas.NavigateUrl = String.Format(urlCopiasCert, this.SociedadId, this.RegistroId, this.CamaraId, this.SociedadRegistro.TipoSociedadId, Helper.ServicioCopiasCertificadasId);
             //   this.lnkActualizarDatosGenerales.NavigateUrl = String.Format(urlActualizarDatosGenerales, this.SociedadId, this.RegistroId, this.CamaraId);
            }
            else if(this.RegistroId > 0 && this.CamaraId.Length > 0 && this.PersonaId > 0)
            {
                InitInterface();
                const string urlBase = "/Operaciones/Shared/Certificaciones.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&PersonaId={5}";
                const string urlCopiasCert = "/Operaciones/Shared/CopiasCert.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&PersonaId={5}";
                //   const string urlActualizarDatosGenerales = "/Empresas/ActualizarDatosGenerales.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}";

                this.lnkCertificacion.NavigateUrl = String.Format(urlBase, 0, this.RegistroId, this.CamaraId, 7, Helper.ServicioCertificacionId,this.PersonaId);
                this.lnkCopiasRegistradas.NavigateUrl = String.Format(urlCopiasCert, 0, this.RegistroId, this.CamaraId, 7, Helper.ServicioCopiasCertificadasId,this.PersonaId);
                //   this.lnkActualizarDatosGenerales.NavigateUrl = String.Format(urlActualizarDatosGenerales, this.SociedadId, this.RegistroId, this.CamaraId);
            }
            else
            {
                //TODO: Amhed: Mensaje de error
                throw new ArgumentException("Intento de acceso a /Consultas/VerDetalleEmpresa.aspx con parametros incorrectos");
            }
        }

        /// <summary>
        /// Inicializa los valores de la interfaz.
        /// </summary>
        protected void InitInterface()
        {
            if (this.SociedadId != 0)
            {
                #region Sociedades
                var dbComun = new CamaraComunEntities();
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var sociedadescontroller = new SociedadesController();
                var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);

                #region Generales

                //litTitulo.Text = sociedadRegistro.NombreEmpresa;
                litTituloM.Text = sociedadRegistro.NombreEmpresa;
                txtDenominacion.Text = sociedadRegistro.NombreSociedad ?? sociedadRegistro.NombreEmpresa;

                if (sociedadRegistro.TipoSociedadId != null && sociedadRegistro.TipoSociedadId > 0)
                {
                    var tipoSoc = dbComun.TipoSociedad.Where(t => t.TipoSociedadId == sociedadRegistro.TipoSociedadId).FirstOrDefault();
                    //this.litTipoEmpresa.Text = !String.IsNullOrEmpty(tipoSoc.Etiqueta) ? tipoSoc.Etiqueta : String.Empty;
                }

                //Estatus


                var estatus = dbComun.EstadoRegistro.Where(a => a.EstadoRegistroId == sociedadRegistro.EstatusId).FirstOrDefault();


                txtStatus.Text = estatus != null ? estatus.Descripcion : String.Empty;


                var ctrlSociedades = new DataAccess.EF.SRM.SociedadesController();
                var sociedades = ctrlSociedades.FetchByRegistroAndCamara(sociedadRegistro.NumeroRegistro, "SDQ").FirstOrDefault();
                if (sociedades != null)
                {
                    txtStatus.Text = sociedades.Estatus_fecha;
                }



                if (sociedadRegistro.TipoSociedadId.HasValue)
                {
                    var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == sociedadRegistro.TipoSociedadId).FirstOrDefault();
                    txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;
                }

                txtRNC.Text = sociedadRegistro.Rnc.FormatRnc();

                txtFechaConstitucion.Text = sociedadRegistro.FechaConstitucion.HasValue
                                                ? sociedadRegistro.FechaConstitucion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                : String.Empty;

                txtDuracionSociedad.Text = sociedadRegistro.DuracionSociedad;
                txtDuracionConsejo.Text = sociedadRegistro.DuraccionDirectiva.HasValue
                                              ? sociedadRegistro.DuraccionDirectiva.Value + " años"
                                              : String.Empty;

                txtFechaUltActo.Text = sociedadRegistro.FechaModificacion.HasValue
                                           ? sociedadRegistro.FechaModificacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                           : String.Empty;

                txtEnteRegulado.Text = !String.IsNullOrEmpty(sociedadRegistro.TipoEnteRegulado)
                                       ? sociedadRegistro.TipoEnteRegulado
                                       : "No";

                var noResolucionExiste = !String.IsNullOrEmpty(sociedadRegistro.NoResolucion);
                txtNumeroResolucion.Text = sociedadRegistro.NoResolucion;
                txtNumeroResolucion.Visible = noResolucionExiste;
                lblNumeroResolucion.Visible = noResolucionExiste;

                var noNaveExiste = !String.IsNullOrEmpty(sociedadRegistro.NumeroNaveIndustrial);
                txtNumeroNaveInd.Text = sociedadRegistro.NumeroNaveIndustrial;
                txtNumeroNaveInd.Visible = noNaveExiste;
                lbltxtNumeroNaveInd.Visible = noNaveExiste;

                #endregion

                #region Direccion

                if (sociedadRegistro.DireccionId.HasValue)
                {
                    var repDirecciones = new Repository<ViewDirecciones, CamaraSRMEntities>(dbSrm);
                    var direccion = repDirecciones.SelectByKey(ViewDirecciones.PropColumns.DireccionId,
                                                                               sociedadRegistro.DireccionId.Value);
                }

                #endregion

                SociedadRegistro = sociedadRegistro;

                //Cantidad de Empleados
                var rangosEmpleados = RangosCantidadEmpresas.Diccionario;
                var cantEmpleados = sociedadRegistro.EmpleadosMasculinos;
                if (cantEmpleados.HasValue && cantEmpleados > 0)
                {
                    string descEmpleados;
                    rangosEmpleados.TryGetValue(cantEmpleados.Value, out descEmpleados);
                }

                #endregion
            }
            if(this.PersonaId != 0)
            {
                #region Sociedades
                var dbComun = new CamaraComunEntities();
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var personasController = new PersonaFisicaController();
                var pR = personasController.ObteneByPersonaIdCamara(this.PersonaId, CamaraId).FirstOrDefault();
                
                #region Generales
                var nombreCompleto = string.Format("{0} {1} {2} {3}", pR.Personas.PrimerNombre, pR.Personas.SegundoNombre
                , pR.Personas.PrimerApellido, pR.Personas.SegundoApellido);
                //litTitulo.Text = nombreCompleto;
                litTituloM.Text = nombreCompleto;
                txtDenominacion.Text = nombreCompleto;

                lblEstatus.Visible = false;
                txtStatus.Visible = false;

                var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == 7).FirstOrDefault();
                txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;


                txtRNC.Text = pR.Personas.Rnc != null? pR.Personas.Rnc.FormatRnc() : "";

                txtCedula.Visible = true;
                lblCedula.Visible = true;
                txtCedula.Text = pR.Personas.Documento != null ? pR.Personas.Documento : "";

                txtFechaConstitucion.Text = pR.Registros.FechaInicioOperacion.HasValue
                                                ? pR.Registros.FechaInicioOperacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                : String.Empty;

                txtDuracionSociedad.Visible = false;

                txtDuracionConsejo.Visible = false;
                lblDuracionConsejo.Visible = false;
                lblDuracionSociedad.Visible = false;

                txtFechaUltActo.Visible = false;
                lblFechaUltActo.Visible = false;

                txtEnteRegulado.Visible = false;
                lblEnteRegulado.Visible = false;

                txtNumeroResolucion.Visible = false;
                lblNumeroResolucion.Visible = false;

                txtNumeroNaveInd.Visible = false;
                lbltxtNumeroNaveInd.Visible = false;

                #endregion

                #region Direccion

                if (pR.Personas.DireccionId.HasValue)
                {
                    var repDirecciones = new Repository<ViewDirecciones, CamaraSRMEntities>(dbSrm);
                    var direccion = repDirecciones.SelectByKey(ViewDirecciones.PropColumns.DireccionId,
                                                                               pR.Personas.DireccionId.Value);
                }

                #endregion

                PersonaRegistro = pR;

                //Cantidad de Empleados
                var rangosEmpleados = RangosCantidadEmpresas.Diccionario;
                var cantEmpleados = pR.Registros.EmpleadosMasculinos;
                if (cantEmpleados.HasValue && cantEmpleados > 0)
                {
                    string descEmpleados;
                    rangosEmpleados.TryGetValue(cantEmpleados.Value, out descEmpleados);
                }

                #endregion
            }
        }

        private void InitMonedad(cvw_SociedadesRegistros sociedadRegistro)
        {
            var tipmonedaRep = new TipoMonedaRepository();
            var tiposMonedas = tipmonedaRep.SelectAll();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_PreRenderComplete(object, EventArgs)'
        protected void Page_PreRenderComplete(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_PreRenderComplete(object, EventArgs)'
        {
            if (!IsPostBack && SociedadRegistro != null)
                InitMonedad(SociedadRegistro);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.tpTipoTransacciones_OnItemCreated(object, RepeaterItemEventArgs)'
        protected void tpTipoTransacciones_OnItemCreated(object sender, RepeaterItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.tpTipoTransacciones_OnItemCreated(object, RepeaterItemEventArgs)'
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var detalle = e.Item.DataItem as OFV.TipoServicioDetalles;
            var hl = e.Item.FindControl("hlOpcion") as HyperLink;

            if (hl == null || detalle == null) return;
        }
    }
}