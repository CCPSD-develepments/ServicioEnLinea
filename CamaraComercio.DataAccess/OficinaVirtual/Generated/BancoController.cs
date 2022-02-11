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
    /// Controller class for Bancos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BancoController
    {
        // Preload our schema..
        Banco thisSchemaLoad = new Banco();
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
        public BancoCollection FetchAll()
        {
            BancoCollection coll = new BancoCollection();
            Query qry = new Query(Banco.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BancoCollection FetchByID(object BancoId)
        {
            BancoCollection coll = new BancoCollection().Where("BancoId", BancoId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BancoCollection FetchByQuery(Query qry)
        {
            BancoCollection coll = new BancoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object BancoId)
        {
            return (Banco.Delete(BancoId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object BancoId)
        {
            return (Banco.Destroy(BancoId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,int? Orden,DateTime FechaModificacion)
	    {
		    Banco item = new Banco();
		    
            item.Descripcion = Descripcion;
            
            item.Orden = Orden;
            
            item.FechaModificacion = FechaModificacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int BancoId,string Descripcion,int? Orden,DateTime FechaModificacion)
	    {
		    Banco item = new Banco();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.BancoId = BancoId;
				
			item.Descripcion = Descripcion;
				
			item.Orden = Orden;
				
			item.FechaModificacion = FechaModificacion;
				
	        item.Save(UserName);
	    }
    }
}
