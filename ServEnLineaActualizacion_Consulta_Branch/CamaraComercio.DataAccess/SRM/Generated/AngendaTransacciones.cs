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
	/// Strongly-typed collection for the AngendaTransacciones class.
	/// </summary>
    [Serializable]
	public partial class AngendaTransaccionesCollection : ActiveList<AngendaTransacciones, AngendaTransaccionesCollection>
	{	   
		public AngendaTransaccionesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AngendaTransaccionesCollection</returns>
		public AngendaTransaccionesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AngendaTransacciones o = this[i];
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
	/// This is an ActiveRecord class which wraps the AngendaTransacciones table.
	/// </summary>
	[Serializable]
	public partial class AngendaTransacciones : ActiveRecord<AngendaTransacciones>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AngendaTransacciones()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AngendaTransacciones(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AngendaTransacciones(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AngendaTransacciones(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("AngendaTransacciones", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Scheduler";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
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
				
				TableSchema.TableColumn colvarAgendaId = new TableSchema.TableColumn(schema);
				colvarAgendaId.ColumnName = "AgendaId";
				colvarAgendaId.DataType = DbType.Int32;
				colvarAgendaId.MaxLength = 0;
				colvarAgendaId.AutoIncrement = false;
				colvarAgendaId.IsNullable = false;
				colvarAgendaId.IsPrimaryKey = false;
				colvarAgendaId.IsForeignKey = true;
				colvarAgendaId.IsReadOnly = false;
				colvarAgendaId.DefaultSetting = @"";
				
					colvarAgendaId.ForeignKeyTableName = "Agenda";
				schema.Columns.Add(colvarAgendaId);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("AngendaTransacciones",schema);
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
		  
		[XmlAttribute("AgendaId")]
		[Bindable(true)]
		public int AgendaId 
		{
			get { return GetColumnValue<int>(Columns.AgendaId); }
			set { SetColumnValue(Columns.AgendaId, value); }
		}
		  
		[XmlAttribute("TransaccionId")]
		[Bindable(true)]
		public int TransaccionId 
		{
			get { return GetColumnValue<int>(Columns.TransaccionId); }
			set { SetColumnValue(Columns.TransaccionId, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Agenda ActiveRecord object related to this AngendaTransacciones
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Agenda Agenda
		{
			get { return CamaraComercio.DataAccess.SRM.Agenda.FetchByID(this.AgendaId); }
			set { SetColumnValue("AgendaId", value.AgendaId); }
		}
		
		
		/// <summary>
		/// Returns a Transacciones ActiveRecord object related to this AngendaTransacciones
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
		public static void Insert(int varAgendaId,int varTransaccionId)
		{
			AngendaTransacciones item = new AngendaTransacciones();
			
			item.AgendaId = varAgendaId;
			
			item.TransaccionId = varTransaccionId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varAgendaId,int varTransaccionId)
		{
			AngendaTransacciones item = new AngendaTransacciones();
			
				item.Id = varId;
			
				item.AgendaId = varAgendaId;
			
				item.TransaccionId = varTransaccionId;
			
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
        
        
        
        public static TableSchema.TableColumn AgendaIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TransaccionIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string AgendaId = @"AgendaId";
			 public static string TransaccionId = @"TransaccionId";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
