using System;
using SubSonic;
using System.Linq;
namespace CamaraComercio.DataAccess.OficinaVirtual
{
    /// <summary>
    /// Retorna todas las referencias bancarias de un registro
    /// </summary>
    public partial class ReferenciaBancariaController
    {
        public ReferenciaBancariaCollection FetchByRegistroId(int registroID)
        {
            ReferenciaBancariaCollection colRefsBancarias = new ReferenciaBancariaCollection();
            BancoCollection colBancos = new BancoCollection();
            try
            {
                colRefsBancarias = new Select().From(ReferenciaBancaria.Schema).
                    Where(ReferenciaBancaria.RegistroIdColumn).IsEqualTo(registroID).
                    ExecuteAsCollection<ReferenciaBancariaCollection>();

                colBancos = new BancoController().FetchAll();

                foreach (var refBancaria in colRefsBancarias)
                {
                    refBancaria.NombreBanco = (from b in colBancos
                                               where b.BancoId == refBancaria.BancoId
                                               select b.Descripcion).First();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return colRefsBancarias;
        }
    }
}