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
	/// Strongly-typed collection for the ReferenciasComerciales class.
	/// </summary>
    [Serializable]
	public partial class ReferenciasComercialesCollection : ActiveList<ReferenciasComerciales, ReferenciasComercialesCollection>
	{	   
		public ReferenciasComercialesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ReferenciasComercialesCollection</returns>
		public ReferenciasComercialesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ReferenciasComerciales o = this[i];
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
	/// This is an ActiveRecord class which wraps the ReferenciasComerciales table.
	/// </summary>
	[Serializable]
	public partial class ReferenciasComerciales : ActiveRecord<ReferenciasComerciales>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ReferenciasComerciales()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ReferenciasComerciales(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ReferenciasComerciales(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ReferenciasComerciales(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ReferenciasComerciales", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sistema";
				//columns
				
				TableSchema.TableColumn colvarReferenciaComercialId = new TableSchema.TableColumn(schema);
				colvarReferenciaComercialId.ColumnName = "ReferenciaComercialId";
				colvarReferenciaComercialId.DataType = DbType.Int32;
				colvarReferenciaComercialId.MaxLength = 0;
				colvarReferenciaComercialId.AutoIncrement = true;
				colvarReferenciaComercialId.IsNullable = false;
				colvarReferenciaComercialId.IsPrimaryKey = true;
				colvarReferenciaComercialId.IsForeignKey = false;
				colvarReferenciaComercialId.IsReadOnly = false;
				colvarReferenciaComercialId.DefaultSetting = @"";
				colvarReferenciaComercialId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferenciaComercialId);
				
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
				
				TableSchema.TableColumn colvarTipoReferencia = new TableSchema.TableColumn(schema);
				colvarTipoReferencia.ColumnName = "TipoReferencia";
				colvarTipoReferencia.DataType = DbType.String;
				colvarTipoReferencia.MaxLength = 1;
				colvarTipoReferencia.AutoIncrement = false;
				colvarTipoReferencia.IsNullable = false;
				colvarTipoReferencia.IsPrimaryKey = false;
				colvarTipoReferencia.IsForeignKey = false;
				colvarTipoReferencia.IsReadOnly = false;
				colvarTipoReferencia.DefaultSetting = @"";
				colvarTipoReferencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoReferencia);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("ReferenciasComerciales",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ReferenciaComercialId")]
		[Bindable(true)]
		public int ReferenciaComercialId 
		{
			get { return GetColumnValue<int>(Columns.ReferenciaComercialId); }
			set { SetColumnValue(Columns.ReferenciaComercialId, value); }
		}
		  
		[XmlAttribute("RegistroId")]
		[Bindable(true)]
		public int RegistroId 
		{
			get { return GetColumnValue<int>(Columns.RegistroId); }
			set { SetColumnValue(Columns.RegistroId, value); }
		}
		  
		[XmlAttribute("TipoReferencia")]
		[Bindable(true)]
		public string TipoReferencia 
		{
			get { return GetColumnValue<string>(Columns.TipoReferencia); }
			set { SetColumnValue(Columns.TipoReferencia, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
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
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Registros ActiveRecord object related to this ReferenciasComerciales
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Registros Registros
		{
			get { return CamaraComercio.DataAccess.SRM.Registros.FetchByID(this.RegistroId); }
			set { SetColumnValue("RegistroId", value.RegistroId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegistroId,string varTipoReferencia,string varDescripcion,DateTime varFechaModificacion,Guid varRowguid)
		{
			ReferenciasComerciales item = new ReferenciasComerciales();
			
			item.RegistroId = varRegistroId;
			
			item.TipoReferencia = varTipoReferencia;
			
			item.Descripcion = varDescripcion;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.Rowguid = varRowguid;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varReferenciaComercialId,int varRegistroId,string varTipoReferencia,string varDescripcion,DateTime varFechaModificacion,Guid varRowguid)
		{
			ReferenciasComerciales item = new ReferenciasComerciales();
			
				item.ReferenciaComercialId = varReferenciaComercialId;
			
				item.RegistroId = varRegistroId;
			
				item.TipoReferencia = varTipoReferencia;
			
				item.Descripcion = varDescripcion;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.Rowguid = varRowguid;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ReferenciaComercialIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RegistroIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoReferenciaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ReferenciaComercialId = @"ReferenciaComercialId";
			 public static string RegistroId = @"RegistroId";
			 public static string TipoReferencia = @"TipoReferencia";
			 public static string Descripcion = @"Descripcion";
			 public static string FechaModificacion = @"FechaModificacion";
			 public static string Rowguid = @"rowguid";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
