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
	/// Strongly-typed collection for the TransaccionesSociedades class.
	/// </summary>
    [Serializable]
	public partial class TransaccionesSociedadesCollection : ActiveList<TransaccionesSociedades, TransaccionesSociedadesCollection>
	{	   
		public TransaccionesSociedadesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TransaccionesSociedadesCollection</returns>
		public TransaccionesSociedadesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TransaccionesSociedades o = this[i];
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
	/// This is an ActiveRecord class which wraps the TransaccionesSociedades table.
	/// </summary>
	[Serializable]
	public partial class TransaccionesSociedades : ActiveRecord<TransaccionesSociedades>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TransaccionesSociedades()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TransaccionesSociedades(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TransaccionesSociedades(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TransaccionesSociedades(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TransaccionesSociedades", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Transaccion";
				//columns
				
				TableSchema.TableColumn colvarTransaccionId = new TableSchema.TableColumn(schema);
				colvarTransaccionId.ColumnName = "TransaccionId";
				colvarTransaccionId.DataType = DbType.Int32;
				colvarTransaccionId.MaxLength = 0;
				colvarTransaccionId.AutoIncrement = false;
				colvarTransaccionId.IsNullable = false;
				colvarTransaccionId.IsPrimaryKey = true;
				colvarTransaccionId.IsForeignKey = true;
				colvarTransaccionId.IsReadOnly = false;
				colvarTransaccionId.DefaultSetting = @"";
				
					colvarTransaccionId.ForeignKeyTableName = "Transacciones";
				schema.Columns.Add(colvarTransaccionId);
				
				TableSchema.TableColumn colvarSociedadId = new TableSchema.TableColumn(schema);
				colvarSociedadId.ColumnName = "SociedadId";
				colvarSociedadId.DataType = DbType.Int32;
				colvarSociedadId.MaxLength = 0;
				colvarSociedadId.AutoIncrement = false;
				colvarSociedadId.IsNullable = false;
				colvarSociedadId.IsPrimaryKey = false;
				colvarSociedadId.IsForeignKey = false;
				colvarSociedadId.IsReadOnly = false;
				colvarSociedadId.DefaultSetting = @"";
				colvarSociedadId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSociedadId);
				
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
				DataService.Providers["SrmProvider"].AddSchema("TransaccionesSociedades",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TransaccionId")]
		[Bindable(true)]
		public int TransaccionId 
		{
			get { return GetColumnValue<int>(Columns.TransaccionId); }
			set { SetColumnValue(Columns.TransaccionId, value); }
		}
		  
		[XmlAttribute("SociedadId")]
		[Bindable(true)]
		public int SociedadId 
		{
			get { return GetColumnValue<int>(Columns.SociedadId); }
			set { SetColumnValue(Columns.SociedadId, value); }
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
		/// Returns a Transacciones ActiveRecord object related to this TransaccionesSociedades
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
		public static void Insert(int varTransaccionId,int varSociedadId,DateTime varFechaModificacion,Guid varRowguid)
		{
			TransaccionesSociedades item = new TransaccionesSociedades();
			
			item.TransaccionId = varTransaccionId;
			
			item.SociedadId = varSociedadId;
			
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
		public static void Update(int varTransaccionId,int varSociedadId,DateTime varFechaModificacion,Guid varRowguid)
		{
			TransaccionesSociedades item = new TransaccionesSociedades();
			
				item.TransaccionId = varTransaccionId;
			
				item.SociedadId = varSociedadId;
			
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
        
        
        public static TableSchema.TableColumn TransaccionIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SociedadIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TransaccionId = @"TransaccionId";
			 public static string SociedadId = @"SociedadId";
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
