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
	/// Strongly-typed collection for the Servicio class.
	/// </summary>
    [Serializable]
	public partial class ServicioCollection : ActiveList<Servicio, ServicioCollection>
	{	   
		public ServicioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ServicioCollection</returns>
		public ServicioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Servicio o = this[i];
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
	/// This is an ActiveRecord class which wraps the Servicio table.
	/// </summary>
	[Serializable]
	public partial class Servicio : ActiveRecord<Servicio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Servicio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Servicio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Servicio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Servicio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Servicio", TableType.Table, DataService.GetInstance("ComunProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarServicioId = new TableSchema.TableColumn(schema);
				colvarServicioId.ColumnName = "ServicioId";
				colvarServicioId.DataType = DbType.Int32;
				colvarServicioId.MaxLength = 0;
				colvarServicioId.AutoIncrement = true;
				colvarServicioId.IsNullable = false;
				colvarServicioId.IsPrimaryKey = true;
				colvarServicioId.IsForeignKey = false;
				colvarServicioId.IsReadOnly = false;
				colvarServicioId.DefaultSetting = @"";
				colvarServicioId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarServicioId);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 250;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarTipoServicioId = new TableSchema.TableColumn(schema);
				colvarTipoServicioId.ColumnName = "TipoServicioId";
				colvarTipoServicioId.DataType = DbType.Int32;
				colvarTipoServicioId.MaxLength = 0;
				colvarTipoServicioId.AutoIncrement = false;
				colvarTipoServicioId.IsNullable = false;
				colvarTipoServicioId.IsPrimaryKey = false;
				colvarTipoServicioId.IsForeignKey = true;
				colvarTipoServicioId.IsReadOnly = false;
				colvarTipoServicioId.DefaultSetting = @"";
				
					colvarTipoServicioId.ForeignKeyTableName = "TipoServicio";
				schema.Columns.Add(colvarTipoServicioId);
				
				TableSchema.TableColumn colvarCostoServicio = new TableSchema.TableColumn(schema);
				colvarCostoServicio.ColumnName = "CostoServicio";
				colvarCostoServicio.DataType = DbType.Currency;
				colvarCostoServicio.MaxLength = 0;
				colvarCostoServicio.AutoIncrement = false;
				colvarCostoServicio.IsNullable = false;
				colvarCostoServicio.IsPrimaryKey = false;
				colvarCostoServicio.IsForeignKey = false;
				colvarCostoServicio.IsReadOnly = false;
				
						colvarCostoServicio.DefaultSetting = @"((0))";
				colvarCostoServicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoServicio);
				
				TableSchema.TableColumn colvarCalculoBaseCapital = new TableSchema.TableColumn(schema);
				colvarCalculoBaseCapital.ColumnName = "CalculoBaseCapital";
				colvarCalculoBaseCapital.DataType = DbType.Boolean;
				colvarCalculoBaseCapital.MaxLength = 0;
				colvarCalculoBaseCapital.AutoIncrement = false;
				colvarCalculoBaseCapital.IsNullable = false;
				colvarCalculoBaseCapital.IsPrimaryKey = false;
				colvarCalculoBaseCapital.IsForeignKey = false;
				colvarCalculoBaseCapital.IsReadOnly = false;
				colvarCalculoBaseCapital.DefaultSetting = @"";
				colvarCalculoBaseCapital.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCalculoBaseCapital);
				
				TableSchema.TableColumn colvarTipoCalculoBaseCapital = new TableSchema.TableColumn(schema);
				colvarTipoCalculoBaseCapital.ColumnName = "TipoCalculoBaseCapital";
				colvarTipoCalculoBaseCapital.DataType = DbType.Int32;
				colvarTipoCalculoBaseCapital.MaxLength = 0;
				colvarTipoCalculoBaseCapital.AutoIncrement = false;
				colvarTipoCalculoBaseCapital.IsNullable = false;
				colvarTipoCalculoBaseCapital.IsPrimaryKey = false;
				colvarTipoCalculoBaseCapital.IsForeignKey = false;
				colvarTipoCalculoBaseCapital.IsReadOnly = false;
				colvarTipoCalculoBaseCapital.DefaultSetting = @"";
				colvarTipoCalculoBaseCapital.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoCalculoBaseCapital);
				
				TableSchema.TableColumn colvarServicioParalelo = new TableSchema.TableColumn(schema);
				colvarServicioParalelo.ColumnName = "ServicioParalelo";
				colvarServicioParalelo.DataType = DbType.Boolean;
				colvarServicioParalelo.MaxLength = 0;
				colvarServicioParalelo.AutoIncrement = false;
				colvarServicioParalelo.IsNullable = false;
				colvarServicioParalelo.IsPrimaryKey = false;
				colvarServicioParalelo.IsForeignKey = false;
				colvarServicioParalelo.IsReadOnly = false;
				colvarServicioParalelo.DefaultSetting = @"";
				colvarServicioParalelo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarServicioParalelo);
				
				TableSchema.TableColumn colvarServicioFlowId = new TableSchema.TableColumn(schema);
				colvarServicioFlowId.ColumnName = "ServicioFlowId";
				colvarServicioFlowId.DataType = DbType.Int32;
				colvarServicioFlowId.MaxLength = 0;
				colvarServicioFlowId.AutoIncrement = false;
				colvarServicioFlowId.IsNullable = false;
				colvarServicioFlowId.IsPrimaryKey = false;
				colvarServicioFlowId.IsForeignKey = false;
				colvarServicioFlowId.IsReadOnly = false;
				colvarServicioFlowId.DefaultSetting = @"";
				colvarServicioFlowId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarServicioFlowId);
				
				TableSchema.TableColumn colvarCuenta = new TableSchema.TableColumn(schema);
				colvarCuenta.ColumnName = "Cuenta";
				colvarCuenta.DataType = DbType.AnsiString;
				colvarCuenta.MaxLength = 25;
				colvarCuenta.AutoIncrement = false;
				colvarCuenta.IsNullable = false;
				colvarCuenta.IsPrimaryKey = false;
				colvarCuenta.IsForeignKey = false;
				colvarCuenta.IsReadOnly = false;
				
						colvarCuenta.DefaultSetting = @"('')";
				colvarCuenta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuenta);
				
				TableSchema.TableColumn colvarSeCobra = new TableSchema.TableColumn(schema);
				colvarSeCobra.ColumnName = "SeCobra";
				colvarSeCobra.DataType = DbType.Boolean;
				colvarSeCobra.MaxLength = 0;
				colvarSeCobra.AutoIncrement = false;
				colvarSeCobra.IsNullable = false;
				colvarSeCobra.IsPrimaryKey = false;
				colvarSeCobra.IsForeignKey = false;
				colvarSeCobra.IsReadOnly = false;
				colvarSeCobra.DefaultSetting = @"";
				colvarSeCobra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeCobra);
				
				TableSchema.TableColumn colvarSinDocumento = new TableSchema.TableColumn(schema);
				colvarSinDocumento.ColumnName = "SinDocumento";
				colvarSinDocumento.DataType = DbType.Boolean;
				colvarSinDocumento.MaxLength = 0;
				colvarSinDocumento.AutoIncrement = false;
				colvarSinDocumento.IsNullable = false;
				colvarSinDocumento.IsPrimaryKey = false;
				colvarSinDocumento.IsForeignKey = false;
				colvarSinDocumento.IsReadOnly = false;
				colvarSinDocumento.DefaultSetting = @"";
				colvarSinDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSinDocumento);
				
				TableSchema.TableColumn colvarSubTransaccional = new TableSchema.TableColumn(schema);
				colvarSubTransaccional.ColumnName = "SubTransaccional";
				colvarSubTransaccional.DataType = DbType.Boolean;
				colvarSubTransaccional.MaxLength = 0;
				colvarSubTransaccional.AutoIncrement = false;
				colvarSubTransaccional.IsNullable = false;
				colvarSubTransaccional.IsPrimaryKey = false;
				colvarSubTransaccional.IsForeignKey = false;
				colvarSubTransaccional.IsReadOnly = false;
				colvarSubTransaccional.DefaultSetting = @"";
				colvarSubTransaccional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTransaccional);
				
				TableSchema.TableColumn colvarAfectaOtraCompania = new TableSchema.TableColumn(schema);
				colvarAfectaOtraCompania.ColumnName = "AfectaOtraCompania";
				colvarAfectaOtraCompania.DataType = DbType.Boolean;
				colvarAfectaOtraCompania.MaxLength = 0;
				colvarAfectaOtraCompania.AutoIncrement = false;
				colvarAfectaOtraCompania.IsNullable = false;
				colvarAfectaOtraCompania.IsPrimaryKey = false;
				colvarAfectaOtraCompania.IsForeignKey = false;
				colvarAfectaOtraCompania.IsReadOnly = false;
				colvarAfectaOtraCompania.DefaultSetting = @"";
				colvarAfectaOtraCompania.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfectaOtraCompania);
				
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
				
				TableSchema.TableColumn colvarValidarRenovacion = new TableSchema.TableColumn(schema);
				colvarValidarRenovacion.ColumnName = "ValidarRenovacion";
				colvarValidarRenovacion.DataType = DbType.Boolean;
				colvarValidarRenovacion.MaxLength = 0;
				colvarValidarRenovacion.AutoIncrement = false;
				colvarValidarRenovacion.IsNullable = false;
				colvarValidarRenovacion.IsPrimaryKey = false;
				colvarValidarRenovacion.IsForeignKey = false;
				colvarValidarRenovacion.IsReadOnly = false;
				colvarValidarRenovacion.DefaultSetting = @"";
				colvarValidarRenovacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValidarRenovacion);
				
				TableSchema.TableColumn colvarEsTransformacion = new TableSchema.TableColumn(schema);
				colvarEsTransformacion.ColumnName = "EsTransformacion";
				colvarEsTransformacion.DataType = DbType.Boolean;
				colvarEsTransformacion.MaxLength = 0;
				colvarEsTransformacion.AutoIncrement = false;
				colvarEsTransformacion.IsNullable = false;
				colvarEsTransformacion.IsPrimaryKey = false;
				colvarEsTransformacion.IsForeignKey = false;
				colvarEsTransformacion.IsReadOnly = false;
				colvarEsTransformacion.DefaultSetting = @"";
				colvarEsTransformacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEsTransformacion);
				
				TableSchema.TableColumn colvarTipoIdentificador = new TableSchema.TableColumn(schema);
				colvarTipoIdentificador.ColumnName = "TipoIdentificador";
				colvarTipoIdentificador.DataType = DbType.Int32;
				colvarTipoIdentificador.MaxLength = 0;
				colvarTipoIdentificador.AutoIncrement = false;
				colvarTipoIdentificador.IsNullable = false;
				colvarTipoIdentificador.IsPrimaryKey = false;
				colvarTipoIdentificador.IsForeignKey = false;
				colvarTipoIdentificador.IsReadOnly = false;
				colvarTipoIdentificador.DefaultSetting = @"";
				colvarTipoIdentificador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoIdentificador);
				
				TableSchema.TableColumn colvarVisible = new TableSchema.TableColumn(schema);
				colvarVisible.ColumnName = "Visible";
				colvarVisible.DataType = DbType.Boolean;
				colvarVisible.MaxLength = 0;
				colvarVisible.AutoIncrement = false;
				colvarVisible.IsNullable = false;
				colvarVisible.IsPrimaryKey = false;
				colvarVisible.IsForeignKey = false;
				colvarVisible.IsReadOnly = false;
				
						colvarVisible.DefaultSetting = @"((1))";
				colvarVisible.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVisible);
				
				TableSchema.TableColumn colvarSiteVisible = new TableSchema.TableColumn(schema);
				colvarSiteVisible.ColumnName = "SiteVisible";
				colvarSiteVisible.DataType = DbType.Boolean;
				colvarSiteVisible.MaxLength = 0;
				colvarSiteVisible.AutoIncrement = false;
				colvarSiteVisible.IsNullable = false;
				colvarSiteVisible.IsPrimaryKey = false;
				colvarSiteVisible.IsForeignKey = false;
				colvarSiteVisible.IsReadOnly = false;
				
						colvarSiteVisible.DefaultSetting = @"((0))";
				colvarSiteVisible.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSiteVisible);
				
				TableSchema.TableColumn colvarServicioCode = new TableSchema.TableColumn(schema);
				colvarServicioCode.ColumnName = "ServicioCode";
				colvarServicioCode.DataType = DbType.AnsiString;
				colvarServicioCode.MaxLength = 20;
				colvarServicioCode.AutoIncrement = false;
				colvarServicioCode.IsNullable = true;
				colvarServicioCode.IsPrimaryKey = false;
				colvarServicioCode.IsForeignKey = false;
				colvarServicioCode.IsReadOnly = false;
				colvarServicioCode.DefaultSetting = @"";
				colvarServicioCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarServicioCode);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ComunProvider"].AddSchema("Servicio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ServicioId")]
		[Bindable(true)]
		public int ServicioId 
		{
			get { return GetColumnValue<int>(Columns.ServicioId); }
			set { SetColumnValue(Columns.ServicioId, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("TipoServicioId")]
		[Bindable(true)]
		public int TipoServicioId 
		{
			get { return GetColumnValue<int>(Columns.TipoServicioId); }
			set { SetColumnValue(Columns.TipoServicioId, value); }
		}
		  
		[XmlAttribute("CostoServicio")]
		[Bindable(true)]
		public decimal CostoServicio 
		{
			get { return GetColumnValue<decimal>(Columns.CostoServicio); }
			set { SetColumnValue(Columns.CostoServicio, value); }
		}
		  
		[XmlAttribute("CalculoBaseCapital")]
		[Bindable(true)]
		public bool CalculoBaseCapital 
		{
			get { return GetColumnValue<bool>(Columns.CalculoBaseCapital); }
			set { SetColumnValue(Columns.CalculoBaseCapital, value); }
		}
		  
		[XmlAttribute("TipoCalculoBaseCapital")]
		[Bindable(true)]
		public int TipoCalculoBaseCapital 
		{
			get { return GetColumnValue<int>(Columns.TipoCalculoBaseCapital); }
			set { SetColumnValue(Columns.TipoCalculoBaseCapital, value); }
		}
		  
		[XmlAttribute("ServicioParalelo")]
		[Bindable(true)]
		public bool ServicioParalelo 
		{
			get { return GetColumnValue<bool>(Columns.ServicioParalelo); }
			set { SetColumnValue(Columns.ServicioParalelo, value); }
		}
		  
		[XmlAttribute("ServicioFlowId")]
		[Bindable(true)]
		public int ServicioFlowId 
		{
			get { return GetColumnValue<int>(Columns.ServicioFlowId); }
			set { SetColumnValue(Columns.ServicioFlowId, value); }
		}
		  
		[XmlAttribute("Cuenta")]
		[Bindable(true)]
		public string Cuenta 
		{
			get { return GetColumnValue<string>(Columns.Cuenta); }
			set { SetColumnValue(Columns.Cuenta, value); }
		}
		  
		[XmlAttribute("SeCobra")]
		[Bindable(true)]
		public bool SeCobra 
		{
			get { return GetColumnValue<bool>(Columns.SeCobra); }
			set { SetColumnValue(Columns.SeCobra, value); }
		}
		  
		[XmlAttribute("SinDocumento")]
		[Bindable(true)]
		public bool SinDocumento 
		{
			get { return GetColumnValue<bool>(Columns.SinDocumento); }
			set { SetColumnValue(Columns.SinDocumento, value); }
		}
		  
		[XmlAttribute("SubTransaccional")]
		[Bindable(true)]
		public bool SubTransaccional 
		{
			get { return GetColumnValue<bool>(Columns.SubTransaccional); }
			set { SetColumnValue(Columns.SubTransaccional, value); }
		}
		  
		[XmlAttribute("AfectaOtraCompania")]
		[Bindable(true)]
		public bool AfectaOtraCompania 
		{
			get { return GetColumnValue<bool>(Columns.AfectaOtraCompania); }
			set { SetColumnValue(Columns.AfectaOtraCompania, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("ValidarRenovacion")]
		[Bindable(true)]
		public bool ValidarRenovacion 
		{
			get { return GetColumnValue<bool>(Columns.ValidarRenovacion); }
			set { SetColumnValue(Columns.ValidarRenovacion, value); }
		}
		  
		[XmlAttribute("EsTransformacion")]
		[Bindable(true)]
		public bool EsTransformacion 
		{
			get { return GetColumnValue<bool>(Columns.EsTransformacion); }
			set { SetColumnValue(Columns.EsTransformacion, value); }
		}
		  
		[XmlAttribute("TipoIdentificador")]
		[Bindable(true)]
		public int TipoIdentificador 
		{
			get { return GetColumnValue<int>(Columns.TipoIdentificador); }
			set { SetColumnValue(Columns.TipoIdentificador, value); }
		}
		  
		[XmlAttribute("Visible")]
		[Bindable(true)]
		public bool Visible 
		{
			get { return GetColumnValue<bool>(Columns.Visible); }
			set { SetColumnValue(Columns.Visible, value); }
		}
		  
		[XmlAttribute("SiteVisible")]
		[Bindable(true)]
		public bool SiteVisible 
		{
			get { return GetColumnValue<bool>(Columns.SiteVisible); }
			set { SetColumnValue(Columns.SiteVisible, value); }
		}
		  
		[XmlAttribute("ServicioCode")]
		[Bindable(true)]
		public string ServicioCode 
		{
			get { return GetColumnValue<string>(Columns.ServicioCode); }
			set { SetColumnValue(Columns.ServicioCode, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CamaraComercio.DataAccess.Comun.ServicioDocumentoRequeridoCollection ServicioDocumentoRequeridoRecords()
		{
			return new CamaraComercio.DataAccess.Comun.ServicioDocumentoRequeridoCollection().Where(ServicioDocumentoRequerido.Columns.ServicioId, ServicioId).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a TipoServicio ActiveRecord object related to this Servicio
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.Comun.TipoServicio TipoServicio
		{
			get { return CamaraComercio.DataAccess.Comun.TipoServicio.FetchByID(this.TipoServicioId); }
			set { SetColumnValue("TipoServicioId", value.TipoServicioId); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public CamaraComercio.DataAccess.Comun.TipoDocumentoCollection GetTipoDocumentoCollection() { return Servicio.GetTipoDocumentoCollection(this.ServicioId); }
		public static CamaraComercio.DataAccess.Comun.TipoDocumentoCollection GetTipoDocumentoCollection(int varServicioId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[TipoDocumento] INNER JOIN [ServicioDocumentoRequerido] ON [TipoDocumento].[TipoDocumentoId] = [ServicioDocumentoRequerido].[TipoDocumentoId] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmd.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			TipoDocumentoCollection coll = new TipoDocumentoCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveTipoDocumentoMap(int varServicioId, TipoDocumentoCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (TipoDocumento item in items)
			{
				ServicioDocumentoRequerido varServicioDocumentoRequerido = new ServicioDocumentoRequerido();
				varServicioDocumentoRequerido.SetColumnValue("ServicioId", varServicioId);
				varServicioDocumentoRequerido.SetColumnValue("TipoDocumentoId", item.GetPrimaryKeyValue());
				varServicioDocumentoRequerido.Save();
			}
		}
		public static void SaveTipoDocumentoMap(int varServicioId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ServicioDocumentoRequerido varServicioDocumentoRequerido = new ServicioDocumentoRequerido();
					varServicioDocumentoRequerido.SetColumnValue("ServicioId", varServicioId);
					varServicioDocumentoRequerido.SetColumnValue("TipoDocumentoId", l.Value);
					varServicioDocumentoRequerido.Save();
				}
			}
		}
		public static void SaveTipoDocumentoMap(int varServicioId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ServicioDocumentoRequerido varServicioDocumentoRequerido = new ServicioDocumentoRequerido();
				varServicioDocumentoRequerido.SetColumnValue("ServicioId", varServicioId);
				varServicioDocumentoRequerido.SetColumnValue("TipoDocumentoId", item);
				varServicioDocumentoRequerido.Save();
			}
		}
		
		public static void DeleteTipoDocumentoMap(int varServicioId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public CamaraComercio.DataAccess.Comun.TipoSociedadCollection GetTipoSociedadCollection() { return Servicio.GetTipoSociedadCollection(this.ServicioId); }
		public static CamaraComercio.DataAccess.Comun.TipoSociedadCollection GetTipoSociedadCollection(int varServicioId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[TipoSociedad] INNER JOIN [ServicioDocumentoRequerido] ON [TipoSociedad].[TipoSociedadId] = [ServicioDocumentoRequerido].[TipoSociedadId] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmd.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			TipoSociedadCollection coll = new TipoSociedadCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveTipoSociedadMap(int varServicioId, TipoSociedadCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (TipoSociedad item in items)
			{
				ServicioDocumentoRequerido varServicioDocumentoRequerido = new ServicioDocumentoRequerido();
				varServicioDocumentoRequerido.SetColumnValue("ServicioId", varServicioId);
				varServicioDocumentoRequerido.SetColumnValue("TipoSociedadId", item.GetPrimaryKeyValue());
				varServicioDocumentoRequerido.Save();
			}
		}
		public static void SaveTipoSociedadMap(int varServicioId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ServicioDocumentoRequerido varServicioDocumentoRequerido = new ServicioDocumentoRequerido();
					varServicioDocumentoRequerido.SetColumnValue("ServicioId", varServicioId);
					varServicioDocumentoRequerido.SetColumnValue("TipoSociedadId", l.Value);
					varServicioDocumentoRequerido.Save();
				}
			}
		}
		public static void SaveTipoSociedadMap(int varServicioId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ServicioDocumentoRequerido varServicioDocumentoRequerido = new ServicioDocumentoRequerido();
				varServicioDocumentoRequerido.SetColumnValue("ServicioId", varServicioId);
				varServicioDocumentoRequerido.SetColumnValue("TipoSociedadId", item);
				varServicioDocumentoRequerido.Save();
			}
		}
		
		public static void DeleteTipoSociedadMap(int varServicioId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ServicioDocumentoRequerido] WHERE [ServicioDocumentoRequerido].[ServicioId] = @ServicioId", Servicio.Schema.Provider.Name);
			cmdDel.AddParameter("@ServicioId", varServicioId, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,int varTipoServicioId,decimal varCostoServicio,bool varCalculoBaseCapital,int varTipoCalculoBaseCapital,bool varServicioParalelo,int varServicioFlowId,string varCuenta,bool varSeCobra,bool varSinDocumento,bool varSubTransaccional,bool varAfectaOtraCompania,DateTime varFechaModificacion,bool varValidarRenovacion,bool varEsTransformacion,int varTipoIdentificador,bool varVisible,bool varSiteVisible,string varServicioCode)
		{
			Servicio item = new Servicio();
			
			item.Descripcion = varDescripcion;
			
			item.TipoServicioId = varTipoServicioId;
			
			item.CostoServicio = varCostoServicio;
			
			item.CalculoBaseCapital = varCalculoBaseCapital;
			
			item.TipoCalculoBaseCapital = varTipoCalculoBaseCapital;
			
			item.ServicioParalelo = varServicioParalelo;
			
			item.ServicioFlowId = varServicioFlowId;
			
			item.Cuenta = varCuenta;
			
			item.SeCobra = varSeCobra;
			
			item.SinDocumento = varSinDocumento;
			
			item.SubTransaccional = varSubTransaccional;
			
			item.AfectaOtraCompania = varAfectaOtraCompania;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.ValidarRenovacion = varValidarRenovacion;
			
			item.EsTransformacion = varEsTransformacion;
			
			item.TipoIdentificador = varTipoIdentificador;
			
			item.Visible = varVisible;
			
			item.SiteVisible = varSiteVisible;
			
			item.ServicioCode = varServicioCode;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varServicioId,string varDescripcion,int varTipoServicioId,decimal varCostoServicio,bool varCalculoBaseCapital,int varTipoCalculoBaseCapital,bool varServicioParalelo,int varServicioFlowId,string varCuenta,bool varSeCobra,bool varSinDocumento,bool varSubTransaccional,bool varAfectaOtraCompania,DateTime varFechaModificacion,bool varValidarRenovacion,bool varEsTransformacion,int varTipoIdentificador,bool varVisible,bool varSiteVisible,string varServicioCode)
		{
			Servicio item = new Servicio();
			
				item.ServicioId = varServicioId;
			
				item.Descripcion = varDescripcion;
			
				item.TipoServicioId = varTipoServicioId;
			
				item.CostoServicio = varCostoServicio;
			
				item.CalculoBaseCapital = varCalculoBaseCapital;
			
				item.TipoCalculoBaseCapital = varTipoCalculoBaseCapital;
			
				item.ServicioParalelo = varServicioParalelo;
			
				item.ServicioFlowId = varServicioFlowId;
			
				item.Cuenta = varCuenta;
			
				item.SeCobra = varSeCobra;
			
				item.SinDocumento = varSinDocumento;
			
				item.SubTransaccional = varSubTransaccional;
			
				item.AfectaOtraCompania = varAfectaOtraCompania;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.ValidarRenovacion = varValidarRenovacion;
			
				item.EsTransformacion = varEsTransformacion;
			
				item.TipoIdentificador = varTipoIdentificador;
			
				item.Visible = varVisible;
			
				item.SiteVisible = varSiteVisible;
			
				item.ServicioCode = varServicioCode;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ServicioIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoServicioIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoServicioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CalculoBaseCapitalColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoCalculoBaseCapitalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ServicioParaleloColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ServicioFlowIdColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CuentaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn SeCobraColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SinDocumentoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTransaccionalColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AfectaOtraCompaniaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ValidarRenovacionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn EsTransformacionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoIdentificadorColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn VisibleColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn SiteVisibleColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ServicioCodeColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ServicioId = @"ServicioId";
			 public static string Descripcion = @"Descripcion";
			 public static string TipoServicioId = @"TipoServicioId";
			 public static string CostoServicio = @"CostoServicio";
			 public static string CalculoBaseCapital = @"CalculoBaseCapital";
			 public static string TipoCalculoBaseCapital = @"TipoCalculoBaseCapital";
			 public static string ServicioParalelo = @"ServicioParalelo";
			 public static string ServicioFlowId = @"ServicioFlowId";
			 public static string Cuenta = @"Cuenta";
			 public static string SeCobra = @"SeCobra";
			 public static string SinDocumento = @"SinDocumento";
			 public static string SubTransaccional = @"SubTransaccional";
			 public static string AfectaOtraCompania = @"AfectaOtraCompania";
			 public static string FechaModificacion = @"FechaModificacion";
			 public static string ValidarRenovacion = @"ValidarRenovacion";
			 public static string EsTransformacion = @"EsTransformacion";
			 public static string TipoIdentificador = @"TipoIdentificador";
			 public static string Visible = @"Visible";
			 public static string SiteVisible = @"SiteVisible";
			 public static string ServicioCode = @"ServicioCode";
						
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
