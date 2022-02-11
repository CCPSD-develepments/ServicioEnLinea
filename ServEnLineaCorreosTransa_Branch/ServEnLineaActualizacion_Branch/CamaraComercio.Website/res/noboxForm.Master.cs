using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.Membership;

namespace CamaraComercio.Website.res
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'noboxForm'
    public partial class noboxForm : System.Web.UI.MasterPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'noboxForm'
    {
        //Properties
        
        /// <summary>
        /// Propiedad que determina el tipo de actividad que se ejecuta en la página
        /// </summary>
        public string NombreActividad { get; set; }

        //Eventos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'noboxForm.Page_Init(object, EventArgs)'
        protected void Page_Init(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'noboxForm.Page_Init(object, EventArgs)'
        {
            //Validacion de browsers modernos
            var userAgent = (!String.IsNullOrEmpty(Request.UserAgent)) ? Request.UserAgent.ToLower() : "";
            
            //IE6-7 Support
            if (userAgent.Contains("msie 6.0") || userAgent.Contains("msie 6.1"))
            {
                Response.Redirect("/Navegadores.htm", true);
            }

            //MobileRedirect
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (Request.Headers["User-Agent"] != null
                    && (Request.Browser["IsMobileDevice"] == "true"
                        || Request.Browser["BlackBerry"] == "true"
                        || userAgent.ToUpper().Contains("MIDP")
                        || userAgent.ToUpper().Contains("CLDC"))
                    || userAgent.ToLower().Contains("iphone")
                    || userAgent.ToLower().Contains("blackberry")
                    )
                {
                    Response.Redirect("/Mobile/Index.html");
                }
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'noboxForm.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'noboxForm.Page_Load(object, EventArgs)'
        {
            var authenticated = HttpContext.Current.User.Identity.IsAuthenticated;
            //pnlLogoutHeader.Visible = !authenticated;
            //pnlLoginHeader.Visible = authenticated;
            //pnlNavigation.Visible = authenticated;
            
            if (IsPostBack) return;

            //Log de actividad del usuario
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(this.NombreActividad))
                    MembershipHelper.LogUserActivity(this.NombreActividad, null);
                
                //Nombre del usuario actual
                var user = HttpContext.Current.User.Identity.Name;
                //this.lblLoginName.Text = OficinaVirtualUserProfile.GetUserProfile(user).NombreSolicitante;
                var profile = OficinaVirtualUserProfile.GetUserProfile(user);
                //this.lblNombreUsuario.Text = profile.NombreSolicitante;
            }
        }

        ///<summary>
        /// Función que muestra un mensaje en el jBar
        ///</summary>
        ///<param name="message"></param>
        public void ShowMessageError(string message)
        {
            lblMessage.Text = message;
        }

        /// <summary>
        /// Función que esconde la navegación principal de la solución
        /// </summary>
        public void HideNavigation()
        {
            //this.pnlNavigation.Visible = false;
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
        
        /// <summary>
        /// Búsqueda en el portal de nobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (this.txtSearch.Text.Length <= 0) return;
            //var url = String.Format("{0}?s={1}", Helper.NoboxMainpage, this.txtSearch.Text);
            //Response.Redirect(url, true);
        }

        /// <summary>
        /// Redirección de un usuario a las aplicaciones de Nobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkRedirectNobox_Click(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return;

            var noboxPage = String.Empty;
            var lnk = (LinkButton) sender;
            switch (lnk.Text)
            {
                case "Inicio":
                    noboxPage = "apps/dashboard.php";
                    break;
                
                case "B2B en la Red":
                    noboxPage = "apps/inbox.php";
                    break;

                case "DigiFirma":
                    noboxPage = "apps/digifirma_solicitud_personal.php";
                    break;

                case "Resolución de Controversias":
                    noboxPage = "apps/digifirma_solicitud_servicios_crc.php";
                    break;

                case "Red Empresarial":
                    noboxPage = "apps/perfiles.php";
                    break;

                default:
                    noboxPage = "apps/dashboard.php";
                    break;
            }

            var redirectUrl = String.Format("{0}/{1}", Helper.NoboxMainpage, noboxPage);
            var user = HttpContext.Current.User.Identity.Name;
            var token = UsuariosController.AddAuthenticationToken(user, new Guid(Helper.NoboxApplicationKey));

            var url = String.Format("{0}?usr={1}&tkn={2}&url={3}", Helper.NoboxLogin, user, token, redirectUrl);
            Response.Redirect(url, true);
        }

    }
}