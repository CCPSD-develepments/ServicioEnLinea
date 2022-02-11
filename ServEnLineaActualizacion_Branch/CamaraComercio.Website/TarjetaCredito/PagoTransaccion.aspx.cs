using CamaraComercio.DataAccess.EF.Membership;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.TarjetaCredito
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion'
    public partial class PagoTransaccion : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion'
    {
        private String _defaultQueryString = String.Empty;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.DefaultQueryString'
        public String DefaultQueryString
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.DefaultQueryString'
        {
            get
            {
                return String.IsNullOrWhiteSpace(_defaultQueryString) ?
                    String.IsNullOrWhiteSpace(ClientQueryString) ? String.Empty : "?" + ClientQueryString
                    : _defaultQueryString;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    _defaultQueryString = string.Empty;
                else
                {
                    if (ClientQueryString.Length > 0)
                        _defaultQueryString = "?" + ClientQueryString;

                    _defaultQueryString = _defaultQueryString.Length == 0
                                              ? String.Format("{0}{1}", "?", value)
                                              : String.Format("{0}{1}{2}", _defaultQueryString, "&", value);
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.statusbhd'
        public bool statusbhd = false;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.statusbhd'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.Page_Load(object, EventArgs)'
        {
            var bhdrespuesta  = HttpContext.Current.Request.Params.Get("transactionState"); 
            
            var CardNumber = HttpContext.Current.Request.Params.Get("CardNumber");
            var IsoCode = HttpContext.Current.Request.Params.Get("IsoCode");
            Session["Sometido"] = null;

            if (bhdrespuesta != null &&  (bhdrespuesta == "Completada" || bhdrespuesta == "Sometido" )) {
                statusbhd = true;

                if (bhdrespuesta == "Sometido")
                {
                    Session["Sometido"] = true;
                    Session["reference"] = HttpContext.Current.Request.Params.Get("reference");
                    Session["processTransactionId"] = HttpContext.Current.Request.Params.Get("processTransactionId");
                }

            }


            if (IsoCode != "00" && IsoCode != null)
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
            }



            btnContinuar.Visible = true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.btnContinuar_Click(object, EventArgs)'
        {
            btnContinuar.Enabled = false;
            btnContinuar.Visible= false;
            var returnUrl = ConfigurationManager.AppSettings["TransaccionalUrl"] + DefaultQueryString;

            if(statusbhd== true)
            {
                returnUrl = returnUrl+ Session["VariablesParaBHD"].ToString();
            }

            Response.Redirect(returnUrl);
        }

        [ScriptMethod(), WebMethod()]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.Continuar()'
        public void Continuar()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PagoTransaccion.Continuar()'
        {
           // var returnUrl = ConfigurationManager.AppSettings["TransaccionalUrl"] + DefaultQueryString;
           // Response.Redirect(returnUrl);
        }

    }
}