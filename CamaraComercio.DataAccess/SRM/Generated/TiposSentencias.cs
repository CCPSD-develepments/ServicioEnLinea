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
	/// Strongly-typed collection for the TiposSentencias class.
	/// </summary>
    [Serializable]
	public partial class TiposSentenciasCollection : ActiveList<TiposSentencias, TiposSentenciasCollection>
	{	   
		public TiposSentenciasCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TiposSentenciasCollection</returns>
		public TiposSentenciasCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TiposSentencias o = this[i];
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
	/// This is an ActiveRecord class which wraps the TiposSentencias table.
	/// </summary>
	[Serializable]
	public partial class TiposSentencias : ActiveRecord<TiposSentencias>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TiposSentencias()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TiposSentencias(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TiposSentencias(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TiposSentencias(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TiposSentencias", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sistema";
				//columns
				
				TableSchema.TableColumn colvarTipoSentenciaId = new TableSchema.TableColumn(schema);
				colvarTipoSentenciaId.ColumnName = "TipoSentenciaId";
				colvarTipoSentenciaId.DataType = DbType.Int32;
				colvarTipoSentenciaId.MaxLength = 0;
				colvarTipoSentenciaId.AutoIncrement = true;
				colvarTipoSentenciaId.IsNullable = false;
				colvarTipoSentenciaId.IsPrimaryKey = true;
				colvarTipoSentenciaId.IsForeignKey = false;
				colvarTipoSentenciaId.IsReadOnly = false;
				colvarTipoSentenciaId.DefaultSetting = @"";
				colvarTipoSentenciaId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoSentenciaId);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("TiposSentencias",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TipoSentenciaId")]
		[Bindable(true)]
		public int TipoSentenciaId 
		{
			get { return GetColumnValue<int>(Columns.TipoSentenciaId); }
			set { SetColumnValue(Columns.TipoSentenciaId, value); }
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
        
		
		public CamaraComercio.DataAccess.SRM.OposicionesCollection OposicionesRecords()
		{
			return new CamaraComercio.DataAccess.SRM.OposicionesCollection().Where(Oposiciones.Columns.TipoSentenciaId, TipoSentenciaId).Load();
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
			TiposSentencias item = new TiposSentencias();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTipoSentenciaId,string varDescripcion)
		{
			TiposSentencias item = new TiposSentencias();
			
				item.TipoSentenciaId = varTipoSentenciaId;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TipoSentenciaIdColumn
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
			 public static string TipoSentenciaId = @"TipoSentenciaId";
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
