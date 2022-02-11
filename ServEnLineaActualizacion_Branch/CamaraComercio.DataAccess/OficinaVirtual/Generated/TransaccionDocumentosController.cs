using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace CamaraComercio.DataAccess.OficinaVirtual
{
    /// <summary>
    /// Controller class for TransaccionesDocumentos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransaccionDocumentosController
    {
        // Preload our schema..
        TransaccionDocumentos thisSchemaLoad = new TransaccionDocumentos();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TransaccionDocumentosCollection FetchAll()
        {
            TransaccionDocumentosCollection coll = new TransaccionDocumentosCollection();
            Query qry = new Query(TransaccionDocumentos.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionDocumentosCollection FetchByID(object TransaccionDocumentosId)
        {
            TransaccionDocumentosCollection coll = new TransaccionDocumentosCollection().Where("TransaccionesDocumentosId", TransaccionDocumentosId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionDocumentosCollection FetchByQuery(Query qry)
        {
            TransaccionDocumentosCollection coll = new TransaccionDocumentosCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransaccionDocumentosId)
        {
            return (TransaccionDocumentos.Delete(TransaccionDocumentosId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransaccionDocumentosId)
        {
            return (TransaccionDocumentos.Destroy(TransaccionDocumentosId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int TransaccionId,int? TipoDocumentoId,string Nombre,string Descripcion,string NombreArchivo,DateTime? FechaEnvio,string Usuario)
	    {
		    TransaccionDocumentos item = new TransaccionDocumentos();
		    
            item.TransaccionId = TransaccionId;
            
            item.TipoDocumentoId = TipoDocumentoId;
            
            item.Nombre = Nombre;
            
            item.Descripcion = Descripcion;
            
            item.NombreArchivo = NombreArchivo;
            
            item.FechaEnvio = FechaEnvio;
            
            item.Usuario = Usuario;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransaccionDocumentosId,int TransaccionId,int? TipoDocumentoId,string Nombre,string Descripcion,string NombreArchivo,DateTime? FechaEnvio,string Usuario)
	    {
		    TransaccionDocumentos item = new TransaccionDocumentos();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TransaccionDocumentosId = TransaccionDocumentosId;
				
			item.TransaccionId = TransaccionId;
				
			item.TipoDocumentoId = TipoDocumentoId;
				
			item.Nombre = Nombre;
				
			item.Descripcion = Descripcion;
				
			item.NombreArchivo = NombreArchivo;
				
			item.FechaEnvio = FechaEnvio;
				
			item.Usuario = Usuario;
				
	        item.Save(UserName);
	    }
    }
}
