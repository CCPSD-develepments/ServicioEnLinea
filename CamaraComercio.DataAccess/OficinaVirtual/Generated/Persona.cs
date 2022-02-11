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
	/// Strongly-typed collection for the Persona class.
	/// </summary>
    [Serializable]
	public partial class PersonaCollection : ActiveList<Persona, PersonaCollection>
	{	   
		public PersonaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PersonaCollection</returns>
		public PersonaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Persona o = this[i];
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
	/// This is an ActiveRecord class which wraps the Personas table.
	/// </summary>
	[Serializable]
	public partial class Persona : ActiveRecord<Persona>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Persona()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Persona(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Persona(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Persona(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Personas", TableType.Table, DataService.GetInstance("OficinaVirtualProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"WebSRM";
				//columns
				
				TableSchema.TableColumn colvarPersonaId = new TableSchema.TableColumn(schema);
				colvarPersonaId.ColumnName = "PersonaId";
				colvarPersonaId.DataType = DbType.Int32;
				colvarPersonaId.MaxLength = 0;
				colvarPersonaId.AutoIncrement = true;
				colvarPersonaId.IsNullable = false;
				colvarPersonaId.IsPrimaryKey = true;
				colvarPersonaId.IsForeignKey = false;
				colvarPersonaId.IsReadOnly = false;
				colvarPersonaId.DefaultSetting = @"";
				colvarPersonaId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPersonaId);
				
				TableSchema.TableColumn colvarRegistroId = new TableSchema.TableColumn(schema);
				colvarRegistroId.ColumnName = "RegistroId";
				colvarRegistroId.DataType = DbType.Int32;
				colvarRegistroId.MaxLength = 0;
				colvarRegistroId.AutoIncrement = false;
				colvarRegistroId.IsNullable = false;
				colvarRegistroId.IsPrimaryKey = false;
				colvarRegistroId.IsForeignKey = false;
				colvarRegistroId.IsReadOnly = false;
				
						colvarRegistroId.DefaultSetting = @"((0))";
				colvarRegistroId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegistroId);
				
				TableSchema.TableColumn colvarTipoDocumento = new TableSchema.TableColumn(schema);
				colvarTipoDocumento.ColumnName = "TipoDocumento";
				colvarTipoDocumento.DataType = DbType.String;
				colvarTipoDocumento.MaxLength = 1;
				colvarTipoDocumento.AutoIncrement = false;
				colvarTipoDocumento.IsNullable = false;
				colvarTipoDocumento.IsPrimaryKey = false;
				colvarTipoDocumento.IsForeignKey = false;
				colvarTipoDocumento.IsReadOnly = false;
				colvarTipoDocumento.DefaultSetting = @"";
				colvarTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocumento);
				
				TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
				colvarDocumento.ColumnName = "Documento";
				colvarDocumento.DataType = DbType.String;
				colvarDocumento.MaxLength = 15;
				colvarDocumento.AutoIncrement = false;
				colvarDocumento.IsNullable = false;
				colvarDocumento.IsPrimaryKey = false;
				colvarDocumento.IsForeignKey = false;
				colvarDocumento.IsReadOnly = false;
				colvarDocumento.DefaultSetting = @"";
				colvarDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumento);
				
				TableSchema.TableColumn colvarPrimerNombre = new TableSchema.TableColumn(schema);
				colvarPrimerNombre.ColumnName = "PrimerNombre";
				colvarPrimerNombre.DataType = DbType.String;
				colvarPrimerNombre.MaxLength = 30;
				colvarPrimerNombre.AutoIncrement = false;
				colvarPrimerNombre.IsNullable = false;
				colvarPrimerNombre.IsPrimaryKey = false;
				colvarPrimerNombre.IsForeignKey = false;
				colvarPrimerNombre.IsReadOnly = false;
				colvarPrimerNombre.DefaultSetting = @"";
				colvarPrimerNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimerNombre);
				
				TableSchema.TableColumn colvarSegundoNombre = new TableSchema.TableColumn(schema);
				colvarSegundoNombre.ColumnName = "SegundoNombre";
				colvarSegundoNombre.DataType = DbType.String;
				colvarSegundoNombre.MaxLength = 30;
				colvarSegundoNombre.AutoIncrement = false;
				colvarSegundoNombre.IsNullable = true;
				colvarSegundoNombre.IsPrimaryKey = false;
				colvarSegundoNombre.IsForeignKey = false;
				colvarSegundoNombre.IsReadOnly = false;
				colvarSegundoNombre.DefaultSetting = @"";
				colvarSegundoNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSegundoNombre);
				
				TableSchema.TableColumn colvarPrimerApellido = new TableSchema.TableColumn(schema);
				colvarPrimerApellido.ColumnName = "PrimerApellido";
				colvarPrimerApellido.DataType = DbType.String;
				colvarPrimerApellido.MaxLength = 30;
				colvarPrimerApellido.AutoIncrement = false;
				colvarPrimerApellido.IsNullable = false;
				colvarPrimerApellido.IsPrimaryKey = false;
				colvarPrimerApellido.IsForeignKey = false;
				colvarPrimerApellido.IsReadOnly = false;
				colvarPrimerApellido.DefaultSetting = @"";
				colvarPrimerApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimerApellido);
				
				TableSchema.TableColumn colvarSegundoApellido = new TableSchema.TableColumn(schema);
				colvarSegundoApellido.ColumnName = "SegundoApellido";
				colvarSegundoApellido.DataType = DbType.String;
				colvarSegundoApellido.MaxLength = 30;
				colvarSegundoApellido.AutoIncrement = false;
				colvarSegundoApellido.IsNullable = true;
				colvarSegundoApellido.IsPrimaryKey = false;
				colvarSegundoApellido.IsForeignKey = false;
				colvarSegundoApellido.IsReadOnly = false;
				colvarSegundoApellido.DefaultSetting = @"";
				colvarSegundoApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSegundoApellido);
				
				TableSchema.TableColumn colvarRnc = new TableSchema.TableColumn(schema);
				colvarRnc.ColumnName = "Rnc";
				colvarRnc.DataType = DbType.String;
				colvarRnc.MaxLength = 15;
				colvarRnc.AutoIncrement = false;
				colvarRnc.IsNullable = true;
				colvarRnc.IsPrimaryKey = false;
				colvarRnc.IsForeignKey = false;
				colvarRnc.IsReadOnly = false;
				colvarRnc.DefaultSetting = @"";
				colvarRnc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRnc);
				
				TableSchema.TableColumn colvarNacionalidadId = new TableSchema.TableColumn(schema);
				colvarNacionalidadId.ColumnName = "NacionalidadId";
				colvarNacionalidadId.DataType = DbType.Int32;
				colvarNacionalidadId.MaxLength = 0;
				colvarNacionalidadId.AutoIncrement = false;
				colvarNacionalidadId.IsNullable = true;
				colvarNacionalidadId.IsPrimaryKey = false;
				colvarNacionalidadId.IsForeignKey = false;
				colvarNacionalidadId.IsReadOnly = false;
				colvarNacionalidadId.DefaultSetting = @"";
				colvarNacionalidadId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNacionalidadId);
				
				TableSchema.TableColumn colvarEstadoCivil = new TableSchema.TableColumn(schema);
				colvarEstadoCivil.ColumnName = "EstadoCivil";
				colvarEstadoCivil.DataType = DbType.String;
				colvarEstadoCivil.MaxLength = 1;
				colvarEstadoCivil.AutoIncrement = false;
				colvarEstadoCivil.IsNullable = true;
				colvarEstadoCivil.IsPrimaryKey = false;
				colvarEstadoCivil.IsForeignKey = false;
				colvarEstadoCivil.IsReadOnly = false;
				colvarEstadoCivil.DefaultSetting = @"";
				colvarEstadoCivil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoCivil);
				
				TableSchema.TableColumn colvarProfesionId = new TableSchema.TableColumn(schema);
				colvarProfesionId.ColumnName = "ProfesionId";
				colvarProfesionId.DataType = DbType.Int32;
				colvarProfesionId.MaxLength = 0;
				colvarProfesionId.AutoIncrement = false;
				colvarProfesionId.IsNullable = true;
				colvarProfesionId.IsPrimaryKey = false;
				colvarProfesionId.IsForeignKey = false;
				colvarProfesionId.IsReadOnly = false;
				colvarProfesionId.DefaultSetting = @"";
				colvarProfesionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProfesionId);
				
				TableSchema.TableColumn colvarDireccionId = new TableSchema.TableColumn(schema);
				colvarDireccionId.ColumnName = "DireccionId";
				colvarDireccionId.DataType = DbType.Int32;
				colvarDireccionId.MaxLength = 0;
				colvarDireccionId.AutoIncrement = false;
				colvarDireccionId.IsNullable = true;
				colvarDireccionId.IsPrimaryKey = false;
				colvarDireccionId.IsForeignKey = true;
				colvarDireccionId.IsReadOnly = false;
				colvarDireccionId.DefaultSetting = @"";
				
					colvarDireccionId.ForeignKeyTableName = "Direcciones";
				schema.Columns.Add(colvarDireccionId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OficinaVirtualProvider"].AddSchema("Personas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PersonaId")]
		[Bindable(true)]
		public int PersonaId 
		{
			get { return GetColumnValue<int>(Columns.PersonaId); }
			set { SetColumnValue(Columns.PersonaId, value); }
		}
		  
		[XmlAttribute("RegistroId")]
		[Bindable(true)]
		public int RegistroId 
		{
			get { return GetColumnValue<int>(Columns.RegistroId); }
			set { SetColumnValue(Columns.RegistroId, value); }
		}
		  
		[XmlAttribute("TipoDocumento")]
		[Bindable(true)]
		public string TipoDocumento 
		{
			get { return GetColumnValue<string>(Columns.TipoDocumento); }
			set { SetColumnValue(Columns.TipoDocumento, value); }
		}
		  
		[XmlAttribute("Documento")]
		[Bindable(true)]
		public string Documento 
		{
			get { return GetColumnValue<string>(Columns.Documento); }
			set { SetColumnValue(Columns.Documento, value); }
		}
		  
		[XmlAttribute("PrimerNombre")]
		[Bindable(true)]
		public string PrimerNombre 
		{
			get { return GetColumnValue<string>(Columns.PrimerNombre); }
			set { SetColumnValue(Columns.PrimerNombre, value); }
		}
		  
		[XmlAttribute("SegundoNombre")]
		[Bindable(true)]
		public string SegundoNombre 
		{
			get { return GetColumnValue<string>(Columns.SegundoNombre); }
			set { SetColumnValue(Columns.SegundoNombre, value); }
		}
		  
		[XmlAttribute("PrimerApellido")]
		[Bindable(true)]
		public string PrimerApellido 
		{
			get { return GetColumnValue<string>(Columns.PrimerApellido); }
			set { SetColumnValue(Columns.PrimerApellido, value); }
		}
		  
		[XmlAttribute("SegundoApellido")]
		[Bindable(true)]
		public string SegundoApellido 
		{
			get { return GetColumnValue<string>(Columns.SegundoApellido); }
			set { SetColumnValue(Columns.SegundoApellido, value); }
		}
		  
		[XmlAttribute("Rnc")]
		[Bindable(true)]
		public string Rnc 
		{
			get { return GetColumnValue<string>(Columns.Rnc); }
			set { SetColumnValue(Columns.Rnc, value); }
		}
		  
		[XmlAttribute("NacionalidadId")]
		[Bindable(true)]
		public int? NacionalidadId 
		{
			get { return GetColumnValue<int?>(Columns.NacionalidadId); }
			set { SetColumnValue(Columns.NacionalidadId, value); }
		}
		  
		[XmlAttribute("EstadoCivil")]
		[Bindable(true)]
		public string EstadoCivil 
		{
			get { return GetColumnValue<string>(Columns.EstadoCivil); }
			set { SetColumnValue(Columns.EstadoCivil, value); }
		}
		  
		[XmlAttribute("ProfesionId")]
		[Bindable(true)]
		public int? ProfesionId 
		{
			get { return GetColumnValue<int?>(Columns.ProfesionId); }
			set { SetColumnValue(Columns.ProfesionId, value); }
		}
		  
		[XmlAttribute("DireccionId")]
		[Bindable(true)]
		public int? DireccionId 
		{
			get { return GetColumnValue<int?>(Columns.DireccionId); }
			set { SetColumnValue(Columns.DireccionId, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Direccion ActiveRecord object related to this Persona
		/// 
		/// </summary>
		public CamaraComercio.DataAccess.OficinaVirtual.Direccion Direccion
		{
			get { return CamaraComercio.DataAccess.OficinaVirtual.Direccion.FetchByID(this.DireccionId); }
			set { SetColumnValue("DireccionId", value.DireccionId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegistroId,string varTipoDocumento,string varDocumento,string varPrimerNombre,string varSegundoNombre,string varPrimerApellido,string varSegundoApellido,string varRnc,int? varNacionalidadId,string varEstadoCivil,int? varProfesionId,int? varDireccionId)
		{
			Persona item = new Persona();
			
			item.RegistroId = varRegistroId;
			
			item.TipoDocumento = varTipoDocumento;
			
			item.Documento = varDocumento;
			
			item.PrimerNombre = varPrimerNombre;
			
			item.SegundoNombre = varSegundoNombre;
			
			item.PrimerApellido = varPrimerApellido;
			
			item.SegundoApellido = varSegundoApellido;
			
			item.Rnc = varRnc;
			
			item.NacionalidadId = varNacionalidadId;
			
			item.EstadoCivil = varEstadoCivil;
			
			item.ProfesionId = varProfesionId;
			
			item.DireccionId = varDireccionId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPersonaId,int varRegistroId,string varTipoDocumento,string varDocumento,string varPrimerNombre,string varSegundoNombre,string varPrimerApellido,string varSegundoApellido,string varRnc,int? varNacionalidadId,string varEstadoCivil,int? varProfesionId,int? varDireccionId)
		{
			Persona item = new Persona();
			
				item.PersonaId = varPersonaId;
			
				item.RegistroId = varRegistroId;
			
				item.TipoDocumento = varTipoDocumento;
			
				item.Documento = varDocumento;
			
				item.PrimerNombre = varPrimerNombre;
			
				item.SegundoNombre = varSegundoNombre;
			
				item.PrimerApellido = varPrimerApellido;
			
				item.SegundoApellido = varSegundoApellido;
			
				item.Rnc = varRnc;
			
				item.NacionalidadId = varNacionalidadId;
			
				item.EstadoCivil = varEstadoCivil;
			
				item.ProfesionId = varProfesionId;
			
				item.DireccionId = varDireccionId;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PersonaIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RegistroIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocumentoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimerNombreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SegundoNombreColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimerApellidoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SegundoApellidoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn RncColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn NacionalidadIdColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoCivilColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ProfesionIdColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionIdColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PersonaId = @"PersonaId";
			 public static string RegistroId = @"RegistroId";
			 public static string TipoDocumento = @"TipoDocumento";
			 public static string Documento = @"Documento";
			 public static string PrimerNombre = @"PrimerNombre";
			 public static string SegundoNombre = @"SegundoNombre";
			 public static string PrimerApellido = @"PrimerApellido";
			 public static string SegundoApellido = @"SegundoApellido";
			 public static string Rnc = @"Rnc";
			 public static string NacionalidadId = @"NacionalidadId";
			 public static string EstadoCivil = @"EstadoCivil";
			 public static string ProfesionId = @"ProfesionId";
			 public static string DireccionId = @"DireccionId";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
