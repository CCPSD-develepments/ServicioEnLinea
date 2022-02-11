using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class RegistroActividadesController
    {
        public RegistroActividadesCollection FetchByRegistroID(int registroID)
        {
            return new Select().From(RegistroActividades.Schema).
                Where(RegistroActividades.RegistroIdColumn).IsEqualTo(registroID).
                ExecuteAsCollection<RegistroActividadesCollection>();
        }
    }
}