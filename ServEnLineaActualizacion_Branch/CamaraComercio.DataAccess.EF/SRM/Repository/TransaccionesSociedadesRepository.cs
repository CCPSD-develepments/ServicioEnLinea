using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    [DataObject]
    public class TransaccionesSociedadesRepository : Repository<TransaccionesSociedades, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraId">ID de la Cámara</param>
        public TransaccionesSociedadesRepository(String camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {
        }

        public TransaccionesSociedadesRepository(CamaraSRMEntities context)
            : base(context)
        {
        }

    }
}

