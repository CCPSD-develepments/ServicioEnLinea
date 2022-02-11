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
    /// Controller class for TiposReglasDocumentos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TiposReglasDocumentosController
    {
        // Preload our schema..
        TiposReglasDocumentos thisSchemaLoad = new TiposReglasDocumentos();
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
        public TiposReglasDocumentosCollection FetchAll()
        {
            TiposReglasDocumentosCollection coll = new TiposReglasDocumentosCollection();
            Query qry = new Query(TiposReglasDocumentos.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TiposReglasDocumentosCollection FetchByID(object TipoReglaDocumentoId)
        {
            TiposReglasDocumentosCollection coll = new TiposReglasDocumentosCollection().Where("TipoReglaDocumentoId", TipoReglaDocumentoId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TiposReglasDocumentosCollection FetchByQuery(Query qry)
        {
            TiposReglasDocumentosCollection coll = new TiposReglasDocumentosCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TipoReglaDocumentoId)
        {
            return (TiposReglasDocumentos.Delete(TipoReglaDocumentoId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TipoReglaDocumentoId)
        {
            return (TiposReglasDocumentos.Destroy(TipoReglaDocumentoId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    TiposReglasDocumentos item = new TiposReglasDocumentos();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TipoReglaDocumentoId,string Descripcion)
	    {
		    TiposReglasDocumentos item = new TiposReglasDocumentos();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TipoReglaDocumentoId = TipoReglaDocumentoId;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
