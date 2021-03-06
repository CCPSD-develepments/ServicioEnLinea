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
    /// Strongly-typed collection for the ViewHistoricoTransaccionesPersonasFisicas class.
    /// </summary>
    [Serializable]
    public partial class ViewHistoricoTransaccionesPersonasFisicasCollection : ReadOnlyList<ViewHistoricoTransaccionesPersonasFisicas, ViewHistoricoTransaccionesPersonasFisicasCollection>
    {        
        public ViewHistoricoTransaccionesPersonasFisicasCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_HistoricoTransaccionesPersonasFisicas view.
    /// </summary>
    [Serializable]
    public partial class ViewHistoricoTransaccionesPersonasFisicas : ReadOnlyRecord<ViewHistoricoTransaccionesPersonasFisicas>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("cvw_HistoricoTransaccionesPersonasFisicas", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Historico";
                //columns
                
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
                
                TableSchema.TableColumn colvarPersonaId = new TableSchema.TableColumn(schema);
                colvarPersonaId.ColumnName = "PersonaId";
                colvarPersonaId.DataType = DbType.Int32;
                colvarPersonaId.MaxLength = 0;
                colvarPersonaId.AutoIncrement = false;
                colvarPersonaId.IsNullable = false;
                colvarPersonaId.IsPrimaryKey = false;
                colvarPersonaId.IsForeignKey = false;
                colvarPersonaId.IsReadOnly = false;
                
                schema.Columns.Add(colvarPersonaId);
                
                TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
                colvarFecha.ColumnName = "Fecha";
                colvarFecha.DataType = DbType.DateTime;
                colvarFecha.MaxLength = 0;
                colvarFecha.AutoIncrement = false;
                colvarFecha.IsNullable = false;
                colvarFecha.IsPrimaryKey = false;
                colvarFecha.IsForeignKey = false;
                colvarFecha.IsReadOnly = false;
                
                schema.Columns.Add(colvarFecha);
                
                TableSchema.TableColumn colvarTipoTransaccionId = new TableSchema.TableColumn(schema);
                colvarTipoTransaccionId.ColumnName = "TipoTransaccionId";
                colvarTipoTransaccionId.DataType = DbType.Int32;
                colvarTipoTransaccionId.MaxLength = 0;
                colvarTipoTransaccionId.AutoIncrement = false;
                colvarTipoTransaccionId.IsNullable = false;
                colvarTipoTransaccionId.IsPrimaryKey = false;
                colvarTipoTransaccionId.IsForeignKey = false;
                colvarTipoTransaccionId.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoTransaccionId);
                
                TableSchema.TableColumn colvarTipoServicioId = new TableSchema.TableColumn(schema);
                colvarTipoServicioId.ColumnName = "TipoServicioId";
                colvarTipoServicioId.DataType = DbType.Int32;
                colvarTipoServicioId.MaxLength = 0;
                colvarTipoServicioId.AutoIncrement = false;
                colvarTipoServicioId.IsNullable = false;
                colvarTipoServicioId.IsPrimaryKey = false;
                colvarTipoServicioId.IsForeignKey = false;
                colvarTipoServicioId.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoServicioId);
                
                TableSchema.TableColumn colvarSalicitante = new TableSchema.TableColumn(schema);
                colvarSalicitante.ColumnName = "Salicitante";
                colvarSalicitante.DataType = DbType.AnsiString;
                colvarSalicitante.MaxLength = 255;
                colvarSalicitante.AutoIncrement = false;
                colvarSalicitante.IsNullable = true;
                colvarSalicitante.IsPrimaryKey = false;
                colvarSalicitante.IsForeignKey = false;
                colvarSalicitante.IsReadOnly = false;
                
                schema.Columns.Add(colvarSalicitante);
                
                TableSchema.TableColumn colvarRNCSolicitante = new TableSchema.TableColumn(schema);
                colvarRNCSolicitante.ColumnName = "RNCSolicitante";
                colvarRNCSolicitante.DataType = DbType.AnsiString;
                colvarRNCSolicitante.MaxLength = 15;
                colvarRNCSolicitante.AutoIncrement = false;
                colvarRNCSolicitante.IsNullable = true;
                colvarRNCSolicitante.IsPrimaryKey = false;
                colvarRNCSolicitante.IsForeignKey = false;
                colvarRNCSolicitante.IsReadOnly = false;
                
                schema.Columns.Add(colvarRNCSolicitante);
                
                TableSchema.TableColumn colvarNombreContacto = new TableSchema.TableColumn(schema);
                colvarNombreContacto.ColumnName = "NombreContacto";
                colvarNombreContacto.DataType = DbType.AnsiString;
                colvarNombreContacto.MaxLength = 255;
                colvarNombreContacto.AutoIncrement = false;
                colvarNombreContacto.IsNullable = true;
                colvarNombreContacto.IsPrimaryKey = false;
                colvarNombreContacto.IsForeignKey = false;
                colvarNombreContacto.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreContacto);
                
                TableSchema.TableColumn colvarTelefonoContacto = new TableSchema.TableColumn(schema);
                colvarTelefonoContacto.ColumnName = "TelefonoContacto";
                colvarTelefonoContacto.DataType = DbType.AnsiString;
                colvarTelefonoContacto.MaxLength = 15;
                colvarTelefonoContacto.AutoIncrement = false;
                colvarTelefonoContacto.IsNullable = true;
                colvarTelefonoContacto.IsPrimaryKey = false;
                colvarTelefonoContacto.IsForeignKey = false;
                colvarTelefonoContacto.IsReadOnly = false;
                
                schema.Columns.Add(colvarTelefonoContacto);
                
                TableSchema.TableColumn colvarFaxContacto = new TableSchema.TableColumn(schema);
                colvarFaxContacto.ColumnName = "FaxContacto";
                colvarFaxContacto.DataType = DbType.AnsiString;
                colvarFaxContacto.MaxLength = 15;
                colvarFaxContacto.AutoIncrement = false;
                colvarFaxContacto.IsNullable = true;
                colvarFaxContacto.IsPrimaryKey = false;
                colvarFaxContacto.IsForeignKey = false;
                colvarFaxContacto.IsReadOnly = false;
                
                schema.Columns.Add(colvarFaxContacto);
                
                TableSchema.TableColumn colvarNoReciboDGII = new TableSchema.TableColumn(schema);
                colvarNoReciboDGII.ColumnName = "NoReciboDGII";
                colvarNoReciboDGII.DataType = DbType.AnsiString;
                colvarNoReciboDGII.MaxLength = 15;
                colvarNoReciboDGII.AutoIncrement = false;
                colvarNoReciboDGII.IsNullable = true;
                colvarNoReciboDGII.IsPrimaryKey = false;
                colvarNoReciboDGII.IsForeignKey = false;
                colvarNoReciboDGII.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoReciboDGII);
                
                TableSchema.TableColumn colvarFechaReciboDGII = new TableSchema.TableColumn(schema);
                colvarFechaReciboDGII.ColumnName = "FechaReciboDGII";
                colvarFechaReciboDGII.DataType = DbType.DateTime;
                colvarFechaReciboDGII.MaxLength = 0;
                colvarFechaReciboDGII.AutoIncrement = false;
                colvarFechaReciboDGII.IsNullable = true;
                colvarFechaReciboDGII.IsPrimaryKey = false;
                colvarFechaReciboDGII.IsForeignKey = false;
                colvarFechaReciboDGII.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaReciboDGII);
                
                TableSchema.TableColumn colvarMontoDGII = new TableSchema.TableColumn(schema);
                colvarMontoDGII.ColumnName = "MontoDGII";
                colvarMontoDGII.DataType = DbType.Currency;
                colvarMontoDGII.MaxLength = 0;
                colvarMontoDGII.AutoIncrement = false;
                colvarMontoDGII.IsNullable = true;
                colvarMontoDGII.IsPrimaryKey = false;
                colvarMontoDGII.IsForeignKey = false;
                colvarMontoDGII.IsReadOnly = false;
                
                schema.Columns.Add(colvarMontoDGII);
                
                TableSchema.TableColumn colvarDestinoTraslado = new TableSchema.TableColumn(schema);
                colvarDestinoTraslado.ColumnName = "DestinoTraslado";
                colvarDestinoTraslado.DataType = DbType.AnsiString;
                colvarDestinoTraslado.MaxLength = 150;
                colvarDestinoTraslado.AutoIncrement = false;
                colvarDestinoTraslado.IsNullable = true;
                colvarDestinoTraslado.IsPrimaryKey = false;
                colvarDestinoTraslado.IsForeignKey = false;
                colvarDestinoTraslado.IsReadOnly = false;
                
                schema.Columns.Add(colvarDestinoTraslado);
                
                TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
                colvarComentario.ColumnName = "Comentario";
                colvarComentario.DataType = DbType.String;
                colvarComentario.MaxLength = -1;
                colvarComentario.AutoIncrement = false;
                colvarComentario.IsNullable = true;
                colvarComentario.IsPrimaryKey = false;
                colvarComentario.IsForeignKey = false;
                colvarComentario.IsReadOnly = false;
                
                schema.Columns.Add(colvarComentario);
                
                TableSchema.TableColumn colvarComentarioHtml = new TableSchema.TableColumn(schema);
                colvarComentarioHtml.ColumnName = "ComentarioHtml";
                colvarComentarioHtml.DataType = DbType.String;
                colvarComentarioHtml.MaxLength = -1;
                colvarComentarioHtml.AutoIncrement = false;
                colvarComentarioHtml.IsNullable = true;
                colvarComentarioHtml.IsPrimaryKey = false;
                colvarComentarioHtml.IsForeignKey = false;
                colvarComentarioHtml.IsReadOnly = false;
                
                schema.Columns.Add(colvarComentarioHtml);
                
                TableSchema.TableColumn colvarFlowId = new TableSchema.TableColumn(schema);
                colvarFlowId.ColumnName = "FlowId";
                colvarFlowId.DataType = DbType.Guid;
                colvarFlowId.MaxLength = 0;
                colvarFlowId.AutoIncrement = false;
                colvarFlowId.IsNullable = true;
                colvarFlowId.IsPrimaryKey = false;
                colvarFlowId.IsForeignKey = false;
                colvarFlowId.IsReadOnly = false;
                
                schema.Columns.Add(colvarFlowId);
                
                TableSchema.TableColumn colvarEstatus = new TableSchema.TableColumn(schema);
                colvarEstatus.ColumnName = "Estatus";
                colvarEstatus.DataType = DbType.Int32;
                colvarEstatus.MaxLength = 0;
                colvarEstatus.AutoIncrement = false;
                colvarEstatus.IsNullable = false;
                colvarEstatus.IsPrimaryKey = false;
                colvarEstatus.IsForeignKey = false;
                colvarEstatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarEstatus);
                
                TableSchema.TableColumn colvarEstatus2 = new TableSchema.TableColumn(schema);
                colvarEstatus2.ColumnName = "Estatus2";
                colvarEstatus2.DataType = DbType.Int32;
                colvarEstatus2.MaxLength = 0;
                colvarEstatus2.AutoIncrement = false;
                colvarEstatus2.IsNullable = true;
                colvarEstatus2.IsPrimaryKey = false;
                colvarEstatus2.IsForeignKey = false;
                colvarEstatus2.IsReadOnly = false;
                
                schema.Columns.Add(colvarEstatus2);
                
                TableSchema.TableColumn colvarPrioridad = new TableSchema.TableColumn(schema);
                colvarPrioridad.ColumnName = "Prioridad";
                colvarPrioridad.DataType = DbType.String;
                colvarPrioridad.MaxLength = 1;
                colvarPrioridad.AutoIncrement = false;
                colvarPrioridad.IsNullable = true;
                colvarPrioridad.IsPrimaryKey = false;
                colvarPrioridad.IsForeignKey = false;
                colvarPrioridad.IsReadOnly = false;
                
                schema.Columns.Add(colvarPrioridad);
                
                TableSchema.TableColumn colvarNombreSociedad = new TableSchema.TableColumn(schema);
                colvarNombreSociedad.ColumnName = "NombreSociedad";
                colvarNombreSociedad.DataType = DbType.String;
                colvarNombreSociedad.MaxLength = 501;
                colvarNombreSociedad.AutoIncrement = false;
                colvarNombreSociedad.IsNullable = true;
                colvarNombreSociedad.IsPrimaryKey = false;
                colvarNombreSociedad.IsForeignKey = false;
                colvarNombreSociedad.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreSociedad);
                
                TableSchema.TableColumn colvarCustomString3 = new TableSchema.TableColumn(schema);
                colvarCustomString3.ColumnName = "CustomString3";
                colvarCustomString3.DataType = DbType.String;
                colvarCustomString3.MaxLength = 250;
                colvarCustomString3.AutoIncrement = false;
                colvarCustomString3.IsNullable = true;
                colvarCustomString3.IsPrimaryKey = false;
                colvarCustomString3.IsForeignKey = false;
                colvarCustomString3.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomString3);
                
                TableSchema.TableColumn colvarCustomInt1 = new TableSchema.TableColumn(schema);
                colvarCustomInt1.ColumnName = "CustomInt1";
                colvarCustomInt1.DataType = DbType.Int32;
                colvarCustomInt1.MaxLength = 0;
                colvarCustomInt1.AutoIncrement = false;
                colvarCustomInt1.IsNullable = true;
                colvarCustomInt1.IsPrimaryKey = false;
                colvarCustomInt1.IsForeignKey = false;
                colvarCustomInt1.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomInt1);
                
                TableSchema.TableColumn colvarCustomInt2 = new TableSchema.TableColumn(schema);
                colvarCustomInt2.ColumnName = "CustomInt2";
                colvarCustomInt2.DataType = DbType.Int32;
                colvarCustomInt2.MaxLength = 0;
                colvarCustomInt2.AutoIncrement = false;
                colvarCustomInt2.IsNullable = true;
                colvarCustomInt2.IsPrimaryKey = false;
                colvarCustomInt2.IsForeignKey = false;
                colvarCustomInt2.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomInt2);
                
                TableSchema.TableColumn colvarCustomInt3 = new TableSchema.TableColumn(schema);
                colvarCustomInt3.ColumnName = "CustomInt3";
                colvarCustomInt3.DataType = DbType.Int32;
                colvarCustomInt3.MaxLength = 0;
                colvarCustomInt3.AutoIncrement = false;
                colvarCustomInt3.IsNullable = true;
                colvarCustomInt3.IsPrimaryKey = false;
                colvarCustomInt3.IsForeignKey = false;
                colvarCustomInt3.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomInt3);
                
                TableSchema.TableColumn colvarCustomDateTime1 = new TableSchema.TableColumn(schema);
                colvarCustomDateTime1.ColumnName = "CustomDateTime1";
                colvarCustomDateTime1.DataType = DbType.DateTime;
                colvarCustomDateTime1.MaxLength = 0;
                colvarCustomDateTime1.AutoIncrement = false;
                colvarCustomDateTime1.IsNullable = true;
                colvarCustomDateTime1.IsPrimaryKey = false;
                colvarCustomDateTime1.IsForeignKey = false;
                colvarCustomDateTime1.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomDateTime1);
                
                TableSchema.TableColumn colvarCustomDateTime2 = new TableSchema.TableColumn(schema);
                colvarCustomDateTime2.ColumnName = "CustomDateTime2";
                colvarCustomDateTime2.DataType = DbType.DateTime;
                colvarCustomDateTime2.MaxLength = 0;
                colvarCustomDateTime2.AutoIncrement = false;
                colvarCustomDateTime2.IsNullable = true;
                colvarCustomDateTime2.IsPrimaryKey = false;
                colvarCustomDateTime2.IsForeignKey = false;
                colvarCustomDateTime2.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomDateTime2);
                
                TableSchema.TableColumn colvarCustomDecimal1 = new TableSchema.TableColumn(schema);
                colvarCustomDecimal1.ColumnName = "CustomDecimal1";
                colvarCustomDecimal1.DataType = DbType.Decimal;
                colvarCustomDecimal1.MaxLength = 0;
                colvarCustomDecimal1.AutoIncrement = false;
                colvarCustomDecimal1.IsNullable = true;
                colvarCustomDecimal1.IsPrimaryKey = false;
                colvarCustomDecimal1.IsForeignKey = false;
                colvarCustomDecimal1.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomDecimal1);
                
                TableSchema.TableColumn colvarCustomDecimal2 = new TableSchema.TableColumn(schema);
                colvarCustomDecimal2.ColumnName = "CustomDecimal2";
                colvarCustomDecimal2.DataType = DbType.Decimal;
                colvarCustomDecimal2.MaxLength = 0;
                colvarCustomDecimal2.AutoIncrement = false;
                colvarCustomDecimal2.IsNullable = true;
                colvarCustomDecimal2.IsPrimaryKey = false;
                colvarCustomDecimal2.IsForeignKey = false;
                colvarCustomDecimal2.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomDecimal2);
                
                TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
                colvarTipo.ColumnName = "Tipo";
                colvarTipo.DataType = DbType.Int32;
                colvarTipo.MaxLength = 0;
                colvarTipo.AutoIncrement = false;
                colvarTipo.IsNullable = true;
                colvarTipo.IsPrimaryKey = false;
                colvarTipo.IsForeignKey = false;
                colvarTipo.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipo);
                
                TableSchema.TableColumn colvarNcf = new TableSchema.TableColumn(schema);
                colvarNcf.ColumnName = "NCF";
                colvarNcf.DataType = DbType.AnsiString;
                colvarNcf.MaxLength = 20;
                colvarNcf.AutoIncrement = false;
                colvarNcf.IsNullable = true;
                colvarNcf.IsPrimaryKey = false;
                colvarNcf.IsForeignKey = false;
                colvarNcf.IsReadOnly = false;
                
                schema.Columns.Add(colvarNcf);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_HistoricoTransaccionesPersonasFisicas",schema);
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
	    public ViewHistoricoTransaccionesPersonasFisicas()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewHistoricoTransaccionesPersonasFisicas(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewHistoricoTransaccionesPersonasFisicas(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewHistoricoTransaccionesPersonasFisicas(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
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
	      
        [XmlAttribute("PersonaId")]
        [Bindable(true)]
        public int PersonaId 
	    {
		    get
		    {
			    return GetColumnValue<int>("PersonaId");
		    }
            set 
		    {
			    SetColumnValue("PersonaId", value);
            }
        }
	      
        [XmlAttribute("Fecha")]
        [Bindable(true)]
        public DateTime Fecha 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("Fecha");
		    }
            set 
		    {
			    SetColumnValue("Fecha", value);
            }
        }
	      
        [XmlAttribute("TipoTransaccionId")]
        [Bindable(true)]
        public int TipoTransaccionId 
	    {
		    get
		    {
			    return GetColumnValue<int>("TipoTransaccionId");
		    }
            set 
		    {
			    SetColumnValue("TipoTransaccionId", value);
            }
        }
	      
        [XmlAttribute("TipoServicioId")]
        [Bindable(true)]
        public int TipoServicioId 
	    {
		    get
		    {
			    return GetColumnValue<int>("TipoServicioId");
		    }
            set 
		    {
			    SetColumnValue("TipoServicioId", value);
            }
        }
	      
        [XmlAttribute("Salicitante")]
        [Bindable(true)]
        public string Salicitante 
	    {
		    get
		    {
			    return GetColumnValue<string>("Salicitante");
		    }
            set 
		    {
			    SetColumnValue("Salicitante", value);
            }
        }
	      
        [XmlAttribute("RNCSolicitante")]
        [Bindable(true)]
        public string RNCSolicitante 
	    {
		    get
		    {
			    return GetColumnValue<string>("RNCSolicitante");
		    }
            set 
		    {
			    SetColumnValue("RNCSolicitante", value);
            }
        }
	      
        [XmlAttribute("NombreContacto")]
        [Bindable(true)]
        public string NombreContacto 
	    {
		    get
		    {
			    return GetColumnValue<string>("NombreContacto");
		    }
            set 
		    {
			    SetColumnValue("NombreContacto", value);
            }
        }
	      
        [XmlAttribute("TelefonoContacto")]
        [Bindable(true)]
        public string TelefonoContacto 
	    {
		    get
		    {
			    return GetColumnValue<string>("TelefonoContacto");
		    }
            set 
		    {
			    SetColumnValue("TelefonoContacto", value);
            }
        }
	      
        [XmlAttribute("FaxContacto")]
        [Bindable(true)]
        public string FaxContacto 
	    {
		    get
		    {
			    return GetColumnValue<string>("FaxContacto");
		    }
            set 
		    {
			    SetColumnValue("FaxContacto", value);
            }
        }
	      
        [XmlAttribute("NoReciboDGII")]
        [Bindable(true)]
        public string NoReciboDGII 
	    {
		    get
		    {
			    return GetColumnValue<string>("NoReciboDGII");
		    }
            set 
		    {
			    SetColumnValue("NoReciboDGII", value);
            }
        }
	      
        [XmlAttribute("FechaReciboDGII")]
        [Bindable(true)]
        public DateTime? FechaReciboDGII 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("FechaReciboDGII");
		    }
            set 
		    {
			    SetColumnValue("FechaReciboDGII", value);
            }
        }
	      
        [XmlAttribute("MontoDGII")]
        [Bindable(true)]
        public decimal? MontoDGII 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("MontoDGII");
		    }
            set 
		    {
			    SetColumnValue("MontoDGII", value);
            }
        }
	      
        [XmlAttribute("DestinoTraslado")]
        [Bindable(true)]
        public string DestinoTraslado 
	    {
		    get
		    {
			    return GetColumnValue<string>("DestinoTraslado");
		    }
            set 
		    {
			    SetColumnValue("DestinoTraslado", value);
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
	      
        [XmlAttribute("ComentarioHtml")]
        [Bindable(true)]
        public string ComentarioHtml 
	    {
		    get
		    {
			    return GetColumnValue<string>("ComentarioHtml");
		    }
            set 
		    {
			    SetColumnValue("ComentarioHtml", value);
            }
        }
	      
        [XmlAttribute("FlowId")]
        [Bindable(true)]
        public Guid? FlowId 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("FlowId");
		    }
            set 
		    {
			    SetColumnValue("FlowId", value);
            }
        }
	      
        [XmlAttribute("Estatus")]
        [Bindable(true)]
        public int Estatus 
	    {
		    get
		    {
			    return GetColumnValue<int>("Estatus");
		    }
            set 
		    {
			    SetColumnValue("Estatus", value);
            }
        }
	      
        [XmlAttribute("Estatus2")]
        [Bindable(true)]
        public int? Estatus2 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Estatus2");
		    }
            set 
		    {
			    SetColumnValue("Estatus2", value);
            }
        }
	      
        [XmlAttribute("Prioridad")]
        [Bindable(true)]
        public string Prioridad 
	    {
		    get
		    {
			    return GetColumnValue<string>("Prioridad");
		    }
            set 
		    {
			    SetColumnValue("Prioridad", value);
            }
        }
	      
        [XmlAttribute("NombreSociedad")]
        [Bindable(true)]
        public string NombreSociedad 
	    {
		    get
		    {
			    return GetColumnValue<string>("NombreSociedad");
		    }
            set 
		    {
			    SetColumnValue("NombreSociedad", value);
            }
        }
	      
        [XmlAttribute("CustomString3")]
        [Bindable(true)]
        public string CustomString3 
	    {
		    get
		    {
			    return GetColumnValue<string>("CustomString3");
		    }
            set 
		    {
			    SetColumnValue("CustomString3", value);
            }
        }
	      
        [XmlAttribute("CustomInt1")]
        [Bindable(true)]
        public int? CustomInt1 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CustomInt1");
		    }
            set 
		    {
			    SetColumnValue("CustomInt1", value);
            }
        }
	      
        [XmlAttribute("CustomInt2")]
        [Bindable(true)]
        public int? CustomInt2 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CustomInt2");
		    }
            set 
		    {
			    SetColumnValue("CustomInt2", value);
            }
        }
	      
        [XmlAttribute("CustomInt3")]
        [Bindable(true)]
        public int? CustomInt3 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CustomInt3");
		    }
            set 
		    {
			    SetColumnValue("CustomInt3", value);
            }
        }
	      
        [XmlAttribute("CustomDateTime1")]
        [Bindable(true)]
        public DateTime? CustomDateTime1 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("CustomDateTime1");
		    }
            set 
		    {
			    SetColumnValue("CustomDateTime1", value);
            }
        }
	      
        [XmlAttribute("CustomDateTime2")]
        [Bindable(true)]
        public DateTime? CustomDateTime2 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("CustomDateTime2");
		    }
            set 
		    {
			    SetColumnValue("CustomDateTime2", value);
            }
        }
	      
        [XmlAttribute("CustomDecimal1")]
        [Bindable(true)]
        public decimal? CustomDecimal1 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CustomDecimal1");
		    }
            set 
		    {
			    SetColumnValue("CustomDecimal1", value);
            }
        }
	      
        [XmlAttribute("CustomDecimal2")]
        [Bindable(true)]
        public decimal? CustomDecimal2 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CustomDecimal2");
		    }
            set 
		    {
			    SetColumnValue("CustomDecimal2", value);
            }
        }
	      
        [XmlAttribute("Tipo")]
        [Bindable(true)]
        public int? Tipo 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Tipo");
		    }
            set 
		    {
			    SetColumnValue("Tipo", value);
            }
        }
	      
        [XmlAttribute("Ncf")]
        [Bindable(true)]
        public string Ncf 
	    {
		    get
		    {
			    return GetColumnValue<string>("NCF");
		    }
            set 
		    {
			    SetColumnValue("NCF", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string TransaccionId = @"TransaccionId";
            
            public static string PersonaId = @"PersonaId";
            
            public static string Fecha = @"Fecha";
            
            public static string TipoTransaccionId = @"TipoTransaccionId";
            
            public static string TipoServicioId = @"TipoServicioId";
            
            public static string Salicitante = @"Salicitante";
            
            public static string RNCSolicitante = @"RNCSolicitante";
            
            public static string NombreContacto = @"NombreContacto";
            
            public static string TelefonoContacto = @"TelefonoContacto";
            
            public static string FaxContacto = @"FaxContacto";
            
            public static string NoReciboDGII = @"NoReciboDGII";
            
            public static string FechaReciboDGII = @"FechaReciboDGII";
            
            public static string MontoDGII = @"MontoDGII";
            
            public static string DestinoTraslado = @"DestinoTraslado";
            
            public static string Comentario = @"Comentario";
            
            public static string ComentarioHtml = @"ComentarioHtml";
            
            public static string FlowId = @"FlowId";
            
            public static string Estatus = @"Estatus";
            
            public static string Estatus2 = @"Estatus2";
            
            public static string Prioridad = @"Prioridad";
            
            public static string NombreSociedad = @"NombreSociedad";
            
            public static string CustomString3 = @"CustomString3";
            
            public static string CustomInt1 = @"CustomInt1";
            
            public static string CustomInt2 = @"CustomInt2";
            
            public static string CustomInt3 = @"CustomInt3";
            
            public static string CustomDateTime1 = @"CustomDateTime1";
            
            public static string CustomDateTime2 = @"CustomDateTime2";
            
            public static string CustomDecimal1 = @"CustomDecimal1";
            
            public static string CustomDecimal2 = @"CustomDecimal2";
            
            public static string Tipo = @"Tipo";
            
            public static string Ncf = @"NCF";
            
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
