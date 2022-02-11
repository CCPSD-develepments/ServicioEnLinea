using System;
using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class SectorController
    {
        /// <summary>
        /// Retorna todos los sectores para una ciudad
        /// </summary>
        /// <param name="ciudadId">ID de la ciudad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SectorCollection FetchByCiudad(int ciudadId)
        {
            SectorCollection col = FetchByQuery(new Query(Sector.Schema).AddWhere(Sector.Columns.CiudadId, ciudadId));
            col.Sort("Nombre", true);
            return col;
        }

        /// <summary>
        /// Obtiene el nombre de un sector a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNombreSector(int id)
        {
            try
            {
                return new Select().From(Sector.Schema).
                    Where(Sector.Columns.SectorId).IsEqualTo(id).ExecuteSingle<Sector>().Nombre;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}