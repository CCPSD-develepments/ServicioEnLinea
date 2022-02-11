using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CamaraComercio.Website
{
    /// <summary>
    /// Clase utilizada para representar una página bajo el esquema de seguridad del Membership Provider
    /// </summary>
    /// <remarks>
    /// Encapsula la mayoría de las propiedades del usuario de Membership, facilitando su acceso desde code-behind
    /// </remarks>
    public class SecurePage : Page
    {
        #region Propiedades

        /// <summary>
        /// Usuario Logueado en la applicacion.
        /// </summary>
        private MembershipUser _currentuser;
        /// <summary>
        /// Flag que indica si ya he cargado el usuario anteriormente para evitar busquedas repetidas.
        /// </summary>
        private bool _bLoaded;

        /// <summary>
        /// Usuario logueado actualmente en el sistema.
        /// </summary>
        public MembershipUser CurrentUser
        {
            get
            {
                if (!_bLoaded)
                {
                    _currentuser = Membership.GetUser(User.Identity.Name);
                    _bLoaded = true;
                }
                return _currentuser;
            }
        }

        /// <summary>
        /// Mensaje de Error a mostrar en el jBar
        /// </summary>
        public String ErrorMessage
        {
            get
            {
                if (Session["ErrorMessage"] == null)
                    return String.Empty;

                return Session["ErrorMessage"].ToString();
            }
            set { Session["ErrorMessage"] = value; }
        }

        private String _defaultQueryString = String.Empty;

        /// <summary>
        /// Retorna el QueryString Seteado.
        /// </summary>
        public String DefaultQueryString
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

        #endregion

        #region Metodos

        /// <summary>
        /// Validacion de la empresa actual. Para saber si desea adecuarse o realizar un nuevo registro
        /// </summary>
        /// <param name="personaId"></param>
        /// <param name="bAdecuada"></param>
        /// <param name="FechaVencimiento"></param>
        /// <param name="FechaVencimientoCal"></param>
        protected void ValidateEmpresa(int personaId, bool? bAdecuada, DateTime? FechaVencimiento, DateTime? FechaVencimientoCal = null)
        {
            var qryt = string.Empty;
            int tipoSociedadId;
            int.TryParse(Request.QueryString["TipoSociedadId"], out tipoSociedadId);
            if (tipoSociedadId != 0 && tipoSociedadId != 7)
            {
                if (FechaVencimiento.HasValue)
                    FechaVencimientoCal = FechaVencimiento;

                //if ((!bAdecuada.HasValue || !bAdecuada.Value) && DateTime.Today >= new DateTime(2011, 09, 01))
                //    Response.Redirect("/Empresas/Adecuacion.aspx" + DefaultQueryString);

                //  var dateSpan = DateTimeSpan.CompareDates(compareTo, now);


               // var resulktadomes =  Convert.ToDateTime(FechaVencimientoCal.Value - DateTime.Now.Date).Month;

                //var ResultadoMesRenovacion = ((FechaVencimientoCal.Value.Year - DateTime.Now.Year) * 12) + FechaVencimientoCal.Value.Month - DateTime.Now.Month; 




                if (FechaVencimientoCal.HasValue && FechaVencimientoCal.Value < DateTime.Today)
                {
                    Session["labelregistrovencido"] = "Su Registro Mercantil está vencido";
                    Response.Redirect("/Empresas/Renovacion.aspx" + DefaultQueryString);
                }



            }
            else
            {
                if (FechaVencimiento.HasValue)
                    FechaVencimientoCal = FechaVencimiento;


                var ResultadoMesRenovacion = ((FechaVencimientoCal.Value.Year - DateTime.Now.Year) * 12) + FechaVencimientoCal.Value.Month - DateTime.Now.Month;



                if (personaId != 0)
                {
                    if (!DefaultQueryString.Contains("PersonaId="))
                        qryt = DefaultQueryString += "&PersonaId="+personaId;
                    else
                    {
                        qryt = DefaultQueryString;
                    }
                    
                }

                if (FechaVencimientoCal.HasValue && FechaVencimientoCal.Value < DateTime.Today)
                {
                    Session["labelregistrovencido"] = "Su Registro Mercantil está vencido";
                    Response.Redirect("/Empresas/Renovacion.aspx" + qryt);
                }

           

            }
           
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para representar una página bajo el esquema de seguridad del Membership Provider
    /// </summary>
    /// <remarks>
    /// Encapsula la mayoría de las propiedades del usuario de Membership, facilitando su acceso desde code-behind
    /// </remarks>
    public class SecureUserControl : UserControl
    {
        #region Propiedades
        /// <summary>
        /// Usuario Logueado en la applicacion.
        /// </summary>
        private MembershipUser _currentuser;

        /// <summary>
        /// Flag que indica si ya he cargado el usuario anteriormente para evitar busquedas repetidas.
        /// </summary>
        private bool _bLoaded;

        /// <summary>
        /// Usuario logueado actualmente en el sistema.
        /// </summary>
        public MembershipUser CurrentUser
        {
            get
            {
                if (!_bLoaded)
                {
                    _currentuser = Membership.GetUser(this.Page.User.Identity.Name);
                    _bLoaded = true;
                }
                return _currentuser;
            }
        }

        /// <summary>
        /// Mensaje de Error a mostrar en el jBar
        /// </summary>
        public String ErrorMessage
        {
            get
            {
                if (Session["ErrorMessage"] == null)
                    return String.Empty;

                return Session["ErrorMessage"].ToString();
            }
            set { Session["ErrorMessage"] = value; }
        }

        /// <summary>
        /// Página segura actual.
        /// </summary>
        public SecurePage SecurePage
        {
            get
            {
                return this.Page as SecurePage;
            }
        }

        /// <summary>
        /// La página master de la actual.
        /// </summary>
        public CamaraComercio.Website.res.nobox Master
        {
            get
            {
                return (this.SecurePage.Master as CamaraComercio.Website.res.nobox);
            }
        }
        
        /// <summary>
        /// Retorna el QueryString Seteado.
        /// </summary>
        public String DefaultQueryString
        {
            get
            {
                return SecurePage.DefaultQueryString;
            }
            set
            {
                SecurePage.DefaultQueryString = value;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Validacion de la empresa actual. Para saber si desea adecuarse o realizar un nuevo registro
        /// </summary>
        /// <param name="bAdecuada"></param>
        /// <param name="FechaVencimiento"></param>
        /// <param name="FechaVencimientoCal"></param>
        protected void ValidateEmpresa(bool? bAdecuada, DateTime? FechaVencimiento, DateTime? FechaVencimientoCal = null)
        {
            if (FechaVencimiento.HasValue)
                FechaVencimientoCal = FechaVencimiento;

            //if ((!bAdecuada.HasValue || !bAdecuada.Value) && DateTime.Today >= new DateTime(2011, 09, 01))
            //    Response.Redirect("/Empresas/Adecuacion.aspx" + DefaultQueryString);

            if (FechaVencimientoCal.HasValue && FechaVencimientoCal.Value < DateTime.Today)
                Response.Redirect("/Empresas/Renovacion.aspx" + DefaultQueryString);
        }
        #endregion

    }
}