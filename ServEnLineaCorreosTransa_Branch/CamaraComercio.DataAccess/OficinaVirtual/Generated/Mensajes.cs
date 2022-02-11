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
	/// Strongly-typed collection for the Mensajes class.
	/// </summary>
    [Serializable]
	public partial class MensajesCollection : ActiveList<Mensajes, MensajesCollection>
	{	   
		public MensajesCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MensajesCollection</returns>
		public MensajesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Mensajes o = this[i];
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
	/// This is an ActiveRecord class which wraps the Mensajes table.
	/// </summary>
	[Serializable]
	public partial class Mensajes : ActiveRecord<Mensajes>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Mensajes()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Mensajes(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Mensajes(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Mensajes(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Mensajes", TableType.Table, DataService.GetInstance("OficinaVirtualProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"OFV";
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
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "Usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = 50;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = false;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				TableSchema.TableColumn colvarUsuarioSistema = new TableSchema.TableColumn(schema);
				colvarUsuarioSistema.ColumnName = "UsuarioSistema";
				colvarUsuarioSistema.DataType = DbType.String;
				colvarUsuarioSistema.MaxLength = 50;
				colvarUsuarioSistema.AutoIncrement = false;
				colvarUsuarioSistema.IsNullable = false;
				colvarUsuarioSistema.IsPrimaryKey = false;
				colvarUsuarioSistema.IsForeignKey = false;
				colvarUsuarioSistema.IsReadOnly = false;
				colvarUsuarioSistema.DefaultSetting = @"";
				colvarUsuarioSistema.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioSistema);
				
				TableSchema.TableColumn colvarSociedadID = new TableSchema.TableColumn(schema);
				colvarSociedadID.ColumnName = "SociedadID";
				colvarSociedadID.DataType = DbType.Int32;
				colvarSociedadID.MaxLength = 0;
				colvarSociedadID.AutoIncrement = false;
				colvarSociedadID.IsNullable = true;
				colvarSociedadID.IsPrimaryKey = false;
				colvarSociedadID.IsForeignKey = false;
				colvarSociedadID.IsReadOnly = false;
				colvarSociedadID.DefaultSetting = @"";
				colvarSociedadID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSociedadID);
				
				TableSchema.TableColumn colvarTitulo = new TableSchema.TableColumn(schema);
				colvarTitulo.ColumnName = "Titulo";
				colvarTitulo.DataType = DbType.String;
				colvarTitulo.MaxLength = 100;
				colvarTitulo.AutoIncrement = false;
				colvarTitulo.IsNullable = true;
				colvarTitulo.IsPrimaryKey = false;
				colvarTitulo.IsForeignKey = false;
				colvarTitulo.IsReadOnly = false;
				colvarTitulo.DefaultSetting = @"";
				colvarTitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitulo);
				
				TableSchema.TableColumn colvarMensaje = new TableSchema.TableColumn(schema);
				colvarMensaje.ColumnName = "Mensaje";
				colvarMensaje.DataType = DbType.String;
				colvarMensaje.MaxLength = -1;
				colvarMensaje.AutoIncrement = false;
				colvarMensaje.IsNullable = false;
				colvarMensaje.IsPrimaryKey = false;
				colvarMensaje.IsForeignKey = false;
				colvarMensaje.IsReadOnly = false;
				colvarMensaje.DefaultSetting = @"";
				colvarMensaje.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMensaje);
				
				TableSchema.TableColumn colvarFechaEnvio = new TableSchema.TableColumn(schema);
				colvarFechaEnvio.ColumnName = "FechaEnvio";
				colvarFechaEnvio.DataType = DbType.DateTime;
				colvarFechaEnvio.MaxLength = 0;
				colvarFechaEnvio.AutoIncrement = false;
				colvarFechaEnvio.IsNullable = true;
				colvarFechaEnvio.IsPrimaryKey = false;
				colvarFechaEnvio.IsForeignKey = false;
				colvarFechaEnvio.IsReadOnly = false;
				colvarFechaEnvio.DefaultSetting = @"";
				colvarFechaEnvio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEnvio);
				
				TableSchema.TableColumn colvarFechaLectura = new TableSchema.TableColumn(schema);
				colvarFechaLectura.ColumnName = "FechaLectura";
				colvarFechaLectura.DataType = DbType.DateTime;
				colvarFechaLectura.MaxLength = 0;
				colvarFechaLectura.AutoIncrement = false;
				colvarFechaLectura.IsNullable = true;
				colvarFechaLectura.IsPrimaryKey = false;
				colvarFechaLectura.IsForeignKey = false;
				colvarFechaLectura.IsReadOnly = false;
				colvarFechaLectura.DefaultSetting = @"";
				colvarFechaLectura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaLectura);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OficinaVirtualProvider"].AddSchema("Mensajes",schema);
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
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("UsuarioSistema")]
		[Bindable(true)]
		public string UsuarioSistema 
		{
			get { return GetColumnValue<string>(Columns.UsuarioSistema); }
			set { SetColumnValue(Columns.UsuarioSistema, value); }
		}
		  
		[XmlAttribute("SociedadID")]
		[Bindable(true)]
		public int? SociedadID 
		{
			get { return GetColumnValue<int?>(Columns.SociedadID); }
			set { SetColumnValue(Columns.SociedadID, value); }
		}
		  
		[XmlAttribute("Titulo")]
		[Bindable(true)]
		public string Titulo 
		{
			get { return GetColumnValue<string>(Columns.Titulo); }
			set { SetColumnValue(Columns.Titulo, value); }
		}
		  
		[XmlAttribute("Mensaje")]
		[Bindable(true)]
		public string Mensaje 
		{
			get { return GetColumnValue<string>(Columns.Mensaje); }
			set { SetColumnValue(Columns.Mensaje, value); }
		}
		  
		[XmlAttribute("FechaEnvio")]
		[Bindable(true)]
		public DateTime? FechaEnvio 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEnvio); }
			set { SetColumnValue(Columns.FechaEnvio, value); }
		}
		  
		[XmlAttribute("FechaLectura")]
		[Bindable(true)]
		public DateTime? FechaLectura 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaLectura); }
			set { SetColumnValue(Columns.FechaLectura, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUsuario,string varUsuarioSistema,int? varSociedadID,string varTitulo,string varMensaje,DateTime? varFechaEnvio,DateTime? varFechaLectura)
		{
			Mensajes item = new Mensajes();
			
			item.Usuario = varUsuario;
			
			item.UsuarioSistema = varUsuarioSistema;
			
			item.SociedadID = varSociedadID;
			
			item.Titulo = varTitulo;
			
			item.Mensaje = varMensaje;
			
			item.FechaEnvio = varFechaEnvio;
			
			item.FechaLectura = varFechaLectura;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varUsuario,string varUsuarioSistema,int? varSociedadID,string varTitulo,string varMensaje,DateTime? varFechaEnvio,DateTime? varFechaLectura)
		{
			Mensajes item = new Mensajes();
			
				item.Id = varId;
			
				item.Usuario = varUsuario;
			
				item.UsuarioSistema = varUsuarioSistema;
			
				item.SociedadID = varSociedadID;
			
				item.Titulo = varTitulo;
			
				item.Mensaje = varMensaje;
			
				item.FechaEnvio = varFechaEnvio;
			
				item.FechaLectura = varFechaLectura;
			
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
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioSistemaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SociedadIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TituloColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MensajeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEnvioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaLecturaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Usuario = @"Usuario";
			 public static string UsuarioSistema = @"UsuarioSistema";
			 public static string SociedadID = @"SociedadID";
			 public static string Titulo = @"Titulo";
			 public static string Mensaje = @"Mensaje";
			 public static string FechaEnvio = @"FechaEnvio";
			 public static string FechaLectura = @"FechaLectura";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
