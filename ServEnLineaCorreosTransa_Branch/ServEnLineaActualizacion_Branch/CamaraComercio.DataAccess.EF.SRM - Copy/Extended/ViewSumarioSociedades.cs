using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class ViewSumarioSociedades
    {
        [XmlAttribute("CamaraID")]
        [Bindable(true)]
        public string CamaraID { get; set; }

        /// <summary>
        /// Estado de la sociedad o empresa
        /// </summary>
        [XmlAttribute("Estatus")]
        [Bindable(true)]
        public string Estatus
        {
            get
            {
                var valorEstado = EstatusId.HasValue ? EstatusId.Value : 0;
                var name = EnumHelper<SociedadesEstatudId>.ObtenerDescripcion(valorEstado);
                return name;
            }
        }


        /// <summary>
        /// TransaccionId de la empresa.
        /// </summary>
        [XmlAttribute("TransaccionId")]
        [Bindable(true)]
        public int? TransaccionId
        {
            get;
            set;
        }
    }
}
