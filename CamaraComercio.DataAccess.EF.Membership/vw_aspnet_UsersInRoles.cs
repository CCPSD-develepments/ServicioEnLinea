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

namespace CamaraComercio.DataAccess.EF.Membership
{
    public partial class vw_aspnet_UsersInRoles
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string UserId = @"UserId";
    public static string RoleId = @"RoleId";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual System.Guid UserId
        {
            get;
            set;
        }
    
        public virtual System.Guid RoleId
        {
            get;
            set;
        }

        #endregion

    }
}
