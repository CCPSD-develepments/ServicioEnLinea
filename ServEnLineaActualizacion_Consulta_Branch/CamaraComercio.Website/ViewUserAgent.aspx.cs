using System;
using System.Linq;
using System.Text;

namespace CamaraComercio.Website
{
    public partial class ViewUserAgent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userAgent = Request.UserAgent;
            if (String.IsNullOrEmpty(userAgent)) return;
            var sb = new StringBuilder();
            sb.Append("User String: " + userAgent);
            sb.Append("<br/>");
            var oldBrowsers = (String[]) Application["userAgents"];
            if (oldBrowsers.Contains(userAgent))
                sb.Append("BROWSER IS OUTDATED");
            this.lblUserAgent.Text = sb.ToString();
        }
    }
}