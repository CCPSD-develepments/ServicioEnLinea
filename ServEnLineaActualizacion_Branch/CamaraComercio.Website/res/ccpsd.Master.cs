using System;
using System.Linq;

namespace CamaraComercio.Website.res
{
    ///<summary>
    /// Master Page Principal
    ///</summary>
    public partial class vu : System.Web.UI.MasterPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'vu.Page_Init(object, EventArgs)'
        protected void Page_Init(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'vu.Page_Init(object, EventArgs)'
        {
            //Validacion de browsers modernos
            var userAgent = (!String.IsNullOrEmpty(Request.UserAgent)) ? Request.UserAgent.ToLower() : "";
            
            //IE6-7 Support
            if (userAgent.Contains("msie 7.0") || userAgent.Contains("msie 6.0")
                || userAgent.Contains("msie 6.1"))
            {
                //Response.Redirect("/Navegadores.htm", true);
            }
            
            //Validacion del Menu
            var attr = Page.GetType().GetCustomAttributes(true).Cast<Attribute>();
            var query = from a in attr
                        where a is MembershipHelper.MenuSiteMapAttribute
                        select a as MembershipHelper.MenuSiteMapAttribute;
            if (query.Count() <= 0) return;
            SiteMapDataSource2.SiteMapProvider = query.FirstOrDefault().SiteMapProvider;
            SiteMapDataSource2.DataBind();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'vu.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'vu.Page_Load(object, EventArgs)'
        {
        }

        ///<summary>
        /// Función que muestra un mensaje en el jBar
        ///</summary>
        ///<param name="message"></param>
        public void ShowMessageError(string message)
        {
            lblMessage.Text = message;
        }

        ///<summary>
        /// Propiedad que define el sitemap a utilizar para cada página
        ///</summary>
        public string SiteMapName
        {
            get { return this.SiteMapDataSource1.SiteMapProvider; }
            set 
            { 
                this.SiteMapDataSource1.SiteMapProvider = value;
                this.SiteMapDataSource1.DataBind();
            }
        }

        /// <summary>
        /// Redirección del usuario acabao de salir de la aplicación a la página por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
    }
}