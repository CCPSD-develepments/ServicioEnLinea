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

namespace CamaraComercio.Website.Operaciones.Shared
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RegDup'
    public partial class RegDup : EnvioDatosPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RegDup'
    {
        private static int DuplicadoServicioMercantil = 401;
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RegDup.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RegDup.PersonaId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["PersonaId"])
                           ? int.Parse(Request.QueryString["PersonaId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("PersonaId={0}", value); }
        }

#pragma warning disable CS0109 // The member 'RegDup.TipoSociedadId' does not hide an accessible member. The new keyword is not required.
        /// <summary>
        /// Llave primaria del numero del tipo de sociedad.
        /// </summary>
        new public int TipoSociedadId
#pragma warning restore CS0109 // The member 'RegDup.TipoSociedadId' does not hide an accessible member. The new keyword is not required.
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])
                           ? int.Parse(Request.QueryString["TipoSociedadId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("TipoSociedadId={0}", value); }
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

#pragma warning disable CS0108 // 'RegDup.CamaraId' hides inherited member 'EnvioDatosPage.CamaraId'. Use the new keyword if hiding was intended.
        /// <summary>
        /// Camara que realizara la transaccion.
        /// </summary>
        public String CamaraId
#pragma warning restore CS0108 // 'RegDup.CamaraId' hides inherited member 'EnvioDatosPage.CamaraId'. Use the new keyword if hiding was intended.
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"])
                           ? Request.QueryString["CamaraId"]
                           : String.Empty;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RegDup.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RegDup.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            
            InitInterface();
            LoadDocumentos(txtNoRegistro.Text);
            txtDescripcion.Text = string.Empty;
            var modeloId = 0;
            var servicioId = DuplicadoServicioMercantil;

            if (!DefaultQueryString.Contains("nSolicitud="))
            {
                if (!RegisterTransaction(servicioId, modeloId > 0 ? modeloId : (int?)null))
                    return;
                DefaultQueryString = String.Format("nSolicitud={0}&EsCertificacion=0&EntregaDigital={1}", transaccionId, false);
            }

            Session["DocumentosSeleccionados"] = null;

            Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
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
                this.rgDocumentos.DataSource = new DataTable();
                this.rgDocumentos.DataBind();
                this.rgDocumentos.Visible = true;
            }
        }

        /// <summary>
        /// Carga los datos de la pantalla.
        /// </summary>
        private void InitInterface()
        {
            if(this.TipoSociedadId != 7)
            {
                #region Sociedades
                var dbComun = new CamaraComunEntities();
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var sociedadescontroller = new SociedadesController();
                var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);

                #region Generales

                litTitulo.Text = sociedadRegistro.NombreEmpresa;
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
                    txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;
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
                #region Sociedades
                var dbComun = new CamaraComunEntities();
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var personaController = new PersonaFisicaController();
                var persona = personaController.ObteneByPersonaIdCamara(PersonaId, CamaraId).First();

                #region Generales
                var nombreCompleto = string.Format("{0} {1} {2} {3}", persona.Personas.PrimerNombre, persona.Personas.SegundoNombre
                    ,persona.Personas.PrimerApellido, persona.Personas.SegundoApellido);

                litTitulo.Text = nombreCompleto;
                txtDenominacion.Text = nombreCompleto;

                //Estatus
                txtStatus.Visible = false;
                lblEstatus.Visible = false;

                if (this.TipoSociedadId != 0)
                {
                    var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();
                    txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;
                }

                txtRNC.Text = persona.Personas.Rnc.FormatRnc();
                txtNoRegistro.Text = persona.NumeroRegistro.ToString();
                txtFechaConstitucion.Text = persona.Registros.FechaInicioOperacion.HasValue
                                                 ? persona.Registros.FechaInicioOperacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                 : String.Empty;

                txtDuracionSociedad.Visible = false;
                lblDuracionSociedad.Visible = false;
                txtDuracionConsejo.Visible = false;
                lblDuracionConsejo.Visible = false;

                txtFechaUltActo.Text = persona.Registros.FechaModificacion != null
                                           ? persona.Registros.FechaModificacion.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                           : String.Empty;

                txtEnteRegulado.Visible = false;
                txtNumeroResolucion.Visible = false;
                lblNumeroResolucion.Visible = false;

                #endregion
                #endregion
            }

        }

        private bool RegisterTransaction(int servicioId, int? modeloId = null)
        {
            if (this.TipoSociedadId != 7)
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
                    Comentario = this.txtDescripcion.Text
                };


                var repTransaccion = new OFV.TransaccionesRepository();

                repTransaccion.Add(transaccion);

                var result = repTransaccion.Save() > 0;
                transaccionId = transaccion.TransaccionId;
                return result;
            }
            else
            {
                var repPersonaFis = new SRM.PersonaFisicaController();

                var persona = repPersonaFis.ObtenerUnByRegistroIdCamara(this.RegistroId, this.CamaraId);

                if (persona.Personas == null)
                    persona.Personas = new SRM.Personas();

                if (persona.Registros == null)
                    persona.Registros = new SRM.Registros();

                string nombreCompleto = string.Format("{0} {1} {2} {3}", persona.Personas.PrimerNombre, persona.Personas.SegundoNombre
                    , persona.Personas.PrimerApellido, persona.Personas.SegundoApellido);

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
                    NombreSocialPersona =  nombreCompleto,
                    TipoModeloId = modeloId,
                    NumeroRegistro = persona.NumeroRegistro,
                    Comentario = this.txtDescripcion.Text
                };


                var repTransaccion = new OFV.TransaccionesRepository();

                repTransaccion.Add(transaccion);

                var result = repTransaccion.Save() > 0;
                transaccionId = transaccion.TransaccionId;
                return result;
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RegDup.btnConfirmar_Click(object, EventArgs)'
        protected void btnConfirmar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RegDup.btnConfirmar_Click(object, EventArgs)'
        {
            this.lblDescripcionObligatoria.Visible = false;
            var descripcion = this.txtDescripcion.Text;
            if (String.IsNullOrWhiteSpace(descripcion))
            {
                this.lblDescripcionObligatoria.Visible = true;
                return;
            }

            var modeloId = 0;
            var servicioId = DuplicadoServicioMercantil;

            if (!RegisterTransaction(servicioId, modeloId > 0 ? modeloId : (int?)null))
                return;

            if (!DefaultQueryString.Contains("nSolicitud="))
                DefaultQueryString = String.Format("nSolicitud={0}&EsCertificacion=1&EntregaDigital={1}",
                                                transaccionId, false);

            Session["DocumentosSeleccionados"] = null;

            Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }
    }
}