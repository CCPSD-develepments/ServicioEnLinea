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
    /// Controller class for UbicacionesExpedientes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UbicacionesExpedientesController
    {
        // Preload our schema..
        UbicacionesExpedientes thisSchemaLoad = new UbicacionesExpedientes();
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
        public UbicacionesExpedientesCollection FetchAll()
        {
            UbicacionesExpedientesCollection coll = new UbicacionesExpedientesCollection();
            Query qry = new Query(UbicacionesExpedientes.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UbicacionesExpedientesCollection FetchByID(object Id)
        {
            UbicacionesExpedientesCollection coll = new UbicacionesExpedientesCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UbicacionesExpedientesCollection FetchByQuery(Query qry)
        {
            UbicacionesExpedientesCollection coll = new UbicacionesExpedientesCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (UbicacionesExpedientes.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (UbicacionesExpedientes.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion)
	    {
		    UbicacionesExpedientes item = new UbicacionesExpedientes();
		    
            item.Descripcion = Descripcion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Descripcion)
	    {
		    UbicacionesExpedientes item = new UbicacionesExpedientes();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Descripcion = Descripcion;
				
	        item.Save(UserName);
	    }
    }
}
