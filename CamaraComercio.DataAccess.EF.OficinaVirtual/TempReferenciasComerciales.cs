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
    public partial class TempReferenciasComerciales
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string Id = @"Id";	
    	public static string IdReferencias = @"IdReferencias";	
    	public static string Descripcion = @"Descripcion";	
    	public static string TransaccionId = @"TransaccionId";	
    	public static string Usuario = @"Usuario";	
    	public static string TipoReferencia = @"TipoReferencia";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual Nullable<int> IdReferencias
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TransaccionId
        {
            get;
            set;
        }
    
        public virtual string Usuario
        {
            get;
            set;
        }
    
        public virtual string TipoReferencia
        {
            get;
            set;
        }

        #endregion

    }
}
