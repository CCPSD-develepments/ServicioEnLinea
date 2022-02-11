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
    /// Controller class for TiposTransacciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TiposTransaccionesController
    {
        // Preload our schema..
        TiposTransacciones thisSchemaLoad = new TiposTransacciones();
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
        public TiposTransaccionesCollection FetchAll()
        {
            TiposTransaccionesCollection coll = new TiposTransaccionesCollection();
            Query qry = new Query(TiposTransacciones.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TiposTransaccionesCollection FetchByID(object TipoTransaccionId)
        {
            TiposTransaccionesCollection coll = new TiposTransaccionesCollection().Where("TipoTransaccionId", TipoTransaccionId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TiposTransaccionesCollection FetchByQuery(Query qry)
        {
            TiposTransaccionesCollection coll = new TiposTransaccionesCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TipoTransaccionId)
        {
            return (TiposTransacciones.Delete(TipoTransaccionId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TipoTransaccionId)
        {
            return (TiposTransacciones.Destroy(TipoTransaccionId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Descripcion,string Sufijo,int? Libro,int? Folio,int? NoDocumento,DateTime FechaModificacion,Guid Rowguid,int? TipoIdentificador)
	    {
		    TiposTransacciones item = new TiposTransacciones();
		    
            item.Descripcion = Descripcion;
            
            item.Sufijo = Sufijo;
            
            item.Libro = Libro;
            
            item.Folio = Folio;
            
            item.NoDocumento = NoDocumento;
            
            item.FechaModificacion = FechaModificacion;
            
            item.Rowguid = Rowguid;
            
            item.TipoIdentificador = TipoIdentificador;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TipoTransaccionId,string Descripcion,string Sufijo,int? Libro,int? Folio,int? NoDocumento,DateTime FechaModificacion,Guid Rowguid,int? TipoIdentificador)
	    {
		    TiposTransacciones item = new TiposTransacciones();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TipoTransaccionId = TipoTransaccionId;
				
			item.Descripcion = Descripcion;
				
			item.Sufijo = Sufijo;
				
			item.Libro = Libro;
				
			item.Folio = Folio;
				
			item.NoDocumento = NoDocumento;
				
			item.FechaModificacion = FechaModificacion;
				
			item.Rowguid = Rowguid;
				
			item.TipoIdentificador = TipoIdentificador;
				
	        item.Save(UserName);
	    }
    }
}
