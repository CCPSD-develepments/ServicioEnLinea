using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class CamarasController
    {
        /// <summary>
        /// Retorna la colección de camaras activas en el sistema
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CamarasCollection FetchAllActivas()
        {
            CamarasCollection coll = new CamarasCollection();
            Query qry = new Query(Camaras.Schema).WHERE(Camaras.Columns.Activa, true);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
    }
}