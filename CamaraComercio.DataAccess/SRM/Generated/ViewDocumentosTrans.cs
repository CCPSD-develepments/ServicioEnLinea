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
    /// Strongly-typed collection for the ViewDocumentosTrans class.
    /// </summary>
    [Serializable]
    public partial class ViewDocumentosTransCollection : ReadOnlyList<ViewDocumentosTrans, ViewDocumentosTransCollection>
    {        
        public ViewDocumentosTransCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_DocumentosTrans view.
    /// </summary>
    [Serializable]
    public partial class ViewDocumentosTrans : ReadOnlyRecord<ViewDocumentosTrans>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("cvw_DocumentosTrans", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Transaccion";
                //columns
                
                TableSchema.TableColumn colvarDocumentoTransaccionId = new TableSchema.TableColumn(schema);
                colvarDocumentoTransaccionId.ColumnName = "DocumentoTransaccionId";
                colvarDocumentoTransaccionId.DataType = DbType.Int32;
                colvarDocumentoTransaccionId.MaxLength = 0;
                colvarDocumentoTransaccionId.AutoIncrement = false;
                colvarDocumentoTransaccionId.IsNullable = false;
                colvarDocumentoTransaccionId.IsPrimaryKey = false;
                colvarDocumentoTransaccionId.IsForeignKey = false;
                colvarDocumentoTransaccionId.IsReadOnly = false;
                
                schema.Columns.Add(colvarDocumentoTransaccionId);
                
                TableSchema.TableColumn colvarTransaccionId = new TableSchema.TableColumn(schema);
                colvarTransaccionId.ColumnName = "TransaccionId";
                colvarTransaccionId.DataType = DbType.Int32;
                colvarTransaccionId.MaxLength = 0;
                colvarTransaccionId.AutoIncrement = false;
                colvarTransaccionId.IsNullable = false;
                colvarTransaccionId.IsPrimaryKey = false;
                colvarTransaccionId.IsForeignKey = false;
                colvarTransaccionId.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransaccionId);
                
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
                
                TableSchema.TableColumn colvarDocumentoId = new TableSchema.TableColumn(schema);
                colvarDocumentoId.ColumnName = "DocumentoId";
                colvarDocumentoId.DataType = DbType.Int32;
                colvarDocumentoId.MaxLength = 0;
                colvarDocumentoId.AutoIncrement = false;
                colvarDocumentoId.IsNullable = false;
                colvarDocumentoId.IsPrimaryKey = false;
                colvarDocumentoId.IsForeignKey = false;
                colvarDocumentoId.IsReadOnly = false;
                
                schema.Columns.Add(colvarDocumentoId);
                
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
                
                TableSchema.TableColumn colvarNoOriginales = new TableSchema.TableColumn(schema);
                colvarNoOriginales.ColumnName = "NoOriginales";
                colvarNoOriginales.DataType = DbType.Int32;
                colvarNoOriginales.MaxLength = 0;
                colvarNoOriginales.AutoIncrement = false;
                colvarNoOriginales.IsNullable = false;
                colvarNoOriginales.IsPrimaryKey = false;
                colvarNoOriginales.IsForeignKey = false;
                colvarNoOriginales.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoOriginales);
                
                TableSchema.TableColumn colvarNoCopias = new TableSchema.TableColumn(schema);
                colvarNoCopias.ColumnName = "NoCopias";
                colvarNoCopias.DataType = DbType.Int32;
                colvarNoCopias.MaxLength = 0;
                colvarNoCopias.AutoIncrement = false;
                colvarNoCopias.IsNullable = false;
                colvarNoCopias.IsPrimaryKey = false;
                colvarNoCopias.IsForeignKey = false;
                colvarNoCopias.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoCopias);
                
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
                
                TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
                colvarComentario.ColumnName = "Comentario";
                colvarComentario.DataType = DbType.String;
                colvarComentario.MaxLength = 1000;
                colvarComentario.AutoIncrement = false;
                colvarComentario.IsNullable = true;
                colvarComentario.IsPrimaryKey = false;
                colvarComentario.IsForeignKey = false;
                colvarComentario.IsReadOnly = false;
                
                schema.Columns.Add(colvarComentario);
                
                TableSchema.TableColumn colvarAlertaPago = new TableSchema.TableColumn(schema);
                colvarAlertaPago.ColumnName = "AlertaPago";
                colvarAlertaPago.DataType = DbType.Boolean;
                colvarAlertaPago.MaxLength = 0;
                colvarAlertaPago.AutoIncrement = false;
                colvarAlertaPago.IsNullable = true;
                colvarAlertaPago.IsPrimaryKey = false;
                colvarAlertaPago.IsForeignKey = false;
                colvarAlertaPago.IsReadOnly = false;
                
                schema.Columns.Add(colvarAlertaPago);
                
                TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
                colvarFechaModificacion.ColumnName = "FechaModificacion";
                colvarFechaModificacion.DataType = DbType.DateTime;
                colvarFechaModificacion.MaxLength = 0;
                colvarFechaModificacion.AutoIncrement = false;
                colvarFechaModificacion.IsNullable = false;
                colvarFechaModificacion.IsPrimaryKey = false;
                colvarFechaModificacion.IsForeignKey = false;
                colvarFechaModificacion.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaModificacion);
                
                TableSchema.TableColumn colvarRowguid = new TableSchema.TableColumn(schema);
                colvarRowguid.ColumnName = "rowguid";
                colvarRowguid.DataType = DbType.Guid;
                colvarRowguid.MaxLength = 0;
                colvarRowguid.AutoIncrement = false;
                colvarRowguid.IsNullable = false;
                colvarRowguid.IsPrimaryKey = false;
                colvarRowguid.IsForeignKey = false;
                colvarRowguid.IsReadOnly = false;
                
                schema.Columns.Add(colvarRowguid);
                
                TableSchema.TableColumn colvarCheckValidated = new TableSchema.TableColumn(schema);
                colvarCheckValidated.ColumnName = "CheckValidated";
                colvarCheckValidated.DataType = DbType.Boolean;
                colvarCheckValidated.MaxLength = 0;
                colvarCheckValidated.AutoIncrement = false;
                colvarCheckValidated.IsNullable = false;
                colvarCheckValidated.IsPrimaryKey = false;
                colvarCheckValidated.IsForeignKey = false;
                colvarCheckValidated.IsReadOnly = false;
                
                schema.Columns.Add(colvarCheckValidated);
                
                TableSchema.TableColumn colvarDeleted = new TableSchema.TableColumn(schema);
                colvarDeleted.ColumnName = "Deleted";
                colvarDeleted.DataType = DbType.Boolean;
                colvarDeleted.MaxLength = 0;
                colvarDeleted.AutoIncrement = false;
                colvarDeleted.IsNullable = false;
                colvarDeleted.IsPrimaryKey = false;
                colvarDeleted.IsForeignKey = false;
                colvarDeleted.IsReadOnly = false;
                
                schema.Columns.Add(colvarDeleted);
                
                TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
                colvarDocumento.ColumnName = "Documento";
                colvarDocumento.DataType = DbType.String;
                colvarDocumento.MaxLength = 150;
                colvarDocumento.AutoIncrement = false;
                colvarDocumento.IsNullable = true;
                colvarDocumento.IsPrimaryKey = false;
                colvarDocumento.IsForeignKey = false;
                colvarDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarDocumento);
                
                TableSchema.TableColumn colvarRegistrable = new TableSchema.TableColumn(schema);
                colvarRegistrable.ColumnName = "Registrable";
                colvarRegistrable.DataType = DbType.Boolean;
                colvarRegistrable.MaxLength = 0;
                colvarRegistrable.AutoIncrement = false;
                colvarRegistrable.IsNullable = true;
                colvarRegistrable.IsPrimaryKey = false;
                colvarRegistrable.IsForeignKey = false;
                colvarRegistrable.IsReadOnly = false;
                
                schema.Columns.Add(colvarRegistrable);
                
                TableSchema.TableColumn colvarCostoOriginal = new TableSchema.TableColumn(schema);
                colvarCostoOriginal.ColumnName = "CostoOriginal";
                colvarCostoOriginal.DataType = DbType.Currency;
                colvarCostoOriginal.MaxLength = 0;
                colvarCostoOriginal.AutoIncrement = false;
                colvarCostoOriginal.IsNullable = true;
                colvarCostoOriginal.IsPrimaryKey = false;
                colvarCostoOriginal.IsForeignKey = false;
                colvarCostoOriginal.IsReadOnly = false;
                
                schema.Columns.Add(colvarCostoOriginal);
                
                TableSchema.TableColumn colvarCostoCopia = new TableSchema.TableColumn(schema);
                colvarCostoCopia.ColumnName = "CostoCopia";
                colvarCostoCopia.DataType = DbType.Currency;
                colvarCostoCopia.MaxLength = 0;
                colvarCostoCopia.AutoIncrement = false;
                colvarCostoCopia.IsNullable = true;
                colvarCostoCopia.IsPrimaryKey = false;
                colvarCostoCopia.IsForeignKey = false;
                colvarCostoCopia.IsReadOnly = false;
                
                schema.Columns.Add(colvarCostoCopia);
                
                TableSchema.TableColumn colvarCostoTotalOriginales = new TableSchema.TableColumn(schema);
                colvarCostoTotalOriginales.ColumnName = "CostoTotalOriginales";
                colvarCostoTotalOriginales.DataType = DbType.Currency;
                colvarCostoTotalOriginales.MaxLength = 0;
                colvarCostoTotalOriginales.AutoIncrement = false;
                colvarCostoTotalOriginales.IsNullable = true;
                colvarCostoTotalOriginales.IsPrimaryKey = false;
                colvarCostoTotalOriginales.IsForeignKey = false;
                colvarCostoTotalOriginales.IsReadOnly = false;
                
                schema.Columns.Add(colvarCostoTotalOriginales);
                
                TableSchema.TableColumn colvarCostoTotalCopias = new TableSchema.TableColumn(schema);
                colvarCostoTotalCopias.ColumnName = "CostoTotalCopias";
                colvarCostoTotalCopias.DataType = DbType.Currency;
                colvarCostoTotalCopias.MaxLength = 0;
                colvarCostoTotalCopias.AutoIncrement = false;
                colvarCostoTotalCopias.IsNullable = true;
                colvarCostoTotalCopias.IsPrimaryKey = false;
                colvarCostoTotalCopias.IsForeignKey = false;
                colvarCostoTotalCopias.IsReadOnly = false;
                
                schema.Columns.Add(colvarCostoTotalCopias);
                
                TableSchema.TableColumn colvarNoDocumento = new TableSchema.TableColumn(schema);
                colvarNoDocumento.ColumnName = "NoDocumento";
                colvarNoDocumento.DataType = DbType.Int32;
                colvarNoDocumento.MaxLength = 0;
                colvarNoDocumento.AutoIncrement = false;
                colvarNoDocumento.IsNullable = true;
                colvarNoDocumento.IsPrimaryKey = false;
                colvarNoDocumento.IsForeignKey = false;
                colvarNoDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoDocumento);
                
                TableSchema.TableColumn colvarNumeroPaginas = new TableSchema.TableColumn(schema);
                colvarNumeroPaginas.ColumnName = "NumeroPaginas";
                colvarNumeroPaginas.DataType = DbType.Int32;
                colvarNumeroPaginas.MaxLength = 0;
                colvarNumeroPaginas.AutoIncrement = false;
                colvarNumeroPaginas.IsNullable = true;
                colvarNumeroPaginas.IsPrimaryKey = false;
                colvarNumeroPaginas.IsForeignKey = false;
                colvarNumeroPaginas.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroPaginas);
                
                TableSchema.TableColumn colvarDigitalizado = new TableSchema.TableColumn(schema);
                colvarDigitalizado.ColumnName = "Digitalizado";
                colvarDigitalizado.DataType = DbType.Boolean;
                colvarDigitalizado.MaxLength = 0;
                colvarDigitalizado.AutoIncrement = false;
                colvarDigitalizado.IsNullable = true;
                colvarDigitalizado.IsPrimaryKey = false;
                colvarDigitalizado.IsForeignKey = false;
                colvarDigitalizado.IsReadOnly = false;
                
                schema.Columns.Add(colvarDigitalizado);
                
                TableSchema.TableColumn colvarFechaDigitalizacion = new TableSchema.TableColumn(schema);
                colvarFechaDigitalizacion.ColumnName = "FechaDigitalizacion";
                colvarFechaDigitalizacion.DataType = DbType.DateTime;
                colvarFechaDigitalizacion.MaxLength = 0;
                colvarFechaDigitalizacion.AutoIncrement = false;
                colvarFechaDigitalizacion.IsNullable = true;
                colvarFechaDigitalizacion.IsPrimaryKey = false;
                colvarFechaDigitalizacion.IsForeignKey = false;
                colvarFechaDigitalizacion.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaDigitalizacion);
                
                TableSchema.TableColumn colvarAnalizado = new TableSchema.TableColumn(schema);
                colvarAnalizado.ColumnName = "Analizado";
                colvarAnalizado.DataType = DbType.Boolean;
                colvarAnalizado.MaxLength = 0;
                colvarAnalizado.AutoIncrement = false;
                colvarAnalizado.IsNullable = true;
                colvarAnalizado.IsPrimaryKey = false;
                colvarAnalizado.IsForeignKey = false;
                colvarAnalizado.IsReadOnly = false;
                
                schema.Columns.Add(colvarAnalizado);
                
                TableSchema.TableColumn colvarSufijo = new TableSchema.TableColumn(schema);
                colvarSufijo.ColumnName = "Sufijo";
                colvarSufijo.DataType = DbType.AnsiString;
                colvarSufijo.MaxLength = 7;
                colvarSufijo.AutoIncrement = false;
                colvarSufijo.IsNullable = true;
                colvarSufijo.IsPrimaryKey = false;
                colvarSufijo.IsForeignKey = false;
                colvarSufijo.IsReadOnly = false;
                
                schema.Columns.Add(colvarSufijo);
                
                TableSchema.TableColumn colvarTransSufijo = new TableSchema.TableColumn(schema);
                colvarTransSufijo.ColumnName = "TransSufijo";
                colvarTransSufijo.DataType = DbType.AnsiString;
                colvarTransSufijo.MaxLength = 2;
                colvarTransSufijo.AutoIncrement = false;
                colvarTransSufijo.IsNullable = true;
                colvarTransSufijo.IsPrimaryKey = false;
                colvarTransSufijo.IsForeignKey = false;
                colvarTransSufijo.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransSufijo);
                
                TableSchema.TableColumn colvarTipoTransaccion = new TableSchema.TableColumn(schema);
                colvarTipoTransaccion.ColumnName = "TipoTransaccion";
                colvarTipoTransaccion.DataType = DbType.AnsiString;
                colvarTipoTransaccion.MaxLength = 50;
                colvarTipoTransaccion.AutoIncrement = false;
                colvarTipoTransaccion.IsNullable = true;
                colvarTipoTransaccion.IsPrimaryKey = false;
                colvarTipoTransaccion.IsForeignKey = false;
                colvarTipoTransaccion.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoTransaccion);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_DocumentosTrans",schema);
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
	    public ViewDocumentosTrans()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewDocumentosTrans(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewDocumentosTrans(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewDocumentosTrans(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("DocumentoTransaccionId")]
        [Bindable(true)]
        public int DocumentoTransaccionId 
	    {
		    get
		    {
			    return GetColumnValue<int>("DocumentoTransaccionId");
		    }
            set 
		    {
			    SetColumnValue("DocumentoTransaccionId", value);
            }
        }
	      
        [XmlAttribute("TransaccionId")]
        [Bindable(true)]
        public int TransaccionId 
	    {
		    get
		    {
			    return GetColumnValue<int>("TransaccionId");
		    }
            set 
		    {
			    SetColumnValue("TransaccionId", value);
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
	      
        [XmlAttribute("DocumentoId")]
        [Bindable(true)]
        public int DocumentoId 
	    {
		    get
		    {
			    return GetColumnValue<int>("DocumentoId");
		    }
            set 
		    {
			    SetColumnValue("DocumentoId", value);
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
	      
        [XmlAttribute("NoOriginales")]
        [Bindable(true)]
        public int NoOriginales 
	    {
		    get
		    {
			    return GetColumnValue<int>("NoOriginales");
		    }
            set 
		    {
			    SetColumnValue("NoOriginales", value);
            }
        }
	      
        [XmlAttribute("NoCopias")]
        [Bindable(true)]
        public int NoCopias 
	    {
		    get
		    {
			    return GetColumnValue<int>("NoCopias");
		    }
            set 
		    {
			    SetColumnValue("NoCopias", value);
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
	      
        [XmlAttribute("Comentario")]
        [Bindable(true)]
        public string Comentario 
	    {
		    get
		    {
			    return GetColumnValue<string>("Comentario");
		    }
            set 
		    {
			    SetColumnValue("Comentario", value);
            }
        }
	      
        [XmlAttribute("AlertaPago")]
        [Bindable(true)]
        public bool? AlertaPago 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("AlertaPago");
		    }
            set 
		    {
			    SetColumnValue("AlertaPago", value);
            }
        }
	      
        [XmlAttribute("FechaModificacion")]
        [Bindable(true)]
        public DateTime FechaModificacion 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("FechaModificacion");
		    }
            set 
		    {
			    SetColumnValue("FechaModificacion", value);
            }
        }
	      
        [XmlAttribute("Rowguid")]
        [Bindable(true)]
        public Guid Rowguid 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("rowguid");
		    }
            set 
		    {
			    SetColumnValue("rowguid", value);
            }
        }
	      
        [XmlAttribute("CheckValidated")]
        [Bindable(true)]
        public bool CheckValidated 
	    {
		    get
		    {
			    return GetColumnValue<bool>("CheckValidated");
		    }
            set 
		    {
			    SetColumnValue("CheckValidated", value);
            }
        }
	      
        [XmlAttribute("Deleted")]
        [Bindable(true)]
        public bool Deleted 
	    {
		    get
		    {
			    return GetColumnValue<bool>("Deleted");
		    }
            set 
		    {
			    SetColumnValue("Deleted", value);
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
	      
        [XmlAttribute("Registrable")]
        [Bindable(true)]
        public bool? Registrable 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("Registrable");
		    }
            set 
		    {
			    SetColumnValue("Registrable", value);
            }
        }
	      
        [XmlAttribute("CostoOriginal")]
        [Bindable(true)]
        public decimal? CostoOriginal 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CostoOriginal");
		    }
            set 
		    {
			    SetColumnValue("CostoOriginal", value);
            }
        }
	      
        [XmlAttribute("CostoCopia")]
        [Bindable(true)]
        public decimal? CostoCopia 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CostoCopia");
		    }
            set 
		    {
			    SetColumnValue("CostoCopia", value);
            }
        }
	      
        [XmlAttribute("CostoTotalOriginales")]
        [Bindable(true)]
        public decimal? CostoTotalOriginales 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CostoTotalOriginales");
		    }
            set 
		    {
			    SetColumnValue("CostoTotalOriginales", value);
            }
        }
	      
        [XmlAttribute("CostoTotalCopias")]
        [Bindable(true)]
        public decimal? CostoTotalCopias 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CostoTotalCopias");
		    }
            set 
		    {
			    SetColumnValue("CostoTotalCopias", value);
            }
        }
	      
        [XmlAttribute("NoDocumento")]
        [Bindable(true)]
        public int? NoDocumento 
	    {
		    get
		    {
			    return GetColumnValue<int?>("NoDocumento");
		    }
            set 
		    {
			    SetColumnValue("NoDocumento", value);
            }
        }
	      
        [XmlAttribute("NumeroPaginas")]
        [Bindable(true)]
        public int? NumeroPaginas 
	    {
		    get
		    {
			    return GetColumnValue<int?>("NumeroPaginas");
		    }
            set 
		    {
			    SetColumnValue("NumeroPaginas", value);
            }
        }
	      
        [XmlAttribute("Digitalizado")]
        [Bindable(true)]
        public bool? Digitalizado 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("Digitalizado");
		    }
            set 
		    {
			    SetColumnValue("Digitalizado", value);
            }
        }
	      
        [XmlAttribute("FechaDigitalizacion")]
        [Bindable(true)]
        public DateTime? FechaDigitalizacion 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("FechaDigitalizacion");
		    }
            set 
		    {
			    SetColumnValue("FechaDigitalizacion", value);
            }
        }
	      
        [XmlAttribute("Analizado")]
        [Bindable(true)]
        public bool? Analizado 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("Analizado");
		    }
            set 
		    {
			    SetColumnValue("Analizado", value);
            }
        }
	      
        [XmlAttribute("Sufijo")]
        [Bindable(true)]
        public string Sufijo 
	    {
		    get
		    {
			    return GetColumnValue<string>("Sufijo");
		    }
            set 
		    {
			    SetColumnValue("Sufijo", value);
            }
        }
	      
        [XmlAttribute("TransSufijo")]
        [Bindable(true)]
        public string TransSufijo 
	    {
		    get
		    {
			    return GetColumnValue<string>("TransSufijo");
		    }
            set 
		    {
			    SetColumnValue("TransSufijo", value);
            }
        }
	      
        [XmlAttribute("TipoTransaccion")]
        [Bindable(true)]
        public string TipoTransaccion 
	    {
		    get
		    {
			    return GetColumnValue<string>("TipoTransaccion");
		    }
            set 
		    {
			    SetColumnValue("TipoTransaccion", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string DocumentoTransaccionId = @"DocumentoTransaccionId";
            
            public static string TransaccionId = @"TransaccionId";
            
            public static string SubTransaccionId = @"SubTransaccionId";
            
            public static string DocumentoId = @"DocumentoId";
            
            public static string FechaDocumento = @"FechaDocumento";
            
            public static string NoOriginales = @"NoOriginales";
            
            public static string NoCopias = @"NoCopias";
            
            public static string Libro = @"Libro";
            
            public static string Folio = @"Folio";
            
            public static string Comentario = @"Comentario";
            
            public static string AlertaPago = @"AlertaPago";
            
            public static string FechaModificacion = @"FechaModificacion";
            
            public static string Rowguid = @"rowguid";
            
            public static string CheckValidated = @"CheckValidated";
            
            public static string Deleted = @"Deleted";
            
            public static string Documento = @"Documento";
            
            public static string Registrable = @"Registrable";
            
            public static string CostoOriginal = @"CostoOriginal";
            
            public static string CostoCopia = @"CostoCopia";
            
            public static string CostoTotalOriginales = @"CostoTotalOriginales";
            
            public static string CostoTotalCopias = @"CostoTotalCopias";
            
            public static string NoDocumento = @"NoDocumento";
            
            public static string NumeroPaginas = @"NumeroPaginas";
            
            public static string Digitalizado = @"Digitalizado";
            
            public static string FechaDigitalizacion = @"FechaDigitalizacion";
            
            public static string Analizado = @"Analizado";
            
            public static string Sufijo = @"Sufijo";
            
            public static string TransSufijo = @"TransSufijo";
            
            public static string TipoTransaccion = @"TipoTransaccion";
            
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
