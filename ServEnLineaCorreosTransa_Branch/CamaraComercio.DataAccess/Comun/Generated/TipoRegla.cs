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
	/// Strongly-typed collection for the TipoRegla class.
	/// </summary>
    [Serializable]
	public partial class TipoReglaCollection : ActiveList<TipoRegla, TipoReglaCollection>
	{	   
		public TipoReglaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TipoReglaCollection</returns>
		public TipoReglaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TipoRegla o = this[i];
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
	/// This is an ActiveRecord class which wraps the TipoRegla table.
	/// </summary>
	[Serializable]
	public partial class TipoRegla : ActiveRecord<TipoRegla>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TipoRegla()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TipoRegla(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TipoRegla(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TipoRegla(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TipoRegla", TableType.Table, DataService.GetInstance("ComunProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTipoReglaId = new TableSchema.TableColumn(schema);
				colvarTipoReglaId.ColumnName = "TipoReglaId";
				colvarTipoReglaId.DataType = DbType.Int32;
				colvarTipoReglaId.MaxLength = 0;
				colvarTipoReglaId.AutoIncrement = true;
				colvarTipoReglaId.IsNullable = false;
				colvarTipoReglaId.IsPrimaryKey = true;
				colvarTipoReglaId.IsForeignKey = false;
				colvarTipoReglaId.IsReadOnly = false;
				colvarTipoReglaId.DefaultSetting = @"";
				colvarTipoReglaId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoReglaId);
				
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
				DataService.Providers["ComunProvider"].AddSchema("TipoRegla",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TipoReglaId")]
		[Bindable(true)]
		public int TipoReglaId 
		{
			get { return GetColumnValue<int>(Columns.TipoReglaId); }
			set { SetColumnValue(Columns.TipoReglaId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CamaraComercio.DataAccess.Comun.TipoReglaDocumentoCollection TipoReglaDocumentoRecords()
		{
			return new CamaraComercio.DataAccess.Comun.TipoReglaDocumentoCollection().Where(TipoReglaDocumento.Columns.TipoReglaId, TipoReglaId).Load();
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
			TipoRegla item = new TipoRegla();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTipoReglaId,string varDescripcion)
		{
			TipoRegla item = new TipoRegla();
			
				item.TipoReglaId = varTipoReglaId;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TipoReglaIdColumn
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
			 public static string TipoReglaId = @"TipoReglaId";
			 public static string Descripcion = @"Descripcion";
						
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
