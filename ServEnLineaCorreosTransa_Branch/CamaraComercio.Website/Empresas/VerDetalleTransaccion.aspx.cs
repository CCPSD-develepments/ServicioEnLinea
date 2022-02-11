using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.wsFacturacion;
using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.Web.Configuration;
using System.Collections.Generic;
using Telerik.Web.UI;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using System.ComponentModel;
using CamaraComercio.Website.TarjetaCredito;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Configuration;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página que muestra el detalle de una transacción
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class VerDetalleTransaccion : SecurePage
    {
#if !Debug
        ServicioFacturacion fac = new ServicioFacturacion();
        
#endif
        private readonly CamaraComunEntities dbCom = new CamaraComunEntities();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.Transaccion'
        protected OFV.Transacciones Transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.Transaccion'
        {
            get
            {
                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);
                    if (transa != null) return transa;
                    else return new OFV.Transacciones();
                }
                else return new OFV.Transacciones();

                //if (Session["Transacciones"] == null)
                //    Session["Transacciones"] = new OFV.Transacciones();

                //return Session["Transacciones"] as OFV.Transacciones;
            }
            set { Session["Transacciones"] = value; }
        }

        private OFV.Transacciones GetTransaccion(long transactionId)
        {
          //  var db = new OFV.CamaraWebsiteEntities();

            using (var db = new OFV.CamaraWebsiteEntities())
            {

                var trans = (from t in db.Transacciones
                             where t.TransaccionId == transactionId
                             select t).FirstOrDefault();

                return trans;

            }
        }

        /// <summary>
        /// Get services from WebConfig
        /// </summary>
        public static ServicioSection ServiciosDefault
        {
            get
            {
                return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
            }
        }

        private ViewSumarioSociedades ObtenerSociedad(int registroNo, string camaraId)
        {
            var repository = new SociedadesController();
            return repository.FetchByRegistroAndCamara(registroNo, camaraId).FirstOrDefault();
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.NombreEmpresa'
        protected string NombreEmpresa
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.NombreEmpresa'
        {
            get
            {
                if (Session["NombreEmpresa"] == null) Session["NombreEmpresa"] = string.Empty;
                return Session["NombreEmpresa"].ToString();
            }
            set { Session["NombreEmpresa"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.FormularioSolicitud'
        protected OFV.TransaccionesDocumentos FormularioSolicitud
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.FormularioSolicitud'
        {
            get
            {
                if (Session["FormularioSolicitud"] == null) return null;
                return Session["FormularioSolicitud"] as OFV.TransaccionesDocumentos;
            }
            set { Session["FormularioSolicitud"] = value; }
        }
        bool trSDQ = false; 
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                bool esDetalle = false;
                Boolean.TryParse(Request.QueryString["VerDetalle"], out esDetalle);
                int transId = 0;
                int.TryParse(Request["nSolicitud"], out transId);
                var transaccion = GetTransaccion(transId);

                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transaccion.CamaraId);
                trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == transId && x.DesdeOfv)?.VieneProblemas == true ? true : false;
                seccionProblema.Visible = trSDQ;
                pnlEnProblema.Visible = trSDQ;

                var transastring = transId.ToString();
                var db = new CamaraWebsiteEntities();
              //  var registro = db.TransaccionesEmpBHD.Where(x => x.reference == transastring && x.Estatus == 1).ToList();
             //   var UltimoTransaccionConBHD = db.TransaccionesEmpBHD.Where(x => x.SolicitudId == transId && x.Estatus == 1).OrderByDescending(a =>a.Id).FirstOrDefault();


#if !DEBUG
                if (trSDQ)
                {
                    int.TryParse(transaccion.SrmTransaccionId.ToString(), out int srmTransa);
                    var verficarNota = fac.ValidacionVigenciaNotaCredito(srmTransa, transaccion.CamaraId);
                    if (verficarNota.DiasTranscurridos >90 && verficarNota.NotaCreditoValida.Equals("False"))
                    {
                        pnlNotaProblema.Visible = true;
                        lblMensajeNota.Visible = true;
                        lblMensajeNota.Text = !string.IsNullOrWhiteSpace(Helper.MensajeNotaNovDiasDetalleTransaccion)
                            ? Helper.MensajeNotaNovDiasDetalleTransaccion : "No mensaje";
                    }
                }
#endif

                if (!esDetalle && !trSDQ)
                {
                    //Si es una certificacion y esta pagada se envia a la pantalla de envio de documentos.
                    RedirectSiPagaynoEnviada();
                    RedirectSiNoEstaCompleta();
                }
                if (!int.TryParse(Request["nSolicitud"], out transId))
                {
                    SolicitudInvalida();
                    return;
                }
                var dbWeb = new CamaraWebsiteEntities();
                var dbCom = new CamaraComunEntities();
                var tran = dbWeb.Transacciones.FirstOrDefault(t => t.TransaccionId == transId);
                if (tran == null)
                {
                    SolicitudInvalida();
                    return;
                }
                int cf = dbWeb.Facturas.Where(c => c.TransaccionId == transId).Count();
                if (tran.ServicioId == Helper.ServicioInclusionId && cf < 2)
                    hlVerFactura.Visible = false;
                LoadInterface();


                //mostramos el panel nuevo del bhd  comented on 2021-07-07:
                /*  if (registro.Count() >= 1)
                  {
                      pnlBhdEmpresa.Visible = true;
                      pnlEnvioDocs.Visible = false;
                  }
                  */

                // la ultimo con pago bhd
                hlEnvioDocumentosTit.Visible = true;
             //   btnCompletarTransaccion.Visible = false;
               // btnComprobarPagoBanco.Visible = true;

                //if (UltimoTransaccionConBHD !=null)
                //{
                //    pnlBhdEmpresa.Visible = true;
                //    pnlEnvioDocs.Visible = false;
                //}
                //else
                // if(UltimoTransaccionConBHD == null)
                //{
                //  var  TransaccionConBHDAprobada = db.TransaccionesEmpBHD.Where(x => x.SolicitudId == transId && x.Estatus == Helper.IdEstadoBHDLocal).OrderByDescending(a => a.SolicitudId).FirstOrDefault();
                //    if (TransaccionConBHDAprobada != null)
                //    {
                //        pnlBhdEmpresa.Visible = false;
                //        pnlEnvioDocs.Visible = true;
                //        hlEnvioDocumentosTit.Visible = false;

                //        btnCompletarTransaccion.Visible = true;
                //        btnComprobarPagoBanco.Visible = false;
                //    }
                //    else
                //    {
                //        var TransaccionConBHDRechazada = db.TransaccionesEmpBHD.Where(x => x.SolicitudId == transId && x.Estatus == Helper.IdEstadoBHDLocalRechazado).OrderByDescending(a => a.SolicitudId).FirstOrDefault();
                //        if (TransaccionConBHDRechazada != null)
                //        {
                //            Master.ShowMessageError("El pago ha sido rechazado por el banco. Favor Intentar Nuevamente.");
                //        }
                //    }
                //}


            }
        }

        private void RedirectSiPagaynoEnviada()
        {
            int transId;
            var db = new OFV.CamaraWebsiteEntities();

            if (!int.TryParse(Request["nSolicitud"], out transId))
            {
                SolicitudInvalida();
                return;
            }
            var trans = (from t in db.Transacciones
                         where t.TransaccionId == transId
                         select t).FirstOrDefault();
            if (trans != null)
            {
                var habilitarPago = Helper.HabilarPagoTarjeta(trans.ServicioId);

                var dbWeb = new CamaraWebsiteEntities();
                var dbCom = new CamaraComunEntities();
                var tran = dbWeb.Transacciones.FirstOrDefault(t => t.TransaccionId == transId);
                var serv = dbCom.Servicio.First(s => s.ServicioId == tran.ServicioId);

                if (habilitarPago && trans.bPagada)
                    Response.Redirect(string.Format("/Empresas/CierreSolicitud.aspx?nSolicitud={0}&TipoServicioId={1}", transId, serv.TipoServicioId));
            }
        }

        private void RedirectSiNoEstaCompleta()
        {
            int transId;
            if (!int.TryParse(Request["nSolicitud"], out transId))
            {
                SolicitudInvalida();
                return;
            }

            //Si la  transaccion no ha sido completada entonces devuelveme a la pagina que me quede
            if (!LogTransaccionesMethods.EstaCompleta(transId))
            {
                string user = LogTransaccionesMethods.VerificarSiEstaIncompletaPorOtroUsuario(transId, User.Identity.Name.ToLower());

                if (string.IsNullOrEmpty(user))
                {
                    var dbWeb = new CamaraWebsiteEntities();
                    var dbCom = new CamaraComunEntities();
                    var tran = dbWeb.Transacciones.FirstOrDefault(t => t.TransaccionId == transId);
                    var serv = dbCom.Servicio.First(s => s.ServicioId == tran.ServicioId);

                    Session["transId"] = transId;
                    string urlantiguo = LogTransaccionesMethods.ObtenerUltimaURL(transId);
                    if (urlantiguo.Contains("TipoServicioId"))
                    {
                        string url = LogTransaccionesMethods.ObtenerUltimaURL(transId);
                    }
                    else
                    {
                        string url = string.Concat(LogTransaccionesMethods.ObtenerUltimaURL(transId), string.Format("&TipoServicioId={0}", serv.TipoServicioId));
                        Response.Redirect(url);
                    }
                }
                else
                {
                    ErrorMessage = string.Format("El usuario {0} debe completar la transaccion.", user);
                    Response.Redirect("/Empresas/Oficina.aspx");
                }
            }
        }

        private void EnableDownloadNotification()
        {
            pnlDocumetosEnviados.Visible = false;
            pnlDocumentoDescargar.Visible = true;
            hlDescargaDocumentos.NavigateUrl = String.Format("~/Operaciones/Shared/DescargaCert.aspx?nSolicitud={0}",
                                                             Request["nSolicitud"]);
        }
        private void LoadInterface()
        {
            //ID De la transaccion
            int transId;
            if (!int.TryParse(Request["nSolicitud"], out transId))
            {
                SolicitudInvalida();
                return;
            }

            //Verificar si es envio digital
            //bool esDigital = false;
            //Boolean.TryParse(Request.QueryString["EntregaDigital"], out esDigital);


            this.litNumSolicitud.Text = transId.ToString();

            //Acceso a Datos
            var db = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            var usr = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);

            var dbUsers = new DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties
                        .Where(c => c.UsuarioPadre == User.Identity.Name)
                        .ToList().Select(c => c.UserName.ToLower());

            var trans = (from t in db.Transacciones
                         where t.TransaccionId == transId &&
                               (t.UserName == User.Identity.Name.ToLower() || t.UserName == usr.UsuarioPadre || uHijos.Contains(t.UserName))
                         select t).FirstOrDefault();
            if (trans == null)
            {
                SolicitudInvalida();
                return;
            }
            //Habilitar boton de proceso de transaccion.
            var sePuedeEnviar = Helper.HabilarPagoTarjeta(trans.ServicioId);
            /*btnEnvioDocumentos.Visible = !(trans.bPagada && trans.bLoadedInSRM.HasValue &&
                                          trans.SrmTransaccionId.HasValue && trans.SrmTransaccionId.Value > 0 &&
                                          sePuedeEnviar);*/

            //Se guarda la transacción en sesión para poder pasar a PagosTarjeta
            //this.Transaccion = trans;

            var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(trans.CamaraId);

            var dbWeb = new CamaraWebsiteEntities();
            var dbCom = new CamaraComunEntities();
            var tran = dbWeb.Transacciones.FirstOrDefault(t => t.TransaccionId == transId);
            var serv = dbCom.Servicio.First(s => s.ServicioId == tran.ServicioId);

            string urlhlenviodatos = LogTransaccionesMethods.ObtenerUltimaURL(transId);
            if (string.IsNullOrWhiteSpace(urlhlenviodatos))
            {
                if (tran.TipoSociedadId != 7)
                {
                    var empresa = dbSrm.SociedadesRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                    hlEnvioDocumentosTit.NavigateUrl = String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&SociedadId={2}&TipoServicioId={3}&TipoSociedadId={4}", Request["nSolicitud"], trans.CamaraId, empresa.SociedadId.ToString(), tran.ServicioId, tran.TipoSociedadId);
                    hlEnvioDocumentosTit.Enabled = true;
                }
                else
                {
                    var persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                    hlEnvioDocumentosTit.NavigateUrl = String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&SociedadId={2}&TipoServicioId={3}&PersonaId={4}&TipoSociedadId={5}"
                        , Request["nSolicitud"], trans.CamaraId, "", tran.ServicioId, persona.PersonaId, tran.TipoSociedadId);
                    hlEnvioDocumentosTit.Enabled = true;
                }
            }
            else
            {
                hlEnvioDocumentosTit.NavigateUrl = urlhlenviodatos;
            }

            //if (Transaccion.ServicioId == 404 && Transaccion.RegistroId == 0)
            //{
            //    hlEnvioDocumentosTit.NavigateUrl = String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&TipoServicioId={2}&TipoSociedadId={3}", Request["nSolicitud"], trans.CamaraId, serv.TipoServicioId, tran.TipoSociedadId);
            //    hlEnvioDocumentosTit.Enabled = true;
            //}
            //else if (trans.ServicioId == 741)
            //{
            //    var empresa = dbSrm.PersonasRegistros.FirstOrDefault(x => x.NumeroRegistro == trans.NumeroRegistro);
            //    hlEnvioDocumentosTit.NavigateUrl = String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&TipoServicioId={2}&TipoSociedadId={3}&PersonaId={4}", Request["nSolicitud"], trans.CamaraId, serv.TipoServicioId, tran.TipoSociedadId, empresa.PersonaId);
            //    hlEnvioDocumentosTit.Enabled = true;
            //}
            //else
            //{
            //    if (tran.TipoSociedadId != 7)
            //    {
            //        var empresa = dbSrm.SociedadesRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
            //        hlEnvioDocumentosTit.NavigateUrl = String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&SociedadId={2}&TipoServicioId={3}&TipoSociedadId={4}", Request["nSolicitud"], trans.CamaraId, empresa.SociedadId.ToString(), serv.TipoServicioId, tran.TipoSociedadId);
            //        hlEnvioDocumentosTit.Enabled = true;
            //    }
            //    else
            //    {
            //        var persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
            //        hlEnvioDocumentosTit.NavigateUrl = String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&SociedadId={2}&TipoServicioId={3}&PersonaId={4}&TipoSociedadId={5}"
            //            , Request["nSolicitud"], trans.CamaraId, "", serv.TipoServicioId, persona.PersonaId, tran.TipoSociedadId);
            //        hlEnvioDocumentosTit.Enabled = true;
            //    }
            //}

            var transHelper = new TransaccionDevueltaHelper(Request);
            if (transHelper.EstaDevuelta())
            {
                if(!hlEnvioDocumentosTit.NavigateUrl.Contains("&estado=devuelto"))
                    hlEnvioDocumentosTit.NavigateUrl += "&estado=devuelto";
            }

            //Tipo de sociedad
            var repTipoSociedad = new DataAccess.EF.Repository<TipoSociedad, CamaraComunEntities>(new CamaraComunEntities());
            var tipoSociedad = repTipoSociedad.SelectByKey(TipoSociedad.PropColumns.TipoSociedadId, trans.TipoSociedadId);
            if (tipoSociedad != null)
            {
                this.lblTipoEmpresa.Text = tipoSociedad.Descripcion;
                this.lblTitTipoEmpresa.Text = tipoSociedad.Etiqueta;
                this.titlelblTipoEmpresa.Visible = true;
            }
#region Llenado de controles / Informacion de la transacción

            if (trSDQ)
            {
                var empresa = new SociedadesRegistros();
                var persona = new PersonasRegistros();

                if (tran.TipoSociedadId != 7 && tran.TipoSociedadId != 0)
                {
                    empresa = dbSrm.SociedadesRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                }
                else
                {
                    persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                }
                hlVerFactura.Visible = false;
                btnDownloadFormularioSolicitud.Visible = false;
                string qs = String.Empty; //
                switch (serv.TipoServicioId)
                {
                    case 3:
                        //"/Empresas/RevisionDocumentos.aspx?SociedadId=&RegistroId=134855&CamaraId=SDQ&TipoSociedadId=2&nSolicitud=39131"
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&nSolicitud={4}&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, trans.TransaccionId);

                        if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;

                        hlEnProblemaContinuar.NavigateUrl = "/Empresas/RevisionDocumentos.aspx?" + qs;
                        break;
                    case 5:
                        //"/Operaciones/Shared/RegDup.aspx?SociedadId=33497&RegistroId=134855&CamaraId=SDQ&TipoSociedadId=2&TipoServicioId=5"
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&nSolicitud={5}&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, serv.TipoServicioId, tran.TransaccionId);

                        persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                        if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;

                        hlEnProblemaContinuar.NavigateUrl = "/Operaciones/Shared/RegDup.aspx?" + qs;
                        break;
                    case 7:
                        //"/Operaciones/Shared/Certificaciones.aspx?SociedadId=33497&RegistroId=134855&CamaraId=SDQ&TipoSociedadId=2&TipoServicioId=7"
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&nSolicitud={5}&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, serv.TipoServicioId, tran.TransaccionId);

                        if (tipoSociedad != null)
                        {
                            persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                            if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;
                        }

                        hlEnProblemaContinuar.NavigateUrl = "/Operaciones/Shared/Certificaciones.aspx?" + qs;
                        break;
                    case 8:
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&nSolicitud={5}&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, serv.TipoServicioId, tran.TransaccionId);

                        persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                        if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;

                        hlEnProblemaContinuar.NavigateUrl = "/Empresas/RevisionDocumentos.aspx?" + qs;
                        break;
                    case 39:
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&nSolicitud={5}&esCertificacion=1&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, serv.TipoServicioId, tran.TransaccionId);

                        persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                        if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;

                        hlEnProblemaContinuar.NavigateUrl = "/Operaciones/Shared/CopiasCert.aspx?" + qs;
                        break;
                    case 17:
                        //"/Empresas/ActualizarDatosGenerales.aspx?SociedadId=33497&RegistroId=134855&CamaraId=SDQ
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&nSolicitud={5}&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, serv.TipoServicioId, tran.TransaccionId);

                        persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                        if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;

                        hlEnProblemaContinuar.NavigateUrl = "/Empresas/ActualizarDatosGenerales.aspx?" + qs;
                        break;
                    case 38:
                        qs = String.Format("SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&nSolicitud={5}&BorrarDocumentos=true",
                            empresa?.SociedadId, tran.RegistroId, tran.CamaraId, tran.TipoSociedadId, serv.TipoServicioId, tran.TransaccionId);

                        persona = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == trans.RegistroId);
                        if (tipoSociedad.TipoSociedadId == 7) qs += "&PersonaId=" + persona.PersonaId;

                        hlEnProblemaContinuar.NavigateUrl = "/Empresas/RevisionDocumentos.aspx?" + qs;
                        break;

                    default:
                        break;
                }

            }

            this.lblFechaRecepcion.Text = trans.Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            //this.lblRNC.Text = trans.RNCSolicitante;
            //this.titlelblRnc.Visible = false; //!String.IsNullOrEmpty(trans.RNCSolicitante);
            this.lblTransaccion.Text = trans.TransaccionId.ToString();
            this.lblCamara.Text = trans.CamaraId;

            //No. Registro
            this.titlelblNoRegistro.Visible = (trans.NumeroRegistro != null && trans.NumeroRegistro > 0);
            this.lblNoRegistro.Text = trans.NumeroRegistro.ToString();


            //Nombre de la empresa
            //if (trans.NumeroRegistro.HasValue)
            //{
            //var empresa = dbSrm.SociedadesRegistros.Where(s => s.NumeroRegistro == trans.NumeroRegistro).FirstOrDefault();
            //if (empresa != null)
            //if(Transaccion.RegistroId != 0)NombreEmpresa = empresa.Sociedades.NombreSocial;
            /*}
            else
            {
                //TODO: esta dando error cuando es registroid = 0
                if (trans.RegistroId > 0)
                {
                    var empresa = db.Sociedades.Where(a => a.RegistroId == trans.RegistroId).First();
                    if (empresa != null)
                        NombreEmpresa = empresa.NombreSocial;
                }
            }*/
            this.lblEmpresa.Text = Transaccion.NombreSocialPersona;
            this.lblTitRazonSocial.Text = Transaccion.RegistroId != 0 ? NombreEmpresa : Transaccion.ANombreQuien;

#endregion

            //Estado actual
            if (trans.EstatusTransacciones != null)
            {
                //Ultimo estado 
                //lblEstado.Text = OFV.TransaccionesController.GetUltimoEstado(trans.TransaccionId).EstatusTransDescripcion;
                lblEstado.Text = trans.EstatusTransacciones.EstatusTransDescripcion;

                //Si la cantidad de entradas en el seguimiento histórico tiene más de una entrada 
                //quiere decir que la transacción ya está en el SRM/se le está dando seguimiento
                var ctrl = new OFV.TransaccionesController();
                if (trans.EstatusTransId != 15)
                    this.pnlEnvioDocs.Visible = ctrl.GetCountTransaccionesHistoria(trans.TransaccionId) <= 1;
                if (trans.EstatusTransId == 40)
                    this.pnlEnvioDocs.Visible = true;
            }

            //Informacion del pago de la factura, si no se requiere documentos...
            if (!this.pnlEnvioDocs.Visible && !trans.bPagada)
            {
                if (trans.ServicioId != Helper.ServicioInclusionId)
                {
                    if (tran.EstatusTransId != 15)
                    {
                        this.lblFacturaPagada.Visible = true;
                    }
                    if (tran.EstatusTransId == 39)
                    {
                        this.lblFacturaPagada.Visible = false;
                    }
                    if (tran.EstatusTransId == 42)
                    {
                        this.lblFacturaPagada.Visible = false;
                    }
                }

                //Data Access Objects
                var transacciones = new OFV.TransaccionDocumentosController();
                var repServicioRequerido = new ServicioDocumentoRequeridoRepository();
                var servicioDocSeleccionados = transacciones.GetDocumentosSeleccionados(Transaccion.TransaccionId);
                var documentos = repServicioRequerido.GetDocumentosSeleccionados(Transaccion.ServicioId,
                                                                                 Transaccion.TipoSociedadId);
                if (documentos.Count() > servicioDocSeleccionados.Count)
                    hfDocumentosRequeridosSeleccionados.Value = "1";

                this.lnkRevisionDocumentos.NavigateUrl =
                    String.Format("/Operaciones/Shared/FormaEntrega.aspx?CamaraId={0}&nSolicitud={1}",
                                  trans.CamaraId, trans.TransaccionId);
            }
            else
            {
                //Si ya se pagó, se muestra la información para enviar documentos
                if (tran.EstatusTransId != 15)
                {
                    this.lblFacturaPagada.Visible = false;
                }

                var helper = new TransaccionDevueltaHelper(Request);
                if (!helper.EstaDevuelta())
                {
                    this.pnlEnvioDocs.Visible = !trans.bLoadedInSRM.GetValueOrDefault();
                    if (trans.EstatusTransId == 40)
                    {
                        this.pnlEnvioDocs.Visible = true;
                        this.pnlEnProblema.Visible = false;
                    }
                }
                else
                {
                    this.pnlEnvioDocs.Visible = true;
                    this.pnlEnProblema.Visible = false;
                }
            }

            //Estado actual
            if (trans.EstatusTransacciones != null)
            {
                //Ultimo estado 
                //lblEstado.Text = OFV.TransaccionesController.GetUltimoEstado(trans.TransaccionId).EstatusTransDescripcion;
                lblEstado.Text = trans.EstatusTransacciones.EstatusTransDescripcion;

                //Si la cantidad de entradas en el seguimiento histórico tiene más de una entrada 
                //quiere decir que la transacción ya está en el SRM/se le está dando seguimiento
                var ctrl = new OFV.TransaccionesController();
                var helper = new TransaccionDevueltaHelper(Request);
                if (!helper.EstaDevuelta())
                {
                    if (tran.EstatusTransId != 15) this.pnlEnvioDocs.Visible = ctrl.GetCountTransaccionesHistoria(trans.TransaccionId) <= 1;
                    else
                        this.pnlEnvioDocs.Visible = false;
                    if (tran.EstatusTransId == 40)
                    {
                        this.pnlEnvioDocs.Visible = true;
                        this.pnlEnProblema.Visible = false;

                    }
                }
                else
                {
                    this.pnlEnvioDocs.Visible = true;
                    this.pnlEnProblema.Visible = false;

                }

            }

            long.TryParse(Request.QueryString["FacturaId"], out long facturaId);
            if (facturaId <= 0)
            {
                using (OFV.CamaraWebsiteEntities dbWebsite = new OFV.CamaraWebsiteEntities())
                {
                    var factura = dbWebsite.Facturas
                        .Where(d => d.TransaccionId.HasValue && d.TransaccionId.Value == trans.TransaccionId && (d.Usuario == User.Identity.Name || uHijos.Contains(d.Usuario)))
                        .OrderByDescending(d => d.FacturaId)
                        .FirstOrDefault();

                    if (factura == null) this.hlVerFactura.Visible = false;

                    else if (factura.TotalFactura == 0m && factura.PagoAnterior == 0m) this.hlVerFactura.Visible = false;

                    else this.hlVerFactura.NavigateUrl = "~/Empresas/ImprimirFactura.aspx?FacturaId=" + factura.FacturaId;
                    if (tran.EstatusTransId == 40)
                    {
                        this.hlVerFactura.Visible = false;
                    }
                }
            }
            //this.hlVerSolicitud.NavigateUrl = "~/Empresas/ImprimirSolicitud.aspx?nSolicitud=" + trans.TransaccionId;
            this.hlEnvioDatos.NavigateUrl = "~/Empresas/EnvioDatos.aspx?nSolicitud=" + trans.TransaccionId;

            using (OFV.CamaraWebsiteEntities dbWebsite = new OFV.CamaraWebsiteEntities())
            {
                var transaccionDocumento = dbWebsite.TransaccionesDocumentos
                    .Where(d => d.TransaccionId == trans.TransaccionId && d.TipoDocumentoId == 1560 && (d.Usuario == User.Identity.Name || uHijos.Contains(d.Usuario)))
                    .OrderByDescending(d => d.FechaEnvio)
                    .FirstOrDefault();

                FormularioSolicitud = transaccionDocumento;
                if (transaccionDocumento == null) btnDownloadFormularioSolicitud.Visible = false;
                if (tran.EstatusTransId == 40) btnDownloadFormularioSolicitud.Visible = false;
            }
        }

        private void SolicitudInvalida()
        {
            ErrorMessage = "Numero de solicitud invalido o no existente.";
            Response.Redirect("/Empresas/Oficina.aspx");
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.btnEnvioDocumentos_Click(object, EventArgs)'
        protected void btnEnvioDocumentos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.btnEnvioDocumentos_Click(object, EventArgs)'
        {
            var db = new OFV.CamaraWebsiteEntities();
            var usr = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);

            //ID De la transaccion
            int transId;
            if (!int.TryParse(Request["nSolicitud"], out transId))
            {
                SolicitudInvalida();
                return;
            }

            var dbUsers = new DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties
                        .Where(c => c.UsuarioPadre == User.Identity.Name)
                        .ToList().Select(c => c.UserName.ToLower());

            var trans = (from t in db.Transacciones
                         where t.TransaccionId == transId &&
                               (t.UserName == User.Identity.Name.ToLower() || t.UserName == usr.UsuarioPadre || uHijos.Contains(t.UserName))
                         select t).FirstOrDefault();
            if (trans == null)
            {
                SolicitudInvalida();
                return;
            }
            var sePuedeEnviar = Helper.HabilarPagoTarjeta(trans.ServicioId);

            if (trans.bPagada && !trans.bLoadedInSRM.HasValue && !trans.SrmTransaccionId.HasValue && sePuedeEnviar)
            {
                var helper = new Helper();
                var Error = "";
                bool saved = helper.GrabarAlSrm(trans.CamaraId, trans.TransaccionId, trans.NombreContacto,
                                   trans.TelefonoContacto, out Error);
                ErrorMessage = Error;
                if (saved)
                {
                    ErrorMessage = "Su Transacción se ha enviado para ser procesada por un analista.";
                    Response.Redirect("~/Empresas/Oficina.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje",
                                                   "alert('" +
                                                   "No se pudo procesar esta transacción, por favor inténtelo más tarde." + "');",
                                                   true);
                }
                //Response.Redirect(string.Format("/Empresas/EnvioDatos.aspx?nSolicitud={0}", transId));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje",
                                                    "alert('" +
                                                    "No se pudo procesar esta transacción, por favor inténtelo más tarde." + "');",
                                                    true);
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.btnDownloadFormularioSolicitud_Click(object, EventArgs)'
        protected void btnDownloadFormularioSolicitud_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.btnDownloadFormularioSolicitud_Click(object, EventArgs)'
        {
            if (FormularioSolicitud == null)
            {
                Master.ShowMessageError("El Formulario de Solicitud no se ha generado");
                return;
            }

            using (OFV.CamaraWebsiteEntities dbWebsite = new OFV.CamaraWebsiteEntities())
            {
                dbWebsite.TransaccionesDocDescargas.AddObject(new OFV.TransaccionesDocDescargas
                {
                    DocContent = FormularioSolicitud.DocContent,
                    FechaDescarga = DateTime.Now,
                    NombreSocialOrComment = NombreEmpresa,
                    TransaccionId = FormularioSolicitud.TransaccionId,
                    UserName = User.Identity.Name.ToLower()
                });
                dbWebsite.SaveChanges();
            }

            Response.Clear();
            Response.ContentType = FormularioSolicitud.DocContentType;
            Response.AddHeader("content-disposition", "attachment; filename=" + FormularioSolicitud.Nombre);
            Response.BufferOutput = true;
            Response.OutputStream.Write(FormularioSolicitud.DocContent, 0, FormularioSolicitud.DocContent.Length);
            Response.End();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.rgridHistorico_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridHistorico_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.rgridHistorico_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                var db = new CamaraComunEntities();
                var ofv_db = new CamaraWebsiteEntities();
                var data = (item.DataItem as HistoricoTransacciones);

                var servicioNombre = db.Servicio.FirstOrDefault(x => x.ServicioId == data.ServicioId);
                var lblServicio = (Label)e.Item.FindControl("ServicioGrid");
                lblServicio.Text = servicioNombre.Descripcion;

                var estadoNombre = ofv_db.EstatusTransacciones.FirstOrDefault(x => x.EstatusTransId == data.estado);
                var lblEstadoNombre = (Label)e.Item.FindControl("lblEstadoGrid");
                lblEstadoNombre.Text = estadoNombre.EstatusTranNombre;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.CancelarTransaccionProblema(object, EventArgs)'
        protected void CancelarTransaccionProblema(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.CancelarTransaccionProblema(object, EventArgs)'
        {
            Response.Redirect("/Empresas/Oficina.aspx");
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.ContinuarTransaccionProblema(object, EventArgs)'
        protected void ContinuarTransaccionProblema(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.ContinuarTransaccionProblema(object, EventArgs)'
        {
            var serv = dbCom.Servicio.First(s => s.ServicioId == Transaccion.ServicioId);
            var socCtrl = new SociedadesController();
            var registro = socCtrl.FindRegistro(Transaccion.RegistroId, Transaccion.CamaraId);
            var sociedad = socCtrl.FetchSociedadesRegistroBySociedadId(registro.SociedadId, Transaccion.CamaraId);
            Response.Redirect(String.Format("/Empresas/RevisionDocumentos.aspx?nSolicitud={0}&CamaraId={1}&TipoServicioId={2}&sociedadId={3}", Request["nSolicitud"], Transaccion.CamaraId, serv.TipoServicioId, sociedad.SociedadId));
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.rgridHistorico_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        protected void rgridHistorico_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleTransaccion.rgridHistorico_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        {
            var dbOfv = new CamaraWebsiteEntities();
            var comun = new CamaraComunEntities();
            var result = new List<HistoricoTransacciones>();
            var sortHistoria = new List<HistoricoTransacciones>();
            int transId;
            int.TryParse(Request["nSolicitud"], out transId);
            var historia = dbOfv.HistoricoTransacciones.Where(x => x.TransaccionId == transId).OrderBy(x => x.fecha);

            foreach (var item in historia)
            {
                if (sortHistoria.Count != 0)
                {
                    if (item.estado == sortHistoria.Last().estado && item.ServicioId == sortHistoria.Last().ServicioId)
                        continue;
                    sortHistoria.Add(item);
                }
                else
                    sortHistoria.Add(item);
            }

            if (historia != null)
            {
                result.AddRange(sortHistoria);
            }
            rgridHistorico.DataSource = "";
            rgridHistorico.DataSource = result;
            rgridHistorico.VirtualItemCount = result.Count();
        }

        //protected void btnCompletarTransaccion_Click(object sender, EventArgs e)
        //{
        //    //   var checkncf = (Checkboxncf.Checked) ? true : false;



        //    //ID De la transaccion
        //    // int transId;
        //    // transId = Convert.ToInt32(Request["nSolicitud"]); 
        //    int transId;
        //    int.TryParse(Request["nSolicitud"], out transId);



        //    PagosTarjeta PagoTarj = new PagosTarjeta();
        //    var result = PagoTarj.ProcesarTransaccionMandarSRM(transId, true);           
        //    var dbWeb = new CamaraWebsiteEntities();
        //    var resultadofbd = dbWeb.TransaccionesEmpBHD.Where(x => x.SolicitudId == transId).FirstOrDefault();

        //    if (resultadofbd != null)
        //    {

        //        using (var db = new CamaraWebsiteEntities())
        //        {
        //            var resultt = db.TransaccionesEmpBHD.Where(x => x.SolicitudId == transId).FirstOrDefault();
        //            if (resultt != null)
        //            {
        //                resultt.Estatus = Helper.IdEstadoBHDLocalPagado; // 2;
        //                db.SaveChanges();
        //            }
        //        }
        //    }

        //    transId = 0;
        //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + result + "');", true);

        //    Response.Redirect(String.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true", Request["nSolicitud"]));
            

        //}

        //BHD, COMPROBAR PAGO - 2021-07-10: 
        //---------------------
        //Transacciones Pagos Boton BHD:
//        public void getWhileLoopData(int transId)

//        {

//            string htmlStr = "";
//            var userId = User.Identity.Name.ToLower();         

//            //buscar transacciones pendientes:
//            var LTransaccionBHD = new OFV.TransaccionesController().LTransaccionesBHDById(userId, transId);
//            //buscar transacciones pendientes <> 1:
//           if(LTransaccionBHD != null)
//         {
//                //para mandar el token priemro de cada transaccion: 
//                string URL = ConfigurationManager.AppSettings["urltokenunico"].ToString();
//                string DATA2 = @"{
//                ""scope"": ""pagosSometidos"",
//                ""clientId"": ""clientIdString"",
//                ""clientSecret"": ""clientSecretString"",
//                ""channel"": ""BDP"",
//                ""transactionId"": " + LTransaccionBHD.TransactionId + "}";

//                DATA2 = DATA2.Replace("clientIdString", ConfigurationManager.AppSettings["clientId"].ToString());
//                DATA2 = DATA2.Replace("clientSecretString", ConfigurationManager.AppSettings["clientSecret"].ToString());


//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
//                request.Method = "POST";
//                request.ContentType = "application/json";
//                request.ContentLength = DATA2.Length;

//                var test = request.GetResponseAsync();


//                using (Stream webStream = request.GetRequestStream())

//                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
//                {
//                    requestWriter.Write(DATA2);
//                }

//                string ResultadoBanner = "";
//                WebResponse webResponse = request.GetResponse();
//                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
//                using (StreamReader responseReader = new StreamReader(webStream))
//                {
//                    string response = responseReader.ReadToEnd();
//                    string[] words = response.Split('\"');
//                    ResultadoBanner = words[3];
//                }

//                Task<string> ff = TestMethodAsync(LTransaccionBHD.TransactionId.Trim(), LTransaccionBHD.SolicitudId.Value, ResultadoBanner);


              
//            }


          


//            // return htmlStr;
//        }


//#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'
//        public void ResultadoPago(string Referencia, string transaccionid, string token)
//        {
//#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'


//            string URL = ConfigurationManager.AppSettings["urlConsultar"].ToString();


//            string DATA3 = @"{
//                ""transactionId"": ""transactionIdVariable"",
//                ""channel"": ""BDP"",
//                ""reference"": ""referenceVariable"",
//                ""providerId"": ""providerIdString"",
//                ""serviceId"": ""serviceIdString"" };";

//            var tran = transaccionid.Trim();
//            var refe = Referencia.Trim();

//            DATA3 = DATA3.Replace("transactionIdVariable", tran);
//            DATA3 = DATA3.Replace("referenceVariable", refe);
//            DATA3 = DATA3.Replace("providerIdString", ConfigurationManager.AppSettings["providerId"].ToString());
//            DATA3 = DATA3.Replace("serviceIdString", ConfigurationManager.AppSettings["serviceId"].ToString());


//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
//            request.Method = "POST";
//            request.ContentType = "application/json";
//            request.ContentLength = DATA3.Length;

//            var test = request.GetResponseAsync();
//            request.Headers.Add("Authorization", token.Trim());

//            using (Stream webStream = request.GetRequestStream())

//            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
//            {
//                requestWriter.Write(DATA3);
//            }


//            WebResponse webResponse = request.GetResponse();


//            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
//            using (StreamReader responseReader = new StreamReader(webStream))
//            {
//                string response = responseReader.ReadToEnd();
//                string[] words = response.Split('\"');
//                var ResultadoBanner = words[3];
//            }
//        }

//        //---------------------
//#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
//        public async Task<string> TestMethodAsync(string transaccionid, int referencia, string token)
//#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
//        {

//            string URL = Helper.urlBHDConsultar; // "https://api-sqa.bhdleon.com.do/bhdleon/boton/v2/clientes/pagos/sometidos/consultar";
//            var ResultadoPago = "";

//            var userId = User.Identity.Name.ToLower();

//            try
//            {
//                var apicallObject = new
//                {
//                    transactionId = transaccionid,
//                    channel = "BDP",
//                    reference = referencia.ToString(),
//                    providerId = Helper.providerIdBHD, // "90909106",
//                    serviceId = Helper.serviceIdBHD,// "123456803",
//                };

//                if (apicallObject != null)
//                {
//                    var bodyContent = JsonConvert.SerializeObject(apicallObject);
//                    using (HttpClient client = new HttpClient())
//                    {
//                        var content = new StringContent(bodyContent.ToString(), System.Text.Encoding.UTF8, "application/json");
//                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
//                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token); // _token = access token

//                        var response = await client.PostAsync(URL, content); // _url =api endpoint url

//                        if (response != null)
//                        {
//                            var jsonString = await response.Content.ReadAsStringAsync();
//                            try
//                            {
//                                string[] words = jsonString.Split('\"');
//                                ResultadoPago = words[37];

//                                //  if (ResultadoPago == "001")                                    
//                                if (ResultadoPago == Helper.IdEstadoBHDEmpresarial)
//                                {
//                                    using (var db = new CamaraWebsiteEntities())
//                                    {
//                                        //buscar transacciones pendientes <> 1:
//                                        var LTransaccionesBHDDist1 = new OFV.TransaccionesController().LTransaccionesBHDById(userId, Convert.ToInt32(referencia));
//                                        //  var result = LTransaccionesBHDDist1.Where(x => x.reference == referencia).FirstOrDefault();


//                                        if (LTransaccionesBHDDist1 != null)
//                                        {                                       

//                                            new OFV.TransaccionesController().ActualizarEstadosBHD(referencia, Helper.IdEstadoBHDLocal); //ver porque el estado 3
//                                        }
//                                    }

//                                }
//                                else //008 //rechazado
//                                if (ResultadoPago == Helper.IdEstadoBHDEmpresarialRechazo)
//                                {
//                                    using (var db = new CamaraWebsiteEntities())
//                                    {
//                                        //buscar transacciones pendientes <> 1:
//                                        var LTransaccionesBHDDist1 = new OFV.TransaccionesController().LTransaccionesBHDById(userId, Convert.ToInt32(referencia));
//                                        //  var result = LTransaccionesBHDDist1.Where(x => x.reference == referencia).FirstOrDefault();


//                                        if (LTransaccionesBHDDist1 != null)
//                                        {

//                                            new OFV.TransaccionesController().ActualizarEstadosBHD(referencia, Helper.IdEstadoBHDLocalRechazado); //ver porque el estado 3
//                                        }
//                                    }

//                                    Master.ShowMessageError("El pago ha sido rechazado por el banco.");

//                                }

//                                return ResultadoPago.ToString();
//                            }
//                            catch (Exception e)
//                            {
//                                throw e;
//                            }
//                        }
//                    }
//                }

//                return null;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        protected void btnComprobarPagoBanco_Click(object sender, EventArgs e)
//        {

//            //new 2021-07-05, get transacciones BHd, valida estado, update:
//            int transId;
//                  int.TryParse(Request["nSolicitud"], out transId);
//            var authenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
//            if (!authenticated)
//            {
//                Response.Redirect("~/Account/Login.aspx");
//            }

//            //COMPROBAR
//            getWhileLoopData(transId);


//            Response.Redirect(String.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true", Request["nSolicitud"]));
//        }



    }
}