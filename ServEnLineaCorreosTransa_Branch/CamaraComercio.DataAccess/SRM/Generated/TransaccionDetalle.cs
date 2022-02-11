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
	/// Strongly-typed collection for the TransaccionDetalle class.
	/// </summary>
    [Serializable]
	public partial class TransaccionDetalleCollection : ActiveList<TransaccionDetalle, TransaccionDetalleCollection>
	{	   
		public TransaccionDetalleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TransaccionDetalleCollection</returns>
		public TransaccionDetalleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TransaccionDetalle o = this[i];
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
	/// This is an ActiveRecord class which wraps the TransaccionDetalle table.
	/// </summary>
	[Serializable]
	public partial class TransaccionDetalle : ActiveRecord<TransaccionDetalle>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TransaccionDetalle()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TransaccionDetalle(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TransaccionDetalle(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TransaccionDetalle(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TransaccionDetalle", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Transaccion";
				//columns
				
				TableSchema.TableColumn colvarTransaccionDetalles = new TableSchema.TableColumn(schema);
				colvarTransaccionDetalles.ColumnName = "TransaccionDetalles";
				colvarTransaccionDetalles.DataType = DbType.Int32;
				colvarTransaccionDetalles.MaxLength = 0;
				colvarTransaccionDetalles.AutoIncrement = true;
				colvarTransaccionDetalles.IsNullable = false;
				colvarTransaccionDetalles.IsPrimaryKey = true;
				colvarTransaccionDetalles.IsForeignKey = false;
				colvarTransaccionDetalles.IsReadOnly = false;
				colvarTransaccionDetalles.DefaultSetting = @"";
				colvarTransaccionDetalles.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransaccionDetalles);
				
				TableSchema.TableColumn colvarCuenta = new TableSchema.TableColumn(schema);
				colvarCuenta.ColumnName = "Cuenta";
				colvarCuenta.DataType = DbType.AnsiString;
				colvarCuenta.MaxLength = 25;
				colvarCuenta.AutoIncrement = false;
				colvarCuenta.IsNullable = false;
				colvarCuenta.IsPrimaryKey = false;
				colvarCuenta.IsForeignKey = false;
				colvarCuenta.IsReadOnly = false;
				colvarCuenta.DefaultSetting = @"";
				colvarCuenta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuenta);
				
				TableSchema.TableColumn colvarDetalle = new TableSchema.TableColumn(schema);
				colvarDetalle.ColumnName = "Detalle";
				colvarDetalle.DataType = DbType.AnsiString;
				colvarDetalle.MaxLength = 255;
				colvarDetalle.AutoIncrement = false;
				colvarDetalle.IsNullable = false;
				colvarDetalle.IsPrimaryKey = false;
				colvarDetalle.IsForeignKey = false;
				colvarDetalle.IsReadOnly = false;
				colvarDetalle.DefaultSetting = @"";
				colvarDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetalle);
				
				TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
				colvarCantidad.ColumnName = "Cantidad";
				colvarCantidad.DataType = DbType.Int32;
				colvarCantidad.MaxLength = 0;
				colvarCantidad.AutoIncrement = false;
				colvarCantidad.IsNullable = false;
				colvarCantidad.IsPrimaryKey = false;
				colvarCantidad.IsForeignKey = false;
				colvarCantidad.IsReadOnly = false;
				colvarCantidad.DefaultSetting = @"";
				colvarCantidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidad);
				
				TableSchema.TableColumn colvarPrecioUnitario = new TableSchema.TableColumn(schema);
				colvarPrecioUnitario.ColumnName = "PrecioUnitario";
				colvarPrecioUnitario.DataType = DbType.Currency;
				colvarPrecioUnitario.MaxLength = 0;
				colvarPrecioUnitario.AutoIncrement = false;
				colvarPrecioUnitario.IsNullable = false;
				colvarPrecioUnitario.IsPrimaryKey = false;
				colvarPrecioUnitario.IsForeignKey = false;
				colvarPrecioUnitario.IsReadOnly = false;
				colvarPrecioUnitario.DefaultSetting = @"";
				colvarPrecioUnitario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrecioUnitario);
				
				TableSchema.TableColumn colvarDescuento = new TableSchema.TableColumn(schema);
				colvarDescuento.ColumnName = "Descuento";
				colvarDescuento.DataType = DbType.Currency;
				colvarDescuento.MaxLength = 0;
				colvarDescuento.AutoIncrement = false;
				colvarDescuento.IsNullable = false;
				colvarDescuento.IsPrimaryKey = false;
				colvarDescuento.IsForeignKey = false;
				colvarDescuento.IsReadOnly = false;
				
						colvarDescuento.DefaultSetting = @"((0))";
				colvarDescuento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescuento);
				
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
				
				TableSchema.TableColumn colvarTotal = new TableSchema.TableColumn(schema);
				colvarTotal.ColumnName = "Total";
				colvarTotal.DataType = DbType.Currency;
				colvarTotal.MaxLength = 0;
				colvarTotal.AutoIncrement = false;
				colvarTotal.IsNullable = true;
				colvarTotal.IsPrimaryKey = false;
				colvarTotal.IsForeignKey = false;
				colvarTotal.IsReadOnly = true;
				colvarTotal.DefaultSetting = @"";
				colvarTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotal);
				
				TableSchema.TableColumn colvarTotalBruto = new TableSchema.TableColumn(schema);
				colvarTotalBruto.ColumnName = "TotalBruto";
				colvarTotalBruto.DataType = DbType.Currency;
				colvarTotalBruto.MaxLength = 0;
				colvarTotalBruto.AutoIncrement = false;
				colvarTotalBruto.IsNullable = true;
				colvarTotalBruto.IsPrimaryKey = false;
				colvarTotalBruto.IsForeignKey = false;
				colvarTotalBruto.IsReadOnly = true;
				colvarTotalBruto.DefaultSetting = @"";
				colvarTotalBruto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalBruto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("TransaccionDetalle",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TransaccionDetalles")]
		[Bindable(true)]
		public int TransaccionDetalles 
		{
			get { return GetColumnValue<int>(Columns.TransaccionDetalles); }
			set { SetColumnValue(Columns.TransaccionDetalles, value); }
		}
		  
		[XmlAttribute("Cuenta")]
		[Bindable(true)]
		public string Cuenta 
		{
			get { return GetColumnValue<string>(Columns.Cuenta); }
			set { SetColumnValue(Columns.Cuenta, value); }
		}
		  
		[XmlAttribute("Detalle")]
		[Bindable(true)]
		public string Detalle 
		{
			get { return GetColumnValue<string>(Columns.Detalle); }
			set { SetColumnValue(Columns.Detalle, value); }
		}
		  
		[XmlAttribute("Cantidad")]
		[Bindable(true)]
		public int Cantidad 
		{
			get { return GetColumnValue<int>(Columns.Cantidad); }
			set { SetColumnValue(Columns.Cantidad, value); }
		}
		  
		[XmlAttribute("PrecioUnitario")]
		[Bindable(true)]
		public decimal PrecioUnitario 
		{
			get { return GetColumnValue<decimal>(Columns.PrecioUnitario); }
			set { SetColumnValue(Columns.PrecioUnitario, value); }
		}
		  
		[XmlAttribute("Descuento")]
		[Bindable(true)]
		public decimal Descuento 
		{
			get { return GetColumnValue<decimal>(Columns.Descuento); }
			set { SetColumnValue(Columns.Descuento, value); }
		}
		  
		[XmlAttribute("TransaccionId")]
		[Bindable(true)]
		public int TransaccionId 
		{
			get { return GetColumnValue<int>(Columns.TransaccionId); }
			set { SetColumnValue(Columns.TransaccionId, value); }
		}
		  
		[XmlAttribute("Total")]
		[Bindable(true)]
		public decimal? Total 
		{
			get { return GetColumnValue<decimal?>(Columns.Total); }
			set { SetColumnValue(Columns.Total, value); }
		}
		  
		[XmlAttribute("TotalBruto")]
		[Bindable(true)]
		public decimal? TotalBruto 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalBruto); }
			set { SetColumnValue(Columns.TotalBruto, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Transacciones ActiveRecord object related to this TransaccionDetalle
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
		public static void Insert(string varCuenta,string varDetalle,int varCantidad,decimal varPrecioUnitario,decimal varDescuento,int varTransaccionId,decimal? varTotal,decimal? varTotalBruto)
		{
			TransaccionDetalle item = new TransaccionDetalle();
			
			item.Cuenta = varCuenta;
			
			item.Detalle = varDetalle;
			
			item.Cantidad = varCantidad;
			
			item.PrecioUnitario = varPrecioUnitario;
			
			item.Descuento = varDescuento;
			
			item.TransaccionId = varTransaccionId;
			
			item.Total = varTotal;
			
			item.TotalBruto = varTotalBruto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTransaccionDetalles,string varCuenta,string varDetalle,int varCantidad,decimal varPrecioUnitario,decimal varDescuento,int varTransaccionId,decimal? varTotal,decimal? varTotalBruto)
		{
			TransaccionDetalle item = new TransaccionDetalle();
			
				item.TransaccionDetalles = varTransaccionDetalles;
			
				item.Cuenta = varCuenta;
			
				item.Detalle = varDetalle;
			
				item.Cantidad = varCantidad;
			
				item.PrecioUnitario = varPrecioUnitario;
			
				item.Descuento = varDescuento;
			
				item.TransaccionId = varTransaccionId;
			
				item.Total = varTotal;
			
				item.TotalBruto = varTotalBruto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TransaccionDetallesColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuentaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DetalleColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrecioUnitarioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DescuentoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TransaccionIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalBrutoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TransaccionDetalles = @"TransaccionDetalles";
			 public static string Cuenta = @"Cuenta";
			 public static string Detalle = @"Detalle";
			 public static string Cantidad = @"Cantidad";
			 public static string PrecioUnitario = @"PrecioUnitario";
			 public static string Descuento = @"Descuento";
			 public static string TransaccionId = @"TransaccionId";
			 public static string Total = @"Total";
			 public static string TotalBruto = @"TotalBruto";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
