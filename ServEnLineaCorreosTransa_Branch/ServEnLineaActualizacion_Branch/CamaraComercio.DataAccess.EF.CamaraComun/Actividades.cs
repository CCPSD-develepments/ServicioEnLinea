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

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    public partial class Actividades
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string ActividadID = @"ActividadID";	
    	public static string PadreID = @"PadreID";	
    	public static string Descripcion = @"Descripcion";	
    	public static string DescripconLarga = @"DescripconLarga";	
    	public static string FechaModificacion = @"FechaModificacion";	
    	public static string RecibeAccion = @"RecibeAccion";	
    	public static string TieneHijos = @"TieneHijos";	
    	public static string Visible = @"Visible";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int ActividadID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> PadreID
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }
    
        public virtual string DescripconLarga
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaModificacion
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> RecibeAccion
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> TieneHijos
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Visible
        {
            get;
            set;
        }

        #endregion

    }
}
