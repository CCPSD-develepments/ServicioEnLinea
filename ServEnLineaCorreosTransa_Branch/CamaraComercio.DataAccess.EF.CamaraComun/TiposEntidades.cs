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
    public partial class TiposEntidades
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string TipoEntidadId = @"TipoEntidadId";	
    	public static string Descripcion = @"Descripcion";	
    	public static string Visible = @"Visible";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TipoEntidadId
        {
            get;
            set;
        }
    
        public virtual string Descripcion
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
