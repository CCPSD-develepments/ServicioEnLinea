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
    public partial class sp_wsat_GetUsersByName_Result
    {
        #region Primitive Properties
    
        public Nullable<long> RowNumber
        {
            get;
            set;
        }
    
        public string UserName
        {
            get;
            set;
        }
    
        public string Email
        {
            get;
            set;
        }
    
        public bool IsApproved
        {
            get;
            set;
        }
    
        public bool IsLockedOut
        {
            get;
            set;
        }
    
        public System.DateTime CreateDate
        {
            get;
            set;
        }
    
        public System.DateTime LastLoginDate
        {
            get;
            set;
        }
    
        public System.DateTime LastActivityDate
        {
            get;
            set;
        }

        #endregion

    }
}
