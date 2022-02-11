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
    /// Controller class for Transacciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransaccionController
    {
        // Preload our schema..
        Transaccion thisSchemaLoad = new Transaccion();
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
        public TransaccionCollection FetchAll()
        {
            TransaccionCollection coll = new TransaccionCollection();
            Query qry = new Query(Transaccion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionCollection FetchByID(object TransaccionId)
        {
            TransaccionCollection coll = new TransaccionCollection().Where("TransaccionId", TransaccionId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionCollection FetchByQuery(Query qry)
        {
            TransaccionCollection coll = new TransaccionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransaccionId)
        {
            return (Transaccion.Delete(TransaccionId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransaccionId)
        {
            return (Transaccion.Destroy(TransaccionId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime Fecha,string Solicitante,string RNCSolicitante,string NombreContacto,string TelefonoContacto,string FaxContacto,string NoReciboDGII,DateTime? FechaReciboDGII,decimal? MontoDGII,string DestinoTraslado,string NombreSocialPersona,string ApellidoPersona,int TipoSociedadId,int? NumeroRegistro,DateTime? FechaAsamblea,decimal? CapitalSocial,decimal? ModificacionCapital,int RegistroId,bool? BLoadedInSRM,int ServicioId,string CamaraId,Guid UserId,int? Tipo,string Ncf,string TipoNcf)
	    {
		    Transaccion item = new Transaccion();
		    
            item.Fecha = Fecha;
            
            item.Solicitante = Solicitante;
            
            item.RNCSolicitante = RNCSolicitante;
            
            item.NombreContacto = NombreContacto;
            
            item.TelefonoContacto = TelefonoContacto;
            
            item.FaxContacto = FaxContacto;
            
            item.NoReciboDGII = NoReciboDGII;
            
            item.FechaReciboDGII = FechaReciboDGII;
            
            item.MontoDGII = MontoDGII;
            
            item.DestinoTraslado = DestinoTraslado;
            
            item.NombreSocialPersona = NombreSocialPersona;
            
            item.ApellidoPersona = ApellidoPersona;
            
            item.TipoSociedadId = TipoSociedadId;
            
            item.NumeroRegistro = NumeroRegistro;
            
            item.FechaAsamblea = FechaAsamblea;
            
            item.CapitalSocial = CapitalSocial;
            
            item.ModificacionCapital = ModificacionCapital;
            
            item.RegistroId = RegistroId;
            
            item.BLoadedInSRM = BLoadedInSRM;
            
            item.ServicioId = ServicioId;
            
            item.CamaraId = CamaraId;
            
            item.UserId = UserId;
            
            item.Tipo = Tipo;
            
            item.Ncf = Ncf;
            
            item.TipoNcf = TipoNcf;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransaccionId,DateTime Fecha,string Solicitante,string RNCSolicitante,string NombreContacto,string TelefonoContacto,string FaxContacto,string NoReciboDGII,DateTime? FechaReciboDGII,decimal? MontoDGII,string DestinoTraslado,string NombreSocialPersona,string ApellidoPersona,int TipoSociedadId,int? NumeroRegistro,DateTime? FechaAsamblea,decimal? CapitalSocial,decimal? ModificacionCapital,int RegistroId,bool? BLoadedInSRM,int ServicioId,string CamaraId,Guid UserId,int? Tipo,string Ncf,string TipoNcf)
	    {
		    Transaccion item = new Transaccion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TransaccionId = TransaccionId;
				
			item.Fecha = Fecha;
				
			item.Solicitante = Solicitante;
				
			item.RNCSolicitante = RNCSolicitante;
				
			item.NombreContacto = NombreContacto;
				
			item.TelefonoContacto = TelefonoContacto;
				
			item.FaxContacto = FaxContacto;
				
			item.NoReciboDGII = NoReciboDGII;
				
			item.FechaReciboDGII = FechaReciboDGII;
				
			item.MontoDGII = MontoDGII;
				
			item.DestinoTraslado = DestinoTraslado;
				
			item.NombreSocialPersona = NombreSocialPersona;
				
			item.ApellidoPersona = ApellidoPersona;
				
			item.TipoSociedadId = TipoSociedadId;
				
			item.NumeroRegistro = NumeroRegistro;
				
			item.FechaAsamblea = FechaAsamblea;
				
			item.CapitalSocial = CapitalSocial;
				
			item.ModificacionCapital = ModificacionCapital;
				
			item.RegistroId = RegistroId;
				
			item.BLoadedInSRM = BLoadedInSRM;
				
			item.ServicioId = ServicioId;
				
			item.CamaraId = CamaraId;
				
			item.UserId = UserId;
				
			item.Tipo = Tipo;
				
			item.Ncf = Ncf;
				
			item.TipoNcf = TipoNcf;
				
	        item.Save(UserName);
	    }
    }
}
