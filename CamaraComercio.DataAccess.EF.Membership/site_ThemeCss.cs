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
    public partial class site_ThemeCss
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string CssId = @"CssId";
    public static string CssUrl = @"CssUrl";
    public static string CssName = @"CssName";
    public static string CssDescription = @"CssDescription";
    public static string ThemeCategory = @"ThemeCategory";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int CssId
        {
            get;
            set;
        }
    
        public virtual string CssUrl
        {
            get;
            set;
        }
    
        public virtual string CssName
        {
            get;
            set;
        }
    
        public virtual string CssDescription
        {
            get;
            set;
        }
    
        public virtual string ThemeCategory
        {
            get;
            set;
        }

        #endregion

    }
}
