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
	/// Strongly-typed collection for the TransaccionDocumentosRequisitos class.
	/// </summary>
    [Serializable]
	public partial class TransaccionDocumentosRequisitosCollection : ActiveList<TransaccionDocumentosRequisitos, TransaccionDocumentosRequisitosCollection>
	{	   
		public TransaccionDocumentosRequisitosCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TransaccionDocumentosRequisitosCollection</returns>
		public TransaccionDocumentosRequisitosCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TransaccionDocumentosRequisitos o = this[i];
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
	/// This is an ActiveRecord class which wraps the TransaccionDocumentosRequisitos table.
	/// </summary>
	[Serializable]
	public partial class TransaccionDocumentosRequisitos : ActiveRecord<TransaccionDocumentosRequisitos>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TransaccionDocumentosRequisitos()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TransaccionDocumentosRequisitos(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TransaccionDocumentosRequisitos(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TransaccionDocumentosRequisitos(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TransaccionDocumentosRequisitos", TableType.Table, DataService.GetInstance("SrmProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Transaccion";
				//columns
				
				TableSchema.TableColumn colvarRquisitosTransaccionId = new TableSchema.TableColumn(schema);
				colvarRquisitosTransaccionId.ColumnName = "RquisitosTransaccionId";
				colvarRquisitosTransaccionId.DataType = DbType.Int32;
				colvarRquisitosTransaccionId.MaxLength = 0;
				colvarRquisitosTransaccionId.AutoIncrement = true;
				colvarRquisitosTransaccionId.IsNullable = false;
				colvarRquisitosTransaccionId.IsPrimaryKey = true;
				colvarRquisitosTransaccionId.IsForeignKey = false;
				colvarRquisitosTransaccionId.IsReadOnly = false;
				colvarRquisitosTransaccionId.DefaultSetting = @"";
				colvarRquisitosTransaccionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRquisitosTransaccionId);
				
				TableSchema.TableColumn colvarDocumentoId = new TableSchema.TableColumn(schema);
				colvarDocumentoId.ColumnName = "DocumentoId";
				colvarDocumentoId.DataType = DbType.Int32;
				colvarDocumentoId.MaxLength = 0;
				colvarDocumentoId.AutoIncrement = false;
				colvarDocumentoId.IsNullable = false;
				colvarDocumentoId.IsPrimaryKey = false;
				colvarDocumentoId.IsForeignKey = true;
				colvarDocumentoId.IsReadOnly = false;
				colvarDocumentoId.DefaultSetting = @"";
				
					colvarDocumentoId.ForeignKeyTableName = "Documentos";
				schema.Columns.Add(colvarDocumentoId);
				
				TableSchema.TableColumn colvarTipoServicioId = new TableSchema.TableColumn(schema);
				colvarTipoServicioId.ColumnName = "TipoServicioId";
				colvarTipoServicioId.DataType = DbType.Int32;
				colvarTipoServicioId.MaxLength = 0;
				colvarTipoServicioId.AutoIncrement = false;
				colvarTipoServicioId.IsNullable = true;
				colvarTipoServicioId.IsPrimaryKey = false;
				colvarTipoServicioId.IsForeignKey = true;
				colvarTipoServicioId.IsReadOnly = false;
				colvarTipoServicioId.DefaultSetting = @"";
				
					colvarTipoServicioId.ForeignKeyTableName = "TiposServicios";
				schema.Columns.Add(colvarTipoServicioId);
				
				TableSchema.TableColumn colvarRequerido = new TableSchema.TableColumn(schema);
				colvarRequerido.ColumnName = "Requerido";
				colvarRequerido.DataType = DbType.Boolean;
				colvarRequerido.MaxLength = 0;
				colvarRequerido.AutoIncrement = false;
				colvarRequerido.IsNullable = true;
				colvarRequerido.IsPrimaryKey = false;
				colvarRequerido.IsForeignKey = false;
				colvarRequerido.IsReadOnly = false;
				
						colvarRequerido.DefaultSetting = @"((0))";
				colvarRequerido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRequerido);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SrmProvider"].AddSchema("TransaccionDocumentosRequisitos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("RquisitosTransaccionId")]
		[Bindable(true)]
		public int RquisitosTransaccionId 
		{
			get { return GetColumnValue<int>(Columns.RquisitosTransaccionId); }
			set { SetColumnValue(Columns.RquisitosTransaccionId, value); }
		}
		  
		[XmlAttribute("DocumentoId")]
		[Bindable(true)]
		public int DocumentoId 
		{
			get { return GetColumnValue<int>(Columns.DocumentoId); }
			set { SetColumnValue(Columns.DocumentoId, value); }
		}
		  
		[XmlAttribute("TipoServicioId")]
		[Bindable(true)]
		public int? TipoServicioId 
		{
			get { return GetColumnValue<int?>(Columns.TipoServicioId); }
			set { SetColumnValue(Columns.TipoServicioId, value); }
		}
		  
		[XmlAttribute("Requerido")]
		[Bindable(true)]
		public bool? Requerido 
		{
			get { return GetColumnValue<bool?>(Columns.Requerido); }
			set { SetColumnValue(Columns.Requerido, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Documentos ActiveRecord object related to this TransaccionDocumentosRequisitos
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.Documentos Documentos
		{
			get { return CamaraComercio.DataAccess.SRM.Documentos.FetchByID(this.DocumentoId); }
			set { SetColumnValue("DocumentoId", value.DocumentoId); }
		}
		
		
		/// <summary>
		/// Returns a TiposServicios ActiveRecord object related to this TransaccionDocumentosRequisitos
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.SRM.TiposServicios TiposServicios
		{
			get { return CamaraComercio.DataAccess.SRM.TiposServicios.FetchByID(this.TipoServicioId); }
			set { SetColumnValue("TipoServicioId", value.TipoServicioId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varDocumentoId,int? varTipoServicioId,bool? varRequerido)
		{
			TransaccionDocumentosRequisitos item = new TransaccionDocumentosRequisitos();
			
			item.DocumentoId = varDocumentoId;
			
			item.TipoServicioId = varTipoServicioId;
			
			item.Requerido = varRequerido;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varRquisitosTransaccionId,int varDocumentoId,int? varTipoServicioId,bool? varRequerido)
		{
			TransaccionDocumentosRequisitos item = new TransaccionDocumentosRequisitos();
			
				item.RquisitosTransaccionId = varRquisitosTransaccionId;
			
				item.DocumentoId = varDocumentoId;
			
				item.TipoServicioId = varTipoServicioId;
			
				item.Requerido = varRequerido;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn RquisitosTransaccionIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentoIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoServicioIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RequeridoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string RquisitosTransaccionId = @"RquisitosTransaccionId";
			 public static string DocumentoId = @"DocumentoId";
			 public static string TipoServicioId = @"TipoServicioId";
			 public static string Requerido = @"Requerido";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
