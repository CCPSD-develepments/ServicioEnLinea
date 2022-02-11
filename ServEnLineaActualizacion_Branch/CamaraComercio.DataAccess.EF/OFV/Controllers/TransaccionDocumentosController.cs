using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Controlador de documentos por transacción
    /// </summary>
    [DataObject]
    public class TransaccionDocumentosController
    {
        /// <summary>
        /// Retorna el listado de los Documentos Enviados
        /// </summary>
        /// <param name="_transaccionID">ID de la Transaccion</param>
        /// <param name="pagInicio">Parametro de paginación: página de inicio</param>
        /// <param name="pagTamano">Parametro de paginación: tamaño de cada página</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IQueryable<TransaccionesDocumentos> DocumentosEnviados(int? _transaccionID, int pagInicio = 0, int pagTamano = 15)
        {
            var db = new CamaraWebsiteEntities();
            var qry = from td in db.TransaccionesDocumentos
                      where td.TransaccionId == _transaccionID
                      select td;
            return qry;
        }

        /// <summary>
        /// Guardado de un documento en la base de datos
        /// </summary>
        /// <param name="_solicitud">ID de la solicitud</param>
        /// <param name="_descripcion">Descripcion del documento</param>
        /// <param name="_fecha">Fecha de registro</param>
        /// <param name="_idusuario">ID del usuario que realiza la solicitud</param>
        /// <param name="_filename">Nombre del archivo</param>
        /// <param name="archivo">Data binaria</param>
        /// <param name="contentType">Tipo del contenido (extensión del archivo)</param>
        /// <returns></returns>
        public static bool savedocuments(int _solicitud, string _descripcion, DateTime _fecha, string _idusuario, Guid _filename, byte[] archivo, string contentType)
        {
            try
            {
                using (var db = new CamaraWebsiteEntities())
                {
                    var tipoDocId =
                        new CamaraComun.CamaraComunEntities().TipoDocumento.FirstOrDefault(a => a.Nombre == "OTROS");

                    var d = new TransaccionesDocumentos
                                {
                                    TransaccionId = _solicitud,
                                    Descripcion = _descripcion,
                                    FechaEnvio = _fecha,
                                    Nombre = _descripcion,
                                    NombreArchivo = _filename.ToString(),
                                    Usuario = _idusuario,
                                    TipoDocumentoId = tipoDocId != null ? tipoDocId.TipoDocumentoId : (int?)null,
                                    RowId = _filename,
                                    DocContent = archivo,
                                    DocContentType = contentType,
                                    FirmaDigital= false
                                };
                    db.TransaccionesDocumentos.AddObject(d);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Actualiza los documentos registrados con una transaccion cuando son enviados
        /// </summary>
        /// <param name="TransaccionesDocumentosId"></param>
        /// <param name="Descripcion"></param>
        /// <param name="FechaEnvio"></param>
        /// <param name="nombre"></param>
        /// <param name="firmaDigital"></param>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void UpdateDocumentosEnviados(int TransaccionesDocumentosId, string Descripcion, DateTime FechaEnvio, string nombre, bool firmaDigital = false)
        {
            using (var db = new CamaraWebsiteEntities())
            {
                var d = db.TransaccionesDocumentos.First(c => c.TransaccionesDocumentosId == TransaccionesDocumentosId);
                d.Descripcion = Descripcion;
                d.FechaEnvio = FechaEnvio;
                d.Nombre = nombre;
                d.FirmaDigital = firmaDigital;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Actualiza los documentos registrados con una transaccion cuando son enviados
        /// </summary>
        /// <param name="TransaccionesDocumentosId"></param>
        /// <param name="Descripcion"></param>
        /// <param name="tipoDocumentoId"></param>
        /// <param name="firmaDigital"></param>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void UpdateDocumentosEnviados(int TransaccionesDocumentosId, string Descripcion, int tipoDocumentoId, bool firmaDigital = false)
        {
            using (var db = new CamaraWebsiteEntities())
            {
                var d = db.TransaccionesDocumentos.First(c => c.TransaccionesDocumentosId == TransaccionesDocumentosId);
                d.Descripcion = Descripcion;
                d.TipoDocumentoId = tipoDocumentoId;
                d.FirmaDigital = firmaDigital;
                db.SaveChanges();

            }

        }

        /// <summary>
        /// Borra los documentos asociados a una transaccion de la base de datos
        /// </summary>
        /// <remarks>
        /// Documento marcado como deprecado/obsoleto. Nunca se borrarán documentos en la aplicación
        /// </remarks>
        /// <param name="TransaccionesDocumentosId"></param>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteDocumentosEnviados(int TransaccionesDocumentosId)
        {
            using (var db = new CamaraWebsiteEntities())
            {
                var d = db.TransaccionesDocumentos.First(c => c.TransaccionesDocumentosId == TransaccionesDocumentosId);
                db.TransaccionesDocumentos.DeleteObject(d);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Borra los documentos asociados a una transaccion de la base de datos
        /// </summary>
        /// <remarks>
        /// Documento marcado como deprecado/obsoleto. Nunca se borrarán documentos en la aplicación
        /// </remarks>
        /// <param name="transactionId"></param>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public List<TransaccionDocSeleccionado> GetDocumentosSeleccionados(int transactionId)
        {
            using (var db = new CamaraWebsiteEntities())
                return db.TransaccionDocSeleccionado.Where(a => a.TransaccionId == transactionId).ToList();
        }
    }
}
