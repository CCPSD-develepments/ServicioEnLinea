using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class ReferenciaComercialController
    {
        public ReferenciaComercialCollection FetchByRegistroID(int registroID)
        {
            return new Select().From(ReferenciaComercial.Schema).
                Where(ReferenciaComercial.RegistroIdColumn).IsEqualTo(registroID).
                ExecuteAsCollection<ReferenciaComercialCollection>();
        }
    }
}