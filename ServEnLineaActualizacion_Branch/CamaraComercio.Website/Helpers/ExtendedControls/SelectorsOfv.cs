using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
    /// <summary>
    /// RadioButtonList que se adhiere al esquema de PropiedadesUI
    /// </summary>
    public class RadioButtonListOfv : RadioButtonList, IExtendedControlOfv
    {
        /// <summary>
        /// Nombre de la propiedad para el UI
        /// </summary>
        public string PropertyName { get; set; }
    }

    ///<summary>
    /// Checkbox que se adhiere al esquema de PropiedadesUI
    ///</summary>
    public class CheckBoxOfv : CheckBox, IExtendedControlOfv
    {
        /// <summary>
        /// Nombre de la propiedad para el UI
        /// </summary>
        public string PropertyName { get; set; }
    }
}