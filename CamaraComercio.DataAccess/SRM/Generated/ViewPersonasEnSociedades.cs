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
namespace CamaraComercio.DataAccess.SRM{
    /// <summary>
    /// Strongly-typed collection for the ViewPersonasEnSociedades class.
    /// </summary>
    [Serializable]
    public partial class ViewPersonasEnSociedadesCollection : ReadOnlyList<ViewPersonasEnSociedades, ViewPersonasEnSociedadesCollection>
    {        
        public ViewPersonasEnSociedadesCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_PersonasEnSociedades view.
    /// </summary>
    [Serializable]
    public partial class ViewPersonasEnSociedades : ReadOnlyRecord<ViewPersonasEnSociedades>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("cvw_PersonasEnSociedades", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Website";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarRegistroId = new TableSchema.TableColumn(schema);
                colvarRegistroId.ColumnName = "RegistroId";
                colvarRegistroId.DataType = DbType.Int32;
                colvarRegistroId.MaxLength = 0;
                colvarRegistroId.AutoIncrement = false;
                colvarRegistroId.IsNullable = false;
                colvarRegistroId.IsPrimaryKey = false;
                colvarRegistroId.IsForeignKey = false;
                colvarRegistroId.IsReadOnly = false;
                
                schema.Columns.Add(colvarRegistroId);
                
                TableSchema.TableColumn colvarNumeroRegistro = new TableSchema.TableColumn(schema);
                colvarNumeroRegistro.ColumnName = "NumeroRegistro";
                colvarNumeroRegistro.DataType = DbType.Int32;
                colvarNumeroRegistro.MaxLength = 0;
                colvarNumeroRegistro.AutoIncrement = false;
                colvarNumeroRegistro.IsNullable = true;
                colvarNumeroRegistro.IsPrimaryKey = false;
                colvarNumeroRegistro.IsForeignKey = false;
                colvarNumeroRegistro.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroRegistro);
                
                TableSchema.TableColumn colvarSocioId = new TableSchema.TableColumn(schema);
                colvarSocioId.ColumnName = "SocioId";
                colvarSocioId.DataType = DbType.Int32;
                colvarSocioId.MaxLength = 0;
                colvarSocioId.AutoIncrement = false;
                colvarSocioId.IsNullable = false;
                colvarSocioId.IsPrimaryKey = false;
                colvarSocioId.IsForeignKey = false;
                colvarSocioId.IsReadOnly = false;
                
                schema.Columns.Add(colvarSocioId);
                
                TableSchema.TableColumn colvarFechaConstitucion = new TableSchema.TableColumn(schema);
                colvarFechaConstitucion.ColumnName = "FechaConstitucion";
                colvarFechaConstitucion.DataType = DbType.DateTime;
                colvarFechaConstitucion.MaxLength = 0;
                colvarFechaConstitucion.AutoIncrement = false;
                colvarFechaConstitucion.IsNullable = true;
                colvarFechaConstitucion.IsPrimaryKey = false;
                colvarFechaConstitucion.IsForeignKey = false;
                colvarFechaConstitucion.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaConstitucion);
                
                TableSchema.TableColumn colvarTipoSocio = new TableSchema.TableColumn(schema);
                colvarTipoSocio.ColumnName = "TipoSocio";
                colvarTipoSocio.DataType = DbType.String;
                colvarTipoSocio.MaxLength = 1;
                colvarTipoSocio.AutoIncrement = false;
                colvarTipoSocio.IsNullable = false;
                colvarTipoSocio.IsPrimaryKey = false;
                colvarTipoSocio.IsForeignKey = false;
                colvarTipoSocio.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoSocio);
                
                TableSchema.TableColumn colvarTipoRelacion = new TableSchema.TableColumn(schema);
                colvarTipoRelacion.ColumnName = "TipoRelacion";
                colvarTipoRelacion.DataType = DbType.String;
                colvarTipoRelacion.MaxLength = 1;
                colvarTipoRelacion.AutoIncrement = false;
                colvarTipoRelacion.IsNullable = false;
                colvarTipoRelacion.IsPrimaryKey = false;
                colvarTipoRelacion.IsForeignKey = false;
                colvarTipoRelacion.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoRelacion);
                
                TableSchema.TableColumn colvarRegistroRelacion = new TableSchema.TableColumn(schema);
                colvarRegistroRelacion.ColumnName = "RegistroRelacion";
                colvarRegistroRelacion.DataType = DbType.String;
                colvarRegistroRelacion.MaxLength = 150;
                colvarRegistroRelacion.AutoIncrement = false;
                colvarRegistroRelacion.IsNullable = false;
                colvarRegistroRelacion.IsPrimaryKey = false;
                colvarRegistroRelacion.IsForeignKey = false;
                colvarRegistroRelacion.IsReadOnly = false;
                
                schema.Columns.Add(colvarRegistroRelacion);
                
                TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
                colvarDocumento.ColumnName = "Documento";
                colvarDocumento.DataType = DbType.String;
                colvarDocumento.MaxLength = 30;
                colvarDocumento.AutoIncrement = false;
                colvarDocumento.IsNullable = true;
                colvarDocumento.IsPrimaryKey = false;
                colvarDocumento.IsForeignKey = false;
                colvarDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarDocumento);
                
                TableSchema.TableColumn colvarAccionista = new TableSchema.TableColumn(schema);
                colvarAccionista.ColumnName = "Accionista";
                colvarAccionista.DataType = DbType.String;
                colvarAccionista.MaxLength = 417;
                colvarAccionista.AutoIncrement = false;
                colvarAccionista.IsNullable = true;
                colvarAccionista.IsPrimaryKey = false;
                colvarAccionista.IsForeignKey = false;
                colvarAccionista.IsReadOnly = false;
                
                schema.Columns.Add(colvarAccionista);
                
                TableSchema.TableColumn colvarNombreSocial = new TableSchema.TableColumn(schema);
                colvarNombreSocial.ColumnName = "NombreSocial";
                colvarNombreSocial.DataType = DbType.String;
                colvarNombreSocial.MaxLength = 150;
                colvarNombreSocial.AutoIncrement = false;
                colvarNombreSocial.IsNullable = true;
                colvarNombreSocial.IsPrimaryKey = false;
                colvarNombreSocial.IsForeignKey = false;
                colvarNombreSocial.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreSocial);
                
                TableSchema.TableColumn colvarRnc = new TableSchema.TableColumn(schema);
                colvarRnc.ColumnName = "Rnc";
                colvarRnc.DataType = DbType.String;
                colvarRnc.MaxLength = 15;
                colvarRnc.AutoIncrement = false;
                colvarRnc.IsNullable = false;
                colvarRnc.IsPrimaryKey = false;
                colvarRnc.IsForeignKey = false;
                colvarRnc.IsReadOnly = false;
                
                schema.Columns.Add(colvarRnc);
                
                TableSchema.TableColumn colvarTipoSociedadId = new TableSchema.TableColumn(schema);
                colvarTipoSociedadId.ColumnName = "TipoSociedadId";
                colvarTipoSociedadId.DataType = DbType.Int32;
                colvarTipoSociedadId.MaxLength = 0;
                colvarTipoSociedadId.AutoIncrement = false;
                colvarTipoSociedadId.IsNullable = true;
                colvarTipoSociedadId.IsPrimaryKey = false;
                colvarTipoSociedadId.IsForeignKey = false;
                colvarTipoSociedadId.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoSociedadId);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_PersonasEnSociedades",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public ViewPersonasEnSociedades()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewPersonasEnSociedades(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewPersonasEnSociedades(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewPersonasEnSociedades(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public int Id 
	    {
		    get
		    {
			    return GetColumnValue<int>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("RegistroId")]
        [Bindable(true)]
        public int RegistroId 
	    {
		    get
		    {
			    return GetColumnValue<int>("RegistroId");
		    }
            set 
		    {
			    SetColumnValue("RegistroId", value);
            }
        }
	      
        [XmlAttribute("NumeroRegistro")]
        [Bindable(true)]
        public int? NumeroRegistro 
	    {
		    get
		    {
			    return GetColumnValue<int?>("NumeroRegistro");
		    }
            set 
		    {
			    SetColumnValue("NumeroRegistro", value);
            }
        }
	      
        [XmlAttribute("SocioId")]
        [Bindable(true)]
        public int SocioId 
	    {
		    get
		    {
			    return GetColumnValue<int>("SocioId");
		    }
            set 
		    {
			    SetColumnValue("SocioId", value);
            }
        }
	      
        [XmlAttribute("FechaConstitucion")]
        [Bindable(true)]
        public DateTime? FechaConstitucion 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("FechaConstitucion");
		    }
            set 
		    {
			    SetColumnValue("FechaConstitucion", value);
            }
        }
	      
        [XmlAttribute("TipoSocio")]
        [Bindable(true)]
        public string TipoSocio 
	    {
		    get
		    {
			    return GetColumnValue<string>("TipoSocio");
		    }
            set 
		    {
			    SetColumnValue("TipoSocio", value);
            }
        }
	      
        [XmlAttribute("TipoRelacion")]
        [Bindable(true)]
        public string TipoRelacion 
	    {
		    get
		    {
			    return GetColumnValue<string>("TipoRelacion");
		    }
            set 
		    {
			    SetColumnValue("TipoRelacion", value);
            }
        }
	      
        [XmlAttribute("RegistroRelacion")]
        [Bindable(true)]
        public string RegistroRelacion 
	    {
		    get
		    {
			    return GetColumnValue<string>("RegistroRelacion");
		    }
            set 
		    {
			    SetColumnValue("RegistroRelacion", value);
            }
        }
	      
        [XmlAttribute("Documento")]
        [Bindable(true)]
        public string Documento 
	    {
		    get
		    {
			    return GetColumnValue<string>("Documento");
		    }
            set 
		    {
			    SetColumnValue("Documento", value);
            }
        }
	      
        [XmlAttribute("Accionista")]
        [Bindable(true)]
        public string Accionista 
	    {
		    get
		    {
			    return GetColumnValue<string>("Accionista");
		    }
            set 
		    {
			    SetColumnValue("Accionista", value);
            }
        }
	      
        [XmlAttribute("NombreSocial")]
        [Bindable(true)]
        public string NombreSocial 
	    {
		    get
		    {
			    return GetColumnValue<string>("NombreSocial");
		    }
            set 
		    {
			    SetColumnValue("NombreSocial", value);
            }
        }
	      
        [XmlAttribute("Rnc")]
        [Bindable(true)]
        public string Rnc 
	    {
		    get
		    {
			    return GetColumnValue<string>("Rnc");
		    }
            set 
		    {
			    SetColumnValue("Rnc", value);
            }
        }
	      
        [XmlAttribute("TipoSociedadId")]
        [Bindable(true)]
        public int? TipoSociedadId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("TipoSociedadId");
		    }
            set 
		    {
			    SetColumnValue("TipoSociedadId", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string RegistroId = @"RegistroId";
            
            public static string NumeroRegistro = @"NumeroRegistro";
            
            public static string SocioId = @"SocioId";
            
            public static string FechaConstitucion = @"FechaConstitucion";
            
            public static string TipoSocio = @"TipoSocio";
            
            public static string TipoRelacion = @"TipoRelacion";
            
            public static string RegistroRelacion = @"RegistroRelacion";
            
            public static string Documento = @"Documento";
            
            public static string Accionista = @"Accionista";
            
            public static string NombreSocial = @"NombreSocial";
            
            public static string Rnc = @"Rnc";
            
            public static string TipoSociedadId = @"TipoSociedadId";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
