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
    /// Controller class for TiposNCF
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TiposNCFController
    {
        // Preload our schema..
        TiposNCF thisSchemaLoad = new TiposNCF();
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
        public TiposNCFCollection FetchAll()
        {
            TiposNCFCollection coll = new TiposNCFCollection();
            Query qry = new Query(TiposNCF.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TiposNCFCollection FetchByID(object TipoNcfId)
        {
            TiposNCFCollection coll = new TiposNCFCollection().Where("TipoNcfId", TipoNcfId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TiposNCFCollection FetchByQuery(Query qry)
        {
            TiposNCFCollection coll = new TiposNCFCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TipoNcfId)
        {
            return (TiposNCF.Delete(TipoNcfId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TipoNcfId)
        {
            return (TiposNCF.Destroy(TipoNcfId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,string Codigo,int Secuencia,int Desde,int Hasta,int ValorAviso,bool DefaultNcf)
	    {
		    TiposNCF item = new TiposNCF();
		    
            item.Descripcion = Descripcion;
            
            item.Codigo = Codigo;
            
            item.Secuencia = Secuencia;
            
            item.Desde = Desde;
            
            item.Hasta = Hasta;
            
            item.ValorAviso = ValorAviso;
            
            item.DefaultNcf = DefaultNcf;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TipoNcfId,string Descripcion,string Codigo,int Secuencia,int Desde,int Hasta,int ValorAviso,bool DefaultNcf)
	    {
		    TiposNCF item = new TiposNCF();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TipoNcfId = TipoNcfId;
				
			item.Descripcion = Descripcion;
				
			item.Codigo = Codigo;
				
			item.Secuencia = Secuencia;
				
			item.Desde = Desde;
				
			item.Hasta = Hasta;
				
			item.ValorAviso = ValorAviso;
				
			item.DefaultNcf = DefaultNcf;
				
	        item.Save(UserName);
	    }
    }
}
