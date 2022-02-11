using System;
using System.Data.Objects;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using MSH = CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.DataAccess.EF.Membership;
using System.Collections.Generic;
using System.Configuration;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Servicio Web que expone las clases de envío de mensajes
    /// en la Oficina Virtual
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Mensajeria : WebService
    {
        /// <summary>
        /// Metodo generico para insertar mesaje utilizado por los metodos facades de cada tipo de mensaje.
        /// </summary>
        /// <param name="tipoMensaje">Enum que especifica el tipo de mensaje</param>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="contenido">Body del mensaje</param>
        /// <param name="usuario">Usuario al que va dirigido el mensaje</param>
        /// <param name="usuarioSistema">Usuario del sistema RM que genera el mensaje</param>
        /// <param name="camaraId">Id que identifica la camara donde se encuentra registrada la sociedad</param>
        /// <param name="sociedadId">Id de la empresa/sociedad</param>
        /// <param name="transaccionId">Id de la transaccion</param>
        /// <returns>Retorna un bool indicando si el mensaje fue enviado por correo satisfactoriamente.</returns>
        private static bool CrearMensaje(TipoMensaje tipoMensaje, string titulo, string contenido, string usuario, string usuarioSistema, string camaraId, int? sociedadId, int? transaccionId)
        {
            var mensaje = new Mensajes
            {
                
                FechaEnvio = DateTime.Now,
                TipoMensaje = Convert.ToInt32(tipoMensaje),
                Titulo = titulo,                
                Mensaje = contenido,
                Usuario = usuario,
                UsuarioSistema = usuarioSistema,
                UsuarioPadre = MSH.UsuariosController.GetUsuarioPadreByUsername(usuario), //TODO: Nando: Agregar el campo usuario padre
                CamaraId = camaraId,
                SociedadID = sociedadId,                
                TransaccionId = transaccionId
            };


            var db = new CamaraWebsiteEntities();
            db.Mensajes.AddObject(mensaje);
            db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                      
            //buscar el nombre completo del usuario.
            var user = UsuariosController.GetInfoUsuarioByUserName(usuario);

            var fromEmail = ConfigurationManager.AppSettings["FromCorreoCamara"];
            var urlPortal = ConfigurationManager.AppSettings["UrlPortal"];
            
            var parametros = new Dictionary<string, string>
                                 {
                                     {"[NombreCompleto]", user.NombreSolicitante},
                                     {"[Titulo]", titulo},
                                     {"[Mensaje]", contenido},
                                     {"[Fecha]", Convert.ToDateTime(mensaje.FechaEnvio)
                                         .ToString("dd MMM yyyy, hh:mm:ss tt")},
                                     {"[UrlOficina]", String.Format("{0}/Empresas/Oficina.aspx", urlPortal)}
                                 };

            var messageSent = true;

            try
            {
                MailBot.MailBot.SendMail(user.Email, null, null, fromEmail, "MOV", 
                    Helper.MailServer, 1, parametros); 
            }
            catch (Exception ex)
            {
                messageSent = false;
            }
            
            return messageSent;
        }

        /// <summary>
        /// Genera un nuevo mensaje para el usuario especificado
        /// </summary>
        /// <param name="usuario">Usuario al que le llegará este mensaje</param>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="contenido">Contenido del mensaje</param>
        /// <param name="usuarioSistema">Opcional: Usuario del sistema que envía el mensaje</param>
        /// <returns>Retorna un bool si el mensaje puso ser enviado por correo.</returns>
        [WebMethod(Description = "Crea un nuevo mensaje para el usuario especificado")]
        public bool CrearMensajeParaUsuario(string titulo, string contenido, string usuario, string usuarioSistema)
        {
            return CrearMensaje(TipoMensaje.Usuario, titulo, contenido, usuario, usuarioSistema, null, null, null);
            
        }

        /// <summary>
        /// Crea un nuevo mensaje para la empresa especificada
        /// </summary>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="contenido">Contenido del mensaje</param>
        /// <param name="noRegistro">No. del Registro Mercantil</param>
        /// <param name="camaraID">Camara en la que esta registrado el usuario</param>
        /// <param name="usuarioSistema">Opcional: Usuario del sistema que envía el mensaje</param>
        /// <returns>Retorna un bool si el mensaje puso ser enviado por correo.</returns>
        [WebMethod(Description = "Crea un nuevo mensaje para la empresa especificada")]
        public bool CrearMensajeParaEmpresa(string titulo, string contenido, int noRegistro, string camaraID, string usuarioSistema)
        {
            //Este es el mismo caso que el método anterior, la única diferencia es que el servicio/
            //busca automaticamente el usuario actual asociado con el RNC y envia el mensaje 
            var ctrlEmpresasUsr = new EmpresasPorUsuarioController();
            var ctrlSociedades = new SRM.SociedadesController();
            var usuario = ctrlEmpresasUsr.FetchEmpresaOwnerName(noRegistro, camaraID);
            var sociedadID = ctrlSociedades.GetSociedadIdByRegistro(noRegistro, camaraID);

            
            if (usuario != null)
            {
                return sociedadID > 0 
                    ? CrearMensaje(TipoMensaje.Empresa, titulo, contenido, usuario, usuarioSistema, camaraID, sociedadID, null)
                    : CrearMensaje(TipoMensaje.Empresa, titulo, contenido, usuario, usuarioSistema, null, null, null);
            }
            
            return false;
        }

        /// <summary>
        /// Crea un nuevo mensaje asociado a una trasaccion.
        /// </summary>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="contenido">Contenido del Mensaje</param>
        /// <param name="usuario">Usuario el que va destinado el mensaje</param>
        /// <param name="usuarioSistema">Usuario del sistema que emite el mensaje</param>
        /// <param name="transaccionId">Id que asocia el mensaje a una transaccion especifica</param>
        /// <returns>Retorna un bool si el mensaje puso ser enviado por correo.</returns>
        [WebMethod(Description = "Crea un nuevo mensaje para un trámite en específico")]
        public bool CrearMensajeParaTramite(string titulo, string contenido, string usuario, string usuarioSistema, int transaccionId)
        {
            //Invoca Crear mensaje genericoy le pasa los parametros necesarios.
            return CrearMensaje(TipoMensaje.Trámite, titulo, contenido, usuario, usuarioSistema, null, null, transaccionId);
        }

        //[WebMethod(Description = "Crea un nuevo mensaje de correo")]
        //public void EnviarMensajeCorreo(string to, string cc, string bcc, string from, string templateCode, 
        //    string host, int sourceID, Dictionary<string, string> parameters)
        //{
        //    MailBot.MailBot.SendMail(to, cc, bcc, from, templateCode, Helper.MailServer, 1, parameters);
        //}
    }
}
