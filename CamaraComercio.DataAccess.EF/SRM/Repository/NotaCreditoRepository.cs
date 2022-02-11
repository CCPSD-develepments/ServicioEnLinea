using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM.Repository
{
    /// <summary>
    /// Repositorio de Notas de Çrédito.
    /// </summary>
    public class NotaCreditoRepository : Repository<NotasCredito, CamaraSRMEntities>
    {
        public NotaCreditoRepository(string camaraID)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID)) { }

        public NotasCredito FetchByNotaId(int notaId)
        {
            return Session.NotasCredito.Where(o => o.NotaCreditoID == notaId).FirstOrDefault();
        }
    }
}
