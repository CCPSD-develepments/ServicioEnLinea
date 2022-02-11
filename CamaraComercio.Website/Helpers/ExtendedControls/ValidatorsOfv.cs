using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RequiredValidatorOfv'
    public class RequiredValidatorOfv : RequiredFieldValidator, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RequiredValidatorOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RequiredValidatorOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RequiredValidatorOfv.PropertyName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RequiredValidatorOfv.RequiredValidatorOfv()'
        public RequiredValidatorOfv() : base()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RequiredValidatorOfv.RequiredValidatorOfv()'
        {
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RangeValidatorOfv'
    public class RangeValidatorOfv : RangeValidator, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RangeValidatorOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RangeValidatorOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RangeValidatorOfv.PropertyName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RangeValidatorOfv.RangeValidatorOfv()'
        public RangeValidatorOfv()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RangeValidatorOfv.RangeValidatorOfv()'
            : base()
        {
        }
    }
}