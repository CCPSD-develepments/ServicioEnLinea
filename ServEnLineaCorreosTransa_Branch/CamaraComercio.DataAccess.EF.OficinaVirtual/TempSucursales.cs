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
    public partial class TempSucursales
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string Id = @"Id";	
    	public static string SucursalId = @"SucursalId";	
    	public static string Descripcion = @"Descripcion";	
    	public static string TransaccionId = @"TransaccionId";	
    	public static string FechaModificacion = @"FechaModificacion";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SucursalId
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
    
        public virtual Nullable<System.DateTime> FechaModificacion
        {
            get;
            set;
        }

        #endregion

    }
}
