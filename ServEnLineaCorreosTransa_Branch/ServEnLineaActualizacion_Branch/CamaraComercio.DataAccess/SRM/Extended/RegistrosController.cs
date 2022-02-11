using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SubSonic;

namespace CamaraComercio.DataAccess.SRM
{
    public partial class RegistrosController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RegistrosCollection FetchByIDCollection(object ColeccionIds)
        {
            RegistrosCollection coll = new RegistrosCollection().Where("RegistroId", Comparison.In, ColeccionIds).Load();
            return coll;
        }
    }
}
