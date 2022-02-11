using System.ComponentModel;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
    interface IExtendedControlOfv
    {
        [Description("Property Name")]
        string PropertyName { get; set; }
    }
}
