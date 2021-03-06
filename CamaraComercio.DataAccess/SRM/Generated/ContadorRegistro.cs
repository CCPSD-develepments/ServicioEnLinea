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
	/// Strongly-typed collection for the ContadorRegistro class.
	/// </summary>
    [Serializable]
	public partial class ContadorRegistroCollection : ActiveList<ContadorRegistro, ContadorRegistroCollection>
	{	   
		public ContadorRegistroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ContadorRegistroCollection</returns>
		public ContadorRegistroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ContadorRegistro o = this[i];
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
	/// This is an ActiveRecord class which wraps the ContadorRegistro table.
	/// </summary>
	[Serializable]
	public partial class ContadorRegistro : ActiveRecord<ContadorRegistro>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ContadorRegistro()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ContadorRegistro(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ContadorRegistro(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ContadorRegistro(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ContadorRegistro", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sistema";
				//columns
				
				TableSchema.TableColumn colvarProvinciaId = new TableSchema.TableColumn(schema);
				colvarProvinciaId.ColumnName = "ProvinciaId";
				colvarProvinciaId.DataType = DbType.Int32;
				colvarProvinciaId.MaxLength = 0;
				colvarProvinciaId.AutoIncrement = false;
				colvarProvinciaId.IsNullable = false;
				colvarProvinciaId.IsPrimaryKey = true;
				colvarProvinciaId.IsForeignKey = false;
				colvarProvinciaId.IsReadOnly = false;
				colvarProvinciaId.DefaultSetting = @"";
				colvarProvinciaId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProvinciaId);
				
				TableSchema.TableColumn colvarTag = new TableSchema.TableColumn(schema);
				colvarTag.ColumnName = "Tag";
				colvarTag.DataType = DbType.AnsiString;
				colvarTag.MaxLength = 15;
				colvarTag.AutoIncrement = false;
				colvarTag.IsNullable = false;
				colvarTag.IsPrimaryKey = true;
				colvarTag.IsForeignKey = false;
				colvarTag.IsReadOnly = false;
				colvarTag.DefaultSetting = @"";
				colvarTag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTag);
				
				TableSchema.TableColumn colvarNoRegistro = new TableSchema.TableColumn(schema);
				colvarNoRegistro.ColumnName = "NoRegistro";
				colvarNoRegistro.DataType = DbType.Int32;
				colvarNoRegistro.MaxLength = 0;
				colvarNoRegistro.AutoIncrement = false;
				colvarNoRegistro.IsNullable = false;
				colvarNoRegistro.IsPrimaryKey = false;
				colvarNoRegistro.IsForeignKey = false;
				colvarNoRegistro.IsReadOnly = false;
				colvarNoRegistro.DefaultSetting = @"";
				colvarNoRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNoRegistro);
				
				TableSchema.TableColumn colvarLimiteContador = new TableSchema.TableColumn(schema);
				colvarLimiteContador.ColumnName = "LimiteContador";
				colvarLimiteContador.DataType = DbType.Int32;
				colvarLimiteContador.MaxLength = 0;
				colvarLimiteContador.AutoIncrement = false;
				colvarLimiteContador.IsNullable = true;
				colvarLimiteContador.IsPrimaryKey = false;
				colvarLimiteContador.IsForeignKey = false;
				colvarLimiteContador.IsReadOnly = false;
				colvarLimiteContador.DefaultSetting = @"";
				colvarLimiteContador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLimiteContador);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("ContadorRegistro",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProvinciaId")]
		[Bindable(true)]
		public int ProvinciaId 
		{
			get { return GetColumnValue<int>(Columns.ProvinciaId); }
			set { SetColumnValue(Columns.ProvinciaId, value); }
		}
		  
		[XmlAttribute("Tag")]
		[Bindable(true)]
		public string Tag 
		{
			get { return GetColumnValue<string>(Columns.Tag); }
			set { SetColumnValue(Columns.Tag, value); }
		}
		  
		[XmlAttribute("NoRegistro")]
		[Bindable(true)]
		public int NoRegistro 
		{
			get { return GetColumnValue<int>(Columns.NoRegistro); }
			set { SetColumnValue(Columns.NoRegistro, value); }
		}
		  
		[XmlAttribute("LimiteContador")]
		[Bindable(true)]
		public int? LimiteContador 
		{
			get { return GetColumnValue<int?>(Columns.LimiteContador); }
			set { SetColumnValue(Columns.LimiteContador, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProvinciaId,string varTag,int varNoRegistro,int? varLimiteContador)
		{
			ContadorRegistro item = new ContadorRegistro();
			
			item.ProvinciaId = varProvinciaId;
			
			item.Tag = varTag;
			
			item.NoRegistro = varNoRegistro;
			
			item.LimiteContador = varLimiteContador;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProvinciaId,string varTag,int varNoRegistro,int? varLimiteContador)
		{
			ContadorRegistro item = new ContadorRegistro();
			
				item.ProvinciaId = varProvinciaId;
			
				item.Tag = varTag;
			
				item.NoRegistro = varNoRegistro;
			
				item.LimiteContador = varLimiteContador;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProvinciaIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TagColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NoRegistroColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LimiteContadorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ProvinciaId = @"ProvinciaId";
			 public static string Tag = @"Tag";
			 public static string NoRegistro = @"NoRegistro";
			 public static string LimiteContador = @"LimiteContador";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
