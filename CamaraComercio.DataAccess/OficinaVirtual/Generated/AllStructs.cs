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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string Banco = @"Bancos";
        
		public static readonly string Camaras = @"Camaras";
        
		public static readonly string Cargo = @"Cargos";
        
		public static readonly string CategoriaSocio = @"CategoriasSocios";
        
		public static readonly string Ciudad = @"Ciudades";
        
		public static readonly string DataFormDefinition = @"DataFormDefinition";
        
		public static readonly string DataFormInstance = @"DataFormInstance";
        
		public static readonly string DiasFeriados = @"DiasFeriados";
        
		public static readonly string Direccion = @"Direcciones";
        
		public static readonly string EmpresasPorUsuario = @"EmpresasPorUsuario";
        
		public static readonly string Mensajes = @"Mensajes";
        
		public static readonly string Pais = @"Paises";
        
		public static readonly string Persona = @"Personas";
        
		public static readonly string Producto = @"Productos";
        
		public static readonly string Profesion = @"Profesiones";
        
		public static readonly string ReferenciaBancaria = @"ReferenciasBancarias";
        
		public static readonly string ReferenciaComercial = @"ReferenciasComerciales";
        
		public static readonly string RegistroActual = @"RegistroActual";
        
		public static readonly string Registro = @"Registros";
        
		public static readonly string RegistroActividades = @"RegistrosActividades";
        
		public static readonly string RegistroActividadesEspecificas = @"RegistrosActividadesEspecificas";
        
		public static readonly string Sector = @"Sectores";
        
		public static readonly string ServicioDetalles = @"ServicioDetalles";
        
		public static readonly string ServiciosEnCamara = @"ServiciosEnCamara";
        
		public static readonly string SistemaArmonizado = @"SistemasArmonizados";
        
		public static readonly string Sociedad = @"Sociedades";
        
		public static readonly string Socio = @"Socios";
        
		public static readonly string Sucursal = @"Sucursales";
        
		public static readonly string Tarifa = @"Tarifas";
        
		public static readonly string TipoActividad = @"TiposActividades";
        
		public static readonly string TipoActividadEspecificas = @"TiposActividadesEspecificas";
        
		public static readonly string TipoEnteRegulado = @"TiposEnteRegulado";
        
		public static readonly string TipoServicioDetalles = @"TipoServicioDetalles";
        
		public static readonly string Transaccion = @"Transacciones";
        
		public static readonly string TransaccionDocumentos = @"TransaccionesDocumentos";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table Banco
		{
            get { return DataService.GetSchema("Bancos", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Camaras
		{
            get { return DataService.GetSchema("Camaras", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Cargo
		{
            get { return DataService.GetSchema("Cargos", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table CategoriaSocio
		{
            get { return DataService.GetSchema("CategoriasSocios", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Ciudad
		{
            get { return DataService.GetSchema("Ciudades", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table DataFormDefinition
		{
            get { return DataService.GetSchema("DataFormDefinition", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table DataFormInstance
		{
            get { return DataService.GetSchema("DataFormInstance", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table DiasFeriados
		{
            get { return DataService.GetSchema("DiasFeriados", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Direccion
		{
            get { return DataService.GetSchema("Direcciones", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table EmpresasPorUsuario
		{
            get { return DataService.GetSchema("EmpresasPorUsuario", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Mensajes
		{
            get { return DataService.GetSchema("Mensajes", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Pais
		{
            get { return DataService.GetSchema("Paises", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Persona
		{
            get { return DataService.GetSchema("Personas", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Producto
		{
            get { return DataService.GetSchema("Productos", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Profesion
		{
            get { return DataService.GetSchema("Profesiones", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table ReferenciaBancaria
		{
            get { return DataService.GetSchema("ReferenciasBancarias", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table ReferenciaComercial
		{
            get { return DataService.GetSchema("ReferenciasComerciales", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table RegistroActual
		{
            get { return DataService.GetSchema("RegistroActual", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Registro
		{
            get { return DataService.GetSchema("Registros", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table RegistroActividades
		{
            get { return DataService.GetSchema("RegistrosActividades", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table RegistroActividadesEspecificas
		{
            get { return DataService.GetSchema("RegistrosActividadesEspecificas", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Sector
		{
            get { return DataService.GetSchema("Sectores", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table ServicioDetalles
		{
            get { return DataService.GetSchema("ServicioDetalles", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table ServiciosEnCamara
		{
            get { return DataService.GetSchema("ServiciosEnCamara", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table SistemaArmonizado
		{
            get { return DataService.GetSchema("SistemasArmonizados", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Sociedad
		{
            get { return DataService.GetSchema("Sociedades", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Socio
		{
            get { return DataService.GetSchema("Socios", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Sucursal
		{
            get { return DataService.GetSchema("Sucursales", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Tarifa
		{
            get { return DataService.GetSchema("Tarifas", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table TipoActividad
		{
            get { return DataService.GetSchema("TiposActividades", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table TipoActividadEspecificas
		{
            get { return DataService.GetSchema("TiposActividadesEspecificas", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table TipoEnteRegulado
		{
            get { return DataService.GetSchema("TiposEnteRegulado", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table TipoServicioDetalles
		{
            get { return DataService.GetSchema("TipoServicioDetalles", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table Transaccion
		{
            get { return DataService.GetSchema("Transacciones", "OficinaVirtualProvider"); }
		}
        
		public static TableSchema.Table TransaccionDocumentos
		{
            get { return DataService.GetSchema("TransaccionesDocumentos", "OficinaVirtualProvider"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["OficinaVirtualProvider"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static readonly string OficinaVirtualProvider = @"OficinaVirtualProvider";
    
}
#endregion