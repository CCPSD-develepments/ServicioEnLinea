using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    [DataObject]
    public class TransaccionesPersonasRepository : Repository<TransaccionesPersonas, CamaraSRMEntities>
    {
        public TransaccionesPersonasRepository(String camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {

        }

        public TransaccionesPersonasRepository(CamaraSRMEntities context) 
            : base(context)
        {

        }
    }
}
