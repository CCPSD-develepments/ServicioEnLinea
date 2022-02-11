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
	/// Strongly-typed collection for the TipoDocumentoRegla class.
	/// </summary>
    [Serializable]
	public partial class TipoDocumentoReglaCollection : ActiveList<TipoDocumentoRegla, TipoDocumentoReglaCollection>
	{	   
		public TipoDocumentoReglaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TipoDocumentoReglaCollection</returns>
		public TipoDocumentoReglaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TipoDocumentoRegla o = this[i];
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
	/// This is an ActiveRecord class which wraps the TipoDocumentoRegla table.
	/// </summary>
	[Serializable]
	public partial class TipoDocumentoRegla : ActiveRecord<TipoDocumentoRegla>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TipoDocumentoRegla()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TipoDocumentoRegla(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TipoDocumentoRegla(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TipoDocumentoRegla(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TipoDocumentoRegla", TableType.Table, DataService.GetInstance("ComunProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTipoDocumentoReglaId = new TableSchema.TableColumn(schema);
				colvarTipoDocumentoReglaId.ColumnName = "TipoDocumentoReglaId";
				colvarTipoDocumentoReglaId.DataType = DbType.Int32;
				colvarTipoDocumentoReglaId.MaxLength = 0;
				colvarTipoDocumentoReglaId.AutoIncrement = true;
				colvarTipoDocumentoReglaId.IsNullable = false;
				colvarTipoDocumentoReglaId.IsPrimaryKey = true;
				colvarTipoDocumentoReglaId.IsForeignKey = false;
				colvarTipoDocumentoReglaId.IsReadOnly = false;
				colvarTipoDocumentoReglaId.DefaultSetting = @"";
				colvarTipoDocumentoReglaId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocumentoReglaId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ComunProvider"].AddSchema("TipoDocumentoRegla",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TipoDocumentoReglaId")]
		[Bindable(true)]
		public int TipoDocumentoReglaId 
		{
			get { return GetColumnValue<int>(Columns.TipoDocumentoReglaId); }
			set { SetColumnValue(Columns.TipoDocumentoReglaId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion)
		{
			TipoDocumentoRegla item = new TipoDocumentoRegla();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTipoDocumentoReglaId,string varDescripcion)
		{
			TipoDocumentoRegla item = new TipoDocumentoRegla();
			
				item.TipoDocumentoReglaId = varTipoDocumentoReglaId;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TipoDocumentoReglaIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TipoDocumentoReglaId = @"TipoDocumentoReglaId";
			 public static string Descripcion = @"Descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
