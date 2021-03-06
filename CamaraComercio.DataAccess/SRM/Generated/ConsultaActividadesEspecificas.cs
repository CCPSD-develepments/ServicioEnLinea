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
    /// Strongly-typed collection for the ConsultaActividadesEspecificas class.
    /// </summary>
    [Serializable]
    public partial class ConsultaActividadesEspecificasCollection : ReadOnlyList<ConsultaActividadesEspecificas, ConsultaActividadesEspecificasCollection>
    {        
        public ConsultaActividadesEspecificasCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the ConsultaActividadesEspecificas view.
    /// </summary>
    [Serializable]
    public partial class ConsultaActividadesEspecificas : ReadOnlyRecord<ConsultaActividadesEspecificas>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("ConsultaActividadesEspecificas", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"SRM_INFORMATION_SCHEMA";
                //columns
                
                TableSchema.TableColumn colvarTipoActividadEspecificaId = new TableSchema.TableColumn(schema);
                colvarTipoActividadEspecificaId.ColumnName = "TipoActividadEspecificaId";
                colvarTipoActividadEspecificaId.DataType = DbType.Int32;
                colvarTipoActividadEspecificaId.MaxLength = 0;
                colvarTipoActividadEspecificaId.AutoIncrement = false;
                colvarTipoActividadEspecificaId.IsNullable = false;
                colvarTipoActividadEspecificaId.IsPrimaryKey = false;
                colvarTipoActividadEspecificaId.IsForeignKey = false;
                colvarTipoActividadEspecificaId.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoActividadEspecificaId);
                
                TableSchema.TableColumn colvarActividadEspecifica = new TableSchema.TableColumn(schema);
                colvarActividadEspecifica.ColumnName = "Actividad Especifica";
                colvarActividadEspecifica.DataType = DbType.String;
                colvarActividadEspecifica.MaxLength = 50;
                colvarActividadEspecifica.AutoIncrement = false;
                colvarActividadEspecifica.IsNullable = false;
                colvarActividadEspecifica.IsPrimaryKey = false;
                colvarActividadEspecifica.IsForeignKey = false;
                colvarActividadEspecifica.IsReadOnly = false;
                
                schema.Columns.Add(colvarActividadEspecifica);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("ConsultaActividadesEspecificas",schema);
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
	    public ConsultaActividadesEspecificas()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConsultaActividadesEspecificas(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConsultaActividadesEspecificas(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConsultaActividadesEspecificas(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("TipoActividadEspecificaId")]
        [Bindable(true)]
        public int TipoActividadEspecificaId 
	    {
		    get
		    {
			    return GetColumnValue<int>("TipoActividadEspecificaId");
		    }
            set 
		    {
			    SetColumnValue("TipoActividadEspecificaId", value);
            }
        }
	      
        [XmlAttribute("ActividadEspecifica")]
        [Bindable(true)]
        public string ActividadEspecifica 
	    {
		    get
		    {
			    return GetColumnValue<string>("Actividad Especifica");
		    }
            set 
		    {
			    SetColumnValue("Actividad Especifica", value);
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
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string TipoActividadEspecificaId = @"TipoActividadEspecificaId";
            
            public static string ActividadEspecifica = @"Actividad Especifica";
            
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
