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
    /// Strongly-typed collection for the ViewMovimientosTransaccionesByReceptor class.
    /// </summary>
    [Serializable]
    public partial class ViewMovimientosTransaccionesByReceptorCollection : ReadOnlyList<ViewMovimientosTransaccionesByReceptor, ViewMovimientosTransaccionesByReceptorCollection>
    {        
        public ViewMovimientosTransaccionesByReceptorCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_MovimientosTransaccionesByReceptor view.
    /// </summary>
    [Serializable]
    public partial class ViewMovimientosTransaccionesByReceptor : ReadOnlyRecord<ViewMovimientosTransaccionesByReceptor>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("cvw_MovimientosTransaccionesByReceptor", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Transaccion";
                //columns
                
                TableSchema.TableColumn colvarSeguimientoId = new TableSchema.TableColumn(schema);
                colvarSeguimientoId.ColumnName = "SeguimientoId";
                colvarSeguimientoId.DataType = DbType.Int32;
                colvarSeguimientoId.MaxLength = 0;
                colvarSeguimientoId.AutoIncrement = false;
                colvarSeguimientoId.IsNullable = false;
                colvarSeguimientoId.IsPrimaryKey = false;
                colvarSeguimientoId.IsForeignKey = false;
                colvarSeguimientoId.IsReadOnly = false;
                
                schema.Columns.Add(colvarSeguimientoId);
                
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
                
                TableSchema.TableColumn colvarEstadoId = new TableSchema.TableColumn(schema);
                colvarEstadoId.ColumnName = "EstadoId";
                colvarEstadoId.DataType = DbType.Int32;
                colvarEstadoId.MaxLength = 0;
                colvarEstadoId.AutoIncrement = false;
                colvarEstadoId.IsNullable = false;
                colvarEstadoId.IsPrimaryKey = false;
                colvarEstadoId.IsForeignKey = false;
                colvarEstadoId.IsReadOnly = false;
                
                schema.Columns.Add(colvarEstadoId);
                
                TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
                colvarComentario.ColumnName = "Comentario";
                colvarComentario.DataType = DbType.AnsiString;
                colvarComentario.MaxLength = 2147483647;
                colvarComentario.AutoIncrement = false;
                colvarComentario.IsNullable = false;
                colvarComentario.IsPrimaryKey = false;
                colvarComentario.IsForeignKey = false;
                colvarComentario.IsReadOnly = false;
                
                schema.Columns.Add(colvarComentario);
                
                TableSchema.TableColumn colvarUsuarioId = new TableSchema.TableColumn(schema);
                colvarUsuarioId.ColumnName = "UsuarioId";
                colvarUsuarioId.DataType = DbType.Int32;
                colvarUsuarioId.MaxLength = 0;
                colvarUsuarioId.AutoIncrement = false;
                colvarUsuarioId.IsNullable = false;
                colvarUsuarioId.IsPrimaryKey = false;
                colvarUsuarioId.IsForeignKey = false;
                colvarUsuarioId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUsuarioId);
                
                TableSchema.TableColumn colvarFechaMovimiento = new TableSchema.TableColumn(schema);
                colvarFechaMovimiento.ColumnName = "FechaMovimiento";
                colvarFechaMovimiento.DataType = DbType.DateTime;
                colvarFechaMovimiento.MaxLength = 0;
                colvarFechaMovimiento.AutoIncrement = false;
                colvarFechaMovimiento.IsNullable = false;
                colvarFechaMovimiento.IsPrimaryKey = false;
                colvarFechaMovimiento.IsForeignKey = false;
                colvarFechaMovimiento.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaMovimiento);
                
                TableSchema.TableColumn colvarUsuarioAsignadoId = new TableSchema.TableColumn(schema);
                colvarUsuarioAsignadoId.ColumnName = "UsuarioAsignadoId";
                colvarUsuarioAsignadoId.DataType = DbType.Int32;
                colvarUsuarioAsignadoId.MaxLength = 0;
                colvarUsuarioAsignadoId.AutoIncrement = false;
                colvarUsuarioAsignadoId.IsNullable = true;
                colvarUsuarioAsignadoId.IsPrimaryKey = false;
                colvarUsuarioAsignadoId.IsForeignKey = false;
                colvarUsuarioAsignadoId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUsuarioAsignadoId);
                
                TableSchema.TableColumn colvarTipoComentario = new TableSchema.TableColumn(schema);
                colvarTipoComentario.ColumnName = "TipoComentario";
                colvarTipoComentario.DataType = DbType.Int32;
                colvarTipoComentario.MaxLength = 0;
                colvarTipoComentario.AutoIncrement = false;
                colvarTipoComentario.IsNullable = true;
                colvarTipoComentario.IsPrimaryKey = false;
                colvarTipoComentario.IsForeignKey = false;
                colvarTipoComentario.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoComentario);
                
                TableSchema.TableColumn colvarIsDefault = new TableSchema.TableColumn(schema);
                colvarIsDefault.ColumnName = "IsDefault";
                colvarIsDefault.DataType = DbType.Boolean;
                colvarIsDefault.MaxLength = 0;
                colvarIsDefault.AutoIncrement = false;
                colvarIsDefault.IsNullable = true;
                colvarIsDefault.IsPrimaryKey = false;
                colvarIsDefault.IsForeignKey = false;
                colvarIsDefault.IsReadOnly = false;
                
                schema.Columns.Add(colvarIsDefault);
                
                TableSchema.TableColumn colvarTrabajadoPor = new TableSchema.TableColumn(schema);
                colvarTrabajadoPor.ColumnName = "TrabajadoPor";
                colvarTrabajadoPor.DataType = DbType.String;
                colvarTrabajadoPor.MaxLength = 100;
                colvarTrabajadoPor.AutoIncrement = false;
                colvarTrabajadoPor.IsNullable = true;
                colvarTrabajadoPor.IsPrimaryKey = false;
                colvarTrabajadoPor.IsForeignKey = false;
                colvarTrabajadoPor.IsReadOnly = false;
                
                schema.Columns.Add(colvarTrabajadoPor);
                
                TableSchema.TableColumn colvarAsignadoA = new TableSchema.TableColumn(schema);
                colvarAsignadoA.ColumnName = "AsignadoA";
                colvarAsignadoA.DataType = DbType.String;
                colvarAsignadoA.MaxLength = 100;
                colvarAsignadoA.AutoIncrement = false;
                colvarAsignadoA.IsNullable = true;
                colvarAsignadoA.IsPrimaryKey = false;
                colvarAsignadoA.IsForeignKey = false;
                colvarAsignadoA.IsReadOnly = false;
                
                schema.Columns.Add(colvarAsignadoA);
                
                TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
                colvarEstado.ColumnName = "Estado";
                colvarEstado.DataType = DbType.String;
                colvarEstado.MaxLength = 25;
                colvarEstado.AutoIncrement = false;
                colvarEstado.IsNullable = false;
                colvarEstado.IsPrimaryKey = false;
                colvarEstado.IsForeignKey = false;
                colvarEstado.IsReadOnly = false;
                
                schema.Columns.Add(colvarEstado);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_MovimientosTransaccionesByReceptor",schema);
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
	    public ViewMovimientosTransaccionesByReceptor()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewMovimientosTransaccionesByReceptor(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewMovimientosTransaccionesByReceptor(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewMovimientosTransaccionesByReceptor(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SeguimientoId")]
        [Bindable(true)]
        public int SeguimientoId 
	    {
		    get
		    {
			    return GetColumnValue<int>("SeguimientoId");
		    }
            set 
		    {
			    SetColumnValue("SeguimientoId", value);
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
	      
        [XmlAttribute("EstadoId")]
        [Bindable(true)]
        public int EstadoId 
	    {
		    get
		    {
			    return GetColumnValue<int>("EstadoId");
		    }
            set 
		    {
			    SetColumnValue("EstadoId", value);
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
	      
        [XmlAttribute("UsuarioId")]
        [Bindable(true)]
        public int UsuarioId 
	    {
		    get
		    {
			    return GetColumnValue<int>("UsuarioId");
		    }
            set 
		    {
			    SetColumnValue("UsuarioId", value);
            }
        }
	      
        [XmlAttribute("FechaMovimiento")]
        [Bindable(true)]
        public DateTime FechaMovimiento 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("FechaMovimiento");
		    }
            set 
		    {
			    SetColumnValue("FechaMovimiento", value);
            }
        }
	      
        [XmlAttribute("UsuarioAsignadoId")]
        [Bindable(true)]
        public int? UsuarioAsignadoId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("UsuarioAsignadoId");
		    }
            set 
		    {
			    SetColumnValue("UsuarioAsignadoId", value);
            }
        }
	      
        [XmlAttribute("TipoComentario")]
        [Bindable(true)]
        public int? TipoComentario 
	    {
		    get
		    {
			    return GetColumnValue<int?>("TipoComentario");
		    }
            set 
		    {
			    SetColumnValue("TipoComentario", value);
            }
        }
	      
        [XmlAttribute("IsDefault")]
        [Bindable(true)]
        public bool? IsDefault 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("IsDefault");
		    }
            set 
		    {
			    SetColumnValue("IsDefault", value);
            }
        }
	      
        [XmlAttribute("TrabajadoPor")]
        [Bindable(true)]
        public string TrabajadoPor 
	    {
		    get
		    {
			    return GetColumnValue<string>("TrabajadoPor");
		    }
            set 
		    {
			    SetColumnValue("TrabajadoPor", value);
            }
        }
	      
        [XmlAttribute("AsignadoA")]
        [Bindable(true)]
        public string AsignadoA 
	    {
		    get
		    {
			    return GetColumnValue<string>("AsignadoA");
		    }
            set 
		    {
			    SetColumnValue("AsignadoA", value);
            }
        }
	      
        [XmlAttribute("Estado")]
        [Bindable(true)]
        public string Estado 
	    {
		    get
		    {
			    return GetColumnValue<string>("Estado");
		    }
            set 
		    {
			    SetColumnValue("Estado", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SeguimientoId = @"SeguimientoId";
            
            public static string TransaccionId = @"TransaccionId";
            
            public static string EstadoId = @"EstadoId";
            
            public static string Comentario = @"Comentario";
            
            public static string UsuarioId = @"UsuarioId";
            
            public static string FechaMovimiento = @"FechaMovimiento";
            
            public static string UsuarioAsignadoId = @"UsuarioAsignadoId";
            
            public static string TipoComentario = @"TipoComentario";
            
            public static string IsDefault = @"IsDefault";
            
            public static string TrabajadoPor = @"TrabajadoPor";
            
            public static string AsignadoA = @"AsignadoA";
            
            public static string Estado = @"Estado";
            
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
