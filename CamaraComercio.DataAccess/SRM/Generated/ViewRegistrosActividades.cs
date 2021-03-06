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
    /// Strongly-typed collection for the ViewRegistrosActividades class.
    /// </summary>
    [Serializable]
    public partial class ViewRegistrosActividadesCollection : ReadOnlyList<ViewRegistrosActividades, ViewRegistrosActividadesCollection>
    {        
        public ViewRegistrosActividadesCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_RegistrosActividades view.
    /// </summary>
    [Serializable]
    public partial class ViewRegistrosActividades : ReadOnlyRecord<ViewRegistrosActividades>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("cvw_RegistrosActividades", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Sistema";
                //columns
                
                TableSchema.TableColumn colvarAtividadId = new TableSchema.TableColumn(schema);
                colvarAtividadId.ColumnName = "AtividadId";
                colvarAtividadId.DataType = DbType.Int32;
                colvarAtividadId.MaxLength = 0;
                colvarAtividadId.AutoIncrement = false;
                colvarAtividadId.IsNullable = false;
                colvarAtividadId.IsPrimaryKey = false;
                colvarAtividadId.IsForeignKey = false;
                colvarAtividadId.IsReadOnly = false;
                
                schema.Columns.Add(colvarAtividadId);
                
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
                
                TableSchema.TableColumn colvarTipoActividadId = new TableSchema.TableColumn(schema);
                colvarTipoActividadId.ColumnName = "TipoActividadId";
                colvarTipoActividadId.DataType = DbType.Int32;
                colvarTipoActividadId.MaxLength = 0;
                colvarTipoActividadId.AutoIncrement = false;
                colvarTipoActividadId.IsNullable = false;
                colvarTipoActividadId.IsPrimaryKey = false;
                colvarTipoActividadId.IsForeignKey = false;
                colvarTipoActividadId.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoActividadId);
                
                TableSchema.TableColumn colvarActividad = new TableSchema.TableColumn(schema);
                colvarActividad.ColumnName = "Actividad";
                colvarActividad.DataType = DbType.String;
                colvarActividad.MaxLength = 50;
                colvarActividad.AutoIncrement = false;
                colvarActividad.IsNullable = true;
                colvarActividad.IsPrimaryKey = false;
                colvarActividad.IsForeignKey = false;
                colvarActividad.IsReadOnly = false;
                
                schema.Columns.Add(colvarActividad);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_RegistrosActividades",schema);
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
	    public ViewRegistrosActividades()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewRegistrosActividades(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewRegistrosActividades(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewRegistrosActividades(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("AtividadId")]
        [Bindable(true)]
        public int AtividadId 
	    {
		    get
		    {
			    return GetColumnValue<int>("AtividadId");
		    }
            set 
		    {
			    SetColumnValue("AtividadId", value);
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
	      
        [XmlAttribute("TipoActividadId")]
        [Bindable(true)]
        public int TipoActividadId 
	    {
		    get
		    {
			    return GetColumnValue<int>("TipoActividadId");
		    }
            set 
		    {
			    SetColumnValue("TipoActividadId", value);
            }
        }
	      
        [XmlAttribute("Actividad")]
        [Bindable(true)]
        public string Actividad 
	    {
		    get
		    {
			    return GetColumnValue<string>("Actividad");
		    }
            set 
		    {
			    SetColumnValue("Actividad", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string AtividadId = @"AtividadId";
            
            public static string RegistroId = @"RegistroId";
            
            public static string TipoActividadId = @"TipoActividadId";
            
            public static string Actividad = @"Actividad";
            
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
