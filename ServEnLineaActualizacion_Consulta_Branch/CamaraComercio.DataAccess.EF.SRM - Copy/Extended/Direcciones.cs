using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class Direcciones
    {
        public new string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Calle + " ");
            sb.Append(this.Numero + ", ");
            sb.Append(this.CiudadDescripcion + ", ");
            if ( !String.IsNullOrEmpty(this.SectorDescripcion) )
                sb.Append(this.SectorDescripcion + ", ");
            if ( !String.IsNullOrEmpty(this.ApartadoPostal) )
                sb.Append("Apt. Postal " + this.ApartadoPostal + ", ");
            sb.Append(this.PaisDescripcion + " ");
            return sb.ToString();
        }
    }
}
