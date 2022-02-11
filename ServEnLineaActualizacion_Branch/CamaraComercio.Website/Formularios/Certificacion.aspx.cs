using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Empresas;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CamaraComercio.Website.WSShareBase;
using System.Globalization;
using System.IO;
namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion'
    public partial class Certificacion : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.socCtrl'
        public SociedadesController socCtrl = new SociedadesController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.socCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.perFisCtrl'
        public PersonaFisicaController perFisCtrl = new PersonaFisicaController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.perFisCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.registroPersona'
        public DataAccess.EF.SRM.PersonasRegistros registroPersona;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.registroPersona'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.registro'
        public DataAccess.EF.SRM.Registros registro;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.registro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.orgGest'
        public List<ViewRegistrosSocios> orgGest = new List<ViewRegistrosSocios>();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.orgGest'

#pragma warning disable CS0108 // 'Certificacion.transaccion' hides inherited member 'FormularioPage.transaccion'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.transaccion'
        public OFV.Transacciones transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.transaccion'
#pragma warning restore CS0108 // 'Certificacion.transaccion' hides inherited member 'FormularioPage.transaccion'. Use the new keyword if hiding was intended.
        {
            get
            {
                return dbWeb.Transacciones.First(t => t.TransaccionId == this.IdTransaciones);
            }
        }

        Camaras camara;
        cvw_SociedadesRegistros sociedadReg;
        OficinaVirtualUserProfile usuarioActual;
        DataAccess.EF.SRM.Direcciones direccion;
        DataAccess.EF.CamaraComun.Sectores sector;
        DataAccess.EF.CamaraComun.Ciudades ciudad;
        OFV.Facturas factura;
        DataAccess.EF.CamaraComun.Servicio serv;
#pragma warning disable CS0169 // The field 'Certificacion.referenciasBancarias' is never used
        List<DataAccess.EF.SRM.ReferenciasBancarias> referenciasBancarias;
#pragma warning restore CS0169 // The field 'Certificacion.referenciasBancarias' is never used
#pragma warning disable CS0169 // The field 'Certificacion.referenciasComerciales' is never used
        List<DataAccess.EF.SRM.ReferenciasComerciales> referenciasComerciales;
#pragma warning restore CS0169 // The field 'Certificacion.referenciasComerciales' is never used
        List<CamaraComercio.DataAccess.EF.SRM.Personas> EntesRegPer = new List<CamaraComercio.DataAccess.EF.SRM.Personas>();
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();
#pragma warning disable CS0169 // The field 'Certificacion.PersonasAutorizadas' is never used
        List<ViewRegistrosSocios> PersonasAutorizadas;
#pragma warning restore CS0169 // The field 'Certificacion.PersonasAutorizadas' is never used
        #endregion

        #region Props
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.NoEspecificada'
        public string NoEspecificada
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.NoEspecificada'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["NoEspecificada"])) return "";
                string noEspecificada = Request.QueryString["NoEspecificada"];
                return noEspecificada;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["cantidadCertificaciones"])) return 0;
                int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.RequiereDocs'
#pragma warning disable CS0108 // 'Certificacion.RequiereDocs' hides inherited member 'FormularioPage.RequiereDocs'. Use the new keyword if hiding was intended.
        public bool RequiereDocs
#pragma warning restore CS0108 // 'Certificacion.RequiereDocs' hides inherited member 'FormularioPage.RequiereDocs'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.RequiereDocs'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["requiereDocs"])
                            ? Request.QueryString["requiereDocs"] == "1"
                            : false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.PersonaId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["PersonaId"])) return 0;
                int.TryParse(Request.QueryString["PersonaId"], out int registroId);
                return registroId;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.TipoSociedadId'
        public int TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.TipoSociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])) return 0;
                int.TryParse(Request.QueryString["TipoSociedadId"], out int registroId);
                return registroId;
            }
        }
#pragma warning disable CS0108 // 'Certificacion.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.CamaraId'
        public string CamaraId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.CamaraId'
#pragma warning restore CS0108 // 'Certificacion.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.EntregaDigital'
#pragma warning disable CS0109 // The member 'Certificacion.EntregaDigital' does not hide an accessible member. The new keyword is not required.
        new public bool EntregaDigital
#pragma warning restore CS0109 // The member 'Certificacion.EntregaDigital' does not hide an accessible member. The new keyword is not required.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.EntregaDigital'
        {
            get
            {
                return bool.Parse(Request.QueryString["EntregaDigital"]);
            }
            // set { DefaultQueryString = String.Format("TipoSociedadId={0}", value); }
        }


        public int IdSolicitud
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["nSolicitud"])) return 0;
                int.TryParse(Request.QueryString["nSolicitud"], out int IdSolicitud);
                return IdSolicitud;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.Socios'
        {
            get
            {
                var items = Session["ACTDGENSOC"] != null ? Session["ACTDGENSOC"] as List<ViewRegistrosSocios> : null;
                return items != null ? items : new List<ViewRegistrosSocios>();
            }
            set
            {
                Session["ACTDGENSOC"] = value;
            }
        }
        #endregion

#pragma warning disable CS0108 // 'Certificacion.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.Page_Load(object, EventArgs)'
#pragma warning restore CS0108 // 'Certificacion.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        {
            if (IsPostBack) return;

            InitInterface();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.InitInterface()'
        {
            if (!IsValidRequestParameters()) return;
            // usuario logeado
            var user = Membership.GetUser(User.Identity.Name.ToLower());
            usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);


            if (EntregaDigital)
            {
                txtentregadigital.Text = "DIGITAL";
            }
            else
            {
                txtentregadigital.Text = "FISICA";
            }


            #region Sociedad_no_espesificada_para_certificacion
            //validar que la sociedad es nula porque estrata de una busqueda//
            serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
            if (!String.IsNullOrWhiteSpace(NoEspecificada))
            {
                txtServicio.Text = serv.Descripcion;
                lbCantidad.Visible = true;
                txtcantidadServicio.Visible = true;
                txtcantidadServicio.Text = CantidadCertificaciones.ToString();
                lbNombreQuien.Visible = true;
                txtNombreQuien.Visible = true;
                txtNombreQuien.Text = transaccion.ANombreQuien;
                txtDocumentoNombreQuien.Text = transaccion.DocumentoNombreQuien.FormatRnc();
                txtSolicitante.Text = transaccion.Solicitante;
                txtNombreCont.Text = transaccion.NombreContacto;
                if (user != null) txtEmail.Text = user.Email;
                //txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
                txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();
                txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
                lbIDepositarCansilleria.Visible = true;
                if (transaccion.DepositarCansilleria == true)
                {
                    txtIDepositarCansilleria.Visible = true;
                    txtIDepositarCansilleria.Text = "Si";
                }
                else
                {
                    txtIDepositarCansilleria.Text = "No";
                }
                txtRazSocial.Text = NoEspecificada;
                txtNoRegistro.Text = "N/A";
                txtRNCSoc.Text = "N/A";
                wrapComentario.Visible = false;
                //txtComentario.Text = "N/A";
                //txtComentario.ReadOnly = true;
                return;
            }

            #endregion

          
            var RespuestaUrl = Request.UrlReferrer.OriginalString.ToString();

            // var RrrrId =     HttpUtility.UrlEncode(Request.QueryString["RegistroId"]);
            int ssociedadid = 0;
            int rregistroId = 0;

            /*  if (RespuestaUrl.Contains("sociedadid"))
              {

                  ssociedadid = Convert.ToInt32(HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["sociedadid"]);

              }



              var solId = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["sociedadid"];     

              var nameValueCollection = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
              string keyword = nameValueCollection["sociedadid"]; */


            var queryCollection =  System.Web.HttpUtility.ParseQueryString(Request.UrlReferrer.Query.ToLower());

            if (queryCollection.AllKeys.Contains("sociedadid") && !string.IsNullOrEmpty(queryCollection.Get("sociedadid")))
            {
                //string value = Convert.ToInt32(queryCollection.Get("sociedadid"));

                ssociedadid = Convert.ToInt32(queryCollection.Get("sociedadid"));// Convert.ToInt32(HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["sociedadid"]);
            }

            if (queryCollection.AllKeys.Contains("registroid") && !string.IsNullOrEmpty(queryCollection.Get("registroid")))
            {
                rregistroId = Convert.ToInt32(queryCollection.Get("registroid"));// Convert.ToInt32(HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["sociedadid"]);
            }



            //funcion temporal problemas URL mayuscula minusculas: 2021-05-12: hasta optimizarlo mejor

            /*   int RegistroId_ = 0;

                 var _Transaccion = dbWeb.Transacciones.FirstOrDefault(d => d.TransaccionId == IdSolicitud);
               if (_Transaccion != null)
                   RegistroId_ = _Transaccion.RegistroId; */

            camara = camCtrl.FetchByID(this.CamaraId).First();
            if (this.TipoSociedadId != 7 && this.TipoSociedadId != 0)
            {
                #region entities
                registro = DbContext.Registros.FirstOrDefault(d => d.RegistroId == rregistroId);// RegistroId);
                sociedadReg = socCtrl.FetchSociedadesRegistroBySociedadId(ssociedadid, CamaraId); //SociedadId
                usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);

                 direccion = DbContext.Direcciones.FirstOrDefault(d => sociedadReg.DireccionId == d.DireccionId);
                sector = dbCom.Sectores.FirstOrDefault(s => s.SectorId == direccion.SectorId);
                if (sector != null)
                {
                    ciudad = dbCom.Ciudades.FirstOrDefault(c => c.CiudadId == sector.CiudadId);
                }
                factura = dbWeb.Facturas.FirstOrDefault(t => t.TransaccionId == this.IdTransaciones);

                serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
                #endregion

                //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
                // Datos del Gestor
                txtSolicitante.Text = transaccion.Solicitante;
                if (transaccion.Comentario != string.Empty)
                {
                    txtComentario.Text = transaccion.Comentario;
                    int countEspacio = transaccion.Comentario.Split('\n').Length;
                    //int chars = transaccion.Comentario.Length;
                    txtComentario.TextMode = TextBoxMode.MultiLine;
                    txtComentario.Columns = 10;
                    //int charsRows = chars / txtComentario.Columns;
                    txtComentario.Rows = /*charsRows +*/ 1 + countEspacio;
                    txtComentario.ReadOnly = true;


                }
                txtNombreCont.Text = transaccion.NombreContacto;
                if (user != null)
                    txtEmail.Text = user.Email;
                //txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
                txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
                txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();
                if (transaccion.DepositarCansilleria == true)
                {
                    txtIDepositarCansilleria.Text = "Si";
                }
                else
                {
                    txtIDepositarCansilleria.Text = "No";
                }



                txtNombreQuien.Text = transaccion.ANombreQuien;
                txtDocumentoNombreQuien.Text = transaccion.DocumentoNombreQuien.FormatRnc();

                // Datos de la sociedad
                txtRazSocial.Text = sociedadReg.NombreSocial;
                txtNoRegistro.Text = string.Format("{0}SD", sociedadReg.NumeroRegistro);
                txtRNCSoc.Text = sociedadReg.Rnc.FormatRnc();
                var estatus = dbCom.EstadoRegistro.Where(a => a.EstadoRegistroId == sociedadReg.EstatusId).FirstOrDefault();

            }
            else if (this.TipoSociedadId == 7)
            {
                #region persona
                registroPersona = DbContext.PersonasRegistros.FirstOrDefault(d => d.RegistroId == RegistroId);
                var persona = perFisCtrl.ObteneByPersonaIdCamara(PersonaId, CamaraId).First();
                usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);

                direccion = DbContext.Direcciones.FirstOrDefault(d => persona.Personas.DireccionId == d.DireccionId);
                sector = dbCom.Sectores.FirstOrDefault(s => s.SectorId == direccion.SectorId);
                if (sector != null)
                {
                    ciudad = dbCom.Ciudades.FirstOrDefault(c => c.CiudadId == sector.CiudadId);
                }
                factura = dbWeb.Facturas.FirstOrDefault(t => t.TransaccionId == this.IdTransaciones);

                serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
                #endregion

                //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
                // Datos del Gestor
                txtSolicitante.Text = transaccion.Solicitante;
                if (transaccion.Comentario != string.Empty)
                {
                    txtComentario.Text = transaccion.Comentario;
                    int countEspacio = transaccion.Comentario.Split('\n').Length;
                    //int chars = transaccion.Comentario.Length;
                    txtComentario.TextMode = TextBoxMode.MultiLine;
                    txtComentario.Columns = 10;
                    //int charsRows = chars / txtComentario.Columns;
                    txtComentario.Rows = /*charsRows +*/ 1 + countEspacio;
                    txtComentario.ReadOnly = true;


                }
                txtNombreCont.Text = transaccion.NombreContacto;
                if (user != null)
                    txtEmail.Text = user.Email;
                //txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
                txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
                txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();
                if (transaccion.DepositarCansilleria == true)
                {
                    txtIDepositarCansilleria.Text = "Si";
                }
                else
                {
                    txtIDepositarCansilleria.Text = "No";
                }
                txtNombreQuien.Text = transaccion.ANombreQuien;
                txtDocumentoNombreQuien.Text = transaccion.DocumentoNombreQuien;

                // Datos de la sociedad
                encabezadoDatosSociedad.Visible = false;
                encabezadoDatosPF.Visible = true;

                lbRazSocial.Visible = false;
                lblNombreCompleto.Visible = true;
                txtRazSocial.Text = transaccion.NombreSocialPersona;
                txtNoRegistro.Text = transaccion.NumeroRegistro != null ? string.Format("{0}SD-PF", transaccion.NumeroRegistro) : "N/A";

                lbRNCSociedad.Visible = false;
                lblRncPersona.Visible = true;
                txtRNCSoc.Text = !string.IsNullOrWhiteSpace(persona.Personas.Rnc) ? persona.Personas.Rnc.FormatRnc() : "N/A";

            }

            // Servicio
            txtServicio.Text = serv.Descripcion;
            txtcantidadServicio.Text = CantidadCertificaciones.ToString();

            // Sucursales
            //var sucursales = LoadSucursales();
            //SetSucursalesDataSource(sucursales);

            //Socios Accionistas
            //var accionistas = LoadSociosAccionistas();
            //SetSociosDataSource();
            //txtTotalAcciones.Text = sociedadReg.TotalAcciones.HasValue
            //    ? sociedadReg.TotalAcciones.Value2().ToString() : "0";

            //Organo Gestion
            //LoadOrgGestor();
            //SetOrgGestorDataSource();
            //txtDuracionDir.Text = sociedadReg.DuraccionDirectiva.HasValue
            //    ? sociedadReg.DuraccionDirectiva.Value2().ToString() : "";

            // Socios con Firmas autorizadas
            //var autorizados = LoadSociosAutorizadosAFirma();
            //SetSociosAutorizadosDataSource(autorizados);
            //PersonasAutorizadas = autorizados;

            //Referencias Comerciales
            //referenciasComerciales = DbContext.ReferenciasComerciales.Where(a => a.RegistroId == RegistroId).ToList();
            //txtReferenciasComerciales.Text = string.Join(",", referenciasComerciales.Select(d => d.Descripcion));
            //if (string.IsNullOrEmpty(txtReferenciasComerciales.Text))
            //    txtReferenciasComerciales.Text = "Referencias Comerciales";

            // Referencias Bancarias

            //referenciasBancarias = DbContext.ReferenciasBancarias.Where(a => a.RegistroId == RegistroId).ToList();
            //txtRefBancarias.Text = string.Join(",", referenciasBancarias.Select(d => d.BancoDescripcion));
            //if (string.IsNullOrEmpty(txtRefBancarias.Text))
            //    txtRefBancarias.Text = "Referencias Bancarias";

            // Fecha Asamblea
            //this.txtFechaAsamb.Text = sociedadReg.FechaAsamblea.HasValue
            //    ? sociedadReg.FechaAsamblea.Value2().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty;

        }

        private void EmpresaNoEspecificada()
        {
            return;
        }

        //private void SetSociosDataSource()
        //{
        //    sociosRep.DataSource = Socios;
        //    sociosRep.DataBind();
        //}

        //private void SetSociosAutorizadosDataSource(List<ViewRegistrosSocios> SociosAut)
        //{
        //    sociosAutRep.DataSource = SociosAut;
        //    sociosAutRep.DataBind();
        //}

        //private void SetOrgGestorDataSource()
        //{
        //    orgGestionRepeater.DataSource = orgGest;
        //    orgGestionRepeater.DataBind();
        //}

        private void SetSucursalesDataSource(List<Suscursales> sucursales)
        {
            //sucursalRepeater.DataSource = sucursales;
            //sucursalRepeater.DataBind();
        }

        private List<Suscursales> LoadSucursales()
        {
            if (this.TipoSociedadId != 7)
            {
                var sucursales = DbContext.Suscursales.Where(s => s.SociedadId == this.SociedadId).ToList();
                return sucursales;
            }
            else
            {
                var sucursales = DbContext.Suscursales.Where(s => s.SociedadId == this.SociedadId).ToList();
                return sucursales;
            }
        }

        private void LoadOrgGestor()
        {
            var registroSociosController = new RegistrosSociosController();
            var sociosAdministracion = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "C");
            orgGest = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosAdministracion)
                if (!orgGest.Any(d => d.SocioId == socio.SocioId)) orgGest.Add(socio);
        }

        private List<ViewRegistrosSocios> LoadSociosAccionistas()
        {
            var registroSociosController = new RegistrosSociosController();
            var sociosAccionistas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "A");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosAccionistas)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }

        private List<ViewRegistrosSocios> LoadSociosAutorizadosAFirma()
        {
            var registroSociosController = new RegistrosSociosController();

            var sociosFirmasAutorizadas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "F");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosFirmasAutorizadas)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }

        private List<ViewRegistrosSocios> LoadcomisariosCuenta()
        {
            var registroSociosController = new RegistrosSociosController();

            var sociosComisarios = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "O");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosComisarios)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }

        private bool IsValidRequestParameters()
        {
            if (string.IsNullOrWhiteSpace(CamaraId))
            {
                txtMessageTitle.InnerText = "Debe especificar la Cámara";
                mainMultiView.SetActiveView(failView);
                return false;
            }

            if (IdTransaciones <= 0)
            {
                txtMessageTitle.InnerText = "Debe especificar la transaccion";
                mainMultiView.SetActiveView(failView);
                return false;
            }


            return true;
        }

        //private void SetEntesRegDataSource()
        //{
        //    entesRegRep.DataSource = EntesReg;
        //    entesRegRep.DataBind();
        //}


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.LoadEntesRegulados()'
        public void LoadEntesRegulados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Certificacion.LoadEntesRegulados()'
        {
            var EntesRegulados = DbContext.ViewRegistrosSocios.Where(v => v.RegistroId == this.RegistroId).ToList();

            foreach (var ente in EntesRegulados)
            {
                var socCtrl = new SociedadesController();

                var sr = socCtrl.FindRegistro(ente.RegistroId, this.CamaraId);
                if (sr != null && sr.Sociedades.EsEnteRegulado)
                    if (!EntesReg.Any(s => sr.SociedadId == s.SociedadId)) EntesReg.Add(sr.Sociedades);
            }
        }
    }
}