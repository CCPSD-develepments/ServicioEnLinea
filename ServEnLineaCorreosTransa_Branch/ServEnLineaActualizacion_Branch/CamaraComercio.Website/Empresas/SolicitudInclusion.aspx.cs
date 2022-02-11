using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using EF = CamaraComercio.DataAccess.EF;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using System.Web.Security;
using CamaraComercio.Website.Helpers;
using System.Web.Configuration;
using System.Data.Common;
using System.Web.UI.WebControls;
using CamaraComercio.Website.WSShareBase;
using System.ServiceModel;
using System.ServiceModel.Channels;
using CamaraComercio.DataAccess.EF;


namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página para solicitar acceso a una empresa previamente matriculada en una Cámara
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class SolicitudInclusion : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.ServiciosDefault'
        public static ServicioSection ServiciosDefault
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.ServiciosDefault'
        {
            get
            {
                return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
            }
        }

        #region Private fields and properties

        /// <summary>
        /// Número de Registro Mercantil de la empresa.
        /// </summary>
        protected int RegistroId
        {
            get
            {
                return Session["RegistroId"] == null ? 0 : int.Parse(Session["RegistroId"].ToString());
            }
            set
            {
                Session["RegistroId"] = value;
            }
        }

        /// <summary>
        /// Id de la Camara.
        /// </summary>
        protected String CamaraId
        {
            get
            {
                if (Session["CamaraId"] == null)
                    return String.Empty;
                return Session["CamaraId"].ToString();
            }
            set
            {
                Session["CamaraId"] = value;
            }
        }
        /// <summary>
        /// Nombre de la Empresa de la cual se solicita la inclusión.
        /// </summary>
        protected String NombreEmpresa
        {
            get
            {
                if (Session["NombreEmpresa"] == null)
                    return String.Empty;
                return Session["NombreEmpresa"].ToString();
            }
            set
            {
                Session["NombreEmpresa"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.TipoEntidad'
        protected String TipoEntidad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.TipoEntidad'
        {
            get
            {
                if (Session["TipoEntidad"] == null)
                    return String.Empty;
                return Session["TipoEntidad"].ToString();
            }
            set
            {
                Session["TipoEntidad"] = value;
            }
        }
        /// <summary>
        /// Rnc de la Empresa de la cual se solicita la inclusión.
        /// </summary>
        protected String RncSolicitante
        {
            get
            {
                if (Session["RncSolicitante"] == null)
                    return String.Empty;
                return Session["RncSolicitante"].ToString();
            }
            set
            {
                Session["RncSolicitante"] = value;
            }

        }
        /// <summary>
        /// Usuario Logueado en la applicacion.
        /// </summary>
        private MembershipUser _currentuser;
        /// <summary>
        /// Flag que indica si ya he cargado el usuario anteriormente para evitar busquedas repetidas.
        /// </summary>
        private bool _bLoaded = false;
        /// <summary>
        /// Usuario logueado actualmente en el sistema.
        /// </summary>
        public MembershipUser CurrentUser
        {
            get
            {
                if (!_bLoaded)
                {
                    _currentuser = Membership.GetUser(Context.User.Identity.Name);
                    _bLoaded = true;
                }
                return _currentuser;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.TipoSociedadId'
        public int TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.TipoSociedadId'
        {
            get
            {
                if (Session["TipoSociedadId"] == null)
                    return 0;
                return int.Parse(Session["TipoSociedadId"].ToString());
            }
            set
            {
                Session["TipoSociedadId"] = value;
            }
        }
        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.Page_Load(object, EventArgs)'
        {
            if (Page.IsPostBack)
                return;

            var helper = new TransaccionDevueltaHelper(Request);
            var transaccionId = helper.ObtenerTransaccionId();

            var db = new OFV.CamaraWebsiteEntities();
            var transaction = db.Transacciones.Where(x => x.TransaccionId == transaccionId).FirstOrDefault();

            if (transaction != null)
            {
                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == transaction.TransaccionId && x.DesdeOfv);

                if (helper.EstaDevuelta() || trSDQ.VieneProblemas)
                {
                    //Se llena los cambios con la informacion anterior
                    LoadInterface();

                    this.lblTransId.Text = transaccionId.ToString();
                    this.ddlCamara.SelectedValue = transaction.CamaraId;
                    this.txtNumeroRegistro.Text = transaction.NumeroRegistro?.ToString();
                    this.txtPersonaContacto.Text = transaction.NombreContacto;
                    this.txtTelefonoContacto.Text = transaction.TelefonoContacto;

                    return;
                }
            }
            
            LoadInterface();
        }

        private bool ValidarTipoSociedad(int? tipo)
        {
            if (!tipo.HasValue) return false;

            switch (tipo)
            {
                case 1: return true;
                case 2: return true;
                case 3: return true;
                case 4: return true;
                case 5: return true;
                case 6: return true;
                case 10: return true;
                case 11: return true;
                case 12: return true;
                case 13: return true;
                case 14: return true;
                case 15: return true;
                case 16: return true;
                //case 17: return true;
                default: return false;
            }
        }

        private bool ValidarEstado(int? estado)
        {
            if (!estado.HasValue) return false;

            switch (estado)
            {
                case 1: return true;
                case 2: return true;
                case 3: return true;
                case 4: return true;
                case 8: return true;
                default: return false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.btnSolicitud_Click(object, EventArgs)'
        protected void btnSolicitud_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.btnSolicitud_Click(object, EventArgs)'
        {
            var tipoEmpresa = int.Parse(this.ddlTipoSociedadPersona.SelectedValue.ToString());
            if (tipoEmpresa == 0)
            {
                this.GenerateCustomError("Debe seleccionar el tipo de empresa.");
                return;
            }

            //Validación del CAPTCHA
            try
            {
                ccJoin.ValidateCaptcha(txtCaptcha.Text);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                Response.Redirect("/Empresas/SolicitudInclusion.aspx");
            }

            if (!ccJoin.UserValidated)
                return;

            var noRegistro = int.Parse(this.txtNumeroRegistro.Text);
            var camaraId = this.ddlCamara.SelectedItem.Value;
            if (tipoEmpresa == 1)
            {
                var ctrlSociedades = new SRM.SociedadesController();
                var sociedades = ctrlSociedades.FetchByRegistroAndCamara(noRegistro, camaraId);

                if (sociedades.Count == 0)
                {
                    this.GenerateCustomError("No se encontró ninguna sociedad con ese Número de Registro en la Cámara indicada");
                    return;
                }

                var sociedad = sociedades.FirstOrDefault();
                if (sociedad != null)
                {
                    if (!ValidarEstado(sociedad.EstatusId))
                    {
                        this.GenerateCustomError("Actualmente, este tipo societario no puede realizar este tipo de solicitud.");
                        return;
                    }

                    if (!ValidarTipoSociedad(sociedad.TipoSociedadId))
                    {
                        this.GenerateCustomError("Actualmente, este tipo societario no puede realizar este tipo de solicitud.");
                        return;
                    }

                    this.lblRnc.Text = sociedad.Rnc;
                    this.lblNombreEmpresa.Text = sociedad.NombreSocial + " " + sociedad.Estatus_fecha;
                    this.lblRegistro.Text = sociedad.NumeroRegistro.ToString();
                    this.lblCamaraID.Text = sociedad.CamaraID;
                    this.lblFechaConstitucion.Text = sociedad.FechaConstitucion.HasValue
                                                    ? sociedad.FechaConstitucion.Value.ToStringDom()
                                                    : String.Empty;

                    this.mvInclusion.SetActiveView(vRevision);


                    //Guardo Valores 
                    this.CamaraId = this.ddlCamara.SelectedItem.Value;
                    this.RegistroId = sociedad.RegistroId;
                    this.RncSolicitante = sociedad.Rnc;
                    this.NombreEmpresa = sociedad.NombreSocial + " " + sociedad.Estatus_fecha;
                    this.TipoSociedadId = sociedad.TipoSociedadId.Value2();
                    this.TipoEntidad = tipoEmpresa.ToString();

                }
            }
            else
            {
                var ctrlPersona = new SRM.PersonaFisicaController();
                var personas = ctrlPersona.ObteneByRegistroCamara(noRegistro, camaraId);
                if (personas.Count == 0)
                {
                    this.GenerateCustomError("No se encontró ninguna entidad Persona con ese Número de Registro en la Cámara indicada");
                    return;
                }
                var persona = personas.First();
                var nombreCompleto = persona.Personas.PrimerNombre + " " + persona.Personas.SegundoNombre + " " +
                    persona.Personas.PrimerApellido + " " + persona.Personas.SegundoApellido;

                this.lblRnc.Text = persona.Personas.Rnc != null ? persona.Personas.Rnc : persona.Personas.Documento;
                this.lblNombreEmpresa.Text = !String.IsNullOrEmpty(persona.Registros.NombreComercial) ? persona.Registros.NombreComercial : nombreCompleto;
                this.lblRegistro.Text = persona.NumeroRegistro.ToString();
                this.lblCamaraID.Text = camaraId;
                this.lblFechaConstitucion.Text = persona.Registros.FechaCreacion.HasValue
                                                ? persona.Registros.FechaCreacion.Value.ToStringDom()
                                                : String.Empty;

                this.mvInclusion.SetActiveView(vRevision);

                //Guardo Valores 
                this.CamaraId = this.ddlCamara.SelectedItem.Value;
                this.RegistroId = persona.RegistroId;
                this.RncSolicitante = persona.Personas.Rnc;
                this.NombreEmpresa = nombreCompleto;
                this.TipoEntidad = tipoEmpresa.ToString();
                this.TipoSociedadId = 7;
            }

        }

        private void Update(long transId)
        {
            //Variables
            var rnc = this.lblRnc.Text;
            var usuario = User.Identity.Name;
            var camaraId = this.lblCamaraID.Text;
            var noRegistroStr = this.lblRegistro.Text;
            var noRegistro = 0; Int32.TryParse(noRegistroStr, out noRegistro);

            //direccion de la camara
            var comunDB = new Comun.CamarasController();
            var camara = comunDB.FetchByID(ddlCamara.SelectedValue).FirstOrDefault();

            //setear el valor en el literal con la direccion de la camara.
            this.ltrDireccionCamara.Text = camara.HeaderImpresiones;

            var ctrlEmpresasPorUsuario = new OFV.EmpresasPorUsuarioController();
            var usuarioDueno = ctrlEmpresasPorUsuario.ExisteUsuarioConEmpresa(noRegistro);

            if (!String.IsNullOrEmpty(usuarioDueno))
            {
                //Quiere decir que hay un usuario
                if (usuarioDueno == usuario)
                {
                    this.GenerateCustomError("Ya esta empresa está registrada bajo esta cuenta.", "ContactoVal");
                    return;
                }
                else
                {
                    //Quiere decir que otra empresa ya tiene este usuario. Se notifica al usuario que se enviará un correo.
                    this.lblMensajesConfirmacion.Visible = true;
                }
            }
            var dbWeb = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            var repEmpresa = new EF.Repository<OFV.EmpresasPorUsuario, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);
            var repTransacion = new EF.Repository<OFV.Transacciones, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);
            var repDocSeleccionados = new EF.Repository<OFV.TransaccionDocSeleccionado, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);
            var repFacturas = new EF.Repository<OFV.Facturas, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);

            var repDocs = new EF.Repository<ServicioDocumentoRequerido, EF.CamaraComun.CamaraComunEntities>(
                          new CamaraComunEntities());
            var docRequeridos =
                repDocs.DoQuery().Where(
                d => d.TipoSociedadId == this.TipoSociedadId && d.ServicioId == Helper.ServicioInclusionId).ToList();

            using (DbTransaction tnx = repEmpresa.BeginTransaction())
            {

                var servicioId = 0;
                var servicio = ServiciosDefault.Servicios.Where(srv => srv.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();
                if (servicio != null)
                    servicioId = servicio.SolicitudInclusionId;
                else
                    servicioId = 686;  //id de servicio de inclusion.
                if (TipoEntidad.Equals("2"))
                {
                    servicioId = 741;
                }
                var registro = dbSrm.Registros.Where(a => a.RegistroId == this.RegistroId).FirstOrDefault();

                //Ingreso de la transacción
                var nombreSolicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                var rncSolicitante = ((OficinaVirtualUserProfile)Context.Profile).RNC;

                var transSpecification = new Specification<Transacciones>(x => x.TransaccionId == transId);
                var transSolicitudInclusion = repTransacion.SelectAll(transSpecification).FirstOrDefault();

                transSolicitudInclusion.Solicitante = nombreSolicitante;
                transSolicitudInclusion.RegistroId = this.RegistroId;
                transSolicitudInclusion.NombreSocialPersona = this.NombreEmpresa;
                transSolicitudInclusion.NombreContacto = this.txtPersonaContacto.Text.ToUpper();
                transSolicitudInclusion.TelefonoContacto = this.txtTelefonoContacto.Text;
                transSolicitudInclusion.RNCSolicitante = rncSolicitante;
                transSolicitudInclusion.CamaraId = this.CamaraId;
                transSolicitudInclusion.ServicioId = servicioId;
                transSolicitudInclusion.UserName = User.Identity.Name.ToLower();
                transSolicitudInclusion.TipoSociedadId = this.TipoSociedadId;
                transSolicitudInclusion.Fecha = DateTime.Now;
                transSolicitudInclusion.EstatusTransId = Helper.EstatusTransIdNuevo;
                transSolicitudInclusion.bPagada = false;
                transSolicitudInclusion.CapitalSocial = registro.CapitalSocial;
                transSolicitudInclusion.NumeroRegistro = noRegistro;
                transSolicitudInclusion.ContratoFirmado = true;

                // repTransacion.Add(transSolicitudInclusion);
                repTransacion.Save();

                //Factura (vacía)

                //var facturaSpecification = new Specification<Facturas>(x => x.TransaccionId == transId);
                //var factura = repFacturas.SelectAll(facturaSpecification)
                //     .OrderByDescending(x => x.FacturaId).FirstOrDefault();

                //factura.Complementaria = false;
                //factura.Estado = 2;
                //factura.Fecha = DateTime.Now;
                //factura.TipoNcf = Helper.TipoComprobanteIdDefault;
                //factura.TransaccionId = transSolicitudInclusion.TransaccionId;
                //factura.Usuario = User.Identity.Name.ToLower();
                //factura.CamaraId = this.CamaraId;
                //repFacturas.Save();


                //Ingreso de la solicitud
                var empresaSpecification = new Specification<EmpresasPorUsuario>(x => x.TransaccionId == transId);
                var empresa = repEmpresa.SelectAll(empresaSpecification).FirstOrDefault();
                empresa.CamaraID = camaraId;
                empresa.Usuario = usuario;
                empresa.FechaSolicitud = DateTime.Now;
                empresa.FechaUltModificacion = DateTime.Now;
                empresa.NoRegistro = noRegistro;
                empresa.Estado = (short)OFV.EmpresaPorUsuarioEstado.Solicitado;
                empresa.TransaccionId = transSolicitudInclusion.TransaccionId;

                //Se graba Empresa por Usuario
                repEmpresa.Save();

                //Se Asigna número de Transaccion para ser visualizado.
                lblNoRecibo.Text = transSolicitudInclusion.TransaccionId.ToString();


                var dbCom = new CamaraComunEntities();
                var serv = dbCom.Servicio.First(s => s.ServicioId == transSolicitudInclusion.ServicioId);
                //nSolicitud=39109&CamaraId=SDQ&TipoServicioId=38&TipoSociedadId=7&PersonaId=11488 

                string qs = String.Format("/Empresas/RevisionDocumentos.aspx?" +
                    "nSolicitud={0}" +
                    "&CamaraId={1}" +
                    "&TipoServicioId={2}" +
                    "&TipoSociedadId={3}",
                    transSolicitudInclusion.TransaccionId,
                    transSolicitudInclusion.CamaraId,
                    serv.TipoServicioId,
                    transSolicitudInclusion.TipoSociedadId);
                this.lnkFormEnvioDatos.NavigateUrl = qs;

                var helper = new TransaccionDevueltaHelper(Request);
                if (helper.EstaDevuelta())
                {
                    this.lnkFormEnvioDatos.NavigateUrl += "&estado=devuelto";
                }

                //Se setea el valor del query string para el formulario de envio de datos en el navigate url
                this.hlnkEnvioDatos.NavigateUrl = string.Format("EnvioDatos.aspx?nSolicitud={0}", transSolicitudInclusion.TransaccionId);
                //Guardando Valores para impresion de Solicitud

                this.mvInclusion.SetActiveView(vConfirmacion);

                //Guardando IdTransaccion en Seccion Para que la solicitud pueda imprimirla
                Session.Add("IdTransacciones", transSolicitudInclusion.TransaccionId);

                tnx.Commit();
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.btnSolicitar_Click(object, EventArgs)'
        protected void btnSolicitar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudInclusion.btnSolicitar_Click(object, EventArgs)'
        {
            int.TryParse(lblTransId.Text, out int transId);
            if (transId > 0)
            {
                Update(transId);
            }

            //Variables
            var rnc = this.lblRnc.Text;
            var usuario = User.Identity.Name.ToLower();
            var camaraId = this.lblCamaraID.Text;
            var noRegistroStr = this.lblRegistro.Text;
            var noRegistro = 0; Int32.TryParse(noRegistroStr, out noRegistro);

            //direccion de la camara
            var comunDB = new Comun.CamarasController();
            var camara = comunDB.FetchByID(ddlCamara.SelectedValue).FirstOrDefault();

            //setear el valor en el literal con la direccion de la camara.
            this.ltrDireccionCamara.Text = camara.HeaderImpresiones;

            //Se revisa que no haya una solicitud pendiente para este usuario/rnc o que ya exista para otra empresa
            var ctrlEmpresasPorUsuario = new OFV.EmpresasPorUsuarioController();
            if (ctrlEmpresasPorUsuario.ExisteSolicitud(usuario, noRegistro, camaraId))
            {
                this.GenerateCustomError("Este usuario ya ha realizado una solicitud para la inclusión de esta Empresa.", "ContactoVal");
                return;
            }

            var usuarioDueno = ctrlEmpresasPorUsuario.ExisteUsuarioConEmpresa(noRegistro);
            if (!String.IsNullOrEmpty(usuarioDueno))
            {
                //Quiere decir que hay un usuario
                if (usuarioDueno == usuario)
                {
                    this.GenerateCustomError("Ya esta empresa está registrada bajo esta cuenta.", "ContactoVal");
                    return;
                }
                else
                {
                    //Quiere decir que otra empresa ya tiene este usuario. Se notifica al usuario que se enviará un correo.
                    this.lblMensajesConfirmacion.Visible = true;
                }
            }
            var dbWeb = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            var repEmpresa = new EF.Repository<OFV.EmpresasPorUsuario, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);
            var repTransacion = new EF.Repository<OFV.Transacciones, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);
            var repDocSeleccionados = new EF.Repository<OFV.TransaccionDocSeleccionado, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);
            var repFacturas = new EF.Repository<OFV.Facturas, EF.OficinaVirtual.CamaraWebsiteEntities>(dbWeb);

            var repDocs = new EF.Repository<ServicioDocumentoRequerido, EF.CamaraComun.CamaraComunEntities>(
                          new CamaraComunEntities());
            int serId = TipoSociedadId != 7 ? Helper.ServicioInclusionId : 741; //serv tipo entidad persona
            var docRequeridos =
                repDocs.DoQuery().Where(
                d => d.TipoSociedadId == this.TipoSociedadId && d.ServicioId == serId).ToList();

            using (DbTransaction tnx = repEmpresa.BeginTransaction())
            {

                var servicioId = 0;
                var servicio = ServiciosDefault.Servicios.Where(srv => srv.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();
                if (servicio != null)
                    servicioId = servicio.SolicitudInclusionId;
                else
                    servicioId = 686;  //id de servicio de inclusion.
                if (TipoEntidad.Equals("2"))
                {
                    servicioId = 741;
                }

                var registro = dbSrm.Registros.Where(a => a.RegistroId == this.RegistroId).FirstOrDefault();

                //Ingreso de la transacción
                var nombreSolicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                var rncSolicitante = ((OficinaVirtualUserProfile)Context.Profile).RNC;
                var transSolicitudInclusion = new OFV.Transacciones()
                {
                    Solicitante = nombreSolicitante,
                    RegistroId = this.RegistroId,
                    NombreSocialPersona = this.NombreEmpresa,
                    NombreContacto = this.txtPersonaContacto.Text.ToUpper(),
                    TelefonoContacto = this.txtTelefonoContacto.Text,
                    RNCSolicitante = rncSolicitante,
                    CamaraId = this.CamaraId,
                    ServicioId = servicioId,
                    UserName = User.Identity.Name.ToLower(),
                    TipoSociedadId = this.TipoSociedadId,
                    Fecha = DateTime.Now,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    bPagada = false,
                    CapitalSocial = registro.CapitalSocial,
                    NumeroRegistro = noRegistro,
                    ContratoFirmado = true
                };

                repTransacion.Add(transSolicitudInclusion);
                repTransacion.Save();

                ////Factura (vacía)
                //var factura = new OFV.Facturas
                //{
                //    Complementaria = false,
                //    Estado = 2,
                //    Fecha = DateTime.Now,
                //    TipoNcf = Helper.TipoComprobanteIdDefault,
                //    TransaccionId = transSolicitudInclusion.TransaccionId,
                //    Usuario = User.Identity.Name.ToLower(),
                //    CamaraId = this.CamaraId
                //};
                //repFacturas.Add(factura);
                //repFacturas.Save();

                //Ingreso de documentos requeridos
                foreach (var doc in docRequeridos)
                {
                    repDocSeleccionados.Add(new TransaccionDocSeleccionado
                    {
                        CantidadCopia = 0,
                        CantidadOriginal = 1,
                        FechaDocumento = DateTime.Now,
                        TipoDocumentoId = doc.TipoDocumentoId,
                        TransaccionId = transSolicitudInclusion.TransaccionId
                    });
                }
                repDocSeleccionados.Save();

                //Ingreso de la solicitud
                var empresa = new OFV.EmpresasPorUsuario()
                {
                    CamaraID = camaraId,
                    Usuario = usuario,
                    FechaSolicitud = DateTime.Now,
                    FechaUltModificacion = DateTime.Now,
                    NoRegistro = noRegistro,
                    Estado = (short)OFV.EmpresaPorUsuarioEstado.Solicitado,
                    TransaccionId = transSolicitudInclusion.TransaccionId,
                    EsPersona = transSolicitudInclusion.TipoSociedadId == 7 ? true : false 
                };

                repEmpresa.Add(empresa);

                //Se graba Empresa por Usuario
                repEmpresa.Save();

                //Se Asigna número de Transaccion para ser visualizado.
                lblNoRecibo.Text = transSolicitudInclusion.TransaccionId.ToString();
                this.lnkFormEnvioDatos.NavigateUrl = "VerDetalleTransaccion.aspx?nSolicitud=" + transSolicitudInclusion.TransaccionId;

                //Se setea el valor del query string para el formulario de envio de datos en el navigate url
                this.hlnkEnvioDatos.NavigateUrl = string.Format("EnvioDatos.aspx?nSolicitud={0}", transSolicitudInclusion.TransaccionId);
                //Guardando Valores para impresion de Solicitud

                this.mvInclusion.SetActiveView(vConfirmacion);

                //Guardando IdTransaccion en Seccion Para que la solicitud pueda imprimirla
                Session.Add("IdTransacciones", transSolicitudInclusion.TransaccionId);

                tnx.Commit();

                if (string.IsNullOrEmpty(transSolicitudInclusion.FolderId))
                    CreateFolderOnShareBase(transSolicitudInclusion.TransaccionId);
            }
        }

        private bool CreateFolderOnShareBase(int TransId)
        {
            var db = new CamaraWebsiteEntities();
            var trans = db.Transacciones.FirstOrDefault(t => t.TransaccionId == TransId);

            if (Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                BasicOperationResultOfstring resp;
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    resp = client.CreateFolderOnSharebase(trans.TransaccionId.ToString(), Helper.NombreCarpetaShareBase);
                    trans.FolderId = resp.Entity;
                    db.SaveChanges();
                    client.Close();
                }
                return resp.Success;
            }

            return true;
        }

        private void LoadInterface()
        {
            ddlCamara.SelectedValue = Helper.IdCamaraPrincipal;
        }
    }
}