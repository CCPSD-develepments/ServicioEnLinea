using System.Linq;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio de Nomenclaturas
    /// </summary>
    public class NomenclaturasRepository : Repository<Nomenclaturas, CamaraComunEntities>
    {   
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public NomenclaturasRepository()
        {
        }

        /// <summary>
        /// Obtiene todas las nomenclaturas en una cámara de comercio
        /// </summary>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <param name="tipo">Tipo de nomenclatura</param>
        /// <returns></returns>
        public Nomenclaturas FetchByCamaraId(string camaraId, string tipo)
        {
            return Session.Nomenclaturas
                .Where(o => o.CamaraId == camaraId && o.TipoNomenclatura == tipo)
                .SingleOrDefault();
        }
    }
}
