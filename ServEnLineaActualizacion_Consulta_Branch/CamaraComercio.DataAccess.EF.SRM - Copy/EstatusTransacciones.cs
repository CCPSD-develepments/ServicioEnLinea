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
    public partial class EstatusTransacciones
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string EstatusTransId = @"EstatusTransId";
    public static string EstatusTransaccion = @"EstatusTransaccion";
    public static string FlowStatus = @"FlowStatus";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int EstatusTransId
        {
            get;
            set;
        }
    
        public virtual string EstatusTransaccion
        {
            get;
            set;
        }
    
        public virtual string FlowStatus
        {
            get;
            set;
        }

        #endregion

    }
}
