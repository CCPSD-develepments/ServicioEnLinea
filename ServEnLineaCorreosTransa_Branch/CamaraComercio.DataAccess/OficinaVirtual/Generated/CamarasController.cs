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
    /// Controller class for Camaras
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CamarasController
    {
        // Preload our schema..
        Camaras thisSchemaLoad = new Camaras();
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
        public CamarasCollection FetchAll()
        {
            CamarasCollection coll = new CamarasCollection();
            Query qry = new Query(Camaras.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CamarasCollection FetchByID(object Id)
        {
            CamarasCollection coll = new CamarasCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CamarasCollection FetchByQuery(Query qry)
        {
            CamarasCollection coll = new CamarasCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Camaras.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Camaras.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Id,string Nombre,decimal? GestionID,string Rnc,bool? Activa)
	    {
		    Camaras item = new Camaras();
		    
            item.Id = Id;
            
            item.Nombre = Nombre;
            
            item.GestionID = GestionID;
            
            item.Rnc = Rnc;
            
            item.Activa = Activa;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Id,string Nombre,decimal? GestionID,string Rnc,bool? Activa)
	    {
		    Camaras item = new Camaras();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
			item.GestionID = GestionID;
				
			item.Rnc = Rnc;
				
			item.Activa = Activa;
				
	        item.Save(UserName);
	    }
    }
}
