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
    /// Strongly-typed collection for the ConsultasReferenciasComerciales class.
    /// </summary>
    [Serializable]
    public partial class ConsultasReferenciasComercialesCollection : ReadOnlyList<ConsultasReferenciasComerciales, ConsultasReferenciasComercialesCollection>
    {        
        public ConsultasReferenciasComercialesCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the ConsultasReferenciasComerciales view.
    /// </summary>
    [Serializable]
    public partial class ConsultasReferenciasComerciales : ReadOnlyRecord<ConsultasReferenciasComerciales>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("ConsultasReferenciasComerciales", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"SRM_INFORMATION_SCHEMA";
                //columns
                
                TableSchema.TableColumn colvarReferenciaComercialId = new TableSchema.TableColumn(schema);
                colvarReferenciaComercialId.ColumnName = "ReferenciaComercialId";
                colvarReferenciaComercialId.DataType = DbType.Int32;
                colvarReferenciaComercialId.MaxLength = 0;
                colvarReferenciaComercialId.AutoIncrement = false;
                colvarReferenciaComercialId.IsNullable = false;
                colvarReferenciaComercialId.IsPrimaryKey = false;
                colvarReferenciaComercialId.IsForeignKey = false;
                colvarReferenciaComercialId.IsReadOnly = false;
                
                schema.Columns.Add(colvarReferenciaComercialId);
                
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
                
                TableSchema.TableColumn colvarNombreReferencia = new TableSchema.TableColumn(schema);
                colvarNombreReferencia.ColumnName = "Nombre Referencia";
                colvarNombreReferencia.DataType = DbType.String;
                colvarNombreReferencia.MaxLength = 100;
                colvarNombreReferencia.AutoIncrement = false;
                colvarNombreReferencia.IsNullable = false;
                colvarNombreReferencia.IsPrimaryKey = false;
                colvarNombreReferencia.IsForeignKey = false;
                colvarNombreReferencia.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreReferencia);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("ConsultasReferenciasComerciales",schema);
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
	    public ConsultasReferenciasComerciales()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConsultasReferenciasComerciales(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConsultasReferenciasComerciales(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConsultasReferenciasComerciales(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ReferenciaComercialId")]
        [Bindable(true)]
        public int ReferenciaComercialId 
	    {
		    get
		    {
			    return GetColumnValue<int>("ReferenciaComercialId");
		    }
            set 
		    {
			    SetColumnValue("ReferenciaComercialId", value);
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
	      
        [XmlAttribute("NombreReferencia")]
        [Bindable(true)]
        public string NombreReferencia 
	    {
		    get
		    {
			    return GetColumnValue<string>("Nombre Referencia");
		    }
            set 
		    {
			    SetColumnValue("Nombre Referencia", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ReferenciaComercialId = @"ReferenciaComercialId";
            
            public static string RegistroId = @"RegistroId";
            
            public static string NombreReferencia = @"Nombre Referencia";
            
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
