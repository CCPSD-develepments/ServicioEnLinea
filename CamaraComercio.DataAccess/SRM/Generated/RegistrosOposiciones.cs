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
	/// Strongly-typed collection for the RegistrosOposiciones class.
	/// </summary>
    [Serializable]
	public partial class RegistrosOposicionesCollection : ActiveList<RegistrosOposiciones, RegistrosOposicionesCollection>
	{	   
		public RegistrosOposicionesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RegistrosOposicionesCollection</returns>
		public RegistrosOposicionesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RegistrosOposiciones o = this[i];
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
	/// This is an ActiveRecord class which wraps the RegistrosOposiciones table.
	/// </summary>
	[Serializable]
	public partial class RegistrosOposiciones : ActiveRecord<RegistrosOposiciones>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RegistrosOposiciones()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RegistrosOposiciones(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RegistrosOposiciones(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RegistrosOposiciones(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RegistrosOposiciones", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sistema";
				//columns
				
				TableSchema.TableColumn colvarRegistroOposicionId = new TableSchema.TableColumn(schema);
				colvarRegistroOposicionId.ColumnName = "RegistroOposicionId";
				colvarRegistroOposicionId.DataType = DbType.Int32;
				colvarRegistroOposicionId.MaxLength = 0;
				colvarRegistroOposicionId.AutoIncrement = true;
				colvarRegistroOposicionId.IsNullable = false;
				colvarRegistroOposicionId.IsPrimaryKey = true;
				colvarRegistroOposicionId.IsForeignKey = false;
				colvarRegistroOposicionId.IsReadOnly = false;
				colvarRegistroOposicionId.DefaultSetting = @"";
				colvarRegistroOposicionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegistroOposicionId);
				
				TableSchema.TableColumn colvarOposicionId = new TableSchema.TableColumn(schema);
				colvarOposicionId.ColumnName = "OposicionId";
				colvarOposicionId.DataType = DbType.Int32;
				colvarOposicionId.MaxLength = 0;
				colvarOposicionId.AutoIncrement = false;
				colvarOposicionId.IsNullable = false;
				colvarOposicionId.IsPrimaryKey = false;
				colvarOposicionId.IsForeignKey = true;
				colvarOposicionId.IsReadOnly = false;
				colvarOposicionId.DefaultSetting = @"";
				
					colvarOposicionId.ForeignKeyTableName = "Oposiciones";
				schema.Columns.Add(colvarOposicionId);
				
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
				
				TableSchema.TableColumn colvarRequirientes = new TableSchema.TableColumn(schema);
				colvarRequirientes.ColumnName = "Requirientes";
				colvarRequirientes.DataType = DbType.AnsiString;
				colvarRequirientes.MaxLength = -1;
				colvarRequirientes.AutoIncrement = false;
				colvarRequirientes.IsNullable = false;
				colvarRequirientes.IsPrimaryKey = false;
				colvarRequirientes.IsForeignKey = false;
				colvarRequirientes.IsReadOnly = false;
				colvarRequirientes.DefaultSetting = @"";
				colvarRequirientes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRequirientes);
				
				TableSchema.TableColumn colvarPrioridad = new TableSchema.TableColumn(schema);
				colvarPrioridad.ColumnName = "Prioridad";
				colvarPrioridad.DataType = DbType.Boolean;
				colvarPrioridad.MaxLength = 0;
				colvarPrioridad.AutoIncrement = false;
				colvarPrioridad.IsNullable = false;
				colvarPrioridad.IsPrimaryKey = false;
				colvarPrioridad.IsForeignKey = false;
				colvarPrioridad.IsReadOnly = false;
				colvarPrioridad.DefaultSetting = @"";
				colvarPrioridad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrioridad);
				
				TableSchema.TableColumn colvarCerrada = new TableSchema.TableColumn(schema);
				colvarCerrada.ColumnName = "Cerrada";
				colvarCerrada.DataType = DbType.Boolean;
				colvarCerrada.MaxLength = 0;
				colvarCerrada.AutoIncrement = false;
				colvarCerrada.IsNullable = false;
				colvarCerrada.IsPrimaryKey = false;
				colvarCerrada.IsForeignKey = false;
				colvarCerrada.IsReadOnly = false;
				colvarCerrada.DefaultSetting = @"";
				colvarCerrada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCerrada);
				
				TableSchema.TableColumn colvarFechaCierre = new TableSchema.TableColumn(schema);
				colvarFechaCierre.ColumnName = "FechaCierre";
				colvarFechaCierre.DataType = DbType.DateTime;
				colvarFechaCierre.MaxLength = 0;
				colvarFechaCierre.AutoIncrement = false;
				colvarFechaCierre.IsNullable = true;
				colvarFechaCierre.IsPrimaryKey = false;
				colvarFechaCierre.IsForeignKey = false;
				colvarFechaCierre.IsReadOnly = false;
				colvarFechaCierre.DefaultSetting = @"";
				colvarFechaCierre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCierre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("RegistrosOposiciones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("RegistroOposicionId")]
		[Bindable(true)]
		public int RegistroOposicionId 
		{
			get { return GetColumnValue<int>(Columns.RegistroOposicionId); }
			set { SetColumnValue(Columns.RegistroOposicionId, value); }
		}
		  
		[XmlAttribute("OposicionId")]
		[Bindable(true)]
		public int OposicionId 
		{
			get { return GetColumnValue<int>(Columns.OposicionId); }
			set { SetColumnValue(Columns.OposicionId, value); }
		}
		  
		[XmlAttribute("RegistroId")]
		[Bindable(true)]
		public int RegistroId 
		{
			get { return GetColumnValue<int>(Columns.RegistroId); }
			set { SetColumnValue(Columns.RegistroId, value); }
		}
		  
		[XmlAttribute("Requirientes")]
		[Bindable(true)]
		public string Requirientes 
		{
			get { return GetColumnValue<string>(Columns.Requirientes); }
			set { SetColumnValue(Columns.Requirientes, value); }
		}
		  
		[XmlAttribute("Prioridad")]
		[Bindable(true)]
		public bool Prioridad 
		{
			get { return GetColumnValue<bool>(Columns.Prioridad); }
			set { SetColumnValue(Columns.Prioridad, value); }
		}
		  
		[XmlAttribute("Cerrada")]
		[Bindable(true)]
		public bool Cerrada 
		{
			get { return GetColumnValue<bool>(Columns.Cerrada); }
			set { SetColumnValue(Columns.Cerrada, value); }
		}
		  
		[XmlAttribute("FechaCierre")]
		[Bindable(true)]
		public DateTime? FechaCierre 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCierre); }
			set { SetColumnValue(Columns.FechaCierre, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Oposiciones ActiveRecord object related to this RegistrosOposiciones
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Oposiciones Oposiciones
		{
			get { return CamaraComercio.DataAccess.SRM.Oposiciones.FetchByID(this.OposicionId); }
			set { SetColumnValue("OposicionId", value.OposicionId); }
		}
		
		
		/// <summary>
		/// Returns a Registros ActiveRecord object related to this RegistrosOposiciones
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
		public static void Insert(int varOposicionId,int varRegistroId,string varRequirientes,bool varPrioridad,bool varCerrada,DateTime? varFechaCierre)
		{
			RegistrosOposiciones item = new RegistrosOposiciones();
			
			item.OposicionId = varOposicionId;
			
			item.RegistroId = varRegistroId;
			
			item.Requirientes = varRequirientes;
			
			item.Prioridad = varPrioridad;
			
			item.Cerrada = varCerrada;
			
			item.FechaCierre = varFechaCierre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varRegistroOposicionId,int varOposicionId,int varRegistroId,string varRequirientes,bool varPrioridad,bool varCerrada,DateTime? varFechaCierre)
		{
			RegistrosOposiciones item = new RegistrosOposiciones();
			
				item.RegistroOposicionId = varRegistroOposicionId;
			
				item.OposicionId = varOposicionId;
			
				item.RegistroId = varRegistroId;
			
				item.Requirientes = varRequirientes;
			
				item.Prioridad = varPrioridad;
			
				item.Cerrada = varCerrada;
			
				item.FechaCierre = varFechaCierre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn RegistroOposicionIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn OposicionIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RegistroIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RequirientesColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrioridadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CerradaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCierreColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string RegistroOposicionId = @"RegistroOposicionId";
			 public static string OposicionId = @"OposicionId";
			 public static string RegistroId = @"RegistroId";
			 public static string Requirientes = @"Requirientes";
			 public static string Prioridad = @"Prioridad";
			 public static string Cerrada = @"Cerrada";
			 public static string FechaCierre = @"FechaCierre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
