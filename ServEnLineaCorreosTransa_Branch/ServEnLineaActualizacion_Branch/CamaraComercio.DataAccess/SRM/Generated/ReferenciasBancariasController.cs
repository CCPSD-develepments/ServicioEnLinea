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
    /// Controller class for ReferenciasBancarias
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ReferenciasBancariasController
    {
        // Preload our schema..
        ReferenciasBancarias thisSchemaLoad = new ReferenciasBancarias();
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
        public ReferenciasBancariasCollection FetchAll()
        {
            ReferenciasBancariasCollection coll = new ReferenciasBancariasCollection();
            Query qry = new Query(ReferenciasBancarias.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReferenciasBancariasCollection FetchByID(object ReferenciaBancariaId)
        {
            ReferenciasBancariasCollection coll = new ReferenciasBancariasCollection().Where("ReferenciaBancariaId", ReferenciaBancariaId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReferenciasBancariasCollection FetchByQuery(Query qry)
        {
            ReferenciasBancariasCollection coll = new ReferenciasBancariasCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ReferenciaBancariaId)
        {
            return (ReferenciasBancarias.Delete(ReferenciaBancariaId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ReferenciaBancariaId)
        {
            return (ReferenciasBancarias.Destroy(ReferenciaBancariaId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int RegistroId,int BancoId,DateTime FechaModificacion,Guid Rowguid)
	    {
		    ReferenciasBancarias item = new ReferenciasBancarias();
		    
            item.RegistroId = RegistroId;
            
            item.BancoId = BancoId;
            
            item.FechaModificacion = FechaModificacion;
            
            item.Rowguid = Rowguid;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ReferenciaBancariaId,int RegistroId,int BancoId,DateTime FechaModificacion,Guid Rowguid)
	    {
		    ReferenciasBancarias item = new ReferenciasBancarias();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ReferenciaBancariaId = ReferenciaBancariaId;
				
			item.RegistroId = RegistroId;
				
			item.BancoId = BancoId;
				
			item.FechaModificacion = FechaModificacion;
				
			item.Rowguid = Rowguid;
				
	        item.Save(UserName);
	    }
    }
}
