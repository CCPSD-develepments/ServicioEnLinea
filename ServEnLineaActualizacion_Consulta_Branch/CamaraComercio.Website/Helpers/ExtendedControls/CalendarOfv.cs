using System;
using System.Web.UI.WebControls;
using eWorld.UI;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfv'
    public class CalendarOfv : CalendarPopup, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfv.PropertyName'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfvRad'
    public class CalendarOfvRad : Telerik.Web.UI.RadDatePicker, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfvRad'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfvRad.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CalendarOfvRad.PropertyName'
    }
}