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
    public partial class UsuariosEstatus
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string EstatusUsuarioId = @"EstatusUsuarioId";
    public static string UsuarioId = @"UsuarioId";
    public static string EstatusTransId = @"EstatusTransId";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int EstatusUsuarioId
        {
            get;
            set;
        }
    
        public virtual int UsuarioId
        {
            get;
            set;
        }
    
        public virtual int EstatusTransId
        {
            get;
            set;
        }

        #endregion

    }
}
