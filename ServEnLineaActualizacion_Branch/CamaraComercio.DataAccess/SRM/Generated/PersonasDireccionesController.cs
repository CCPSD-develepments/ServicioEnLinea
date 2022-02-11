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
    /// Controller class for PersonasDirecciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PersonasDireccionesController
    {
        // Preload our schema..
        PersonasDirecciones thisSchemaLoad = new PersonasDirecciones();
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
        public PersonasDireccionesCollection FetchAll()
        {
            PersonasDireccionesCollection coll = new PersonasDireccionesCollection();
            Query qry = new Query(PersonasDirecciones.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonasDireccionesCollection FetchByID(object Id)
        {
            PersonasDireccionesCollection coll = new PersonasDireccionesCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonasDireccionesCollection FetchByQuery(Query qry)
        {
            PersonasDireccionesCollection coll = new PersonasDireccionesCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PersonasDirecciones.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PersonasDirecciones.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int PersonaId,int DireccionId,DateTime FechaModificacion,Guid Rowguid)
	    {
		    PersonasDirecciones item = new PersonasDirecciones();
		    
            item.PersonaId = PersonaId;
            
            item.DireccionId = DireccionId;
            
            item.FechaModificacion = FechaModificacion;
            
            item.Rowguid = Rowguid;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int PersonaId,int DireccionId,DateTime FechaModificacion,Guid Rowguid)
	    {
		    PersonasDirecciones item = new PersonasDirecciones();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.PersonaId = PersonaId;
				
			item.DireccionId = DireccionId;
				
			item.FechaModificacion = FechaModificacion;
				
			item.Rowguid = Rowguid;
				
	        item.Save(UserName);
	    }
    }
}
