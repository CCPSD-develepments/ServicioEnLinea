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
    /// Controller class for Cargos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CargosController
    {
        // Preload our schema..
        Cargos thisSchemaLoad = new Cargos();
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
        public CargosCollection FetchAll()
        {
            CargosCollection coll = new CargosCollection();
            Query qry = new Query(Cargos.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CargosCollection FetchByID(object CargoId)
        {
            CargosCollection coll = new CargosCollection().Where("CargoId", CargoId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CargosCollection FetchByQuery(Query qry)
        {
            CargosCollection coll = new CargosCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CargoId)
        {
            return (Cargos.Delete(CargoId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CargoId)
        {
            return (Cargos.Destroy(CargoId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,DateTime FechaModificacion,Guid Rowguid)
	    {
		    Cargos item = new Cargos();
		    
            item.Descripcion = Descripcion;
            
            item.FechaModificacion = FechaModificacion;
            
            item.Rowguid = Rowguid;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CargoId,string Descripcion,DateTime FechaModificacion,Guid Rowguid)
	    {
		    Cargos item = new Cargos();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CargoId = CargoId;
				
			item.Descripcion = Descripcion;
				
			item.FechaModificacion = FechaModificacion;
				
			item.Rowguid = Rowguid;
				
	        item.Save(UserName);
	    }
    }
}
