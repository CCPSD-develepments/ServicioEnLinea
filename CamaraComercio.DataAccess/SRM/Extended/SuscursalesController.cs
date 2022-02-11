using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.SRM
{
    public partial class SuscursalesController
    {
        /// <summary>
        /// Obtiene todas las sucursales de una empresa.
        /// </summary>
        /// <param name="sociedadId">Id de la sociedad.</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns>Retorna todas las sucursales de una empresa registrada.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SuscursalesCollection FetchSucursalesByRegistroId(int sociedadId, string camaraId)
        {
            using (SharedDbConnectionScope scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                SuscursalesCollection col =
                    new SuscursalesCollection().Where(Suscursales.Columns.SociedadId, sociedadId).Load();

                return col;
            }
        }
    }
}
