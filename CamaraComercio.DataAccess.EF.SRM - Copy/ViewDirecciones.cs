//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class ViewDirecciones
    {
        #region Property Metadata
    	
    	public struct PropColumns
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
    public static string SectorDgii = @"SectorDgii";
    public static string SectorDgiiId = @"SectorDgiiId";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int DireccionId
        {
            get;
            set;
        }
    
        public virtual string Calle
        {
            get;
            set;
        }
    
        public virtual string Numero
        {
            get;
            set;
        }
    
        public virtual Nullable<int> CiudadId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SectorId
        {
            get;
            set;
        }
    
        public virtual string ApartadoPostal
        {
            get;
            set;
        }
    
        public virtual string TelefonoCasa
        {
            get;
            set;
        }
    
        public virtual string TelefonoOficina
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Extension
        {
            get;
            set;
        }
    
        public virtual string Fax
        {
            get;
            set;
        }
    
        public virtual string Email
        {
            get;
            set;
        }
    
        public virtual string SitioWeb
        {
            get;
            set;
        }
    
        public virtual string Ciudad
        {
            get;
            set;
        }
    
        public virtual string Sector
        {
            get;
            set;
        }
    
        public virtual string Pais
        {
            get;
            set;
        }
    
        public virtual Nullable<int> PaisId
        {
            get;
            set;
        }
    
        public virtual string SectorDgii
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SectorDgiiId
        {
            get;
            set;
        }

        #endregion

    }
}
