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
	/// Strongly-typed collection for the Producto class.
	/// </summary>
    [Serializable]
	public partial class ProductoCollection : ActiveList<Producto, ProductoCollection>
	{	   
		public ProductoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductoCollection</returns>
		public ProductoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Producto o = this[i];
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
	/// This is an ActiveRecord class which wraps the Productos table.
	/// </summary>
	[Serializable]
	public partial class Producto : ActiveRecord<Producto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Producto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Producto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Producto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Producto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Productos", TableType.Table, DataService.GetInstance("OficinaVirtualProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"WebSRM";
				//columns
				
				TableSchema.TableColumn colvarProductoId = new TableSchema.TableColumn(schema);
				colvarProductoId.ColumnName = "ProductoId";
				colvarProductoId.DataType = DbType.Int32;
				colvarProductoId.MaxLength = 0;
				colvarProductoId.AutoIncrement = true;
				colvarProductoId.IsNullable = false;
				colvarProductoId.IsPrimaryKey = true;
				colvarProductoId.IsForeignKey = false;
				colvarProductoId.IsReadOnly = false;
				colvarProductoId.DefaultSetting = @"";
				colvarProductoId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductoId);
				
				TableSchema.TableColumn colvarRegistroId = new TableSchema.TableColumn(schema);
				colvarRegistroId.ColumnName = "RegistroId";
				colvarRegistroId.DataType = DbType.Int32;
				colvarRegistroId.MaxLength = 0;
				colvarRegistroId.AutoIncrement = false;
				colvarRegistroId.IsNullable = false;
				colvarRegistroId.IsPrimaryKey = false;
				colvarRegistroId.IsForeignKey = true;
				colvarRegistroId.IsReadOnly = false;
				colvarRegistroId.DefaultSetting = @"";
				
					colvarRegistroId.ForeignKeyTableName = "Registros";
				schema.Columns.Add(colvarRegistroId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarSistemaArmonizadoId = new TableSchema.TableColumn(schema);
				colvarSistemaArmonizadoId.ColumnName = "SistemaArmonizadoId";
				colvarSistemaArmonizadoId.DataType = DbType.String;
				colvarSistemaArmonizadoId.MaxLength = 10;
				colvarSistemaArmonizadoId.AutoIncrement = false;
				colvarSistemaArmonizadoId.IsNullable = true;
				colvarSistemaArmonizadoId.IsPrimaryKey = false;
				colvarSistemaArmonizadoId.IsForeignKey = true;
				colvarSistemaArmonizadoId.IsReadOnly = false;
				colvarSistemaArmonizadoId.DefaultSetting = @"";
				
					colvarSistemaArmonizadoId.ForeignKeyTableName = "SistemasArmonizados";
				schema.Columns.Add(colvarSistemaArmonizadoId);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OficinaVirtualProvider"].AddSchema("Productos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductoId")]
		[Bindable(true)]
		public int ProductoId 
		{
			get { return GetColumnValue<int>(Columns.ProductoId); }
			set { SetColumnValue(Columns.ProductoId, value); }
		}
		  
		[XmlAttribute("RegistroId")]
		[Bindable(true)]
		public int RegistroId 
		{
			get { return GetColumnValue<int>(Columns.RegistroId); }
			set { SetColumnValue(Columns.RegistroId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("SistemaArmonizadoId")]
		[Bindable(true)]
		public string SistemaArmonizadoId 
		{
			get { return GetColumnValue<string>(Columns.SistemaArmonizadoId); }
			set { SetColumnValue(Columns.SistemaArmonizadoId, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Registro ActiveRecord object related to this Producto
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.OficinaVirtual.Registro Registro
		{
			get { return CamaraComercio.DataAccess.OficinaVirtual.Registro.FetchByID(this.RegistroId); }
			set { SetColumnValue("RegistroId", value.RegistroId); }
		}
		
		
		/// <summary>
		/// Returns a SistemaArmonizado ActiveRecord object related to this Producto
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.OficinaVirtual.SistemaArmonizado SistemaArmonizado
		{
			get { return CamaraComercio.DataAccess.OficinaVirtual.SistemaArmonizado.FetchByID(this.SistemaArmonizadoId); }
			set { SetColumnValue("SistemaArmonizadoId", value.SistemaArmonizadoId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegistroId,string varDescripcion,string varSistemaArmonizadoId,DateTime varFechaModificacion)
		{
			Producto item = new Producto();
			
			item.RegistroId = varRegistroId;
			
			item.Descripcion = varDescripcion;
			
			item.SistemaArmonizadoId = varSistemaArmonizadoId;
			
			item.FechaModificacion = varFechaModificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductoId,int varRegistroId,string varDescripcion,string varSistemaArmonizadoId,DateTime varFechaModificacion)
		{
			Producto item = new Producto();
			
				item.ProductoId = varProductoId;
			
				item.RegistroId = varRegistroId;
			
				item.Descripcion = varDescripcion;
			
				item.SistemaArmonizadoId = varSistemaArmonizadoId;
			
				item.FechaModificacion = varFechaModificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProductoIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RegistroIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SistemaArmonizadoIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ProductoId = @"ProductoId";
			 public static string RegistroId = @"RegistroId";
			 public static string Descripcion = @"Descripcion";
			 public static string SistemaArmonizadoId = @"SistemaArmonizadoId";
			 public static string FechaModificacion = @"FechaModificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
