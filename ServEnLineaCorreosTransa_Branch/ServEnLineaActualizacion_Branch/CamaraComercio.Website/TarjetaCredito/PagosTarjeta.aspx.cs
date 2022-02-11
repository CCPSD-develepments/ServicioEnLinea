using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.DTO;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.wsFacturacion;
using ModuloPago;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using Facturas = CamaraComercio.DataAccess.EF.OficinaVirtual.Facturas;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using TransaccionDetalle = CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionDetalle;
using Transacciones = CamaraComercio.DataAccess.EF.OficinaVirtual.Transacciones;


namespace CamaraComercio.Website.TarjetaCredito
{
    ///<summary>
    /// Página principal para el pago de facturas mediante tarjetas de crédito
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class PagosTarjeta : EnvioDatosPage
    {
        private const string SiglaExtranjera = "EXT";
        readonly ProcesarPagoVisanet pago = new ProcesarPagoVisanet();

        //variable temporal buscar la cuenta del sello: ep 2021-05-14
        ////private int SellosColegioServiceId = Convert.ToInt32(ConfigurationManager.AppSettings["SellosColegioServiceId"]);
        private string SellosColegioCuenta = ConfigurationManager.AppSettings["SellosColegioCuenta"];



        #region Propiedades
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.FacturaSrmId'
        protected int FacturaSrmId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.FacturaSrmId'
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["FacturaSrmId"]) ? int.Parse(Request.QueryString["FacturaSrmId"]) : 0; }
            set { DefaultQueryString = String.Format("FacturaSrmId={0}", value); }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.CostoServicio'
        protected Decimal CostoServicio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.CostoServicio'
        {
            get
            {
                if (Session["CostoServicio"] == null)
                    Session["CostoServicio"] = 0M;

                return (Decimal)Session["CostoServicio"];
            }
            set
            {
                Session["CostoServicio"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.CostoTransaccion'
        protected Decimal CostoTransaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.CostoTransaccion'
        {
            get
            {
                if (Session["CostoTransaccion"] == null)
                    Session["CostoTransaccion"] = 0M;

                return (Decimal)Session["CostoTransaccion"];
            }
            set
            {
                Session["CostoTransaccion"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.Credito'
        protected Decimal Credito
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.Credito'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.Transaccion'
        protected Transacciones Transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.Transaccion'
        {
            get
            {
                //if (Session["Transacciones"] == null)
                //    Session["Transacciones"] = new Transacciones();

                //return Session["Transacciones"] as Transacciones;

                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);

                    if (transa != null)
                    {
                        return transa;
                    }
                    else
                    {
                        return new Transacciones();
                    }
                }
                else
                {
                    return new Transacciones();
                }
            }
            set
            {
                Transaccion = value as Transacciones;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ServiciosDefault'
        public static ServicioSection ServiciosDefault
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ServiciosDefault'
        {
            get
            {
                return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.EsConstitucion'
        protected bool EsConstitucion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.EsConstitucion'
        {
            get
            {
                if (Transaccion == null)
                    return false;
                var service =
                    ServiciosDefault.Servicios.FirstOrDefault(s => s.TipoSociedadId == Transaccion.TipoSociedadId);

                return service != null && service.ServicioConstitucionId == Transaccion.ServicioId;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.EsCertificacionSimple'
        protected bool EsCertificacionSimple
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.EsCertificacionSimple'
        {
            get
            {
                var servicio = new CamaraComunEntities().Servicio.FirstOrDefault(a => a.ServicioId == Transaccion.ServicioId);
                return (servicio.ServicioFlowId == Helper.ServicioFlowIdNoRequiereAnalisis ||
                        Transaccion.TipoModeloId.HasValue);
            }
        }

        /// <summary>
        /// Id de la transacción en CamaraWebsite
        /// </summary>
        private int? TransaccionId
        {
            get
            {
                var parm = Request.GetParam("nSolicitud");
                if (parm.Length > 0)
                {
                    var id = 0;
                    if (Int32.TryParse(parm, out id))
                        return id;
                    return null;
                }
                return null;
            }
        }

        /// <summary>
        /// Token de respuesta de la transacción
        /// </summary>
        private string TokenId
        {
            get { return Request.GetParam("confirmationCode"); }
        }

        /// <summary>
        /// Parametro con el estatus de la transaccion (desde el transaccional)
        /// </summary>
        private string Status
        {
            get { return Request.GetParam("status"); }
        }

        /// <summary>
        /// Coleccion de errores retornados por la transacción
        /// </summary>
        private List<string> Errors
        {
            get
            { return Request.GetParam("errors").Split(',').ToList(); }
        }

        private int CantidadCertificaciones { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.BackUrl'
        protected string BackUrl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.BackUrl'
        {
            get
            {
                /*var noSolicitud = Request.QueryString["nSolicitud"];
                var tipoModeloId = Request.QueryString["TipoModeloId"];
                var esCertificacion = Request.QueryString["EsCertificacion"];
                var camaraId = Request.QueryString["CamaraId"];

                return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";*/

                return $"~/Empresas/EnvioDatos.aspx{DefaultQueryString}";
            }
        }
        private bool ReembolsoExedente = false;
        private decimal pagadoTarjeta = 0M;
        private decimal pagadoNota = 0M;
        #endregion

        //objeto de prueba para la Nota de Credito en desarrollo
#if DEBUG
        #region objeto nota de credito de desarrolo
        private FormaPagoDearrollo NotaCredito
        {
            get;
            set;
        }
        #endregion
#else
        #region objeto nota de credito de produccion

        ServicioFacturacion facturacion = new ServicioFacturacion()
        {
            Timeout = Helper.TimeOutWS
        };

        private FormaPagoDearrollo NotaCredito { get; set; }

        private FormaPagoDearrollo VoucherNotaCredito { get; set; } //ep 2021-05-10
        #endregion
#endif
        #region Eventos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.Page_Load(object, EventArgs)'
        {

            bool trSDQ;

            var context = (CamaraSRMEntities)null;

            if (CamaraId == "")
            {
                context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext("SDQ");
                trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == this.TransaccionId && x.DesdeOfv)?.VieneProblemas == true ? true : false;
            }
            else
            {
                context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == this.TransaccionId && x.DesdeOfv)?.VieneProblemas == true ? true : false;

            }



            if (!IsValidRequestParameters()) return;


            //var padreUser = User.Identity.Name.ToLower();

            //var rep = new DataAccess.EF.Membership.UsuariosController();
            //var usuariosHijo = rep.FetchByUsuarioPadre(User.Identity.Name, "1");
            //var hijos = new List<string>();
            //foreach (var item in usuariosHijo)
            //{
            //    hijos.Add(item.UserName.ToLower());
            //}

            if (this.TransaccionId != 0)
            {
                var db = new CamaraWebsiteEntities();
                var trans = (from tr in db.Transacciones
                             where tr.TransaccionId == TransaccionId && (tr.UserName.Equals(User.Identity.Name.ToLower()) /*|| hijos.Contains(tr.UserName)*/)
                             select tr).FirstOrDefault();


                if (trans == null) return;

            }



            if (this.TransaccionId != 0)
            {
                var dbOFV = new OFV.CamaraWebsiteEntities();
                var tr = dbOFV.Transacciones.Where(x => x.TransaccionId == this.TransaccionId).FirstOrDefault();
                if (tr != null)
                {

                    var redirectUrl = string.Format("/Empresas/CierreSolicitud.aspx{0}", DefaultQueryString);
                    if (tr.bPagada) Response.Redirect(redirectUrl);

                    var docEnviados = dbOFV.TransaccionesDocumentos.Where(x => x.TransaccionId == tr.TransaccionId);
                    var transacDocSelec = dbOFV.TransaccionDocSeleccionado.Where(x => x.TransaccionId == tr.TransaccionId);

                    if (docEnviados.Count() != 0 && transacDocSelec.Count() != 0)
                    {
                        foreach (var item in transacDocSelec)
                        {
                            if (!docEnviados.Any(x => x.TipoDocumentoId == item.TipoDocumentoId))
                            {
                                Response.Redirect($"/Empresas/EnvioDatos.aspx{DefaultQueryString}");
                            }
                        }
                    }
                }
            }



            if (trSDQ)
            {
#if DEBUG
                NotaCredito = new FormaPagoDearrollo();
                NotaCredito.Id = 1;
                NotaCredito.Valor = 1000M;
                NotaCredito.NumeroNota = 1;
                Credito = NotaCredito.Valor;
#endif

#if !DEBUG
                var tranSDQ = context.Transacciones.FirstOrDefault(c => c.TransaccionIdAnterior == TransaccionId && c.DesdeOfv);
                CargaNotaCredito(tranSDQ.TransaccionId);
                if (trSDQ)
                {
                    var dbOFV = new OFV.CamaraWebsiteEntities();
                    var tr = dbOFV.Transacciones.Where(x => x.TransaccionId == this.TransaccionId).FirstOrDefault();
                    if (tr != null)
                    {
                        int.TryParse(tr.SrmTransaccionId.ToString(), out int srmTransa);
                        var verficarNota = facturacion.ValidacionVigenciaNotaCredito(srmTransa, tr.CamaraId);
                        if (verficarNota.DiasTranscurridos > 90 && verficarNota.NotaCreditoValida.Equals("False"))
                        {
                            pnlNotaProblema.Visible = true;
                            lblMensajeNota.Visible = true;
                            lblMensajeNota.Text = !string.IsNullOrWhiteSpace(Helper.MensajeNotaNovDiasConfirmacionPago)
                                ? Helper.MensajeNotaNovDiasConfirmacionPago : "No mensaje";
                            rblreembolsoExedente.Visible = false;
                            rblreembolsoExedentetitulo.Visible = false;
                        }
                    }

                }
#endif
            }
            int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantidadCertificaciones);
            CantidadCertificaciones = cantidadCertificaciones <= 0 ? 1 : cantidadCertificaciones;

            //Validacion de la hora de oficina
            if (!Utils.IsHorarioOficina())
                hfHoraOficina.Value = "1";

            //Parametros de Transaccional VisaNet
            var vDTO = new VisanetDTO();

            //Postback
            if (IsPostBack) return;
            var pantallaIniciada = false;

            //Validacion de errores
            if (this.Status.ToLower() == "error")
            {
                var errores = Request.GetParam("Errors");
                Master.ShowMessageError(errores);
            }

            if (pago.EsRepuestaVisanet)
            {
                var visanet = pago.RequestVisanet(EnumSystemType.CamaraOnline);

                if (!string.IsNullOrEmpty(visanet.AuthCode))
                {
                    vDTO.Amount = visanet.Amount;
                    vDTO.AuthCode = visanet.AuthCode;
                    vDTO.Currency = visanet.Currency;
                    vDTO.MerchantKey = visanet.MerchantKey;
                    vDTO.OrderID = visanet.OrderID;
                    vDTO.ReferenceCode = visanet.ReferenceCode;
                    vDTO.Tarjeta = visanet.Tarjeta;

                    ProcesarPagoTarjeta(vDTO);

                }
            }
            else if (pago.EsRepuestaBHD)
            {

                var visanet = pago.RequestBHD(EnumSystemType.CamaraOnline, this.Transaccion.CamaraId);
                if (visanet == null)
                {
                    Master.ShowMessageError(pago.Errores);
                }

                vDTO.Amount = visanet.Amount;
                vDTO.AuthCode = visanet.AuthCode;
                vDTO.Currency = visanet.Currency;
                vDTO.MerchantKey = visanet.MerchantKey;
                vDTO.OrderID = Convert.ToInt32(Session["OdenIDBHD"].ToString());
                vDTO.ReferenceCode = visanet.ReferenceCode;
                vDTO.Tarjeta = visanet.Tarjeta;

                ProcesarPagoTarjeta(vDTO, 0, "BHD");

            }
            else if (pago.EsRepuestaAzul)
            {
                var visanet = pago.RequestAzul(EnumSystemType.CamaraOnline, this.Transaccion.CamaraId);
                if (visanet == null)
                {
                    Master.ShowMessageError(pago.Errores);
                }
                else if (!string.IsNullOrEmpty(visanet.AuthCode))
                {
                    vDTO.Amount = visanet.Amount;
                    vDTO.AuthCode = visanet.AuthCode;
                    vDTO.Currency = visanet.Currency;
                    vDTO.MerchantKey = visanet.MerchantKey;
                    vDTO.OrderID = visanet.OrderID;
                    vDTO.ReferenceCode = visanet.ReferenceCode;
                    vDTO.Tarjeta = visanet.Tarjeta;

                    ProcesarPagoTarjeta(vDTO, 0);

                }

                //vDTO.Amount = 200;
                //vDTO.AuthCode = string.Empty;
                //vDTO.Currency = 0;
                //vDTO.MerchantKey = string.Empty;
                //vDTO.OrderID = 000025;
                //vDTO.ReferenceCode = "256699";
                //vDTO.Tarjeta = "Prueba";

                //ProcesarPagoTarjeta(vDTO, 0);

                // Response.Redirect($"~/TarjetaCredito/Factura.aspx?transId={Convert.ToInt32(Session["transId"])}");
                // return;
            }
            else
            {
                //Registro de actividades
                Master.NombreActividad = "Envío de pago con Tarjeta de Crédito";
                int tipoServicio = 0;
                int.TryParse(Request.QueryString["TipoServicioId"], out tipoServicio);
                //Objeto de la transaccion
                if (this.Transaccion == null)
                    this.Transaccion = new OFV.TransaccionesRepository().GetTransaccion(this.IdTransaciones, User.Identity.Name.ToLower());






                Session["transId"] = this.IdTransaciones;
                //Se inicia la pantalla
                InitInterface(Transaccion.CamaraId);
                pantallaIniciada = true;
                //if (tipoServicio.Equals(Helper.ServicioCopiasCertificadasId)) 
                //{
                //    LoadDataCopiasCertificadas();
                //    return;
                //}
                if (this.IdTransaciones == 0 && this.FacturaSrmId == 0)
                    SolicitudInvalidad();

                if (TipoSociedadID == 7)
                {
                    var ofvDb = new OFV.CamaraWebsiteEntities();
                    var transaccion = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == TransaccionId);

                    var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                    var rg = dbSRM.PersonasRegistros.FirstOrDefault(x => x.NumeroRegistro == transaccion.NumeroRegistro);

                    if (rg != null)
                    {
                        var proxy = new WSMondorRates.iRatesClient();
                        int.TryParse(rg.Registros.TipoMonedaCapitalAutorizado.ToString(), out int tipoModena);
                        if (tipoModena != 1 && tipoModena != 0)
                        {
                            double aCalcular;
                            double.TryParse(rg.Registros.CapitalAutorizado != null ? rg.Registros.CapitalAutorizado.ToString() : "0.00", out aCalcular);

                            double aCalcularModificado;
                            double.TryParse(transaccion.ModificacionCapital != null ? transaccion.ModificacionCapital.ToString() : "0.00", out aCalcularModificado);


                            var dbComunCal = new CamaraComunEntities();
                            var tipoMoneda = dbComunCal.TipoMoneda.FirstOrDefault(x => x.TipoMonedaId == rg.Registros.TipoMonedaCapitalAutorizado).AbreviaturaAPI;
                            string abreviatura = tipoMoneda == null ? tipoMoneda : "DOP";

                            decimal resultCapAutorizado;
                            decimal.TryParse(proxy.Convert(abreviatura, "DOP", aCalcular, Helper.PasswordMondorRates).ToString(), out resultCapAutorizado);

                            decimal resultCapModificado;
                            decimal.TryParse(proxy.Convert(abreviatura, "DOP", aCalcularModificado, Helper.PasswordMondorRates).ToString(), out resultCapModificado);

                            transaccion.CapitalSocial = resultCapAutorizado != 0 ? resultCapAutorizado : transaccion.CapitalSocial;
                            transaccion.ModificacionCapital = resultCapAutorizado != 0 ? resultCapAutorizado : transaccion.CapitalSocial;



                            if (transaccion.SubTransacciones != null)
                            {
                                foreach (var item in transaccion.SubTransacciones)
                                {
                                    item.CapitalSocial = resultCapAutorizado != 0 ? resultCapAutorizado : item.CapitalSocial;
                                    item.ModificacionCapital = resultCapAutorizado != 0 ? resultCapAutorizado : item.CapitalSocial;
                                }
                                ofvDb.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    var ofvDb = new OFV.CamaraWebsiteEntities();
                    var transaccion = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == TransaccionId);

                    var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                    var rg = dbSRM.SociedadesRegistros.FirstOrDefault(x => x.NumeroRegistro == transaccion.NumeroRegistro);

                    if (rg != null)
                    {
                        var proxy = new WSMondorRates.iRatesClient();
                        int.TryParse(rg.Registros.TipoMonedaCapitalAutorizado.ToString(), out int tipoModena);
                        if (tipoModena != 1 && tipoModena != 0)
                        {

                            double aCalcular;
                            double.TryParse(rg.Registros.CapitalAutorizado != null ? rg.Registros.CapitalAutorizado.ToString() : "0.00", out aCalcular);

                            //double aCalcularModificado;
                            //double.TryParse(transaccion.ModificacionCapital != null ? transaccion.ModificacionCapital.ToString() : "0.00", out aCalcularModificado);

                            var dbComunCal = new CamaraComunEntities();
                            var tipoMoneda = dbComunCal.TipoMoneda.FirstOrDefault(x => x.TipoMonedaId == rg.Registros.TipoMonedaCapitalAutorizado).AbreviaturaAPI;
                            string abreviatura = tipoMoneda != null ? tipoMoneda : "DOP";

                            decimal resultCapAutorizado;
                            decimal.TryParse(proxy.Convert(abreviatura, "DOP", aCalcular, Helper.PasswordMondorRates).ToString(), out resultCapAutorizado);

                            //decimal resultCapModificado;
                            //decimal.TryParse(proxy.Convert(abreviatura, "DOP", aCalcularModificado, Helper.PasswordMondorRates).ToString(), out resultCapModificado);

                            transaccion.CapitalSocial = resultCapAutorizado != 0 ? resultCapAutorizado : transaccion.CapitalSocial;
                            transaccion.ModificacionCapital = resultCapAutorizado != 0 ? resultCapAutorizado : transaccion.CapitalSocial;

                            if (transaccion.SubTransacciones != null)
                            {
                                foreach (var item in transaccion.SubTransacciones)
                                {
                                    item.CapitalSocial = resultCapAutorizado != 0 ? resultCapAutorizado : item.CapitalSocial;
                                    item.ModificacionCapital = resultCapAutorizado != 0 ? resultCapAutorizado : item.CapitalSocial;
                                }
                                ofvDb.SaveChanges();
                            }
                        }
                    }
                }



                if (this.IdTransaciones > 0)
                    LoadData(this.IdTransaciones, Transaccion.CamaraId);
                if (this.FacturaSrmId > 0)
                    LoadDataFacturaSrm(this.FacturaSrmId);
                if (EsConstitucion)
                    hfServicio.Value = "1";

                //Validacion para certificaciones simples
                //Comente : Se puede pagar las siple en la camara
                bool esDigital = true;

                // Boolean.TryParse(Request.QueryString["EntregaDigital"], out esDigital);

                if (esDigital)
                {
                    //pnlExpress.Visible = false;
                    // this.rbFormaPago.Items[1].Enabled = false;
                    this.rbFormaPago.Items[0].Selected = true;
                }
                else
                {
                    this.rbFormaPago.Items[0].Selected = true;
                    // this.rbFormaPago.Items[1].Selected = true;
                }

                //Se revisa si la camara actual tiene permisos para procesar transacciones de tarjeta
                var dbComun = new CamaraComunEntities();
                var camara = dbComun.Camaras.FirstOrDefault(c => c.ID == this.CamaraId);
                if (camara != null && esDigital)
                {
                    var puedeVender = camara.PuedeVenderOnline.HasValue
                                                        ? camara.PuedeVenderOnline.Value
                                                        : false;
                    this.rbFormaPago.Items[0].Enabled = puedeVender;
                    this.rbFormaPago.Items[0].Selected = puedeVender;
                    //this.rbFormaPago.Items[1].Selected = !puedeVender;
                }

                if (User.IsInRole("Testers"))
                {
                    this.rbFormaPago.Items[0].Enabled = true;
                    this.rbFormaPago.Items[0].Selected = true;
                    //this.rbFormaPago.Items[1].Selected = false;
                }
            }

            if (!pantallaIniciada)
            {
                if (this.Transaccion == null)
                    this.Transaccion = new OFV.TransaccionesRepository().GetTransaccion(this.Transaccion.TransaccionId, User.Identity.Name.ToLower());

                InitInterface(Transaccion.CamaraId);
                LoadData(this.Transaccion.TransaccionId, Transaccion.CamaraId);
            }

            //TODO: Force para que tarjeta de crédito no funcione en site en producción.
            //  var habilitarPago = Helper.HabilarPagoTarjeta(this.Transaccion.ServicioId) && (CamaraId.Equals("SDQ") || CamaraId.Equals("GOT"));

            //if (habilitarPago)
            {
                this.rbFormaPago.Items[0].Enabled = true;
                this.rbFormaPago.Items[0].Selected = true;
                //this.rbFormaPago.Items[1].Selected = false;
                //this.rbFormaPago.Items[1].Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            }
            //else
            //{
            //    this.rbFormaPago.Items[0].Enabled = false;
            //    this.rbFormaPago.Items[0].Selected = false;
            //    //this.rbFormaPago.Items[1].Selected = true;

            //}
            CamaraWebsiteEntities dbWeb = new CamaraWebsiteEntities();
            var t = dbWeb.Transacciones.FirstOrDefault(tt => tt.TransaccionId == TransaccionId);
            lblReembolso.Text = string.Format("{0:n}", 0M);
            lblCredito.Text = string.Format("{0:n}", (NotaCredito?.Valor ?? 0));
            if (trSDQ)
            {
                if (NotaCredito.NumeroNota != 0)
                {
                    decimal exedente = 0M;
                    exedente = NotaCredito.Valor - CostoTransaccion;
                    if (exedente > 0m)
                    {
                        lblReembolso.Text = string.Format("{0:n}", Math.Round(exedente, 2)).ToString();
                        PanelReembolsoExedente.Visible = true;
                    }
                }
            }
            lblTotal.Text = string.Format("{0:n}", CostoTransaccion - Credito);
            if ((CostoTransaccion - Credito) < 0)
            {
                lblTotal.Text = string.Format("{0:n}", 0);
            }
            if (trSDQ)
            {
                Panel.Visible = true;
            }
            Int32 nSolicitud = Transaccion.TransaccionId;
            // if (!Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud)) throw new Exception("No tiene numero de solicitud");
            //Aqui grabo el log de la transaccion que se creo
            if (!pago.EsRepuestaAzul && !pago.EsRepuestaCardnet && !pago.EsRepuestaVisanet)
                LogTransaccionesMethods.GrabarLogTransacciones(nSolicitud, Request.RawUrl, false, User.Identity.Name.ToLower());
        }
#if !DEBUG
        private void CargaNotaCredito(int? SrmTransaccionId)
        {
            var nota = facturacion.GetNotaCreditoMonto(Convert.ToInt32(SrmTransaccionId ?? 0), CamaraId);
            if (nota != null) NotaCredito = new FormaPagoDearrollo
            {
                Id = nota.Id,
                Valor = nota.Valor,
                NumeroNota = nota.NumeroNotaCredito ?? 0,
                Voucher = nota.Voucher

            };
            Credito = NotaCredito?.Valor ?? 0;

        }

#endif

        private bool IsValidRequestParameters()
        {
            if (string.IsNullOrWhiteSpace(CamaraId))
            {
                txtMessageTitle.InnerText = "Debe especificar la Cámara";
                MvFacturaTrans.SetActiveView(failView);
                mvFull.Visible = false;
                return false;
            }

            return true;
        }

        private bool HabilarPagoTarjeta(int servicioId)
        {
            var servicios = ConfigurationManager.AppSettings["ServiciosPagoOnline"].Split(',');
            foreach (var servicio in servicios)
            {
                var serId = 0;
                int.TryParse(servicio, out serId);

                if (serId.Equals(servicioId))
                    return true;
            }
            return false;
        }

        private void LoadDataCopiasCertificadas()
        {
            //Load Transaccion
            var dbWebSite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            //Nombre de la empresa
            var nombreSocial = String.Empty;
            if (!string.IsNullOrEmpty(Request.QueryString["SociedadId"]))
            {
                int sociedadId = int.Parse(Request.QueryString["SociedadId"]);

                var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var soc = dbSRM.SociedadesRegistros.Where(s => s.SociedadId == sociedadId).FirstOrDefault();
                if (soc != null)
                    nombreSocial = soc.Sociedades.NombreSocial;


                this.txtDenominacion.Text = nombreSocial;
                //this.litNombreEmpresa.Text = nombreSocial;
                this.litNombreEmpresaM.Text = nombreSocial;

                txtFecha.Text = DateTime.Now.ToStringDom();
                txtNoRegistro.Text = soc.NumeroRegistro.ToString();
                pnlNumeroRegistro.Visible = true;

            }
            LoadDetalleFacturaCopiasCertificadas();
            LoadServiciosCopiasCertificadas();
        }

        private void LoadDetalleFacturaCopiasCertificadas()
        {
            var detalle = new List<DetalleServicio>();

            detalle.Add(new DetalleServicio
            {
                Descripcion = "Copia Certificada",
                Costo = GetCostoCopiasCert()
            });

            detalle.Add(new DetalleServicio
            {
                Descripcion = "COBROS DE HOJAS (COPIAS CERTIFICADAS)",
                Costo = GetCostoCantPaginasCopiasCert(),
            });

            rpDetalleServicio.DataSource = detalle;
            rpDetalleServicio.DataBind();

            decimal total = 0;

            foreach (var item in detalle)
                total += item.Costo;

            var lbl = (Label)this.rpDetalleServicio.FindControlInFooter("txtCostoTotalTransaccion");
            total = decimal.Round(total, 2);
            lbl.Text = total.ToString();
            lblTotalTransaccion.Text = total.ToString();
        }

        private decimal GetCostoCantPaginasCopiasCert()
        {
            var dbComun = new CamaraComunEntities();

            var ser = (from servicio in dbComun.Servicio
                       where servicio.ServicioId.Equals(689)
                       select servicio).FirstOrDefault();

            decimal totalCopias = 0;

            foreach (var item in this.CopiasCertificadas)
            {
                decimal total = (item.CantPaginas * ser.CostoServicio);
                totalCopias += total;
            }
            return totalCopias;
        }

        private decimal GetCostoCopiasCert()
        {
            var dbComun = new CamaraComunEntities();

            var ser = (from servicio in dbComun.Servicio
                       where servicio.ServicioId.Equals(415)
                       select servicio).FirstOrDefault();

            return ser.CostoServicio;
        }

        private void LoadServiciosCopiasCertificadas()
        {
            //COPIA CERTIFICADA: 415,  COBROS DE HOJAS (COPIAS CERTIFICADAS): 686
            List<int> servicioIds = new List<int>() { 415, 689 };
            //Listado de servicios
            var dbComun = new CamaraComunEntities();
            var servicios = dbComun.Servicio.Where(s => servicioIds.Contains(s.ServicioId) && s.SiteVisible);
            this.rpServiciosSeleccionados.DataSource = servicios;
            this.rpServiciosSeleccionados.DataBind();
        }

        private void SolicitudInvalidad()
        {
            Session["ErrorMessage"] = "Solicitud no Existe. Por favor verificar y trate de nuevo.";
            Response.Redirect("~/Empresas/Oficina.aspx");
        }

        private void InitInterface(string camaraId)
        {
            var dbComun = new CamaraComunEntities();
            //Tipo de Empresa            
            var tipoEmpresa = String.Empty;
            var tipoSociedadField = this.TipoSociedadID > 0 ? this.TipoSociedadID : this.Transaccion.TipoSociedadId;
            if (tipoSociedadField > 0)
            {
                var obj = dbComun.TipoSociedad.Where(c => c.TipoSociedadId == tipoSociedadField).First();
                if (obj != null)
                    tipoEmpresa = obj.Etiqueta;
            }
            if (tipoEmpresa.Equals(SiglaExtranjera))
                this.txtTipoSociedad.Text = "Extranjera";
            else
                this.txtTipoSociedad.Text = tipoEmpresa;

            //this.litTipoEmpresaTit.Text = tipoEmpresa;

            //Tipos de comprobantes fiscales
            var ncfs = dbComun.TiposNcf.Where(t => t.SiteVisible);
            ddlTipoComprobantes.BindCollection(ncfs, TiposNcf.PropColumns.TipoNcfId, TiposNcf.PropColumns.Descripcion);
            ddlTipoComprobantes.SelectedIndex = ddlTipoComprobantes.Items.Count > 0 ? 1 : 0;

            //Si es certificación no se despliega la opción de transacción express
            var servicio = dbComun.Servicio.Where(s => s.ServicioId == this.Transaccion.ServicioId).FirstOrDefault();

            if (servicio != null && !Helper.ServicioVip(servicio.ServicioId))
                this.pnlExpress.Visible = false;

            //Información sobre la cámara
            var camara = dbComun.Camaras.FirstOrDefault(a => a.ID == camaraId);
            ltrNombreCamara.Text = camara.Nombre;
            ltrDireccionCamara.Text = camara.Direccion;

            //Si es una empresa nueva se deshabilita la opción de NCFs para el usuario actual
            var nuevaEmpStr = HttpHelpers.GetParameter("nuevaEmp", this.Context);
            bool nuevaEmpresa; Boolean.TryParse(nuevaEmpStr, out nuevaEmpresa);
            if (nuevaEmpresa)
                this.hfFormaEntrega.Value = this.FormaEntrega;

            //Si no es una constitución, se deshabilita la opción de cobros de los primeros documentos
            if (!EsConstitucion)
                this.litCostoServicio.Text = "";

            if (this.FormaEntrega == "F")
                mvFull.SetActiveView(vPagoFisico);
            //<parameto> NotaCredito //

            if (this.TransaccionId != 0)
            {
                var dbOFV = new OFV.CamaraWebsiteEntities();
                var tr = dbOFV.Transacciones.Where(x => x.TransaccionId == this.TransaccionId).FirstOrDefault();

                if (tr.ServicioId == 686 || tr.ServicioId == 741)
                {
                    //tr.TipoComprobanteId = 2;
                    //dbOFV.SaveChanges();
                    //ProcesarTransaccionSinPago(tr.TransaccionId);
                    mvFull.SetActiveView(vTransaccionSinCosto);
                }
            }


        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnContinuarBHD_Click(object, EventArgs)'
        protected void btnContinuarBHD_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnContinuarBHD_Click(object, EventArgs)'
        {
#if !DEBUG
            var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            var tranSDQ = context.Transacciones.FirstOrDefault(c => c.TransaccionIdAnterior == TransaccionId && c.DesdeOfv);
            if (tranSDQ != null)
            {


                CargaNotaCredito(tranSDQ.TransaccionId);


            }
#endif
            if (chkCondicionBanco.Checked != true)
            {
                Master.ShowMessageError("Debe aceptar las condiciones");
                return;
            }

            if (rblreembolsoExedente.SelectedValue.Equals("1")) this.ReembolsoExedente = rblreembolsoExedente.SelectedValue.Equals("1") ? true : false;
            if (rblreembolsoExedente.SelectedValue.Equals("") && rblreembolsoExedente.Visible == true)
            {
                Master.ShowMessageError("Debe seleccionar si desea reclamar o no el exedente del credito de la nota");
                return;
            }
            int tipoComp = Convert.ToInt32(this.ddlTipoComprobantes.SelectedItem.Value);

            if (tipoComp != 2)
            {



                var wsDGI = new WSMovilDGII.WSMovilDGIISoapClient();
                wsDGI.Open();
                var result = wsDGI.GetContribuyentes(this.RNC, 0, 0, 0, "");
                if (result == "0")
                {
                    Master.ShowMessageError("El contribuyente indicado es inválido.");
                    this.txtRnc.BorderColor = System.Drawing.Color.Red;
                    wsDGI.Close();
                    return;
                }
                wsDGI.Close();
            }
            //Info de la transacción
            var db = new OFV.CamaraWebsiteEntities();
            var transId = IdTransaciones == 0 ? Convert.ToInt32(Session["transId"]) : IdTransaciones;
            var transaction = db.Transacciones.FirstOrDefault(t => t.TransaccionId == transId && t.UserName == User.Identity.Name.ToLower());
            //var registro = db.Registros.FirstOrDefault(r => r.RegistroId == transaction.RegistroId);
            bool save = false;


            if (Session["CostoTransaccion"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            var totalPago = CostoTransaccion - Credito;
            this.NombreSolicitante.NombreCompleto = this.txtNombre.Text.ToUpper();


            //Se guarda el nombre del solicitnate en la transacción
            if (NombreSolicitante.NombreCompleto.Length > 0 && RNC.Length > 0)
            {
                transaction.Solicitante = this.NombreSolicitante.NombreCompleto;
                transaction.RNCSolicitante = this.RNC;
                transaction.TipoComprobanteId = Convert.ToInt32(this.ddlTipoComprobantes.SelectedItem.Value);
                save = true;
            }
            if (chkExpress.Checked)
            {
                totalPago *= 2;
                transaction.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;
                save = true;
            }

            if (save) db.SaveChanges();

            //var returnUrl = ConfigurationManager.AppSettings["TransaccionalUrl"] + DefaultQueryString;

            string url = string.Concat(LogTransaccionesMethods.ObtenerUltimaURL(transId));
            string urlRes = !string.IsNullOrWhiteSpace(url) ? url.Remove(0, 33) : "";
            var urlReturnPagoTransaccion = ConfigurationManager.AppSettings["TransaccionalUrlPaginaTransaccion"] + urlRes;

            if (totalPago > 0)
            {
                pagadoTarjeta = totalPago;
                pagadoNota = Credito;
                transaction.PagadoConNota = Credito;
                if (save) db.SaveChanges();



                string URL = ConfigurationManager.AppSettings["UrlAutenticacion"].ToString();
                string DATA = @"{
                ""transactionId"": ""TransaccionVariable"",
                ""amount"": Montovariable,
                ""clientId"": ""clientIdString"",
                ""clientSecret"": ""clientSecretString"",
                ""billingNumber"": ""billingNumberVariable"",
                ""currency"": ""RD"",
                ""creditHold"": ""Y"",
                 ""scope"": ""login"",
                 ""description"": ""Descripcion"",
                 ""returnedURL"": ""URLTRansacconpagina"",
                 ""cancelledURL"": ""URLTRansacconpagina""}";
                //transId
                DATA = DATA.Replace("Montovariable", totalPago.ToString());
                DATA = DATA.Replace("URLTRansacconpagina", ConfigurationManager.AppSettings["TransaccionalUrlPaginaTransaccion"].ToString());
                DATA = DATA.Replace("TransaccionVariable", transId.ToString());
                DATA = DATA.Replace("billingNumberVariable", transId.ToString());
                DATA = DATA.Replace("clientIdString", ConfigurationManager.AppSettings["clientId"].ToString());
                DATA = DATA.Replace("clientSecretString", ConfigurationManager.AppSettings["clientSecret"].ToString());



                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                // request.Headers.Add("User-Agent: Other");
                // var test = request.GetResponseAsync();


                //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;                
                //request.ProtocolVersion = HttpVersion.Version11;
                //request.KeepAlive = false;
                //request.ServicePoint.ConnectionLimit = 1;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                       SecurityProtocolType.Tls11 |
                                       SecurityProtocolType.Tls12;

                request.ProtocolVersion = HttpVersion.Version11;

                

                using (Stream webStream = request.GetRequestStream())
                { 
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(DATA);
                }

               // webStream.Close();
            }

                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {

                    string response = responseReader.ReadToEnd();
                    string[] words = response.Split('\"');
                    var jwt = words[3];

                    Session["VariablesParaBHD"] = HttpContext.Current.Request.Url.PathAndQuery;
                    var UrlBhd = ConfigurationManager.AppSettings["UrlBHD"].ToString() + jwt;
                    var orderId = PagoVisanetService.GrabarOrder(transId, EnumSystemType.CamaraOnline);
                    Session["OdenIDBHD"] = orderId;
                    Response.Redirect(UrlBhd);

                }


                //pago.RealizarPago(transId, totalPago, NombreSolicitante.NombreCompleto, string.IsNullOrEmpty(RNC) ? string.Empty : RNC, urlReturnPagoTransaccion, EnumSystemType.CamaraOnline, transaction.CamaraId);
            }
            else
            {
                pagadoNota = CostoTransaccion;
                transaction.PagadoConNota = CostoTransaccion;
                if (save) db.SaveChanges();
                ProcesarTransaccionSinPago(transId);
            }
            //var url = String.Format("{0}?{1}", Helper.TransGatewayUrl, sb);
            //Response.Redirect(url);

        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnContinuar_Click(object, EventArgs)'
        {
#if !DEBUG
            var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            var tranSDQ = context.Transacciones.FirstOrDefault(c => c.TransaccionIdAnterior == TransaccionId && c.DesdeOfv);
            if (tranSDQ != null)
            {
                if (tranSDQ.Estatus == 15)
                {
                    CargaNotaCredito(tranSDQ.TransaccionId);
                }
            }
#endif
            if (chkCondicionBanco.Checked != true)
            {
                Master.ShowMessageError("Debe aceptar las condiciones");
                return;
            }

            if (rblreembolsoExedente.SelectedValue.Equals("1")) this.ReembolsoExedente = rblreembolsoExedente.SelectedValue.Equals("1") ? true : false;
            if (rblreembolsoExedente.SelectedValue.Equals("") && rblreembolsoExedente.Visible == true)
            {
                Master.ShowMessageError("Debe seleccionar si desea reclamar o no el exedente del credito de la nota");
                return;
            }
            int tipoComp = Convert.ToInt32(this.ddlTipoComprobantes.SelectedItem.Value);

            if (tipoComp != 2)
            {

                //#region ProtocoloSeguridadDGII
                //if (ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12) == false)
                //    ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
                //#endregion

                var wsDGI = new WSMovilDGII.WSMovilDGIISoapClient();
                wsDGI.Open();
                var result = wsDGI.GetContribuyentes(this.RNC, 0, 0, 0, "");
                if (result == "0")
                {
                    Master.ShowMessageError("El contribuyente indicado es inválido.");
                    this.txtRnc.BorderColor = System.Drawing.Color.Red;
                    wsDGI.Close();
                    return;
                }
                wsDGI.Close();
            }
            //Info de la transacción
            var db = new OFV.CamaraWebsiteEntities();
            var transId = IdTransaciones == 0 ? Convert.ToInt32(Session["transId"]) : IdTransaciones;
            var transaction = db.Transacciones.FirstOrDefault(t => t.TransaccionId == transId && t.UserName == User.Identity.Name.ToLower());
            //var registro = db.Registros.FirstOrDefault(r => r.RegistroId == transaction.RegistroId);
            bool save = false;


            if (Session["CostoTransaccion"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            var totalPago = CostoTransaccion - Credito;
            this.NombreSolicitante.NombreCompleto = this.txtNombre.Text.ToUpper();


            //Se guarda el nombre del solicitnate en la transacción
            if (NombreSolicitante.NombreCompleto.Length > 0 && RNC.Length > 0)
            {
                transaction.Solicitante = this.NombreSolicitante.NombreCompleto;
                transaction.RNCSolicitante = this.RNC;
                transaction.TipoComprobanteId = Convert.ToInt32(this.ddlTipoComprobantes.SelectedItem.Value);
                save = true;
            }
            if (chkExpress.Checked)
            {
                totalPago *= 2;
                transaction.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;
                save = true;
            }

            if (save) db.SaveChanges();

            //var returnUrl = ConfigurationManager.AppSettings["TransaccionalUrl"] + DefaultQueryString;

            string url = string.Concat(LogTransaccionesMethods.ObtenerUltimaURL(transId));
            string urlRes = !string.IsNullOrWhiteSpace(url) ? url.Remove(0, 33) : "";
            var urlReturnPagoTransaccion = ConfigurationManager.AppSettings["TransaccionalUrlPaginaTransaccion"] + urlRes;

            if (totalPago > 0)
            {
                pagadoTarjeta = totalPago;
                pagadoNota = Credito;
                transaction.PagadoConNota = Credito;
                if (save) db.SaveChanges();
                pago.RealizarPago(transId, totalPago, NombreSolicitante.NombreCompleto, string.IsNullOrEmpty(RNC) ? string.Empty : RNC, urlReturnPagoTransaccion, EnumSystemType.CamaraOnline, transaction.CamaraId);
            }
            else
            {
                pagadoNota = CostoTransaccion;
                transaction.PagadoConNota = CostoTransaccion;
                if (save) db.SaveChanges();
                ProcesarTransaccionSinPago(transId);
            }
            //var url = String.Format("{0}?{1}", Helper.TransGatewayUrl, sb);
            //Response.Redirect(url);

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnContinuarSinCosto_Click(object, EventArgs)'
        protected void btnContinuarSinCosto_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnContinuarSinCosto_Click(object, EventArgs)'
        {
            if (this.TransaccionId != 0)
            {
                var db = new OFV.CamaraWebsiteEntities();
                var transaction = db.Transacciones.FirstOrDefault(t => t.TransaccionId == this.TransaccionId && t.UserName == User.Identity.Name.ToLower());
                transaction.bPagada = true;
                transaction.TipoComprobanteId = 2;
                db.SaveChanges();
                ProcesarTransaccionSinPago(transaction.TransaccionId);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnFormaPago_Click(object, EventArgs)'
        protected void btnFormaPago_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnFormaPago_Click(object, EventArgs)'
        {
            switch (rbFormaPago.SelectedValue)
            {
                case "1":
                    this.mvFull.SetActiveView(vGeneracionTicket);
                    break;
                case "2":
                    Int32 nSolicitud;
                    Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);

                    //int tiposervicioid = 0;
                    //int.TryParse(Request.QueryString["TipoServicioId"],out tiposervicioid);

                    //if (tiposervicioid.Equals(Helper.ServicioCopiasCertificadasId)) 
                    //{
                    //  nSolicitud =  SaveTransaccionCopiaCertificada();
                    //  if (nSolicitud > 0 && this.CopiasCertificadas.Count > 0) 
                    //  {
                    //    int res = SaveCopiasCertificadas(nSolicitud);
                    //    if (res <= 0) 
                    //    {
                    //        ErrorMessage = "Ha ocurrido un error al intentar procesar su transacción. Contacte al personal de soporte.";
                    //        return;
                    //    }
                    //    DefaultQueryString = string.Format("nSolicitud={0}", nSolicitud);
                    //  }
                    //}
                    ErrorMessage =
                        @"Su transacción ha sido guardada. Debe depositar los documentos 
                          en la camara seleccionada para completar su solicitud.";
                    //Aqui grabo el log de la transaccion que se creo
                    LogTransaccionesMethods.GrabarLogTransacciones(nSolicitud, "/Empresas/VerDetalleTransaccion.aspx" + DefaultQueryString, true, User.Identity.Name.ToLower());
                    Response.Redirect("/Empresas/VerDetalleTransaccion.aspx" + DefaultQueryString);
                    break;
            }
        }

        private int SaveCopiasCertificadas(int nSolicitud)
        {
            var dbWeb = new OFV.CamaraWebsiteEntities();

            foreach (var copia in this.CopiasCertificadas)
            {
                copia.TransaccionId = nSolicitud;
                dbWeb.TransaccionCopiasCertificadas.AddObject(copia);
            }

            return dbWeb.SaveChanges();
        }

        private int SaveTransaccionCopiaCertificada()
        {
            var transRep = new OFV.TransaccionesRepository();
            OFV.Transacciones trans = new Transacciones();
            OFV.Transacciones subTrans = new Transacciones();
            int transId = 0;
            int registroid = int.Parse(Request.QueryString["RegistroId"]);
            int tipoSociedadId = int.Parse(Request.QueryString["TipoSociedadId"]);
            int NoRegistro = 0;
            int.TryParse(txtNoRegistro.Text, out NoRegistro);
            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);

            var profile = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);

            trans.Fecha = DateTime.Now;
            trans.EstatusTransId = 21;
            trans.RegistroId = registroid;
            //servicioid copia certificada
            trans.ServicioId = 415;
            trans.CamaraId = this.CamaraId;
            trans.UserName = this.User.Identity.Name.ToLower();
            trans.TipoSociedadId = tipoSociedadId;
            trans.Solicitante = profile.NombreSolicitante;
            trans.RNCSolicitante = profile.RNC;
            trans.NombreContacto = profile.NombreSolicitante;
            trans.TelefonoContacto = profile.Telefono;
            trans.NombreSocialPersona = this.txtDenominacion.Text;
            trans.NumeroRegistro = NoRegistro;
            trans.Tipo = 2;
            if (tipoSociedadId != 7)
            {
                var soc = dbSRM.SociedadesRegistros.Where(s => s.NumeroRegistro == NoRegistro).FirstOrDefault();
                trans.FechaAsamblea = soc.Sociedades.FechaAsamblea;
                trans.CapitalSocial = soc.Registros.CapitalSocial;
            }
            else
            {
                var per = dbSRM.PersonasRegistros.Where(s => s.NumeroRegistro == NoRegistro).FirstOrDefault();
                trans.FechaAsamblea = per.Registros.FechaAsamblea1;
                trans.CapitalSocial = per.Registros.CapitalSocial;
            }


            transRep.Add(trans);

            transRep.Save();
            transId = trans.TransaccionId;

            transRep = new OFV.TransaccionesRepository();

            #region Subtransaccion
            subTrans.SubTransaccionId = trans.TransaccionId;
            subTrans.Fecha = DateTime.Now;
            subTrans.EstatusTransId = 21;
            subTrans.RegistroId = registroid;
            subTrans.ServicioId = 689;
            subTrans.CamaraId = this.CamaraId;
            subTrans.UserName = this.User.Identity.Name.ToLower();
            subTrans.TipoSociedadId = tipoSociedadId;
            subTrans.Solicitante = profile.NombreSolicitante;
            subTrans.RNCSolicitante = profile.RNC;
            subTrans.NombreContacto = profile.NombreSolicitante;
            subTrans.TelefonoContacto = profile.Telefono;
            subTrans.NombreSocialPersona = this.txtDenominacion.Text;
            subTrans.NumeroRegistro = NoRegistro;
            subTrans.Tipo = 2;
            if (tipoSociedadId != 7)
            {
                var soc = dbSRM.SociedadesRegistros.Where(s => s.NumeroRegistro == NoRegistro).FirstOrDefault();
                trans.FechaAsamblea = soc.Sociedades.FechaAsamblea;
                trans.CapitalSocial = soc.Registros.CapitalSocial;
            }
            else
            {
                var per = dbSRM.PersonasRegistros.Where(s => s.NumeroRegistro == NoRegistro).FirstOrDefault();
                trans.FechaAsamblea = per.Registros.FechaAsamblea1;
                trans.CapitalSocial = per.Registros.CapitalSocial;
            }
            #endregion

            transRep.Add(subTrans);
            transRep.Save();
            //Grabo el log de la transaccion.
            LogTransaccionesMethods.GrabarLogTransacciones(transId, "Solicitud Copias Certificadas", true, User.Identity.Name.ToLower());

            return transId;

        }

        #endregion

        #region Validaciones
        private void LoadData(int transaccionId, string camaraId)
        {
            //var proxy = new WSMondorRates.iRatesClient();
            //proxy.Convert("","",0.00,"");

            //Load Transaccion
            var dbWebSite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            var trans = dbWebSite.Transacciones.FirstOrDefault(
                        t => t.TransaccionId == transaccionId && t.UserName == User.Identity.Name.ToLower());




            //  trans.CapitalSocial = 

            if (trans == null)
            {
                ErrorMessage = "Numero de solicitud invalido o no existe.";
                Response.Redirect("~/Empresas/Oficina.aspx");
            }

            var helper = new TransaccionDevueltaHelper(Request);
            var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == Transaccion.TransaccionId && x.DesdeOfv)?.VieneProblemas == true ? true : false;
            if (trans.bPagada && !trSDQ)
                Response.Redirect(String.Format("~/Empresas/CierreSolicitud.aspx?nSolicitud={0}", IdTransaciones));

            if (Transaccion == null)
                Transaccion = trans;

            //Nombre de la empresa
            var nombreSocial = String.Empty;
            if (trans.ServicioId == 741)
            {
                nombreSocial = trans.NombreSocialPersona;
            }
            else
            {
                if (trans.TipoSociedadId != 7)
                {
                    if (trans.NumeroRegistro.HasValue)
                    {
                        var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
                        var soc = dbSRM.SociedadesRegistros.Where(s => s.NumeroRegistro == trans.NumeroRegistro).FirstOrDefault();
                        if (soc != null)
                            nombreSocial = soc.Sociedades.NombreSocial;
                    }
                    else
                    {
                        var registro = dbWebSite.Sociedades
                            .Where(s => s.RegistroId == trans.RegistroId)
                            .FirstOrDefault();
                        nombreSocial = registro != null
                                           ? registro.NombreSocial
                                           : trans.NombreSocialPersona;
                    }
                }
                else
                {
                    nombreSocial = trans.NombreSocialPersona;
                }
            }

            if (trans.NumeroRegistro == 0) { nombreSocial = trans.NombreSocialPersona; }

            this.txtDenominacion.Text = nombreSocial;
            //this.litNombreEmpresa.Text = nombreSocial;
            this.litNombreEmpresaM.Text = nombreSocial;

            txtFecha.Text = trans.Fecha.ToStringDom();
            txtNoRegistro.Text = trans.NumeroRegistro.HasValue ? trans.NumeroRegistro.ToString() : String.Empty;
            pnlNumeroRegistro.Visible = trans.NumeroRegistro.HasValue;

            this.CamaraId = trans.CamaraId;

            chkExpress.Checked = Convert.ToBoolean(trans.Prioridad);

            SetCostoServicio(trans);

            LoadDocumentos((trans.Prioridad == 1));
            LoadDetalleFactura(trans);
            LoadServicios(trans);
            LoadCostoExpress(false, true);


            var factura = ObtenerFactura(transaccionId);
        }


        private int ObtenerTranSRM(int transaccionid)
        {

            var dbWebSite = new OFV.CamaraWebsiteEntities();
            var trans = dbWebSite.Transacciones.FirstOrDefault(
                  t => t.TransaccionId == transaccionid && t.UserName == User.Identity.Name.ToLower());

            return Convert.ToInt32(trans.SrmTransaccionId);
        }



        private void LoadServicios(Transacciones trans)
        {
            var servicioIds = trans.GetServicioTransacciones();
            if (servicioIds.Count > 0 && servicioIds.FirstOrDefault() > 0)
            {
                //Listado de servicios
                var dbComun = new CamaraComunEntities();
                var servicios = dbComun.Servicio.Where(s => servicioIds.Contains(s.ServicioId) && s.SiteVisible);
                this.rpServiciosSeleccionados.DataSource = servicios;
                this.rpServiciosSeleccionados.DataBind();
            }
        }

        private void SetCostoServicio(OFV.Transacciones trans)
        {

            var repTransacciones = new OFV.TransaccionesRepository();

            var calculoCostoServicio = 0M;

            calculoCostoServicio = repTransacciones.GetCostoTransaccion(trans, Helper.PorcentajeVIP)
                        + repTransacciones.GetCostoTransaccionSub(trans, Helper.PorcentajeVIP, false, trans.Prioridad == 1);

            CostoServicio = calculoCostoServicio;
        }

        private void LoadCostoExpress(bool persistExpress, bool bExpress)
        {
            var repServicio = new ServicioRepository();
            var costoServicio = repServicio.GetTotalServicio(Transaccion.ServicioId, Transaccion.CamaraId,
                                                             Transaccion.CapitalSocial,
                                                             Transaccion.ModificacionCapital, bExpress,
                                                             Helper.PorcentajeVIP, Transaccion);

            var docs = persistExpress
                           ? this.DocumentosSeleccionados
                           : this.DocumentosSeleccionados.Select(Utils.Clone).ToList();

            docs.ForEach(delegate (ServicioDocumentoRequerido doc)
            {
                doc.bExpress = bExpress;
                doc.PorcentajeVIP = Helper.PorcentajeVIP;
            });


            var costoVIP = this.CostoTransaccion + this.CostoTransaccion * Helper.PorcentajeVIP / 100;
            litCostoServicio.Text = String.Format("{0:n}", costoVIP);

            if (!persistExpress) return;

            CostoServicio = costoServicio;
            LoadDocumentos(bExpress);
            LoadDetalleFactura(Transaccion);
        }

        private void LoadDetalleFactura(Transacciones tnx)
        {
            var detalle = new List<DetalleServicio>();
            var repTransaccion = new OFV.TransaccionesRepository();
            var dbComun = new CamaraComunEntities();

            var repServicio = new ServicioRepository();
            tnx.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

            var considerarMods = true;
            var servicio = dbComun.Servicio.First(s => s.ServicioId == tnx.ServicioId);

            detalle.Add(new DetalleServicio()
            {
                Descripcion = servicio.DescripcionWeb ?? servicio.Descripcion,
                Cantidad = servicio.SeCobraEnSubTransaccion ? 1 : CantidadCertificaciones,
                Costo = repTransaccion.GetCostoTransaccionCabecera(tnx, Helper.PorcentajeVIP)
            });

            //si el servicio es renovacion se le cobrara 50 pesos por un sello que DGII le vendio a la camara 













            if (!servicio.SeCobraEnSubTransaccion && servicio.TransaccionJerarquia > 0 ||
                Helper.ServiciosHeaderIds.Contains(servicio.ServicioId))
                considerarMods = false;

            if (servicio.SeCobraEnSubTransaccion && tnx.SubTransacciones.Count() > 0)
            {
                foreach (var subtnx in tnx.SubTransacciones)
                {
                    var detalleFact = new DetalleServicio
                    {
                        Descripcion = subtnx.NombreServicio,
                        Costo = repTransaccion.GetCostoTransaccionSub
                                                  (subtnx, Helper.PorcentajeVIP, considerarMods, tnx.Prioridad == 1)

                    };

                    if (detalleFact.Costo > 0)
                    {

                        //if (tnx.ServicioId == 398)
                        //{
                        //    detalleFact.Costo = detalleFact.Costo + 50;
                        //}

                        servicio = dbComun.Servicio.First(s => s.ServicioId == subtnx.ServicioId);
                        detalleFact.Descripcion = servicio.DescripcionWeb ?? servicio.Descripcion;

                        detalle.Add(detalleFact);
                    }

                    if (considerarMods)
                    {
                        var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                        var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                        var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                        if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                            considerarMods = false;
                    }
                }
            }


            if (tnx.ServicioId == 398 || tnx.ServicioId == 421)
            {
                //int contador = 0;
                //foreach (var item in detalle)
                //{
                //        contador = contador + 1;
                //}

                detalle.Add(new DetalleServicio()
                {
                    Descripcion = "Cargo de RD$50.00 correspondiente a la contribución del Colegio de Abogados de la República Dominicana",
                    //Cantidad = servicio.SeCobraEnSubTransaccion ? 1 : CantidadCertificaciones,
                    Costo = 50
                });

            }

            detalle.Add(new DetalleServicio
            {
                Descripcion = "Registro de Documentos",
                Costo = GetCostoDocumentos(this.DocumentosSeleccionados, (tnx.Prioridad == 1))
            });



            rpDetalleServicio.DataSource = detalle;
            rpDetalleServicio.DataBind();

            if (detalle.Count > 0)
            {
                ((Label)this.rpDetalleServicio.FindControlInFooter("txtCostoTotalTransaccion")).Text =
                    String.Format("{0:n}",
                                  detalle.Sum(d => d.Costo * d.Cantidad));

                lblTotalTransaccion.Text = String.Format("{0:n}", detalle.Sum(d => d.Costo * d.Cantidad));
            }

            this.CostoTransaccion = detalle.Sum(d => d.Costo * d.Cantidad);
        }


        private void LoadDocumentos(bool esVip)
        {
            //Codigo Agregado para que funcione en el nuevo escenario.
            if (this.DocumentosSeleccionados.Count <= 0) LoadDocumentoSeleccionados();
            rpDocumentos.DataSource = this.DocumentosSeleccionados;
            rpDocumentos.DataBind();

            var costoDocumentos = GetCostoDocumentos(this.DocumentosSeleccionados, esVip);

            var ctrlCosto = this.rpDocumentos.FindControlInFooter("txtCostoTotalTransaccion");
            if (ctrlCosto is Label)
            {
                ((Label)ctrlCosto).Text = String.Format("{0:n}", CostoServicio + costoDocumentos);
                lblTotalTransaccion.Text = String.Format("{0:n}", CostoServicio + costoDocumentos);
            }


            ((Label)this.rpDocumentos.FindControlInFooter("txtCostoTransaccion")).Text = String.Format("{0:n}",
                                                                                                        costoDocumentos);

            lblTotalTransaccion.Text = String.Format("{0:n}", costoDocumentos);
        }

        private void LoadDocumentoSeleccionados()
        {
            var transacciones = new OFV.TransaccionDocumentosController();
            var repServicioRequerido = new ServicioDocumentoRequeridoRepository();
            var repServicioDocSeleccionados = transacciones.GetDocumentosSeleccionados(Transaccion.TransaccionId);

            var documentos = repServicioRequerido.GetDocumentosSeleccionados(Transaccion.ServicioId,
                                                                             Transaccion.TipoSociedadId,
                                                                             Transaccion.TransaccionId);

            foreach (var docSeleccionado in repServicioDocSeleccionados)
            {
                var docAgregar = documentos.FirstOrDefault(doc => doc.TipoDocumentoId == docSeleccionado.TipoDocumentoId);
                if (docAgregar == null) continue;


                this.DocumentosSeleccionados.Add(
                    new ServicioDocumentoRequerido
                    {
                        CantidadCopia = docSeleccionado.CantidadCopia,
                        CantidadOriginal = docSeleccionado.CantidadOriginal,
                        CostoCopia = docAgregar.TipoDocumento.CostoCopia,
                        CostoOriginal = docAgregar.TipoDocumento.CostoOriginal,
                        TipoDocumentoId = docAgregar.TipoDocumentoId,
                        Nombre = docAgregar.TipoDocumento.Nombre,
                        TipoSociedadId = Transaccion.TipoSociedadId,
                        ServicioId = Transaccion.ServicioId,
                        Requerido = docAgregar.Requerido
                    });
            }
        }

        private decimal GetCostoDocumentos(IEnumerable<ServicioDocumentoRequerido> listServicios, bool EsVip)
        {
            return EsConstitucion
                       ? listServicios.GetTotal(Helper.CantidadCopiasGratisNuevaEmpresa,
                                                Helper.CantidadOriginalGratisNuevaEmpresa, EsVip)
                       : listServicios.GetTotal(EsVip);

        }


        // Loading Factura From Camara
        private void LoadDataFacturaSrm(int facturaSrmId)
        {
            //Activo vista de Factura Srm
            this.MvFacturaTrans.ActiveViewIndex = 1;

            //Loading Data Factura
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);

            var factura = dbSrm.Facturas.FirstOrDefault(a => a.FacturaId == facturaSrmId);
            var detalles = factura.TransaccionDetalle.ToList();

            rpServComplementarios.DataSource = detalles;
            rpServComplementarios.DataBind();

            var lbl = (Label)this.rpServComplementarios.FindControlInFooter("txtCostoTransaccion");
            lbl.Text = String.Format("{0:n}", this.CostoServicio = detalles.Sum(a => a.TotalBruto).Value2());
        }


        #endregion

        #region Facturacion
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.GenerarFacturas(Transacciones, string, IEnumerable<ServicioDTO>, Dictionary<int, decimal>, int?, bool, string)'
        public Facturas GenerarFacturas(OFV.Transacciones tnx, string nombreTipoSociedad, IEnumerable<DTO.ServicioDTO> servicios,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.GenerarFacturas(Transacciones, string, IEnumerable<ServicioDTO>, Dictionary<int, decimal>, int?, bool, string)'
            Dictionary<int, Decimal> costoServicios, int? tipoComprobanteId, bool seCobraEnSubTransaccion, string usuario = "")
        {

            var usuariofinal = "";
            if (usuario != "")
            {
                usuariofinal = usuario;
            }

            var repTransacciones = new OFV.TransaccionesRepository();
            var ultimaFactura = ObtenerFactura(tnx.TransaccionId);

            var servicio = servicios.FirstOrDefault(a => a.ServicioId == tnx.ServicioId);
            var nombreServicio = servicio.Descripcion;
            var cuentaServicio = servicio.Cuenta;
            //repTransacciones.GetCostoTransaccionCabecera(tnx, Helper.PorcentajeVIP);
            var costo = costoServicios[tnx.TransaccionId];
            decimal pagadoNota = Convert.ToDecimal(tnx.PagadoConNota > 0 ? tnx.PagadoConNota : 0M);


            //Estos servicios son en dolares y los convertiremos en pesos dominicanos
            if (tnx.ServicioId == 745 || tnx.ServicioId == 746 || tnx.ServicioId == 747 || tnx.ServicioId == 748)
            {

                //var proxy = new WSMondorRates.iRatesClient();
                decimal resultCapAutorizado = costo;
                //  decimal.TryParse(proxy.Convert("USD", "DOP", Convert.ToDouble(costo), Helper.PasswordMondorRates).ToString(), out resultCapAutorizado);
                costo = resultCapAutorizado;

                var docCopiass = this.DocumentosSeleccionados.Where(a => a.CostoOriginal > 0 && a.CantidadOriginal > 0).ToList();
                CantidadCertificaciones = Convert.ToInt32(tnx.CantidadCopiaCertificaciones);
            }



            var factura = new Facturas
            {
                Complementaria = false,
                Estado = 1,
                Fecha = DateTime.Now,
                TipoNcf = tipoComprobanteId > 0 ? tipoComprobanteId.ToString() : Helper.TipoComprobanteIdDefault,
                TransaccionId = tnx.TransaccionId,
                Usuario = usuariofinal.ToLower(),
                CamaraId = tnx.CamaraId,
                PagoAnterior = pagadoNota,
                CobroPorServicio = costo
            };


            var td = new TransaccionDetalle
            {
                //Cantidad = 1,
                Cantidad = seCobraEnSubTransaccion ? 1 : CantidadCertificaciones,
                Cuenta = cuentaServicio,
                Detalle = nombreServicio + " - " + nombreTipoSociedad,
                PrecioUnitario = costo,
                Descuento = 0,
            };

            factura.TransaccionDetalle.Add(td);

            if (seCobraEnSubTransaccion)
            {
                foreach (var subtnx in tnx.SubTransacciones)
                {
                    var subt = subtnx;
                    var service = servicios.FirstOrDefault(a => a.ServicioId == subt.ServicioId);

                    if (service != null && !service.bFactura)
                        continue;

                    costo = costoServicios[subtnx.TransaccionId]; //repTransacciones.GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP);
                    td = new TransaccionDetalle
                    {
                        Cantidad = 1,
                        Cuenta = service.Cuenta,
                        Detalle = service.Descripcion,
                        PrecioUnitario = costo,
                        Descuento = 0,
                    };

                    factura.TransaccionDetalle.Add(td);
                }
            }

            var cantidadExonera = (dynamic)null;

           //ep: -  2021-05-18: se comenta lo siguiente porque en estos servicios no se exoneran copias con el SEL actual
          /*  if (tnx.ServicioId != 745 && tnx.ServicioId != 746 && tnx.ServicioId != 747 && tnx.ServicioId != 748)
            {
                cantidadExonera = EsConstitucion ? Helper.CantidadOriginalGratisNuevaEmpresa : 0;
            }
            */

            //quitar esto cuando se pueda.
            cantidadExonera = 0;

            var docCopias = this.DocumentosSeleccionados.Where(a => a.CostoOriginal > 0 && a.CantidadOriginal > 0).ToList();

            if (docCopias.Count > 0)
            {
                td = new TransaccionDetalle
                {
                    // Preguntar si se requiere cobrar por la cantidad de documentos subidos o por el servicio adquirido.
                    //Cantidad = 1,
                    Cantidad = (int)docCopias.Sum(a => a.CantidadOriginal) - cantidadExonera,
                    Cuenta = cuentaServicio,
                    Detalle = "Registro Documentos Originales",
                    FacturaId = factura.FacturaId,
                    PrecioUnitario = docCopias.FirstOrDefault().CostoOriginalFinal,
                    Descuento = 0m
                };

                if (td.Cantidad <= 0)
                {
                    td.Cantidad = 0; td.PrecioUnitario = 0;
                }

                factura.TransaccionDetalle.Add(td);
            }

            //ep: -  2021-05-18: se comenta lo siguiente porque en estos servicios no se exoneran copias con el SEL actual
        /*    if (tnx.ServicioId != 745 && tnx.ServicioId != 746 && tnx.ServicioId != 747 && tnx.ServicioId != 748)
            {
                cantidadExonera = EsConstitucion ? Helper.CantidadCopiasGratisNuevaEmpresa : 0;
            }
            */

            //Documentos Copias
            docCopias = this.DocumentosSeleccionados.Where(a => a.CostoCopia > 0 && a.CantidadCopia > 0).ToList();

            if (docCopias.Count > 0)
            {
                td = new TransaccionDetalle
                {
                    // Preguntar si se requiere cobrar por la cantidad de documentos subidos o por el servicio adquirido.
                    //Cantidad = 1,
                    Cantidad = (int)docCopias.Sum(a => a.CantidadOriginal) - cantidadExonera,
                    Cuenta = cuentaServicio,
                    Detalle = "Registro Documentos Copias",
                    FacturaId = factura.FacturaId,
                    PrecioUnitario = docCopias.FirstOrDefault().CostoCopiaFinal,
                    Descuento = 0m
                };

                if (td.Cantidad <= 0)
                {
                    td.Cantidad = 0; td.PrecioUnitario = 0;
                }

                factura.TransaccionDetalle.Add(td);
            }



            factura.TotalFactura = factura.TransaccionDetalle.Sum(a => (a.Cantidad * a.PrecioUnitario) - a.Descuento);

            if (!factura.Credito.HasValue)
                factura.Credito = 0;

            this.CostoTransaccion = factura.TotalFactura;
            factura.TotalFactura -= Credito;
            if (factura.TotalFactura < 0)
            {
                factura.TotalFactura = 0M;
            }




            if (tnx.ServicioId == 398 || tnx.ServicioId == 421)
            {

                //rutina temporal buscar la cuenta del servicio de colegio abogados:
                var ServCuentaColegio = string.Empty;
                //   var dbComunServi = new CamaraComunEntities();

                /*  var repTemp = new ServicioRepository();

                  var service = repTemp.GetServicioById(SellosColegioServiceId).FirstOrDefault();
                  if (service != null )
                  {
                      ServCuentaColegio = service.Cuenta;              
                  }
                  */

                //esta cuenta se buscara por el codigo del servicio desde su tabla : EP 2021-05-14
                var tdr = new TransaccionDetalle
                {
                    Cantidad = 1,
                    Cuenta = SellosColegioCuenta, // cuentaServicio,
                    Detalle = "Cargo de RD$50.00 correspondiente a la contribución del Colegio de Abogados de la República Dominicana",
                    PrecioUnitario = 50,
                    Descuento = 0,
                };

                factura.TransaccionDetalle.Add(tdr);
                factura.TotalFactura = factura.TotalFactura + 50;

            }



            return factura;
        }

        private string SendInvoiceToAccounting(Facturas header, string rnc, string nombresolicitante, int?
            tipoComprobanteId, bool? bhd)
        {
            //  mandar un 6 (transferencia) envez de 2 (tarjeta) 
            int metodopago = 2;

            if (bhd == true) { metodopago = 2; }
            else
            {
                metodopago = 1;
            }


            if (!tipoComprobanteId.HasValue)
                throw new InvalidOperationException("No se especificó un tipo de comprobante para esta transacción");


            List<RegistroPago> pagos = new List<RegistroPago>();
#pragma warning disable CS0168 // The variable 'outTipoNcfId' is declared but never used
            int outTipoNcfId;
#pragma warning restore CS0168 // The variable 'outTipoNcfId' is declared but never used
            var servicios = (from TransaccionDetalle data in header.TransaccionDetalle
                             select new wsFacturacion.Servicio
                             {
                                 Cantidad = data.Cantidad.ToString(),
                                 Codigo = data.Cuenta,
                                 Descripcion = data.Detalle,
                                 Descuento = data.Descuento,
                                 PrecioUnitario = data.PrecioUnitario,
                                 Total = data.PrecioUnitario,
                                 TransaccionId = header.TransaccionId.HasValue ? header.TransaccionId.Value : 0
                             }).ToArray();

            //Se están enviando campos en cero a gestión. No importa porque ya los maneja el sistema de gestión
            var tarjeta = new OFV.TransaccionesTarjeta()
            {
                AnoVencimiento = "",
                MesVencimiento = "",
                bCancelada = false,
                bProcesada = true,
                FacturaId = 0,
                FechaTransaccion = DateTime.Now,
                NombreBanco = "Nobox Transaccional",
                NumeroTarjeta = "",
                NombreTarjeta = "",
                TipoTarjeta = "1"
            };
            // if (NotaCredito?.NumeroNota != 0 && NotaCredito != null)
            if (NotaCredito != null && !string.IsNullOrEmpty(NotaCredito.Voucher))
            {

                pagadoTarjeta = header.TotalFactura;

                if (pagadoTarjeta > 0)
                {
                    pagos.Add(new RegistroPago
                    {
                        Fecha = header.Fecha,
                        MetodoPago = metodopago, // 2, Forma Pago Tarjeta Credito
                        Monto = pagadoTarjeta,
                        Nota = tarjeta.NombreBanco,
                        Refenrencia = tarjeta.NumeroTarjeta,
                        TarjetaCredito = tarjeta.NumeroTarjeta
                    });
                }

                pagos.Add(
                    new RegistroPago
                    {
                        Fecha = header.Fecha,
                        MetodoPago = 8, // 4, Forma Pago Nota Credito
                        Monto = pagadoNota,
                        NotaCreditoId = NotaCredito.NumeroNota.Value,
                        Nota = "Pago con nota de crerdito",
                        Refenrencia = "",
                        TarjetaCredito = "",
                        VoucherNotaCredito = NotaCredito.Voucher
                    });

            }
            else
            {
                pagos.Add(new RegistroPago
                {
                    Fecha = header.Fecha,
                    MetodoPago = metodopago, // 2, Forma Pago Tarjeta Credito
                    Monto = header.TotalFactura,
                    Nota = tarjeta.NombreBanco,
                    Refenrencia = tarjeta.NumeroTarjeta,
                    TarjetaCredito = tarjeta.NumeroTarjeta,
                }
               );
            }

            var UsuarioFact = "";
            if (bhd == true) { UsuarioFact = ConfigurationManager.AppSettings["UsuarioCaja"].ToString(); } else { UsuarioFact = ConfigurationManager.AppSettings["UsuarioFacturacion"].ToString(); }


#if !DEBUG
            var factura = facturacion.GenerarFactura(rnc.RemoverFormato(),
                    nombresolicitante, tipoComprobanteId.Value, header.CamaraId,
                    UsuarioFact, servicios, pagos.ToArray(), false);

            return factura.NCF;
#else

            return string.Format("A0200102101000000") + (new Random(1)).Next(99).ToString();
#endif
        }





        private Facturas ObtenerFactura(long transaccionId)
        {
            var db = new OFV.CamaraWebsiteEntities();
            var factura = (from t in db.Facturas
                           where t.TransaccionId.HasValue && t.TransaccionId.Value == transaccionId
                           select t).OrderByDescending(x => x.FacturaId).FirstOrDefault();

            return factura;
        }

        //Metodo que se llama después que el transaccional retorna un resultado
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ProcesarPagoTarjeta(VisanetDTO, int, string)'
        public void ProcesarPagoTarjeta(VisanetDTO response, int transId = 0, string medioDePago = "")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ProcesarPagoTarjeta(VisanetDTO, int, string)'
        {

            bool esbhd = false;
            if (medioDePago == "BHD")
            {
                esbhd = true;
            }

            //aqui entro con carnet
            var redirectUrl = String.Empty;

            var dbWebsite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            int transaccionId = 0;
            var factu = new OFV.Facturas();
            transaccionId = PagoVisanetService.GetTransaccionByOrderIdAndSystemType(response.OrderID,
                                                                                EnumSystemType.CamaraOnline);

            var transaccion = dbWebsite.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId
                && t.UserName == User.Identity.Name.ToLower());

            if (transaccion != null && transaccion.TransaccionId > 0)
            {
                #region Caching de propiedades fuera del Transaction Scope (para evitar llamar el MSDTC)
                var idServicio = dbWebsite.Transacciones
                                    .Where(t => t.TransaccionId == transaccion.TransaccionId)
                                    .Select(t => t.ServicioId).FirstOrDefault();
                if (idServicio == 0)
                {
                    Master.ShowMessageError("No existe una transacción pendiente. El pago no puede ser realizado. Intente nuevamente.");
                    return;
                }

                #region Verificacion de transaccion nula
                // if (transaccion.bPagada)
                //    redirectUrl = "~/Empresas/CierreSolicitud.aspx" + DefaultQueryString;

                //var verifyTransacion = dbWebsite.TransaccionesTarjeta.FirstOrDefault(
                //    a => a.Facturas.TransaccionId == transaccion.TransaccionId && a.bCancelada == false);
                //var transHelper = new TransaccionDevueltaHelper(Request);
                ////if (verifyTransacion != null && !transHelper.EstaDevuelta())
                //{
                //    Master.ShowMessageError("La transacción ha sido registrada anteriormente. Vea sus transacciones pendientes en <a href='/Empresas/Oficina.aspx'>transacciones en progreso.</a>");
                //    return;
                //}
                #endregion

                var tipoSociedad = dbComun.TipoSociedad
                    .FirstOrDefault(a => a.TipoSociedadId == transaccion.TipoSociedadId);
                var nombreTipoSociedad = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;

                var nombresolicitante = (dynamic)null;
                var rnc = (dynamic)null;

                if (transaccion.ServicioId != 745 && transaccion.ServicioId != 746 && transaccion.ServicioId != 747 && transaccion.ServicioId != 748)
                {

                    nombresolicitante = this.NombreSolicitante;
                    rnc = this.RNC;
                }

                //Asignando la transaccion como prioritaria.
                //transaccion.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

                //Servicios a ser facturados
                var servicios = new List<DTO.ServicioDTO>();
                var costosServicios = new Dictionary<int, decimal>();
                var repTransaccion = new OFV.TransaccionesRepository();
                var dbServicios = dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId);
                servicios.AddRange(dbServicios.Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta, bFactura = s.SiteVisible })
                        .ToList());

                var considerarMods = true;

                costosServicios[transaccion.TransaccionId] = repTransaccion.GetCostoTransaccionCabecera(transaccion, Helper.PorcentajeVIP);

                //Validacion de servicios para los que no se cobran modificaciones extras
                var servicioInfo = dbServicios.FirstOrDefault();
                if (servicioInfo != null && !servicioInfo.SeCobraEnSubTransaccion && servicioInfo.TransaccionJerarquia > 0 ||
                   Helper.ServiciosHeaderIds.Contains(servicioInfo.ServicioId))
                    considerarMods = false;

                if (transaccion.SubTransacciones.Count() > 0)
                {
                    var ids = transaccion.SubTransacciones.Select(st => st.ServicioId).ToList();
                    servicios.AddRange(
                        dbComun.Servicio.Where(s => ids.Contains(s.ServicioId))
                            .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta })
                            .ToList());

                    foreach (var subtnx in transaccion.SubTransacciones)
                    {
                        if (!costosServicios.ContainsKey(subtnx.TransaccionId))
                            costosServicios[subtnx.TransaccionId] = repTransaccion
                               .GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP, considerarMods, transaccion.Prioridad == 1);

                        if (considerarMods)
                        {
                            var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                            if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                                considerarMods = false;
                        }
                    }
                }

                var seCobraEnSubTransaccion = servicioInfo.SeCobraEnSubTransaccion;
                dbComun.Dispose();

                #endregion
                //using (var scope = new System.Transactions.TransactionScope())
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new System.TimeSpan(0, 5, 0)))
                {
                    try
                    {
                        //Se marca la factura como pagada
                        transaccion.NombreContacto = String.IsNullOrEmpty(transaccion.NombreContacto)
                                                        ? nombresolicitante.NombreCompleto
                                                        : transaccion.NombreContacto;
                        transaccion.RNCSolicitante = String.IsNullOrEmpty(transaccion.RNCSolicitante)
                                                        ? rnc
                                                        : transaccion.RNCSolicitante;
                        transaccion.Solicitante = String.IsNullOrEmpty(transaccion.Solicitante)
                                                        ? nombresolicitante.NombreCompleto
                                                        : transaccion.Solicitante;



                        //Si el pago fue empresarial se guardara en la tabla hasta que los empresarios liberen la cuenta pagada y no se guardara
                        //en la tabla de facturacion y ni en el SRM
                        if (Session["Sometido"] != null && Session["Sometido"].ToString() == "True")
                        {
                            using (var context = new CamaraWebsiteEntities())
                            {
                                var bhd = new OFV.TransaccionesEmpBHD()
                                {
                                    reference = Session["reference"].ToString(),
                                    TransactionId = Session["processTransactionId"].ToString(),
                                    Estatus = 1,
                                    UserName = User.Identity.Name.ToLower(),
                                    SolicitudId = transaccionId,
                                    FechaModificacion = DateTime.Now,
                                    EstadoString = Session["Sometido"].ToString()
                                };
                                context.TransaccionesEmpBHD.AddObject(bhd);
                                context.SaveChanges();
                            }
                        }


                        //aqui se pondra la condicion si es empresarial no se guardara la factura ni en SRM

                        if (Session["Sometido"] == null)
                        {

                            //Se crean las Facturas en el WebSite
                            var factura = GenerarFacturas(transaccion, nombreTipoSociedad, servicios, costosServicios, transaccion.TipoComprobanteId, seCobraEnSubTransaccion);
                            factura.Ncf = SendInvoiceToAccounting(factura, transaccion.RNCSolicitante, transaccion.Solicitante, transaccion.TipoComprobanteId, esbhd);
                            factu = factura;
                            dbWebsite.Facturas.AddObject(factura);

                            //Se agrega la informacion de la tarjeta de crédito
                            var tarjeta = new OFV.TransaccionesTarjeta()
                            {
                                AnoVencimiento = "",
                                MesVencimiento = "",
                                bCancelada = false,
                                bProcesada = true,
                                FacturaId = 0,
                                FechaTransaccion = DateTime.Now,
                                NombreBanco = "Nobox Transaccional",
                                NumeroTarjeta = response.Tarjeta,
                                NombreTarjeta = transaccion.NombreContacto,
                                TipoTarjeta = "1",
                                MedioDePago = medioDePago
                            };
                            factura.TransaccionesTarjeta.Add(tarjeta);

                            transaccion.NCF = factura.Ncf;
                            transaccion.EstatusTransId = Helper.EstatusTransIdAnalisis;
                            transaccion.TipoNcf = transaccion.TipoComprobanteId.ToString();
                            transaccion.bPagada = true;
                            dbWebsite.SaveChanges();
                        }

                        scope.Complete();
                    }
                    catch (Exception ext)
                    {
                        string a = ext.Message;
                    }

                }
                //Aqui grabo al srm
                var helper = new Helper();

                var Error = "";
                bool saved = false;
                //Se graba al srm


                if (Session["Sometido"] == null)
                {
                    saved = helper.GrabarAlSrm(transaccion.CamaraId, transaccion.TransaccionId, transaccion.NombreContacto,
                                           transaccion.TelefonoContacto, out Error);
                }

                if (saved)
                {
                    if (transaccion.ServicioId != 745 && transaccion.ServicioId != 746 && transaccion.ServicioId != 747 & transaccion.ServicioId != 748)
                    {
                        if (transaccion.ServicioId == 398 || transaccion.ServicioId == 421)
                        {
                            try
                            {
                                var subTransSrm = new SRM.SubTransacciones()
                                {
                                    TipoServicioId = 743,
                                    TransaccionId = ObtenerTranSRM(transaccion.TransaccionId),
                                    TipoTransaccionId = transaccion.ServicioId,
                                    Servicio = "SELLO COLEGIO DE ABOGADOS",
                                    Estatus = 3,
                                    TipoServicio = "SELLO COLEGIO DE ABOGADOS",
                                    CustomInt1 = transaccion.TipoSociedadId,
                                    CustomInt2 = transaccion.NumeroRegistro,
                                    CustomString1 = transaccion.NombreSocialPersona,
                                    CustomString2 = String.Empty,
                                    CustomString3 = String.Empty,
                                    CustomDecimal1 = transaccion.CapitalSocial,
                                    CustomDecimal2 = transaccion.ModificacionCapital,
                                    FechaModificacion = DateTime.Now,
                                    FlowId = null,//Guid.NewGuid(),
                                };

                                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext("SDQ");
                                var subtransList = new List<SRM.SubTransacciones>();
                                var repSubTransaccion = new SRM.SubTransaccionesRepository(context);
                                repSubTransaccion.Add(subTransSrm);
                                var dd = repSubTransaccion.Save();
                                context.Connection.Close();

                            }
                            catch (Exception ex)
                            {
                                throw ex.InnerException;
                            }
                        }
                    }
                }

                //Para Enviar correo de confirmacion cuando se esta realizando este servicio
                if (transaccion.ServicioId == 745 || transaccion.ServicioId == 746 || transaccion.ServicioId == 747 || transaccion.ServicioId == 748)
                {

                    var textoFirmadigital = Session["DetalleCompraFirmaDigital"].ToString();
                    var parametros = new Dictionary<string, string>();
                    parametros.Add("[NombreCompleto]", textoFirmadigital);


                    //Session["UsarioDigital"] = HttpContext.Current.User.Identity.Name;
                    //Session["SolicitanteDigital"] = profile.NombreSolicitante.ToString();
                    //Session["ActividadDigital"] = Texto + " " + ", por el tiempo de " + tiempo + " ano ,";
                    //Session["CantidadDigital"] = Cantidad;

                    var to = HtmlHelper.GetAppVariable("CorreoFirmaDigital").ToString();
                    var cc = HtmlHelper.GetAppVariable("CorreoFirmaDigitalCC").ToString();


                    //invocar envio de template Recuperación de Contraseña
                    MailBot.MailBot.SendMail(to, cc, null,
                        Helper.FromEmailCorreoCamara, "FIRMA", Helper.MailServer, 1, parametros, Session["UsarioDigital"].ToString(), Session["SolicitanteDigital"].ToString()
                       , Session["ActividadDigital"].ToString() + "Cantidad : " + Session["CantidadDigital"].ToString(), Session["CantidadDigital"].ToString());

                }


                ErrorMessage = Error;
                if (saved)
                {
                    //Almaceno valor para poder imprimir
                    if (!DefaultQueryString.Contains("FacturaId="))
                        DefaultQueryString = String.Format("FacturaId={0}", factu.FacturaId);
                    redirectUrl = "/Empresas/CierreSolicitud.aspx" + DefaultQueryString;
                }
                else
                {
                    redirectUrl = string.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true", transaccion.TransaccionId);
                }
            }

            if (!string.IsNullOrWhiteSpace(redirectUrl)) Response.Redirect(redirectUrl);
        }

        private void ProcesarTransaccionSinPago(int transaccionId = 0, string medioDePago = "")
        {
            var redirectUrl = String.Empty;

            var dbWebsite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();


            var factu = new OFV.Facturas();


            var transaccion = dbWebsite.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId
                && t.UserName == User.Identity.Name.ToLower());

            if (transaccion != null && transaccion.TransaccionId > 0)
            {
                #region Caching de propiedades fuera del Transaction Scope (para evitar llamar el MSDTC)
                var idServicio = dbWebsite.Transacciones
                                    .Where(t => t.TransaccionId == transaccion.TransaccionId)
                                    .Select(t => t.ServicioId).FirstOrDefault();
                if (idServicio == 0)
                {
                    Master.ShowMessageError("No existe una transacción pendiente. El pago no puede ser realizado. Intente nuevamente.");
                    return;
                }

                #region Verificacion de transaccion nula
                //if (transaccion.bPagada)
                //    redirectUrl = "~/Empresas/CierreSolicitud.aspx" + DefaultQueryString;

                //var verifyTransacion = dbWebsite.TransaccionesTarjeta.FirstOrDefault(
                //    a => a.Facturas.TransaccionId == transaccion.TransaccionId && a.bCancelada == false);

                //var transHelper = new TransaccionDevueltaHelper(Request);
                //if (verifyTransacion != null && !transHelper.EstaDevuelta())
                //{
                //    Master.ShowMessageError("La transacción ha sido registrada anteriormente. Vea sus transacciones pendientes en <a href='/Empresas/Oficina.aspx'>transacciones en progreso.</a>");
                //    return;
                //}
                #endregion

                var tipoSociedad = dbComun.TipoSociedad
                    .FirstOrDefault(a => a.TipoSociedadId == transaccion.TipoSociedadId);
                var nombreTipoSociedad = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;

                var nombresolicitante = this.NombreSolicitante;
                var rnc = this.RNC;

                //Asignando la transaccion como prioritaria.
                //transaccion.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

                //Servicios a ser facturados
                var servicios = new List<DTO.ServicioDTO>();
                var costosServicios = new Dictionary<int, decimal>();
                var repTransaccion = new OFV.TransaccionesRepository();

                servicios.AddRange(dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId)
                        .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta, bFactura = s.SiteVisible })
                        .ToList());

                var considerarMods = true;

                costosServicios[transaccion.TransaccionId] = repTransaccion.GetCostoTransaccionCabecera(transaccion, Helper.PorcentajeVIP);

                //Validacion de servicios para los que no se cobran modificaciones extras
                var servicioInfo = dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId).FirstOrDefault();
                if (servicioInfo != null && !servicioInfo.SeCobraEnSubTransaccion && servicioInfo.TransaccionJerarquia > 0 ||
                   Helper.ServiciosHeaderIds.Contains(servicioInfo.ServicioId))
                    considerarMods = false;

                if (transaccion.SubTransacciones.Count() > 0)
                {
                    var ids = transaccion.SubTransacciones.Select(st => st.ServicioId).ToList();
                    servicios.AddRange(
                        dbComun.Servicio.Where(s => ids.Contains(s.ServicioId))
                            .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta })
                            .ToList());

                    foreach (var subtnx in transaccion.SubTransacciones)
                    {
                        if (!costosServicios.ContainsKey(subtnx.TransaccionId))
                            costosServicios[subtnx.TransaccionId] = repTransaccion
                               .GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP, considerarMods, transaccion.Prioridad == 1);

                        if (considerarMods)
                        {
                            var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                            if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                                considerarMods = false;
                        }
                    }
                }

                var seCobraEnSubTransaccion = servicioInfo.SeCobraEnSubTransaccion;
                dbComun.Dispose();

                #endregion
                using (var scope = new System.Transactions.TransactionScope())
                {
                    //Se marca la factura como pagada
                    transaccion.NombreContacto = String.IsNullOrEmpty(transaccion.NombreContacto)
                                                    ? nombresolicitante.NombreCompleto
                                                    : transaccion.NombreContacto;
                    transaccion.RNCSolicitante = String.IsNullOrEmpty(transaccion.RNCSolicitante)
                                                    ? rnc
                                                    : transaccion.RNCSolicitante;
                    transaccion.Solicitante = String.IsNullOrEmpty(transaccion.Solicitante)
                                                    ? nombresolicitante.NombreCompleto
                                                    : transaccion.Solicitante;

                    //Se crean las Facturas en el WebSite
                    var factura = GenerarFacturas(transaccion, nombreTipoSociedad, servicios, costosServicios, transaccion.TipoComprobanteId, seCobraEnSubTransaccion);

                    if (idServicio != 741 && idServicio != 686)
                    {
                        factura.Ncf = SendInvoiceToAccounting(factura, transaccion.RNCSolicitante, transaccion.Solicitante, transaccion.TipoComprobanteId, false);
                    }


                    factu = factura;

                    dbWebsite.Facturas.AddObject(factura);

                    //Se agrega la informacion de la tarjeta de crédito
                    var tarjeta = new OFV.TransaccionesTarjeta()
                    {
                        AnoVencimiento = "",
                        MesVencimiento = "",
                        bCancelada = false,
                        bProcesada = true,
                        FacturaId = 0,
                        FechaTransaccion = DateTime.Now,
                        NombreBanco = "Nobox Transaccional",
                        NumeroTarjeta = "0000-0000-0000-0000",
                        NombreTarjeta = transaccion.NombreContacto,
                        TipoTarjeta = "1",
                        MedioDePago = medioDePago
                    };
                    factura.TransaccionesTarjeta.Add(tarjeta);

                    transaccion.NCF = factura.Ncf;



                    transaccion.TipoNcf = transaccion.TipoComprobanteId.ToString();


                    transaccion.bPagada = true;
                    transaccion.EstatusTransId = Helper.EstatusTransIdEnSRM;

                    dbWebsite.SaveChanges();

                    scope.Complete();

                }
                //Aqui grabo al srm
                var helper = new Helper();
                var Error = "";
                //Se graba al srm
                bool saved = helper.GrabarAlSrm(transaccion.CamaraId, transaccion.TransaccionId, transaccion.NombreContacto,
                                   transaccion.TelefonoContacto, out Error);
                //

                ErrorMessage = Error;
                if (saved)
                {
                    //Almaceno valor para poder imprimir
                    DefaultQueryString = String.Format("FacturaId={0}", factu.FacturaId);
                    redirectUrl = "/Empresas/CierreSolicitud.aspx" + DefaultQueryString;
                }
                else
                {
                    redirectUrl = string.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true",
                                                transaccion.TransaccionId);
                }
            }

            if (redirectUrl.Length > 0)
                Response.Redirect(redirectUrl);
        }


        private String RNC
        {
            get
            {
                if (txtRnc.Text.Length > 0)
                    return txtRnc.Text;

                if (!String.IsNullOrEmpty(this.Transaccion.RNCSolicitante))
                    return this.Transaccion.RNCSolicitante;

                if (this.User.Identity.IsAuthenticated)
                {
                    var usr = OficinaVirtualUserProfile.GetUserProfile();
                    return usr != null ? usr.RNC : String.Empty;
                }

                return String.Empty;
            }
        }

        private Solicitante NombreSolicitante
        {
            get
            {
                var sol = new Solicitante();
                var usr = OficinaVirtualUserProfile.GetUserProfile();

                sol.NombreCompleto = txtNombre.Text.Length > 0
                                         ? txtNombre.Text
                                         : (!String.IsNullOrEmpty(this.Transaccion.NombreContacto))
                                               ? this.Transaccion.NombreContacto
                                               : (usr.NombreSolicitante.Length > 0)
                                                     ? usr.NombreSolicitante
                                                     : String.Empty;

                sol.PrimerNombre = (sol.NombreCompleto.IndexOf(" ") > 1)
                                       ? sol.NombreCompleto.Substring(0, sol.NombreCompleto.IndexOf(" "))
                                       : sol.NombreCompleto;
                sol.SegundoNombre = (sol.NombreCompleto.IndexOf(" ") != -1)
                                        ? sol.NombreCompleto.Substring(sol.NombreCompleto.IndexOf(" "))
                                        : sol.NombreCompleto;

                return sol;
            }
        }

        private String Email
        {
            get
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    var usr = Membership.GetUser(User.Identity.Name);
                    return (usr != null && !String.IsNullOrEmpty(usr.Email)) ? usr.Email : String.Empty;
                }
                return String.Empty;
            }
        }

        #endregion


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ProcesarTransaccionMandarSRM(int, bool, string)'
        public string ProcesarTransaccionMandarSRM(int transaccionId = 0, bool checkncf = false, string
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ProcesarTransaccionMandarSRM(int, bool, string)'
            user = "")
        {
            var redirectUrl = String.Empty;

            var dbWebsite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            var factu = new OFV.Facturas();

            var _userName = User.Identity.Name;
            if (string.IsNullOrEmpty(user))
                user = _userName;


            var transaccion = dbWebsite.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId
                && t.UserName ==  user.ToLower());

            if (transaccion != null && transaccion.TransaccionId > 0)
            {
                #region Caching de propiedades fuera del Transaction Scope (para evitar llamar el MSDTC)
                var idServicio = dbWebsite.Transacciones
                                    .Where(t => t.TransaccionId == transaccion.TransaccionId)
                                    .Select(t => t.ServicioId).FirstOrDefault();
                if (idServicio == 0)
                {
                    // Master.ShowMessageError("No existe una transacción pendiente. El pago no puede ser realizado. Intente nuevamente.");
                    return "No existe una transacción pendiente. El pago no puede ser realizado. Intente nuevamente.";
                }

                #region Verificacion de transaccion nula

                #endregion

                var tipoSociedad = dbComun.TipoSociedad
                    .FirstOrDefault(a => a.TipoSociedadId == transaccion.TipoSociedadId);
                var nombreTipoSociedad = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;

                //var nombresolicitante = this.NombreSolicitante;
                //var rnc = this.RNC;


                //Servicios a ser facturados
                var servicios = new List<DTO.ServicioDTO>();
                var costosServicios = new Dictionary<int, decimal>();
                var repTransaccion = new OFV.TransaccionesRepository();

                servicios.AddRange(dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId)
                        .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta, bFactura = s.SiteVisible })
                        .ToList());

                var considerarMods = true;

                costosServicios[transaccion.TransaccionId] = repTransaccion.GetCostoTransaccionCabecera(transaccion, Helper.PorcentajeVIP);

                //Validacion de servicios para los que no se cobran modificaciones extras
                var servicioInfo = dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId).FirstOrDefault();
                if (servicioInfo != null && !servicioInfo.SeCobraEnSubTransaccion && servicioInfo.TransaccionJerarquia > 0 ||
                   Helper.ServiciosHeaderIds.Contains(servicioInfo.ServicioId))
                    considerarMods = false;

                if (transaccion.SubTransacciones.Count() > 0)
                {
                    var ids = transaccion.SubTransacciones.Select(st => st.ServicioId).ToList();
                    servicios.AddRange(
                        dbComun.Servicio.Where(s => ids.Contains(s.ServicioId))
                            .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta })
                            .ToList());

                    foreach (var subtnx in transaccion.SubTransacciones)
                    {
                        if (!costosServicios.ContainsKey(subtnx.TransaccionId))
                            costosServicios[subtnx.TransaccionId] = repTransaccion
                               .GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP, considerarMods, transaccion.Prioridad == 1);

                        if (considerarMods)
                        {
                            var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                            if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                                considerarMods = false;
                        }
                    }
                }

                var seCobraEnSubTransaccion = true;
                dbComun.Dispose();

                #endregion
                //using (var scope = new System.Transactions.TransactionScope())
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new System.TimeSpan(0, 5, 0)))
                {


                    if (checkncf)
                    {
                        var factura = GenerarFacturas(transaccion, nombreTipoSociedad, servicios, costosServicios, transaccion.TipoComprobanteId, seCobraEnSubTransaccion, user);
                        factura.Ncf = SendInvoiceToAccounting(factura, transaccion.RNCSolicitante, transaccion.Solicitante, transaccion.TipoComprobanteId, false);
                        factu = factura;

                        dbWebsite.Facturas.AddObject(factura);



                        transaccion.NCF = factura.Ncf;
                        transaccion.TipoNcf = transaccion.TipoComprobanteId.ToString();
                        transaccion.bPagada = true;
                        transaccion.EstatusTransId = Helper.EstatusTransIdEnSRM;

                        dbWebsite.SaveChanges();

                        scope.Complete();
                    }

                }
                //Aqui grabo al srm


                var helper = new Helper();
                var Error = "";
                //Se graba al srm
                bool saved = helper.GrabarAlSrm(transaccion.CamaraId, transaccion.TransaccionId, transaccion.NombreContacto,
                                   transaccion.TelefonoContacto, out Error);
                //

                ErrorMessage = Error;
                if (saved)
                {
                    return "Su Transacción se ha enviado para ser procesada por un analista.";

                }
                else
                {
                    return "Hay un error con los datos de su factura. Por favor contactar al personal de soporte";
                }
            }

            return "No existe este numero de transaccion";
            //if (redirectUrl.Length > 0)
            //    Response.Redirect(redirectUrl);
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect(BackUrl);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnBuscarRNC_Click(object, EventArgs)'
        protected void btnBuscarRNC_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.btnBuscarRNC_Click(object, EventArgs)'
        {
            //#region ProtocoloSeguridadDGII
            //if (ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12) == false)
            //    ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
            //#endregion

            var wsDGI = new WSMovilDGII.WSMovilDGIISoapClient();
            wsDGI.Open();
            var result = wsDGI.GetContribuyentes(this.RNC, 0, 0, 0, "");
            if (result == "0")
            {
                Master.ShowMessageError("El contribuyente indicado es inválido.");
                this.txtRnc.BorderColor = System.Drawing.Color.Red;
                wsDGI.Close();
                return;
            }
            wsDGI.Close();

            this.txtNombre.Text = result.FromAnonJSON<DGIIContribuyenteResp>().RGE_NOMBRE;
            this.NombreSolicitante.NombreCompleto = this.txtNombre.Text.ToUpper();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.DGIIContribuyenteResp'
        public class DGIIContribuyenteResp
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.DGIIContribuyenteResp'
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.DGIIContribuyenteResp.RGE_NOMBRE'
            public string RGE_NOMBRE { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.DGIIContribuyenteResp.RGE_NOMBRE'
        }

        private void ShowMessageError()
        {
            string script = @"<script type='text/javascript'>
                                ErrorRNCInvalido();
                            </script>";

            if (!ClientScript.IsClientScriptBlockRegistered("ErrorRNCInvalido"))
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorRNCInvalido", script);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ddlTipoComprobantes_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoComprobantes_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.ddlTipoComprobantes_SelectedIndexChanged(object, EventArgs)'
        {
            if (this.ddlTipoComprobantes.SelectedItem.Value != "2")
            {
                this.btnBuscarRNC.Visible = true;
                this.txtNombre.ReadOnly = true;
                this.txtNombre.Text = "";
                this.txtRnc.Text = "";
            }
            else
            {
                this.btnBuscarRNC.Visible = false;
                this.txtNombre.ReadOnly = false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.txtRnc_TextChanged(object, EventArgs)'
        protected void txtRnc_TextChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagosTarjeta.txtRnc_TextChanged(object, EventArgs)'
        {

        }
    }

    /// <summary>
    /// Abstracción del nombre del solicitante
    /// </summary>
    class Solicitante
    {
        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormaPagoDearrollo'
    public class FormaPagoDearrollo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormaPagoDearrollo'
    {
        /// <remarks/>
        public int Id { get; set; }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormaPagoDearrollo.Valor'
        public decimal Valor { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormaPagoDearrollo.Valor'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormaPagoDearrollo.NumeroNota'
        public int? NumeroNota { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormaPagoDearrollo.NumeroNota'
        public string Voucher { get; set; }
    }

}