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
    /// Strongly-typed collection for the ViewAllHistoricosDocumentos class.
    /// </summary>
    [Serializable]
    public partial class ViewAllHistoricosDocumentosCollection : ReadOnlyList<ViewAllHistoricosDocumentos, ViewAllHistoricosDocumentosCollection>
    {        
        public ViewAllHistoricosDocumentosCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_AllHistoricosDocumentos view.
    /// </summary>
    [Serializable]
    public partial class ViewAllHistoricosDocumentos : ReadOnlyRecord<ViewAllHistoricosDocumentos>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("cvw_AllHistoricosDocumentos", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Historico";
                //columns
                
                TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
                colvarNumeroDocumento.ColumnName = "NumeroDocumento";
                colvarNumeroDocumento.DataType = DbType.Int32;
                colvarNumeroDocumento.MaxLength = 0;
                colvarNumeroDocumento.AutoIncrement = false;
                colvarNumeroDocumento.IsNullable = true;
                colvarNumeroDocumento.IsPrimaryKey = false;
                colvarNumeroDocumento.IsForeignKey = false;
                colvarNumeroDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumento);
                
                TableSchema.TableColumn colvarNombreDocumento = new TableSchema.TableColumn(schema);
                colvarNombreDocumento.ColumnName = "NombreDocumento";
                colvarNombreDocumento.DataType = DbType.String;
                colvarNombreDocumento.MaxLength = 150;
                colvarNombreDocumento.AutoIncrement = false;
                colvarNombreDocumento.IsNullable = true;
                colvarNombreDocumento.IsPrimaryKey = false;
                colvarNombreDocumento.IsForeignKey = false;
                colvarNombreDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreDocumento);
                
                TableSchema.TableColumn colvarFechaDocumento = new TableSchema.TableColumn(schema);
                colvarFechaDocumento.ColumnName = "FechaDocumento";
                colvarFechaDocumento.DataType = DbType.DateTime;
                colvarFechaDocumento.MaxLength = 0;
                colvarFechaDocumento.AutoIncrement = false;
                colvarFechaDocumento.IsNullable = true;
                colvarFechaDocumento.IsPrimaryKey = false;
                colvarFechaDocumento.IsForeignKey = false;
                colvarFechaDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaDocumento);
                
                TableSchema.TableColumn colvarLibro = new TableSchema.TableColumn(schema);
                colvarLibro.ColumnName = "Libro";
                colvarLibro.DataType = DbType.Int32;
                colvarLibro.MaxLength = 0;
                colvarLibro.AutoIncrement = false;
                colvarLibro.IsNullable = true;
                colvarLibro.IsPrimaryKey = false;
                colvarLibro.IsForeignKey = false;
                colvarLibro.IsReadOnly = false;
                
                schema.Columns.Add(colvarLibro);
                
                TableSchema.TableColumn colvarFolio = new TableSchema.TableColumn(schema);
                colvarFolio.ColumnName = "Folio";
                colvarFolio.DataType = DbType.Int32;
                colvarFolio.MaxLength = 0;
                colvarFolio.AutoIncrement = false;
                colvarFolio.IsNullable = true;
                colvarFolio.IsPrimaryKey = false;
                colvarFolio.IsForeignKey = false;
                colvarFolio.IsReadOnly = false;
                
                schema.Columns.Add(colvarFolio);
                
                TableSchema.TableColumn colvarTransaccion = new TableSchema.TableColumn(schema);
                colvarTransaccion.ColumnName = "Transaccion";
                colvarTransaccion.DataType = DbType.Int32;
                colvarTransaccion.MaxLength = 0;
                colvarTransaccion.AutoIncrement = false;
                colvarTransaccion.IsNullable = false;
                colvarTransaccion.IsPrimaryKey = false;
                colvarTransaccion.IsForeignKey = false;
                colvarTransaccion.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransaccion);
                
                TableSchema.TableColumn colvarSubTransaccionId = new TableSchema.TableColumn(schema);
                colvarSubTransaccionId.ColumnName = "SubTransaccionId";
                colvarSubTransaccionId.DataType = DbType.Int32;
                colvarSubTransaccionId.MaxLength = 0;
                colvarSubTransaccionId.AutoIncrement = false;
                colvarSubTransaccionId.IsNullable = true;
                colvarSubTransaccionId.IsPrimaryKey = false;
                colvarSubTransaccionId.IsForeignKey = false;
                colvarSubTransaccionId.IsReadOnly = false;
                
                schema.Columns.Add(colvarSubTransaccionId);
                
                TableSchema.TableColumn colvarRegistroId = new TableSchema.TableColumn(schema);
                colvarRegistroId.ColumnName = "RegistroId";
                colvarRegistroId.DataType = DbType.Int32;
                colvarRegistroId.MaxLength = 0;
                colvarRegistroId.AutoIncrement = false;
                colvarRegistroId.IsNullable = true;
                colvarRegistroId.IsPrimaryKey = false;
                colvarRegistroId.IsForeignKey = false;
                colvarRegistroId.IsReadOnly = false;
                
                schema.Columns.Add(colvarRegistroId);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_AllHistoricosDocumentos",schema);
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
	    public ViewAllHistoricosDocumentos()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewAllHistoricosDocumentos(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewAllHistoricosDocumentos(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewAllHistoricosDocumentos(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("NumeroDocumento")]
        [Bindable(true)]
        public int? NumeroDocumento 
	    {
		    get
		    {
			    return GetColumnValue<int?>("NumeroDocumento");
		    }
            set 
		    {
			    SetColumnValue("NumeroDocumento", value);
            }
        }
	      
        [XmlAttribute("NombreDocumento")]
        [Bindable(true)]
        public string NombreDocumento 
	    {
		    get
		    {
			    return GetColumnValue<string>("NombreDocumento");
		    }
            set 
		    {
			    SetColumnValue("NombreDocumento", value);
            }
        }
	      
        [XmlAttribute("FechaDocumento")]
        [Bindable(true)]
        public DateTime? FechaDocumento 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("FechaDocumento");
		    }
            set 
		    {
			    SetColumnValue("FechaDocumento", value);
            }
        }
	      
        [XmlAttribute("Libro")]
        [Bindable(true)]
        public int? Libro 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Libro");
		    }
            set 
		    {
			    SetColumnValue("Libro", value);
            }
        }
	      
        [XmlAttribute("Folio")]
        [Bindable(true)]
        public int? Folio 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Folio");
		    }
            set 
		    {
			    SetColumnValue("Folio", value);
            }
        }
	      
        [XmlAttribute("Transaccion")]
        [Bindable(true)]
        public int Transaccion 
	    {
		    get
		    {
			    return GetColumnValue<int>("Transaccion");
		    }
            set 
		    {
			    SetColumnValue("Transaccion", value);
            }
        }
	      
        [XmlAttribute("SubTransaccionId")]
        [Bindable(true)]
        public int? SubTransaccionId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("SubTransaccionId");
		    }
            set 
		    {
			    SetColumnValue("SubTransaccionId", value);
            }
        }
	      
        [XmlAttribute("RegistroId")]
        [Bindable(true)]
        public int? RegistroId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("RegistroId");
		    }
            set 
		    {
			    SetColumnValue("RegistroId", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string NumeroDocumento = @"NumeroDocumento";
            
            public static string NombreDocumento = @"NombreDocumento";
            
            public static string FechaDocumento = @"FechaDocumento";
            
            public static string Libro = @"Libro";
            
            public static string Folio = @"Folio";
            
            public static string Transaccion = @"Transaccion";
            
            public static string SubTransaccionId = @"SubTransaccionId";
            
            public static string RegistroId = @"RegistroId";
            
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
