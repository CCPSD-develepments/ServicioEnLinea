using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using CamaraComercio.Website.Operaciones.Registro;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'LabelOfv'
    public class LabelOfv : System.Web.UI.WebControls.Label, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'LabelOfv'
    {
        [Description("Property Name")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'LabelOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'LabelOfv.PropertyName'

        
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SpanOfv'
    public class SpanOfv : System.Web.UI.WebControls.Label, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SpanOfv'
    {
        [Description("Property Name")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SpanOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SpanOfv.PropertyName'
    }
}