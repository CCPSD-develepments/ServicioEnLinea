using System;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class TipoActividadController
    {
        /// <summary>
        /// Obtiene el nombre de una actividad a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNombreActividad(int id)
        {
            try
            {
                return new Select().From(TipoActividad.Schema).
                    Where(TipoActividad.Columns.TipoActividadId).IsEqualTo(id).ExecuteSingle<TipoActividad>().
                    Descripcion;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}