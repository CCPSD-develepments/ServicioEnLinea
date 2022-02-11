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
namespace CamaraComercio.DataAccess.Comun
{
	/// <summary>
	/// Strongly-typed collection for the TipoReglaDocumento class.
	/// </summary>
    [Serializable]
	public partial class TipoReglaDocumentoCollection : ActiveList<TipoReglaDocumento, TipoReglaDocumentoCollection>
	{	   
		public TipoReglaDocumentoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TipoReglaDocumentoCollection</returns>
		public TipoReglaDocumentoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TipoReglaDocumento o = this[i];
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
	/// This is an ActiveRecord class which wraps the TipoReglaDocumento table.
	/// </summary>
	[Serializable]
	public partial class TipoReglaDocumento : ActiveRecord<TipoReglaDocumento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TipoReglaDocumento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TipoReglaDocumento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TipoReglaDocumento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TipoReglaDocumento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TipoReglaDocumento", TableType.Table, DataService.GetInstance("ComunProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTipoReglaDocumentoId = new TableSchema.TableColumn(schema);
				colvarTipoReglaDocumentoId.ColumnName = "TipoReglaDocumentoId";
				colvarTipoReglaDocumentoId.DataType = DbType.Int32;
				colvarTipoReglaDocumentoId.MaxLength = 0;
				colvarTipoReglaDocumentoId.AutoIncrement = false;
				colvarTipoReglaDocumentoId.IsNullable = false;
				colvarTipoReglaDocumentoId.IsPrimaryKey = true;
				colvarTipoReglaDocumentoId.IsForeignKey = false;
				colvarTipoReglaDocumentoId.IsReadOnly = false;
				colvarTipoReglaDocumentoId.DefaultSetting = @"";
				colvarTipoReglaDocumentoId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoReglaDocumentoId);
				
				TableSchema.TableColumn colvarTipoDocumentoId = new TableSchema.TableColumn(schema);
				colvarTipoDocumentoId.ColumnName = "TipoDocumentoId";
				colvarTipoDocumentoId.DataType = DbType.Int32;
				colvarTipoDocumentoId.MaxLength = 0;
				colvarTipoDocumentoId.AutoIncrement = false;
				colvarTipoDocumentoId.IsNullable = false;
				colvarTipoDocumentoId.IsPrimaryKey = false;
				colvarTipoDocumentoId.IsForeignKey = true;
				colvarTipoDocumentoId.IsReadOnly = false;
				colvarTipoDocumentoId.DefaultSetting = @"";
				
					colvarTipoDocumentoId.ForeignKeyTableName = "TipoDocumento";
				schema.Columns.Add(colvarTipoDocumentoId);
				
				TableSchema.TableColumn colvarTipoReglaId = new TableSchema.TableColumn(schema);
				colvarTipoReglaId.ColumnName = "TipoReglaId";
				colvarTipoReglaId.DataType = DbType.Int32;
				colvarTipoReglaId.MaxLength = 0;
				colvarTipoReglaId.AutoIncrement = false;
				colvarTipoReglaId.IsNullable = false;
				colvarTipoReglaId.IsPrimaryKey = false;
				colvarTipoReglaId.IsForeignKey = true;
				colvarTipoReglaId.IsReadOnly = false;
				colvarTipoReglaId.DefaultSetting = @"";
				
					colvarTipoReglaId.ForeignKeyTableName = "TipoRegla";
				schema.Columns.Add(colvarTipoReglaId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ComunProvider"].AddSchema("TipoReglaDocumento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TipoReglaDocumentoId")]
		[Bindable(true)]
		public int TipoReglaDocumentoId 
		{
			get { return GetColumnValue<int>(Columns.TipoReglaDocumentoId); }
			set { SetColumnValue(Columns.TipoReglaDocumentoId, value); }
		}
		  
		[XmlAttribute("TipoDocumentoId")]
		[Bindable(true)]
		public int TipoDocumentoId 
		{
			get { return GetColumnValue<int>(Columns.TipoDocumentoId); }
			set { SetColumnValue(Columns.TipoDocumentoId, value); }
		}
		  
		[XmlAttribute("TipoReglaId")]
		[Bindable(true)]
		public int TipoReglaId 
		{
			get { return GetColumnValue<int>(Columns.TipoReglaId); }
			set { SetColumnValue(Columns.TipoReglaId, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a TipoDocumento ActiveRecord object related to this TipoReglaDocumento
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.Comun.TipoDocumento TipoDocumento
		{
			get { return CamaraComercio.DataAccess.Comun.TipoDocumento.FetchByID(this.TipoDocumentoId); }
			set { SetColumnValue("TipoDocumentoId", value.TipoDocumentoId); }
		}
		
		
		/// <summary>
		/// Returns a TipoRegla ActiveRecord object related to this TipoReglaDocumento
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.Comun.TipoRegla TipoRegla
		{
			get { return CamaraComercio.DataAccess.Comun.TipoRegla.FetchByID(this.TipoReglaId); }
			set { SetColumnValue("TipoReglaId", value.TipoReglaId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTipoReglaDocumentoId,int varTipoDocumentoId,int varTipoReglaId)
		{
			TipoReglaDocumento item = new TipoReglaDocumento();
			
			item.TipoReglaDocumentoId = varTipoReglaDocumentoId;
			
			item.TipoDocumentoId = varTipoDocumentoId;
			
			item.TipoReglaId = varTipoReglaId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTipoReglaDocumentoId,int varTipoDocumentoId,int varTipoReglaId)
		{
			TipoReglaDocumento item = new TipoReglaDocumento();
			
				item.TipoReglaDocumentoId = varTipoReglaDocumentoId;
			
				item.TipoDocumentoId = varTipoDocumentoId;
			
				item.TipoReglaId = varTipoReglaId;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TipoReglaDocumentoIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocumentoIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoReglaIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TipoReglaDocumentoId = @"TipoReglaDocumentoId";
			 public static string TipoDocumentoId = @"TipoDocumentoId";
			 public static string TipoReglaId = @"TipoReglaId";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
