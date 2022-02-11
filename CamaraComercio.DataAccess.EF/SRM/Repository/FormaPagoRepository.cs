using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public class FormaPagoRepository : Repository<SRM.FormasPagos, SRM.CamaraSRMEntities>
    {
        
        public FormaPagoRepository(string camaraID) :
            base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        {
        }

        public FormaPagoRepository(CamaraSRMEntities context) : base(context) { }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<SRM.FormasPagos> GetFormasPorFactura(int facturaId)
        {
            var db = this.Session;
            return db.FormasPagos.Where(f => f.FacturaId == facturaId);
        }
    }
}
