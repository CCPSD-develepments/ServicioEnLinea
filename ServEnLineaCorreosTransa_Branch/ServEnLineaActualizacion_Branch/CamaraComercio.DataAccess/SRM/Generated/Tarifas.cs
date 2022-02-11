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
	/// Strongly-typed collection for the Tarifas class.
	/// </summary>
    [Serializable]
	public partial class TarifasCollection : ActiveList<Tarifas, TarifasCollection>
	{	   
		public TarifasCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TarifasCollection</returns>
		public TarifasCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Tarifas o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tarifas table.
	/// </summary>
	[Serializable]
	public partial class Tarifas : ActiveRecord<Tarifas>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Tarifas()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Tarifas(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Tarifas(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Tarifas(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tarifas", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTarifaId = new TableSchema.TableColumn(schema);
				colvarTarifaId.ColumnName = "TarifaId";
				colvarTarifaId.DataType = DbType.Int32;
				colvarTarifaId.MaxLength = 0;
				colvarTarifaId.AutoIncrement = true;
				colvarTarifaId.IsNullable = false;
				colvarTarifaId.IsPrimaryKey = true;
				colvarTarifaId.IsForeignKey = false;
				colvarTarifaId.IsReadOnly = false;
				colvarTarifaId.DefaultSetting = @"";
				colvarTarifaId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTarifaId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarMontoInicial = new TableSchema.TableColumn(schema);
				colvarMontoInicial.ColumnName = "MontoInicial";
				colvarMontoInicial.DataType = DbType.Decimal;
				colvarMontoInicial.MaxLength = 0;
				colvarMontoInicial.AutoIncrement = false;
				colvarMontoInicial.IsNullable = true;
				colvarMontoInicial.IsPrimaryKey = false;
				colvarMontoInicial.IsForeignKey = false;
				colvarMontoInicial.IsReadOnly = false;
				colvarMontoInicial.DefaultSetting = @"";
				colvarMontoInicial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoInicial);
				
				TableSchema.TableColumn colvarMontoFinal = new TableSchema.TableColumn(schema);
				colvarMontoFinal.ColumnName = "MontoFinal";
				colvarMontoFinal.DataType = DbType.Decimal;
				colvarMontoFinal.MaxLength = 0;
				colvarMontoFinal.AutoIncrement = false;
				colvarMontoFinal.IsNullable = true;
				colvarMontoFinal.IsPrimaryKey = false;
				colvarMontoFinal.IsForeignKey = false;
				colvarMontoFinal.IsReadOnly = false;
				colvarMontoFinal.DefaultSetting = @"";
				colvarMontoFinal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoFinal);
				
				TableSchema.TableColumn colvarCostoContitucion = new TableSchema.TableColumn(schema);
				colvarCostoContitucion.ColumnName = "CostoContitucion";
				colvarCostoContitucion.DataType = DbType.Decimal;
				colvarCostoContitucion.MaxLength = 0;
				colvarCostoContitucion.AutoIncrement = false;
				colvarCostoContitucion.IsNullable = false;
				colvarCostoContitucion.IsPrimaryKey = false;
				colvarCostoContitucion.IsForeignKey = false;
				colvarCostoContitucion.IsReadOnly = false;
				colvarCostoContitucion.DefaultSetting = @"";
				colvarCostoContitucion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoContitucion);
				
				TableSchema.TableColumn colvarCostoModificacion = new TableSchema.TableColumn(schema);
				colvarCostoModificacion.ColumnName = "CostoModificacion";
				colvarCostoModificacion.DataType = DbType.Decimal;
				colvarCostoModificacion.MaxLength = 0;
				colvarCostoModificacion.AutoIncrement = false;
				colvarCostoModificacion.IsNullable = false;
				colvarCostoModificacion.IsPrimaryKey = false;
				colvarCostoModificacion.IsForeignKey = false;
				colvarCostoModificacion.IsReadOnly = false;
				colvarCostoModificacion.DefaultSetting = @"";
				colvarCostoModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoModificacion);
				
				TableSchema.TableColumn colvarCostoModificacionNeto = new TableSchema.TableColumn(schema);
				colvarCostoModificacionNeto.ColumnName = "CostoModificacionNeto";
				colvarCostoModificacionNeto.DataType = DbType.Decimal;
				colvarCostoModificacionNeto.MaxLength = 0;
				colvarCostoModificacionNeto.AutoIncrement = false;
				colvarCostoModificacionNeto.IsNullable = true;
				colvarCostoModificacionNeto.IsPrimaryKey = false;
				colvarCostoModificacionNeto.IsForeignKey = false;
				colvarCostoModificacionNeto.IsReadOnly = true;
				colvarCostoModificacionNeto.DefaultSetting = @"";
				colvarCostoModificacionNeto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoModificacionNeto);
				
				TableSchema.TableColumn colvarCostoRenovacion = new TableSchema.TableColumn(schema);
				colvarCostoRenovacion.ColumnName = "CostoRenovacion";
				colvarCostoRenovacion.DataType = DbType.Decimal;
				colvarCostoRenovacion.MaxLength = 0;
				colvarCostoRenovacion.AutoIncrement = false;
				colvarCostoRenovacion.IsNullable = false;
				colvarCostoRenovacion.IsPrimaryKey = false;
				colvarCostoRenovacion.IsForeignKey = false;
				colvarCostoRenovacion.IsReadOnly = false;
				colvarCostoRenovacion.DefaultSetting = @"";
				colvarCostoRenovacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoRenovacion);
				
				TableSchema.TableColumn colvarCostoRenovacionNeto = new TableSchema.TableColumn(schema);
				colvarCostoRenovacionNeto.ColumnName = "CostoRenovacionNeto";
				colvarCostoRenovacionNeto.DataType = DbType.Decimal;
				colvarCostoRenovacionNeto.MaxLength = 0;
				colvarCostoRenovacionNeto.AutoIncrement = false;
				colvarCostoRenovacionNeto.IsNullable = true;
				colvarCostoRenovacionNeto.IsPrimaryKey = false;
				colvarCostoRenovacionNeto.IsForeignKey = false;
				colvarCostoRenovacionNeto.IsReadOnly = true;
				colvarCostoRenovacionNeto.DefaultSetting = @"";
				colvarCostoRenovacionNeto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoRenovacionNeto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("Tarifas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TarifaId")]
		[Bindable(true)]
		public int TarifaId 
		{
			get { return GetColumnValue<int>(Columns.TarifaId); }
			set { SetColumnValue(Columns.TarifaId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("MontoInicial")]
		[Bindable(true)]
		public decimal? MontoInicial 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoInicial); }
			set { SetColumnValue(Columns.MontoInicial, value); }
		}
		  
		[XmlAttribute("MontoFinal")]
		[Bindable(true)]
		public decimal? MontoFinal 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoFinal); }
			set { SetColumnValue(Columns.MontoFinal, value); }
		}
		  
		[XmlAttribute("CostoContitucion")]
		[Bindable(true)]
		public decimal CostoContitucion 
		{
			get { return GetColumnValue<decimal>(Columns.CostoContitucion); }
			set { SetColumnValue(Columns.CostoContitucion, value); }
		}
		  
		[XmlAttribute("CostoModificacion")]
		[Bindable(true)]
		public decimal CostoModificacion 
		{
			get { return GetColumnValue<decimal>(Columns.CostoModificacion); }
			set { SetColumnValue(Columns.CostoModificacion, value); }
		}
		  
		[XmlAttribute("CostoModificacionNeto")]
		[Bindable(true)]
		public decimal? CostoModificacionNeto 
		{
			get { return GetColumnValue<decimal?>(Columns.CostoModificacionNeto); }
			set { SetColumnValue(Columns.CostoModificacionNeto, value); }
		}
		  
		[XmlAttribute("CostoRenovacion")]
		[Bindable(true)]
		public decimal CostoRenovacion 
		{
			get { return GetColumnValue<decimal>(Columns.CostoRenovacion); }
			set { SetColumnValue(Columns.CostoRenovacion, value); }
		}
		  
		[XmlAttribute("CostoRenovacionNeto")]
		[Bindable(true)]
		public decimal? CostoRenovacionNeto 
		{
			get { return GetColumnValue<decimal?>(Columns.CostoRenovacionNeto); }
			set { SetColumnValue(Columns.CostoRenovacionNeto, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,decimal? varMontoInicial,decimal? varMontoFinal,decimal varCostoContitucion,decimal varCostoModificacion,decimal? varCostoModificacionNeto,decimal varCostoRenovacion,decimal? varCostoRenovacionNeto)
		{
			Tarifas item = new Tarifas();
			
			item.Descripcion = varDescripcion;
			
			item.MontoInicial = varMontoInicial;
			
			item.MontoFinal = varMontoFinal;
			
			item.CostoContitucion = varCostoContitucion;
			
			item.CostoModificacion = varCostoModificacion;
			
			item.CostoModificacionNeto = varCostoModificacionNeto;
			
			item.CostoRenovacion = varCostoRenovacion;
			
			item.CostoRenovacionNeto = varCostoRenovacionNeto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTarifaId,string varDescripcion,decimal? varMontoInicial,decimal? varMontoFinal,decimal varCostoContitucion,decimal varCostoModificacion,decimal? varCostoModificacionNeto,decimal varCostoRenovacion,decimal? varCostoRenovacionNeto)
		{
			Tarifas item = new Tarifas();
			
				item.TarifaId = varTarifaId;
			
				item.Descripcion = varDescripcion;
			
				item.MontoInicial = varMontoInicial;
			
				item.MontoFinal = varMontoFinal;
			
				item.CostoContitucion = varCostoContitucion;
			
				item.CostoModificacion = varCostoModificacion;
			
				item.CostoModificacionNeto = varCostoModificacionNeto;
			
				item.CostoRenovacion = varCostoRenovacion;
			
				item.CostoRenovacionNeto = varCostoRenovacionNeto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TarifaIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoInicialColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoFinalColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoContitucionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoModificacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoModificacionNetoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoRenovacionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoRenovacionNetoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TarifaId = @"TarifaId";
			 public static string Descripcion = @"Descripcion";
			 public static string MontoInicial = @"MontoInicial";
			 public static string MontoFinal = @"MontoFinal";
			 public static string CostoContitucion = @"CostoContitucion";
			 public static string CostoModificacion = @"CostoModificacion";
			 public static string CostoModificacionNeto = @"CostoModificacionNeto";
			 public static string CostoRenovacion = @"CostoRenovacion";
			 public static string CostoRenovacionNeto = @"CostoRenovacionNeto";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
