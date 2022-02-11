using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using CamaraComercio.DataAccess.EF;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Modal que muestra un mensaje enviado a un usuario del portal
    ///</summary>
    public partial class VerMensaje : Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerMensaje.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerMensaje.Page_Load(object, EventArgs)'
        {
            var msgIdStr = Request.Params["msgId"] ?? string.Empty;
            int id;
            if (Int32.TryParse(msgIdStr, out id))
            {
                var dbOfv = new OFV.CamaraWebsiteEntities();
                var ctrlMensajes = new Repository<OFV.Mensajes, OFV.CamaraWebsiteEntities>(dbOfv);
                
                var mensaje = ctrlMensajes.SelectByKey(id);
                if (mensaje != null)
                {
                    //Despliegue del mensaje
                    //lblEnviadoPor.Text = mensaje.UsuarioSistema;
                    lblEnviadoPor.Text = "Camara De Comercio";
                    lblFecha.Text = mensaje.FechaEnvio.HasValue
                                        ? mensaje.FechaEnvio.Value.ToString("dd MMM yyyy", new CultureInfo("es-PR"))
                                        : String.Empty;
                    lblMensaje.Text = mensaje.Mensaje;
                    if (mensaje.SociedadID.HasValue && mensaje.SociedadID > 0)
                    {
                        //Quiere decir que el mensaje está relacionado con una sociedad y no es un mensaje genérico/general
                        
                        var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(mensaje.CamaraId); 
                        var sociedad = dbSrm.Sociedades.Where(a => a.SociedadId == mensaje.SociedadID).FirstOrDefault();

                        if (sociedad != null)
                        {
                            var nombreSocial = sociedad.NombreSocial;
                            lblMensajeTitulo.Text = String.Format("{0} - {1}", nombreSocial, mensaje.Titulo);
                        }
                    }
                    else
                    {
                        lblMensajeTitulo.Text = mensaje.Titulo;
                    }

                    //Marcado del mensaje como leido por primera vez
                    if (!mensaje.FechaLectura.HasValue && mensaje.Usuario == User.Identity.Name) //se agrego la segunda condicion para que solo se marquen leidos los que te corresponden.
                    {
                        mensaje.FechaLectura = DateTime.Now;
                        ctrlMensajes.Save();
                    }

                    //Despliegue del mensaje
                    mvMensajes.SetActiveView(vMensaje);
                }
                else
                {
                    mvMensajes.SetActiveView(vError);
                    return;
                }
            }
            else
            {
                mvMensajes.SetActiveView(vError);
            }
        }
        /// <summary>
        /// Aqui mandamos un mensaje generico
        /// </summary>
        /// <param name="mensaje"></param>
        private void ShowCustomMessage(string mensaje) 
        {
            //Despliegue del mensaje
            lblMensajeTitulo.Text = "Informacion.";
            lblEnviadoPor.Text = "Camara Comercio Produccion";
            lblFecha.Text = DateTime.Now.ToString();

            lblMensaje.Text = mensaje;

            //Despliegue dla vista que muestra este tipo de mensaje
            mvMensajes.SetActiveView(vMensaje);
        }
    }
}