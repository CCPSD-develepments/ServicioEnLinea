using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class TarifaController
    {
        /// <summary>
        /// Retorna las tarifas para el monto proveido
        /// </summary>
        /// <param name="monto"></param>
        /// <returns></returns>
        public Tarifa FetchByMonto(decimal monto)
        {
            return new Select().From(Tarifa.Schema).
                Where(Tarifa.MontoInicialColumn).IsLessThanOrEqualTo(monto).
                And(Tarifa.MontoFinalColumn).IsGreaterThanOrEqualTo(monto).
                ExecuteSingle<Tarifa>();
        }
    }
}