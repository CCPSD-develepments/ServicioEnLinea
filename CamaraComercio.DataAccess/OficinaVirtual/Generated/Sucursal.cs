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
	/// Strongly-typed collection for the Sucursal class.
	/// </summary>
    [Serializable]
	public partial class SucursalCollection : ActiveList<Sucursal, SucursalCollection>
	{	   
		public SucursalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SucursalCollection</returns>
		public SucursalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sucursal o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the Sucursales table.
	/// </summary>
	[Serializable]
	public partial class Sucursal : ActiveRecord<Sucursal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Sucursal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Sucursal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Sucursal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Sucursal(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Sucursales", TableType.Table, DataService.GetInstance("OficinaVirtualProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"WebSRM";
				//columns
				
				TableSchema.TableColumn colvarSucursalId = new TableSchema.TableColumn(schema);
				colvarSucursalId.ColumnName = "SucursalId";
				colvarSucursalId.DataType = DbType.Int32;
				colvarSucursalId.MaxLength = 0;
				colvarSucursalId.AutoIncrement = true;
				colvarSucursalId.IsNullable = false;
				colvarSucursalId.IsPrimaryKey = true;
				colvarSucursalId.IsForeignKey = false;
				colvarSucursalId.IsReadOnly = false;
				colvarSucursalId.DefaultSetting = @"";
				colvarSucursalId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSucursalId);
				
				TableSchema.TableColumn colvarSociedadId = new TableSchema.TableColumn(schema);
				colvarSociedadId.ColumnName = "SociedadId";
				colvarSociedadId.DataType = DbType.Int32;
				colvarSociedadId.MaxLength = 0;
				colvarSociedadId.AutoIncrement = false;
				colvarSociedadId.IsNullable = false;
				colvarSociedadId.IsPrimaryKey = false;
				colvarSociedadId.IsForeignKey = true;
				colvarSociedadId.IsReadOnly = false;
				colvarSociedadId.DefaultSetting = @"";
				
					colvarSociedadId.ForeignKeyTableName = "Sociedades";
				schema.Columns.Add(colvarSociedadId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 150;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarDireccionId = new TableSchema.TableColumn(schema);
				colvarDireccionId.ColumnName = "DireccionId";
				colvarDireccionId.DataType = DbType.Int32;
				colvarDireccionId.MaxLength = 0;
				colvarDireccionId.AutoIncrement = false;
				colvarDireccionId.IsNullable = true;
				colvarDireccionId.IsPrimaryKey = false;
				colvarDireccionId.IsForeignKey = false;
				colvarDireccionId.IsReadOnly = false;
				colvarDireccionId.DefaultSetting = @"";
				colvarDireccionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionId);
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "FechaModificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = false;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				
						colvarFechaModificacion.DefaultSetting = @"(getdate())";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				TableSchema.TableColumn colvarDireccionCalle = new TableSchema.TableColumn(schema);
				colvarDireccionCalle.ColumnName = "DireccionCalle";
				colvarDireccionCalle.DataType = DbType.String;
				colvarDireccionCalle.MaxLength = 256;
				colvarDireccionCalle.AutoIncrement = false;
				colvarDireccionCalle.IsNullable = true;
				colvarDireccionCalle.IsPrimaryKey = false;
				colvarDireccionCalle.IsForeignKey = false;
				colvarDireccionCalle.IsReadOnly = false;
				colvarDireccionCalle.DefaultSetting = @"";
				colvarDireccionCalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionCalle);
				
				TableSchema.TableColumn colvarDireccionNumero = new TableSchema.TableColumn(schema);
				colvarDireccionNumero.ColumnName = "DireccionNumero";
				colvarDireccionNumero.DataType = DbType.String;
				colvarDireccionNumero.MaxLength = 6;
				colvarDireccionNumero.AutoIncrement = false;
				colvarDireccionNumero.IsNullable = true;
				colvarDireccionNumero.IsPrimaryKey = false;
				colvarDireccionNumero.IsForeignKey = false;
				colvarDireccionNumero.IsReadOnly = false;
				colvarDireccionNumero.DefaultSetting = @"";
				colvarDireccionNumero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionNumero);
				
				TableSchema.TableColumn colvarDireccionCiudadId = new TableSchema.TableColumn(schema);
				colvarDireccionCiudadId.ColumnName = "DireccionCiudadId";
				colvarDireccionCiudadId.DataType = DbType.Int32;
				colvarDireccionCiudadId.MaxLength = 0;
				colvarDireccionCiudadId.AutoIncrement = false;
				colvarDireccionCiudadId.IsNullable = true;
				colvarDireccionCiudadId.IsPrimaryKey = false;
				colvarDireccionCiudadId.IsForeignKey = false;
				colvarDireccionCiudadId.IsReadOnly = false;
				colvarDireccionCiudadId.DefaultSetting = @"";
				colvarDireccionCiudadId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionCiudadId);
				
				TableSchema.TableColumn colvarDireccionSectorId = new TableSchema.TableColumn(schema);
				colvarDireccionSectorId.ColumnName = "DireccionSectorId";
				colvarDireccionSectorId.DataType = DbType.Int32;
				colvarDireccionSectorId.MaxLength = 0;
				colvarDireccionSectorId.AutoIncrement = false;
				colvarDireccionSectorId.IsNullable = true;
				colvarDireccionSectorId.IsPrimaryKey = false;
				colvarDireccionSectorId.IsForeignKey = false;
				colvarDireccionSectorId.IsReadOnly = false;
				colvarDireccionSectorId.DefaultSetting = @"";
				colvarDireccionSectorId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionSectorId);
				
				TableSchema.TableColumn colvarDireccionApartadoPostal = new TableSchema.TableColumn(schema);
				colvarDireccionApartadoPostal.ColumnName = "DireccionApartadoPostal";
				colvarDireccionApartadoPostal.DataType = DbType.String;
				colvarDireccionApartadoPostal.MaxLength = 20;
				colvarDireccionApartadoPostal.AutoIncrement = false;
				colvarDireccionApartadoPostal.IsNullable = true;
				colvarDireccionApartadoPostal.IsPrimaryKey = false;
				colvarDireccionApartadoPostal.IsForeignKey = false;
				colvarDireccionApartadoPostal.IsReadOnly = false;
				colvarDireccionApartadoPostal.DefaultSetting = @"";
				colvarDireccionApartadoPostal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionApartadoPostal);
				
				TableSchema.TableColumn colvarDireccionTelefonoCasa = new TableSchema.TableColumn(schema);
				colvarDireccionTelefonoCasa.ColumnName = "DireccionTelefonoCasa";
				colvarDireccionTelefonoCasa.DataType = DbType.String;
				colvarDireccionTelefonoCasa.MaxLength = 15;
				colvarDireccionTelefonoCasa.AutoIncrement = false;
				colvarDireccionTelefonoCasa.IsNullable = true;
				colvarDireccionTelefonoCasa.IsPrimaryKey = false;
				colvarDireccionTelefonoCasa.IsForeignKey = false;
				colvarDireccionTelefonoCasa.IsReadOnly = false;
				colvarDireccionTelefonoCasa.DefaultSetting = @"";
				colvarDireccionTelefonoCasa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionTelefonoCasa);
				
				TableSchema.TableColumn colvarDireccionTelefonoOficina = new TableSchema.TableColumn(schema);
				colvarDireccionTelefonoOficina.ColumnName = "DireccionTelefonoOficina";
				colvarDireccionTelefonoOficina.DataType = DbType.String;
				colvarDireccionTelefonoOficina.MaxLength = 15;
				colvarDireccionTelefonoOficina.AutoIncrement = false;
				colvarDireccionTelefonoOficina.IsNullable = true;
				colvarDireccionTelefonoOficina.IsPrimaryKey = false;
				colvarDireccionTelefonoOficina.IsForeignKey = false;
				colvarDireccionTelefonoOficina.IsReadOnly = false;
				colvarDireccionTelefonoOficina.DefaultSetting = @"";
				colvarDireccionTelefonoOficina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionTelefonoOficina);
				
				TableSchema.TableColumn colvarDireccionExtension = new TableSchema.TableColumn(schema);
				colvarDireccionExtension.ColumnName = "DireccionExtension";
				colvarDireccionExtension.DataType = DbType.Int32;
				colvarDireccionExtension.MaxLength = 0;
				colvarDireccionExtension.AutoIncrement = false;
				colvarDireccionExtension.IsNullable = true;
				colvarDireccionExtension.IsPrimaryKey = false;
				colvarDireccionExtension.IsForeignKey = false;
				colvarDireccionExtension.IsReadOnly = false;
				colvarDireccionExtension.DefaultSetting = @"";
				colvarDireccionExtension.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionExtension);
				
				TableSchema.TableColumn colvarDireccionFax = new TableSchema.TableColumn(schema);
				colvarDireccionFax.ColumnName = "DireccionFax";
				colvarDireccionFax.DataType = DbType.String;
				colvarDireccionFax.MaxLength = 15;
				colvarDireccionFax.AutoIncrement = false;
				colvarDireccionFax.IsNullable = true;
				colvarDireccionFax.IsPrimaryKey = false;
				colvarDireccionFax.IsForeignKey = false;
				colvarDireccionFax.IsReadOnly = false;
				colvarDireccionFax.DefaultSetting = @"";
				colvarDireccionFax.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccionFax);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OficinaVirtualProvider"].AddSchema("Sucursales",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SucursalId")]
		[Bindable(true)]
		public int SucursalId 
		{
			get { return GetColumnValue<int>(Columns.SucursalId); }
			set { SetColumnValue(Columns.SucursalId, value); }
		}
		  
		[XmlAttribute("SociedadId")]
		[Bindable(true)]
		public int SociedadId 
		{
			get { return GetColumnValue<int>(Columns.SociedadId); }
			set { SetColumnValue(Columns.SociedadId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("DireccionId")]
		[Bindable(true)]
		public int? DireccionId 
		{
			get { return GetColumnValue<int?>(Columns.DireccionId); }
			set { SetColumnValue(Columns.DireccionId, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("DireccionCalle")]
		[Bindable(true)]
		public string DireccionCalle 
		{
			get { return GetColumnValue<string>(Columns.DireccionCalle); }
			set { SetColumnValue(Columns.DireccionCalle, value); }
		}
		  
		[XmlAttribute("DireccionNumero")]
		[Bindable(true)]
		public string DireccionNumero 
		{
			get { return GetColumnValue<string>(Columns.DireccionNumero); }
			set { SetColumnValue(Columns.DireccionNumero, value); }
		}
		  
		[XmlAttribute("DireccionCiudadId")]
		[Bindable(true)]
		public int? DireccionCiudadId 
		{
			get { return GetColumnValue<int?>(Columns.DireccionCiudadId); }
			set { SetColumnValue(Columns.DireccionCiudadId, value); }
		}
		  
		[XmlAttribute("DireccionSectorId")]
		[Bindable(true)]
		public int? DireccionSectorId 
		{
			get { return GetColumnValue<int?>(Columns.DireccionSectorId); }
			set { SetColumnValue(Columns.DireccionSectorId, value); }
		}
		  
		[XmlAttribute("DireccionApartadoPostal")]
		[Bindable(true)]
		public string DireccionApartadoPostal 
		{
			get { return GetColumnValue<string>(Columns.DireccionApartadoPostal); }
			set { SetColumnValue(Columns.DireccionApartadoPostal, value); }
		}
		  
		[XmlAttribute("DireccionTelefonoCasa")]
		[Bindable(true)]
		public string DireccionTelefonoCasa 
		{
			get { return GetColumnValue<string>(Columns.DireccionTelefonoCasa); }
			set { SetColumnValue(Columns.DireccionTelefonoCasa, value); }
		}
		  
		[XmlAttribute("DireccionTelefonoOficina")]
		[Bindable(true)]
		public string DireccionTelefonoOficina 
		{
			get { return GetColumnValue<string>(Columns.DireccionTelefonoOficina); }
			set { SetColumnValue(Columns.DireccionTelefonoOficina, value); }
		}
		  
		[XmlAttribute("DireccionExtension")]
		[Bindable(true)]
		public int? DireccionExtension 
		{
			get { return GetColumnValue<int?>(Columns.DireccionExtension); }
			set { SetColumnValue(Columns.DireccionExtension, value); }
		}
		  
		[XmlAttribute("DireccionFax")]
		[Bindable(true)]
		public string DireccionFax 
		{
			get { return GetColumnValue<string>(Columns.DireccionFax); }
			set { SetColumnValue(Columns.DireccionFax, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Sociedad ActiveRecord object related to this Sucursal
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.OficinaVirtual.Sociedad Sociedad
		{
			get { return CamaraComercio.DataAccess.OficinaVirtual.Sociedad.FetchByID(this.SociedadId); }
			set { SetColumnValue("SociedadId", value.SociedadId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSociedadId,string varDescripcion,int? varDireccionId,DateTime varFechaModificacion,string varDireccionCalle,string varDireccionNumero,int? varDireccionCiudadId,int? varDireccionSectorId,string varDireccionApartadoPostal,string varDireccionTelefonoCasa,string varDireccionTelefonoOficina,int? varDireccionExtension,string varDireccionFax)
		{
			Sucursal item = new Sucursal();
			
			item.SociedadId = varSociedadId;
			
			item.Descripcion = varDescripcion;
			
			item.DireccionId = varDireccionId;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.DireccionCalle = varDireccionCalle;
			
			item.DireccionNumero = varDireccionNumero;
			
			item.DireccionCiudadId = varDireccionCiudadId;
			
			item.DireccionSectorId = varDireccionSectorId;
			
			item.DireccionApartadoPostal = varDireccionApartadoPostal;
			
			item.DireccionTelefonoCasa = varDireccionTelefonoCasa;
			
			item.DireccionTelefonoOficina = varDireccionTelefonoOficina;
			
			item.DireccionExtension = varDireccionExtension;
			
			item.DireccionFax = varDireccionFax;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSucursalId,int varSociedadId,string varDescripcion,int? varDireccionId,DateTime varFechaModificacion,string varDireccionCalle,string varDireccionNumero,int? varDireccionCiudadId,int? varDireccionSectorId,string varDireccionApartadoPostal,string varDireccionTelefonoCasa,string varDireccionTelefonoOficina,int? varDireccionExtension,string varDireccionFax)
		{
			Sucursal item = new Sucursal();
			
				item.SucursalId = varSucursalId;
			
				item.SociedadId = varSociedadId;
			
				item.Descripcion = varDescripcion;
			
				item.DireccionId = varDireccionId;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.DireccionCalle = varDireccionCalle;
			
				item.DireccionNumero = varDireccionNumero;
			
				item.DireccionCiudadId = varDireccionCiudadId;
			
				item.DireccionSectorId = varDireccionSectorId;
			
				item.DireccionApartadoPostal = varDireccionApartadoPostal;
			
				item.DireccionTelefonoCasa = varDireccionTelefonoCasa;
			
				item.DireccionTelefonoOficina = varDireccionTelefonoOficina;
			
				item.DireccionExtension = varDireccionExtension;
			
				item.DireccionFax = varDireccionFax;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SucursalIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SociedadIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionCalleColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionNumeroColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionCiudadIdColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionSectorIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionApartadoPostalColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionTelefonoCasaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionTelefonoOficinaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionExtensionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionFaxColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SucursalId = @"SucursalId";
			 public static string SociedadId = @"SociedadId";
			 public static string Descripcion = @"Descripcion";
			 public static string DireccionId = @"DireccionId";
			 public static string FechaModificacion = @"FechaModificacion";
			 public static string DireccionCalle = @"DireccionCalle";
			 public static string DireccionNumero = @"DireccionNumero";
			 public static string DireccionCiudadId = @"DireccionCiudadId";
			 public static string DireccionSectorId = @"DireccionSectorId";
			 public static string DireccionApartadoPostal = @"DireccionApartadoPostal";
			 public static string DireccionTelefonoCasa = @"DireccionTelefonoCasa";
			 public static string DireccionTelefonoOficina = @"DireccionTelefonoOficina";
			 public static string DireccionExtension = @"DireccionExtension";
			 public static string DireccionFax = @"DireccionFax";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
