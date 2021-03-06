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
namespace CamaraComercio.DataAccess.SRM
{
    /// <summary>
    /// Controller class for HistoricosDocumentos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class HistoricosDocumentosController
    {
        // Preload our schema..
        HistoricosDocumentos thisSchemaLoad = new HistoricosDocumentos();
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
        public HistoricosDocumentosCollection FetchAll()
        {
            HistoricosDocumentosCollection coll = new HistoricosDocumentosCollection();
            Query qry = new Query(HistoricosDocumentos.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public HistoricosDocumentosCollection FetchByID(object Id)
        {
            HistoricosDocumentosCollection coll = new HistoricosDocumentosCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public HistoricosDocumentosCollection FetchByQuery(Query qry)
        {
            HistoricosDocumentosCollection coll = new HistoricosDocumentosCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (HistoricosDocumentos.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (HistoricosDocumentos.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int RegistroId,int DocumentoId,DateTime? FechaDocumento,int? NoDocumento,int? Libro,int? Folio,int NoExpediente,string Documento)
	    {
		    HistoricosDocumentos item = new HistoricosDocumentos();
		    
            item.RegistroId = RegistroId;
            
            item.DocumentoId = DocumentoId;
            
            item.FechaDocumento = FechaDocumento;
            
            item.NoDocumento = NoDocumento;
            
            item.Libro = Libro;
            
            item.Folio = Folio;
            
            item.NoExpediente = NoExpediente;
            
            item.Documento = Documento;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int RegistroId,int DocumentoId,DateTime? FechaDocumento,int? NoDocumento,int? Libro,int? Folio,int NoExpediente,string Documento)
	    {
		    HistoricosDocumentos item = new HistoricosDocumentos();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.RegistroId = RegistroId;
				
			item.DocumentoId = DocumentoId;
				
			item.FechaDocumento = FechaDocumento;
				
			item.NoDocumento = NoDocumento;
				
			item.Libro = Libro;
				
			item.Folio = Folio;
				
			item.NoExpediente = NoExpediente;
				
			item.Documento = Documento;
				
	        item.Save(UserName);
	    }
    }
}
