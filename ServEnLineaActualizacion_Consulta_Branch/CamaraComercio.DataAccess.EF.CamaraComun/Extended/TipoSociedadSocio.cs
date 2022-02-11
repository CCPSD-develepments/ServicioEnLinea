using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    public partial class TipoSociedadSocio
    {
        private int _cargoId = 0;
        public int CargoId
        {
            get { return _cargoId; }
            set { _cargoId = value; }
        }
        public int CantAcciones { get; set; }
    }
}
