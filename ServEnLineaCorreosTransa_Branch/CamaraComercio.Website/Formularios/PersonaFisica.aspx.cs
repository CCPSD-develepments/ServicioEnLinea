using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.SRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica'
    public partial class PersonaFisica : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.perCtrl'
        public PersonaFisicaController perCtrl = new PersonaFisicaController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.perCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.socioCtrl'
        public RegistrosSociosController socioCtrl = new RegistrosSociosController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.socioCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.registro'
        public DataAccess.EF.SRM.Registros registro;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.registro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.orgGest'
        public List<ViewRegistrosSocios> orgGest = new List<ViewRegistrosSocios>();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.orgGest'
        OficinaVirtualUserProfile usuarioActual;
        DataAccess.EF.CamaraComun.Servicio serv;
        DataAccess.EF.CamaraComun.TipoServicio tipServ;
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();

        #endregion
        #region Props
#pragma warning disable CS0108 // 'PersonaFisica.RequiereDocs' hides inherited member 'FormularioPage.RequiereDocs'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.RequiereDocs'
        public bool RequiereDocs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.RequiereDocs'
#pragma warning restore CS0108 // 'PersonaFisica.RequiereDocs' hides inherited member 'FormularioPage.RequiereDocs'. Use the new keyword if hiding was intended.
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["requiereDocs"])
                            ? Request.QueryString["requiereDocs"] == "1"
                            : false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.PersonaId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["PersonaId"])) return 0;
                int.TryParse(Request.QueryString["PersonaId"], out int personaId);
                return personaId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.CamaraId'
#pragma warning disable CS0108 // 'PersonaFisica.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
        public string CamaraId
#pragma warning restore CS0108 // 'PersonaFisica.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }

        //public int IdTransaciones
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(Request.QueryString["IdTransaccion"])) return 0;
        //        int.TryParse(Request.QueryString["IdTransaccion"], out int transaccionId);
        //        return transaccionId;
        //    }
        //}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["cantidadCertificaciones"])) return 0;
                int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.Socios'
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

#pragma warning disable CS0108 // 'PersonaFisica.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.Page_Load(object, EventArgs)'
#pragma warning restore CS0108 // 'PersonaFisica.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        {
            if (IsPostBack) return;

            InitInterface();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonaFisica.InitInterface()'
        {
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            if (!IsValidRequestParameters()) return;

            var persona = perCtrl.ObteneByPersonaIdCamara(this.PersonaId, this.CamaraId).First();
            serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
            tipServ = dbCom.TipoServicio.FirstOrDefault(s => serv.TipoServicioId == s.TipoServicioId);
            // litTipoSociedad.Text = sociedadReg.SufijoSociedad;
            // Datos del Gestor
            //txtSolicitante.Text = transaccion.Solicitante;
            txtNombreCont.Text = transaccion.NombreContacto;
            var user = Membership.GetUser(User.Identity.Name);
            if (user != null)
                txtEmail.Text = user.Email;

            //txtNombreF.Text = transaccion.NombreSocialPersona;
            //txtRNC1.Text = !string.IsNullOrWhiteSpace(transaccion.RNCSolicitante.FormatRnc()) ? transaccion.RNCSolicitante.FormatRnc() : "N/A";
            txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
            usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);
            txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

            //Comprobante y Cancilleria

            // Datos de la sociedad
            txtRazSocial.Text = transaccion.NombreSocialPersona;
            txtNoRegistro.Text = string.Format("{0}SD-PF",transaccion.NumeroRegistro);
            if (persona.Personas.DireccionId.HasValue)
            {
                var repDirecciones = new Repository<SRM.ViewDirecciones, SRM.CamaraSRMEntities>(dbSrm);
                var direccion = repDirecciones.SelectByKey(SRM.ViewDirecciones.PropColumns.DireccionId,
                                                                           persona.Personas.DireccionId.Value);
                var direcionCalle = !string.IsNullOrWhiteSpace(direccion.Calle)
                ? direccion.Calle + "," : "";
                var direccionSector = !string.IsNullOrWhiteSpace(direccion.Sector)
                    ? direccion.Sector + "," : "";
                var direccionCiudad = !string.IsNullOrWhiteSpace(direccion.Ciudad)
                    ? direccion.Ciudad + "." : "";

                txtDireccionPF.Text = string.Format(
                    "{0} {1} {2}",
                    direcionCalle,
                    direccionSector,
                    direccionCiudad
                    );
                txtTelefonoCasa.Text = !string.IsNullOrWhiteSpace(direccion.TelefonoCasa) ? direccion.TelefonoCasa : "N/A";
            }

            

            txtNombreCom.Text = !string.IsNullOrWhiteSpace(persona.Registros.NombreComercial) ? persona.Registros.NombreComercial : "N/A";
            txtDocumento.Text = !string.IsNullOrWhiteSpace(persona.Personas.Documento) ? persona.Personas.Documento : "N/A";
            txtNombreEstablecimiento.Text = !string.IsNullOrWhiteSpace(persona.Registros.NombreEstablecimiento) ? persona.Registros.NombreEstablecimiento : "N/A";

            if (persona.Registros.DireccionId.HasValue)
            {
                var repDirecciones = new Repository<SRM.ViewDirecciones, SRM.CamaraSRMEntities>(dbSrm);
                var direccion = repDirecciones.SelectByKey(SRM.ViewDirecciones.PropColumns.DireccionId,
                                                                           persona.Personas.DireccionId.Value);

                var direcionCalle = !string.IsNullOrWhiteSpace(direccion.Calle)
                ? direccion.Calle + "," : "";
                var direccionSector = !string.IsNullOrWhiteSpace(direccion.Sector)
                    ? direccion.Sector + "," : "";
                var direccionCiudad = !string.IsNullOrWhiteSpace(direccion.Ciudad)
                    ? direccion.Ciudad + "." : "";

                txtDireccionEstablecimiento.Text = string.Format(
                    "{0} {1} {2}",
                    direcionCalle,
                    direccionSector,
                    direccionCiudad
                );
                txtPagWeb.Text = !string.IsNullOrWhiteSpace(direccion.SitioWeb) ? direccion.SitioWeb : "N/A";
                txtTel1.Text = !string.IsNullOrWhiteSpace(direccion.TelefonoCasa)? direccion.TelefonoCasa.FormatTelefono() : "N/A";
                txtTel2.Text = !string.IsNullOrWhiteSpace(direccion.TelefonoOficina)?direccion.TelefonoOficina.FormatTelefono() : "N/A";
                txtEmailPF.Text = !string.IsNullOrWhiteSpace(direccion.Email)? direccion.Email : "N/A";
            }

             txtRNCSoc.Text = !string.IsNullOrWhiteSpace(persona.Personas.Rnc.FormatRnc())? persona.Personas.Rnc.FormatRnc() : "N/A";

            txtFechaEmision.Text = !string.IsNullOrWhiteSpace(Convert.ToString(persona.Registros.FechaEmision) ?? "") ?
                string.Format("{0:dd/MM/yyyy}", persona.Registros.FechaEmision) : "N/A";
            txtFechaIO.Text = !string.IsNullOrWhiteSpace(Convert.ToString(persona.Registros.FechaInicioOperacion) ?? "") ? 
                string.Format("{0:dd/MM/yyyy}",persona.Registros.FechaInicioOperacion) : "N/A";
            txtFechaVenc.Text = !string.IsNullOrWhiteSpace(Convert.ToString(persona.Registros.FechaVencimiento) ?? "") ?
                string.Format("{0:dd/MM/yyyy}", persona.Registros.FechaVencimiento) : "N/A"; ;
            txtEmpFem.Text = persona.Registros.EmpleadosFemeninos.ToString();
            txtEmpMasc.Text = persona.Registros.EmpleadosMasculinos.ToString();
            txtTotalEmp.Text = persona.Registros.EmpleadosTotal.ToString();
            txtRegNombreCom.Text = Convert.ToString(persona.Registros.RegistroNombreComercial) ?? "N/A";
            txtServicio.Text = tipServ.Descripcion.ToUpper() + " - " + serv.Descripcion;
            var nacionalidad = dbCom.Paises.Where(s => s.PaisId == persona.Personas.NacionalidadId.Value).Select(s=> s.Nombre).FirstOrDefault();
            txtNacionalidad.Text = !string.IsNullOrWhiteSpace(nacionalidad)? nacionalidad:"N/A";

            //Socios
            var socios = socioCtrl.FetchAllSociosByRegistroIdAndTipoRelacion(transaccion.RegistroId,this.CamaraId, "A").ToList();
            //SetSociosDataSource(socios.ToList());

            //// Socios con Firmas autorizadas
            ////var autorizados = LoadSociosAutorizadosAFirma();
            ////SetSociosAutorizadosDataSource(autorizados);
            ////PersonasAutorizadas = autorizados;

            //Referencias Comerciales
            //txtReferenciasComerciales.Text = string.Join(",", persona.Registros.ReferenciasComerciales.Select(d => d.Descripcion));
            //if (string.IsNullOrEmpty(txtReferenciasComerciales.Text))
            //    txtReferenciasComerciales.Text = "Referencias Comerciales";

            //// Referencias Bancarias

            //txtRefBancarias.Text = string.Join(",", persona.Registros.ReferenciasBancarias.Select(d => d.BancoDescripcion));
            //if (string.IsNullOrEmpty(txtRefBancarias.Text))
            //    txtRefBancarias.Text = "Referencias Bancarias";
            // Datos de Pago
            // Se toman al final
            //txtNombrePagador.Text = transaccion.So
            //txtCedulaPagador.Text = tran
            var trans = TransaccionesController.GetTransaccionById(IdTransaciones);
            if (string.IsNullOrEmpty(trans.FolderId))
                CreateFolderOnShareBase(trans.TransaccionId);
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

    }
}