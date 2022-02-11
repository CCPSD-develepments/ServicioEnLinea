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
    /// Controller class for TransaccionesDocumentosReglas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransaccionesDocumentosReglasController
    {
        // Preload our schema..
        TransaccionesDocumentosReglas thisSchemaLoad = new TransaccionesDocumentosReglas();
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
        public TransaccionesDocumentosReglasCollection FetchAll()
        {
            TransaccionesDocumentosReglasCollection coll = new TransaccionesDocumentosReglasCollection();
            Query qry = new Query(TransaccionesDocumentosReglas.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionesDocumentosReglasCollection FetchByID(object TransDocReglaId)
        {
            TransaccionesDocumentosReglasCollection coll = new TransaccionesDocumentosReglasCollection().Where("TransDocReglaId", TransDocReglaId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionesDocumentosReglasCollection FetchByQuery(Query qry)
        {
            TransaccionesDocumentosReglasCollection coll = new TransaccionesDocumentosReglasCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransDocReglaId)
        {
            return (TransaccionesDocumentosReglas.Delete(TransDocReglaId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransDocReglaId)
        {
            return (TransaccionesDocumentosReglas.Destroy(TransDocReglaId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int TransaccionId,int DocumentoId,int ReglaId,bool EsValida)
	    {
		    TransaccionesDocumentosReglas item = new TransaccionesDocumentosReglas();
		    
            item.TransaccionId = TransaccionId;
            
            item.DocumentoId = DocumentoId;
            
            item.ReglaId = ReglaId;
            
            item.EsValida = EsValida;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransDocReglaId,int TransaccionId,int DocumentoId,int ReglaId,bool EsValida)
	    {
		    TransaccionesDocumentosReglas item = new TransaccionesDocumentosReglas();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TransDocReglaId = TransDocReglaId;
				
			item.TransaccionId = TransaccionId;
				
			item.DocumentoId = DocumentoId;
				
			item.ReglaId = ReglaId;
				
			item.EsValida = EsValida;
				
	        item.Save(UserName);
	    }
    }
}
