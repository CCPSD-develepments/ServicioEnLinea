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
    public partial class TiposContadores
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string TipoContadorId = @"TipoContadorId";
    public static string NombreContado = @"NombreContado";
    public static string ContadorTag = @"ContadorTag";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TipoContadorId
        {
            get;
            set;
        }
    
        public virtual string NombreContado
        {
            get;
            set;
        }
    
        public virtual string ContadorTag
        {
            get;
            set;
        }

        #endregion

    }
}
