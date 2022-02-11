using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class ProductoController
    {
        public ProductoCollection FetchByRegistroID(int registroID)
        {
            return new Select().From(Producto.Schema).Where(Producto.RegistroIdColumn).
                IsEqualTo(registroID).ExecuteAsCollection<ProductoCollection>();
        }
    }
}