using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.Data;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using Telerik.Web.UI;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using System.Globalization;
using CamaraComercio.Website.Helpers;
using CamaraComercio.DataAccess.EF;

namespace CamaraComercio.Website.Operaciones.Shared
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert'
    public partial class CopiasCert : EnvioDatosPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert'
    {
        private static int CopiaCertificadaId = 415;
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
            set { DefaultQueryString = String.Format("sociedadId={0}", value); }
        }

#pragma warning disable CS0109 // The member 'CopiasCert.TipoSociedadId' does not hide an accessible member. The new keyword is not required.
        /// <summary>
        /// Llave primaria del numero del tipo de sociedad.
        /// </summary>
        new public int TipoSociedadId
#pragma warning restore CS0109 // The member 'CopiasCert.TipoSociedadId' does not hide an accessible member. The new keyword is not required.
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])
                           ? int.Parse(Request.QueryString["TipoSociedadId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("TipoSociedadId={0}", value); }
        }
#pragma warning disable CS0109 // The member 'CopiasCert.PersonaId' does not hide an accessible member. The new keyword is not required.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.PersonaId'
        new public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.PersonaId'
#pragma warning restore CS0109 // The member 'CopiasCert.PersonaId' does not hide an accessible member. The new keyword is not required.
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["PersonaId"])
                           ? int.Parse(Request.QueryString["PersonaId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("PersonaId={0}", value); }
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

        private int transaccionId;

#pragma warning disable CS0108 // 'CopiasCert.CamaraId' hides inherited member 'EnvioDatosPage.CamaraId'. Use the new keyword if hiding was intended.
        /// <summary>
        /// Camara que realizara la transaccion.
        /// </summary>
        public String CamaraId
#pragma warning restore CS0108 // 'CopiasCert.CamaraId' hides inherited member 'EnvioDatosPage.CamaraId'. Use the new keyword if hiding was intended.
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"])
                           ? Request.QueryString["CamaraId"]
                           : String.Empty;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();

            var helper = new TransaccionDevueltaHelper(Request);
            if (helper.EstaDevuelta() || DefaultQueryString.Contains("nSolicitud"))
            {
                var transaccionId = helper.ObtenerTransaccionId();

                var db = new OFV.CamaraWebsiteEntities();
                var transaccion = db.Transacciones.Where(x => x.TransaccionId == transaccionId).FirstOrDefault();

                lblTransaccionId.Text = transaccion.TransaccionId.ToString();
                txtDescripcion.Text = transaccion.Comentario;
            }

            
            //LoadDocumentos(txtNoRegistro.Text);
        }
        private string GetNomenclaturaSociedad() 
        {
            var dbComun = new CamaraComunEntities();

            var nomenclatura = (from no in dbComun.Nomenclaturas
                                where no.CamaraId.Equals(this.CamaraId) && no.TipoNomenclatura.Equals("S")
                                select no.Prefijo).FirstOrDefault();

            return nomenclatura;

        }
        private void LoadDocumentos(string numeroRegistro)
        {
            try
            {
                svrkofax.wsCSI csi = new svrkofax.wsCSI();
                System.Data.DataSet ds = new System.Data.DataSet();

                ds = csi.getPathCamaraOnline(1, string.Format("{0}{1}", numeroRegistro, GetNomenclaturaSociedad()));

                if (ds.Tables.Count > 0)
                {
                    this.rgDocumentos.DataSource = ds.Tables[0];
                    this.rgDocumentos.DataBind();
                    this.rgDocumentos.Visible = true;
                }
                else
                {
                    this.rgDocumentos.DataSource = new DataTable();
                    this.rgDocumentos.DataBind();
                    this.rgDocumentos.Visible = true;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex) 
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                svrkofax.wsCSI csi = new svrkofax.wsCSI();
                System.Data.DataSet ds = new System.Data.DataSet();

                ds = csi.getPathCamaraOnline(1, string.Format("{0}{1}", numeroRegistro, GetNomenclaturaSociedad()));

                if (ds.Tables.Count > 0)
                {
                    this.rgDocumentos.DataSource = ds.Tables[0];
                    this.rgDocumentos.DataBind();
                    this.rgDocumentos.Visible = true;
                }
                else
                {
                    this.rgDocumentos.DataSource = new DataTable();
                    this.rgDocumentos.DataBind();
                    this.rgDocumentos.Visible = true;
                }
            }
        }

        /// <summary>
        /// Carga los datos de la pantalla.
        /// </summary>
        private void InitInterface()
        {
            if (this.TipoSociedadId != 7)
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

                if (sociedadRegistro.TipoSociedadId.HasValue)
                {
                    var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == sociedadRegistro.TipoSociedadId).FirstOrDefault();
                    txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion.ToUpper() : String.Empty;
                }

                txtRNC.Text = sociedadRegistro.Rnc.FormatRnc();
                txtNoRegistro.Text = sociedadRegistro.NumeroRegistro.ToString();
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

                #endregion
                #endregion
            }
            else
            {
                #region Persona
                var dbComun = new CamaraComunEntities();
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var personaFisicaController = new PersonaFisicaController();
                var persona = personaFisicaController.ObteneByPersonaIdCamara(this.PersonaId, CamaraId).First();

                #region Generales
                var nombreCompleto = persona.Personas.PrimerNombre + " " + persona.Personas.SegundoNombre + " " + persona.Personas.PrimerApellido + " " + persona.Personas.SegundoApellido;
                //litTitulo.Text = nombreCompleto;
                litTituloM.Text = nombreCompleto;
                txtDenominacion.Text = nombreCompleto;

                //Estatus
                txtStatus.Visible = false;

                if (this.TipoSociedadId > 0)
                {
                    var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();
                    txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion.ToUpper() : String.Empty;
                }

                txtRNC.Text = persona.Personas.Rnc.FormatRnc();
                txtNoRegistro.Text = persona.NumeroRegistro.ToString();
                txtFechaConstitucion.Text = persona.Registros.FechaInicioOperacion.HasValue
                                                ? persona.Registros.FechaInicioOperacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                : String.Empty;
                lblEstatus.Visible = false;
                lblDuracionSociedad.Visible = false;
                lblDuracionConsejo.Visible = false;
                txtDuracionSociedad.Visible = false;
                lblFechaUltActo.Visible = false;
                txtDuracionConsejo.Visible = false;
                txtFechaUltActo.Visible = false;
                lblEnteRegulado.Visible = false;
                txtEnteRegulado.Visible = false;
                txtNumeroResolucion.Visible = false;
                lblNumeroResolucion.Visible = false;

                #endregion
                #endregion
            }
        }

        private bool UpdateTransaction(int servicioId ,long transId, int? modeloId = null )
        {
            string nombreCompleto = null;

            var repTransaccion = new OFV.TransaccionesRepository();
            var transSpecification = new Specification<OFV.Transacciones>(x => x.TransaccionId == transId);
            var transaccion = repTransaccion.SelectAll(transSpecification).FirstOrDefault();

            if (transaccion.TipoSociedadId != 7)
            {
                var repSociedades = new SRM.SociedadesController();

                var registro = repSociedades.FindRegistro(this.RegistroId, this.CamaraId) ?? new SRM.SociedadesRegistros();

                if (registro.Sociedades == null)
                    registro.Sociedades = new SRM.Sociedades();

                if (registro.Registros == null)
                    registro.Registros = new SRM.Registros();
                transaccion.Fecha = DateTime.Now;
                transaccion.NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.RegistroId = registro.RegistroId;
                transaccion.ModificacionCapital = 0m;
                transaccion.CapitalSocial = registro.Registros.CapitalSocial;
                transaccion.TipoSociedadId = this.TipoSociedadId;
                transaccion.RNCSolicitante = registro.Sociedades.Rnc;
                transaccion.ServicioId = servicioId;
                transaccion.UserName = User.Identity.Name.ToLower();
                transaccion.CamaraId = this.CamaraId;
                transaccion.EstatusTransId = Helper.EstatusTransIdNuevo;
                transaccion.Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono;
                transaccion.FechaAsamblea = registro.Sociedades.FechaAsamblea;
                transaccion.NombreSocialPersona = registro.Sociedades.NombreSocial ?? nombreCompleto;
                transaccion.TipoModeloId = modeloId;
                transaccion.EsCertificacion = true;
                transaccion.NumeroRegistro = registro.NumeroRegistro;
                transaccion.Comentario = this.txtDescripcion.Text.ToUpper();
            }
            else
            {
                var repPersona = new SRM.PersonaFisicaController();

                var persona = repPersona.ObteneByRegistroIdCamara(this.RegistroId, this.CamaraId).First();

                nombreCompleto = persona.Personas.PrimerNombre + " " + persona.Personas.SegundoApellido 
                    + " " + persona.Personas.PrimerApellido + " " + persona.Personas.SegundoApellido;
                if (persona.Registros == null)
                    persona.Registros = new SRM.Registros();
                transaccion.Fecha = DateTime.Now;
                transaccion.NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.RegistroId = persona.RegistroId;
                transaccion.ModificacionCapital = 0m;
                transaccion.CapitalSocial = persona.Registros.CapitalSocial;
                transaccion.TipoSociedadId = this.TipoSociedadId;
                transaccion.RNCSolicitante = persona.Personas.Rnc;
                transaccion.ServicioId = servicioId;
                transaccion.UserName = User.Identity.Name.ToLower();
                transaccion.CamaraId = this.CamaraId;
                transaccion.EstatusTransId = Helper.EstatusTransIdNuevo;
                transaccion.Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono;
                transaccion.FechaAsamblea = persona.Registros.FechaAsamblea1;
                transaccion.NombreSocialPersona = nombreCompleto;
                transaccion.TipoModeloId = modeloId;
                transaccion.EsCertificacion = true;
                transaccion.NumeroRegistro = persona.NumeroRegistro;
                transaccion.Comentario = this.txtDescripcion.Text.ToUpper();

            }
            
           
            var result = repTransaccion.Save() > 0;

            transaccionId = transaccion.TransaccionId;

            return result;
        }

        private bool RegisterTransaction(int servicioId, int? modeloId = null)
        {
            if(this.TipoSociedadId != 7)
            {
                var repSociedades = new SRM.SociedadesController();

                var registro = repSociedades.FindRegistro(this.RegistroId, this.CamaraId) ?? new SRM.SociedadesRegistros();

                if (registro.Sociedades == null)
                    registro.Sociedades = new SRM.Sociedades();

                if (registro.Registros == null)
                    registro.Registros = new SRM.Registros();

                string nombreCompleto = null;

                var transaccion = new OFV.Transacciones
                {
                    Fecha = DateTime.Now,
                    NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    RegistroId = registro.RegistroId,
                    ModificacionCapital = 0m,
                    CapitalSocial = registro.Registros.CapitalSocial,
                    TipoSociedadId = this.TipoSociedadId,
                    RNCSolicitante = registro.Sociedades.Rnc,
                    ServicioId = servicioId,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    FechaAsamblea = registro.Sociedades.FechaAsamblea,
                    NombreSocialPersona = registro.Sociedades.NombreSocial ?? nombreCompleto,
                    TipoModeloId = modeloId,
                    NumeroRegistro = registro.NumeroRegistro,
                    Comentario = this.txtDescripcion.Text.ToUpper(),
                    EsCertificacion = true
                };


                var repTransaccion = new OFV.TransaccionesRepository();

                repTransaccion.Add(transaccion);

                var result = repTransaccion.Save() > 0;

                transaccionId = transaccion.TransaccionId;

                return result;
            }
            else
            {
                var repPersona = new SRM.PersonaFisicaController();

                var persona = repPersona.ObteneByRegistroIdCamara(this.RegistroId, this.CamaraId).First();

                if (persona.Registros == null)
                    persona.Registros = new SRM.Registros();

                string nombreCompleto = null;
                nombreCompleto = persona.Personas.PrimerNombre + " " + persona.Personas.SegundoApellido + " " + persona.Personas.PrimerApellido + " " + persona.Personas.SegundoApellido;

                var transaccion = new OFV.Transacciones
                {
                    Fecha = DateTime.Now,
                    NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    RegistroId = persona.RegistroId,
                    ModificacionCapital = 0m,
                    CapitalSocial = persona.Registros.CapitalSocial,
                    TipoSociedadId = this.TipoSociedadId,
                    RNCSolicitante = persona.Personas.Rnc,
                    ServicioId = servicioId,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    FechaAsamblea = persona.Registros.FechaAsamblea1,
                    NombreSocialPersona = nombreCompleto,
                    TipoModeloId = modeloId,
                    NumeroRegistro = persona.NumeroRegistro,
                    Comentario = this.txtDescripcion.Text.ToUpper(),
                    EsCertificacion = true
                };


                var repTransaccion = new OFV.TransaccionesRepository();

                repTransaccion.Add(transaccion);

                var result = repTransaccion.Save() > 0;

                transaccionId = transaccion.TransaccionId;

                return result;
            }
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.btnConfirmar_Click(object, EventArgs)'
        protected void btnConfirmar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.btnConfirmar_Click(object, EventArgs)'
        {
            this.lblDescripcionObligatoria.Visible = false;
            var descripcion = this.txtDescripcion.Text.ToUpper();
            if (String.IsNullOrWhiteSpace(descripcion))
            {
                this.lblDescripcionObligatoria.Visible = true;
                return;
            }

            var modeloId = 0;
            var servicioId = CopiaCertificadaId;

            bool resultadoTransaccion = false;
            var transactionId = long.Parse(lblTransaccionId.Text);
            if (transactionId <= 0)
            {
                resultadoTransaccion = RegisterTransaction(servicioId, modeloId > 0 ? modeloId : (int?)null);
            }
            else
            {
                resultadoTransaccion = UpdateTransaction(servicioId, transactionId, modeloId > 0 ? modeloId : (int?)null);
            }

            if (!resultadoTransaccion) return;

            if (!DefaultQueryString.Contains(string.Format("nSolicitud={0}", transaccionId)))
            {
                DefaultQueryString = String.Format("nSolicitud={0}&EsCertificacion=1&EntregaDigital={1}", transaccionId, false);
            }

            Session["DocumentosSeleccionados"] = null;
            Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.BackUrl'
        protected string BackUrl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.BackUrl'
        {
            get
            {
                //var noSolicitud = Request.QueryString["nSolicitud"];
                //var tipoModeloId = Request.QueryString["TipoModeloId"];
                //var esCertificacion = Request.QueryString["EsCertificacion"];
                //var camaraId = Request.QueryString["CamaraId"];
                //return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";

                var helper = new TransaccionDevueltaHelper(Request);

                string queryString = DefaultQueryString;
                if (helper.EstaDevuelta() && !queryString.Contains("estado="))
                    queryString += "&estado=devuelto";

                return $"~/Empresas/ActualizarDatosGenerales.aspx{queryString}";
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCert.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect(BackUrl);
        }
    }
}