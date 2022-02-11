using CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.DTO;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.TarjetaCredito;
using ModuloPago;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma'
    public partial class CertificadosFirma : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma'
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.totaltoal'
        public decimal totaltoal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.totaltoal'
        //decimal totaltoal;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.Page_Load(object, EventArgs)'
        {

            var CardNumber = HttpContext.Current.Request.Params.Get("CardNumber");
            var IsoCode = HttpContext.Current.Request.Params.Get("IsoCode");


            if (IsoCode == "00")
            {
                var db = new CamaraWebsiteAccountsEntities();
                var al = new ActivityLog
                {
                    ActivityLogID = Guid.NewGuid(),
                    UserId = System.Guid.NewGuid(),
                    Activity = IsoCode,
                    PageUrl = CardNumber,
                    ActivityDate = DateTime.Now.Date,
                    IpAddress = ""
                };
                db.ActivityLog.AddObject(al);
                db.SaveChanges();

                ProcesarPagoVisanet pago = new ProcesarPagoVisanet();
                var vDTO = new VisanetDTO();
                PagosTarjeta ProcesarPagoTarjeta = new PagosTarjeta();

                var visanet = pago.RequestAzul(EnumSystemType.CamaraOnline, "SDQ");

                vDTO.Amount = visanet.Amount;
                vDTO.AuthCode = visanet.AuthCode;
                vDTO.Currency = visanet.Currency;
                vDTO.MerchantKey = visanet.MerchantKey;
                vDTO.OrderID = visanet.OrderID;
                vDTO.ReferenceCode = visanet.ReferenceCode;
                vDTO.Tarjeta = visanet.Tarjeta;
                ProcesarPagoTarjeta.ProcesarPagoTarjeta(vDTO, 0);
            }
           

            // var ff = Session["xPersonaId"].ToString();

            pnlDetalles.Visible = false;
           // txtcantidad.Text = "1";
           // LoadDetalleFacturas();
        }

        private void LoadDetalleFacturas()
        {
            var user = HttpContext.Current.User.Identity.Name;
            var profile = OficinaVirtualUserProfile.GetUserProfile(user);

            var detalle = new List<DetalleServicio>();
            var Cantidad =  Convert.ToInt32(txtcantidad.Text);
            var Texto = ddltipoproducto.SelectedItem.Text + " de firma digital";

            double monto;
            var tiempo = Convert.ToInt32(ddltiempo.SelectedItem.Value);

            if (tiempo == 1)
            {
                //si es 1 ano vale 30 usd 
                monto = 1750;
            }
            else
            {
                //si son 2 anos vale 45 usd 
                monto = 2600;
            }

            var proxy = new WSMondorRates.iRatesClient();
            decimal resultCapAutorizado = (decimal)monto;
          //  decimal.TryParse(proxy.Convert("DOP", "USD", monto, Helper.PasswordMondorRates).ToString(), out resultCapAutorizado);


            detalle.Add(new DetalleServicio
            {
                Descripcion = Texto +"por el tiempo de : "+ tiempo,
                Cantidad = Cantidad,
                Costo = resultCapAutorizado
            });

             this.totaltoal = decimal.Round((resultCapAutorizado * Cantidad), 2);

            lblCredito.Text = "0.00";
            lblTotalTransaccion.Text = (totaltoal).ToString("#,##0.###");
            lblTotal.Text = (totaltoal).ToString("#,##0.###");

            Session["DetalleCompraFirmaDigital"] =  "Usuario : "+ HttpContext.Current.User.Identity.Name +
                "/ Nombre Solicitante :  " +  profile.NombreSolicitante.ToString() + 
                " /  realizo : "+ Texto +" " +
                ", por el tiempo de " + tiempo +" ano ," +
                " Cantidad : "+ Cantidad;


            Session["UsarioDigital"] = HttpContext.Current.User.Identity.Name;
            Session["SolicitanteDigital"] = profile.NombreSolicitante.ToString();
            Session["ActividadDigital"] = Texto + " " + ", por el tiempo de " + tiempo + " ano ,";
            Session["CantidadDigital"] = Cantidad;

            rpDetalleServicio.DataSource = detalle;
            rpDetalleServicio.DataBind();

            decimal total = 0;

            foreach (var item in detalle)
                total += item.Costo;

            var lbl = (Label)this.rpDetalleServicio.FindControlInFooter("txtCostoTotalTransaccion");
            total = decimal.Round(total, 2);
            //lbl.Text = total.ToString();
           // lblTotalTransaccion.Text = total.ToString();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.btnContinuarSinCosto_Click(object, EventArgs)'
        protected void btnContinuarSinCosto_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.btnContinuarSinCosto_Click(object, EventArgs)'
        {
            var Cantidad =  (txtcantidad.Text == "")? 0 : Convert.ToInt32(txtcantidad.Text);
            
            if (Cantidad > 0) {
                Panel1.Visible = false;
                pnlDetalles.Visible = true;
                LoadDetalleFacturas();
            }
            else
            {
                string strMessage = "Tiene que introducir la cantidad de certificados que quiera comprar.\\r\\n Intente nuevamente.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strMessage + "');</script>");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.Button2_Click(object, EventArgs)'
        protected void Button2_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.Button2_Click(object, EventArgs)'
        {
            Panel1.Visible = true;
            pnlDetalles.Visible = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.btnregresar_Click(object, EventArgs)'
        protected void btnregresar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.btnregresar_Click(object, EventArgs)'
        {

            decimal montotoal = Convert.ToDecimal(lblTotal.Text);
            var user = HttpContext.Current.User.Identity.Name;
            var profile = OficinaVirtualUserProfile.GetUserProfile(user);
            ProcesarPagoVisanet pago = new ProcesarPagoVisanet();


           var Resultado = RegisterTransaction();
            //guardamos en el log 
            LogTransaccionesMethods.GrabarLogTransacciones(Resultado.TransaccionId, "/Empresas/CertificadosFirma.aspx", true, User.Identity.Name.ToLower());

            //        string url = string.Concat(LogTransaccionesMethods.ObtenerUltimaURL(Resultado.TransaccionId));
            //        string urlRes = url;

           string DefaultQueryString = String.Format("?nSolicitud={0}&CamaraId=SDQ", Resultado.TransaccionId);
           var urlReturnPagoTransaccion = ConfigurationManager.AppSettings["TransaccionalUrlPaginaTransaccion"].ToString()+DefaultQueryString;

            pago.RealizarPago(Resultado.TransaccionId, montotoal, profile.UserName,
                string.IsNullOrEmpty(profile.RNC) ? string.Empty : "", urlReturnPagoTransaccion,
               EnumSystemType.CamaraOnline, "SDQ");

            //var prueba = 433;

        }


         
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.RegisterTransaction(int?)'
        public OFV.Transacciones RegisterTransaction(int? modeloId = null)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CertificadosFirma.RegisterTransaction(int?)'
        {

            var servicioidfinal = 0;
            
            var servicioSeleccionado = Convert.ToInt32(ddltipoproducto.SelectedItem.Value);
            var tiempo =  Convert.ToInt32(ddltiempo.SelectedItem.Value);

            //productoid 1  = nueva emision 
            //productoid 2  =   renovacion

            if(servicioSeleccionado == 1)
            {
                if (tiempo == 1) {
                    servicioidfinal = 745;
                } else
                {
                    servicioidfinal = 746;
                }
            }
            else
            {
                if (tiempo == 1)
                {
                    servicioidfinal = 747;
                }
                else
                {
                    servicioidfinal = 748;
                }

            }


            var user = HttpContext.Current.User.Identity.Name;
            var profile = OficinaVirtualUserProfile.GetUserProfile(user);


            // var repSociedades = new SociedadesController();
            // var registro = repSociedades.FindRegistro(0, "SDQ") ?? new SociedadesRegistros();

            var transaccion = new OFV.Transacciones
            {
                Fecha = DateTime.Now,
                NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                RegistroId = 0,
                ModificacionCapital = 0,
                CapitalSocial = 0,
                TipoSociedadId = 0,
                RNCSolicitante = txtRnc.Text,
                ServicioId = servicioidfinal,
                UserName = User.Identity.Name.ToLower(),
                CamaraId = "SDQ",
                EstatusTransId = Helper.EstatusTransIdCompletado,
                Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                FechaAsamblea = null,// buscar la fecha asamble a deeste 
                NombreSocialPersona = "", // no se 
                TipoModeloId = modeloId,
                NumeroRegistro = 0, // numero de registro 
                Comentario = ddltipoproducto.SelectedItem.Text + " de firma digital",
                TipoComprobanteId = Convert.ToInt32(ddltipofactura.SelectedItem.Value),
                CantidadCopiaCertificaciones = Convert.ToInt32(txtcantidad.Text),
                ImprimirCopias = true
        };

            var repTransaccion = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            repTransaccion.Add(transaccion);
            var result = repTransaccion.Save() > 0;

            return result ? transaccion : null;
        }

    }
}