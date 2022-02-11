using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Global'
    public class Global : System.Web.HttpApplication
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Global'
    {

        void Application_Start(object sender, EventArgs e)
        {
            //TODO: Amhed: Fill App Variables for collections that are used a lot

            #region User Agents
            var UserAgents = new String[]
            {
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 6.0)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.2; .net clr 1.1.4322; .net clr 2.0.50727; infopath.2; .net clr 3.0.04506.30)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; media center pc 3.0; .net clr 1.0.3705; .net clr 1.1.4322; .net clr 2.0.50727; infopath.1)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; fdm; .net clr 1.1.4322)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322; infopath.1; .net clr 2.0.50727)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322; infopath.1)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322; alexa toolbar; .net clr 2.0.50727)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322; alexa toolbar)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322; .net clr 2.0.50727)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322; .net clr 2.0.40607)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.1.4322)",
                "mozilla/4.0 (compatible; msie 7.0b; windows nt 5.1; .net clr 1.0.3705; media center pc 3.1; alexa toolbar; .net clr 1.1.4322; .net clr 2.0.50727)",
                "mozilla/5.0 (windows; u; msie 7.0; windows nt 6.0; en-us)",
                "mozilla/5.0 (windows; u; msie 7.0; windows nt 6.0; el-gr)",
                "mozilla/5.0 (msie 7.0; macintosh; u; sunos; x11; gu; sv1; infopath.2; .net clr 3.0.04506.30; .net clr 3.0.04506.648)",
                "mozilla/5.0 (compatible; msie 7.0; windows nt 6.0; wow64; slcc1; .net clr 2.0.50727; media center pc 5.0; c .net clr 3.0.04506; .net clr 3.5.30707; infopath.1; el-gr)",
                "mozilla/5.0 (compatible; msie 7.0; windows nt 6.0; slcc1; .net clr 2.0.50727; media center pc 5.0; c .net clr 3.0.04506; .net clr 3.5.30707; infopath.1; el-gr)",
                "mozilla/5.0 (compatible; msie 7.0; windows nt 6.0; fr-fr)",
                "mozilla/5.0 (compatible; msie 7.0; windows nt 6.0; en-us)",
                "mozilla/5.0 (compatible; msie 7.0; windows nt 5.2; wow64; .net clr 2.0.50727)",
                "mozilla/5.0 (compatible; msie 7.0; windows 98; spamblockerutility 6.3.91; spamblockerutility 6.2.91; .net clr 4.1.89;gb)",
                "mozilla/4.79 [en] (compatible; msie 7.0; windows nt 5.0; .net clr 2.0.50727; infopath.2; .net clr 1.1.4322; .net clr 3.0.04506.30; .net clr 3.0.04506.648)",
                "mozilla/4.0 (windows; msie 7.0; windows nt 5.1; sv1; .net clr 2.0.50727)",
                "mozilla/4.0 (mozilla/4.0; msie 7.0; windows nt 5.1; fdm; sv1; .net clr 3.0.04506.30)",
                "mozilla/4.0 (mozilla/4.0; msie 7.0; windows nt 5.1; fdm; sv1)",
                "mozilla/4.0 (compatible;msie 7.0;windows nt 6.0)",
                "mozilla/4.0 (compatible; msie 7.0; windows nt 6.1; wow64; slcc2; .net clr 2.0.50727; infopath.3; .net4.0c; .net4.0e; .net clr 3.5.30729; .net clr 3.0.30729; ms-rtc lm 8)",
                "mozilla/4.0 (compatible; msie 7.0; windows nt 6.1; wow64; slcc2; .net clr 2.0.50727; .net clr 3.5.30729; .net clr 3.0.30729; media center pc 6.0; ms-rtc lm 8; .net4.0c; .net4.0e; infopath.3)",
                "mozilla/4.0 (compatible; msie 7.0; windows nt 6.1; slcc2; .net clr 2.0.50727; .net clr 3.5.30729; .net clr 3.0.30729; media center pc 6.0; .net4.0c; .net4.0e)",
                "mozilla/4.0 (compatible; msie 7.0; windows nt 6.1; slcc2; .net clr 2.0.50727; .net clr 3.5.30729; .net clr 3.0.30729; media center pc 6.0)",
                "mozilla/4.0 (compatible; msie 7.0; windows nt 6.0;)",
                "mozilla/4.0 (compatible; msie 7.0; windows nt 6.0; ypc 3.2.0; slcc1; .net clr 2.0.50727; media center pc 5.0; infopath.2; .net clr 3.5.30729; .net clr 3.0.30618)",
                "mozilla/4.0 (compatible; msie 6.1; windows xp; .net clr 1.1.4322; .net clr 2.0.50727)",
                "mozilla/4.0 (compatible; msie 6.1; windows xp)",
                "mozilla/4.0 (compatible; msie 6.01; windows nt 6.0)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.1; digext)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.1)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.0; ycomp 5.0.2.6)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.0; ycomp 5.0.0.0) (compatible; ; ; trident/4.0)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.0; ycomp 5.0.0.0)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.0; .net clr 1.1.4322)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.0)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 4.0; .net clr 1.0.2914)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 4.0)",
                "mozilla/4.0 (compatible; msie 6.0b; windows 98; ycomp 5.0.0.0)",
                "mozilla/4.0 (compatible; msie 6.0b; windows 98; win 9x 4.90)",
                "mozilla/4.0 (compatible; msie 6.0b; windows 98)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.1)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 5.0; .net clr 1.0.3705)",
                "mozilla/4.0 (compatible; msie 6.0b; windows nt 4.0)",
                "mozilla/5.0 (windows; u; msie 6.0; windows nt 5.1; sv1; .net clr 2.0.50727)",
                "mozilla/5.0 (compatible; msie 6.0; windows nt 5.1; sv1; .net clr 2.0.50727)",
                "mozilla/5.0 (compatible; msie 6.0; windows nt 5.1; sv1; .net clr 1.1.4325)",
                "mozilla/5.0 (compatible; msie 6.0; windows nt 5.1)",
                "mozilla/45.0 (compatible; msie 6.0; windows nt 5.1)",
                "mozilla/4.08 (compatible; msie 6.0; windows nt 5.1)",
                "mozilla/4.01 (compatible; msie 6.0; windows nt 5.1)",
                "mozilla/4.0 (x11; msie 6.0; i686; .net clr 1.1.4322; .net clr 2.0.50727; fdm)",
                "mozilla/4.0 (windows; msie 6.0; windows nt 6.0)",
                "mozilla/4.0 (windows; msie 6.0; windows nt 5.2)",
                "mozilla/4.0 (windows; msie 6.0; windows nt 5.0)",
                "mozilla/4.0 (windows; msie 6.0; windows nt 5.1; sv1; .net clr 2.0.50727)",
                "mozilla/4.0 (msie 6.0; windows nt 5.1)",
                "mozilla/4.0 (msie 6.0; windows nt 5.0)",
                "mozilla/4.0 (compatible;msie 6.0;windows 98;q312461)",
                "mozilla/4.0 (compatible; windows nt 5.1; msie 6.0) (compatible; msie 6.0; windows nt 5.1; .net clr 1.1.4322; .net clr 2.0.50727)",
                "mozilla/4.0 (compatible; u; msie 6.0; windows nt 5.1)",
                "mozilla/4.0 (compatible; msie 8.0; windows nt 6.1; trident/4.0; mozilla/4.0 (compatible; msie 6.0; windows nt 5.1; sv1) ; slcc2; .net clr 2.0.50727; .net clr 3.5.30729; .net clr 3.0.30729; media center pc 6.0; .net4.0c; infopath.3; tablet pc 2.0)",
                "mozilla/4.0 (compatible; msie 8.0; windows nt 6.1; trident/4.0; gtb6.5; qqdownload 534; mozilla/4.0 (compatible; msie 6.0; windows nt 5.1; sv1) ; slcc2; .net clr 2.0.50727; media center pc 6.0; .net clr 3.5.30729; .net clr 3.0.30729)",
                "mozilla/4.0 (compatible; msie 8.0; windows nt 6.1; fdm; .net clr 1.1.4322; windows nt 6.1; trident/4.0; mozilla/4.0; msie 6.0; windows nt 5.1; sv1 ; slcc2; .net clr 2.0.50727; media center pc 6.0; .net clr 3.5.30729; .net clr 3.0.30729; .net clr 1.1."};
            #endregion
            Application["userAgents"] = UserAgents;

            #region ProtocoloSeguridadDGII
            if (ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12) == false)
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
            #endregion
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Global.RegisterRoutes(RouteCollection)'
        public static void RegisterRoutes(RouteCollection routes)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Global.RegisterRoutes(RouteCollection)'
        {
            routes.Clear();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                MembershipHelper.LogUserActivity("Acceso a portal autorizado.", null);
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                MembershipHelper.LogUserActivity("Usuario ha terminado la sessión", null);
        }
    }
}
