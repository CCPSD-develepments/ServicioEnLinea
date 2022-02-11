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
namespace CamaraComercio.DataAccess.OficinaVirtual
{
	/// <summary>
	/// Strongly-typed collection for the TiposSociedad class.
	/// </summary>
    [Serializable]
	public partial class TiposSociedadCollection : ActiveList<TiposSociedad, TiposSociedadCollection>
	{	   
		public TiposSociedadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TiposSociedadCollection</returns>
		public TiposSociedadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TiposSociedad o = this[i];
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
	/// This is an ActiveRecord class which wraps the TiposSociedades table.
	/// </summary>
	[Serializable]
	public partial class TiposSociedad : ActiveRecord<TiposSociedad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TiposSociedad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TiposSociedad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TiposSociedad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TiposSociedad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TiposSociedades", TableType.Table, DataService.GetInstance("OficinaVirtualProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"WebSRM";
				//columns
				
				TableSchema.TableColumn colvarTipoSociedadId = new TableSchema.TableColumn(schema);
				colvarTipoSociedadId.ColumnName = "TipoSociedadId";
				colvarTipoSociedadId.DataType = DbType.Int32;
				colvarTipoSociedadId.MaxLength = 0;
				colvarTipoSociedadId.AutoIncrement = true;
				colvarTipoSociedadId.IsNullable = false;
				colvarTipoSociedadId.IsPrimaryKey = true;
				colvarTipoSociedadId.IsForeignKey = false;
				colvarTipoSociedadId.IsReadOnly = false;
				colvarTipoSociedadId.DefaultSetting = @"";
				colvarTipoSociedadId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoSociedadId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarSufijo = new TableSchema.TableColumn(schema);
				colvarSufijo.ColumnName = "Sufijo";
				colvarSufijo.DataType = DbType.AnsiString;
				colvarSufijo.MaxLength = 10;
				colvarSufijo.AutoIncrement = false;
				colvarSufijo.IsNullable = true;
				colvarSufijo.IsPrimaryKey = false;
				colvarSufijo.IsForeignKey = false;
				colvarSufijo.IsReadOnly = false;
				colvarSufijo.DefaultSetting = @"";
				colvarSufijo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSufijo);
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "FechaModificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = false;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				
						colvarFechaModificacion.DefaultSetting = @"(getdate())";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OficinaVirtualProvider"].AddSchema("TiposSociedades",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TipoSociedadId")]
		[Bindable(true)]
		public int TipoSociedadId 
		{
			get { return GetColumnValue<int>(Columns.TipoSociedadId); }
			set { SetColumnValue(Columns.TipoSociedadId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Sufijo")]
		[Bindable(true)]
		public string Sufijo 
		{
			get { return GetColumnValue<string>(Columns.Sufijo); }
			set { SetColumnValue(Columns.Sufijo, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CamaraComercio.DataAccess.OficinaVirtual.MatrizConversionTipoSociedadCollection MatrizConversionTipoSociedadRecords()
		{
			return new CamaraComercio.DataAccess.OficinaVirtual.MatrizConversionTipoSociedadCollection().Where(MatrizConversionTipoSociedad.Columns.TipoSociedadNuevaId, TipoSociedadId).Load();
		}
		public CamaraComercio.DataAccess.OficinaVirtual.RequisitoCollection RequisitoRecords()
		{
			return new CamaraComercio.DataAccess.OficinaVirtual.RequisitoCollection().Where(Requisito.Columns.TipoSociedadId, TipoSociedadId).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public CamaraComercio.DataAccess.OficinaVirtual.TipoSociedadActualCollection GetTipoSociedadActualCollection() { return TiposSociedad.GetTipoSociedadActualCollection(this.TipoSociedadId); }
		public static CamaraComercio.DataAccess.OficinaVirtual.TipoSociedadActualCollection GetTipoSociedadActualCollection(int varTipoSociedadId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [WebSRM].[TipoSociedadActual] INNER JOIN [MatrizConversionTipoSociedad] ON [TipoSociedadActual].[TipoSociedadId] = [MatrizConversionTipoSociedad].[TipoSociedadActualId] WHERE [MatrizConversionTipoSociedad].[TipoSociedadNuevaId] = @TipoSociedadNuevaId", TiposSociedad.Schema.Provider.Name);
			cmd.AddParameter("@TipoSociedadNuevaId", varTipoSociedadId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			TipoSociedadActualCollection coll = new TipoSociedadActualCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveTipoSociedadActualMap(int varTipoSociedadId, TipoSociedadActualCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [MatrizConversionTipoSociedad] WHERE [MatrizConversionTipoSociedad].[TipoSociedadNuevaId] = @TipoSociedadNuevaId", TiposSociedad.Schema.Provider.Name);
			cmdDel.AddParameter("@TipoSociedadNuevaId", varTipoSociedadId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (TipoSociedadActual item in items)
			{
				MatrizConversionTipoSociedad varMatrizConversionTipoSociedad = new MatrizConversionTipoSociedad();
				varMatrizConversionTipoSociedad.SetColumnValue("TipoSociedadNuevaId", varTipoSociedadId);
				varMatrizConversionTipoSociedad.SetColumnValue("TipoSociedadActualId", item.GetPrimaryKeyValue());
				varMatrizConversionTipoSociedad.Save();
			}
		}
		public static void SaveTipoSociedadActualMap(int varTipoSociedadId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [MatrizConversionTipoSociedad] WHERE [MatrizConversionTipoSociedad].[TipoSociedadNuevaId] = @TipoSociedadNuevaId", TiposSociedad.Schema.Provider.Name);
			cmdDel.AddParameter("@TipoSociedadNuevaId", varTipoSociedadId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					MatrizConversionTipoSociedad varMatrizConversionTipoSociedad = new MatrizConversionTipoSociedad();
					varMatrizConversionTipoSociedad.SetColumnValue("TipoSociedadNuevaId", varTipoSociedadId);
					varMatrizConversionTipoSociedad.SetColumnValue("TipoSociedadActualId", l.Value);
					varMatrizConversionTipoSociedad.Save();
				}
			}
		}
		public static void SaveTipoSociedadActualMap(int varTipoSociedadId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [MatrizConversionTipoSociedad] WHERE [MatrizConversionTipoSociedad].[TipoSociedadNuevaId] = @TipoSociedadNuevaId", TiposSociedad.Schema.Provider.Name);
			cmdDel.AddParameter("@TipoSociedadNuevaId", varTipoSociedadId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				MatrizConversionTipoSociedad varMatrizConversionTipoSociedad = new MatrizConversionTipoSociedad();
				varMatrizConversionTipoSociedad.SetColumnValue("TipoSociedadNuevaId", varTipoSociedadId);
				varMatrizConversionTipoSociedad.SetColumnValue("TipoSociedadActualId", item);
				varMatrizConversionTipoSociedad.Save();
			}
		}
		
		public static void DeleteTipoSociedadActualMap(int varTipoSociedadId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [MatrizConversionTipoSociedad] WHERE [MatrizConversionTipoSociedad].[TipoSociedadNuevaId] = @TipoSociedadNuevaId", TiposSociedad.Schema.Provider.Name);
			cmdDel.AddParameter("@TipoSociedadNuevaId", varTipoSociedadId, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,string varSufijo,DateTime varFechaModificacion)
		{
			TiposSociedad item = new TiposSociedad();
			
			item.Descripcion = varDescripcion;
			
			item.Sufijo = varSufijo;
			
			item.FechaModificacion = varFechaModificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTipoSociedadId,string varDescripcion,string varSufijo,DateTime varFechaModificacion)
		{
			TiposSociedad item = new TiposSociedad();
			
				item.TipoSociedadId = varTipoSociedadId;
			
				item.Descripcion = varDescripcion;
			
				item.Sufijo = varSufijo;
			
				item.FechaModificacion = varFechaModificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TipoSociedadIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SufijoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TipoSociedadId = @"TipoSociedadId";
			 public static string Descripcion = @"Descripcion";
			 public static string Sufijo = @"Sufijo";
			 public static string FechaModificacion = @"FechaModificacion";
						
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
