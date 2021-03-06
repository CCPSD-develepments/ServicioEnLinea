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
	/// Strongly-typed collection for the ModulosRoles class.
	/// </summary>
    [Serializable]
	public partial class ModulosRolesCollection : ActiveList<ModulosRoles, ModulosRolesCollection>
	{	   
		public ModulosRolesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ModulosRolesCollection</returns>
		public ModulosRolesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ModulosRoles o = this[i];
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
	/// This is an ActiveRecord class which wraps the ModulosRoles table.
	/// </summary>
	[Serializable]
	public partial class ModulosRoles : ActiveRecord<ModulosRoles>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ModulosRoles()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ModulosRoles(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ModulosRoles(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ModulosRoles(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ModulosRoles", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
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
				
				TableSchema.TableColumn colvarModuloId = new TableSchema.TableColumn(schema);
				colvarModuloId.ColumnName = "ModuloId";
				colvarModuloId.DataType = DbType.Int32;
				colvarModuloId.MaxLength = 0;
				colvarModuloId.AutoIncrement = false;
				colvarModuloId.IsNullable = false;
				colvarModuloId.IsPrimaryKey = false;
				colvarModuloId.IsForeignKey = true;
				colvarModuloId.IsReadOnly = false;
				colvarModuloId.DefaultSetting = @"";
				
					colvarModuloId.ForeignKeyTableName = "Modulos";
				schema.Columns.Add(colvarModuloId);
				
				TableSchema.TableColumn colvarRolId = new TableSchema.TableColumn(schema);
				colvarRolId.ColumnName = "RolId";
				colvarRolId.DataType = DbType.Int32;
				colvarRolId.MaxLength = 0;
				colvarRolId.AutoIncrement = false;
				colvarRolId.IsNullable = false;
				colvarRolId.IsPrimaryKey = false;
				colvarRolId.IsForeignKey = true;
				colvarRolId.IsReadOnly = false;
				colvarRolId.DefaultSetting = @"";
				
					colvarRolId.ForeignKeyTableName = "Roles";
				schema.Columns.Add(colvarRolId);
				
				TableSchema.TableColumn colvarTipoAcceso = new TableSchema.TableColumn(schema);
				colvarTipoAcceso.ColumnName = "TipoAcceso";
				colvarTipoAcceso.DataType = DbType.AnsiString;
				colvarTipoAcceso.MaxLength = 2;
				colvarTipoAcceso.AutoIncrement = false;
				colvarTipoAcceso.IsNullable = true;
				colvarTipoAcceso.IsPrimaryKey = false;
				colvarTipoAcceso.IsForeignKey = false;
				colvarTipoAcceso.IsReadOnly = false;
				
						colvarTipoAcceso.DefaultSetting = @"('NA')";
				colvarTipoAcceso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoAcceso);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("ModulosRoles",schema);
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
		  
		[XmlAttribute("ModuloId")]
		[Bindable(true)]
		public int ModuloId 
		{
			get { return GetColumnValue<int>(Columns.ModuloId); }
			set { SetColumnValue(Columns.ModuloId, value); }
		}
		  
		[XmlAttribute("RolId")]
		[Bindable(true)]
		public int RolId 
		{
			get { return GetColumnValue<int>(Columns.RolId); }
			set { SetColumnValue(Columns.RolId, value); }
		}
		  
		[XmlAttribute("TipoAcceso")]
		[Bindable(true)]
		public string TipoAcceso 
		{
			get { return GetColumnValue<string>(Columns.TipoAcceso); }
			set { SetColumnValue(Columns.TipoAcceso, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Modulos ActiveRecord object related to this ModulosRoles
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Modulos Modulos
		{
			get { return CamaraComercio.DataAccess.SRM.Modulos.FetchByID(this.ModuloId); }
			set { SetColumnValue("ModuloId", value.ModuloId); }
		}
		
		
		/// <summary>
		/// Returns a Roles ActiveRecord object related to this ModulosRoles
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Roles Roles
		{
			get { return CamaraComercio.DataAccess.SRM.Roles.FetchByID(this.RolId); }
			set { SetColumnValue("RolId", value.RolId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varModuloId,int varRolId,string varTipoAcceso)
		{
			ModulosRoles item = new ModulosRoles();
			
			item.ModuloId = varModuloId;
			
			item.RolId = varRolId;
			
			item.TipoAcceso = varTipoAcceso;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varModuloId,int varRolId,string varTipoAcceso)
		{
			ModulosRoles item = new ModulosRoles();
			
				item.Id = varId;
			
				item.ModuloId = varModuloId;
			
				item.RolId = varRolId;
			
				item.TipoAcceso = varTipoAcceso;
			
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
        
        
        
        public static TableSchema.TableColumn ModuloIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RolIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoAccesoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string ModuloId = @"ModuloId";
			 public static string RolId = @"RolId";
			 public static string TipoAcceso = @"TipoAcceso";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
