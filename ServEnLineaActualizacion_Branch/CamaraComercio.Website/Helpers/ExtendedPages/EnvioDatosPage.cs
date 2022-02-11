using System;
using System.Collections.Generic;
using CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage'
    public class EnvioDatosPage : SecurePage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage'
    {
        /// <summary>
        /// IDs de transacciones a las que se asocian los documentos
        /// </summary>
        public int IdTransaciones
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["nSolicitud"]) ? int.Parse(Request.QueryString["nSolicitud"]) : 0; }
            set { DefaultQueryString = String.Format("nSolicitud={0}", value); }
        }

        /// <summary>
        /// Contiene el Id de la Camara.
        /// </summary>
        protected String CamaraId
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? Request.QueryString["CamaraId"] : String.Empty; }
            set { DefaultQueryString = String.Format("CamaraId={0}", value); }
        }

        /// <summary>
        /// Documentos seleccionados
        /// </summary>
        public List<ServicioDocumentoRequerido> DocumentosSeleccionados
        {
            get
            {
                if (Session["DocumentosSeleccionados"] == null)
                    Session["DocumentosSeleccionados"] = new List<ServicioDocumentoRequerido>();

                return (List<ServicioDocumentoRequerido>)Session["DocumentosSeleccionados"];
            }
            set
            {
                Session["DocumentosSeleccionados"] = value;
                if (value == null)
                    Session.Remove("DocumentosSeleccionados");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage.DocumentosAgregados'
        public List<ServicioDocumentoRequerido> DocumentosAgregados
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage.DocumentosAgregados'
        {
            get
            {
                if (Session["DocumentosAgregados"] == null)
                    Session["DocumentosAgregados"] = new List<ServicioDocumentoRequerido>();

                return (List<ServicioDocumentoRequerido>)Session["DocumentosAgregados"];
            }
            set
            {
                Session["DocumentosAgregados"] = value;
                if (value == null)
                    Session.Remove("DocumentosAgregados");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage.CopiasCertificadas'
        public List<OFV.TransaccionCopiasCertificadas> CopiasCertificadas 
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage.CopiasCertificadas'
        {
            get
            {
                if (Session["CopiasCertificadas"] == null)
                    Session["CopiasCertificadas"] = new List<OFV.TransaccionCopiasCertificadas>();

                return (List<OFV.TransaccionCopiasCertificadas>)Session["CopiasCertificadas"];
            }
            set
            {
                Session["CopiasCertificadas"] = value;
                if (value == null)
                    Session.Remove("CopiasCertificadas");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage.FormaEntrega'
        public string FormaEntrega
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosPage.FormaEntrega'
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["FormaEntrega"]) ? Request.QueryString["FormaEntrega"] : String.Empty; }
            set { DefaultQueryString = String.Format("FormaEntrega={0}", value); }
        }

        /// <summary>
        /// Obtiene el ID del tipo de sociedad a partir del QueryString
        /// </summary>
        public int TipoSociedadID
        {
            get
            {
                var id = 0;
                var query = Request.QueryString["TipoSociedadId"];
                
                if (!String.IsNullOrWhiteSpace(query))
                    Int32.TryParse(query, out id);

                return id;
            }
        }

        /// <summary>
        /// Limpia los objetos en sesion
        /// </summary>
        protected void LimpiarObjetosSession()
        {
            DocumentosSeleccionados = null;
            DocumentosAgregados = null;
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl'
    public abstract class EnvioDatosUserControl : SecureUserControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl'
    {
        /// <summary>
        /// IDs de transacciones a las que se asocian los documentos
        /// </summary>
        public int IdTransaciones
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["nSolicitud"]) ? int.Parse(Request.QueryString["nSolicitud"]) : 0; }
            set { DefaultQueryString = String.Format("nSolicitud={0}", value); }
        }

        /// <summary>
        /// Contiene el Id de la Camara.
        /// </summary>
        protected String CamaraId
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? Request.QueryString["CamaraId"] : String.Empty; }
            set { DefaultQueryString = String.Format("CamaraId={0}", value); }
        }

        /// <summary>
        /// Documentos seleccionados
        /// </summary>
        public List<ServicioDocumentoRequerido> DocumentosSeleccionados
        {
            get
            {
                if (Session["DocumentosSeleccionados"] == null)
                    Session["DocumentosSeleccionados"] = new List<ServicioDocumentoRequerido>();

                return (List<ServicioDocumentoRequerido>)Session["DocumentosSeleccionados"];
            }
            set
            {
                Session["DocumentosSeleccionados"] = value;
                if (value == null)
                    Session.Remove("DocumentosSeleccionados");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.DocumentosAgregados'
        public List<ServicioDocumentoRequerido> DocumentosAgregados
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.DocumentosAgregados'
        {
            get
            {
                if (Session["DocumentosAgregados"] == null)
                    Session["DocumentosAgregados"] = new List<ServicioDocumentoRequerido>();

                return (List<ServicioDocumentoRequerido>)Session["DocumentosAgregados"];
            }
            set
            {
                Session["DocumentosAgregados"] = value;
                if (value == null)
                    Session.Remove("DocumentosAgregados");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.CopiasCertificadas'
        public List<OFV.TransaccionCopiasCertificadas> CopiasCertificadas
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.CopiasCertificadas'
        {
            get
            {
                if (Session["CopiasCertificadas"] == null)
                    Session["CopiasCertificadas"] = new List<OFV.TransaccionCopiasCertificadas>();

                return (List<OFV.TransaccionCopiasCertificadas>)Session["CopiasCertificadas"];
            }
            set
            {
                Session["CopiasCertificadas"] = value;
                if (value == null)
                    Session.Remove("CopiasCertificadas");
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.FormaEntrega'
        public string FormaEntrega
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.FormaEntrega'
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["FormaEntrega"]) ? Request.QueryString["FormaEntrega"] : String.Empty; }
            set { DefaultQueryString = String.Format("FormaEntrega={0}", value); }
        }

        /// <summary>
        /// Obtiene el ID del tipo de sociedad a partir del QueryString
        /// </summary>
        public int TipoSociedadID
        {
            get
            {
                var id = 0;
                var query = Request.QueryString["TipoSociedadId"];

                if (!String.IsNullOrWhiteSpace(query))
                    Int32.TryParse(query, out id);

                return id;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.ControlLoad(List<KeyValuePair<string, string>>)'
        public abstract void ControlLoad(List<KeyValuePair<string, string>> args);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.ControlLoad(List<KeyValuePair<string, string>>)'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.ValidateNext()'
        public abstract bool ValidateNext();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.ValidateNext()'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.ValidateBack()'
        public virtual bool ValidateBack()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatosUserControl.ValidateBack()'
        {
            return true;
        }
    }
}