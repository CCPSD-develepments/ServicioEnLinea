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
    public partial class TipoMoneda
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string TipoMonedaId = @"TipoMonedaId";	
    	public static string Descripcion = @"Descripcion";	
    	public static string Abreviatura = @"Abreviatura";	
    	public static string AbreviaturaAPI = @"AbreviaturaAPI";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TipoMonedaId
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }
    
        public virtual string Abreviatura
        {
            get;
            set;
        }
    
        public virtual string AbreviaturaAPI
        {
            get;
            set;
        }

        #endregion

    }
}
