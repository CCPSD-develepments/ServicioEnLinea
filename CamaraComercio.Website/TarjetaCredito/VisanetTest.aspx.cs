using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hammock;
using Hammock.Web;

namespace CamaraComercio.Website
{
    public partial class VisanetTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            var urlVisanet = "https://ecommerce.visanet.com.do/APaymentWebPay/default.aspx";
            var llaveComercio = "NJMZMJK0MJY4ODG4MTA0MZI0";

            var token = String.Empty;
            var values = new NameValueCollection();

            values.Add("MerchantKey", "NjMzMjk0MjY4ODg4MTA0MzI0");
            values.Add("OrderID", "A-123477");
            values.Add("Currency", "214");
            values.Add("Nombres", "Amhed Herrera");
            values.Add("Identificacion", "05601345191");
            values.Add("Amount", "850.25");
            values.Add("Tax", "15.28");
            values.Add("ReturnURL", "http://www.nextmedia.com.do");

            VisanetHelper.RedirectAndPOST(this.Page, urlVisanet, values);
        }
    }
}