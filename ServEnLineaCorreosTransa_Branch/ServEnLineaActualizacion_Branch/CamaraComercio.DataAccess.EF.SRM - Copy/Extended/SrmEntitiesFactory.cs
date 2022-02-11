using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class CamaraSRMEntitiesFactory
    {
        /// <summary>
        /// Genera un context para CamaraSrmEntities a partir del CanaraID Epecificado
        /// </summary>
        /// <param name="camaraId">ID de tres caracteres que identifica la base de datos para la camara</param>
        /// <returns></returns>
        public static CamaraSRMEntities CreateSrmEntitiesContext(string camaraId)
        {
            if (camaraId == null) return null;

            var connString = Helpers.GetCamaraConnString(camaraId);
            return new CamaraSRMEntities(connString);
        }
    }
}
