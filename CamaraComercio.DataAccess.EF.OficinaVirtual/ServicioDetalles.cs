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

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    [Serializable]
    public partial class ServicioDetalles
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string ServicioId = @"ServicioId";	
    	public static string Url = @"Url";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int ServicioId
        {
            get;
            set;
        }
    
        public virtual string Url
        {
            get;
            set;
        }

        #endregion

    }
}
