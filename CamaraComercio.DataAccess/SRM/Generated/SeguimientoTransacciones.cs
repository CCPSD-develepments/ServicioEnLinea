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
	/// Strongly-typed collection for the SeguimientoTransacciones class.
	/// </summary>
    [Serializable]
	public partial class SeguimientoTransaccionesCollection : ActiveList<SeguimientoTransacciones, SeguimientoTransaccionesCollection>
	{	   
		public SeguimientoTransaccionesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SeguimientoTransaccionesCollection</returns>
		public SeguimientoTransaccionesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SeguimientoTransacciones o = this[i];
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
	/// This is an ActiveRecord class which wraps the SeguimientoTransacciones table.
	/// </summary>
	[Serializable]
	public partial class SeguimientoTransacciones : ActiveRecord<SeguimientoTransacciones>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SeguimientoTransacciones()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SeguimientoTransacciones(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SeguimientoTransacciones(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SeguimientoTransacciones(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SeguimientoTransacciones", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Transaccion";
				//columns
				
				TableSchema.TableColumn colvarSeguimientoId = new TableSchema.TableColumn(schema);
				colvarSeguimientoId.ColumnName = "SeguimientoId";
				colvarSeguimientoId.DataType = DbType.Int32;
				colvarSeguimientoId.MaxLength = 0;
				colvarSeguimientoId.AutoIncrement = true;
				colvarSeguimientoId.IsNullable = false;
				colvarSeguimientoId.IsPrimaryKey = true;
				colvarSeguimientoId.IsForeignKey = false;
				colvarSeguimientoId.IsReadOnly = false;
				colvarSeguimientoId.DefaultSetting = @"";
				colvarSeguimientoId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeguimientoId);
				
				TableSchema.TableColumn colvarTransaccionId = new TableSchema.TableColumn(schema);
				colvarTransaccionId.ColumnName = "TransaccionId";
				colvarTransaccionId.DataType = DbType.Int32;
				colvarTransaccionId.MaxLength = 0;
				colvarTransaccionId.AutoIncrement = false;
				colvarTransaccionId.IsNullable = false;
				colvarTransaccionId.IsPrimaryKey = false;
				colvarTransaccionId.IsForeignKey = true;
				colvarTransaccionId.IsReadOnly = false;
				colvarTransaccionId.DefaultSetting = @"";
				
					colvarTransaccionId.ForeignKeyTableName = "Transacciones";
				schema.Columns.Add(colvarTransaccionId);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "Estado";
				colvarEstado.DataType = DbType.Int32;
				colvarEstado.MaxLength = 0;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = false;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "Comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = 2147483647;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = false;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarUsuarioId = new TableSchema.TableColumn(schema);
				colvarUsuarioId.ColumnName = "UsuarioId";
				colvarUsuarioId.DataType = DbType.Int32;
				colvarUsuarioId.MaxLength = 0;
				colvarUsuarioId.AutoIncrement = false;
				colvarUsuarioId.IsNullable = false;
				colvarUsuarioId.IsPrimaryKey = false;
				colvarUsuarioId.IsForeignKey = false;
				colvarUsuarioId.IsReadOnly = false;
				colvarUsuarioId.DefaultSetting = @"";
				colvarUsuarioId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioId);
				
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
				
				TableSchema.TableColumn colvarUsuarioAsignadoId = new TableSchema.TableColumn(schema);
				colvarUsuarioAsignadoId.ColumnName = "UsuarioAsignadoId";
				colvarUsuarioAsignadoId.DataType = DbType.Int32;
				colvarUsuarioAsignadoId.MaxLength = 0;
				colvarUsuarioAsignadoId.AutoIncrement = false;
				colvarUsuarioAsignadoId.IsNullable = true;
				colvarUsuarioAsignadoId.IsPrimaryKey = false;
				colvarUsuarioAsignadoId.IsForeignKey = false;
				colvarUsuarioAsignadoId.IsReadOnly = false;
				colvarUsuarioAsignadoId.DefaultSetting = @"";
				colvarUsuarioAsignadoId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioAsignadoId);
				
				TableSchema.TableColumn colvarTipoComentario = new TableSchema.TableColumn(schema);
				colvarTipoComentario.ColumnName = "TipoComentario";
				colvarTipoComentario.DataType = DbType.Int32;
				colvarTipoComentario.MaxLength = 0;
				colvarTipoComentario.AutoIncrement = false;
				colvarTipoComentario.IsNullable = true;
				colvarTipoComentario.IsPrimaryKey = false;
				colvarTipoComentario.IsForeignKey = false;
				colvarTipoComentario.IsReadOnly = false;
				
						colvarTipoComentario.DefaultSetting = @"((0))";
				colvarTipoComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoComentario);
				
				TableSchema.TableColumn colvarIsDefault = new TableSchema.TableColumn(schema);
				colvarIsDefault.ColumnName = "IsDefault";
				colvarIsDefault.DataType = DbType.Boolean;
				colvarIsDefault.MaxLength = 0;
				colvarIsDefault.AutoIncrement = false;
				colvarIsDefault.IsNullable = true;
				colvarIsDefault.IsPrimaryKey = false;
				colvarIsDefault.IsForeignKey = false;
				colvarIsDefault.IsReadOnly = false;
				colvarIsDefault.DefaultSetting = @"";
				colvarIsDefault.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDefault);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("SeguimientoTransacciones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SeguimientoId")]
		[Bindable(true)]
		public int SeguimientoId 
		{
			get { return GetColumnValue<int>(Columns.SeguimientoId); }
			set { SetColumnValue(Columns.SeguimientoId, value); }
		}
		  
		[XmlAttribute("TransaccionId")]
		[Bindable(true)]
		public int TransaccionId 
		{
			get { return GetColumnValue<int>(Columns.TransaccionId); }
			set { SetColumnValue(Columns.TransaccionId, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public int Estado 
		{
			get { return GetColumnValue<int>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("UsuarioId")]
		[Bindable(true)]
		public int UsuarioId 
		{
			get { return GetColumnValue<int>(Columns.UsuarioId); }
			set { SetColumnValue(Columns.UsuarioId, value); }
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
		  
		[XmlAttribute("UsuarioAsignadoId")]
		[Bindable(true)]
		public int? UsuarioAsignadoId 
		{
			get { return GetColumnValue<int?>(Columns.UsuarioAsignadoId); }
			set { SetColumnValue(Columns.UsuarioAsignadoId, value); }
		}
		  
		[XmlAttribute("TipoComentario")]
		[Bindable(true)]
		public int? TipoComentario 
		{
			get { return GetColumnValue<int?>(Columns.TipoComentario); }
			set { SetColumnValue(Columns.TipoComentario, value); }
		}
		  
		[XmlAttribute("IsDefault")]
		[Bindable(true)]
		public bool? IsDefault 
		{
			get { return GetColumnValue<bool?>(Columns.IsDefault); }
			set { SetColumnValue(Columns.IsDefault, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Transacciones ActiveRecord object related to this SeguimientoTransacciones
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Transacciones Transacciones
		{
			get { return CamaraComercio.DataAccess.SRM.Transacciones.FetchByID(this.TransaccionId); }
			set { SetColumnValue("TransaccionId", value.TransaccionId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTransaccionId,int varEstado,string varComentario,int varUsuarioId,DateTime varFechaModificacion,Guid varRowguid,int? varUsuarioAsignadoId,int? varTipoComentario,bool? varIsDefault)
		{
			SeguimientoTransacciones item = new SeguimientoTransacciones();
			
			item.TransaccionId = varTransaccionId;
			
			item.Estado = varEstado;
			
			item.Comentario = varComentario;
			
			item.UsuarioId = varUsuarioId;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.Rowguid = varRowguid;
			
			item.UsuarioAsignadoId = varUsuarioAsignadoId;
			
			item.TipoComentario = varTipoComentario;
			
			item.IsDefault = varIsDefault;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSeguimientoId,int varTransaccionId,int varEstado,string varComentario,int varUsuarioId,DateTime varFechaModificacion,Guid varRowguid,int? varUsuarioAsignadoId,int? varTipoComentario,bool? varIsDefault)
		{
			SeguimientoTransacciones item = new SeguimientoTransacciones();
			
				item.SeguimientoId = varSeguimientoId;
			
				item.TransaccionId = varTransaccionId;
			
				item.Estado = varEstado;
			
				item.Comentario = varComentario;
			
				item.UsuarioId = varUsuarioId;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.Rowguid = varRowguid;
			
				item.UsuarioAsignadoId = varUsuarioAsignadoId;
			
				item.TipoComentario = varTipoComentario;
			
				item.IsDefault = varIsDefault;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SeguimientoIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TransaccionIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioAsignadoIdColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoComentarioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDefaultColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SeguimientoId = @"SeguimientoId";
			 public static string TransaccionId = @"TransaccionId";
			 public static string Estado = @"Estado";
			 public static string Comentario = @"Comentario";
			 public static string UsuarioId = @"UsuarioId";
			 public static string FechaModificacion = @"FechaModificacion";
			 public static string Rowguid = @"rowguid";
			 public static string UsuarioAsignadoId = @"UsuarioAsignadoId";
			 public static string TipoComentario = @"TipoComentario";
			 public static string IsDefault = @"IsDefault";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
