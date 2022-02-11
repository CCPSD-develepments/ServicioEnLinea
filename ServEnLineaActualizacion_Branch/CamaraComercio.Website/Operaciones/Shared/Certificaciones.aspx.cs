using System;
using System.Linq;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using Telerik.Web.UI;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using System.Web.Configuration;
using CamaraComercio.Website.Helpers;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.SRM;
using System.Web.Security;

namespace CamaraComercio.Website.Operaciones.Shared
{
    ///<summary>
    /// Página que permite solicitar certificaciones
    ///</summary>
    public partial class Certificaciones : SecurePage
    {
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

        public int PersonaId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["personaId"])
                           ? int.Parse(Request.QueryString["personaId"])
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
            set
            {
                if (!DefaultQueryString.Contains("registroId"))
                    DefaultQueryString = String.Format("registroId={0}", value);
            }

        }
        /// <summary>
        /// Llave primaria del numero del tipo de sociedad.
        /// </summary>
        new public int TipoSociedadId
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
            set
            {
                if (!DefaultQueryString.Contains("CamaraId"))
                    DefaultQueryString = String.Format("CamaraId={0}", value);
            }
        }

        /// <summary>
        /// Es Indica que el tipo de Certificacion es Tipo Persona.
        /// </summary>
        public bool EsPersona
        {
            get
            {
                bool Estado = false;
                if (!String.IsNullOrWhiteSpace(Request.QueryString["PersonaId"]))
                    Estado = Request.QueryString["PersonaId"] != "0" ? true : false;

                return Estado;
            }
        }

        private int transaccionId;

        //2021-08

        private DataAccess.EF.CamaraComun.CamaraComunEntities _comunDbContext;
        private CamaraSRMEntities _srmDbContext;
        private OFV.CamaraWebsiteEntities _ofvDbContext;

        public CamaraSRMEntities SrmDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatosGenerales.SrmDbContext'
        {
            get
            {
                if (_srmDbContext == null) _srmDbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return _srmDbContext;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            //Data Source Socios
            odsCertificacionesAvanzadas.SelectParameters["servicioFlowIdNoRequiereAnalisis"].DefaultValue =
                Helper.ServicioFlowIdNoRequiereAnalisis.ToString();

            odsCertificacionesAvanzadas.SelectParameters["tipoServicioId"].DefaultValue =
                Helper.ServicioCertificacionId.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            //Nombre y tipo de empresa

            if (!EsPersona)
            {
                getCertificacionAnterio();
                var sociedades = new SRM.SociedadesController().FetchBySociedadId(this.SociedadId, this.CamaraId);
                if (sociedades.Count() <= 0)
                {
                    //Si no se pasó la sociedad por el URL o no existe, se intenta buscar por los demás parametros
                    if (this.CamaraId.Length > 0 && this.RegistroId > 0)
                    {
                        var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                        var sumario = dbSRM.ViewSumarioSociedades
                                .Where(s => s.RegistroId == this.RegistroId).FirstOrDefault();
                        if (sumario != null && sumario.SociedadId > 0)
                        {
                            this.SociedadId = sumario.SociedadId;
                            sociedades = new SRM.SociedadesController().FetchBySociedadId(sumario.SociedadId, this.CamaraId);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                var sociedad = sociedades.FirstOrDefault();
                this.lblNombreEmpresaM.Text = sociedad.NombreSocial;
                if (sociedad.TipoSociedadId != null && sociedad.TipoSociedadId > 0)
                {
                    var dbComun = new Comun.CamaraComunEntities();
                    var repTipoSociedad = dbComun.TipoSociedad.Where(t => t.TipoSociedadId == sociedad.TipoSociedadId).FirstOrDefault();

                    if (!String.IsNullOrEmpty(repTipoSociedad.Etiqueta))
                        this.lblNombreEmpresaM.Text = lblNombreEmpresaM.Text + string.Format("/{0}", repTipoSociedad.Etiqueta);
                }
            }
            else
            {
                getCertificacionAnterio();
                var personas = new SRM.PersonaFisicaController().ObteneByPersonaIdCamara(this.PersonaId, this.CamaraId);
                if (personas.Count() <= 0)
                {
                    //Si no se pasó la sociedad por el URL o no existe, se intenta buscar por los demás parametros
                    if (this.CamaraId.Length > 0 && this.RegistroId > 0)
                    {
                        var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                        var sumario = dbSRM.PersonasRegistros
                                .Where(s => s.RegistroId == this.RegistroId).FirstOrDefault();
                        if (sumario != null && sumario.PersonaId > 0)
                        {
                            this.PersonaId = sumario.PersonaId;
                            personas = new SRM.PersonaFisicaController().ObteneByPersonaIdCamara(sumario.PersonaId, this.CamaraId);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                var persona = personas.FirstOrDefault();
                var nombreCompleto = persona.Personas.PrimerNombre + " " + persona.Personas.SegundoApellido + " "
                    + persona.Personas.PrimerApellido + " " + persona.Personas.SegundoApellido;
                this.lblNombreEmpresaM.Text = nombreCompleto;
                if (this.TipoSociedadId != 0 && this.TipoSociedadId > 0)
                {
                    var dbComun = new Comun.CamaraComunEntities();
                    var repTipoSociedad = dbComun.TipoSociedad.Where(t => t.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();

                    if (!String.IsNullOrEmpty(repTipoSociedad.Etiqueta))
                        this.lblNombreEmpresaM.Text = lblNombreEmpresaM.Text + string.Format("/{0}", repTipoSociedad.Etiqueta);
                }
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Visible"]))
            {
                bool EnsenarCertGenerales = false;

                Boolean.TryParse(Request.QueryString["Visible"], out EnsenarCertGenerales);

                if (!EnsenarCertGenerales)
                    mv1.SetActiveView(vCertSimple);
            }

            var helper = new TransaccionDevueltaHelper(Request);
            var db = new OFV.CamaraWebsiteEntities();
            int tranId;
            int.TryParse(Request.QueryString["nSolicitud"], out tranId);
            var transaccion = db.Transacciones.Where(x => x.TransaccionId == tranId).FirstOrDefault();
            if (helper.EstaDevuelta())
            {

                ViewState["servicioId"] = transaccion.ServicioId;
                ViewState["modeloId"] = transaccion.TipoModeloId;
                LoadServicio(transaccion.ServicioId);
                mv1.SetActiveView(v2);

                //var grid = (RadGrid);
                //var esCertAvanzada = (grid.ID == "rgridCertificacionAvanzadas" ||
                //                      grid.ID == "rgridCertificacionAvanzadasPersonas");

                //     this.txtDescripcion.Text = String.Empty;
                this.pnlCampoDescripcion.Visible = true;

            }
            this.txtDescripcion.Text = transaccion?.Comentario ?? "";

            //this.rblCertificacionFirma.Enabled = false;
        }

        public void getCertificacionAnterio()
        {
            int tranId;
            int.TryParse(Request.QueryString["nSolicitud"], out tranId);
            if (tranId > 0)
            {
                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                var comun = new CamaraComunEntities();
                var transaccionSRM = context.Transacciones.FirstOrDefault(c => c.TransaccionIdAnterior == tranId && c.DesdeOfv);
                if (transaccionSRM != null)
                {
                    var result = comun.Servicio.Where(s => s.ServicioId == transaccionSRM.TipoServicioId);
                    rgridCertificacionesAnteriores.DataSource = "";
                    rgridCertificacionesAnteriores.DataSource = result;
                    rgridCertificacionesAnteriores.DataBind();
                    panelTransAnterior.Visible = true;
                }
            }
        }
        class CertificacionAnterior
        {
            public string Descripcion;
            public string CostoServicio;
            public string Url;

        }
        protected void rgridEmpresas_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (
                !(e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                || e.CommandArgument == null || e.CommandArgument.ToString().Length <= 0) return;

            Int32 modeloId, servicioId;
            var values = e.CommandArgument.ToString().Split('|');

            Int32.TryParse(values[0], out modeloId);
            Int32.TryParse(values[1], out servicioId);
            ViewState["servicioId"] = servicioId;
            ViewState["modeloId"] = modeloId;
            LoadServicio(servicioId);
            mv1.SetActiveView(v2);

            var grid = (RadGrid)source;
            var esCertAvanzada = (grid.ID == "rgridCertificacionAvanzadas" ||
                                  grid.ID == "rgridCertificacionesAnteriores" ||
                                  grid.ID == "rgridCertificacionAvanzadasPersonas");
            int tranId;
            var db = new OFV.CamaraWebsiteEntities();
            int.TryParse(Request.QueryString["nSolicitud"], out tranId);

            // para cargar el comentario del servicio anterior
            var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            var comun = new CamaraComunEntities();
            var transaccionSRM = context.Transacciones.FirstOrDefault(c => c.TransaccionIdAnterior == tranId && c.DesdeOfv);
            if (transaccionSRM != null)
            {
                var Servicio = comun.Servicio.FirstOrDefault(s => s.ServicioId == transaccionSRM.TipoServicioId);
                if (Servicio.ServicioId == servicioId)
                {
                    this.txtDescripcion.Text = transaccionSRM?.ComentarioHtml ?? "";
                }
            }
            else
            {
                this.txtDescripcion.Text = "";
            }
            //

            this.pnlCampoDescripcion.Visible = esCertAvanzada;
            //this.rblCertificacionFirma.Enabled = !esCertAvanzada;
            //this.lblNoAplica.Visible = esCertAvanzada;
        }

        private void LoadServicio(int servicioId)
        {
            switch (servicioId)
            {
                case 404: // CERTIFICACION SI POSEE O NO REGISTRO MERCANTIL
                    {
                        this.txtDescripcion.Text = string.Empty;
                        btnContinuar_Click(null, null);
                    }
                    break;
                default:
                    break;
            }

            var repServicio = new Comun.ServicioRepository();
            rgridServicioSeleccionado.DataSource = repServicio.GetServicio(servicioId);
            rgridServicioSeleccionado.DataBind();
        }

        private bool RegisterTransaction(int servicioId, int? modeloId = null)
        {

            var _CorreoContacto = String.Empty;
            var user = Membership.GetUser(User.Identity.Name);
            if (user != null)
            {
                _CorreoContacto = user.Email;
            }

            //new 2021-08-:
            var registroSRM = SrmDbContext.Registros.FirstOrDefault(d => d.RegistroId == this.RegistroId);



            if (EsPersona)
            {
                string nombreCompleto = null;
                var repPersona = new SRM.PersonaRepository(this.CamaraId);
                var persona = repPersona.SelectByKey(SRM.Personas.PropColumns.PersonaId, this.PersonaId);
                var ctrlPersonas = new SRM.PersonaFisicaController();
                var registro = ctrlPersonas.ObteneByRegistroIdCamara(this.RegistroId, this.CamaraId).FirstOrDefault() ?? new SRM.PersonasRegistros();

                if (registro.Personas == null)
                    registro.Personas = new SRM.Personas();

                if (registro.Registros == null)
                    registro.Registros = new SRM.Registros();

                nombreCompleto = string.Format("{0} {1} {2} {3}", persona.PrimerNombre, persona.SegundoNombre,
                    persona.PrimerApellido, persona.SegundoApellido);

                var transaccion = new OFV.Transacciones
                {
                    Fecha = DateTime.Now,
                    NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    RegistroId = this.RegistroId,
                    ModificacionCapital = 0m,
                    CapitalSocial = registro.Registros.CapitalSocial,
                    TipoSociedadId = this.TipoSociedadId != 0 ? this.TipoSociedadId : 7,
                    RNCSolicitante = registro.Personas.Rnc,
                    ServicioId = servicioId,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    FechaAsamblea = registro.Registros.FechaAsamblea1,
                    NombreSocialPersona = nombreCompleto,
                    TipoModeloId = modeloId,
                    NumeroRegistro = registro.NumeroRegistro,
                    Comentario = this.txtDescripcion.Text.ToUpper(),
                    EsCertificacion = true,

                    CorreoContacto = _CorreoContacto,
                    CorreoEmpresa = (registroSRM != null) ? registroSRM.Direcciones.Email : ""
                };


                var repTransaccion = new OFV.TransaccionesRepository();

                repTransaccion.Add(transaccion);

                var result = repTransaccion.Save() > 0;

                transaccionId = transaccion.TransaccionId;

                return result;
            }
            else
            {
                var repSociedades = new SRM.SociedadesController();

                var registro = repSociedades.FindRegistro(this.RegistroId, this.CamaraId) ?? new SRM.SociedadesRegistros();

                if (registro.Sociedades == null)
                    registro.Sociedades = new SRM.Sociedades();

                if (registro.Registros == null)
                    registro.Registros = new SRM.Registros();

                var SolicitanteNombre = (((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante == null) ? ((OficinaVirtualUserProfile)Context.Profile).UserName : ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;

                var transaccion = new OFV.Transacciones
                {
                    Fecha = DateTime.Now,
                    NombreContacto = SolicitanteNombre, //((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    RegistroId = this.RegistroId,
                    ModificacionCapital = 0m,
                    CapitalSocial = registro.Registros.CapitalSocial,
                    TipoSociedadId = this.TipoSociedadId != 0 ? this.TipoSociedadId : registro.Sociedades.TipoSociedadId.Value,
                    RNCSolicitante = registro.Sociedades.Rnc,
                    ServicioId = servicioId,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = SolicitanteNombre, //((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    FechaAsamblea = registro.Sociedades.FechaAsamblea,
                    NombreSocialPersona = registro.Sociedades.NombreSocial,
                    TipoModeloId = modeloId,
                    NumeroRegistro = registro.NumeroRegistro,
                    Comentario = this.txtDescripcion.Text.ToUpper(),
                    EsCertificacion = true,

                    CorreoContacto = _CorreoContacto,
                    CorreoEmpresa = (registroSRM != null) ? registroSRM.Direcciones.Email : ""
                };


                var repTransaccion = new OFV.TransaccionesRepository();

                repTransaccion.Add(transaccion);

                var result = repTransaccion.Save() > 0;

                transaccionId = transaccion.TransaccionId;

                return result;
            }
        }

        private bool UpdateTransaction(int servicioId, long transId, int? modeloId = null)
        {
            var _CorreoContacto = String.Empty;
            var user = Membership.GetUser(User.Identity.Name);
            if (user != null)
            {
                _CorreoContacto = user.Email;
            }

            //new 2021-08-:
            var registroSRM = SrmDbContext.Registros.FirstOrDefault(d => d.RegistroId == this.RegistroId);


            if (EsPersona)
            {
                string nombreCompleto = null;
                var repPersona = new SRM.PersonaRepository(this.CamaraId);
                var persona = repPersona.SelectByKey(SRM.Personas.PropColumns.PersonaId, this.PersonaId);
                var ctrlPersonas = new SRM.PersonaFisicaController();
                var registro = ctrlPersonas.ObteneByRegistroIdCamara(this.RegistroId, this.CamaraId).FirstOrDefault() ?? new SRM.PersonasRegistros();

                if (registro.Personas == null)
                    registro.Personas = new SRM.Personas();

                if (registro.Registros == null)
                    registro.Registros = new SRM.Registros();

                nombreCompleto = string.Format("{0} {1} {2} {3}", persona.PrimerNombre, persona.SegundoNombre,
                    persona.PrimerApellido, persona.SegundoApellido);


                var transSpecification = new Specification<OFV.Transacciones>(x => x.TransaccionId == transId);
                var repTransaccion = new OFV.TransaccionesRepository();
                var transaccion = repTransaccion.SelectAll(transSpecification).FirstOrDefault();
                transaccion.Fecha = DateTime.Now;
                transaccion.NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.ModificacionCapital = 0m;
                transaccion.CapitalSocial = registro.Registros.CapitalSocial;
                transaccion.RegistroId = this.RegistroId;
                transaccion.TipoSociedadId = this.TipoSociedadId != 0 ? this.TipoSociedadId : 7;
                //  transaccion.RNCSolicitante = registro.Personas.Rnc;
               
                transaccion.RNCSolicitante = (transaccion.EstatusTransId == 15) ? transaccion.RNCSolicitante : registro.Personas.Rnc;
                transaccion.Solicitante = (transaccion.EstatusTransId == 15) ? transaccion.Solicitante : ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;


                transaccion.ServicioId = servicioId;
                transaccion.UserName = User.Identity.Name.ToLower();
                transaccion.CamaraId = this.CamaraId;
                transaccion.EstatusTransId = Helper.EstatusTransIdNuevo;
                transaccion.Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono;
                transaccion.FechaAsamblea = registro.Registros.FechaAsamblea1;
                transaccion.NombreSocialPersona = nombreCompleto;
                transaccion.TipoModeloId = modeloId;
                transaccion.NumeroRegistro = registro.NumeroRegistro;
                transaccion.Comentario = this.txtDescripcion.Text.ToUpper();
                transaccion.EsCertificacion = true;

                transaccion.CorreoContacto = _CorreoContacto;
                transaccion.CorreoEmpresa = (registroSRM != null) ? registroSRM.Direcciones.Email : "";


                var result = repTransaccion.Save() > 0;

                transaccionId = transaccion.TransaccionId;

                return result;
            }
            else
            {
                var repSociedades = new SRM.SociedadesController();

                var registro = repSociedades.FindRegistro(this.RegistroId, this.CamaraId) ?? new SRM.SociedadesRegistros();

                if (registro.Sociedades == null)
                    registro.Sociedades = new SRM.Sociedades();

                if (registro.Registros == null)
                    registro.Registros = new SRM.Registros();

                string nombreCompleto = null;

                var transSpecification = new Specification<OFV.Transacciones>(x => x.TransaccionId == transId);
                var repTransaccion = new OFV.TransaccionesRepository();
                var transaccion = repTransaccion.SelectAll(transSpecification).FirstOrDefault();
                transaccion.Fecha = DateTime.Now;
                transaccion.NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
                transaccion.ModificacionCapital = 0m;
                transaccion.CapitalSocial = registro.Registros.CapitalSocial;
                transaccion.RegistroId = this.RegistroId;
                transaccion.TipoSociedadId = this.TipoSociedadId != 0 ? this.TipoSociedadId : registro.Sociedades.TipoSociedadId.Value;

                transaccion.RNCSolicitante = (transaccion.EstatusTransId == 15) ? transaccion.RNCSolicitante : registro.Sociedades.Rnc;
                transaccion.Solicitante = (transaccion.EstatusTransId == 15) ? transaccion.Solicitante : ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;

                transaccion.ServicioId = servicioId;
                transaccion.UserName = User.Identity.Name.ToLower();
                transaccion.CamaraId = this.CamaraId;
                transaccion.EstatusTransId = Helper.EstatusTransIdNuevo;          
                transaccion.TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono;
                transaccion.FechaAsamblea = registro.Sociedades.FechaAsamblea;
                transaccion.NombreSocialPersona = registro.Sociedades.NombreSocial ?? null;
                transaccion.TipoModeloId = modeloId;
                transaccion.NumeroRegistro = registro.NumeroRegistro;
                transaccion.Comentario = this.txtDescripcion.Text.ToUpper();
                transaccion.EsCertificacion = true;

                transaccion.CorreoContacto = _CorreoContacto;
                transaccion.CorreoEmpresa = (registroSRM != null) ? registroSRM.Direcciones.Email : "";



                var result = repTransaccion.Save() > 0;

                transaccionId = transaccion.TransaccionId;

                return result;
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            if (this.pnlCampoDescripcion.Visible)
            {
                this.lblDescripcionObligatoria.Visible = false;
                var descripcion = this.txtDescripcion.Text.ToUpper();
                if (String.IsNullOrWhiteSpace(descripcion))
                {
                    this.lblDescripcionObligatoria.Visible = true;
                    return;
                }
            }

            var modeloId = 0;
            var servicioId = 0;

            if (ViewState["modeloId"] != null)
                int.TryParse(ViewState["modeloId"].ToString(), out modeloId);

            if (ViewState["servicioId"] != null)
                int.TryParse(ViewState["servicioId"].ToString(), out servicioId);

            var helper = new TransaccionDevueltaHelper(Request);
            int nSolicitud;
            int.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);
            if (nSolicitud != 0)
            {
                if (!UpdateTransaction(servicioId, helper.ObtenerTransaccionId(), modeloId > 0 ? modeloId : (int?)null))
                    return;
            }
            else
            {
                if (!RegisterTransaction(servicioId, modeloId > 0 ? modeloId : (int?)null))
                    return;
            }

            //if (modeloId > 0)
            //    DefaultQueryString = String.Format("nSolicitud={0}&TipoModeloId={1}&EsCertificacion=1&EntregaDigital={2}",
            //                                       transaccionId, modeloId,false);
            //else
            if (DefaultQueryString.Contains(string.Format("nSolicitud={0}", transaccionId)))
            {
                if (!DefaultQueryString.Contains("EsCertificacion") && !DefaultQueryString.Contains("EntregaDigital"))
                {
                    DefaultQueryString = String.Format("EsCertificacion=1&EntregaDigital={0}", false);
                }
            }
            else
            {
                if (!DefaultQueryString.Contains("nSolicitud") && !DefaultQueryString.Contains("EsCertificacion"))
                {
                    DefaultQueryString = String.Format("nSolicitud={0}&EsCertificacion=1&EntregaDigital={1}", transaccionId, false);
                }
                else if (!DefaultQueryString.Contains("nSolicitud"))
                {
                    DefaultQueryString = String.Format("nSolicitud={0}&EntregaDigital={1}", transaccionId, false);
                }
            }




            Session["DocumentosSeleccionados"] = null;
            var dbCom = new CamaraComunEntities();
            var serv = dbCom.Servicio.FirstOrDefault(c => c.ServicioId == servicioId);
            if (!DefaultQueryString.Contains("TipoServicioId"))
            {
                DefaultQueryString = String.Format("nSolicitud={0}&EsCertificacion=1&EntregaDigital={1}&TipoServicioId={2}", transaccionId, false, serv.TipoServicioId);
            }
            Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);

            //Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
        }

        //Metodo para cargar la vista v1 si es una entrega fisica
        // y la vista ViewDescargaDigital si es una descarga digital
        private void LoadView()
        {
            if (rblCertificacionFisica.Checked)
                mv1.SetActiveView(v1);
            else
                mv1.SetActiveView(ViewDescargaDigital);
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            LoadView();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            LoadView();
        }
        protected string BackUrl
        {
            get
            {
                /*var noSolicitud = Request.QueryString["nSolicitud"];
                var tipoModeloId = Request.QueryString["TipoModeloId"];
                var esCertificacion = Request.QueryString["EsCertificacion"];
                var camaraId = Request.QueryString["CamaraId"];

                return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";*/
                var helper = new TransaccionDevueltaHelper(Request);
                string queryString = DefaultQueryString;
                if (helper.EstaDevuelta() && !queryString.Contains("estado="))
                    queryString += "&estado=devuelto";
                return $"~/Operaciones/Shared/Certificaciones.aspx{queryString}";
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(BackUrl);
        }

        protected void rgridCertificacionAvanzadas_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }
    }
}