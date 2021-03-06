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
    /// Controller class for aspnet_Users
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AspnetUserController
    {
        // Preload our schema..
        AspnetUser thisSchemaLoad = new AspnetUser();
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
        public AspnetUserCollection FetchAll()
        {
            AspnetUserCollection coll = new AspnetUserCollection();
            Query qry = new Query(AspnetUser.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspnetUserCollection FetchByID(object UserId)
        {
            AspnetUserCollection coll = new AspnetUserCollection().Where("UserId", UserId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspnetUserCollection FetchByQuery(Query qry)
        {
            AspnetUserCollection coll = new AspnetUserCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserId)
        {
            return (AspnetUser.Delete(UserId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserId)
        {
            return (AspnetUser.Destroy(UserId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid ApplicationId,Guid UserId,string UserName,string LoweredUserName,string MobileAlias,bool IsAnonymous,DateTime LastActivityDate)
	    {
		    AspnetUser item = new AspnetUser();
		    
            item.ApplicationId = ApplicationId;
            
            item.UserId = UserId;
            
            item.UserName = UserName;
            
            item.LoweredUserName = LoweredUserName;
            
            item.MobileAlias = MobileAlias;
            
            item.IsAnonymous = IsAnonymous;
            
            item.LastActivityDate = LastActivityDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid ApplicationId,Guid UserId,string UserName,string LoweredUserName,string MobileAlias,bool IsAnonymous,DateTime LastActivityDate)
	    {
		    AspnetUser item = new AspnetUser();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ApplicationId = ApplicationId;
				
			item.UserId = UserId;
				
			item.UserName = UserName;
				
			item.LoweredUserName = LoweredUserName;
				
			item.MobileAlias = MobileAlias;
				
			item.IsAnonymous = IsAnonymous;
				
			item.LastActivityDate = LastActivityDate;
				
	        item.Save(UserName);
	    }
    }
}
