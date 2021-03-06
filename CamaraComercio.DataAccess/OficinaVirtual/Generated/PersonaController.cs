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
    /// Controller class for Personas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PersonaController
    {
        // Preload our schema..
        Persona thisSchemaLoad = new Persona();
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
        public PersonaCollection FetchAll()
        {
            PersonaCollection coll = new PersonaCollection();
            Query qry = new Query(Persona.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonaCollection FetchByID(object PersonaId)
        {
            PersonaCollection coll = new PersonaCollection().Where("PersonaId", PersonaId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonaCollection FetchByQuery(Query qry)
        {
            PersonaCollection coll = new PersonaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PersonaId)
        {
            return (Persona.Delete(PersonaId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PersonaId)
        {
            return (Persona.Destroy(PersonaId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int RegistroId,string TipoDocumento,string Documento,string PrimerNombre,string SegundoNombre,string PrimerApellido,string SegundoApellido,string Rnc,int? NacionalidadId,string EstadoCivil,int? ProfesionId,int? DireccionId)
	    {
		    Persona item = new Persona();
		    
            item.RegistroId = RegistroId;
            
            item.TipoDocumento = TipoDocumento;
            
            item.Documento = Documento;
            
            item.PrimerNombre = PrimerNombre;
            
            item.SegundoNombre = SegundoNombre;
            
            item.PrimerApellido = PrimerApellido;
            
            item.SegundoApellido = SegundoApellido;
            
            item.Rnc = Rnc;
            
            item.NacionalidadId = NacionalidadId;
            
            item.EstadoCivil = EstadoCivil;
            
            item.ProfesionId = ProfesionId;
            
            item.DireccionId = DireccionId;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PersonaId,int RegistroId,string TipoDocumento,string Documento,string PrimerNombre,string SegundoNombre,string PrimerApellido,string SegundoApellido,string Rnc,int? NacionalidadId,string EstadoCivil,int? ProfesionId,int? DireccionId)
	    {
		    Persona item = new Persona();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PersonaId = PersonaId;
				
			item.RegistroId = RegistroId;
				
			item.TipoDocumento = TipoDocumento;
				
			item.Documento = Documento;
				
			item.PrimerNombre = PrimerNombre;
				
			item.SegundoNombre = SegundoNombre;
				
			item.PrimerApellido = PrimerApellido;
				
			item.SegundoApellido = SegundoApellido;
				
			item.Rnc = Rnc;
				
			item.NacionalidadId = NacionalidadId;
				
			item.EstadoCivil = EstadoCivil;
				
			item.ProfesionId = ProfesionId;
				
			item.DireccionId = DireccionId;
				
	        item.Save(UserName);
	    }
    }
}
