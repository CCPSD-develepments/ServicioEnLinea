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
    public partial class aspnet_SchemaVersions
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string Feature = @"Feature";
    public static string CompatibleSchemaVersion = @"CompatibleSchemaVersion";
    public static string IsCurrentVersion = @"IsCurrentVersion";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual string Feature
        {
            get;
            set;
        }
    
        public virtual string CompatibleSchemaVersion
        {
            get;
            set;
        }
    
        public virtual bool IsCurrentVersion
        {
            get;
            set;
        }

        #endregion

    }
}
