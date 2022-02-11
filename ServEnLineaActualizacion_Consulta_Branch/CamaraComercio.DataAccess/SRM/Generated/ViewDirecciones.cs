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
    /// Strongly-typed collection for the ViewDirecciones class.
    /// </summary>
    [Serializable]
    public partial class ViewDireccionesCollection : ReadOnlyList<ViewDirecciones, ViewDireccionesCollection>
    {        
        public ViewDireccionesCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the cvw_Direcciones view.
    /// </summary>
    [Serializable]
    public partial class ViewDirecciones : ReadOnlyRecord<ViewDirecciones>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("cvw_Direcciones", TableType.View, DataService.GetInstance("SrmProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Persona";
                //columns
                
                TableSchema.TableColumn colvarDireccionId = new TableSchema.TableColumn(schema);
                colvarDireccionId.ColumnName = "DireccionId";
                colvarDireccionId.DataType = DbType.Int32;
                colvarDireccionId.MaxLength = 0;
                colvarDireccionId.AutoIncrement = false;
                colvarDireccionId.IsNullable = false;
                colvarDireccionId.IsPrimaryKey = false;
                colvarDireccionId.IsForeignKey = false;
                colvarDireccionId.IsReadOnly = false;
                
                schema.Columns.Add(colvarDireccionId);
                
                TableSchema.TableColumn colvarCalle = new TableSchema.TableColumn(schema);
                colvarCalle.ColumnName = "Calle";
                colvarCalle.DataType = DbType.String;
                colvarCalle.MaxLength = 256;
                colvarCalle.AutoIncrement = false;
                colvarCalle.IsNullable = true;
                colvarCalle.IsPrimaryKey = false;
                colvarCalle.IsForeignKey = false;
                colvarCalle.IsReadOnly = false;
                
                schema.Columns.Add(colvarCalle);
                
                TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
                colvarNumero.ColumnName = "Numero";
                colvarNumero.DataType = DbType.String;
                colvarNumero.MaxLength = 6;
                colvarNumero.AutoIncrement = false;
                colvarNumero.IsNullable = true;
                colvarNumero.IsPrimaryKey = false;
                colvarNumero.IsForeignKey = false;
                colvarNumero.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumero);
                
                TableSchema.TableColumn colvarCiudadId = new TableSchema.TableColumn(schema);
                colvarCiudadId.ColumnName = "CiudadId";
                colvarCiudadId.DataType = DbType.Int32;
                colvarCiudadId.MaxLength = 0;
                colvarCiudadId.AutoIncrement = false;
                colvarCiudadId.IsNullable = true;
                colvarCiudadId.IsPrimaryKey = false;
                colvarCiudadId.IsForeignKey = false;
                colvarCiudadId.IsReadOnly = false;
                
                schema.Columns.Add(colvarCiudadId);
                
                TableSchema.TableColumn colvarSectorId = new TableSchema.TableColumn(schema);
                colvarSectorId.ColumnName = "SectorId";
                colvarSectorId.DataType = DbType.Int32;
                colvarSectorId.MaxLength = 0;
                colvarSectorId.AutoIncrement = false;
                colvarSectorId.IsNullable = true;
                colvarSectorId.IsPrimaryKey = false;
                colvarSectorId.IsForeignKey = false;
                colvarSectorId.IsReadOnly = false;
                
                schema.Columns.Add(colvarSectorId);
                
                TableSchema.TableColumn colvarApartadoPostal = new TableSchema.TableColumn(schema);
                colvarApartadoPostal.ColumnName = "ApartadoPostal";
                colvarApartadoPostal.DataType = DbType.String;
                colvarApartadoPostal.MaxLength = 20;
                colvarApartadoPostal.AutoIncrement = false;
                colvarApartadoPostal.IsNullable = true;
                colvarApartadoPostal.IsPrimaryKey = false;
                colvarApartadoPostal.IsForeignKey = false;
                colvarApartadoPostal.IsReadOnly = false;
                
                schema.Columns.Add(colvarApartadoPostal);
                
                TableSchema.TableColumn colvarTelefonoCasa = new TableSchema.TableColumn(schema);
                colvarTelefonoCasa.ColumnName = "TelefonoCasa";
                colvarTelefonoCasa.DataType = DbType.String;
                colvarTelefonoCasa.MaxLength = 15;
                colvarTelefonoCasa.AutoIncrement = false;
                colvarTelefonoCasa.IsNullable = true;
                colvarTelefonoCasa.IsPrimaryKey = false;
                colvarTelefonoCasa.IsForeignKey = false;
                colvarTelefonoCasa.IsReadOnly = false;
                
                schema.Columns.Add(colvarTelefonoCasa);
                
                TableSchema.TableColumn colvarTelefonoOficina = new TableSchema.TableColumn(schema);
                colvarTelefonoOficina.ColumnName = "TelefonoOficina";
                colvarTelefonoOficina.DataType = DbType.String;
                colvarTelefonoOficina.MaxLength = 15;
                colvarTelefonoOficina.AutoIncrement = false;
                colvarTelefonoOficina.IsNullable = true;
                colvarTelefonoOficina.IsPrimaryKey = false;
                colvarTelefonoOficina.IsForeignKey = false;
                colvarTelefonoOficina.IsReadOnly = false;
                
                schema.Columns.Add(colvarTelefonoOficina);
                
                TableSchema.TableColumn colvarExtension = new TableSchema.TableColumn(schema);
                colvarExtension.ColumnName = "Extension";
                colvarExtension.DataType = DbType.Int32;
                colvarExtension.MaxLength = 0;
                colvarExtension.AutoIncrement = false;
                colvarExtension.IsNullable = true;
                colvarExtension.IsPrimaryKey = false;
                colvarExtension.IsForeignKey = false;
                colvarExtension.IsReadOnly = false;
                
                schema.Columns.Add(colvarExtension);
                
                TableSchema.TableColumn colvarFax = new TableSchema.TableColumn(schema);
                colvarFax.ColumnName = "Fax";
                colvarFax.DataType = DbType.String;
                colvarFax.MaxLength = 15;
                colvarFax.AutoIncrement = false;
                colvarFax.IsNullable = true;
                colvarFax.IsPrimaryKey = false;
                colvarFax.IsForeignKey = false;
                colvarFax.IsReadOnly = false;
                
                schema.Columns.Add(colvarFax);
                
                TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
                colvarEmail.ColumnName = "Email";
                colvarEmail.DataType = DbType.String;
                colvarEmail.MaxLength = 256;
                colvarEmail.AutoIncrement = false;
                colvarEmail.IsNullable = true;
                colvarEmail.IsPrimaryKey = false;
                colvarEmail.IsForeignKey = false;
                colvarEmail.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmail);
                
                TableSchema.TableColumn colvarSitioWeb = new TableSchema.TableColumn(schema);
                colvarSitioWeb.ColumnName = "SitioWeb";
                colvarSitioWeb.DataType = DbType.String;
                colvarSitioWeb.MaxLength = 256;
                colvarSitioWeb.AutoIncrement = false;
                colvarSitioWeb.IsNullable = true;
                colvarSitioWeb.IsPrimaryKey = false;
                colvarSitioWeb.IsForeignKey = false;
                colvarSitioWeb.IsReadOnly = false;
                
                schema.Columns.Add(colvarSitioWeb);
                
                TableSchema.TableColumn colvarCiudad = new TableSchema.TableColumn(schema);
                colvarCiudad.ColumnName = "Ciudad";
                colvarCiudad.DataType = DbType.String;
                colvarCiudad.MaxLength = 50;
                colvarCiudad.AutoIncrement = false;
                colvarCiudad.IsNullable = true;
                colvarCiudad.IsPrimaryKey = false;
                colvarCiudad.IsForeignKey = false;
                colvarCiudad.IsReadOnly = false;
                
                schema.Columns.Add(colvarCiudad);
                
                TableSchema.TableColumn colvarSector = new TableSchema.TableColumn(schema);
                colvarSector.ColumnName = "Sector";
                colvarSector.DataType = DbType.String;
                colvarSector.MaxLength = 100;
                colvarSector.AutoIncrement = false;
                colvarSector.IsNullable = true;
                colvarSector.IsPrimaryKey = false;
                colvarSector.IsForeignKey = false;
                colvarSector.IsReadOnly = false;
                
                schema.Columns.Add(colvarSector);
                
                TableSchema.TableColumn colvarPais = new TableSchema.TableColumn(schema);
                colvarPais.ColumnName = "Pais";
                colvarPais.DataType = DbType.String;
                colvarPais.MaxLength = 50;
                colvarPais.AutoIncrement = false;
                colvarPais.IsNullable = true;
                colvarPais.IsPrimaryKey = false;
                colvarPais.IsForeignKey = false;
                colvarPais.IsReadOnly = false;
                
                schema.Columns.Add(colvarPais);
                
                TableSchema.TableColumn colvarPaisId = new TableSchema.TableColumn(schema);
                colvarPaisId.ColumnName = "PaisId";
                colvarPaisId.DataType = DbType.Int32;
                colvarPaisId.MaxLength = 0;
                colvarPaisId.AutoIncrement = false;
                colvarPaisId.IsNullable = true;
                colvarPaisId.IsPrimaryKey = false;
                colvarPaisId.IsForeignKey = false;
                colvarPaisId.IsReadOnly = false;
                
                schema.Columns.Add(colvarPaisId);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SrmProvider"].AddSchema("cvw_Direcciones",schema);
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
	    public ViewDirecciones()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ViewDirecciones(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ViewDirecciones(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ViewDirecciones(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("DireccionId")]
        [Bindable(true)]
        public int DireccionId 
	    {
		    get
		    {
			    return GetColumnValue<int>("DireccionId");
		    }
            set 
		    {
			    SetColumnValue("DireccionId", value);
            }
        }
	      
        [XmlAttribute("Calle")]
        [Bindable(true)]
        public string Calle 
	    {
		    get
		    {
			    return GetColumnValue<string>("Calle");
		    }
            set 
		    {
			    SetColumnValue("Calle", value);
            }
        }
	      
        [XmlAttribute("Numero")]
        [Bindable(true)]
        public string Numero 
	    {
		    get
		    {
			    return GetColumnValue<string>("Numero");
		    }
            set 
		    {
			    SetColumnValue("Numero", value);
            }
        }
	      
        [XmlAttribute("CiudadId")]
        [Bindable(true)]
        public int? CiudadId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CiudadId");
		    }
            set 
		    {
			    SetColumnValue("CiudadId", value);
            }
        }
	      
        [XmlAttribute("SectorId")]
        [Bindable(true)]
        public int? SectorId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("SectorId");
		    }
            set 
		    {
			    SetColumnValue("SectorId", value);
            }
        }
	      
        [XmlAttribute("ApartadoPostal")]
        [Bindable(true)]
        public string ApartadoPostal 
	    {
		    get
		    {
			    return GetColumnValue<string>("ApartadoPostal");
		    }
            set 
		    {
			    SetColumnValue("ApartadoPostal", value);
            }
        }
	      
        [XmlAttribute("TelefonoCasa")]
        [Bindable(true)]
        public string TelefonoCasa 
	    {
		    get
		    {
			    return GetColumnValue<string>("TelefonoCasa");
		    }
            set 
		    {
			    SetColumnValue("TelefonoCasa", value);
            }
        }
	      
        [XmlAttribute("TelefonoOficina")]
        [Bindable(true)]
        public string TelefonoOficina 
	    {
		    get
		    {
			    return GetColumnValue<string>("TelefonoOficina");
		    }
            set 
		    {
			    SetColumnValue("TelefonoOficina", value);
            }
        }
	      
        [XmlAttribute("Extension")]
        [Bindable(true)]
        public int? Extension 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Extension");
		    }
            set 
		    {
			    SetColumnValue("Extension", value);
            }
        }
	      
        [XmlAttribute("Fax")]
        [Bindable(true)]
        public string Fax 
	    {
		    get
		    {
			    return GetColumnValue<string>("Fax");
		    }
            set 
		    {
			    SetColumnValue("Fax", value);
            }
        }
	      
        [XmlAttribute("Email")]
        [Bindable(true)]
        public string Email 
	    {
		    get
		    {
			    return GetColumnValue<string>("Email");
		    }
            set 
		    {
			    SetColumnValue("Email", value);
            }
        }
	      
        [XmlAttribute("SitioWeb")]
        [Bindable(true)]
        public string SitioWeb 
	    {
		    get
		    {
			    return GetColumnValue<string>("SitioWeb");
		    }
            set 
		    {
			    SetColumnValue("SitioWeb", value);
            }
        }
	      
        [XmlAttribute("Ciudad")]
        [Bindable(true)]
        public string Ciudad 
	    {
		    get
		    {
			    return GetColumnValue<string>("Ciudad");
		    }
            set 
		    {
			    SetColumnValue("Ciudad", value);
            }
        }
	      
        [XmlAttribute("Sector")]
        [Bindable(true)]
        public string Sector 
	    {
		    get
		    {
			    return GetColumnValue<string>("Sector");
		    }
            set 
		    {
			    SetColumnValue("Sector", value);
            }
        }
	      
        [XmlAttribute("Pais")]
        [Bindable(true)]
        public string Pais 
	    {
		    get
		    {
			    return GetColumnValue<string>("Pais");
		    }
            set 
		    {
			    SetColumnValue("Pais", value);
            }
        }
	      
        [XmlAttribute("PaisId")]
        [Bindable(true)]
        public int? PaisId 
	    {
		    get
		    {
			    return GetColumnValue<int?>("PaisId");
		    }
            set 
		    {
			    SetColumnValue("PaisId", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string DireccionId = @"DireccionId";
            
            public static string Calle = @"Calle";
            
            public static string Numero = @"Numero";
            
            public static string CiudadId = @"CiudadId";
            
            public static string SectorId = @"SectorId";
            
            public static string ApartadoPostal = @"ApartadoPostal";
            
            public static string TelefonoCasa = @"TelefonoCasa";
            
            public static string TelefonoOficina = @"TelefonoOficina";
            
            public static string Extension = @"Extension";
            
            public static string Fax = @"Fax";
            
            public static string Email = @"Email";
            
            public static string SitioWeb = @"SitioWeb";
            
            public static string Ciudad = @"Ciudad";
            
            public static string Sector = @"Sector";
            
            public static string Pais = @"Pais";
            
            public static string PaisId = @"PaisId";
            
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
