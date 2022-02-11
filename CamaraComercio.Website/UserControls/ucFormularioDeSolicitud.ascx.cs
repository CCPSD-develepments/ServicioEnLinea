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

namespace CamaraComercio.Website.UserControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud'
    public partial class ucFormularioDeSolicitud : EnvioDatosUserControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.dbWeb'
        public CamaraWebsiteEntities dbWeb = new CamaraWebsiteEntities();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.dbWeb'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.dbCom'
        public CamaraComunEntities dbCom = new CamaraComunEntities();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.dbCom'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.socCtrl'
        public SociedadesController socCtrl = new SociedadesController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.socCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.registro'
        public DataAccess.EF.SRM.Registros registro;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.registro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.orgGest'
        public List<ViewRegistrosSocios> orgGest = new List<ViewRegistrosSocios>();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.orgGest'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.transaccion'
        public OFV.Transacciones transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.transaccion'
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
        List<DataAccess.EF.SRM.ReferenciasBancarias> referenciasBancarias;
        List<DataAccess.EF.SRM.ReferenciasComerciales> referenciasComerciales;
        #endregion
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();
        List<ViewRegistrosSocios> PersonasAutorizadas;
        #region Props
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace((string)ViewState["cantidadCertificaciones"])) return 0;
                int.TryParse((string)ViewState["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.CamaraId'
#pragma warning disable CS0108 // 'ucFormularioDeSolicitud.CamaraId' hides inherited member 'EnvioDatosUserControl.CamaraId'. Use the new keyword if hiding was intended.
        public string CamaraId
#pragma warning restore CS0108 // 'ucFormularioDeSolicitud.CamaraId' hides inherited member 'EnvioDatosUserControl.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.Socios'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.RequiereDocs'
        public bool RequiereDocs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.RequiereDocs'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["requiereDocs"])
                            ? Request.QueryString["requiereDocs"] == "1"
                            : false;
            }
        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.ControlLoad(List<KeyValuePair<string, string>>)'
        public override void ControlLoad(List<KeyValuePair<string, string>> args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.ControlLoad(List<KeyValuePair<string, string>>)'
        {
            InitInterface();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.InitInterface()'
        {
            if (!IsValidRequestParameters()) return;
            
            camara = camCtrl.FetchByID(this.CamaraId).First();
            registro = DbContext.Registros.FirstOrDefault(d => d.RegistroId == RegistroId);
            sociedadReg = socCtrl.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);
            usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);

            direccion = DbContext.Direcciones.FirstOrDefault(d => sociedadReg.DireccionId == d.DireccionId);
            sector = dbCom.Sectores.FirstOrDefault(s => s.SectorId == direccion.SectorId);
            if (sector != null)
            {
                ciudad = dbCom.Ciudades.FirstOrDefault(c => c.CiudadId == sector.CiudadId);
            }
            factura = dbWeb.Facturas.FirstOrDefault(t => t.TransaccionId == IdTransaciones);

            serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
            //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
            // Datos del Gestor
            txtSolicitante.Text = transaccion.Solicitante;
            txtNombreCont.Text = transaccion.NombreContacto;
            var user = Membership.GetUser(this.Page.User.Identity.Name);
            if (user != null)
                txtEmail.Text = user.Email;
            txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
            txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
            txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

            // Datos de la sociedad
            txtRazSocial.Text = sociedadReg.NombreSocial;
            txtNoRegistro.Text = sociedadReg.NumeroRegistro.ToString();
            txtDireccionSociedad.Text = string.Format("Ciudad: {0}, Sector: {1}, Calle: {2}, Numero: {3}", ciudad?.Nombre, sector?.Nombre, direccion?.Calle, direccion?.Numero);
            txtTel1.Text = direccion.TelefonoCasa.FormatTelefono();
            txtTel2.Text = direccion.TelefonoOficina.FormatTelefono();
            txtNombreCom.Text = sociedadReg.NombreComercial;
            txtRNCSoc.Text = sociedadReg.Rnc.FormatRnc();
            txtPagWeb.Text = direccion.SitioWeb;
            var estatus = dbCom.EstadoRegistro.Where(a => a.EstadoRegistroId == sociedadReg.EstatusId).FirstOrDefault();
            txtEstadoSociedad.Text = estatus != null ? estatus.Descripcion : String.Empty;

            txtFechaEmision.Text = sociedadReg.FechaEmision.HasValue
                ? sociedadReg.FechaEmision.Value2().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty;
            txtFechaConst.Text = sociedadReg.FechaConstitucion.HasValue
                ? sociedadReg.FechaConstitucion.Value2().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty;
            txtFechaVenc.Text = sociedadReg.FechaVencimiento.HasValue
                ? sociedadReg.FechaVencimiento.Value2().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty;
            txtDuracionSociedad.Text = sociedadReg.DuracionSociedad;

            // Servicio
            txtServicio.Text = serv.Descripcion;

            // Sucursales
            var sucursales = LoadSucursales();
            SetSucursalesDataSource(sucursales);
            /*if(sucursales.Count == 0)
            {
                lbSucursales.Visible = true;
                tblSucursales.Visible = false;
            }*/


            //Socios
            LoadSocios();
            SetSociosDataSource();
            txtTotalSocios.Text = sociedadReg.NumeroSocios.HasValue
                ? sociedadReg.NumeroSocios.Value2().ToString() : "0";
            txtTotalAcciones.Text = sociedadReg.TotalAcciones.ToString();

            //Organo Gestion
            orgGest = LoadOrgGestor();
            SetOrgGestorDataSource();
            txtDuracionDir.Text = sociedadReg.DuraccionDirectiva.HasValue
                ? sociedadReg.DuraccionDirectiva.Value2().ToString() : "";

            // Socios con Firmas autorizadas
            var autorizados = LoadSociosAutorizadosAFirma();
            SetSociosAutorizadosDataSource(autorizados);
            PersonasAutorizadas = autorizados;
            //Load Entes Regulados
            LoadEntesRegulados();
            SetEntesRegDataSource();
            //if(EntesReg.Count == 0)
            //{
            //    lbEntesReg.Visible = true;
            //    tblEntesReg.Visible = false;
            //}
            //Referencias Comerciales
            referenciasComerciales = DbContext.ReferenciasComerciales.Where(a => a.RegistroId == RegistroId).ToList();
            txtReferenciasComerciales.Text = string.Join(",", referenciasComerciales.Select(d => d.Descripcion));
            if (string.IsNullOrEmpty(txtReferenciasComerciales.Text))
                txtReferenciasComerciales.Text = "Referencias Comerciales";

            // Referencias Bancarias

            referenciasBancarias = DbContext.ReferenciasBancarias.Where(a => a.RegistroId == RegistroId).ToList();
            txtRefBancarias.Text = string.Join(",", referenciasBancarias.Select(d => d.BancoDescripcion));
            if (string.IsNullOrEmpty(txtRefBancarias.Text))
                txtRefBancarias.Text = "Referencias Bancarias";

            // Fecha Asamblea
            this.txtFechaAsamb.Text = sociedadReg.FechaAsamblea.HasValue
                ? sociedadReg.FechaAsamblea.Value2().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty;

            var trans = TransaccionesController.GetTransaccionById(IdTransaciones);
            if (string.IsNullOrEmpty(trans.FolderId))
                CreateFolderOnShareBase(trans.TransaccionId);
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
            else
            {
                return true; // Resultado simulado...
            }
        }

        private void SetSociosDataSource()
        {
            sociosRep.DataSource = Socios;
            sociosRep.DataBind();
        }

        private void SetOrgGestorDataSource()
        {
            orgGestionRepeater.DataSource = orgGest;
            orgGestionRepeater.DataBind();
        }

        private void SetSociosAutorizadosDataSource(List<ViewRegistrosSocios> SociosAut)
        {
            sociosAutRep.DataSource = SociosAut;
            sociosAutRep.DataBind();
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

        private void SetSucursalesDataSource(List<Suscursales> sucursales)
        {
            sucursalRepeater.DataSource = sucursales;
            sucursalRepeater.DataBind();
        }

        private List<Suscursales> LoadSucursales()
        {
            var sucursales = DbContext.Suscursales.Where(s => s.SociedadId == this.SociedadId).ToList();
            return sucursales;
        }

        private List<ViewRegistrosSocios> LoadOrgGestor()
        {
            var registroSociosController = new RegistrosSociosController();
            return registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "C");
            
        }

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

        private void SetEntesRegDataSource()
        {
            entesRegRep.DataSource = EntesReg;
            entesRegRep.DataBind();
        }

        private byte[] ObtenerImagenPdf()
        {
            System.IO.TextWriter _writer = new System.IO.StringWriter();
            HttpContext.Current.Server.Execute(Request.Url.PathAndQuery, _writer, false);
            string html = _writer.ToString();

            IronPdf.HtmlToPdf renderer = new IronPdf.HtmlToPdf();
            var pdf = renderer.RenderHtmlAsPdf(html);
            byte[] data = pdf.BinaryData;

            return data;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.LoadEntesRegulados()'
        public void LoadEntesRegulados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.LoadEntesRegulados()'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.ValidateNext()'
        public override bool ValidateNext()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.ValidateNext()'
        {
            if (running) return false;
            running = true;
            var doc = new TransaccionesDocumentos
            {
                TransaccionId = transaccion.TransaccionId,
                Usuario = this.Page.User.Identity.Name,
                CantidadCopia = 0,
                CantidadOriginal = 1,
                Deleted = false,
                Descripcion = "FORMULARIO DE SOLICITUD",
                DocContent = ObtenerImagenPdf(),
                DocContentType = "application/pdf",
                DocSeleccionadoId = 0,
                FechaDocumento = DateTime.Now,
                FechaEnvio = DateTime.Now,
                NombreArchivo =
                    string.Format("Formulario Solicitud {0}", IdTransaciones),
                Nombre = string.Format("FormularioSolicitud{0}.pdf", IdTransaciones),
                RowId = Guid.NewGuid(),
                TipoDocumentoId = 1560
            };
            dbWeb.TransaccionesDocumentos.AddObject(doc);

            if (Helper.ShareBaseEnabled)
            {
                var client = new OnlineChamberServiceClient();
                BasicOperationResultOfstring val;
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    string DocTypeName = dbCom.TipoDocumento.First(i => i.TipoDocumentoId == doc.TipoDocumentoId).DocumentoOnBaseDesc;

                    var d = new DocumentData()
                    {
                        DocumentTypeName = GetSafeFilename(DocTypeName),
                        Base64 = Convert.ToBase64String(doc.DocContent)
                    };
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                    val = client.CreateDocumentOnSharebase(long.Parse(transaccion.FolderId), doc.TransaccionId.ToString(), d);
                }
                client.Close();

                if (!val.Success)
                {
                    Master.ShowMessageError("Error al procesar formulario de solicitud, Intentelo mas tarde!");
                    return false;
                }
                else
                {
                    doc.SBDocumentId = val.Entity;
                    dbWeb.SaveChanges();
                }
            }

            return true;
        }

        bool running = false;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.ConfirmarDatos_Click(object, EventArgs)'
        protected void ConfirmarDatos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.ConfirmarDatos_Click(object, EventArgs)'
        {
            ValidateNext();

            if (RequiereDocs)
                Response.Redirect("~/Empresas/EnvioDatos.aspx" + DefaultQueryString);
            else
                Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.GetSafeFilename(string)'
        public string GetSafeFilename(string filename)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucFormularioDeSolicitud.GetSafeFilename(string)'
        {
            return string.Join("_", filename.Split(System.IO.Path.GetInvalidFileNameChars()));
        }
    }
}