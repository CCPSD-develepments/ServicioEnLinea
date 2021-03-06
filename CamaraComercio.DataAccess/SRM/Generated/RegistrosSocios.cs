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
	/// Strongly-typed collection for the RegistrosSocios class.
	/// </summary>
    [Serializable]
	public partial class RegistrosSociosCollection : ActiveList<RegistrosSocios, RegistrosSociosCollection>
	{	   
		public RegistrosSociosCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RegistrosSociosCollection</returns>
		public RegistrosSociosCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RegistrosSocios o = this[i];
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
	/// This is an ActiveRecord class which wraps the RegistrosSocios table.
	/// </summary>
	[Serializable]
	public partial class RegistrosSocios : ActiveRecord<RegistrosSocios>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RegistrosSocios()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RegistrosSocios(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RegistrosSocios(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RegistrosSocios(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RegistrosSocios", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sistema";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarRegistroId = new TableSchema.TableColumn(schema);
				colvarRegistroId.ColumnName = "RegistroId";
				colvarRegistroId.DataType = DbType.Int32;
				colvarRegistroId.MaxLength = 0;
				colvarRegistroId.AutoIncrement = false;
				colvarRegistroId.IsNullable = false;
				colvarRegistroId.IsPrimaryKey = false;
				colvarRegistroId.IsForeignKey = false;
				colvarRegistroId.IsReadOnly = false;
				colvarRegistroId.DefaultSetting = @"";
				colvarRegistroId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegistroId);
				
				TableSchema.TableColumn colvarSocioId = new TableSchema.TableColumn(schema);
				colvarSocioId.ColumnName = "SocioId";
				colvarSocioId.DataType = DbType.Int32;
				colvarSocioId.MaxLength = 0;
				colvarSocioId.AutoIncrement = false;
				colvarSocioId.IsNullable = false;
				colvarSocioId.IsPrimaryKey = false;
				colvarSocioId.IsForeignKey = false;
				colvarSocioId.IsReadOnly = false;
				colvarSocioId.DefaultSetting = @"";
				colvarSocioId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSocioId);
				
				TableSchema.TableColumn colvarTipoSocio = new TableSchema.TableColumn(schema);
				colvarTipoSocio.ColumnName = "TipoSocio";
				colvarTipoSocio.DataType = DbType.String;
				colvarTipoSocio.MaxLength = 1;
				colvarTipoSocio.AutoIncrement = false;
				colvarTipoSocio.IsNullable = false;
				colvarTipoSocio.IsPrimaryKey = false;
				colvarTipoSocio.IsForeignKey = false;
				colvarTipoSocio.IsReadOnly = false;
				colvarTipoSocio.DefaultSetting = @"";
				colvarTipoSocio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoSocio);
				
				TableSchema.TableColumn colvarTipoRelacion = new TableSchema.TableColumn(schema);
				colvarTipoRelacion.ColumnName = "TipoRelacion";
				colvarTipoRelacion.DataType = DbType.String;
				colvarTipoRelacion.MaxLength = 1;
				colvarTipoRelacion.AutoIncrement = false;
				colvarTipoRelacion.IsNullable = false;
				colvarTipoRelacion.IsPrimaryKey = false;
				colvarTipoRelacion.IsForeignKey = false;
				colvarTipoRelacion.IsReadOnly = false;
				colvarTipoRelacion.DefaultSetting = @"";
				colvarTipoRelacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoRelacion);
				
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
				
				TableSchema.TableColumn colvarRepresentanteId = new TableSchema.TableColumn(schema);
				colvarRepresentanteId.ColumnName = "RepresentanteId";
				colvarRepresentanteId.DataType = DbType.Int32;
				colvarRepresentanteId.MaxLength = 0;
				colvarRepresentanteId.AutoIncrement = false;
				colvarRepresentanteId.IsNullable = true;
				colvarRepresentanteId.IsPrimaryKey = false;
				colvarRepresentanteId.IsForeignKey = false;
				colvarRepresentanteId.IsReadOnly = false;
				colvarRepresentanteId.DefaultSetting = @"";
				colvarRepresentanteId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRepresentanteId);
				
				TableSchema.TableColumn colvarCargoId = new TableSchema.TableColumn(schema);
				colvarCargoId.ColumnName = "CargoId";
				colvarCargoId.DataType = DbType.Int32;
				colvarCargoId.MaxLength = 0;
				colvarCargoId.AutoIncrement = false;
				colvarCargoId.IsNullable = true;
				colvarCargoId.IsPrimaryKey = false;
				colvarCargoId.IsForeignKey = false;
				colvarCargoId.IsReadOnly = false;
				colvarCargoId.DefaultSetting = @"";
				colvarCargoId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCargoId);
				
				TableSchema.TableColumn colvarNumeroRM = new TableSchema.TableColumn(schema);
				colvarNumeroRM.ColumnName = "NumeroRM";
				colvarNumeroRM.DataType = DbType.String;
				colvarNumeroRM.MaxLength = 10;
				colvarNumeroRM.AutoIncrement = false;
				colvarNumeroRM.IsNullable = true;
				colvarNumeroRM.IsPrimaryKey = false;
				colvarNumeroRM.IsForeignKey = false;
				colvarNumeroRM.IsReadOnly = false;
				colvarNumeroRM.DefaultSetting = @"";
				colvarNumeroRM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroRM);
				
				TableSchema.TableColumn colvarOrden = new TableSchema.TableColumn(schema);
				colvarOrden.ColumnName = "Orden";
				colvarOrden.DataType = DbType.Int32;
				colvarOrden.MaxLength = 0;
				colvarOrden.AutoIncrement = false;
				colvarOrden.IsNullable = true;
				colvarOrden.IsPrimaryKey = false;
				colvarOrden.IsForeignKey = false;
				colvarOrden.IsReadOnly = false;
				colvarOrden.DefaultSetting = @"";
				colvarOrden.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrden);
				
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
				
				TableSchema.TableColumn colvarDeleted = new TableSchema.TableColumn(schema);
				colvarDeleted.ColumnName = "Deleted";
				colvarDeleted.DataType = DbType.Boolean;
				colvarDeleted.MaxLength = 0;
				colvarDeleted.AutoIncrement = false;
				colvarDeleted.IsNullable = true;
				colvarDeleted.IsPrimaryKey = false;
				colvarDeleted.IsForeignKey = false;
				colvarDeleted.IsReadOnly = false;
				colvarDeleted.DefaultSetting = @"";
				colvarDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDeleted);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("RegistrosSocios",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("RegistroId")]
		[Bindable(true)]
		public int RegistroId 
		{
			get { return GetColumnValue<int>(Columns.RegistroId); }
			set { SetColumnValue(Columns.RegistroId, value); }
		}
		  
		[XmlAttribute("SocioId")]
		[Bindable(true)]
		public int SocioId 
		{
			get { return GetColumnValue<int>(Columns.SocioId); }
			set { SetColumnValue(Columns.SocioId, value); }
		}
		  
		[XmlAttribute("TipoSocio")]
		[Bindable(true)]
		public string TipoSocio 
		{
			get { return GetColumnValue<string>(Columns.TipoSocio); }
			set { SetColumnValue(Columns.TipoSocio, value); }
		}
		  
		[XmlAttribute("TipoRelacion")]
		[Bindable(true)]
		public string TipoRelacion 
		{
			get { return GetColumnValue<string>(Columns.TipoRelacion); }
			set { SetColumnValue(Columns.TipoRelacion, value); }
		}
		  
		[XmlAttribute("DireccionId")]
		[Bindable(true)]
		public int? DireccionId 
		{
			get { return GetColumnValue<int?>(Columns.DireccionId); }
			set { SetColumnValue(Columns.DireccionId, value); }
		}
		  
		[XmlAttribute("RepresentanteId")]
		[Bindable(true)]
		public int? RepresentanteId 
		{
			get { return GetColumnValue<int?>(Columns.RepresentanteId); }
			set { SetColumnValue(Columns.RepresentanteId, value); }
		}
		  
		[XmlAttribute("CargoId")]
		[Bindable(true)]
		public int? CargoId 
		{
			get { return GetColumnValue<int?>(Columns.CargoId); }
			set { SetColumnValue(Columns.CargoId, value); }
		}
		  
		[XmlAttribute("NumeroRM")]
		[Bindable(true)]
		public string NumeroRM 
		{
			get { return GetColumnValue<string>(Columns.NumeroRM); }
			set { SetColumnValue(Columns.NumeroRM, value); }
		}
		  
		[XmlAttribute("Orden")]
		[Bindable(true)]
		public int? Orden 
		{
			get { return GetColumnValue<int?>(Columns.Orden); }
			set { SetColumnValue(Columns.Orden, value); }
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
		  
		[XmlAttribute("Deleted")]
		[Bindable(true)]
		public bool? Deleted 
		{
			get { return GetColumnValue<bool?>(Columns.Deleted); }
			set { SetColumnValue(Columns.Deleted, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegistroId,int varSocioId,string varTipoSocio,string varTipoRelacion,int? varDireccionId,int? varRepresentanteId,int? varCargoId,string varNumeroRM,int? varOrden,DateTime varFechaModificacion,Guid varRowguid,bool? varDeleted)
		{
			RegistrosSocios item = new RegistrosSocios();
			
			item.RegistroId = varRegistroId;
			
			item.SocioId = varSocioId;
			
			item.TipoSocio = varTipoSocio;
			
			item.TipoRelacion = varTipoRelacion;
			
			item.DireccionId = varDireccionId;
			
			item.RepresentanteId = varRepresentanteId;
			
			item.CargoId = varCargoId;
			
			item.NumeroRM = varNumeroRM;
			
			item.Orden = varOrden;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.Rowguid = varRowguid;
			
			item.Deleted = varDeleted;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varRegistroId,int varSocioId,string varTipoSocio,string varTipoRelacion,int? varDireccionId,int? varRepresentanteId,int? varCargoId,string varNumeroRM,int? varOrden,DateTime varFechaModificacion,Guid varRowguid,bool? varDeleted)
		{
			RegistrosSocios item = new RegistrosSocios();
			
				item.Id = varId;
			
				item.RegistroId = varRegistroId;
			
				item.SocioId = varSocioId;
			
				item.TipoSocio = varTipoSocio;
			
				item.TipoRelacion = varTipoRelacion;
			
				item.DireccionId = varDireccionId;
			
				item.RepresentanteId = varRepresentanteId;
			
				item.CargoId = varCargoId;
			
				item.NumeroRM = varNumeroRM;
			
				item.Orden = varOrden;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.Rowguid = varRowguid;
			
				item.Deleted = varDeleted;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RegistroIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SocioIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoSocioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoRelacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionIdColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn RepresentanteIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CargoIdColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroRMColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdenColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string RegistroId = @"RegistroId";
			 public static string SocioId = @"SocioId";
			 public static string TipoSocio = @"TipoSocio";
			 public static string TipoRelacion = @"TipoRelacion";
			 public static string DireccionId = @"DireccionId";
			 public static string RepresentanteId = @"RepresentanteId";
			 public static string CargoId = @"CargoId";
			 public static string NumeroRM = @"NumeroRM";
			 public static string Orden = @"Orden";
			 public static string FechaModificacion = @"FechaModificacion";
			 public static string Rowguid = @"rowguid";
			 public static string Deleted = @"Deleted";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
