using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class SucursalController
    {
        public SucursalCollection FetchBySociedadID(int sociedadID)
        {
            return new Select().From(Sucursal.Schema).
                Where(Sucursal.SociedadIdColumn).IsEqualTo(sociedadID).
                ExecuteAsCollection<SucursalCollection>();
        }
    }
}