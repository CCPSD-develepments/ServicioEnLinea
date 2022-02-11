using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using CamaraComercio.Website.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Telerik.Web.UI;
using CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Transactions;
using Image = System.Web.UI.WebControls.Image;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página para la revisión de documentos requeridos en una transacción
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class RevisionDocumentos : EnvioDatosPage
    {
        CamaraWebsiteEntities dbOFV = null;
        private int TransaccionId
        {
            get
            {
                int r;
                int.TryParse(Request.QueryString["nSolicitud"], out r);
                return r != 0 ? r : 0;
            }

            set
            {
                ViewState["TranssaccionId"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.PersonaId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["PersonaId"]) ?
                    int.Parse(Request.QueryString["PersonaId"])
                              : 0;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.TipoSociedadId'
        public int TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.TipoSociedadId'
        {
            get
            {
                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId]"]) && nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);
                    if (transa != null) return transa.TipoSociedadId;
                    else return 0;
                }

                else
                {
                    return !String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])
                               ? int.Parse(Request.QueryString["TipoSociedadId"])
                               : 0;
                }
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.TipoServicioId'
        public int TipoServicioId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.TipoServicioId'
        {
            get
            {
                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (String.IsNullOrWhiteSpace(Request.QueryString["TipoServicioId"]) && nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var comundb = new CamaraComunEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);
                    var tipoServicioId = comundb.Servicio.FirstOrDefault(x => x.ServicioId == transa.ServicioId);
                    if (transa != null) return tipoServicioId.TipoServicioId;

                    else return 0;
                }
                else
                {
                    return !String.IsNullOrWhiteSpace(Request.QueryString["TipoServicioId"])
                               ? int.Parse(Request.QueryString["TipoServicioId"])
                               : 0;
                }

            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.RegistroId'
        {
            get
            {
                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (String.IsNullOrWhiteSpace(Request.QueryString["RegistroId"]) && nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);
                    if (transa != null) return transa.RegistroId;
                    else return 0;
                }
                else
                {
                    return !String.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])
                               ? int.Parse(Request.QueryString["RegistroId"])
                               : 0;
                }
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.EsCertificacion'
        public bool EsCertificacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.EsCertificacion'
        {
            get
            {
                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (String.IsNullOrWhiteSpace(Request.QueryString["EsCertificacion"]) && nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);
                    if (transa.ServicioId == Helper.ServicioCopiasCertificadasId) return true;
                    else return false;
                }
                else
                {
                    return !String.IsNullOrWhiteSpace(Request.QueryString["EsCertificacion"])
                                ? Request.QueryString["esCertificacion"] == "1"
                                : false;

                }
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.BorrarDocumentos'
        public bool BorrarDocumentos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.BorrarDocumentos'
        {
            get
            {
#pragma warning disable CS0168 // The variable 'nSol' is declared but never used
                string nSol;
#pragma warning restore CS0168 // The variable 'nSol' is declared but never used
                if (String.IsNullOrWhiteSpace(Request.QueryString["BorrarDocumentos"]))
                {
                    return false;
                }
                else
                {
                    return Request.QueryString["BorrarDocumentos"].Equals("true") ? true : false;

                }
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.FolderId'
        public string FolderId;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.FolderId'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.Page_Load(object, EventArgs)'
        {

            try
            { 

            if (IsPostBack) return;

            // se utulisa para saber si la transacion esta devuelta por problema
            var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
          var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == this.TransaccionId && x.DesdeOfv)?.VieneProblemas == true ? true : false;
            //
           // rblImpreso.Visible = true;
            lblImpresoDoc.Visible = true;
            

            LimpiarObjetosSession();


            // Creacion de la transaccion si es un servicio de Registro Duplicado
            //if(this.TipoServicioId == 5)
            //{
            //    int modeloId = 0;
            //    int servicioId = 30;

            //    if (!RegisterTransaction(servicioId, modeloId > 0 ? modeloId : (int?)null))
            //        return;

            //    DefaultQueryString += String.Format("nSolicitud={0}&EsCertificacion=1&EntregaDigital={1}",
            //                                   TransaccionId, false);

            //    Session["DocumentosSeleccionados"] = null;

            //}


            //Objetos de acceso a datos
            var db = new CamaraWebsiteEntities();
            var dbComun = new Comun.CamaraComunEntities();
#pragma warning disable CS0219 // The variable 'saved' is assigned but its value is never used
            bool saved = false;
#pragma warning restore CS0219 // The variable 'saved' is assigned but its value is never used

            //Transaccion
            int transaccionId;
            int.TryParse(Request.QueryString["nSolicitud"], out transaccionId);

            //var padreUser = User.Identity.Name.ToLower();

            //var rep = new DataAccess.EF.Membership.UsuariosController();
            //var usuariosHijo = rep.FetchByUsuarioPadre(User.Identity.Name, "1");
            //var hijos = new List<string>();
            //foreach (var item in usuariosHijo)
            //{
            //    hijos.Add(item.UserName.ToLower());
            //}

            var trans = (from t in db.Transacciones
                         where t.TransaccionId == transaccionId && (t.UserName.Equals(User.Identity.Name.ToLower())/* || hijos.Contains(t.UserName)*/)
                         select t).FirstOrDefault();

            if (trans == null) return;
            if (trans?.ServicioId != null)
            {
                var servicios = dbComun.Servicio.FirstOrDefault(s => s.ServicioId == (trans.ServicioId != 0? trans.ServicioId : 0) && s.SiteVisible);
                var a = new List<Servicio>();
                if (servicios != null)
                {
                    a.Add(servicios);
                    this.rpServiciosSeleccionados.DataSource = a;
                    this.rpServiciosSeleccionados.DataBind();
                }
            }

            if (trSDQ)
            {
                //using (TransactionScope tsTransScope = new TransactionScope())
                //{
                dbOFV = new CamaraWebsiteEntities();
                BorrarTransaccionesDocumentos(TransaccionId);
                BorrarTransaccionesDocumentoDescargas(TransaccionId);
                BorrarTransaccionesDocumentoSeleccionado(TransaccionId);

                if (Helper.ShareBaseEnabled && trans.FolderId != null)
                {
                    if (!BorrarFolderEnShareBase(trans.FolderId))
                    {
                        Master.ShowMessageError("Error en sharabase.");
                        return;
                    }
                }
                dbOFV.SaveChanges();
                //tsTransScope.Complete();
                //}
            }

            if (this.TipoServicioId == Helper.ServicioCopiasCertificadasId)
            {
               // rblImpreso.Visible = true;
                lblImpresoDoc.Visible = true;

            }
            initialazerRevision(TransaccionId);

            if (string.IsNullOrEmpty(trans.FolderId) && Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    var resp = client.CreateFolderOnSharebase(trans.TransaccionId.ToString(), Helper.NombreCarpetaShareBase);
                    trans.FolderId = resp.Entity;
                    db.SaveChanges();
                    client.Close();
                }
            }
            else if (trSDQ && Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    var resp = client.CreateFolderOnSharebase(trans.TransaccionId.ToString(), Helper.NombreCarpetaShareBase);
                    trans.FolderId = resp.Entity;
                    trans.EsCasoAperturado = false;
                    db.SaveChanges();
                    client.Close();
                }
            }

            //pnlAgregarDocumento.Visible = !Helper.HabilarPagoTarjeta(trans.ServicioId); ~// Comentado temporalmente por Wagner~

            // Hide controles de cantidad de certificaciones
            if (!EsCertificacion || TipoServicioId == 3)
            {
                certificacionDiv.Visible = false;

                lblIDepositarCansilleria.Visible = true;
                rblDepositarCansilleria.Visible = true;
                if (this.TipoServicioId == 39)
                {
                    certificacionDiv.Visible = true;
                }
                //lbCertificaciones.Visible = false;
                //txtCantidadCertificaciones.Visible = false;
                if (this.TipoSociedadId == 7 && this.TipoServicioId != 741)
                {
                    certificacionDiv.Visible = false;
                    lblIDepositarCansilleria.Visible = false;
                    rblDepositarCansilleria.Visible = false;
                }
                if (this.TipoServicioId == 38)
                {
                    certificacionDiv.Visible = false;
                    lblIDepositarCansilleria.Visible = false;
                    rblDepositarCansilleria.Visible = false;
                }
                if (trans != null)
                {
                    if (trans.ServicioId == 398 || trans.ServicioId == 421 )
                    {
                        certificacionDiv.Visible = false;
                        lblIDepositarCansilleria.Visible = true;
                        rblDepositarCansilleria.Visible = true;

                    }
                }
                if (trans != null)
                {
                    if (trans.ServicioId == 421)
                    {
                        certificacionDiv.Visible = false;
                        lblIDepositarCansilleria.Visible = true;
                        rblDepositarCansilleria.Visible = true;

                    }
                    if (trans.ServicioId == 686)
                    {
                        lblIDepositarCansilleria.Visible = false;
                        rblDepositarCansilleria.Visible = false;
                    }
                    if (trans.ServicioId == 741)
                    {
                        lblIDepositarCansilleria.Visible = false;
                        rblDepositarCansilleria.Visible = false;
                    }
                }
                var sId = trans.GetServicioTransacciones();
                if (sId.Count != 0)
                {
                    if (sId[0] == 401)
                    {
                        certificacionDiv.Visible = false;
                        lblIDepositarCansilleria.Visible = true;
                        rblDepositarCansilleria.Visible = true;

                    }
                }

                if (trans.EsCertificacion.HasValue)
                {
                    certificacionDiv.Visible = true;
                    lblImpresoDoc.Visible = true;
                 //   rblImpreso.Visible = true;
                    lblIDepositarCansilleria.Visible = false;
                    rblDepositarCansilleria.Visible = false;

                }
            }
            else
            {
                if (TipoServicioId == Helper.ServicioCopiasCertificadasId)
                {
                    lbCertificaciones.Text = "Cuántas copias Certificadas quiere?";
                }
                else
                {
                    lbCertificaciones.Text = "Cuántas Certificaciones quiere?";
                }
                txtCantidadCertificaciones.Visible = true;

                var sessKey = string.Format("{0}", this.IdTransaciones);
                if (Session[sessKey + "_cantidadCertificaciones"] != null)
                {
                    txtCantidadCertificaciones.Text = (string)Session[sessKey + "_cantidadCertificaciones"];
                }
                else if (TipoServicioId == 38)
                {
                    certificacionDiv.Visible = false;
                    lblIDepositarCansilleria.Visible = false;
                    rblDepositarCansilleria.Visible = false;
                }
                else if (TipoServicioId == 17)
                {
                    certificacionDiv.Visible = false;
                }
                else
                {
                    certificacionDiv.Visible = true;
                   // rblImpreso.Visible = true;
                    lblImpresoDoc.Visible = true;
                    lblIDepositarCansilleria.Visible = true;
                    rblDepositarCansilleria.Visible = true;

                }
            }
            if (trans.EstatusTransId == 15)
            {
                trans.EstatusTransId = Helper.EstatusTransIdNuevo;
                if(trans.ServicioId == 686 || trans.ServicioId == 741)
                {
                    var empAsign = db.EmpresasPorUsuario.FirstOrDefault(x => x.TransaccionId.Value == trans.TransaccionId);
                    if (empAsign != null)
                    {
                        empAsign.Estado = 1;
                    }
                }
                db.SaveChanges();
            }

            //Variable de servicios solicitados
            var servicioIds = trans.GetServicioTransacciones();

            //Tipo Sociedad ID
            if (trans.TipoSociedadId == 0)
                trans.TipoSociedadId = 2;

            hfTipoSociedadId.Value = trans.TipoSociedadId.ToString();

            //Header
            if (trans.TipoSociedadId != 7)
            {
                var registro = db.Registros.Where(r => r.RegistroId == trans.RegistroId).FirstOrDefault();
                if (registro != null)
                {
                    if (registro.RegistroMercantil.HasValue && registro.RegistroMercantil > 0)
                    {
                        var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                        var empresa = dbSrm.SociedadesRegistros
                            .Where(s => s.NumeroRegistro == registro.RegistroMercantil).FirstOrDefault();

                        if (empresa != null)
                        {
                            this.lblNombreEmpresa.Text = empresa.Sociedades.NombreSocial;
                            hfTipoSociedadId.Value = empresa.Sociedades.TipoSociedadId.ToString();
                        }
                    }
                    else
                    {
                        var sociedad = db.Sociedades.Where(s => s.RegistroId == registro.RegistroId).FirstOrDefault();
                        this.lblNombreEmpresa.Text = this.lblNombreEmpresa.Text = sociedad.NombreSocial;
                    }
                }
            }
            else
            {

                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var empresa = dbSrm.PersonasRegistros
                    .Where(s => s.NumeroRegistro == trans.NumeroRegistro).FirstOrDefault();

                if (empresa != null)
                {
                    string nombrecompleto = string.Format("{0} {1} {2} {3} ", empresa.Personas.PrimerNombre, empresa.Personas.SegundoNombre
                        , empresa.Personas.PrimerApellido, empresa.Personas.SegundoApellido);
                    this.lblNombreEmpresa.Text = nombrecompleto;
                    hfTipoSociedadId.Value = trans.TipoSociedadId.ToString();
                }
                else
                {
                    this.lblNombreEmpresa.Text = trans.NombreSocialPersona;
                    hfTipoSociedadId.Value = trans.TipoSociedadId.ToString();
                }
            }

            //Tipo de Sociedad
            /*var tipo = dbComun.TipoSociedad.Where(c => c.TipoSociedadId == this.TipoSociedadID);
            if (tipo.Count() > 0)
                this.litTipoEmpresa.Text = tipo.First().Etiqueta;*/

            //Servicio(s)
            this.FormaEntrega = Request.QueryString["formaEntrega"];
            Session["Servicios"] = servicioIds;
            if (servicioIds.Count > 0 && servicioIds.FirstOrDefault() > 0)
            {
                //Listado de servicios
                var servicios = dbComun.Servicio.Where(s => servicioIds.Contains(s.ServicioId) && s.SiteVisible);
                //this.rpServiciosSeleccionados.DataSource = servicios;
                //this.rpServiciosSeleccionados.DataBind();

                var tipoSocId = (trans.TipoSociedadId > 0)
                                    ? trans.TipoSociedadId
                                    : this.TipoSociedadID;

                //Copias exoneradas
                var servSection = (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
                var qry = servSection.Servicios.Where(s => s.TipoSociedadId == tipoSocId)
                                     .Select(s => s.ServicioConstitucionId).ToList();
                if (qry.Count() > 0)
                {
                    if (servicios.Count() > 0 && qry.Contains(servicios.FirstOrDefault().ServicioId))
                    {
                        this.hfCantExOriginal.Value = Helper.CantidadOriginalGratisNuevaEmpresa.ToString();
                        this.hfCantExCopia.Value = Helper.CantidadCopiasGratisNuevaEmpresa.ToString();

                        //Solo se muestra este aviso si la forma de entrega es física
                        if (this.FormaEntrega == "F")
                            this.litCopiasExoneradas.Visible = true;
                    }
                }
            }

            Int32 nSolicitud;
            if (this.TransaccionId > 0)
                nSolicitud = this.TransaccionId;
            else
                if (!Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud)) throw new Exception("No tiene numero de solicitud");
            //Aqui grabo el log de la transaccion que se creo
            LogTransaccionesMethods.GrabarLogTransacciones(nSolicitud, Request.RawUrl, false, User.Identity.Name);

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }
        }

        private void BorrarTransaccionesDocumentoSeleccionado(int transaccionId)
        {
            var trOrigen = (from transaccion in dbOFV.TransaccionDocSeleccionado
                            where transaccion.TransaccionId.Equals(transaccionId)
                            select transaccion);

            foreach (var item in trOrigen)
                dbOFV.TransaccionDocSeleccionado.DeleteObject(item);
        }

        private void BorrarTransaccionesDocumentoDescargas(int transaccionId)
        {
            var docDescarga = from fac in dbOFV.TransaccionesDocDescargas
                              where fac.TransaccionId.Equals(transaccionId)
                              select fac;

            foreach (var item in docDescarga)
                dbOFV.TransaccionesDocDescargas.DeleteObject(item);
        }
        private bool BorrarFolderEnShareBase(string FoldId)
        {
            if (Helper.ShareBaseEnabled)
            {
                if (Helper.ShareBaseEnabled && FoldId != null)
                {
                    var client = new WSShareBase.OnlineChamberServiceClient();
                    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                    {
                        var httpRequestProperty = new HttpRequestMessageProperty();
                        httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                        var resp = client.DeleteFolderOnSharebase(long.Parse(FoldId));
                        return resp.Success;
                    }
                }
            }
            return true;
        }
        private void BorrarTransaccionesDocumentos(int transaccionId)
        {
            var doc = dbOFV.TransaccionesDocumentos.
                      Where(c => c.TransaccionId == transaccionId);

            foreach (var item in doc)
                dbOFV.TransaccionesDocumentos.DeleteObject(item);
        }

        private void initialazerRevision(int transaccionId)
        {
            var ofvDB = new CamaraWebsiteEntities();
            var transa = ofvDB.Transacciones.FirstOrDefault(x => x.TransaccionId == transaccionId);
            if (transa != null)
            {
                if (txtCantidadCertificaciones.Visible)
                    txtCantidadCertificaciones.Text = transa.CantidadCopiaCertificaciones != null ? transa.CantidadCopiaCertificaciones.ToString() : 1.ToString();
                //if (rblImpreso.Visible)
                //    rblImpreso.SelectedValue = transa.ImprimirCopias == true ? "1" : transa.ImprimirCopias == null ? "" : "0";
                if (txtNombreQuien.Visible)
                    txtNombreQuien.Text = !String.IsNullOrWhiteSpace(transa.ANombreQuien) ? transa.ANombreQuien.ToUpper() : "";
                if(transa.DocumentoNombreQuien != null)
                {
                    if (transa.DocumentoNombreQuien.Length == 11)
                    {
                        ddTipoDocumento.SelectedValue = "1";
                        txtDocumentoNombreQuienMask.Mask = "###-#######-#";
                    }
                    else
                    {
                        ddTipoDocumento.SelectedValue = "2";
                        txtDocumentoNombreQuienMask.Mask = "#-##-#####-#";
                    }
                }
                if (txtDocumentoNombreQuienMask.Visible)
                    txtDocumentoNombreQuienMask.Text = transa.DocumentoNombreQuien != null ? transa.DocumentoNombreQuien.ToString() : "";
                if (rblDepositarCansilleria.Visible)
                    rblDepositarCansilleria.SelectedValue = transa.DepositarCansilleria == true ? "1" : transa.DepositarCansilleria == null ? "" : "0";

                var comun = new CamaraComunEntities();
                var vistaDocumentoReq = comun.ServicioDocumentoRequeridoComentario.FirstOrDefault(x => x.ServicioId == transa.ServicioId && x.TipoSociedadId == transa.TipoSociedadId);
                var comentario = string.Empty;
                if (vistaDocumentoReq != null) comentario = !string.IsNullOrWhiteSpace(vistaDocumentoReq.ComentarioWeb) ? vistaDocumentoReq.ComentarioWeb : "";
                if (!string.IsNullOrWhiteSpace(comentario))
                {
                    pnlComentarioServicio.Visible = true;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = comentario;
                }

            }
        }

        private void HideControles()
        {
            rpGrupoDoc.Visible = rpGrupoDoc.Items.Count > 0;
            pnDocRequeridos.Visible = rgriddocumentos.Items.Count > 0;


            //if ( (!rpGrupoDoc.Visible && !pnDocRequeridos.Visible) || this.hfServicioId.Value == Helper.ServicioCertificacionId.ToString())
            if (!rpGrupoDoc.Visible && !pnDocRequeridos.Visible)
                mv1.SetActiveView(v2);
        }

        // 01 - Cargando documentos requeridos por grupos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rpGrupoDoc_ItemDataBound(object, RepeaterItemEventArgs)'
        protected void rpGrupoDoc_ItemDataBound(object sender, RepeaterItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rpGrupoDoc_ItemDataBound(object, RepeaterItemEventArgs)'
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = e.Item.DataItem as int?;
                if (item.HasValue)
                    odsDocsRequeridosPorGrupo.SelectParameters["grupo"].DefaultValue = item.Value.ToString();
                var grid = e.Item.FindControl("rgriddocumentos") as RadGrid;
                if (grid != null)
                {
                    grid.DataSource = odsDocsRequeridosPorGrupo.Select();
                    grid.DataBind();
                }
            }
        }

        // 02 - Especificando valores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.btnContinuar_Click(object, EventArgs)'
        {
            bool impreso = false;
            bool depositarCansilleria = false;

            //Seleccion si quiere impreso
            //if (rblImpreso.SelectedValue.Equals("1") && rblImpreso.Visible) impreso = true;
            //else if (rblImpreso.SelectedValue.Equals("0") && rblImpreso.Visible) impreso = false;
            //else if (rblImpreso.Visible && rblImpreso.SelectedValue.Equals(""))
            //{
            //    Master.ShowMessageError("Debe seleccionar si desea imprimir o no la certificacion.");
            //    return;
            //}

            //A nombre de quien saldar la certificacion
            if (rblDepositarCansilleria.SelectedValue.Equals("1") && rblDepositarCansilleria.Visible) depositarCansilleria = true;
            else if (rblDepositarCansilleria.SelectedValue.Equals("0") && rblDepositarCansilleria.Visible) depositarCansilleria = false;
            else if (rblDepositarCansilleria.SelectedValue.Equals("") && rblDepositarCansilleria.Visible)
            {
                Master.ShowMessageError("Debe seleccionar si los documentos serán depositados en cancillería.");
                return;
            }

            if (EsCertificacion)
            {
                //Seleccion si quiere impreso
                //if (rblImpreso.SelectedValue.Equals("1") && rblImpreso.Visible) impreso = true;
                //else if (rblImpreso.SelectedValue.Equals("0") && rblImpreso.Visible) impreso = false;
                //else if (rblImpreso.Visible && rblImpreso.SelectedValue.Equals(""))
                //{
                //    Master.ShowMessageError("Debe seleccionar si desea imprimir o no la certificacion.");
                //    return;
                //}

                //A nombre de quien saldar la certificacion
                if (rblDepositarCansilleria.SelectedValue.Equals("1") && rblDepositarCansilleria.Visible) depositarCansilleria = true;
                else if (rblDepositarCansilleria.SelectedValue.Equals("0") && rblDepositarCansilleria.Visible) depositarCansilleria = false;
                else if (rblDepositarCansilleria.SelectedValue.Equals("") && rblDepositarCansilleria.Visible)
                {
                    Master.ShowMessageError("Debe seleccionar si los documentos serán depositados en cancillería.");
                    return;
                }

                lbCertificaciones.Visible = true;
                int.TryParse(txtCantidadCertificaciones.Text, out int cantidadCopiasCertificaciones);

                if (cantidadCopiasCertificaciones > 999)
                {
                    Master.ShowMessageError("La cantidad de certificaciones o copias certificadas no puede ser mayor a 999");
                    return;
                }
                if (cantidadCopiasCertificaciones <= 0)
                {
                    Master.ShowMessageError("La cantidad de Certificaciones debe ser mayor a 0.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtNombreQuien.Text) && txtNombreQuien.Visible)
                {
                    Master.ShowMessageError("Debe de especificar a nombre de quien se emitirá esta solicitud.");
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtDocumentoNombreQuienMask.Text) && txtDocumentoNombreQuienMask.Visible)
                {
                    Master.ShowMessageError("Debe de especificar la cedula o el RNC.");
                    return;
                }

            }

            if (CreateDocumentosRequeridos())
            {
                SaveDocSeleccionados();

                //Seleccion si quiere impreso
                //if (rblImpreso.SelectedValue.Equals("1") && rblImpreso.Visible) impreso = true;
                //else if (rblImpreso.SelectedValue.Equals("0") && rblImpreso.Visible) impreso = false;
                //else if (rblImpreso.Visible && rblImpreso.SelectedValue.Equals(""))
                //{
                //    Master.ShowMessageError("Debe seleccionar si desea imprimir o no la certificacion.");
                //    return;
                //}

                //A nombre de quien saldar la certificacion
                if (rblDepositarCansilleria.SelectedValue.Equals("1") && rblDepositarCansilleria.Visible) depositarCansilleria = true;
                else if (rblDepositarCansilleria.SelectedValue.Equals("0") && rblDepositarCansilleria.Visible) depositarCansilleria = false;
                else if (rblDepositarCansilleria.SelectedValue.Equals("") && rblDepositarCansilleria.Visible)
                {
                    Master.ShowMessageError("Debe seleccionar si los documentos serán depositados en cancillería.");
                    return;
                }

                var db = new CamaraWebsiteEntities();
                var transaccion = db.Transacciones.FirstOrDefault(a => a.TransaccionId.Equals(IdTransaciones));

                bool resCert = transaccion != null ? transaccion.EsCertificacion.HasValue : false;
                transaccion.DepositarCansilleria = depositarCansilleria;

                if (resCert)
                {
                    var list = transaccion.SubTransacciones.ToList();
                    foreach (var item in list)
                    {
                        db.DeleteObject(item);
                    }
                    // add campos para la certificion y la cop. certificada
                    transaccion.ImprimirCopias = impreso;
                    transaccion.EsCertificacion = true;
                    transaccion.DepositarCansilleria = depositarCansilleria;
                    transaccion.ANombreQuien = txtNombreQuien.Text.ToUpper();
                    transaccion.ImprimirCopias = impreso;
                    transaccion.CantidadCopiaCertificaciones = Convert.ToInt32(txtCantidadCertificaciones.Text);
                    transaccion.RegistroId = this.RegistroId;
                    string documentoNombreQuien = txtDocumentoNombreQuienMask.Text.Replace("-", "");
                    if (documentoNombreQuien.Length < 9 && txtDocumentoNombreQuienMask.Visible)
                    {
                        Master.ShowMessageError("Cedula o rnc no valida");
                        return;
                    }
                    else if (documentoNombreQuien.Length == 10 && txtDocumentoNombreQuienMask.Visible)
                    {
                        Master.ShowMessageError("Cedula o rnc no valida");
                        return;
                    }
                    else if (documentoNombreQuien.Length > 11 && txtDocumentoNombreQuienMask.Visible)
                    {
                        Master.ShowMessageError("Cedula o rnc no valida");
                        return;
                    }
                    transaccion.DocumentoNombreQuien = documentoNombreQuien;

                    // Creando tantas transacciones sean requeridas.
                    int.TryParse(txtCantidadCertificaciones.Text, out int cantidadCopiasCertificaciones);
                    if (cantidadCopiasCertificaciones > 999)
                    {
                        Master.ShowMessageError("La cantidad de certificaciones no puede ser mayor a 999");
                        return;
                    }
                    for (int i = 0; i < (cantidadCopiasCertificaciones - 1); i++)
                    {
                        transaccion.ImprimirCopias = impreso;
                        Transacciones tnx = new OFV.Transacciones
                        {
                            TransaccionId = -1,
                            Fecha = DateTime.Now,
                            NombreContacto = transaccion.NombreContacto,
                            RegistroId = transaccion.RegistroId,
                            ModificacionCapital = transaccion.ModificacionCapital,
                            CapitalSocial = transaccion.CapitalSocial,
                            TipoSociedadId = transaccion.TipoSociedadId,
                            RNCSolicitante = transaccion.RNCSolicitante,
                            UserName = transaccion.UserName,
                            CamaraId = transaccion.CamaraId,
                            EstatusTransId = Helper.EstatusTransIdNuevo,
                            Solicitante = transaccion.Solicitante,
                            FechaReciboDGII = transaccion.FechaReciboDGII,
                            MontoDGII = transaccion.MontoDGII,
                            NoReciboDGII = transaccion.NoReciboDGII,
                            TelefonoContacto = transaccion.TelefonoContacto,
                            NumeroRegistro = transaccion.NumeroRegistro,
                            ServicioId = transaccion.ServicioId,
                            ImprimirCopias = transaccion.ImprimirCopias,
                            DepositarCansilleria = transaccion.DepositarCansilleria,
                            ANombreQuien = transaccion.ANombreQuien,
                            EsCertificacion = transaccion.EsCertificacion,
                            DocumentoNombreQuien = transaccion.DocumentoNombreQuien
                        };
                        tnx.ServicioId = transaccion.ServicioId;
                        transaccion.SubTransacciones.Add(tnx);
                    }
                }
                    db.SaveChanges();
                var helper = new TransaccionDevueltaHelper(Request);

                #region UrlForm
                string queryString = DefaultQueryString;
                if (!queryString.Contains("requireDocs="))
                    queryString += pnDocRequeridos.Visible ? "&requiereDocs=1" : "&requiereDocs=0";

                if (!queryString.Contains("cantidadCertificaciones="))
                {
                    queryString += string.Format("&cantidadCertificaciones={0}", txtCantidadCertificaciones.Text);
                }
                else
                {
                    queryString = Regex.Replace(queryString, "cantidadCertificaciones=(.*)\\&?",
                        string.Format("cantidadCertificaciones={0}", txtCantidadCertificaciones.Text));
                }

                if (helper.EstaDevuelta() && !queryString.Contains("estado="))
                    queryString += "&estado=devuelto";
                if (transaccion.EsCertificacion != null)
                {
                    if (transaccion.EsCertificacion == true)
                    {
                        if (!queryString.Contains("EsCertificacion="))
                            queryString += "&EsCertificacion=1";
                    }
                }

                //Williams Oleaga para saber si es entrega digital
                //if (rblImpreso.SelectedValue.Equals("0"))
                //{
                //    if (queryString.Contains("EntregaDigital=False"))
                //        queryString = queryString.Replace("EntregaDigital=False", "EntregaDigital=True");
                //}

                //if (rblImpreso.SelectedValue.Equals("1"))
                //{
                //    if (queryString.Contains("EntregaDigital=False"))
                //        queryString = queryString.Replace("EntregaDigital=False", "EntregaDigital=true");
                //}

                if (rblDepositarCansilleria.SelectedValue.Equals("1"))
                {
                    if (queryString.ToLower().Contains("EntregaDigital=true".ToLower()))
                        queryString = queryString.ToLower().Replace("EntregaDigital=true".ToLower(), "EntregaDigital=false");
                }

                if (rblDepositarCansilleria.SelectedValue.Equals("0"))
                {
                    if (queryString.ToLower().Contains("EntregaDigital=false".ToLower()))
                        queryString = queryString.ToLower().Replace("EntregaDigital=false".ToLower(), "EntregaDigital=true");
                }

                //si viene de problema el le quita el entrga digital , en esta vuelta le agregamos eso
                if (queryString.ToLower().Contains("EntregaDigital".ToLower()))
                {
                }
                else
                {
                    if (rblDepositarCansilleria.SelectedValue.Equals("1"))
                    {
                        queryString = queryString + "&EntregaDigital=false";
                    }
                    if (rblDepositarCansilleria.SelectedValue.Equals("0"))
                    {
                        queryString = queryString + "&EntregaDigital=true";
                    }
                }


                if (transaccion.TipoSociedadId != 7 && transaccion.TipoSociedadId != 0)
                {
                    var sociedadescontroller = new SRM.SociedadesController();
                    var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroByRegistroId(this.RegistroId, CamaraId);
                    var sociedadId = sociedadRegistro.SociedadId;

                    if (queryString.Contains("SociedadId="))
                    {
                        int socId;
                        int.TryParse(Request.QueryString["SociedadId"], out socId);
                        if (socId == 0)
                        {
                            queryString = String.Format("?SociedadId={0}{1}", sociedadRegistro.SociedadId, DefaultQueryString.Substring(12));
                        }
                    }
                }
                else if (transaccion.TipoSociedadId == 7)
                {
                    var ctrlPersona = new SRM.PersonaFisicaController();
                    var personas = ctrlPersona.ObteneByPersonaIdCamara(PersonaId, CamaraId);
                    if (personas.Count == 0)
                    {
                        if (!queryString.Contains("PersonaId="))
                        {
                            var pr = ctrlPersona.ObteneByRegistroIdCamara(this.RegistroId, this.CamaraId).FirstOrDefault();
                            if (pr == null)
                            {
                                Master.ShowMessageError("No se encontró ninguna entidad Persona con ese Número de Registro en la Cámara indicada");
                                return;
                            }
                            queryString += String.Format("&PersonaId={0}", pr.PersonaId);
                        }
                    }

                    if (!queryString.Contains("TipoSociedadId="))
                    {
                        queryString += String.Format("&TipoSociedadId={0}", transaccion.TipoSociedadId);
                    }

                }
                int reg;
                int.TryParse(Request.QueryString["RegistroId"], out reg);
                if (reg == 0)
                {
                    queryString = String.Format(queryString + "&RegistroId={0}", this.RegistroId);
                }
                Response.Redirect("~/Formularios/FormViewer.aspx" + queryString);
                #endregion
            }
        }

        //Guardando documentos selecconados
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.SaveDocSeleccionados()'
        protected void SaveDocSeleccionados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.SaveDocSeleccionados()'
        {
            var db = new CamaraWebsiteEntities();
            var result = db.TransaccionDocSeleccionado.Where(a => a.TransaccionId == IdTransaciones || a.TransaccionId == this.TransaccionId);

            foreach (var item in result)
                db.DeleteObject(item);

            db.SaveChanges();
            foreach (var tran in this.DocumentosSeleccionados
                        .Select(item => new TransaccionDocSeleccionado
                        {
                            TransaccionId = IdTransaciones == 0 ? TransaccionId : IdTransaciones,
                            TipoDocumentoId = item.TipoDocumentoId,
                            CantidadCopia = item.CantidadCopia,
                            CantidadOriginal = item.CantidadOriginal,
                            FechaDocumento = item.Fecha
                        }
                    ))
                db.TransaccionDocSeleccionado.AddObject(tran);

            db.SaveChanges();
        }

        //Definiendo documentos requeridos
        private bool CreateDocumentosRequeridos()
        {
            txtCosto.Text = String.Empty;

            //Cargando documentos requeridos seleccionados
            this.DocumentosSeleccionados = new List<Comun.ServicioDocumentoRequerido>();

            foreach (GridDataItem item in rgriddocumentos.Items)
                LoadDocumento(rgriddocumentos, item);

            if (this.DocumentosSeleccionados.Count != rgriddocumentos.Items.Count)
            {
                Master.ShowMessageError("Selecciona la cantidad de todos los documentos requeridos para continuar. Intentelo nuevamente.");
                return false;
            }

            foreach (RepeaterItem rpitem in rpGrupoDoc.Items)
            {
                var radGrid = rpitem.FindControl("rGridDocumentosPorGrupo") as RadGrid;
                if (radGrid == null) continue;
                var docsSeleccionados = this.DocumentosSeleccionados.Count;
                foreach (GridDataItem item in radGrid.Items)
                    LoadDocumento(radGrid, item);

                //Validators para calendarios
                foreach (GridDataItem item in radGrid.Items)
                {
                    var cal = item.FindControl("radFechaDocumento") as RadDatePicker;
                    var txt1 = item.FindControl("txtCantidadDoc") as TextBox;
                    var txt2 = item.FindControl("txtCantidadDocOriginal") as TextBox;
                    if (cal != null && txt1 != null && txt2 != null)
                    {
                        Int32 cant1, cant2;
                        Int32.TryParse(txt1.Text, out cant1);
                        Int32.TryParse(txt2.Text, out cant2);
                        if (cant2 == 0)
                        {
                            Master.ShowMessageError("Debes seleccionar por lo menos un original para cada documento agregado. Intentalo nuevamente.");
                            return false;
                        }
                        if (cant1 + cant2 > 0 && cal.SelectedDate == null)
                        {
                            Master.ShowMessageError("Existen documentos sin fecha asignada.");
                            return false;
                        }
                    }
                }

                //Validacion de documentos por grupo
                if (docsSeleccionados != this.DocumentosSeleccionados.Count) continue;
                Master.ShowMessageError("Selecciona al menos un documento por grupo.");
                return false;
            }

            //Verificando Documentos agregados.
            var docsNoOriginales = this.DocumentosSeleccionados.Any(
                    a => a.CantidadOriginal == 0 && a.TipoDocumento.Registrable && a.Requerido == true &&
                    !Helper.TipoSociedadExtranjera.Contains(a.TipoSociedadId));

            if (docsNoOriginales)
            {
                Master.ShowMessageError(
                    "Deposita al menos un documento original de los documentos registrables para poder continuar. Intentalo nuevamente.");
                return false;
            }

            SetDocumentosAgregados();
            var existeDocSinCantidad = this.DocumentosAgregados.Any(a => a.CantidadOriginal == 0);
            if (existeDocSinCantidad)
            {
                Master.ShowMessageError("Debes seleccionar por lo menos un original para cada documento agregado. Intentalo nuevamente.");
                return false;
            }

            // Comentado temporalmente por Wagner
            /*for (var i = 0; i < this.DocumentosAgregados.Count(); i++)
            {
                var item = this.gDocumentosAgregados.Items[i];
                Int32 cantidadOriginal, cantidadCopia;
                int.TryParse(((TextBox)item.FindControl("txtCantidadDocOriginal")).Text, out cantidadOriginal);
                int.TryParse(((TextBox)item.FindControl("txtCantidadDoc")).Text, out cantidadCopia);

                this.DocumentosAgregados[i].CantidadCopia = cantidadCopia;
                this.DocumentosAgregados[i].CantidadOriginal = cantidadOriginal;
                this.DocumentosSeleccionados.Add(this.DocumentosAgregados[i]);
            }*/

            return true;
        }


        /// <summary>
        /// Load ServicioDocumentoRequerido From Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="item"></param>
        private void LoadDocumento(RadGrid grid, GridDataItem item)
        {
            var keys = grid.MasterTableView.DataKeyValues[item.ItemIndex];

            var cantidadCopia = 0;
            var cantidadOriginal = 0;

            DateTime? fechaDocumento;
            var fechaCal = item.FindControl("radFechaDocumento") as RadDatePicker;
            var fechaLabel = item.FindControl("FechaLabel") as Label;

            if (fechaCal != null)
                fechaDocumento = fechaCal.SelectedDate;
            else
            {
                var fechaStr = fechaLabel.Text;
                DateTime fechaTemp;
                if (DateTime.TryParse(fechaStr, out fechaTemp) && fechaTemp > DateTime.MinValue)
                    fechaDocumento = fechaTemp;
                else
                    fechaDocumento = DateTime.Today;
            }

            var myCantidadCopia = item["TipoDocumento.CantidadCopia"].Text;

            int.TryParse(((TextBox)item.FindControl("txtCantidadDocOriginal")).Text, out cantidadOriginal);
            int.TryParse(((TextBox)item.FindControl("txtCantidadDoc")).Text, out cantidadCopia);

            if (cantidadCopia <= 0 && cantidadOriginal <= 0) return;

            this.DocumentosSeleccionados.Add(new Comun.ServicioDocumentoRequerido
            {
                Agregado = false,
                Fecha = fechaDocumento,
                CantidadCopia = cantidadCopia,
                CantidadOriginal = cantidadOriginal,
                Grupo = (int)keys["Grupo"],
                Requerido = (bool)keys["Requerido"],
                ServicioId = (int)keys["ServicioId"],
                TipoSociedadId = (int)keys["TipoSociedadId"],
                TipoDocumentoId = (int)keys["TipoDocumentoID"],
                Nombre = keys["TipoDocumento.Nombre"].ToString(),
                CostoCopia = (decimal)keys["TipoDocumento.CostoCopia"],
                CostoOriginal = (decimal)keys["TipoDocumento.CostoOriginal"],
                TipoDocumento =
                                                         new TipoDocumento
                                                         {
                                                             TipoDocumentoId = (int)keys["TipoDocumentoID"],
                                                             Registrable = keys["TipoDocumento.Registrable"] != null
                                                                        ? (bool)keys["TipoDocumento.Registrable"]
                                                                        : true
                                                         }
            });
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.Page_PreRenderComplete(object, EventArgs)'
        protected void Page_PreRenderComplete(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.Page_PreRenderComplete(object, EventArgs)'
        {
            //Oculto controles grid cuando no existan documentos.
            HideControles();
            SetOriginalValue(rgriddocumentos);

            foreach (RepeaterItem item in rpGrupoDoc.Items)
            {
                if (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem) continue;

                var grid = item.FindControl("rgriddocumentos") as RadGrid;
                if (grid == null) continue;

                SetOriginalValue(grid);
            }

            if (rpGrupoDoc.Items.Count == 0)
                rpGrupoDoc.Visible = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.SetOriginalValue(RadGrid)'
        protected void SetOriginalValue(RadGrid grid)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.SetOriginalValue(RadGrid)'
        {
            foreach (GridDataItem item in grid.Items)
            {
                var txtOriginal = ((TextBox)item.FindControl("txtCantidadDocOriginal"));
                var txtCantidadDoc = ((TextBox)item.FindControl("txtCantidadDoc"));
                var hfOriginal = ((HiddenField)item.FindControl("hfCostoOriginal"));
                var lblOriginal = ((Label)item.FindControl("lblOriginal"));
                var hfRegistrable = ((HiddenField)item.FindControl("hfEsRegistrable"));

                if (FormaEntrega == "D" || FormaEntrega == "d")
                    txtCantidadDoc.Visible = false;

                switch (hfRegistrable.Value)
                {
                    case "False":
                        txtOriginal.Visible = false;
                        lblOriginal.Visible = true;
                        txtCantidadDoc.Visible = true;
                        break;
                    default:
                        //txtOriginal.Text = "1";
                        //txtOriginal.ReadOnly = true;
                        break;
                }
                decimal costo = 0;
                decimal.TryParse(txtCosto.Text, out costo);
                txtCosto.Text = (costo + Convert.ToDecimal(hfOriginal.Value)).ToString();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.btnAgregar_Click(object, EventArgs)'
        protected void btnAgregar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.btnAgregar_Click(object, EventArgs)'
        {
            //if (this.ddlDocumentos.SelectedIndex > 0) // Comentado temporalmente por Wagner
            //    AgregarDocumento();
        }

        private void AgregarDocumento()
        {
            /* // Comentado temporalmente por Wagner
            var docs = new TipoDocumentoRepository();
            var tipoDocumentoId = int.Parse(ddlDocumentos.SelectedValue);
            var tipoDocumento = docs.SelectByID(tipoDocumentoId);

            this.DocumentosAgregados.Add(new ServicioDocumentoRequerido
            {
                Agregado = true,
                CantidadCopia = 0,
                CantidadOriginal = 1,
                TipoDocumentoId = tipoDocumento.TipoDocumentoId,
                Nombre = ddlDocumentos.SelectedItem.Text,
                CostoCopia = tipoDocumento.CostoCopia,
                CostoOriginal = tipoDocumento.CostoOriginal,
                Fecha = radFechaDocumento.SelectedDate
            });

            gDocumentosAgregados.DataSource = this.DocumentosAgregados;
            gDocumentosAgregados.DataBind();*/

        }

        private void SetDocumentosAgregados()
        {
            /* // Comentado temporalmente por Wagner
            int index = 0;
            foreach (GridDataItem item in gDocumentosAgregados.Items)
            {
                var cantidadOriginal = 0;
                int.TryParse(((TextBox)item.FindControl("txtCantidadDocOriginal")).Text, out cantidadOriginal);
                var cantidadCopia = 0;
                int.TryParse(((TextBox)item.FindControl("txtCantidadDoc")).Text, out cantidadCopia);

                this.DocumentosAgregados[index].CantidadCopia = cantidadCopia;
                this.DocumentosAgregados[index].CantidadOriginal = cantidadOriginal;
                index++;
            }*/
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.gDocumentosAgregados_Command(object, EventArgs)'
        protected void gDocumentosAgregados_Command(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.gDocumentosAgregados_Command(object, EventArgs)'
        {
            /* // Comentado temporalmente por Wagner
            var btn = (ImageButton)sender;
            var index = int.Parse(btn.CommandArgument);

            this.DocumentosAgregados.RemoveAt(index);

            gDocumentosAgregados.DataSource = this.DocumentosAgregados;
            gDocumentosAgregados.DataBind();
            */
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        protected void rgriddocumentos_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var reqFecha = (RequiredFieldValidator)e.Item.FindControl("reqFecha");
                var radFechaDocumento = (RadDatePicker)e.Item.FindControl("radFechaDocumento");
                var imgStatus = (Image)e.Item.FindControl("HelpImg");

                radFechaDocumento.MaxDate = DateTime.Today;

                var doc = (ServicioDocumentoRequerido)e.Item.DataItem;

                var transaccion = new CamaraWebsiteEntities()
                    .Transacciones.FirstOrDefault(x => x.TransaccionId == TransaccionId && CamaraId == x.CamaraId);
                if (transaccion == null)
                    return;

                if (doc.TipoDocumento != null && !doc.TipoDocumento.Registrable)
                {
                    reqFecha.Enabled = false;
                    reqFecha.Visible = false;
                    radFechaDocumento.Visible = false;
                }
                if(doc.TipoDocumento != null)
                {
                    if(doc.TipoDocumento.DescripcionWeb != null)
                    {
                        imgStatus.Visible = true;
                        imgStatus.ToolTip = doc.TipoDocumento.DescripcionWeb;
                    }
                }

                var nombreDoc = (Label)e.Item.FindControl("lblNombreDocumento");
                var cantCopias = (TextBox)e.Item.FindControl("txtCantidadDoc");
                var transacDolSel = new CamaraWebsiteEntities()
                    .TransaccionDocSeleccionado.FirstOrDefault(x => x.TransaccionId == TransaccionId && x.TipoDocumentoId == doc.TipoDocumentoId);

                void MostrarFechaEnGrid()
                {
                    reqFecha.Enabled = true;
                    reqFecha.Visible = true;
                    radFechaDocumento.Visible = true;
                }

                if (doc.TipoDocumentoId == 1560)
                {
                    cantCopias.Text = "1";
                    cantCopias.Enabled = false;
                }
                //poder inclusion
                else if(doc.TipoDocumentoId == 1655 && this.TipoServicioId == 686)
                {
                    cantCopias.Text = "1";
                    cantCopias.Enabled = false;

                    MostrarFechaEnGrid();
                }
                //poder inclusion
                else if (doc.TipoDocumentoId == 1583 && this.TipoServicioId == 741)
                {
                    cantCopias.Text = "1";
                    cantCopias.Enabled = false;

                    MostrarFechaEnGrid();
                }
                //Cedula
                else if (doc.TipoDocumentoId == 1551)
                {
                    if (transaccion.EsCertificacion != null)
                    {
                        bool.TryParse(transaccion.EsCertificacion.ToString(), out bool certificacion);
                        if (certificacion)
                        {
                            cantCopias.Text = "1";
                            cantCopias.Enabled = false;
                        }

                    }
                }
                else
                {
                    var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                    var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == this.TransaccionId && x.DesdeOfv);
                    if (trSDQ != null)
                    {
                        var conDocumetosSRM = context.DocumentosTransacciones.Where(d => d.TransaccionId == trSDQ.TransaccionId);
                        cantCopias.Text = conDocumetosSRM.Where(d => d.Documento != "FORMULARIO DE SOLICITUD").Count() != 0 ?
                                         conDocumetosSRM.Where(d => d.Documento != "FORMULARIO DE SOLICITUD").Count().ToString() : "0";
                    }
                    else
                    {
                        if (transacDolSel != null) cantCopias.Text = transacDolSel.CantidadCopia != 0 ? transacDolSel.CantidadCopia.ToString() : "0";
                    }
                    cantCopias.Enabled = true;
                }

            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rgriddocumentos_RowEditing(object, GridItemEventArgs)'
        protected void rgriddocumentos_RowEditing(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rgriddocumentos_RowEditing(object, GridItemEventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.ddlDocumentos_DataBound(object, EventArgs)'
        protected void ddlDocumentos_DataBound(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.ddlDocumentos_DataBound(object, EventArgs)'
        {
            //FOrce para que se escoja el primer item agregado manualmente antes que los items databound
            //this.ddlDocumentos.SelectedIndex = 0; // Comentado temporalmente por Wagner
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rpServiciosSeleccionados_ItemCommand(object, RepeaterCommandEventArgs)'
        protected void rpServiciosSeleccionados_ItemCommand(object source, RepeaterCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rpServiciosSeleccionados_ItemCommand(object, RepeaterCommandEventArgs)'
        {

        }

        private bool RegisterTransaction(int servicioId, int? modeloId = null)
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
                Comentario = "",
                ImprimirCopias = false
            };


            var repTransaccion = new OFV.TransaccionesRepository();

            repTransaccion.Add(transaccion);

            var result = repTransaccion.Save() > 0;

            this.TransaccionId = transaccion.TransaccionId;
            IdTransaciones = transaccion.TransaccionId;

            return result;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect(BackUrl);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.BackUrl'
        protected string BackUrl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.BackUrl'
        {
            get
            {
                /*var noSolicitud = Request.QueryString["nSolicitud"];
                var esCertificacion = Request.QueryString["EsCertificacion"];
                var camaraId = Request.QueryString["CamaraId"];

                return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";*/
                var helper = new TransaccionDevueltaHelper(Request);
                string queryString = DefaultQueryString;
                var TipoServicioId = Request.QueryString["TipoServicioId"];
                int nSolicitud;
                int.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);
                var trans = new CamaraWebsiteEntities().Transacciones.FirstOrDefault(x => x.TransaccionId == nSolicitud);
                if (TipoServicioId == null && RegistroId != 0)
                {
                    switch (trans.ServicioId)
                    {
                        case 398:
                            return $"~/Empresas/VerDetalleTransaccion.aspx{queryString}";
                        case 421:
                            return $"~/Empresas/VerDetalleTransaccion.aspx{queryString}";
                        default:
                            return $"~/Empresas/VerDetalleEmpresa.aspx{queryString}";
                    }

                }
                switch (TipoServicioId)
                {
                    case "3":
                        return $"~/Empresas/VerDetalleEmpresa.aspx{queryString}";
                    case "5":
                        return $"~/Empresas/VerDetalleEmpresa.aspx{queryString}";
                    case "38":
                        return $"~/Empresas/VerDetalleTransaccion.aspx{queryString}";
                    case "7":
                        if (!queryString.Contains("RegistroId="))
                            queryString += "&RegistroId=" + trans.RegistroId;
                        var tipoSociedad = !queryString.Contains("&TipoSociedadId=") ? "&TipoSociedadId=" + this.TipoSociedadId : "";
                        return $"~/Operaciones/Shared/Certificaciones.aspx{queryString}" + tipoSociedad;
                    case "11":
                        if (!queryString.Contains("RegistroId="))
                            queryString += "&RegistroId=" + trans.RegistroId + "&TipoSociedadId=" + this.TipoSociedadId;
                        var tipoSoc = !queryString.Contains("&TipoSociedadId=") ? "&TipoSociedadId=" + this.TipoSociedadId : "";
                        return $"~/Operaciones/Shared/Certificaciones.aspx{queryString}" + tipoSoc;
                    case "8":
                        if (this.TipoSociedadId != 7)
                        {
                            if (!queryString.Contains("RegistroId="))
                                queryString += "&RegistroId=" + trans.RegistroId;
                            return $"~/Empresas/ActualizarDatosGenerales.aspx{queryString}";
                        }
                        else return $"~/Empresas/VerDetalleTransaccion.aspx{queryString}";
                    case "17":
                        if (!queryString.Contains("RegistroId="))
                            queryString += "&RegistroId=" + trans.RegistroId;
                        return $"~/Empresas/ActualizarDatosGenerales.aspx{queryString}";
                    case "39":
                        if (!queryString.Contains("RegistroId="))
                            queryString += "&RegistroId=" + trans.RegistroId;
                        if (!queryString.Contains("TipoSociedadId="))
                            queryString += "&TipoSociedadId=" + trans.TipoSociedadId ?? "";
                        return $"~/Operaciones/Shared/CopiasCert.aspx{queryString}";
                    
                    case "686":
                        return $"~/Empresas/VerDetalleTransaccion.aspx{queryString}";
                    default:
                        return $"~/Empresas/Oficina.aspx";
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.txtCantidadCertificaciones_TextChanged(object, EventArgs)'
        protected void txtCantidadCertificaciones_TextChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.txtCantidadCertificaciones_TextChanged(object, EventArgs)'
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.txtDocumentoNombreQuien_TextChanged(object, EventArgs)'
        protected void txtDocumentoNombreQuien_TextChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.txtDocumentoNombreQuien_TextChanged(object, EventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rGridDocumentosPorGrupo_ItemDataBound(object, GridItemEventArgs)'
        protected void rGridDocumentosPorGrupo_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rGridDocumentosPorGrupo_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var doc = (ServicioDocumentoRequerido)e.Item.DataItem;
                var radFechaDocumento = (RadDatePicker)e.Item.FindControl("radFechaDocumento");
                radFechaDocumento.MaxDate = DateTime.Today;
                var cantOriginal = (TextBox)e.Item.FindControl("txtCantidadDocOriginal");
                var cantCopias = (TextBox)e.Item.FindControl("txtCantidadDoc");
                var imgStatus = (Image)e.Item.FindControl("HelpImg");

                var transacDolSel = new CamaraWebsiteEntities()
                    .TransaccionDocSeleccionado.FirstOrDefault(x => x.TransaccionId == TransaccionId && x.TipoDocumentoId == doc.TipoDocumentoId);

                var transaccion = new CamaraWebsiteEntities()
                    .Transacciones.FirstOrDefault(x => x.TransaccionId == TransaccionId && CamaraId == x.CamaraId);
                 if(transaccion == null)                
                    return;

                if (doc.TipoDocumento != null)
                {
                    if (doc.TipoDocumento.DescripcionWeb != null)
                    {
                        imgStatus.Visible = true;
                        imgStatus.ToolTip = doc.TipoDocumento.DescripcionWeb;
                    }
                }

                void MostrarFechaEnGrid()
                {
                    radFechaDocumento.Visible = true;
                }

                if (doc.TipoDocumentoId == 1560)
                {
                    cantCopias.Text = "1";
                    cantCopias.Enabled = false;
                }
                //inclusion
                else if (doc.TipoDocumentoId == 1655 && this.TipoServicioId == 686)
                {
                    cantCopias.Text = "1";
                    cantCopias.Enabled = false;

                    MostrarFechaEnGrid();
                }
                //inclusion
                else if (doc.TipoDocumentoId == 1583 && this.TipoServicioId == 741)
                {
                    cantCopias.Text = "1";
                    cantCopias.Enabled = false;

                    MostrarFechaEnGrid();
                }
                //Cedula
                else if (doc.TipoDocumentoId == 1551)
                {
                    if (transaccion.EsCertificacion != null)
                    {
                        bool.TryParse(transaccion.EsCertificacion.ToString(), out bool certificacion);
                        if (certificacion)
                        {
                            cantCopias.Text = "1";
                            cantCopias.Enabled = false;
                        }

                    }
                }

                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == this.TransaccionId && x.DesdeOfv);
                if (trSDQ != null)
                {
                    var conDocumetosSRM = context.DocumentosTransacciones.FirstOrDefault(d => d.TransaccionId == trSDQ.TransaccionId && d.DocumentoId == doc.TipoDocumentoId);
                    if (conDocumetosSRM != null)
                    {
                        if (conDocumetosSRM?.FechaDocumento != null) radFechaDocumento.SelectedDate = conDocumetosSRM.FechaDocumento;
                        cantCopias.Text = conDocumetosSRM?.NoCopias != 0 ? conDocumetosSRM.NoCopias.ToString() : "0";
                        cantOriginal.Text = conDocumetosSRM?.NoCopias != 0 ? conDocumetosSRM.NoOriginales.ToString() : "0";
                    }
                    
                }
                else
                {
                    if (transacDolSel != null)
                    {
                        if(transacDolSel.FechaDocumento != null) radFechaDocumento.SelectedDate = transacDolSel.FechaDocumento;
                        cantCopias.Text = transacDolSel.CantidadCopia != 0 ? transacDolSel.CantidadCopia.ToString() : "0";
                        cantOriginal.Text = transacDolSel.CantidadOriginal != 0 ? transacDolSel.CantidadOriginal.ToString() : "0";
                    }
                }

            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.ddTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        protected void ddTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.ddTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        {            
            int.TryParse(this.ddTipoDocumento.SelectedItem.Value, out int tipoMask);

            if (tipoMask == 1)
            {
                txtDocumentoNombreQuienMask.Mask = "###-#######-#";
            }
            else if(tipoMask == 2)
            {
                txtDocumentoNombreQuienMask.Mask = "#-##-#####-#";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rblImpreso_SelectedIndexChanged(object, EventArgs)'
        protected void rblImpreso_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rblImpreso_SelectedIndexChanged(object, EventArgs)'
        {
            //if (rblImpreso.SelectedValue.Equals("0"))
            //{
            //    lblIDepositarCansilleria.Visible = false;
            //    rblDepositarCansilleria.Visible = false;
            //}
            //if (rblImpreso.SelectedValue.Equals("1"))
            //{
            //    lblIDepositarCansilleria.Visible = true;
            //    rblDepositarCansilleria.Visible = true;
            //}
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rblDepositarCansilleria_SelectedIndexChanged(object, EventArgs)'
        protected void rblDepositarCansilleria_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionDocumentos.rblDepositarCansilleria_SelectedIndexChanged(object, EventArgs)'
        {

            if (rblDepositarCansilleria.SelectedValue.Equals("0"))
            {
                Label1.Text = "Nota: Al confirmar esta solicitud les notificamos que sus documentos serán entregados digitalmente y que por lo tanto “NO” debe dirigirse a nuestras instalaciones a retirar las copias, pues las mismas serán remitidas al correo electrónico asociado a esta solicitud.";
                Label1.Visible = true;
            }


            if (rblDepositarCansilleria.SelectedValue.Equals("1"))
            {

                if (this.TipoServicioId == 7 || this.TipoServicioId == 39)
                {
                    Label1.Text = "Nota: Al confirmar esta solicitud la cual será depositada en Cancillería  les notificamos  que sus documentos serán entregados físicamente por lo tanto debe dirigirse a nuestras instalaciones a retirar su documentación. Tomar en cuenta que se anexará una factura Complementaria si dicho servicio genera copias de algún documento";
                    Label1.Visible = true;
                }else
                {
                    Label1.Text = "Nota: Al confirmar esta solicitud la cual será depositada en Cancillería  les notificamos  que sus documentos serán entregados físicamente por lo tanto debe dirigirse a nuestras instalaciones a retirar su documentación.";
                    Label1.Visible = true;
                }
           
            }




        }


        



    }


}