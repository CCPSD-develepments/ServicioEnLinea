using System;
using System.Web;
using System.IO;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Empresas
{
    /// <summary>
    /// HTTP Handler que facilita la subida de documentos desde el plugin de jQuery Uploadify
    /// </summary>
    public class MyUpload : IHttpHandler
    {
        /// <summary>
        /// Procesa el Request del envio de archivos
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var file = context.Request.Files["Filedata"];
            var idusuario = context.Request["id"];
            var solicitud = Convert.ToInt32(context.Request["sid"]);
            var sguid = Guid.NewGuid();

            var reader = new BinaryReader(file.InputStream);
            var filebytes = reader.ReadBytes(file.ContentLength);

            var status = OFV.TransaccionDocumentosController.savedocuments(solicitud, file.FileName, DateTime.Now, idusuario, sguid, filebytes,file.ContentType);

            context.Response.Write(status ? "1" : "0");
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MyUpload.IsReusable'
        public bool IsReusable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MyUpload.IsReusable'
        {
            get
            {
                return false;
            }
        }
    }
}