using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.Comun
{
    public partial class TipoSociedad
    {
        public String this[int tipoSociedadId]
        {
            get
            {
                

                TipoSociedadController controller = new TipoSociedadController();
                return controller.FetchByID(tipoSociedadId).First().Descripcion;
            }

        }
    }
}
