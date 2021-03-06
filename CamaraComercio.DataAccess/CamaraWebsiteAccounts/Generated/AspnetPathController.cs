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
namespace CamaraComercio.DataAccess.CamaraWebsiteAccounts
{
    /// <summary>
    /// Controller class for aspnet_Paths
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AspnetPathController
    {
        // Preload our schema..
        AspnetPath thisSchemaLoad = new AspnetPath();
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
        public AspnetPathCollection FetchAll()
        {
            AspnetPathCollection coll = new AspnetPathCollection();
            Query qry = new Query(AspnetPath.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspnetPathCollection FetchByID(object PathId)
        {
            AspnetPathCollection coll = new AspnetPathCollection().Where("PathId", PathId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspnetPathCollection FetchByQuery(Query qry)
        {
            AspnetPathCollection coll = new AspnetPathCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PathId)
        {
            return (AspnetPath.Delete(PathId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PathId)
        {
            return (AspnetPath.Destroy(PathId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid ApplicationId,Guid PathId,string Path,string LoweredPath)
	    {
		    AspnetPath item = new AspnetPath();
		    
            item.ApplicationId = ApplicationId;
            
            item.PathId = PathId;
            
            item.Path = Path;
            
            item.LoweredPath = LoweredPath;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid ApplicationId,Guid PathId,string Path,string LoweredPath)
	    {
		    AspnetPath item = new AspnetPath();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ApplicationId = ApplicationId;
				
			item.PathId = PathId;
				
			item.Path = Path;
				
			item.LoweredPath = LoweredPath;
				
	        item.Save(UserName);
	    }
    }
}
