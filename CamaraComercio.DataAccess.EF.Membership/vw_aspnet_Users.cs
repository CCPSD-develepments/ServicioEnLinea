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
    public partial class vw_aspnet_Users
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string ApplicationId = @"ApplicationId";
    public static string UserId = @"UserId";
    public static string UserName = @"UserName";
    public static string LoweredUserName = @"LoweredUserName";
    public static string MobileAlias = @"MobileAlias";
    public static string IsAnonymous = @"IsAnonymous";
    public static string LastActivityDate = @"LastActivityDate";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual System.Guid ApplicationId
        {
            get;
            set;
        }
    
        public virtual System.Guid UserId
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }
    
        public virtual string LoweredUserName
        {
            get;
            set;
        }
    
        public virtual string MobileAlias
        {
            get;
            set;
        }
    
        public virtual bool IsAnonymous
        {
            get;
            set;
        }
    
        public virtual System.DateTime LastActivityDate
        {
            get;
            set;
        }

        #endregion

    }
}
