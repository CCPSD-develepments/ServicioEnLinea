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
    public partial class TransaccionesEmpBHD
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string Id = @"Id";	
    	public static string reference = @"reference";	
    	public static string TransactionId = @"TransactionId";	
    	public static string Estatus = @"Estatus";	
    	public static string UserName = @"UserName";	
    	public static string SolicitudId = @"SolicitudId";	
    	public static string FechaModificacion = @"FechaModificacion";	
    	public static string EstadoString = @"EstadoString";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string reference
        {
            get;
            set;
        }
    
        public virtual string TransactionId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Estatus
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SolicitudId
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaModificacion
        {
            get;
            set;
        }
    
        public virtual string EstadoString
        {
            get;
            set;
        }

        #endregion

    }
}
