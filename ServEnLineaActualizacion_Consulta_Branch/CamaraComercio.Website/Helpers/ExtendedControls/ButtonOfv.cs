using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ButtonOfv'
    public class ButtonOfv : Button, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ButtonOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ButtonOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ButtonOfv.PropertyName'
    }
}