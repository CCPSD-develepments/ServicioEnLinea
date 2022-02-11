using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DropdownListOfv'
    public class DropdownListOfv: DropDownList, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DropdownListOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DropdownListOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DropdownListOfv.PropertyName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DropdownListOfv.DropdownListOfv()'
        public DropdownListOfv() : base()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DropdownListOfv.DropdownListOfv()'
        {
        }
    }
}