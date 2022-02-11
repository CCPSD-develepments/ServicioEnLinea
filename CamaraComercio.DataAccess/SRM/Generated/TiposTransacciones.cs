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
	/// Strongly-typed collection for the TiposTransacciones class.
	/// </summary>
    [Serializable]
	public partial class TiposTransaccionesCollection : ActiveList<TiposTransacciones, TiposTransaccionesCollection>
	{	   
		public TiposTransaccionesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TiposTransaccionesCollection</returns>
		public TiposTransaccionesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TiposTransacciones o = this[i];
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
	/// This is an ActiveRecord class which wraps the TiposTransacciones table.
	/// </summary>
	[Serializable]
	public partial class TiposTransacciones : ActiveRecord<TiposTransacciones>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TiposTransacciones()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TiposTransacciones(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TiposTransacciones(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TiposTransacciones(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TiposTransacciones", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Transaccion";
				//columns
				
				TableSchema.TableColumn colvarTipoTransaccionId = new TableSchema.TableColumn(schema);
				colvarTipoTransaccionId.ColumnName = "TipoTransaccionId";
				colvarTipoTransaccionId.DataType = DbType.Int32;
				colvarTipoTransaccionId.MaxLength = 0;
				colvarTipoTransaccionId.AutoIncrement = true;
				colvarTipoTransaccionId.IsNullable = false;
				colvarTipoTransaccionId.IsPrimaryKey = true;
				colvarTipoTransaccionId.IsForeignKey = false;
				colvarTipoTransaccionId.IsReadOnly = false;
				colvarTipoTransaccionId.DefaultSetting = @"";
				colvarTipoTransaccionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoTransaccionId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 50;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarSufijo = new TableSchema.TableColumn(schema);
				colvarSufijo.ColumnName = "Sufijo";
				colvarSufijo.DataType = DbType.AnsiString;
				colvarSufijo.MaxLength = 2;
				colvarSufijo.AutoIncrement = false;
				colvarSufijo.IsNullable = false;
				colvarSufijo.IsPrimaryKey = false;
				colvarSufijo.IsForeignKey = false;
				colvarSufijo.IsReadOnly = false;
				colvarSufijo.DefaultSetting = @"";
				colvarSufijo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSufijo);
				
				TableSchema.TableColumn colvarLibro = new TableSchema.TableColumn(schema);
				colvarLibro.ColumnName = "Libro";
				colvarLibro.DataType = DbType.Int32;
				colvarLibro.MaxLength = 0;
				colvarLibro.AutoIncrement = false;
				colvarLibro.IsNullable = true;
				colvarLibro.IsPrimaryKey = false;
				colvarLibro.IsForeignKey = false;
				colvarLibro.IsReadOnly = false;
				colvarLibro.DefaultSetting = @"";
				colvarLibro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLibro);
				
				TableSchema.TableColumn colvarFolio = new TableSchema.TableColumn(schema);
				colvarFolio.ColumnName = "Folio";
				colvarFolio.DataType = DbType.Int32;
				colvarFolio.MaxLength = 0;
				colvarFolio.AutoIncrement = false;
				colvarFolio.IsNullable = true;
				colvarFolio.IsPrimaryKey = false;
				colvarFolio.IsForeignKey = false;
				colvarFolio.IsReadOnly = false;
				colvarFolio.DefaultSetting = @"";
				colvarFolio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFolio);
				
				TableSchema.TableColumn colvarNoDocumento = new TableSchema.TableColumn(schema);
				colvarNoDocumento.ColumnName = "NoDocumento";
				colvarNoDocumento.DataType = DbType.Int32;
				colvarNoDocumento.MaxLength = 0;
				colvarNoDocumento.AutoIncrement = false;
				colvarNoDocumento.IsNullable = true;
				colvarNoDocumento.IsPrimaryKey = false;
				colvarNoDocumento.IsForeignKey = false;
				colvarNoDocumento.IsReadOnly = false;
				colvarNoDocumento.DefaultSetting = @"";
				colvarNoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNoDocumento);
				
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
				
				TableSchema.TableColumn colvarRowguid = new TableSchema.TableColumn(schema);
				colvarRowguid.ColumnName = "rowguid";
				colvarRowguid.DataType = DbType.Guid;
				colvarRowguid.MaxLength = 0;
				colvarRowguid.AutoIncrement = false;
				colvarRowguid.IsNullable = false;
				colvarRowguid.IsPrimaryKey = false;
				colvarRowguid.IsForeignKey = false;
				colvarRowguid.IsReadOnly = false;
				
						colvarRowguid.DefaultSetting = @"(newid())";
				colvarRowguid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRowguid);
				
				TableSchema.TableColumn colvarTipoIdentificador = new TableSchema.TableColumn(schema);
				colvarTipoIdentificador.ColumnName = "TipoIdentificador";
				colvarTipoIdentificador.DataType = DbType.Int32;
				colvarTipoIdentificador.MaxLength = 0;
				colvarTipoIdentificador.AutoIncrement = false;
				colvarTipoIdentificador.IsNullable = true;
				colvarTipoIdentificador.IsPrimaryKey = false;
				colvarTipoIdentificador.IsForeignKey = false;
				colvarTipoIdentificador.IsReadOnly = false;
				colvarTipoIdentificador.DefaultSetting = @"";
				colvarTipoIdentificador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoIdentificador);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("TiposTransacciones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TipoTransaccionId")]
		[Bindable(true)]
		public int TipoTransaccionId 
		{
			get { return GetColumnValue<int>(Columns.TipoTransaccionId); }
			set { SetColumnValue(Columns.TipoTransaccionId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Sufijo")]
		[Bindable(true)]
		public string Sufijo 
		{
			get { return GetColumnValue<string>(Columns.Sufijo); }
			set { SetColumnValue(Columns.Sufijo, value); }
		}
		  
		[XmlAttribute("Libro")]
		[Bindable(true)]
		public int? Libro 
		{
			get { return GetColumnValue<int?>(Columns.Libro); }
			set { SetColumnValue(Columns.Libro, value); }
		}
		  
		[XmlAttribute("Folio")]
		[Bindable(true)]
		public int? Folio 
		{
			get { return GetColumnValue<int?>(Columns.Folio); }
			set { SetColumnValue(Columns.Folio, value); }
		}
		  
		[XmlAttribute("NoDocumento")]
		[Bindable(true)]
		public int? NoDocumento 
		{
			get { return GetColumnValue<int?>(Columns.NoDocumento); }
			set { SetColumnValue(Columns.NoDocumento, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("Rowguid")]
		[Bindable(true)]
		public Guid Rowguid 
		{
			get { return GetColumnValue<Guid>(Columns.Rowguid); }
			set { SetColumnValue(Columns.Rowguid, value); }
		}
		  
		[XmlAttribute("TipoIdentificador")]
		[Bindable(true)]
		public int? TipoIdentificador 
		{
			get { return GetColumnValue<int?>(Columns.TipoIdentificador); }
			set { SetColumnValue(Columns.TipoIdentificador, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CamaraComercio.DataAccess.SRM.TiposServiciosCollection TiposServiciosRecords()
		{
			return new CamaraComercio.DataAccess.SRM.TiposServiciosCollection().Where(TiposServicios.Columns.TipoTransaccionId, TipoTransaccionId).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,string varSufijo,int? varLibro,int? varFolio,int? varNoDocumento,DateTime varFechaModificacion,Guid varRowguid,int? varTipoIdentificador)
		{
			TiposTransacciones item = new TiposTransacciones();
			
			item.Descripcion = varDescripcion;
			
			item.Sufijo = varSufijo;
			
			item.Libro = varLibro;
			
			item.Folio = varFolio;
			
			item.NoDocumento = varNoDocumento;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.Rowguid = varRowguid;
			
			item.TipoIdentificador = varTipoIdentificador;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTipoTransaccionId,string varDescripcion,string varSufijo,int? varLibro,int? varFolio,int? varNoDocumento,DateTime varFechaModificacion,Guid varRowguid,int? varTipoIdentificador)
		{
			TiposTransacciones item = new TiposTransacciones();
			
				item.TipoTransaccionId = varTipoTransaccionId;
			
				item.Descripcion = varDescripcion;
			
				item.Sufijo = varSufijo;
			
				item.Libro = varLibro;
			
				item.Folio = varFolio;
			
				item.NoDocumento = varNoDocumento;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.Rowguid = varRowguid;
			
				item.TipoIdentificador = varTipoIdentificador;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TipoTransaccionIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SufijoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LibroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FolioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NoDocumentoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoIdentificadorColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TipoTransaccionId = @"TipoTransaccionId";
			 public static string Descripcion = @"Descripcion";
			 public static string Sufijo = @"Sufijo";
			 public static string Libro = @"Libro";
			 public static string Folio = @"Folio";
			 public static string NoDocumento = @"NoDocumento";
			 public static string FechaModificacion = @"FechaModificacion";
			 public static string Rowguid = @"rowguid";
			 public static string TipoIdentificador = @"TipoIdentificador";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
