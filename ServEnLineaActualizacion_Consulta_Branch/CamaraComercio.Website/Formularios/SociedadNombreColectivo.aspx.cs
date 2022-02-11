using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.ServiceModel.Channels;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Empresas;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CamaraComercio.Website.WSShareBase;
using System.Globalization;
using SRM = CamaraComercio.DataAccess.EF.SRM;


namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo'
    public partial class SociedadNombreColectivo : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.socCtrl'
        public SociedadesController socCtrl = new SociedadesController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.socCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.registroSociosCtrl'
        public RegistrosSociosController registroSociosCtrl = new RegistrosSociosController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.registroSociosCtrl'

#pragma warning disable CS0169 // The field 'SociedadNombreColectivo.referenciasBancarias' is never used
        List<DataAccess.EF.SRM.ReferenciasBancarias> referenciasBancarias;
#pragma warning restore CS0169 // The field 'SociedadNombreColectivo.referenciasBancarias' is never used
#pragma warning disable CS0169 // The field 'SociedadNombreColectivo.referenciasComerciales' is never used
        List<DataAccess.EF.SRM.ReferenciasComerciales> referenciasComerciales;
#pragma warning restore CS0169 // The field 'SociedadNombreColectivo.referenciasComerciales' is never used
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();
#pragma warning disable CS0169 // The field 'SociedadNombreColectivo.PersonasAutorizadas' is never used
        List<ViewRegistrosSocios> PersonasAutorizadas;
#pragma warning restore CS0169 // The field 'SociedadNombreColectivo.PersonasAutorizadas' is never used
        Servicio serv;
        TipoServicio tipServ;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.orgGest'
        public List<ViewRegistrosSocios> orgGest;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.orgGest'
        #endregion

        #region Props
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.camara'
        public Camaras camara
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.camara'
        {
            get
            {
                return camCtrl.FetchByID(this.CamaraId).First();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.sociedadReg'
        public cvw_SociedadesRegistros sociedadReg
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.sociedadReg'
        {
            get
            {
                return socCtrl.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.registro'
        public DataAccess.EF.SRM.Registros registro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.registro'
        {
            get
            {
                return DbContext.Registros.FirstOrDefault(d => d.RegistroId == RegistroId);
            }
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.usuarioActual'
        public OficinaVirtualUserProfile usuarioActual
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.usuarioActual'
        {
            get
            {
                return OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);
            }
        }





#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.direccion'
        public DataAccess.EF.SRM.Direcciones direccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.direccion'
        {
            get
            {
                return DbContext.Direcciones.FirstOrDefault(d => sociedadReg.DireccionId == d.DireccionId);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.sector'
        public DataAccess.EF.CamaraComun.Sectores sector
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.sector'
        {
            get
            {
                return dbCom.Sectores.FirstOrDefault(s => s.SectorId == direccion.SectorId);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.ciudad'
        public DataAccess.EF.CamaraComun.Ciudades ciudad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.ciudad'
        {
            get
            {
                if (sector == null) return null;
                return dbCom.Ciudades.FirstOrDefault(c => c.CiudadId == sector.CiudadId);
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.CamaraId'
#pragma warning disable CS0108 // 'SociedadNombreColectivo.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
        public string CamaraId
#pragma warning restore CS0108 // 'SociedadNombreColectivo.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }

        //public int IdTransacciones
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(Request.QueryString["IdTransaccion"])) return 0;
        //        int.TryParse(Request.QueryString["IdTransaccion"], out int transaccionId);
        //        return transaccionId;
        //    }
        //}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["cantidadCertificaciones"])) return 0;
                int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.Socios'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.Page_Load(object, EventArgs)'
#pragma warning disable CS0108 // 'SociedadNombreColectivo.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS0108 // 'SociedadNombreColectivo.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.InitInterface()'
        {
            if (!IsValidRequestParameters()) return;

            if (transaccion.ServicioId == 650)
            {
                bool a = SetFormularioModelViewOFV(transaccion.TransaccionId, RegistroId, SociedadId);
                if (!a)
                {
                    return;
                }
            }
            else
            {
                bool a = SetFormularioModelViewSRM(transaccion.TransaccionId, RegistroId, SociedadId);
                if (!a)
                {
                    return;
                }
            }
            var dbSRM = new SRM.CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(transaccion.CamaraId));
            var sucursales = LoadSucursales();
            var estatus = dbCom.EstadoRegistro.FirstOrDefault(a => a.EstadoRegistroId == Formulario.Sociedad.EstatusId);
            serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
            tipServ = dbCom.TipoServicio.FirstOrDefault(s => serv.TipoServicioId == s.TipoServicioId);
            //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
            // Datos del Gestor
            //txtSolicitante.Text = transaccion.Solicitante.ToUpper();
            txtNombreCont.Text = transaccion.NombreContacto.ToUpper();
            //var user = Membership.GetUser(User.Identity.Name);
            //if (user != null) txtEmail.Text = user.Email;

            //Actualizacion de datos: solo para el servicioid= 650, 398, y 401, traer el correo desde transacciones:
            if (transaccion.ServicioId == 650 || transaccion.ServicioId == 401 || transaccion.ServicioId == 398)
            {
                txtEmail.Text = transaccion.CorreoContacto;
                this.Formulario.Registro.DireccionEmail = transaccion.CorreoEmpresa;

                //OfvDbContext = new CamaraWebsiteEntities();

                //var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transaccion.TransaccionId);
                //if (ofvRegistro != null)
                //{
                //    this.Formulario.Registro.DireccionEmail = ofvRegistro.DireccionEmail;
                //}

                if (transaccion.CorreoEmpresa == null)
                {
                    var user = Membership.GetUser(User.Identity.Name);

                    if (user != null)
                    {
                        txtEmail.Text = user.Email;
                    }
                }
            }
            else// condicion temporal //ep: 2021-10-29
            {
                var user = Membership.GetUser(User.Identity.Name);
                if (user != null)
                {
                    txtEmail.Text = user.Email;
                }
            }
            //txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
            txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();

            txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

            // Datos de la sociedad
            txtRazSocial.Text = this.Formulario.Sociedad.NombreSocial;
            txtTipoSocietario.Text = dbCom.TipoSociedad.FirstOrDefault(x => x.TipoSociedadId == this.Formulario.Sociedad.TipoSociedadId).Descripcion;
            txtNoRegistro.Text = string.Format("{0}SD", this.Formulario.Registro.RegistroMercantil);
            txtRNCSoc.Text = !string.IsNullOrWhiteSpace(this.Formulario.Sociedad.Rnc) 
                ? this.Formulario.Sociedad.Rnc.FormatRnc() : "N/A";
            var direcionCalle = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionCalle)
                ? this.Formulario.Registro.DireccionCalle + "," : "";
            var direccionSector = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionSector)
                ? this.Formulario.Registro.DireccionSector + "," : "";
            var direccionCiudad = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionCiudad)
                ? this.Formulario.Registro.DireccionCiudad + "." : "";

            txtDireccionSociedad.Text = string.Format(
                "{0} {1} {2}",
                direcionCalle,
                direccionSector,
                direccionCiudad
                );

            txtTel1.Text = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionTelefonoCasa) 
                ? this.Formulario.Registro.DireccionTelefonoCasa.FormatTelefono() : "N/A";
            txtTel2.Text = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionTelefonoOficina) 
                ? this.Formulario.Registro.DireccionTelefonoOficina.FormatTelefono() : "N/A";
            txtCorreoSociedad.Text = IsNullorEmptyNA(this.Formulario.Registro.DireccionEmail);
            txtPagWeb.Text = IsNullorEmptyNA(this.Formulario.Registro.DireccionSitioWeb);
            if (Formulario.Sociedad.NacionalidadId != null)
                txtNacionalidad.Text = dbCom.Paises.FirstOrDefault(c => c.PaisId == Formulario.Sociedad.NacionalidadId).Nombre;
            else
                txtNacionalidad.Text = "N/A";
            txtFechaEmision.Text = FormatoFecha(this.Formulario.Registro.FechaEmision);
            txtFechaVenc.Text = FormatoFecha(this.Formulario.Registro.FechaVencimiento);
            txtFechaConst.Text = FormatoFecha(this.Formulario.Sociedad.FechaConstitucion);
            txtDuracionSociedad.Text = this.Formulario.Sociedad.DuracionSociedad.Equals("DEFINIDA") ? this.Formulario.Sociedad.DuraccionDirectiva.ToString() : this.Formulario.Sociedad.DuracionSociedad;
            txtEstadoSociedad.Text = estatus != null ? estatus.Descripcion : "N/A";
            // Empleadoas
            txtMasculino.Text = this.Formulario.Registro.EmpleadosMasculinos.ToString();
            txtFemenino.Text = this.Formulario.Registro.EmpleadosFemeninos.ToString();
            txtTotal.Text = this.Formulario.Registro.EmpleadosTotal.ToString();
            //nombre comercial
            txtNombreComercial.Text = IsNullorEmptyNA(this.Formulario.Registro.NombreComercial);
            txtRegitroNComercial.Text = IsNullorEmptyNA(this.Formulario.Registro.RegistroNombreComercial);
            // desc
            txtDesc.Text = IsNullorEmptyNA(this.Formulario.Registro.ActividadNegocio);
            var actividades = dbSRM.RegistrosActividades.Where(c => c.RegistroId == Formulario.Registro.SrmRegistroId);
            foreach (var item in actividades)
            {
                if (string.IsNullOrWhiteSpace(txtActividad.Text))
                    txtActividad.Text = item.TipoActividadDescripcion + ", ";
                else
                    txtActividad.Text += item.TipoActividadDescripcion + ", ";

            }
            if (actividades.Count() == 0)
                txtActividad.Text = "N/A";
            else if (!string.IsNullOrWhiteSpace(txtActividad.Text))
            {
                int fin;
                fin = txtActividad.Text.Length - 2;
                var result = txtActividad.Text.Substring(0, fin);
                txtActividad.Text = result;
                txtActividad.Text = txtActividad.Text + ".";
            }
            //Capital social
            txtMonto.Text = string.Format("{0:c}", this.Formulario.Registro.CapitalAutorizado != null ? this.Formulario.Registro.CapitalAutorizado:0);
            txtMoneda.Text = dbCom.TipoMoneda.FirstOrDefault(c => c.TipoMonedaId == Formulario.Registro.TipoMonedaCapitalAutorizado).Abreviatura;
            //
            //txtDuracionOrganoGestor.Text = this.Formulario.Sociedad.DuracionSociedad;
            this.txtFechaAsamb.Text = FormatoFecha(Formulario.Sociedad.FechaAsamblea);

            // Servicio
            txtServicio.Text = tipServ.Descripcion.ToUpper() + " - " + serv.Descripcion;

            // Sucursales
            SetSucursalesDataSource(sucursales);
            /*if(sucursales.Count == 0)
            {
                lbSucursales.Visible = true;
                tblSucursales.Visible = false;
            }*/


            //Socios
            SetSociosDataSource(Formulario.Socios.ToList());
            txtTotalSocios.Text = Convert.ToString(Formulario.Registro.NumeroSocios) ?? "0";
            txtTotalAcciones.Text = Formulario.Registro.TotalAcciones.ToString();
            SetProducto(dbSRM.Productos.Where(p => p.RegistroId == Formulario.Registro.SrmRegistroId).ToList());
            //OrganoGestion
            SetOrgGestorDataSource(Formulario.OrganoGestion.ToList());

            // Socios con Firmas autorizadas
            var autorizados = Formulario.SociosFirmas.ToList();
            SetSociosAutorizadosDataSource(autorizados);
            SetComisario(Formulario.Comisarios.ToList());
            //Load Entes Regulados
            LoadEntesRegulados();
            SetEntesRegDataSource();

            //if(EntesReg.Count == 0)
            //{
            //    lbEntesReg.Visible = true;
            //    tblEntesReg.Visible = false;
            //}
            //Referencias Comerciales
            txtReferenciasComerciales.Text = string.Join(",", Formulario.ReferenciaComercial.Select(d => d.Descripcion));
            if (string.IsNullOrEmpty(txtReferenciasComerciales.Text))
                txtReferenciasComerciales.Text = "N/A";

            // Referencias Bancarias
            txtRefBancarias.Text = string.Join(",", Formulario.ReferenciaBancaria.Select(d => d.NombreBanco));
            if (string.IsNullOrEmpty(txtRefBancarias.Text))
                txtRefBancarias.Text = "N/A";

            var trans = TransaccionesController.GetTransaccionById(IdTransaciones);
            if (string.IsNullOrEmpty(trans.FolderId))
                CreateFolderOnShareBase(trans.TransaccionId);
        }

        private string FormatoFecha(DateTime? fecha)
        {
            string result = "N/A";

            if (fecha != null)
                result = string.Format("{0:dd/MM/yyyy}", fecha);

            return result;
        }

        private string IsNullorEmptyNA(string val)
        {
            string result = !string.IsNullOrWhiteSpace(val)
                ? val : "N/A";
            return result;
        }

        private void SetProducto(List<SRM.Productos> productos)
        {
            if (productos.Count() < 1)
            {
                this.productos.Visible = false;
            }
            else
            {
                productosRepeater.DataSource = productos;
                productosRepeater.DataBind();
            }
        }

        private void SetComisario(List<Comisario> comisarios)
        {
            if (comisarios.Count() < 1)
            {
                div4.Visible = false;
            }
            else
            {
                sociosComisario.DataSource = comisarios;
                sociosComisario.DataBind();
            }
        }

        private void SetSociosDataSource(List<Formularios.Socio> socios)
        {
            if (socios.Count() < 1)
            {
                div1.Visible = false;
            }
            else
            {
                sociosRep.DataSource = socios;
                sociosRep.DataBind();
            }
        }

        private void SetOrgGestorDataSource(List<OrganoGestion> orgGestion)
        {
            if (orgGestion.Count() < 1)
            {
                div2.Visible = false;
            }
            else
            {
                orgGestionRepeater.DataSource = orgGestion;
                orgGestionRepeater.DataBind();
            }
        }

        private void SetSucursalesDataSource(List<Suscursales> sucursales)
        {
            if (sucursales.Count() < 1)
            {
                this.sucursales.Visible = false;
            }
            else
            {
                sucursalRepeater.DataSource = sucursales;
                sucursalRepeater.DataBind();
            }
        }

        private List<Suscursales> LoadSucursales()
        {
            var sucursales = DbContext.Suscursales.Where(s => s.SociedadId == this.SociedadId).ToList();
            return sucursales;
        }

        //private void LoadOrgGestor()
        //{
        //    var registroSociosController = new RegistrosSociosController();
        //    var sociosAdministracion = 
        //    orgGest = new List<ViewRegistrosSocios>();

        //    foreach (var socio in sociosAdministracion)
        //        if (!orgGest.Any(d => d.SocioId == socio.SocioId)) orgGest.Add(socio);
        //}

        private void LoadSocios()
        {
            var registroSociosController = new RegistrosSociosController();
            var sociosAccionistas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "A");

            Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosAccionistas)
            {
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);
            }
        }

        private void SetSociosAutorizadosDataSource(List<SociosFirmas> SociosAut)
        {
            if (SociosAut.Count() < 1)
            {
                div3.Visible = false;
            }
            else
            {
                sociosAutRep.DataSource = SociosAut;
                sociosAutRep.DataBind();
            }
        }

        private void SetEntesRegDataSource()
        {
            if (EntesReg.Count() < 1)
            {
                entesRegTbl.Visible = false;
            }
            else
            {
                entesRegRep.DataSource = EntesReg;
                entesRegRep.DataBind();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.LoadEntesRegulados()'
        public void LoadEntesRegulados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.LoadEntesRegulados()'
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

        private List<ViewRegistrosSocios> LoadSociosAutorizadosAFirma()
        {
            var registroSociosController = new RegistrosSociosController();

            var sociosFirmasAutorizadas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "F");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosFirmasAutorizadas)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }
        private bool IsValidRequestParameters()
        {
            if (SociedadId <= 0)
            {
                txtMessageTitle.InnerText = "Debe especificar la Empresa";
                mainMultiView.SetActiveView(failView);
                return false;
            }

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

        private List<ViewRegistrosSocios> LoadOrganosGestion()
        {
            var registroSociosController = new RegistrosSociosController();
            return registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "C");
        }

#pragma warning disable CS0108 // 'SociedadNombreColectivo.GetSafeFilename(string)' hides inherited member 'EnvioDatos.GetSafeFilename(string)'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.GetSafeFilename(string)'
        public string GetSafeFilename(string filename)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadNombreColectivo.GetSafeFilename(string)'
#pragma warning restore CS0108 // 'SociedadNombreColectivo.GetSafeFilename(string)' hides inherited member 'EnvioDatos.GetSafeFilename(string)'. Use the new keyword if hiding was intended.
        {
            return string.Join("_", filename.Split(System.IO.Path.GetInvalidFileNameChars()));
        }
    }
}