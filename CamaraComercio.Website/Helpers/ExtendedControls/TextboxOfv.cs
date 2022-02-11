using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TextBoxOfv'
    public class TextBoxOfv : TextBox, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TextBoxOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TextBoxOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TextBoxOfv.PropertyName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TextBoxOfv.TextBoxOfv()'
        public TextBoxOfv() : base()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TextBoxOfv.TextBoxOfv()'
        {
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NumericTextBoxOfv'
    public class NumericTextBoxOfv : RadNumericTextBox, IExtendedControlOfv
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NumericTextBoxOfv'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NumericTextBoxOfv.PropertyName'
        public string PropertyName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NumericTextBoxOfv.PropertyName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NumericTextBoxOfv.NumericTextBoxOfv()'
        public NumericTextBoxOfv()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NumericTextBoxOfv.NumericTextBoxOfv()'
            : base()
        {
        }
    }
}