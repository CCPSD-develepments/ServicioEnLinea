using System;
using System.Drawing.Imaging;
using System.Web;
using System.Linq;
using System.Web.Security;
//using Neodynamic.WinControls.BarcodeProfessional;
using EF = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CodigoBarras'
    public class CodigoBarras
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CodigoBarras'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CodigoBarras.ObtenerCodigoBarras(string)'
        public static byte[] ObtenerCodigoBarras(string id)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CodigoBarras.ObtenerCodigoBarras(string)'
        {
            byte[] codigo = null;

            try
            {
                //BarcodeProfessional bcp = new BarcodeProfessional();
              //  bcp.Symbology = Symbology.Code128;
             //   bcp.Code = id;
              //  bcp.AntiAlias = true;
              //  bcp.DisplayCode = false;
               // BarcodeProfessional.LicenseOwner = "Amhed Herrera-Ultimate Edition-Developer License";
               // BarcodeProfessional.LicenseKey = "DQD5QGSZNNUV4ECPCTHDDQANVX9BR3EP83T4Q62TWZP4PN9JEZSA";
            
               // codigo = bcp.GetBarcodeImage(ImageFormat.Png);
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }

            return codigo;
        }
    }

    /// <summary>
    /// Handler que maneja la creacion del código de barras.
    /// </summary>
    public class GetBarCodeHandler : IHttpHandler
    {

        #region Private fields and properties

        private HttpContext _context;
        /// <summary>
        /// Usuario Logueado en la applicacion.
        /// </summary>
        private MembershipUser _currentuser;
        /// <summary>
        /// Flag que indica si ya he cargado el usuario anteriormente para evitar busquedas repetidas.
        /// </summary>
        private bool _bLoaded = false;

        /// <summary>
        /// Usuario logueado actualmente en el sistema.
        /// </summary>
        public MembershipUser CurrentUser
        {
            get
            {
                if (!_bLoaded)
                {
                    _currentuser = Membership.GetUser(_context.User.Identity.Name);
                    _bLoaded = true;
                }
                return _currentuser;
            }
        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'GetBarCodeHandler.ProcessRequest(HttpContext)'
        public void ProcessRequest(HttpContext context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'GetBarCodeHandler.ProcessRequest(HttpContext)'
        {
            //Asigno Context a Variable Local para Utilizar con propiedades u otros metodos que necesiten utilizarlo fuera de la clase.
            _context = context;

            if (!string.IsNullOrEmpty(context.Request.Params["id"]) && context.User.Identity.IsAuthenticated)
            {

                string strId = context.Request.Params["id"];

                //Valido Transacion pertener al usuario
                if (!ValidarTransaccion(strId))
                    return;

                //Generando Codigo de Barras
                byte[] objCodigo = CodigoBarras.ObtenerCodigoBarras(strId);

                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(objCodigo);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'GetBarCodeHandler.IsReusable'
        public bool IsReusable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'GetBarCodeHandler.IsReusable'
        {
            get { return false; }
        }

        #region Methods

#pragma warning disable CS1572 // XML comment has a param tag for 'id', but there is no parameter by that name
#pragma warning disable CS1573 // Parameter 'idStr' has no matching param tag in the XML comment for 'GetBarCodeHandler.ValidarTransaccion(string)' (but other parameters do)
        /// <summary>
        /// Valida que la transacción a visualizar pertenece al usuario que la solicita.
        /// </summary>
        /// <param name="id">Id De la transacción.</param>
        /// <returns>true si el usuario es el propietario de la transacion</returns>
        public bool ValidarTransaccion(String idStr)
#pragma warning restore CS1573 // Parameter 'idStr' has no matching param tag in the XML comment for 'GetBarCodeHandler.ValidarTransaccion(string)' (but other parameters do)
#pragma warning restore CS1572 // XML comment has a param tag for 'id', but there is no parameter by that name
        {
            if (CurrentUser == null)
                return false;

            var dbWebSite = new EF.CamaraWebsiteEntities();
            int id = 0;
            if (Int32.TryParse(idStr, out id))
            {
                var transaccion = dbWebSite.Transacciones.Where(a => a.TransaccionId == id);
                return transaccion.Count() > 0;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}