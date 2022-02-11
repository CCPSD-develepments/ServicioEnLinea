using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de documentos en transacciones
    /// </summary>
    [DataObject]
    public class DocumentosTransaccionesRepository: Repository<DocumentosTransacciones, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraId">ID de la Cámara</param>
        public DocumentosTransaccionesRepository(String camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {}

        public DocumentosTransaccionesRepository(CamaraSRMEntities context) : base(context) { }


        /// <summary>
        /// Obtiene todos los documentos que han sido depositados por una empresa
        /// </summary>
        /// <param name="noRegistro">Número de Registro</param>
        /// <param name="camaraID">ID de la Cámara</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IEnumerable<DocumentoTransaccionOfv> GetDocumentosByNoRegistro(int noRegistro, string camaraID = null)
        {
            //Instanciando los objetos del Entity Framework para acceso a Datos
            var db = !String.IsNullOrEmpty(camaraID) 
                ? CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID) 
                : this.Session;
            if (this.Session == null && String.IsNullOrEmpty(camaraID)) return null;
            
            var dbComun = new Comun.CamaraComunEntities();
            
            //Transacciones del usuario
            var trans = db.Transacciones.Where(t => t.CustomInt2 == noRegistro)
                .OrderByDescending(t => t.Fecha).Select(c => c.TransaccionId)
                .ToList();
            
            //Documentos relacionados a esas transacciones
            var docs = (from d in db.DocumentosTransacciones
                       where trans.Contains(d.TransaccionId)
                       orderby d.FechaDocumento
                       select d).AsEnumerable();

            //Coleccion de nombres de los documentos (se hace de esta forma porque está en otro contexto de base de datos)
            var docIds = docs.Select(d => d.DocumentoId).ToList().Distinct();
            var tiposDocs = (from td in dbComun.TipoDocumento
                            where docIds.Contains(td.TipoDocumentoId)
                            select td).ToList();

            //Coleccion a retornar
            var docsConDescr = from d in docs
                               join td in tiposDocs on d.DocumentoId equals td.TipoDocumentoId
                               select new DocumentoTransaccionOfv
                                          {
                                              DocumentoID = d.DocumentoId,
                                              DocumentoTransaccionID = d.DocumentoTransaccionId,
                                              FechaDocumento = d.FechaDocumento,
                                              FechaModificacion = d.FechaModificacion,
                                              NombreDocumento = td.Nombre,
                                              CostoCopia = td.CostoCopia,
                                              CostoOriginal = td.CostoOriginal
                                          };
            return docsConDescr;
        }

        /// <summary>
        /// Obtiene todos los documentos que han sido depositados por una empresa
        /// </summary>
        /// <param name="noRegistro">Número de registro</param>
        /// <param name="camaraID">ID de la Cámara</param>
        /// <returns>Retorna un DataTable con la estructura de DocumentoTransaccionOfv</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetDocumentosByNoRegistroDt(int noRegistro, string camaraID)
        {
            var docs = GetDocumentosByNoRegistro(noRegistro, camaraID);
            return docs.ToDataTable();
        }

        /// <summary>
        /// Clase DTO que representa un Documento asociado a una transaccion
        /// </summary>
        public class DocumentoTransaccionOfv
        {
            /// <summary>
            /// ID del tipo de documento
            /// </summary>
            public int DocumentoID { get; set; }
            
            /// <summary>
            /// ID identificador (key)
            /// </summary>
            public int DocumentoTransaccionID { get; set; }
            
            /// <summary>
            /// Fecha de última modificación
            /// </summary>
            public DateTime? FechaModificacion { get; set; }
            
            /// <summary>
            /// Fecha del documento (de su creación, no del depósito en la cámara)
            /// </summary>
            public DateTime? FechaDocumento { get; set; }
            
            /// <summary>
            /// Descripción del tipo de documento
            /// </summary>
            public string NombreDocumento { get; set; }
            
            /// <summary>
            /// Costo de depósito de un original
            /// </summary>
            public Decimal CostoOriginal { get; set; }
            
            /// <summary>
            /// Costo de depósito de una copia
            /// </summary>
            public Decimal CostoCopia { get; set; }
        }
    }
}
