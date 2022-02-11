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
    /// Controller class for Transacciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransaccionesController
    {
        // Preload our schema..
        Transacciones thisSchemaLoad = new Transacciones();
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
        public TransaccionesCollection FetchAll()
        {
            TransaccionesCollection coll = new TransaccionesCollection();
            Query qry = new Query(Transacciones.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionesCollection FetchByID(object TransaccionId)
        {
            TransaccionesCollection coll = new TransaccionesCollection().Where("TransaccionId", TransaccionId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransaccionesCollection FetchByQuery(Query qry)
        {
            TransaccionesCollection coll = new TransaccionesCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransaccionId)
        {
            return (Transacciones.Delete(TransaccionId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransaccionId)
        {
            return (Transacciones.Destroy(TransaccionId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime Fecha,int TipoTransaccionId,int TipoServicioId,string Salicitante,string RNCSolicitante,string NombreContacto,string TelefonoContacto,string FaxContacto,string NoReciboDGII,DateTime? FechaReciboDGII,decimal? MontoDGII,string DestinoTraslado,string Comentario,string ComentarioHtml,Guid? FlowId,int Estatus,int? Estatus2,string Prioridad,string CustomString1,string CustomString2,string CustomString3,int? CustomInt1,int? CustomInt2,int? CustomInt3,DateTime? CustomDateTime1,DateTime? CustomDateTime2,decimal? CustomDecimal1,decimal? CustomDecimal2,DateTime? FechaModificacion,Guid? Rowguid,int? Tipo,string Ncf,int? UsuarioId,DateTime? HoraInicio,DateTime? HoraFinal,string Receptor,string TipoNcf,int? UbicacionExpedienteId,string UbicacionExterna,string TipoServicio,string Servicio,string TipoServicioSufijo)
	    {
		    Transacciones item = new Transacciones();
		    
            item.Fecha = Fecha;
            
            item.TipoTransaccionId = TipoTransaccionId;
            
            item.TipoServicioId = TipoServicioId;
            
            item.Salicitante = Salicitante;
            
            item.RNCSolicitante = RNCSolicitante;
            
            item.NombreContacto = NombreContacto;
            
            item.TelefonoContacto = TelefonoContacto;
            
            item.FaxContacto = FaxContacto;
            
            item.NoReciboDGII = NoReciboDGII;
            
            item.FechaReciboDGII = FechaReciboDGII;
            
            item.MontoDGII = MontoDGII;
            
            item.DestinoTraslado = DestinoTraslado;
            
            item.Comentario = Comentario;
            
            item.ComentarioHtml = ComentarioHtml;
            
            item.FlowId = FlowId;
            
            item.Estatus = Estatus;
            
            item.Estatus2 = Estatus2;
            
            item.Prioridad = Prioridad;
            
            item.CustomString1 = CustomString1;
            
            item.CustomString2 = CustomString2;
            
            item.CustomString3 = CustomString3;
            
            item.CustomInt1 = CustomInt1;
            
            item.CustomInt2 = CustomInt2;
            
            item.CustomInt3 = CustomInt3;
            
            item.CustomDateTime1 = CustomDateTime1;
            
            item.CustomDateTime2 = CustomDateTime2;
            
            item.CustomDecimal1 = CustomDecimal1;
            
            item.CustomDecimal2 = CustomDecimal2;
            
            item.FechaModificacion = FechaModificacion;
            
            item.Rowguid = Rowguid;
            
            item.Tipo = Tipo;
            
            item.Ncf = Ncf;
            
            item.UsuarioId = UsuarioId;
            
            item.HoraInicio = HoraInicio;
            
            item.HoraFinal = HoraFinal;
            
            item.Receptor = Receptor;
            
            item.TipoNcf = TipoNcf;
            
            item.UbicacionExpedienteId = UbicacionExpedienteId;
            
            item.UbicacionExterna = UbicacionExterna;
            
            item.TipoServicio = TipoServicio;
            
            item.Servicio = Servicio;
            
            item.TipoServicioSufijo = TipoServicioSufijo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransaccionId,DateTime Fecha,int TipoTransaccionId,int TipoServicioId,string Salicitante,string RNCSolicitante,string NombreContacto,string TelefonoContacto,string FaxContacto,string NoReciboDGII,DateTime? FechaReciboDGII,decimal? MontoDGII,string DestinoTraslado,string Comentario,string ComentarioHtml,Guid? FlowId,int Estatus,int? Estatus2,string Prioridad,string CustomString1,string CustomString2,string CustomString3,int? CustomInt1,int? CustomInt2,int? CustomInt3,DateTime? CustomDateTime1,DateTime? CustomDateTime2,decimal? CustomDecimal1,decimal? CustomDecimal2,DateTime? FechaModificacion,Guid? Rowguid,int? Tipo,string Ncf,int? UsuarioId,DateTime? HoraInicio,DateTime? HoraFinal,string Receptor,string TipoNcf,int? UbicacionExpedienteId,string UbicacionExterna,string TipoServicio,string Servicio,string TipoServicioSufijo)
	    {
		    Transacciones item = new Transacciones();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TransaccionId = TransaccionId;
				
			item.Fecha = Fecha;
				
			item.TipoTransaccionId = TipoTransaccionId;
				
			item.TipoServicioId = TipoServicioId;
				
			item.Salicitante = Salicitante;
				
			item.RNCSolicitante = RNCSolicitante;
				
			item.NombreContacto = NombreContacto;
				
			item.TelefonoContacto = TelefonoContacto;
				
			item.FaxContacto = FaxContacto;
				
			item.NoReciboDGII = NoReciboDGII;
				
			item.FechaReciboDGII = FechaReciboDGII;
				
			item.MontoDGII = MontoDGII;
				
			item.DestinoTraslado = DestinoTraslado;
				
			item.Comentario = Comentario;
				
			item.ComentarioHtml = ComentarioHtml;
				
			item.FlowId = FlowId;
				
			item.Estatus = Estatus;
				
			item.Estatus2 = Estatus2;
				
			item.Prioridad = Prioridad;
				
			item.CustomString1 = CustomString1;
				
			item.CustomString2 = CustomString2;
				
			item.CustomString3 = CustomString3;
				
			item.CustomInt1 = CustomInt1;
				
			item.CustomInt2 = CustomInt2;
				
			item.CustomInt3 = CustomInt3;
				
			item.CustomDateTime1 = CustomDateTime1;
				
			item.CustomDateTime2 = CustomDateTime2;
				
			item.CustomDecimal1 = CustomDecimal1;
				
			item.CustomDecimal2 = CustomDecimal2;
				
			item.FechaModificacion = FechaModificacion;
				
			item.Rowguid = Rowguid;
				
			item.Tipo = Tipo;
				
			item.Ncf = Ncf;
				
			item.UsuarioId = UsuarioId;
				
			item.HoraInicio = HoraInicio;
				
			item.HoraFinal = HoraFinal;
				
			item.Receptor = Receptor;
				
			item.TipoNcf = TipoNcf;
				
			item.UbicacionExpedienteId = UbicacionExpedienteId;
				
			item.UbicacionExterna = UbicacionExterna;
				
			item.TipoServicio = TipoServicio;
				
			item.Servicio = Servicio;
				
			item.TipoServicioSufijo = TipoServicioSufijo;
				
	        item.Save(UserName);
	    }
    }
}
